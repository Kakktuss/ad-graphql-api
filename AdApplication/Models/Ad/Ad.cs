using System;
using System.Collections.Generic;

namespace AdApplication.Models.Ad
{
    public class Ad
    {

        protected Ad()
        {
            
        }

        public Ad(string title,
            string description)
        {
            Uuid = Guid.NewGuid();

            Title = title;

            Description = description;

            Categories = new List<AdCategory>();

            Metrics = new List<AdMetric>();
        }
        
        public int Id { get; set; }
        
        public Guid Uuid { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
        
        public List<AdCategory> Categories { get; set; }
        
        public List<AdMetric> Metrics { get; set; }
        
    }
}