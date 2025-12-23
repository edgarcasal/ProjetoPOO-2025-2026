/*
*   <copyright file="Order.cs"
*      Copyright (c) 2025 All Rights Reserved
*   </copyright>
*   <author>Edgar Casal</author>
*   <date>03-11-2025 13:25:27</date>
*   <description></description>
**/

using System;

namespace BO;

/// <summary>
/// Purpose: The purpose of this class is to link a User to the items they bought and tracking the status.
/// Created by: Edgar Casal
/// Created on: 03-11-2025 13:25:27
/// </summary>
/// <remarks></remarks>
/// <example></example>
public class Order
{
    #region Attributes

    private int orderId;
    private DateTime orderDate;
    private User user;
    //adicionar uma estrutura de dados para guardar todos os items comprados (OrderItem)
    
    private List<OrderItem> OrderedItems;
    enum orderStatus
    {
        Pending,
        Shipping,
        Cancelled
    };

    #endregion

    #region Methods

    #region Constructors
    /// <summary>
    /// Default constructor for Order
    /// </summary>
    public Order()
    {
        orderId = -1;
        orderDate = DateTime.Now;
        user = new User();
    }

    /// <summary>
    /// Constructor for Order with parameters
    /// </summary>
    /// <param name="oid">Order Id</param>
    /// <param name="u">Object user</param>
    public Order(int oid, User u)
    {
        orderId = oid;
        user = u;
        orderDate = DateTime.Now;
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets or Sets the ID of the Order
    /// </summary>
    public int OrderId
    {
        get { return orderId; }
        set { if (value > 0) orderId = value; }
    }

    /// <summary>
    /// Gets the current date time of the Order
    /// </summary>
    public DateTime DateTime
    {
        get {return DateTime.Now;}
    }

    #endregion

    #region OtherMethods

    #endregion

    #region Overrides
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object obj)
    {
        Order aux;
        if (obj is Order)
        {
            aux = (Order)obj;
            return aux.orderId == this.orderId;
        }

        return false;
    }
    #endregion

    #region Operators

    #endregion

    #endregion
}