using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using GreatwideApp.Domain.Interfaces.Repositories;
using GreatwideApp.Domain.Services;
using GreatwideApp.Domain.Entities;
using System.Linq;

namespace GreatwideApp.UnitTests.Services
{
    public class ProductServiceTests
    {
        private readonly ProductService _productService;

        public ProductServiceTests()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            _productService = new ProductService(unitOfWork.Object);
        }

        [Fact]
        public void Test_GetAverageProductRating_WhenCalled_ReturnsAverageRating()
        {
            // Arrange
            var reviews = new List<ProductReview>
            {
                // Total Rating = 11
                new ProductReview { Rating = 1 },
                new ProductReview { Rating = 2 },
                new ProductReview { Rating = 1 },
                new ProductReview { Rating = 4 },
                new ProductReview { Rating = 3 }
            };

            var expectedRating = Convert.ToInt32(reviews.Average(x => x.Rating));

            // Act
            var result = _productService.GetAverageProductRating(reviews);

            // Assert
            Assert.Equal(expectedRating, result);
        }
    }
}
