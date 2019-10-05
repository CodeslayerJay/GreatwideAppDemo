using System;
using System.Collections.Generic;

namespace GreatwideApp.Domain.Entities
{
    public partial class ProductReview
    {
        public int ProductReviewId { get; set; }
        public int ProductId { get; set; }
        public string ReviewerName { get; set; }
        public DateTime ReviewDate { get; set; } = DateTime.Now;
        public string EmailAddress { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }
        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        public virtual Product Product { get; set; }
    }
}
