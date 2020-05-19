using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IllyriadAssist.Models
{
    [Table("MD_API_SETTINGS")]
    public class APISettings
    {
        [Key]
        [Column("API_ID")]
        public int APIid { get; set; }
        
        //MAIL, NOTI
        [Required]
        [StringLength(15, ErrorMessage = "API Type cannot be longer than 15 characters.")]
        [Column("API_TYPE")]
        [Display(Name = "API Type")]
        public string APIType { get; set; }

        [StringLength(100, ErrorMessage = "API Key cannot be longer than 100 characters.")]
        [Column("API_KEY")]
        [Display(Name = "API Key")]
        public string APIKey { get; set; }
    }
}
