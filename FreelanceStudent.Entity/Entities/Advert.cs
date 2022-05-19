using System;

namespace FreelanceStudent.Entity.Entities
{
    public class Advert
    {
        public int AdvertId { get; set; }

        public string Title { get; set; }

        public string Detail { get; set; }

        public double Price { get; set; }

        public DateTime Deadline { get; set; }

        public bool IsActivated { get; set; }

        public DateTime CreatedTime { get; set; }

        public Category Category { get; set; }

        public int CategoryId { get; set; }

    }
}
