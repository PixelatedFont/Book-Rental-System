using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.ViewModels
{
    public class BookViewModel
    {
        private int BookID;
        private int ISBN;
        private string Title;
        private string Summary;
        private int AuthorID;
        private int PublisherID;
        private bool BookStatus;

        public int BookID1 { get => BookID; set => BookID = value; }
        public int ISBN1 { get => ISBN; set => ISBN = value; }
        public string Title1 { get => Title; set => Title = value; }
        public string Summary1 { get => Summary; set => Summary = value; }
        public int AuthorID1 { get => AuthorID; set => AuthorID = value; }
        public int PublisherID1 { get => PublisherID; set => PublisherID = value; }
        public bool BookStatus1 { get => BookStatus; set => BookStatus = value; }
    }
}