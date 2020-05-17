using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IllyriadAssist.Models
{
    [Table("MD_RARE_MINERALS")]
    public class RareMinerals
    {
        [Key]
        [Column("ITEM_ID")]
        public int ItemID { get; set; }
        
        [Required]
        [StringLength(100, ErrorMessage = "Item Name cannot be longer than 100 characters.")]
        [Column("ITEM_NAME")]
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Illyriad Code cannot be longer than 10 characters.")]
        [Column("ILLY_CODE")]
        [Display(Name = "Illyriad Image Code")]
        public string IllyCode { get; set; }

        [Required]
        [StringLength(1000000, ErrorMessage = "Item Description exceeds database MAX_LENGTH.")]
        [Column("ITEM_DESCRIPTION")]
        [Display(Name = "Item Description")]
        public string ItemDescription { get; set; }

        [Required]
        [StringLength(1000, ErrorMessage = "Image Location cannot be longer than 1000 characters.")]
        [Column("IMAGE_NAME")]
        [Display(Name = "Image Name")]
        public string ImageName { get; set; }

    }
}
