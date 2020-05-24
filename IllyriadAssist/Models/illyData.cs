using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IllyriadAssist.Models
{
    [Table("USER_ILLY_DATA")]
    public class illyData
    {

        [Key]
        [Column("RECORD_ID")]
        public int RecordID { get; set; }

        //API NOTIFICATION ID - POPULATES FROM API FEED
        [Required]
        [StringLength(40, ErrorMessage = "Notification ID cannot be longer than 40 characters.")]
        [Column("NOTIFY_ID")]
        [Display(Name = "Notification ID")]
        public int APINotificationID { get; set; }

        //API NOTIFICATION TYPE ID - POPULATES FROM API FEED
        [Required]
        [StringLength(4, ErrorMessage = "Notification Type ID cannot be longer than 4 characters.")]
        [Column("NOTIFY_TYPE_ID")]
        [Display(Name = "Notification Type ID")]
        public int APINotificationTypeID { get; set; }

        //API NOTIFICATION CATEGORY ID - POPULATES FROM API FEED
        [Required]
        [StringLength(2, ErrorMessage = "Notification Category ID cannot be longer than 2 characters.")]
        [Column("NOTIFY_CAT_ID")]
        [Display(Name = "Notification Category ID")]
        public int APINotificationCategoryID { get; set; }

        //API NOTIFICATION CATEGORY - POPULATES FROM API FEED
        [Required]
        [StringLength(20, ErrorMessage = "Notification Category cannot be longer than 20 characters.")]
        [Column("NOTIFY_CATEGORY")]
        [Display(Name = "Notification Category")]
        public string APINotificationCategory { get; set; }

        //API DATA TYPE - MAIL & NOTI
        [Required]
        [StringLength(4, ErrorMessage = "Notification Type cannot be longer than 4 characters.")]
        [Column("NOTIFY_TYPE")]
        [Display(Name = "Notification Type")]
        public string APINotificationType { get; set; }

        //API CIY NAME - POPULATES FROM API FEED
        [Required]
        [StringLength(100, ErrorMessage = "City Name cannot be longer than 100 characters.")]
        [Column("CITY_NAME")]
        [Display(Name = "City Name")]
        public string CityName { get; set; }

        //API CITY X_GRID - POPULATES FROM API FEED
        [Required]
        [StringLength(5, ErrorMessage = "City X Grid cannot be longer than 5 characters.")]
        [Column("CITY_X_GRID")]
        [Display(Name = "City X")]
        public string CityXGrid { get; set; }

        //API CITY Y_GRID - POPULATES FROM API FEED
        [Required]
        [StringLength(5, ErrorMessage = "City Y Grid cannot be longer than 5 characters.")]
        [Column("CITY_Y_GRID")]
        [Display(Name = "City Y")]
        public string CityYGrid { get; set; }

        //API ILLY_CODE - POPULATES FROM API FEED
        [Required]
        [StringLength(10, ErrorMessage = "Illyriad Item Code Category cannot be longer than 10 characters.")]
        [Column("ILLY_ITEM_CODE")]
        [Display(Name = "Illyriad Item Code")]
        public string IllyriadCode { get; set; }

        //API ITEM CATEGORY (MINR, HERB, PRTS, EXOT, or ELEM)
        [Required]
        [StringLength(4, ErrorMessage = "Item Category cannot be longer than 4 characters.")]
        [Column("ITEM_CATEGORY")]
        [Display(Name = "Item Category")]
        public string ItemCategory { get; set; }

        //API ITEM X_GRID - POPULATES FROM API FEED
        [Required]
        [StringLength(5, ErrorMessage = "X Grid cannot be longer than 5 characters.")]
        [Column("ITEM_X_GRID")]
        [Display(Name = "X")]
        public string ItemXGrid { get; set; }

        //API ITEM Y_GRID - POPULATES FROM API FEED
        [Required]
        [StringLength(5, ErrorMessage = "Y Grid cannot be longer than 5 characters.")]
        [Column("ITEM_Y_GRID")]
        [Display(Name = "Y")]
        public string ItemYGrid { get; set; }

        //API ITEM QUANTITY ON GRID - POPULATES FROM API FEED
        [Required]
        [StringLength(10, ErrorMessage = "Grid Quantity cannot be longer than 10 characters.")]
        [Column("GRID_QUANTITY")]
        [Display(Name = "Grid Quantity")]
        public string GridQuantity { get; set; }

        //REGION ID - POPULATES FROM API FEED
        [Required]
        [StringLength(3, ErrorMessage = "Illyriad Region ID cannot be longer than 3 characters.")]
        [Column("ILLY_REGION_ID")]
        [Display(Name = "Illyriad Region ID")]
        public string IllyRegionID { get; set; }

        //REGION ID - POPULATES FROM API FEED
        [Required]
        [StringLength(30, ErrorMessage = "Notification Date (UTC) cannot be longer than 30 characters.")]
        [Column("NOTIFICATION_DATE")]
        [Display(Name = "Notification Date (UTC)")]
        public string NotificationDate { get; set; }

    }
}
