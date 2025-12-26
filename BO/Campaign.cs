/*
*   <copyright file="Campaign.cs"
*      Copyright (c) 2025 All Rights Reserved
*   </copyright>
*   <author>Edgar Casal</author>
*   <date>14-11-2025 22:29:26</date>
*   <description></description>
**/

using System;

namespace BO;

/// <summary>
/// Purpose: The purpose of this class is to represent a special promotion.
/// It contains discount information and dates the sale is active.
/// Created by: Edgar Casal
/// Created on: 14-11-2025 22:29:26
/// </summary>
/// <remarks></remarks>
/// <example></example>
public class Campaign  //IComparable
{
    #region Attributes

    private int campaignId;
    private string campaignName;
    private DateOnly startDate;
    private DateOnly endDate;
    private double discountPercentage;

    #endregion

    #region Methods

    #region Constructors

    /// <summary>
    /// Default constructor for Campaign
    /// </summary>
    public Campaign(int id, string name, DateOnly startDate, DateOnly endDate, int discount)

    {
        campaignId = id;
        campaignName = name;
        this.startDate = startDate;
        this.endDate = endDate;
        discountPercentage = discount;
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets the ID from the Campaign
    /// </summary>
    public int CampaignId
    {
        get { return campaignId; }
    }

    /// <summary>
    /// Gets or Sets the name of the Campaign
    /// </summary>
    public string CampaignName
    {
        get { return campaignName; }
        set { campaignName = value; }
    }

    /// <summary>
    /// Gets the start date of the Campaign
    /// </summary>
    public DateOnly StartDate
    {
        get { return startDate; }
    }

    /// <summary>
    /// Gets the end date of the Campaign
    /// </summary>
    public DateOnly EndDate
    {
        get { return endDate; }
    }

    /// <summary>
    /// Gets or Sets the discount percentage of the Campaign
    /// </summary>
    public double DiscountPercentage
    {
        get { return discountPercentage; }
        set { if (value > 0) discountPercentage = value; }
    }
    #endregion

    #region OtherMethods

    /// <summary>
    /// This method calculates the discount based on the item ordered
    /// </summary>
    /// <param name="order"></param>
    /// <returns></returns>
    public decimal CalculateDiscount(OrderItem order)
    {
        
        return 0;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public int CompareTo(object obj)
    {
        Campaign aux = obj as Campaign;
        
        if (aux == null)
        {
            return 1;
        }
        return this.CampaignId.CompareTo(aux.CampaignId);
    }

    /// <summary>
    /// This method extends the campaign end date.
    /// </summary>
    /// <param name="newEndDate"></param>
    /// <returns></returns>
    public bool ExtendCampaign(DateOnly newEndDate)
    {
        //
        return true;
    }

    /// <summary>
    /// A method that checks if the campaign is active.
    /// </summary>
    /// <returns>Returns true if the campaign is active, false if not</returns>
    public bool IsActive()
    {
        //...
        return true;
    }
    #endregion

    #region Overrides
    
    public override bool Equals(object obj)
    {
        Campaign aux;
        if (obj is Campaign)
        {
            aux = (Campaign)obj;
            return aux.campaignId== this.campaignId;
        }

        return false;
    }
    #endregion

    #region Operators

    //public int CompareTo(Object obj)
    //{
        //obj as Order;
    //}

    #endregion

    #endregion
}