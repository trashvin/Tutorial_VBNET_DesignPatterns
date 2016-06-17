using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataProviderService;

namespace MVCPattern.Models
{
    public class UserModel
    {
        public int UserID { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }

        public UserModel()
        {

        }

        public UserModel(DataProviderService.MyUser aUser)
        {
            UserID = aUser.UserID;
            FullName = aUser.FullName;
            Gender = aUser.Gender;
            Age = aUser.Age;
        }

        public MyUser ToMyUser()
        {
            MyUser temp = new MyUser() { UserID = this.UserID, FullName = this.FullName, Gender = this.Gender, Age = this.Age };

            return temp;
        }
    }
}