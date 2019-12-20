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
    using System.ComponentModel.DataAnnotations;

    public partial class RentDetailTable
    {
        [DisplayName("Rent ID")]
        public int RentID { get; set; }

        [DisplayName("Book ID")]
        public Nullable<int> BookID { get; set; }

        [DisplayName("Book ISBN")]
        public Nullable<int> ISBN { get; set; }

        [DisplayName("User ID")]
        public Nullable<int> UserID { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yy}")]
        [DisplayName("Rent Date")]
        public Nullable<System.DateTime> RentDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yy}")]
        [DisplayName("Due Date")]
        public Nullable<System.DateTime> DueDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yy}")]
        [DisplayName("Return Date")]
        public Nullable<System.DateTime> ReturnDate { get; set; }

        public Nullable<double> Cost { get; set; }
        public Nullable<double> Paid { get; set; }
        public Nullable<double> Deposit { get; set; }
        public string Note { get; set; }
    
        public virtual BookDetailTable BookDetailTable { get; set; }
        public virtual BookTable BookTable { get; set; }
        public virtual RentTable RentTable { get; set; }
        public virtual UserTable UserTable { get; set; }
    }
}
