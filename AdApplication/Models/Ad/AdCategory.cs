using AdApplication.Models.Categories;

namespace AdApplication.Models.Ad
{
    public class AdCategory
    {
        protected AdCategory()
        {
            
        }
        
        public int Id { get; set; }
        
        #region Ad relationship

        public int AdId { get; set; }
        
        public Ad Ad { get; set; }

        #endregion

        #region Category relationship

        public Category Category { get; set; }

        public int CategoryId { get; set; }

        #endregion
        
    }
}