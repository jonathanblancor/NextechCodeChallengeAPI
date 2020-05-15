using Nextech_Code_Challenge.Models;
using System;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace XUnitTestProject
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            IEnumerable<NewsHN> news = GetNews("system");

            Assert.Equal(2, news.Count());
        }

        [Fact]
        public void Test2()
        {
            IEnumerable<NewsHN> news = GetNews("Ethereum");

            Assert.Single(news);
        }

        public IEnumerable<NewsHN> GetNews(string searchTerm)
        {
            IEnumerable<NewsHN> newestStories = new List<NewsHN>
            {
                new NewsHN
                {
                    title = "Fault-Tolerance in Distributed Systems"
                },

                new NewsHN
                {
                    title = "Tornado: Private Transactions on Ethereum System"
                }
            };

            return newestStories.Where(x => x.title.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
