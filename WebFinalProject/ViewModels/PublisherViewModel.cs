using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebFinalProject.ViewModels
{
    public class PublisherViewModel
    {
        private int PublisherID;
        private string PublisherName;
        private string PublisherEmail;
        private string PublisherPhoneNumber;
        private string PublichserAddress;

        public int PublisherID1 { get => PublisherID; set => PublisherID = value; }

        [DisplayName("Publisher Name")]
        public string PublisherName1 { get => PublisherName; set => PublisherName = value; }

        [DisplayName("Publisher Email")]
        public string PublisherEmail1 { get => PublisherEmail; set => PublisherEmail = value; }

        [DisplayName("Publisher Phone Number")]
        public string PublisherPhoneNumber1 { get => PublisherPhoneNumber; set => PublisherPhoneNumber = value; }

        [DisplayName("Publisher Address")]
        public string PublichserAddress1 { get => PublichserAddress; set => PublichserAddress = value; }
    }
}