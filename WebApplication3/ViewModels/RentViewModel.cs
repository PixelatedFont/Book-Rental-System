using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Models;

namespace WebApplication3.ViewModels
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

        public int RentID1 { get => RentID; set => RentID = value; }
        public int BookID1 { get => BookID; set => BookID = value; }
        public int ISBN1 { get => ISBN; set => ISBN = value; }
        public int UserID1 { get => UserID; set => UserID = value; }
        public DateTime RentDate1 { get => RentDate; set => RentDate = value; }
        public DateTime DueDate1 { get => DueDate; set => DueDate = value; }
        public DateTime ReturnDate1 { get => ReturnDate; set => ReturnDate = value; }
        public double Cost1 { get => Cost; set => Cost = value; }
        public double Paid1 { get => Paid; set => Paid = value; }
        public double Deposit1 { get => Deposit; set => Deposit = value; }
        public string Note1 { get => Note; set => Note = value; }
        public virtual RentDetailTable RentDetailTable { get; set; }
        public virtual RentTable RentTable { get; set; }
        public virtual BookDetailTable BookDetailTable { get; set; }
        public virtual BookTable BookTable { get; set; }

    }
}