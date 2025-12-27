/*
*   <copyright file="OrderService.cs"
*      Copyright (c) 2025 All Rights Reserved
*   </copyright>
*   <author>Edgar Casal</author>
*   <date>27-12-2025 11:16:23</date>
*   <description></description>
**/

using System;
using BO;
using Data;
using Data.Repository;
using Data.Repository.Interface;

namespace Rules;

/// <summary>
/// Purpose:
/// Created by: Edgar Casal
/// Created on: 27-12-2025 11:16:23
/// </summary>
public class OrderService
{
    #region Attributes

    private IOrderRepository orderRepo;
    private IProductRepository productRepo;

    #endregion

    #region Methods
    
    
    #region Constructor

    public OrderService()
    {
        orderRepo = new OrderRepository();
        productRepo = new ProductRepository();
    }
    
    #endregion

    /// <summary>
    /// Takes the User and their Cart, checks stock, deducts stock, and saves the order.
    /// </summary>
    /// <param name="user">The user that is going to place an order</param>
    /// <param name="cart">The list of items the user is going to buy</param>
    /// <returns>Returns true if the new order was added to the list of orders</returns>
    public bool PlaceOrder(User user, List<OrderItem> cart)
    {
        // Check if cart is empty
        if (cart == null || cart.Count == 0)
        {
            return false;
        }

        // Checks if there is enough stock for each item
        foreach (OrderItem item in cart)
        {
            // To make sure we have the latest stock updated
            Product p = productRepo.GetProductById(item.Product.ProductId);

            // Checks if product exists or if there's not enough stock
            if (p == null || p.StockQuantity < item.Quantity)
            {
                return false;
            }
            
        }

        // Remove the quantity to be bought
        foreach (OrderItem item in cart)
        {
            Product p = productRepo.GetProductById(item.Product.ProductId);
            p.RemoveStock(item.Quantity);

        }

        // Creates the unique ID and the Order
        int newOrderId = orderRepo.GetAllOrders().Count + 1;
        Order newOrder = new Order(newOrderId, user);
        
        newOrder.OrderItems = cart;
        
        //Calculates the total
        newOrder.CalculateTotal();

        orderRepo.AddOrder(newOrder);
        return true;
    }

    /// <summary>
    /// Returns only the orders belonging to a specific user.
    /// </summary>
    /// <param name="userId">The user's id</param>
    /// <returns>Returns the list of orders for the specific user.</returns>
    public List<Order> GetUserOrderHistory(int userId)
    {
        // Create a list of orders containing all orders, and a list o userOrders to add all orders for a specific user
        List<Order> allOrders = orderRepo.GetAllOrders();
        List<Order> userOrders = new List<Order>();

        // For each order, checks if the order is from the userId given, if so, adds it to the userOrders
        foreach (Order order in allOrders)
        {
            if (order.User.UserId == userId)
            {
                userOrders.Add(order);
            }
        }

        // Returns the list of all orders from the User
        return userOrders;
    }
    #endregion
}