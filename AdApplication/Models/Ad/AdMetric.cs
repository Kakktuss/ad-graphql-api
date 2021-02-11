namespace AdApplication.Models.Ad
{
    public class AdMetric
    {
        protected AdMetric()
        {
            
        }
        
        public int Id { get; set; }
        
        public int Value { get; set; }

        #region Ad relationship

        public int AdId { get; set; }
        
        public Ad Ad { get; set; }

        #endregion

        #region Metric relationship

        public int MetricId { get; set; }
        
        public Metric.Metric Metric { get; set; }

        #endregion
        
    }
}