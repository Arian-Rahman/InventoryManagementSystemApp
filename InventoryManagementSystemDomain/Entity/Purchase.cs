using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InventoryManagementSystemDomain.Entity
{
    public class Purchase
    {

        [Key]
      //  [Display(Name = "Purchase ID")]
      //  [Required(ErrorMessage = "Id Required")]
        public int PurchaseId { get; set; }
        
      // [StringLength(100, ErrorMessage = "First Name must be a maximum length of 100")]

        [Display(Name = "Purchase Date")]
        [DataType(DataType.Date, ErrorMessage = "Date is not Valid")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? PurchaseDate { get; set; }



        [Display(Name = "SupplierName")]
        [StringLength(50, ErrorMessage = "SupplierName must be a maximum length of 50")]
        public string? SupplierName { get; set; }

        [Display(Name = "Address")]
        [StringLength(500, ErrorMessage = "Address must be a maximum length of 500")]
        public string? Address { get; set; }

        [Display(Name = "EntryBy")]
        [StringLength(50, ErrorMessage = "EntryBy  must be a maximum length of 500")]
        public string? EntryBy { get; set; }

        [Display(Name = "EntryDate")]
        [DataType(DataType.Date, ErrorMessage = "EntryDate is not Valid")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? EntryDate { get; set; }

        [Display(Name = "Remark")]
        [StringLength(800, ErrorMessage = "Remark must be a maximum length of 800")]
        public string? Remark { get; set; }


        public virtual List<PurchaseDetails> PurchaseDetails { get; set; } 
            = new List<PurchaseDetails>();
       
    }
}
