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

public interface IOrderRepository
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="order"></param>
    /// <returns></returns>
    bool AddOrder(Order order);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    bool RemoveOrder(int id);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Order GetOrderById(int id);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    Order GetOrderByDate(DateTime date);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    List<Order> GetAllOrders();

}