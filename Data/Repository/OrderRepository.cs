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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
#pragma warning disable SYSLIB0011

namespace Data.Repository;

/// <summary>
/// Purpose: The Data Access Layer for Orders.
/// Created by: Edgar Casal
/// Created on: 26-12-2025 15:22:29
/// </summary>
public class OrderRepository:IOrderRepository
{
    
    private const string FILE_PATH = "orders.bin";

    #region Methods

    /// <summary>
    /// Adds a new Order to the order dictionary.
    /// </summary>
    /// <param name="order">The order object to add</param>
    /// <returns>True if added successfully, False if the ID already exists.</returns>
    public bool AddOrder(Order order)
    {
        // Checks if order already exists
        if (Store.Orders.ContainsKey(order.OrderId))
        {
            return false;
        }
        // Adds it to the dictionary
        Store.Orders.Add(order.OrderId, order);
        return true;
    }

    /// <summary>
    /// Deletes an order from the system based on their ID.
    /// </summary>
    /// <param name="id">The ID of the order to remove.</param>
    /// <returns>True if the order was found and removed. False if the ID did not exist.</returns>
    public bool RemoveOrder(int id)
    {
        // Checks if there's an order with the ID given and removes it
        if (Store.Orders.ContainsKey(id))
        {
            Store.Orders.Remove(id);
            return true;
        }

        return false;
    }


    /// <summary>
    /// Searchs for an order using their ID.
    /// </summary>
    /// <param name="id">The ID of the order</param>
    /// <returns>The Order object if found, otherwise null.</returns>
    public Order GetOrderById(int id)
    {
        // Checks if there's an order with that ID, and returns the object if so.
        if (Store.Orders.ContainsKey(id))
        {
            return Store.Orders[id];
        }

        return null;
    }


    /// <summary>
    /// Searches for an order by its date
    /// </summary>
    /// <param name="date">Date given to search for</param>
    /// <returns>The Order object if found, otherwise null.</returns>
    public Order GetOrderByDate(DateTime date)
    {
        // Checks every order available and verifies if the object data matches
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
    /// Retrieves all orders currently stored in the system.
    /// </summary>
    /// <returns>A list containing every Order object from the Store</returns>
    public List<Order> GetAllOrders()
    {
        return Store.Orders.Values.ToList();
    }

    /// <summary>
    /// Saves the current dictionary of orders to a binary file
    /// If the file already exists it is deleted and recreated.
    /// </summary>
    public void SaveOrders()
    {
        FileStream fs = null;

        try
        {
            //If exists, deletes it first to start over
            if (File.Exists(FILE_PATH))
            {
                File.Delete(FILE_PATH);
            }

            //Creates the file
            fs = File.Create(FILE_PATH);

            //Serialize the dictionary
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, Store.Orders);
        }
        catch (System.Exception e)
        {
            Console.WriteLine("Error saving file: " + e.Message);
        }
        finally
        {
            if (fs != null)
            {
                fs.Close();
            }
        }
    }
    
    /// <summary>
    /// Loads order data from the binary file
    /// This method clears the existing 'Store.Orders' dictionary before to avoid duplicate conflicts.
    /// If the file does not exist, it ensures the Store remains empty but valid.
    /// </summary>
    public void LoadOrders()
    {
        FileStream fs = null;

        try
        {
            //Checks if file exists
            if (File.Exists(FILE_PATH))
            {
                //Opens the file
                fs = File.Open(FILE_PATH, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                
                // Deserialize to a temporary dictionary
                Dictionary<int, Order> tempOrders = (Dictionary<int, Order>)bf.Deserialize(fs);
               
                // Clears the existing Store to avoid duplicates
                Store.Orders.Clear();

                foreach (KeyValuePair<int, Order> entry in tempOrders)
                {
                    //where entry.Key is the id and entry.value is the product object
                    Store.Orders.Add(entry.Key, entry.Value);
                }
                
            }
        }
        catch (System.Exception e)
        {
            Console.WriteLine("Error loading file: " + e.Message);
            // File might be corrupted so it starts fresh
            Store.Orders.Clear();
        }
        finally
        {
            if (fs != null)
            {
                fs.Close();
            }
        }
    }
    #endregion
}