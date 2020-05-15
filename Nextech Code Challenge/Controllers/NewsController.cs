using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Nextech_Code_Challenge.Models;
using Nextech_Code_Challenge.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Nextech_Code_Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        /// <summary>
        /// Get newest 20 news
        /// </summary>
        /// <returns>Return the newest news</returns>
        // GET: api/news
        [HttpGet, EnableCors, ResponseCache(Duration = 60, Location = ResponseCacheLocation.Client)]
        public IActionResult Get()
        {
            List<NewsHN> newestStories = new List<NewsHN>();

            try
            {
                newestStories = Helper.GetNews(20);
            }
            catch (Exception e)
            {
                return BadRequest("Unable to process request.");
            }
       
            return Ok(newestStories);
        }

        /// <summary>
        /// Search news based on 'title'.
        /// </summary>
        /// <param name="searchTerm">Term to search in the news</param>
        /// <returns>News found based on the search term</returns>
        // GET api/news/searchnews?searchterm
        [HttpGet("[action]"), EnableCors]
        public IActionResult SearchNews(string searchTerm)
        {
            List<NewsHN> newestStories = new List<NewsHN>();
      
            try
            {
                // If no search term was provided, return default (20) amount of news
                if (String.IsNullOrWhiteSpace(searchTerm)) 
                {
                    newestStories = Helper.GetNews(20);
                    return Ok(newestStories);
                }

                // Only get top 40 news 
                newestStories = Helper.GetNews(40);

                return Ok(newestStories.Where(x => x.title.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase)));
            }
            catch (Exception e)
            {
                return BadRequest("Unable to process request.");
            }
        }
    }
}
