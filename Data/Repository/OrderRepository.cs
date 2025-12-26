/*
*   <copyright file="OrderRepository.cs"
*      Copyright (c) 2025 All Rights Reserved
*   </copyright>
*   <author>Edgar Casal</author>
*   <date>26-12-2025 15:22:29</date>
*   <description></description>
**/

using System;
using BO;
using Data.Repository.Interface;

namespace Data.Repository;

/// <summary>
/// Purpose:
/// Created by: Edgar Casal
/// Created on: 26-12-2025 15:22:29
/// </summary>
/// <remarks></remarks>
/// <example></example>
public class OrderRepository:IOrderRepository
{

    #region Methods

    /// <summary>
    /// 
    /// </summary>
    /// <param name="order"></param>
    /// <returns></returns>
    public bool AddOrder(Order order)
    {
        // Checks if order already exists
        if (Store.Orders.ContainsKey(order.OrderId))
        {
            return false;
        }
        
        Store.Orders.Add(order.OrderId, order);
        return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool RemoveOrder(int id)
    {
        if (Store.Orders.ContainsKey(id))
        {
            Store.Orders.Remove(id);
            return true;
        }

        return false;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Order GetOrderById(int id)
    {
        if (Store.Orders.ContainsKey(id))
        {
            return Store.Orders[id];
        }

        return null;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public Order GetOrderByDate(DateTime date)
    {
        foreach (Order aux in Store.Orders.Values)
        {
            if (aux.DateTime == date)
            {
                return aux;
            }
        }

        return null;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public List<Order> GetAllOrders()
    {
        return Store.Orders.Values.ToList();
    }

    #endregion
}