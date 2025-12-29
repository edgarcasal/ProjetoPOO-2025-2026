/*
*	<copyright file="UserService.cs" 
*	Copyright (c) 2025 All Rights Reserved
*	</copyright>
* 	<author>Edgar Casal</author>
*   <date>17-12-2025 17:44:22</date>
*	<description></description>
**/

using System;
using Data;
using Data.Repository;
using Data.Repository.Interface;
using BO;

namespace Rules;

/// <summary>
/// Purpose: Responsible for all business rules related to Users.
/// Handles account creation, login validation, and profile management.
/// Acts as the bridge between the UI and the Data
/// Created by: Edgar Casal
/// Created on: 17-12-2025 17:44:22
/// </summary>
public class UserService
{
    #region Attributes

    private IUserRepository repository;

    #endregion
    
    #region Methods
    
    #region Constructors

    public UserService()
    {
        repository = new UserRepository();
    }
    #endregion
    /// <summary>
    /// Creates a new user account if the email is not already taken.
    /// </summary>
    /// <param name="fName">First Name</param>
    /// <param name="lName">Last Name</param>
    /// <param name="email">Unique email address</param>
    /// <param name="password">Security password</param>
    /// <returns>True if registered successfully. False if email already exists.</returns>
    public bool RegisterUser(string fName, string lName, string email, string password)
    {
        // Check if email exists
        if (repository.GetUserByEmail(email) != null)
        {
            return false;
        }

        int newId = repository.GetAllUsers().Count + 1;

        User newUser = new User(newId, fName, lName, email, password);

        repository.AddUser(newUser);
        return true;
    }
    
    /// <summary>
    /// Validates credentials and returns the User object if successful.
    /// </summary>
    /// <param name="email">User's email</param>
    /// <param name="password">User's password</param>
    /// <returns>The user object if found and password matches, otherwise returns null.</returns>
    public User Login(string email, string password)
    {
        User aux = repository.GetUserByEmail(email);

        if (aux is Admin)
        {
            //return 
        }
        
        if (aux != null && aux.Password == password)
        {
            return aux;
        }

        return null;
    }

    /// <summary>
    /// Updates a user's password after verifying their identity.
    /// </summary>
    /// <param name="email">Identify the user by email</param>
    /// <param name="currentPassword">Must match current password</param>
    /// <param name="newPassword">The new password to set</param>
    /// <returns>True if the old password was correct and update succeeded.</returns>
    public bool ChangePassword(string email, string currentPassword, string newPassword)
    {
        User aux = repository.GetUserByEmail(email);
        if (aux == null || aux.Password != currentPassword)
        {
            return false;
        }
        
        aux.Password = newPassword;
        return true;
    }

    /// <summary>
    /// Updates a user's email after verifying their identity.
    /// </summary>
    /// <param name="password">User's password</param>
    /// <param name="currentEmail">Current User's email</param>
    /// <param name="newEmail">The new email to set</param>
    /// <returns>True if the old email was correct, if the password matches and if the new email does not already exist.</returns>
    public bool ChangeEmail(string password, string currentEmail, string newEmail)
    {
        User aux = repository.GetUserByEmail(currentEmail);

        if (aux == null || aux.Password != password)
        {
            return false;
        }

        //validating if someone already has this email
        if (repository.GetUserByEmail(newEmail) != null)
        {
            return false;
        }
        
        aux.Email = newEmail;
        return true;
    }
    
    
    /// <summary>
    /// A method needed to be used by the main program layer with the main purpose of saving all user's data.
    /// It calls the function created in the repository
    /// It permits keeping the layer structured 
    /// </summary>
    public void SaveData()
    {
        repository.SaveUsers();
    }

    /// <summary>
    /// A method needed to be used by the main program layer with the main purpose of loading all user's data.
    /// It calls the function created in the repository.
    /// It permits keeping the layer structured.
    /// </summary>
    public void LoadData()
    {
        repository.LoadUsers();
    }

    /// <summary>
    /// Gets a list of all registered users from the system.
    /// </summary>
    /// <returns>A list containing all User objects found in the database.</returns>
    public List<User> GetAllUsers()
    {
        return repository.GetAllUsers();
    }

    #endregion
}