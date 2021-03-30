using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeadSpider.Models;
using Microsoft.EntityFrameworkCore;

namespace LeadSpider.Data.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private ApplicationDbContext _ctx;

        public BlogRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public void AddPost(Post post)
        {
            _ctx.Posts.Add(post);
        }

        public List<Post> GetAllPosts()
        {
            return _ctx.Posts.ToList();
        }

        public Post GetPost(int id)
        {
                return _ctx.Posts
                // .Include(p => p.MainComments)
                    // .ThenInclude(mc => mc.SubComments)
                .FirstOrDefault(p => p.Id == id);
        }

        public void RemovePost(int id)
        {
            _ctx.Posts.Remove(GetPost(id));
        }

        public async Task<bool> SaveChangesAsync()
        {
            if (await _ctx.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }

        public void UpdatePost(Post post)
        {
            _ctx.Posts.Update(post);
        }
    }
}