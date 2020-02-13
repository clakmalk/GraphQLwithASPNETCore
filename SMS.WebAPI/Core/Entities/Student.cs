using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.WebAPI.Core.Entities
{
    public class Student
    {
        private int _id = -1;
        private string _name = string.Empty;
        private string _address = string.Empty;
        private string _email = string.Empty;
        private string _phoneNumber = string.Empty;

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Address { get => _address; set => _address = value; }
        public string Email { get => _email; set => _email = value; }
        public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }

        public ICollection<Course> Enrollements { set; get; }


    }
}
