/*
*   <copyright file="User.cs"
*      Copyright (c) 2025 All Rights Reserved
*   </copyright>
*   <author>Edgar Casal</author>
*   <date>03-11-2025 13:09:40</date>
*   <description></description>
**/

using System;

namespace BO;

/// <summary>
/// Purpose: The purpose of this class is to represent a customer.
/// This class contains all the information about the user, like login details (email and password) and
/// personal info (first and last names)
/// Created by: Edgar Casal
/// Created on: 03-11-2025 13:09:40
/// </summary>
[Serializable]
public class User : IComparable
{
    #region Attributes

    private int userId;
    private string firstName;
    private string lastName;
    private string email;
    private string password;

    #endregion

    #region Methods

    #region Constructors

    /// <summary>
    /// Default constructor of User
    /// </summary>
    public User()
    {
        userId = -1;
        firstName = "";
        lastName = "";
        email = "";
        password = "";
    }

    /// <summary>
    /// Constructor of User with parameters
    /// </summary>
    /// <param name="id">User's id</param>
    /// <param name="fname">First name of the user</param>
    /// <param name="lname">Last name of the user</param>
    /// <param name="email">User's email</param>
    /// <param name="passwrd">User's password</param>
    public User(int id, string fname, string lname, string email, string passwrd)
    {
        userId = id;
        firstName = fname;
        lastName = lname;
        this.email = email;
        password = passwrd;
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets the ID of the User
    /// </summary>
    public int UserId
    {
        get { return userId; }
        set
        {
            if (value > 0) userId = value;
        }
    }

    /// <summary>
    /// Gets or Sets the first name of the User
    /// </summary>
    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }

    /// <summary>
    /// Gets or Sets the last name of the User
    /// </summary>
    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }

    /// <summary>
    /// Gets or Sets the email of the User
    /// </summary>
    public string Email
    {
        get { return email; }
        set
        {
            if (value != "" && value.Contains("@")) email = value;
        }
    }

    /// <summary>
    /// Gets or Sets the password of the User
    /// </summary>
    public string Password
    {
        get { return password;}
        set
        {
            if (value.Length > 8) password = value ;
        }
    }

    #endregion

    #region OtherMethods
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public int CompareTo(object obj)
    {
        User aux = obj as User;
        
        if (aux == null)
        {
            return 1;
        }
        return this.UserId.CompareTo(aux.UserId);
    }

    #endregion

    #region Overrides

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object obj)
    {
        User aux;
        if (obj is User)
        {
            aux = (User)obj;
            return aux.userId == this.userId;
        }
        return false;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $"[{UserId}] - {FirstName + " " + LastName} | {Email}";
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        return userId.GetHashCode();
    }
    

    #endregion
        
    #endregion

}