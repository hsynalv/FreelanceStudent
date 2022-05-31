using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelanceStudent.Entity.Entities
{
    public class Student : User
    {
        public string NationalityId { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Background Background { get; set; }

    }
}
