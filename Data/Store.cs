/*
 *   <copyright file="Store.cs"
 *      Copyright (c) 2025 All Rights Reserved
 *   </copyright>
 *   <author>Edgar Casal</author>
 *   <date>16-12-2025 10:52:33</date>
 *   <description></description>
 **/

using System;
using BO;

namespace Data;

/// <summary>
/// Purpose: Represents the database for the application
/// It holds static collections (dictionaries) for all data entities like Users, Products, and Orders.
/// Created by: Edgar Casal
/// Created on: 16-12-2025 10:52:33
/// </summary>
public static class Store
{
    #region Attributes

    private static Dictionary<int, User> users;
    private static Dictionary<int, Product> products;
    private static Dictionary<int, Order> orders;
    private static Dictionary<int, Category> categories;
    private static Dictionary<int, Campaign> campaigns;
    
    #endregion

    #region Methods

    #region Constructors

    /// <summary>
    /// Ensures the lists are ready to use (or null) as sonn as the program starts.
    /// Static constructor that initializes all data collections.
    /// </summary>
    static Store()
    {
        users = new Dictionary<int, User>();
        products = new Dictionary<int, Product>();
        orders = new Dictionary<int, Order>();
        categories = new Dictionary<int, Category>();
        campaigns = new Dictionary<int, Campaign>();
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets the collection of all registered users, indexed by their ID.
    /// </summary>
    public static Dictionary<int, User> Users
    {
        get {return users;}
    }

    /// <summary>
    /// Gets the collection of all available products.
    /// </summary>
    public static Dictionary<int, Product> Products
    {
        get { return products; }
    }

    /// <summary>
    /// Gets the collection of all customer orders placed in the system.
    /// </summary>
    public static Dictionary<int, Order> Orders
    {
        get { return orders; }
    }

    /// <summary>
    /// Gets the collection of product categories.
    /// </summary>
    public static Dictionary<int, Category> Categories
    {
        get { return categories; }
    }
    
    /// <summary>
    /// Gets the collection of active campaigns
    /// </summary>
    public static Dictionary<int, Campaign> Campaigns
    {
        get { return campaigns; }
    }


    #endregion
    
    #endregion
}