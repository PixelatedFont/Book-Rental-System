//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebFinalProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class PublisherTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PublisherTable()
        {
            this.BookDetailTables = new HashSet<BookDetailTable>();
        }
        
        [DisplayName("Publisher Id")]
        public int PublisherID { get; set; }

        [DisplayName("Publisher Name")]
        public string PublisherName { get; set; }

        [DisplayName("Publisher Email")]
        public string P_Email { get; set; }

        [DisplayName("Publisher P.Number")]
        public string P_PhoneNumber { get; set; }

        [DisplayName("Publisher Address")]
        public string P_Address { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookDetailTable> BookDetailTables { get; set; }
    }
}
