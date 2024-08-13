﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Local_Market_Place_001.Models
{
    [Table(" RegisterShopInfo")]
    public class RegisterShopInfo
    {
        [Key]  // Specifies that the property is the primary key.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // Specifies that the value is generated by the database on insert.
        public int RegisterShopInfoID { get; set; }

        [DefaultValue("9854548382")]
        [Required(ErrorMessage = "Mobile number is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid mobile number.")]
        public string MobileNo { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Password must be between 3 and 100 characters")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Shop name is required.")]
        [StringLength(100, ErrorMessage = "Shop name cannot be longer than 100 characters.")]
        public string ShopName { get; set; }

        [DefaultValue("Unknown")]
        [StringLength(20, ErrorMessage = "Shop name cannot be longer than 20 characters.")]
        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }

        [DefaultValue("9:00 AM - 11:00 PM")]
        public string? ShopTimings { get; set; } = "9:00 AM - 9:00 PM"; // Default value

        [DefaultValue("Unknown")]
        [Required(ErrorMessage = "Shop category is required.")]
        public string ShopCategory { get; set; }

        [DefaultValue("Unknown")]
        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }

        [DefaultValue("Unknown")]
        [Required(ErrorMessage = "Pin/Zip Code is required.")]
        public string PinCode { get; set; }

        [DefaultValue("R@gmail.com")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? Email { get; set; }

        [DefaultValue("Shop providing diverse products and services with convenient access.")]
        [StringLength(250, ErrorMessage = "Description cannot exceed 250 characters.")]
        public string? Description { get; set; }


        [DefaultValue("Karavenagar")]
        [StringLength(100, ErrorMessage = "Area  cannot exceed 100 characters.")]
        public string? Area { get; set; }

        [DefaultValue("Unknown")]
        [Required(ErrorMessage = "Owner name is required.")]
        public string OwnerName { get; set; }

        [DefaultValue("9854548382")]
        [Required(ErrorMessage = "Owner mobile number is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid mobile number.")]
        public string OwnerMobileNo { get; set; }

        [DefaultValue("123456789101")]
        [Required(ErrorMessage = "Aadhar number is required.")]
        [RegularExpression(@"^\d{12}$", ErrorMessage = "Invalid Aadhar number.")]
        public string AadharNo { get; set; }

        [DefaultValue(false)]
        [Required(ErrorMessage = "You must accept the terms and conditions.")]

    
        public bool TermsAndConditionsAccepted { get; set; } = false;
    }
}
