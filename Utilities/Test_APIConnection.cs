using CodingChallenge.AttributeModels;
using CodingChallenge.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CodingChallengeTests
{
    [TestClass]
    public partial class Test_APIConnection
    {
        [TestMethod]
        public void getJSON_ThrowsNotImplemented()
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
                    Offset = 0
                }
            };

            APIConnection api = new APIConnection(attrs);

            Assert.ThrowsException<NotImplementedException>(() => api.getJSON());
        }
    }

}
