using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelanceStudent.Entity.Entities
{
    public class Employer : User
    {
        public int EmployerId { get; set; }
        public string WebSite { get; set; }
    
    }
}
