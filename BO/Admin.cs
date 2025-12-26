/*
 *	<copyright file="Admin.cs"
 *	Copyright (c) 2025 All Rights Reserved
 *	</copyright>
 * 	<author>Edgar Casal</author>
 *   <date>18-12-2025 21:47:50</date>
 *	<description></description>
 **/

using System;

namespace BO;

/// <summary>
/// Purpose:
/// Created by: Edgar Casal
/// Created on: 18-12-2025 21:47:50
/// </summary>
/// <remarks></remarks>
/// <example></example>
public class Admin : User, IComparable
{
    #region Attributes

    private int employeeId;

    #endregion

    #region Methods

    #region Constructors

    public Admin(int id, string fName, string lName, string email, string password, int employeeId) : base(id, fName, lName, email, password)
    {
        this.employeeId = employeeId;
    }

    #endregion

    #region Properties

    public int EmployeeId
    {
        get { return employeeId; }
        set
        {
            if (value > 0) value = employeeId;
        }
    }
    
    #endregion
    
    #region Other Methods
    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public int CompareTo(object obj)
    {
        Admin aux = obj as Admin;
        
        if (aux == null)
        {
            return 1;
        }
        return this.EmployeeId.CompareTo(aux.EmployeeId);
    }
    #endregion

    #region Overrides

    public override string ToString()
    {
        return $"[ADMIN] {base.ToString()} - Emp#{EmployeeId}";
    }
    #endregion
    
    #endregion
}