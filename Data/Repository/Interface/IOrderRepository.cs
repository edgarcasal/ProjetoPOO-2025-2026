/*
 *	<copyright file="IUserRepository.cs"
 *	Copyright (c) 2025 All Rights Reserved
 *	</copyright>
 * 	<author>Edgar Casal</author>
 *   <date>26-12-2025 15:21:35</date>
 *	<description></description>
 **/

using System;
using BO;

namespace Data.Repository.Interface;


/// <summary>
/// Purpose: Defines the contract for accessing Order data.
/// Any class that implements this interface must provide code for these methods.
/// Created by: Edgar Casal
/// Created on: 26-12-2025 15:21:35
/// </summary>
public interface IOrderRepository
{
    /// <summary>
    /// Adds a new Order to the data dictionary.
    /// </summary>
    /// <param name="order">The Order object to add</param>
    /// <returns>True if added successfully, False if the ID already exists.</returns>
    bool AddOrder(Order order);

    /// <summary>
    /// Removes an order from the system based on their ID.
    /// </summary>
    /// <param name="id">The ID of the order to remove</param>
    /// <returns>True if the user was found and remove. False if the ID did not exist.</returns>
    bool RemoveOrder(int id);
    
    /// <summary>
    /// Searches for an order using its unique ID
    /// </summary>
    /// <param name="id">The unique ID of the order</param>
    /// <returns>The order object if found, otherwise null</returns>
    Order GetOrderById(int id);

    /// <summary>
    /// Searchs for an order using its date
    /// </summary>
    /// <param name="date">The date of the order</param>
    /// <returns>The order object if found, otherwise null</returns>
    Order GetOrderByDate(DateTime date);

    /// <summary>
    /// List of all orders currently stored in the system
    /// </summary>
    /// <returns>A list containing every order object from the store.</returns>
    List<Order> GetAllOrders();

}