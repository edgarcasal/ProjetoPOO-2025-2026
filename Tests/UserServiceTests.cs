/*
*	<copyright file="UserServiceTest.cs" 
*	Copyright (c) 2025 All Rights Reserved
*	</copyright>
* 	<author>Edgar Casal</author>
*   <date>29-12-2025 10:49:45</date>
*	<description></description>
**/


using Rules;
using BO;

namespace Tests;

/// <summary>
/// Purpose: To verify the correctness of user management business logic,
/// to make sure that features like Registration, Login, and getting Data function as expected
/// under various scenarios (valid inputs, invalid passwords, empty data, etc.).
/// It contains unit tests for the UserService class.
/// Created by: Edgar Casal
/// Created on: 29-12-2025 10:49:45
/// </summary>
[TestClass]
public sealed class UserServiceTests
{
    [TestMethod]
    public void RegisterUserTest_WhenValidData()
    {
        UserService service = new UserService();
        string fname = "Test";
        string lname = "User";
        string email = "test@example.com";
        string pass = "password123";

        bool result = service.RegisterUser(fname, lname, email, pass);
        
        // Check the result
        Assert.IsTrue(result, "RegisterUser should return true");

        //Verify if the user is in the list
        List<User> allUsers = service.GetAllUsers();
        Assert.HasCount(1, allUsers);
        Assert.AreEqual(email, allUsers[0].Email);
    }

    
    [TestMethod]
    public void LoginTest_WhenPasswordIsWrong()
    {
        UserService service = new UserService();
        service.RegisterUser("Edgar", "Casal", "a31026@alunos.ipca.pt", "abc1234");

        User loggedUser = service.Login("a31026@alunos.ipca.pt", "abc");
        
        Assert.IsNull(loggedUser, "User should be null when password is wrong.");
    }

    [TestMethod]
    public void LoginTest_WhenPasswordIsRight()
    {
        UserService service = new UserService();
        service.RegisterUser("Edgar", "Casal", "a31026@alunos.ipca.pt", "abc1234");

        User loggedUser = service.Login("a31026@alunos.ipca.pt", "abc1234");
        
        Assert.IsNotNull(loggedUser, "Login should return a User object, not null.");
        Assert.AreEqual("a31026@alunos.ipca.pt", loggedUser.Email);
    }


    [TestMethod]
    public void RegisterUserTest_WhenEmailAlreadyExists()
    {
        UserService service = new UserService();
        service.RegisterUser("A", "B", "test@test.com", "1234");

        bool success = service.RegisterUser("C", "D", "test@test.com", "1212");
        
        Assert.IsFalse(success, "Should not allow registering the same email twice.");
    }


    [TestMethod]
    public void LoginUserTest_WhenUserDoesNotExist()
    {
        UserService service = new UserService();

        User result = service.Login("test@test.com", "123123");
        
        Assert.IsNull(result, "Login should return null for unknown emails.");
    }
}