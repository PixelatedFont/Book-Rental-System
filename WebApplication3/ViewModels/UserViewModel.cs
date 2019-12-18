using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.ViewModels
{
    public class UserViewModel
    {
        private int UserID;
        private int RoleID;
        private string UserName;
        private string UserPassword;
        private string FirstName;
        private string LastName;
        private string U_Email;
        private string U_PhoneNumber;
        private string U_Address;

        
        public int UserID1 { get => UserID; set => UserID = value; }
        [Required(ErrorMessage = "User name is required, please enter. ")]
        [RegularExpression("^[A-z]+[A-z0-9]+$", ErrorMessage = "Special characters detected, please re-enter.")]
        [DisplayName("User Name")]
        public string UserName1 { get => UserName; set => UserName = value; }

        [Required(ErrorMessage = "Password is required, please enter. ")]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string UserPassword1 { get => UserPassword; set => UserPassword = value; }
        public int RoleID1 { get => RoleID; set => RoleID = value; }
        public string FirstName1 { get => FirstName; set => FirstName = value; }
        public string LastName1 { get => LastName; set => LastName = value; }
        public string U_Email1 { get => U_Email; set => U_Email = value; }
        public string U_PhoneNumber1 { get => U_PhoneNumber; set => U_PhoneNumber = value; }
        public string U_Address1 { get => U_Address; set => U_Address = value; }
    }
}