using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IllyriadAssist.Models
{
    [Table("MD_ILLY_REGIONS")]
    public class IllyRegions
    {
        [Key]
        [Column("REGION_ID")]
        public int RegionID { get; set; }

        //MAIL, NOTI
        [Required]
        [StringLength(3, ErrorMessage = "Illyriad Region ID cannot be longer than 3 characters.")]
        [Column("ILLY_REGION_ID")]
        [Display(Name = "Illyriad Region ID")]
        public int IllyRegionID { get; set; }

        [StringLength(100, ErrorMessage = "Region Name cannot be longer than 100 characters.")]
        [Column("REGION_NAME")]
        [Display(Name = "Region Name")]
        public string RegionName { get; set; }
    }
}
