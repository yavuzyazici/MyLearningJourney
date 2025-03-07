//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BasicCRUDoperations.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class BasicCRUDTblProduct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BasicCRUDTblProduct()
        {
            this.BasicCRUDTblSales = new HashSet<BasicCRUDTblSale>();
        }
    
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public Nullable<short> ProductCategory { get; set; }
        public string Brand { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<byte> Stock { get; set; }
    
        public virtual BasicCRUDTblCategory BasicCRUDTblCategory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BasicCRUDTblSale> BasicCRUDTblSales { get; set; }
    }
}
