using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystemDomain.Entity
{
    public class PurchaseDetails
    {
        [Key]

        public int Id { get; set; }

        [ForeignKey("PurchaseId")]    
        public int PurchaseId { get;}

        public virtual Purchase Purchase { get; private set; }

        //PurchaseId int NOT NULL,

        [Display(Name = "ItemCode")]
        [StringLength(50, ErrorMessage = "ItemCode must be a maximum length of 50")]
        public string? ItemCode { get; set; }

        public float ItemQty { get; set; }

        public float ItemUnitId { get; set; }

        public float ItemRate { get; set; }

    }
}
