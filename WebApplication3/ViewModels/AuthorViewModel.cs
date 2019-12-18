using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.ViewModels
{
    public class AuthorViewModel
    {
        private int AuthorID;
        private string AuthorName;

        public int AuthorID1 { get => AuthorID; set => AuthorID = value; }
        public string AuthorName1 { get => AuthorName; set => AuthorName = value; }
    }
}