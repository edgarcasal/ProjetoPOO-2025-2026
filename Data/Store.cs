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
/// Purpose:
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

    public static Dictionary<int, User> Users
    {
        get {return users;}
    }

    public static Dictionary<int, Product> Products
    {
        get { return products; }
    }

    public static Dictionary<int, Order> Orders
    {
        get { return orders; }
    }

    public static Dictionary<int, Category> Categories
    {
        get { return categories; }
    }
    
    public static Dictionary<int, Campaign> Campaigns
    {
        get { return campaigns; }
    }


    #endregion
    
    #endregion
}