using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InstrumentalistFinderApi.Data;
using InstrumentalistFinderApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstrumentalistFinderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostRepository postRepository;

        public PostsController(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }
        [Route("/GetAllPosts")]
        [HttpGet]
        public async Task<ActionResult> GetPosts()
        {
            try
            {
                return Ok(await postRepository.GetPosts());

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        //[Route("GetPost")]
        [HttpGet("GetPost/{id:int}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            try
            {
                var result = await postRepository.GetPost(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from database");
            }

        }
        [Route("/CreatePost")]
        [HttpPost]
        public async Task<ActionResult<Post>> CreatePost(Post post)
        {
            try
            {
                if (post == null)
                {
                    return BadRequest();
                }
                var createdPost = await postRepository.AddPost(post);
                return CreatedAtAction(nameof(GetPost),new {id = createdPost.Id}, createdPost);  

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error retrieving data from database");
            }
        }
        //[Route("DeletePost")]
        [HttpDelete("DeletePost/{id:int}")]
        public async Task<ActionResult<Post>> DeletePost (int id)
        {
            try
            {
                var postToDelete = await postRepository.GetPost(id);
                if(postToDelete == null)
                {
                    return NotFound($"Post with Id = {id} not found");
                }
                return await postRepository.DeletePost(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error deleting data");
            }
        }
    }
}
