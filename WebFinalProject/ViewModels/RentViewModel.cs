using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using WebFinalProject.Models;

namespace WebFinalProject.ViewModels
{
    public class RentViewModel
    {
        private int RentID;
        private int BookID;
        private int ISBN;
        private int UserID;
        private DateTime RentDate;
        private DateTime DueDate;
        private DateTime ReturnDate;
        private double Cost;
        private double Paid;
        private double Deposit;
        private string Note;

        [DisplayName("Rent ID")]
        public int RentID1 { get => RentID; set => RentID = value; }

        [DisplayName("Book ID")]
        public int BookID1 { get => BookID; set => BookID = value; }

        [DisplayName("Book ISBN")]
        public int ISBN1 { get => ISBN; set => ISBN = value; }

        [DisplayName("User ID")]
        public int UserID1 { get => UserID; set => UserID = value; }

        [DisplayName("Rent Date")]
        public DateTime RentDate1 { get => RentDate; set => RentDate = value; }

        [DisplayName("Due Date")]
        public DateTime DueDate1 { get => DueDate; set => DueDate = value; }

        [DisplayName("Return Date")]
        public DateTime ReturnDate1 { get => ReturnDate; set => ReturnDate = value; }

        [DisplayName("Rent Cost")]
        public double Cost1 { get => Cost; set => Cost = value; }

        [DisplayName("Rent Paid")]
        public double Paid1 { get => Paid; set => Paid = value; }

        [DisplayName("Rent Deposit")]
        public double Deposit1 { get => Deposit; set => Deposit = value; }

        [DisplayName("Rent Note")]
        public string Note1 { get => Note; set => Note = value; }

        [DisplayName("Rent Detail:")]
        public virtual RentDetailTable RentDetailTable { get; set; }

        [DisplayName("Rent:")]
        public virtual RentTable RentTable { get; set; }

        [DisplayName("Book Detail:")]
        public virtual BookDetailTable BookDetailTable { get; set; }

        [DisplayName("Book:")]
        public virtual BookTable BookTable { get; set; }

    }
}