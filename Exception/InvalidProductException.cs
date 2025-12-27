/*
*   <copyright file="InvalidProductException.cs"
*      Copyright (c) 2025 All Rights Reserved
*   </copyright>
*   <author>Edgar Casal</author>
*   <date>27-12-2025 16:21:43</date>
*   <description></description>
**/

using System;

namespace Exception;

/// <summary>
/// Purpose: Represents errors that occur when a Product is created with invalid data,
/// such as a negative price or an empty name.
/// Created by: Edgar Casal
/// Created on: 27-12-2025 16:21:43
/// </summary>
public class InvalidProductException : System.Exception
{
 
    #region Methods

    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidProductException"/> class 
    /// with a specific error message.
    /// </summary>
    /// <param name="message">The message that describes the error (e.g., "Price cannot be negative").</param>
    public InvalidProductException(string message) : base(message)
    {
    }

    #endregion
}