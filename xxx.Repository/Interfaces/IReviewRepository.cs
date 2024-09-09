using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xxx.Repository.Models;

namespace xxx.Repository.Interfaces
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetAllReviews();
        Task<Review> CreateReview(Review review);
        Task<bool> DeleteReview(int id);
    }
}
