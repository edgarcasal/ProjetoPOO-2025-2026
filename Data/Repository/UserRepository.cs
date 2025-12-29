/*
 *	<copyright file="UserRepo.cs"
 *	Copyright (c) 2025 All Rights Reserved
 *	</copyright>
 * 	<author>Edgar Casal</author>
 *   <date>18-12-2025 21:47:11</date>
 *	<description></description>
 **/
using BO;
using Data.Repository.Interface;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
#pragma warning disable SYSLIB0011

namespace Data.Repository;

/// <summary>
/// Purpose: The Data Access Layer for Users.
/// Implements the logic to Save, Load, and Search users in the 'Store'
/// This class acts as the bridge between the Service and the raw data.
/// Created by: Edgar Casal
/// Created on: 18-12-2025 21:47:11
/// </summary>
public class UserRepository:IUserRepository
{
    private const string FILE_PATH = "users.bin";
    
    #region Methods

    /// <summary>
    /// Adds a new User to the internal data dictionary.
    /// </summary>
    /// <param name="user">The User object containing ID, Name, etc.</param>
    /// <returns>True if added successfully, False if the ID already exists.</returns>
    public bool AddUser(User user)
    {
        if (Store.Users.ContainsKey(user.UserId))
        {
            return false;
        }
        
        Store.Users.Add(user.UserId, user);
        return true;
    }

    /// <summary>
    /// Searches for a user using their unique ID.
    /// Essential for finding users by the system's internal key.
    /// </summary>
    /// <param name="id">The unique integer ID of the user.</param>
    /// <returns>The User object if found, otherwise null.</returns>
    public User GetUserById(int id)
    {
        if (Store.Users.ContainsKey(id))
        {
            return Store.Users[id];
        }

        return null;
    }

    /// <summary>
    /// Performs a search to find a user by their email address.
    /// Used primarily during the Login process.
    /// </summary>
    /// <param name="email">The email to search for</param>
    /// <returns>The User object if a match is found, otherwise null.</returns>
    public User GetUserByEmail(string email)
    {
        foreach (User aux in Store.Users.Values)
        {
            if (aux.Email == email)
            {
                return aux;
            }
        }

        return null;
    }
    
    /// <summary>
    /// Retrieves all users currently stored in the system.
    /// </summary>
    /// <returns>A List containing every User object from the Store.</returns>
    public List<User> GetAllUsers()
    {
        return Store.Users.Values.ToList();
    }

    /// <summary>
    /// Deletes a user from the system based on their ID.
    /// </summary>
    /// <param name="id">The unique ID of the user to remove</param>
    /// <returns>True if the user was found and removed. False if the ID did not exist.</returns>
    public bool RemoveUser(int id)
    {
        if (Store.Users.ContainsKey(id))
        {
            Store.Users.Remove(id);
            return true;
        }

        return false;
    }


    /// <summary>
    /// Saves the current dictionary of users to a binary file
    /// If the file already exists it is deleted and recreated.
    /// </summary>
    public void SaveUsers()
    {
        FileStream fs = null;

        try
        {
            //If exists, deletes it first to start over
            if (File.Exists(FILE_PATH))
            {
                File.Delete(FILE_PATH);
            }

            //Creates the file
            fs = File.Create(FILE_PATH);

            //Serialize the dictionary
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, Store.Users);
        }
        catch (System.Exception e)
        {
            Console.WriteLine("Error saving file: " + e.Message);
        }
        finally
        {
            if (fs != null)
            {
                fs.Close();
            }
        }
    }

    /// <summary>
    /// Loads user data from the binary file
    /// This method clears the existing 'Store.Users' dictionary before to avoid duplicate conflicts.
    /// If the file does not exist, it ensures the Store remains empty but valid.
    /// </summary>
    public void LoadUsers()
    {
        FileStream fs = null;

        try
        {
            //Checks if file exists
            if (File.Exists(FILE_PATH))
            {
                //Opens the file
                fs = File.Open(FILE_PATH, FileMode.Open);

                // Checks if the file has data
                if (fs.Length > 0)
                { 
                    BinaryFormatter bf = new BinaryFormatter();
                
                    // Deserialize to a temporary dictionary
                    Dictionary<int, User> tempUsers = (Dictionary<int, User>)bf.Deserialize(fs);
               
                    // Clears the existing Store to avoid duplicates
                    Store.Users.Clear();

                    foreach (KeyValuePair<int, User> entry in tempUsers)
                    {
                        //where entry.Key is the id and entry.value is the user object
                        Store.Users.Add(entry.Key, entry.Value);
                    }
                }

                
            }
        }
        catch (System.Exception e)
        {
            Console.WriteLine("Error loading file: " + e.Message);
            // File might be corrupted so it starts fresh
            Store.Users.Clear();
        }
        finally
        {
            if (fs != null)
            {
                fs.Close();
            }
        }
    }

    #endregion
}