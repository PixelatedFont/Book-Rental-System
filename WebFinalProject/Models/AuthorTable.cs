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

    public partial class AuthorTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AuthorTable()
        {
            this.BookDetailTables = new HashSet<BookDetailTable>();
        }
        
        [DisplayName("Author ID")]
        public int AuthorID { get; set; }

        [DisplayName("Author Name")]
        public string AuthorName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookDetailTable> BookDetailTables { get; set; }
    }
}