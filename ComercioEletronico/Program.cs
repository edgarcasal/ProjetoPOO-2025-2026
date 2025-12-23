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

namespace ComercioEletronico
{ 
    internal class Program
    {
        static void Main(string[] args)
        {
            UserService userService = new UserService();

            userService.RegisterUser("Edgar", "Casal", "a31026@alunos.ipca.pt", "abcd1234");
            userService.RegisterUser("João", "Torres", "abc@gmail.com", "12345abcd");
            
            Console.Write("Enter Email Address: ");
            string email = Console.ReadLine();
            
            Console.Write("Enter Password: ");
            string pass = Console.ReadLine();

            User loggedUser = userService.Login(email, pass);

            if (loggedUser != null)
            {
                Console.WriteLine($"Welcome, {loggedUser.FirstName} {loggedUser.LastName}!");
            }


            //User a = new User(1, "Edgar", "Casal", "abc@gmail.com", "123");
            //Product product1 = new Product(1, "Sapatilhas", 49.99m,"Nike",100);
            //Product product2 = new Product(2, "Camisola", 29.99m, "Lacoste", 50);
            //Order order1 = new Order(1, a);
            //OrderItem orderItem1 = new OrderItem(product1, 50, 2);

            //orderItem1.Quantity = 3;
            //orderItem1.UnitPrice = 30.33m;

            //Campaign campaign1 = new Campaign(1, "Black Friday", new DateOnly(2025, 11, 25), new DateOnly(2025, 12, 8),
            //20);

            //decimal total = orderItem1.CalculateTotal();
            //Console.WriteLine(total);
            //bool res = a.CheckPassword("123");
            //res = a.ChangePassword("1123", "abc");
            //Console.WriteLine(res);


            //bool res = a.Login("abc@gmail.com", "123");
            //Console.WriteLine(res);
        }
    }
}