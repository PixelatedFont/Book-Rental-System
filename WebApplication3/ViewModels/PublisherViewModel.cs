using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.ViewModels
{
    public class PublisherViewModel
    {
        private int PublisherID;
        private string PublisherName;
        private string PublisherEmail;
        private string PublisherPhoneNumber;
        private string PublichserAddress;

        public int PublisherID1 { get => PublisherID; set => PublisherID = value; }
        public string PublisherName1 { get => PublisherName; set => PublisherName = value; }
        public string PublisherEmail1 { get => PublisherEmail; set => PublisherEmail = value; }
        public string PublisherPhoneNumber1 { get => PublisherPhoneNumber; set => PublisherPhoneNumber = value; }
        public string PublichserAddress1 { get => PublichserAddress; set => PublichserAddress = value; }
    }
}