using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelanceStudent.Entity.DTOs
{
    public class AdvertDto
    {
        public int AdvertId { get; set; }

        public string Title { get; set; }

        public string Detail { get; set; }

        public double Price { get; set; }

        public DateTime Deadline { get; set; }
    }
}
