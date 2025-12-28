/*
 *	<copyright file="IUserRepository.cs"
 *	Copyright (c) 2025 All Rights Reserved
 *	</copyright>
 * 	<author>Edgar Casal</author>
 *   <date>18-12-2025 21:47:20</date>
 *	<description></description>
 **/

using BO;
using System;



namespace Data.Repository.Interface;


/// <summary>
/// Purpose: Defines the contract for accessing User data.
/// Any class that implements this interface must provide code for these methods.
/// Created by: Edgar Casal
/// Created on: 18-12-2025 21:47:20
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Saves a new User to the data store.
    /// </summary>
    /// <param name="user">The user to save</param>
    /// <returns>True if successful, False if the user ID already exists.</returns>
    bool AddUser(User user);
    
    /// <summary>
    /// Retrieves a single User by their unique ID.
    /// </summary>
    /// <param name="id">The user's ID</param>
    /// <returns>The User object, or null if not found.</returns>
    User GetUserById(int id);
    
    /// <summary>
    /// Retrieves a single User by their email address.
    /// </summary>
    /// <param name="email">The user's email</param>
    /// <returns>The User object, or null if not found.</returns>
    User GetUserByEmail(string email);
    
    /// <summary>
    /// Gets a list of all Users currently in the system.
    /// </summary>
    /// <returns>A list of User objects</returns>
    List<User> GetAllUsers();
    
    /// <summary>
    /// Removes a User from the data store.
    /// </summary>
    /// <param name="id">The ID of the user to remove</param>
    /// <returns>True if the user was found and removed.</returns>
    bool RemoveUser(int id);

    /// <summary>
    /// Saves all Users to a binary file
    /// </summary>
    void SaveUsers();

    /// <summary>
    /// Loads all Users from a binary file
    /// </summary>
    void LoadUsers();

}