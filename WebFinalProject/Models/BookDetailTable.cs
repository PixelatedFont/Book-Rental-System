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

    public partial class BookDetailTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BookDetailTable()
        {
            this.BookTables = new HashSet<BookTable>();
            this.RentDetailTables = new HashSet<RentDetailTable>();
            this.RentTables = new HashSet<RentTable>();
        }
    
        public int ISBN { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }

        [DisplayName("Author ID")]
        public Nullable<int> AuthorID { get; set; }

        [DisplayName("Publisher ID")]
        public Nullable<int> PublisherID { get; set; }
    
        public virtual AuthorTable AuthorTable { get; set; }
        public virtual PublisherTable PublisherTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookTable> BookTables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RentDetailTable> RentDetailTables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RentTable> RentTables { get; set; }
    }
}
