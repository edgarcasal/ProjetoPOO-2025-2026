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
[Serializable]
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
    /// Gets or sets the User who placed this order.
    /// </summary>
    public User User
    {
        get { return user; }
        set { user = value; }
    }

    /// <summary>
    /// Gets or sets the list of items (products and quantities) included in this order.
    /// </summary>
    public List<OrderItem> OrderItems
    {
        get { return orderItems; }
        set { orderItems = value; }
    }

    /// <summary>
    /// Gets or sets the current status of the order (e.g., Pending, Paid, Sent).
    /// </summary>
    public OrderStatus OrderStatus
    {
        get { return status; }
        set { status = value; }
    }
    
    /// <summary>
    /// Gets or sets the total monetary value of the order.
    /// The setter includes validation to prevent negative prices. 
    /// </summary>
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
    /// Compares this Order with another object to determine their sort order.
    /// Orders are compared chronologically based on their creation Date and Time.
    /// </summary>
    /// <param name="obj">The object to compare with this Order.</param>
    /// <returns>A value less than 0 if this Order is older (earlier date); 
    /// 0 if they occurred at the same time; 
    /// greater than 0 if this Order is newer (later date).</returns>
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
    /// Determines whether the specified object is equal to the current Order.
    /// Equality is defined by matching Order IDs.
    /// </summary>
    /// <param name="obj">The object to compare with the current Order.</param>
    /// <returns>True if the specified object is an Order with the same ID, otherwise false.</returns>
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
    /// Returns a hash code for this Order.
    /// This code is generated using the unique Order ID.
    /// </summary>
    /// <returns>A hash code integer.</returns>
    public override int GetHashCode()
    {
        return OrderId.GetHashCode();
    }

    /// <summary>
    /// Returns a string representing the Order's summary.
    /// Format: Order #ID [Status] - Date | User: Full Name
    /// </summary>
    /// <returns>A formatted string containing ID, status, date, and customer name.</returns>
    public override string ToString()
    {
        return $"Order #{OrderId} [{OrderStatus}] - {DateTime.ToShortDateString()} | User: {User.FirstName + " " + User.LastName}";
    }

    #endregion
    
    #endregion
}