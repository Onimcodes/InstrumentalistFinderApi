using System.Collections.Generic;
using System.Threading.Tasks;
using InstrumentalistFinderApi.Models;

namespace InstrumentalistFinderApi.Data
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetPosts();
        Task<Post> GetPost(int postId);
        Task<Post> AddPost(Post post);
        Task<Post> DeletePost(int postId);
    }
}
