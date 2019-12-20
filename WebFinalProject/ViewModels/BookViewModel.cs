using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebFinalProject.ViewModels
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

        [DisplayName("Book ID")]
        public int BookID1 { get => BookID; set => BookID = value; }

        [DisplayName("ISBN")]
        public int ISBN1 { get => ISBN; set => ISBN = value; }

        [DisplayName("Title")]
        public string Title1 { get => Title; set => Title = value; }

        [DisplayName("Summary")]
        public string Summary1 { get => Summary; set => Summary = value; }

        [DisplayName("Author ID")]
        public int AuthorID1 { get => AuthorID; set => AuthorID = value; }

        [DisplayName("Publisher ID")]
        public int PublisherID1 { get => PublisherID; set => PublisherID = value; }

        [DisplayName("Book Status")]
        public bool BookStatus1 { get => BookStatus; set => BookStatus = value; }
    }
}