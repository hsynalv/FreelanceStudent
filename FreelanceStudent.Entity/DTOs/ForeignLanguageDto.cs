using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelanceStudent.Entity.DTOs
{
    public class ForeignLanguageDto
    {
        public int FLanguageId { get; set; }

        public int BackgroundId { get; set; }
        public string Name { get; set; }
    }
}
