using System;
using System.Collections.Generic;
using AdApplication.Models.Ad;

namespace AdApplication.Models.Metric
{
    public class Metric
    {
        public Metric()
        {
            Uuid = Guid.NewGuid();
        }
        
        public int Id { get; set; }
        
        public Guid Uuid { get; set; }

        public string Name { get; set; }
        
        #region Ad relationship

        public List<AdMetric> Ads { get; set; }

        #endregion
    }
}