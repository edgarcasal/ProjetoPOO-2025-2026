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



public enum OrderStatus
{
    Pending,
    Shipping,
    Cancelled,
    Delivered
};

/// <summary>
/// Purpose: The purpose of this class is to link a User to the items they bought and tracking the status.
/// Created by: Edgar Casal
/// Created on: 03-11-2025 13:25:27
/// </summary>
/// <remarks></remarks>
/// <example></example>
public class Order : IComparable
{
    #region Attributes

    private int orderId;
    private DateTime orderDate;
    private User user;
    private OrderStatus status;
    private double totalPrice;
    
    public List<OrderItem> orderItems;

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
        orderItems = new List<OrderItem>();
        status = OrderStatus.Pending;
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
        orderItems = new List<OrderItem>();
        status = OrderStatus.Pending;
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
    /// Gets or Sets the current date time of the Order
    /// </summary>
    public DateTime DateTime
    {
        get {return orderDate;}
        set
        {
            orderDate = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public User User
    {
        get { return user; }
        set { user = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    public List<OrderItem> OrderItems
    {
        get { return orderItems; }
        set { orderItems = value; }
    }

    public OrderStatus OrderStatus
    {
        get { return status; }
        set { status = value; }
    }
    
    public double TotalPrice
    {
        get { return totalPrice; }
        set
        {
            if (value >= 0) totalPrice = value;
        }
    }

    #endregion

    #region OtherMethods
    
    
    /// <summary>
    /// Calculates the total cost of the order based on the items inside it.
    /// </summary>
    public void CalculateTotal()
    {
        double sum = 0;
    
        // Check if list is not null to avoid crash
        if (this.OrderItems != null)
        {
            foreach (OrderItem item in this.OrderItems)
            {
                sum += item.CalculateTotal();
            }
        }
    
        this.TotalPrice = sum;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public int CompareTo(object obj)
    {
        Order aux = obj as Order;
        
        if (aux == null)
        {
            return 1;
        }
        return this.DateTime.CompareTo(aux.DateTime);
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
        Order aux;
        if (obj is Order)
        {
            aux = (Order)obj;
            return aux.orderId == this.orderId;
        }

        return false;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        return OrderId.GetHashCode();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return
            $"Order #{OrderId} [{OrderStatus}] - {DateTime.ToShortDateString()} | User: {User.FirstName + " " + User.LastName}";
    }

    #endregion
    
    #endregion
}