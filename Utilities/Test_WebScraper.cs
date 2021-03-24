using CodingChallenge.APIModels;
using CodingChallenge.AttributeModels;
using CodingChallenge.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Net;

namespace CodingChallengeTests
{
    [TestClass]
    public class Test_WebScraper { 
        [TestMethod]
        public void getHTML_SinglePage() {
            RequestAttribute attrs = new RequestAttribute
            {
                URI = "https://api.dealerrater.com/",
                URL = "https://www.dealerrater.com/dealer/McKaig-Chevrolet-Buick-A-Dealer-For-The-People-dealer-reviews-23685",
                API = false,
                AccessToken = "ACCESSTOKENHERE",
                DealerID = "23685",
                PaginationOptions = new PaginationOptions
                {
                    Pages = 1,
                    ResultsPerPage = 10,
                    Offset = 0
                }
            };

            WebScraper scraper = new WebScraper(attrs);

            string returnedHTML = scraper.getHTML();
            int index, count = 0;

            while ((index = returnedHTML.ToLower().IndexOf("<!doctype html>")) != -1)
            {
                returnedHTML = returnedHTML.Substring(index + 15, returnedHTML.Length - (index + 15));
                count++;
            }

            Assert.AreEqual(attrs.PaginationOptions.Pages, count);
        }
        [TestMethod]
        public void getHTML_OnePageAndOffset() {
            RequestAttribute attrs = new RequestAttribute
            {
                URI = "https://api.dealerrater.com/",
                URL = "https://www.dealerrater.com/dealer/McKaig-Chevrolet-Buick-A-Dealer-For-The-People-dealer-reviews-23685",
                API = false,
                AccessToken = "ACCESSTOKENHERE",
                DealerID = "23685",
                PaginationOptions = new PaginationOptions
                {
                    Pages = 1,
                    ResultsPerPage = 10,
                    Offset = 3
                }
            };

            WebScraper scraper = new WebScraper(attrs);

            string returnedHTML = scraper.getHTML();
            int index, count = 0;

            while ((index = returnedHTML.ToLower().IndexOf("<!doctype html>")) != -1)
            {
                returnedHTML = returnedHTML.Substring(index + 15, returnedHTML.Length - (index + 15));
                count++;
            }

            Assert.AreEqual(attrs.PaginationOptions.Pages, count);
        }
        [TestMethod]
        public void getHTML_MultiPage() {
            RequestAttribute attrs = new RequestAttribute
            {
                URI = "https://api.dealerrater.com/",
                URL = "https://www.dealerrater.com/dealer/McKaig-Chevrolet-Buick-A-Dealer-For-The-People-dealer-reviews-23685",
                API = false,
                AccessToken = "ACCESSTOKENHERE",
                DealerID = "23685",
                PaginationOptions = new PaginationOptions
                {
                    Pages = 5,
                    ResultsPerPage = 10,
                    Offset = 0
                }
            };

            WebScraper scraper = new WebScraper(attrs);

            string returnedHTML = scraper.getHTML();
            int index, count = 0;

            while ((index = returnedHTML.ToLower().IndexOf("<!doctype html>")) != -1)
            {
                returnedHTML = returnedHTML.Substring(index + 15, returnedHTML.Length - (index + 15));
                count++;
            }

            Assert.AreEqual(attrs.PaginationOptions.Pages, count);
        }
        [TestMethod]
        public void getHTML_MultiPageAndOffset() {
            RequestAttribute attrs = new RequestAttribute
            {
                URI = "https://api.dealerrater.com/",
                URL = "https://www.dealerrater.com/dealer/McKaig-Chevrolet-Buick-A-Dealer-For-The-People-dealer-reviews-23685",
                API = false,
                AccessToken = "ACCESSTOKENHERE",
                DealerID = "23685",
                PaginationOptions = new PaginationOptions
                {
                    Pages = 5,
                    ResultsPerPage = 10,
                    Offset = 5
                }
            };

            WebScraper scraper = new WebScraper(attrs);

            string returnedHTML = scraper.getHTML();
            int index, count = 0;

            while ((index = returnedHTML.ToLower().IndexOf("<!doctype html>")) != -1)
            {
                returnedHTML = returnedHTML.Substring(index + 15, returnedHTML.Length - (index + 15));
                count++;
            }

            Assert.AreEqual(attrs.PaginationOptions.Pages, count);
        }
        [TestMethod]
        public void getHTML_NonDRSinglePage() {
            RequestAttribute attrs = new RequestAttribute
            {
                URI = "https://api.dealerrater.com/",
                URL = "https://www.google.com/",
                API = false,
                AccessToken = "ACCESSTOKENHERE",
                DealerID = "23685",
                PaginationOptions = new PaginationOptions
                {
                    Pages = 1,
                    ResultsPerPage = 10,
                    Offset = 0
                }
            };

            WebScraper scraper = new WebScraper(attrs);

            string returnedHTML = scraper.getHTML();
            int index, count = 0;

            while ((index = returnedHTML.ToLower().IndexOf("<!doctype html>")) != -1)
            {
                returnedHTML = returnedHTML.Substring(index + 15, returnedHTML.Length - (index + 15));
                count++;
            }

            Assert.AreEqual(attrs.PaginationOptions.Pages, count);
        }
        [TestMethod]
        public void getHTML_NonDRMultiPage() {
            RequestAttribute attrs = new RequestAttribute
            {
                URI = "https://api.dealerrater.com/",
                URL = "https://www.google.com/",
                API = false,
                AccessToken = "ACCESSTOKENHERE",
                DealerID = "23685",
                PaginationOptions = new PaginationOptions
                {
                    Pages = 3,
                    ResultsPerPage = 10,
                    Offset = 0
                }
            };

            WebScraper scraper = new WebScraper(attrs);

            Assert.ThrowsException<Exception>(() => scraper.getHTML());
        }
        [TestMethod]
        public void getHTML_NonDRSinglePageAndOffset() {
            RequestAttribute attrs = new RequestAttribute
            {
                URI = "https://api.dealerrater.com/",
                URL = "https://www.google.com/",
                API = false,
                AccessToken = "ACCESSTOKENHERE",
                DealerID = "23685",
                PaginationOptions = new PaginationOptions
                {
                    Pages = 1,
                    ResultsPerPage = 10,
                    Offset = 1
                }
            };

            WebScraper scraper = new WebScraper(attrs);

            Assert.ThrowsException<Exception>(() => scraper.getHTML());
        }
        [TestMethod]
        // I will only ever need to scrape 5 for the challenge but it is good to know
        // What my solution is capable of. This would be 10x load.
        public void getHTML_StressTest()
        {
            RequestAttribute attrs = new RequestAttribute
            {
                URI = "https://api.dealerrater.com/",
                URL = "https://www.dealerrater.com/dealer/McKaig-Chevrolet-Buick-A-Dealer-For-The-People-dealer-reviews-23685",
                API = false,
                AccessToken = "ACCESSTOKENHERE",
                DealerID = "23685",
                PaginationOptions = new PaginationOptions
                {
                    Pages = 50,
                    ResultsPerPage = 10,
                    Offset = 0
                }
            };

            WebScraper scraper = new WebScraper(attrs);

            string returnedHTML = scraper.getHTML();
            int index, count = 0;

            while ((index = returnedHTML.ToLower().IndexOf("<!doctype html>")) != -1)
            {
                returnedHTML = returnedHTML.Substring(index + 15, returnedHTML.Length - (index + 15));
                count++;
            }

            Assert.AreEqual(attrs.PaginationOptions.Pages, count);
        }
        [TestMethod]
        public void getHTML_BadURL()
        {
            RequestAttribute attrs = new RequestAttribute
            {
                URI = "https://api.dealerrater.com/",
                URL = "https://www.whatisthisurlitdoesnotexist.com/",
                API = false,
                AccessToken = "ACCESSTOKENHERE",
                DealerID = "23685",
                PaginationOptions = new PaginationOptions
                {
                    Pages = 3,
                    ResultsPerPage = 10,
                    Offset = 0
                }
            };

            WebScraper scraper = new WebScraper(attrs);

            Assert.ThrowsException<WebException>(() => scraper.getHTML());
        }
        [TestMethod]
        public void getJSON_SinglePage()
        {
            RequestAttribute attrs = new RequestAttribute
            {
                URI = "https://api.dealerrater.com/",
                URL = "https://www.dealerrater.com/dealer/McKaig-Chevrolet-Buick-A-Dealer-For-The-People-dealer-reviews-23685",
                API = false,
                AccessToken = "ACCESSTOKENHERE",
                DealerID = "23685",
                PaginationOptions = new PaginationOptions
                {
                    Pages = 1,
                    ResultsPerPage = 10,
                    Offset = 0
                }
            };

            WebScraper scraper = new WebScraper(attrs);

            string returnedJSON = scraper.getJSON();

            ReviewCollection collection = JsonConvert.DeserializeObject<ReviewCollection>(returnedJSON);

            Assert.AreEqual(attrs.PaginationOptions.Pages * attrs.PaginationOptions.ResultsPerPage, collection.reviews.Count);
        }
        [TestMethod]
        public void getJSON_MultipleConcatPages()
        {
            RequestAttribute attrs = new RequestAttribute
            {
                URI = "https://api.dealerrater.com/",
                URL = "https://www.dealerrater.com/dealer/McKaig-Chevrolet-Buick-A-Dealer-For-The-People-dealer-reviews-23685",
                API = false,
                AccessToken = "ACCESSTOKENHERE",
                DealerID = "23685",
                PaginationOptions = new PaginationOptions
                {
                    Pages = 5,
                    ResultsPerPage = 10,
                    Offset = 2
                }
            };

            WebScraper scraper = new WebScraper(attrs);

            string returnedJSON = scraper.getJSON();

            ReviewCollection collection = JsonConvert.DeserializeObject<ReviewCollection>(returnedJSON);

            Assert.AreEqual(attrs.PaginationOptions.Pages * attrs.PaginationOptions.ResultsPerPage, collection.reviews.Count);
        }
        [TestMethod]
        public void getJSON_NonDRPage()
        {
            RequestAttribute attrs = new RequestAttribute
            {
                URI = "https://api.dealerrater.com/",
                URL = "https://www.google.com/",
                API = false,
                AccessToken = "ACCESSTOKENHERE",
                DealerID = "23685",
                PaginationOptions = new PaginationOptions
                {
                    Pages = 1,
                    ResultsPerPage = 10,
                    Offset = 0
                }
            };

            WebScraper scraper = new WebScraper(attrs);

            string returnedJSON = scraper.getJSON();

            ReviewCollection collection = JsonConvert.DeserializeObject<ReviewCollection>(returnedJSON);

            Assert.AreEqual(0, collection.reviews.Count);
        }
        [TestMethod]
        public void getJSON_StressTest()
        {
            RequestAttribute attrs = new RequestAttribute
            {
                URI = "https://api.dealerrater.com/",
                URL = "https://www.dealerrater.com/dealer/McKaig-Chevrolet-Buick-A-Dealer-For-The-People-dealer-reviews-23685",
                API = false,
                AccessToken = "ACCESSTOKENHERE",
                DealerID = "23685",
                PaginationOptions = new PaginationOptions
                {
                    Pages = 50,
                    ResultsPerPage = 10,
                    Offset = 0
                }
            };

            WebScraper scraper = new WebScraper(attrs);

            string returnedJSON = scraper.getJSON();

            ReviewCollection collection = JsonConvert.DeserializeObject<ReviewCollection>(returnedJSON);

            Assert.AreEqual(attrs.PaginationOptions.Pages * attrs.PaginationOptions.ResultsPerPage, collection.reviews.Count);
        }
    }
}
