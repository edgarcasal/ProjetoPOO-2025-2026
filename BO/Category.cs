/*
*   <copyright file="Category.cs"
*      Copyright (c) 2025 All Rights Reserved
*   </copyright>
*   <author>Edgar Casal</author>
*   <date>03-11-2025 13:14:43</date>
*   <description></description>
**/

using System;

namespace BO;

/// <summary>
/// Purpose: The purpose of this class is to organize products by category.
/// It's job is to make products easier to find.
/// Created by: Edgar Casal
/// Created on: 03-11-2025 13:14:43
/// </summary>
/// <remarks></remarks>
/// <example></example>
public class Category
{

    #region Attributes

    private int categoryId;
    private string categoryName;
    private string categoryDescription;

    #endregion

    #region Methods

    #region Constructors

    /// <summary>
    /// Default constructor for Category
    /// </summary>
    public Category()
    {
        categoryId = -1;
        categoryName = "";
        categoryDescription = "";
    }

    /// <summary>
    /// Constructor for Category with parameters
    /// </summary>
    /// <param name="id">Category id</param>
    /// <param name="cname">Name of category</param>
    /// <param name="desc">Description of the category</param>
    public Category(int id, string cname, string desc)
    {
        categoryId = id;
        categoryName = cname;
        categoryDescription = desc;

    }
    #endregion

    #region Properties

    /// <summary>
    /// Gets the ID from the Category
    /// </summary>
    public int CategoryId
    {
        get { return categoryId; }
    }

    /// <summary>
    /// Gets or Sets the name of the Category
    /// </summary>
    public string CategoryName
    {
        get { return categoryName; }
        set { categoryName = value; }
    }

    /// <summary>
    /// Gets the description of the Category
    /// </summary>
    public string CategoryDescription
    {
        get { return categoryDescription; }
    }
    
    #endregion
    
    #region OtherMethods

    /// <summary>
    /// A method that changes the current description of a category.
    /// </summary>
    /// <param name="newDescription">The new description to be changed</param>
    /// <returns>Return true if the new description changed successfully</returns>
    public bool UpdateCategoryDescription(string newDescription)
    {
        if (newDescription != String.Empty)
        {
            categoryDescription = newDescription; 
            return true;
        }
        
        return false;
    }
    #endregion
    
    #region Overrides
    
    
    public override bool Equals(object obj)
    {
        Category aux;
        if (obj is Category)
        {
            aux = (Category)obj;
            return aux.categoryId == this.categoryId;
        }

        return false;
    }
    #endregion
    
    #region Operators

    #endregion

    #endregion
}