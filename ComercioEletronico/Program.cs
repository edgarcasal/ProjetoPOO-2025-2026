/*
 *   <copyright file="Program.cs"
 *   Copyright (c) 2025 All Rights Reserved
 *   </copyright>
 *   <author>Edgar Casal</author>
 *   <date>03-11-2025 13:06:35</date>
 *   <description></description>
 **/

using System;
using BO;
using Rules;
using Exception;

namespace ComercioEletronico
{ 
    internal class Program
    {
        static void Main(string[] args)
        {
        // --- 1. INITIALIZATION ---
            UserService userService = new UserService();
            ProductService productService = new ProductService();
            OrderService orderService = new OrderService();
       
            // --- 2. LOAD DATA ---
            // Loading existing data
            userService.LoadData();
            productService.LoadData();
            orderService.LoadData();

            // --- 3. Adding information for testing ---
            if (userService.Login("admin@store.com", "admin123") == null)
            {
                userService.RegisterUser("System","Admin", "admin@store.com", "admin123");
            }
            if (userService.Login("user@test.com", "user123") == null)
            {
                userService.RegisterUser("Test", "User", "user@test.com", "user123");
            }
            
            if (productService.GetAllProducts().Count == 0)
            {
                Console.WriteLine("Forming database with sample products...");

                try 
                {
                    // Add diverse items to test your Search logic
                    productService.RegisterProduct("iPhone 15", "Apple", 999.99, 10);
                    productService.RegisterProduct("iPhone 15 Pro","Apple",1199.99,5);
                    productService.RegisterProduct("Samsung Galaxy S23","Samsung",850.00,8);
                    productService.RegisterProduct("Sony Headphones",  "Sony",150.50,20);
                    productService.RegisterProduct("Gaming Mouse","Logitech",59.90, 15);
        
                    Console.WriteLine("Data added successfully!");
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine("Error adding data: " + ex.Message);
                }
            }

            // --- 4. LOGIN SCREEN ---
            Console.WriteLine("=== SYSTEM LOGIN ===");
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Password: ");
            string pass = Console.ReadLine();

            User loggedUser = userService.Login(email, pass);

            if (loggedUser == null)
            {
                Console.WriteLine("Login failed! Exiting...");
                return; // Stop the program
            }

            Console.WriteLine($"Welcome, {loggedUser.FirstName}!");

            // --- 5. ROLE CHECK (Admin vs User) ---
            
            if (loggedUser.Email == "admin@store.com")
            {
                // === ADMIN SECTION ===
                Console.WriteLine("\n[ADMIN MODE]");
                Console.WriteLine("1. Create New Product");
                Console.Write("Option: ");
                string option = Console.ReadLine();

                if (option == "1")
                {
                    try
                    {
                        Console.Write("Product Name: ");
                        string pName = Console.ReadLine();
                        
                        Console.Write("Price: ");
                        double pPrice = double.Parse(Console.ReadLine());

                        Console.Write("Stock: ");
                        int pStock = int.Parse(Console.ReadLine());

                        // This might throw InvalidProductException if price is negative!
                        bool created = productService.RegisterProduct(pName,"GenericBrand",pPrice ,pStock);
                        
                        if (created) Console.WriteLine("Product Created Successfully!");
                    }
                    catch (InvalidProductException ex)
                    {
                        // Catches negative price or empty name
                        Console.WriteLine($"ERROR: {ex.Message}");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("ERROR: Please enter valid numbers.");
                    }
                }
            }
            else
            {
                // === USER SECTION ===
                Console.WriteLine("\n[SHOPPING MODE]");
                
                // A. Search
                Console.Write("Search Product: ");
                string search = Console.ReadLine();
                List<Product> results = productService.SearchProduct(search);

                if (results.Count == 0)
                {
                    Console.WriteLine("No products found.");
                }
                else
                {
                    // Show results
                    foreach (Product p in results)
                    {
                        Console.WriteLine($"ID: {p.ProductId} | {p.ProductName} | ${p.Price} | Stock: {p.StockQuantity}");
                    }

                    // B. Basic buy Logic
                    Console.Write("\nEnter Product ID to buy (or 0 to cancel): ");
                    try 
                    {
                        int idToBuy = int.Parse(Console.ReadLine());
                        if (idToBuy != 0)
                        {
                            Product selected = productService.GetProductById(idToBuy);
                            
                            Console.Write("Quantity: ");
                            int qty = int.Parse(Console.ReadLine());

                            // Create the Cart (List)
                            List<OrderItem> cart = new List<OrderItem>();
                            OrderItem item = new OrderItem(selected, qty);
                            cart.Add(item);

                            // Try to Place Order
                            bool success = orderService.PlaceOrder(loggedUser, cart);

                            if (success) Console.WriteLine("Purchase Successful! Receipt saved.");
                        }
                    }
                    catch (InvalidProductException ex)
                    {
                        Console.WriteLine($"ORDER FAILED: {ex.Message}");
                    }
                    catch (System.Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            }

            // --- 6. SAVE DATA ---
            // Save everything before the window closes
            userService.SaveData();
            productService.SaveData();
            orderService.SaveData();

            Console.WriteLine("\nData saved. Press any key to exit.");
            Console.ReadKey();
        }
    }
}