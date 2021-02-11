using System;
using System.Collections.Generic;
using AdApplication.Models.Ad;

namespace AdApplication.Models.Categories
{
    public class Category
    {
        protected Category()
        {
            
        }
        
        public Category(string name)
        {
            Uuid = Guid.NewGuid();

            Name = name;
        }
        
        public int Id { get; set; }
        
        public Guid Uuid { get; set; }

        public string Name { get; set; }

        #region Ad relationship

        public List<AdCategory> Ads { get; set; }

        #endregion
        
    }
}