using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GreatwideApp.UI.Models.ViewModels
{
    public class ReviewFormModel
    {

        public ReviewFormModel()
        {
            RatingsDropdownList = BuildRatingList();
        }

        public int ProductReviewId { get; set; }
        public int ProductId { get; set; }

        [Display(Name = "Full Name")]
        public string ReviewerName { get; set; }

        public DateTime ReviewDate { get; set; } = DateTime.Now;

        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }

        public virtual ProductViewModel Product { get; set; }

        public IEnumerable<SelectListItem> RatingsDropdownList { get; set; }

        private IEnumerable<SelectListItem> BuildRatingList()
        {
            var ratings = new List<SelectListItem>();

            var totalRatingCount = 5;
            for(var i = 0; i < totalRatingCount; i++)
            {
                ratings.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            }

            return ratings;
        }
    }
}
