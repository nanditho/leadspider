using System.Collections.Generic;
using System.Threading.Tasks;
using LeadSpider.Models;

namespace LeadSpider.Data.Repository
{
    public interface IBlogRepository
    {
        Post GetPost(int id);
        // FrontPostViewModel GetFrontPost(int id);
        List<Post> GetAllPosts();
        // IndexViewModel GetAllPosts(int pageNumber, string category, string search);
        void AddPost(Post post);
        void UpdatePost(Post post);
        void RemovePost(int id);
        // void AddSubComment(SubComment comment);
        Task<bool> SaveChangesAsync();
    }
}