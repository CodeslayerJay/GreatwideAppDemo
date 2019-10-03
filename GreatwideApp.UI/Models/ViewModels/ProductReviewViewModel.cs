using System;

namespace GreatwideApp.UI.Models.ViewModels
{
    public class ProductReviewViewModel
    {

        public int ProductReviewId { get; set; }
        public int ProductId { get; set; }
        public string ReviewerName { get; set; }
        public DateTime ReviewDate { get; set; }
        public string EmailAddress { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }

        public virtual ProductViewModel Product { get; set; }
    }
}