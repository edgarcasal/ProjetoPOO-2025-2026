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
[Serializable]
public class OrderItem : IComparable
{
    #region Attributes

    private Product product;
    private double unitPrice;
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
    /// Constructor for OrderItem with 2 parameters.
    /// </summary>
    /// <param name="p">Product object</param>
    /// <param name="n">Quantity of the product</param>
    public OrderItem(Product p, int n)
    {
        product = p;
        quantity = n;
        unitPrice = product.Price;
    }
    
    /// <summary>
    /// Constructor for OrderItem with 3 parameters.
    /// </summary>
    /// <param name="p">Product object</param>
    /// <param name="price">Price of the product</param>
    /// <param name="n">Quantity of the product</param>
    public OrderItem(Product p, double price, int n)
    {
        product = p;
        unitPrice = price;
        quantity = n;
    }
    #endregion

    #region Properties

    public Product Product
    {
        get { return product; }
        set { product = value; }
    }

    /// <summary>
    /// Gets or Sets the unit price of the OrderItem
    /// </summary>
    public double UnitPrice
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
    public double CalculateTotal()
    {
        double total;
        if (quantity > 0 && unitPrice > 0)
        { 
            total = unitPrice * quantity;
            return total;
        }

        return 1;
    }
    
    /// <summary>
    /// Compares this OrderItem with another object based on the associated Product.
    /// This allows lists of OrderItems to be sorted by Product ID.
    /// </summary>
    /// <param name="obj">The object to compare with this OrderItem.</param>
    /// <returns>A value indicating the relative order. 
    /// Returns 1 if the other object or the products are null (placing this item after).
    /// Otherwise, returns the result of the Product comparison.</returns>
    public int CompareTo(object obj)
    {
        OrderItem aux = obj as OrderItem;
        
        // If the other item is null, or if either product is missing,
        // we consider 'this' item to be "greater" (put it at the end).
        if (aux == null || this.product == null || aux.product == null)
        {
            return 1;
        }
        
        return this.Product.CompareTo(aux.Product);
    }
    
    #endregion
    
    #region Overrides

    /// <summary>
    /// Returns a string representing the receipt line for this item.
    /// Format: ProductName (Quantity) - TotalPrice€
    /// </summary>
    /// <returns>A formatted string showing what was bought and the total cost for this line.</returns>
    public override string ToString()
    {
        string pName = product.ProductName;
        return $"{pName} ({Quantity}) - {CalculateTotal()}€";
    }

    #endregion
    

    #endregion
}