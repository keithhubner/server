﻿using System.ComponentModel.DataAnnotations;
using Bit.Core.Entities;
using Bit.Core.Enums;
using Bit.Core.Models.Business;
using Bit.Core.Models.Data.Organizations.OrganizationUsers;
using Bit.Core.Settings;
using Bit.Core.Utilities;
using Bit.Core.Vault.Entities;

namespace Bit.Admin.Models;

public class OrganizationEditModel : OrganizationViewModel
{
    public OrganizationEditModel() { }

    public OrganizationEditModel(Organization org, IEnumerable<OrganizationUserUserDetails> orgUsers,
        IEnumerable<Cipher> ciphers, IEnumerable<Collection> collections, IEnumerable<Group> groups,
        IEnumerable<Policy> policies, BillingInfo billingInfo, IEnumerable<OrganizationConnection> connections,
        GlobalSettings globalSettings)
        : base(org, connections, orgUsers, ciphers, collections, groups, policies)
    {
        BillingInfo = billingInfo;
        BraintreeMerchantId = globalSettings.Braintree.MerchantId;

        Name = org.Name;
        BusinessName = org.BusinessName;
        BillingEmail = org.BillingEmail;
        PlanType = org.PlanType;
        Plan = org.Plan;
        Seats = org.Seats;
        MaxAutoscaleSeats = org.MaxAutoscaleSeats;
        MaxCollections = org.MaxCollections;
        UsePolicies = org.UsePolicies;
        UseSso = org.UseSso;
        UseKeyConnector = org.UseKeyConnector;
        UseScim = org.UseScim;
        UseGroups = org.UseGroups;
        UseDirectory = org.UseDirectory;
        UseEvents = org.UseEvents;
        UseTotp = org.UseTotp;
        Use2fa = org.Use2fa;
        UseApi = org.UseApi;
        UseSecretsManager = org.UseSecretsManager;
        UseResetPassword = org.UseResetPassword;
        SelfHost = org.SelfHost;
        UsersGetPremium = org.UsersGetPremium;
        UseCustomPermissions = org.UseCustomPermissions;
        MaxStorageGb = org.MaxStorageGb;
        Gateway = org.Gateway;
        GatewayCustomerId = org.GatewayCustomerId;
        GatewaySubscriptionId = org.GatewaySubscriptionId;
        Enabled = org.Enabled;
        LicenseKey = org.LicenseKey;
        ExpirationDate = org.ExpirationDate;
    }

    public BillingInfo BillingInfo { get; set; }
    public string RandomLicenseKey => CoreHelpers.SecureRandomString(20);
    public string FourteenDayExpirationDate => DateTime.Now.AddDays(14).ToString("yyyy-MM-ddTHH:mm");
    public string BraintreeMerchantId { get; set; }

    [Required]
    [Display(Name = "Name")]
    public string Name { get; set; }
    [Display(Name = "Business Name")]
    public string BusinessName { get; set; }
    [Display(Name = "Billing Email")]
    public string BillingEmail { get; set; }
    [Required]
    [Display(Name = "Plan")]
    public PlanType? PlanType { get; set; }
    [Required]
    [Display(Name = "Plan Name")]
    public string Plan { get; set; }
    [Display(Name = "Seats")]
    public int? Seats { get; set; }
    [Display(Name = "Max. Autoscale Seats")]
    public int? MaxAutoscaleSeats { get; set; }
    [Display(Name = "Max. Collections")]
    public short? MaxCollections { get; set; }
    [Display(Name = "Policies")]
    public bool UsePolicies { get; set; }
    [Display(Name = "SSO")]
    public bool UseSso { get; set; }
    [Display(Name = "Key Connector with Customer Encryption")]
    public bool UseKeyConnector { get; set; }
    [Display(Name = "Groups")]
    public bool UseGroups { get; set; }
    [Display(Name = "Directory")]
    public bool UseDirectory { get; set; }
    [Display(Name = "Events")]
    public bool UseEvents { get; set; }
    [Display(Name = "TOTP")]
    public bool UseTotp { get; set; }
    [Display(Name = "2FA")]
    public bool Use2fa { get; set; }
    [Display(Name = "API")]
    public bool UseApi { get; set; }
    [Display(Name = "Reset Password")]
    public bool UseResetPassword { get; set; }
    [Display(Name = "SCIM")]
    public bool UseScim { get; set; }
    [Display(Name = "Secrets Manager")]
    public bool UseSecretsManager { get; set; }
    [Display(Name = "Self Host")]
    public bool SelfHost { get; set; }
    [Display(Name = "Users Get Premium")]
    public bool UsersGetPremium { get; set; }
    [Display(Name = "Custom Permissions")]
    public bool UseCustomPermissions { get; set; }
    [Display(Name = "Max. Storage GB")]
    public short? MaxStorageGb { get; set; }
    [Display(Name = "Gateway")]
    public GatewayType? Gateway { get; set; }
    [Display(Name = "Gateway Customer Id")]
    public string GatewayCustomerId { get; set; }
    [Display(Name = "Gateway Subscription Id")]
    public string GatewaySubscriptionId { get; set; }
    [Display(Name = "Enabled")]
    public bool Enabled { get; set; }
    [Display(Name = "License Key")]
    public string LicenseKey { get; set; }
    [Display(Name = "Expiration Date")]
    public DateTime? ExpirationDate { get; set; }
    public bool SalesAssistedTrialStarted { get; set; }
}
