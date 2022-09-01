using System.Collections.Generic;
using System.Threading.Tasks;
using InstrumentalistFinderApi.Models;
using Microsoft.EntityFrameworkCore;

namespace InstrumentalistFinderApi.Data
{
    public class PostRepository : IPostRepository
    {
        private readonly AppDbContext appDbContext;

        public PostRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Post> AddPost(Post post)
        {
           var result = await appDbContext.Posts.AddAsync(post);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Post> DeletePost(int postId)
        {
            var result = await appDbContext.Posts.FirstOrDefaultAsync(p => p.Id == postId);
            if(result != null)
            {
                appDbContext.Posts.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Post> GetPost(int postId)
        {
            return await appDbContext.Posts.FirstOrDefaultAsync(p => p.Id == postId); 
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            return await appDbContext.Posts.ToListAsync();

        }
    }
}
