/*
*   <copyright file="OrderItem.cs"
*      Copyright (c) 2025 All Rights Reserved
*   </copyright>
*   <author>Edgar Casal</author>
*   <date>13-11-2025 21:24:31</date>
*   <description></description>
**/

using System;

namespace BO;

/// <summary>
/// Purpose: The purpose of this class is to connect a specific Product to a specific Order and
/// store the quantity.
/// Created by: Edgar Casal
/// Created on: 13-11-2025 21:24:31
/// </summary>
/// <remarks></remarks>
/// <example></example>
public class OrderItem
{
    #region Attributes

    private Product product;
    private decimal unitPrice;
    private int quantity;

    #endregion

    #region Methods

    #region Constructors
    
    /// <summary>
    /// Default constructor for OrderItem
    /// </summary>
    public OrderItem()
    {
        product = new Product();
        unitPrice = -1;
        quantity = -1;
    }
    
    /// <summary>
    /// Constructor for OrderItem with parameters.
    /// </summary>
    /// <param name="p">Product object</param>
    /// <param name="price">Price of the product</param>
    /// <param name="n">Quantity of the product</param>
    public OrderItem(Product p, decimal price, int n)
    {
        product = p;
        unitPrice = price;
        quantity = n;
    }
    #endregion

    #region Properties

    /// <summary>
    /// Gets or Sets the unit price of the OrderItem
    /// </summary>
    public decimal UnitPrice
    {
        get { return unitPrice;}
        set { if (value > 0) unitPrice = value; }
    }
    
    /// <summary>
    /// Gets or Sets the quantity of the OrderItem
    /// </summary>
    public int Quantity
    {
        get { return quantity;}
        set { if (value > 0) quantity = value; }
    }
    #endregion

    #region OtherMethods

    /// <summary>
    /// This method calculates the total amount.
    /// </summary>
    /// <returns></returns>
    public decimal CalculateTotal()
    {
        decimal total;
        if (quantity > 0 && unitPrice > 0)
        { 
            total = unitPrice * quantity;
            return total;
        }

        return 1;
    }
    #endregion
    
    #region Overrides
    
    #endregion
    
    #region Operators

    #endregion

    #endregion
}