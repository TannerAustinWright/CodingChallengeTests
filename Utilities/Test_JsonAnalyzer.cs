using CodingChallenge.APIModels;
using CodingChallenge.AttributeModels;
using CodingChallenge.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace CodingChallengeTests
{
    [TestClass]
    public class Test_JsonAnalyzer {
        // Output Word Count
        // OneReviewOneRule
        // TwoReviewsTwoRules
        // OneReviewTwoRules
        // TwoReviewsOneRule
        // Custom Object
        // Bad Rule (rule property does not exist)
        // Bad Review (review property empty)
        [TestMethod]
        public void outputWordCount_OneReviewOneRule()
        {
            List<AnalyzerRule> rules = new List<AnalyzerRule>()
            {
                new AnalyzerRule(){
                    Key = "comments",
                    Rules = new List<KeyWeight>()
                    {
                        new KeyWeight(){Keyword = "positiveOne", Weight = 1},
                        new KeyWeight(){Keyword = "negativeOne", Weight = -1},
                        new KeyWeight(){Keyword = "positiveTwo", Weight = 2}
                    }
                }
            };

            JsonAnalyzer<Review> analyzer = new JsonAnalyzer<Review>(rules);

            StringWriter debugLog = new StringWriter();
            Console.SetOut(debugLog);
            Console.SetError(debugLog);

            ReviewCollection mockCollection = new ReviewCollection()
            {
                dealerId = "12345",
                ratingURl = "test/ratings",
                name = "testDealer",
                reviewCount = 1,
                reviews = new List<Review>() {
                            new Review()
                            {
                                id = "001",
                                dateWritten = "01/19/2021",
                                comments = "positiveOne positiveOne positiveOne positiveOne positiveTwo " +
                                "positiveTwo negativeOne negativeOne negativeOne negativeOne negativeOne"
                            }
                        }
            };

            analyzer.outputWordCount(JsonConvert.SerializeObject(mockCollection.reviews));

            string log = debugLog.ToString();
            Assert.AreEqual(0, "negativeone 5\r\npositiveone 4\r\npositivetwo 2\r\n".CompareTo(log));
        }
        [TestMethod]
        public void outputWordCount_OneReviewTwoRules()
        {
            List<AnalyzerRule> rules = new List<AnalyzerRule>()
            {
                new AnalyzerRule(){
                    Key = "comments",
                    Rules = new List<KeyWeight>()
                    {
                        new KeyWeight(){Keyword = "positiveOne", Weight = 1},
                        new KeyWeight(){Keyword = "negativeOne", Weight = -1},
                        new KeyWeight(){Keyword = "positiveTwo", Weight = 2}
                    }
                },
                new AnalyzerRule(){
                    Key = "comments",
                    Rules = new List<KeyWeight>()
                    {
                        new KeyWeight(){Keyword = "positiveOne", Weight = 1},
                        new KeyWeight(){Keyword = "negativeOne", Weight = -1},
                        new KeyWeight(){Keyword = "positiveTwo", Weight = 2}
                    }
                }
            };

            JsonAnalyzer<Review> analyzer = new JsonAnalyzer<Review>(rules);

            StringWriter debugLog = new StringWriter();
            Console.SetOut(debugLog);
            Console.SetError(debugLog);

            ReviewCollection mockCollection = new ReviewCollection()
            {
                dealerId = "12345",
                ratingURl = "test/ratings",
                name = "testDealer",
                reviewCount = 1,
                reviews = new List<Review>() {
                            new Review()
                            {
                                id = "001",
                                dateWritten = "01/19/2021",
                                comments = "positiveOne positiveOne positiveOne positiveOne positiveTwo " +
                                "positiveTwo negativeOne negativeOne negativeOne negativeOne negativeOne"
                            }
                        }
            };

            analyzer.outputWordCount(JsonConvert.SerializeObject(mockCollection.reviews));

            string log = debugLog.ToString();
            Assert.AreEqual(0, "negativeone 10\r\npositiveone 8\r\npositivetwo 4\r\n".CompareTo(log));
        }
        [TestMethod]
        public void outputWordCount_TwoReviewsOneRule()
        {
            List<AnalyzerRule> rules = new List<AnalyzerRule>()
            {
                new AnalyzerRule(){
                    Key = "comments",
                    Rules = new List<KeyWeight>()
                    {
                        new KeyWeight(){Keyword = "positiveOne", Weight = 1},
                        new KeyWeight(){Keyword = "negativeOne", Weight = -1},
                        new KeyWeight(){Keyword = "positiveTwo", Weight = 2}
                    }
                }
            };

            JsonAnalyzer<Review> analyzer = new JsonAnalyzer<Review>(rules);

            StringWriter debugLog = new StringWriter();
            Console.SetOut(debugLog);
            Console.SetError(debugLog);

            ReviewCollection mockCollection = new ReviewCollection()
            {
                dealerId = "12345",
                ratingURl = "test/ratings",
                name = "testDealer",
                reviewCount = 1,
                reviews = new List<Review>() {
                            new Review()
                            {
                                id = "001",
                                dateWritten = "01/19/2021",
                                comments = "positiveOne positiveOne positiveOne positiveOne positiveTwo " +
                                "positiveTwo negativeOne negativeOne negativeOne negativeOne negativeOne"
                            },
                            new Review()
                            {
                                id = "002",
                                dateWritten = "01/19/2021",
                                comments = "positiveOne positiveOne positiveOne positiveOne positiveTwo " +
                                "positiveTwo negativeOne negativeOne negativeOne negativeOne negativeOne"
                            }
                        }
            };

            analyzer.outputWordCount(JsonConvert.SerializeObject(mockCollection.reviews));

            string log = debugLog.ToString();
            Assert.AreEqual(0, "negativeone 10\r\npositiveone 8\r\npositivetwo 4\r\n".CompareTo(log));

        }
        [TestMethod]
        public void outputWordCount_TwoReviewsTwoRules()
        {
            List<AnalyzerRule> rules = new List<AnalyzerRule>()
            {
                new AnalyzerRule(){
                    Key = "comments",
                    Rules = new List<KeyWeight>()
                    {
                        new KeyWeight(){Keyword = "positiveOne", Weight = 1},
                        new KeyWeight(){Keyword = "negativeOne", Weight = -1},
                        new KeyWeight(){Keyword = "positiveTwo", Weight = 2}
                    }
                },
                new AnalyzerRule(){
                    Key = "comments",
                    Rules = new List<KeyWeight>()
                    {
                        new KeyWeight(){Keyword = "positiveOne", Weight = 1},
                        new KeyWeight(){Keyword = "negativeOne", Weight = -1},
                        new KeyWeight(){Keyword = "positiveTwo", Weight = 2}
                    }
                }
            };

            JsonAnalyzer<Review> analyzer = new JsonAnalyzer<Review>(rules);

            StringWriter debugLog = new StringWriter();
            Console.SetOut(debugLog);
            Console.SetError(debugLog);

            ReviewCollection mockCollection = new ReviewCollection()
            {
                dealerId = "12345",
                ratingURl = "test/ratings",
                name = "testDealer",
                reviewCount = 1,
                reviews = new List<Review>() {
                            new Review()
                            {
                                id = "001",
                                dateWritten = "01/19/2021",
                                comments = "positiveOne positiveOne positiveOne positiveOne positiveTwo " +
                                "positiveTwo negativeOne negativeOne negativeOne negativeOne negativeOne"
                            },
                            new Review()
                            {
                                id = "002",
                                dateWritten = "01/19/2021",
                                comments = "positiveOne positiveOne positiveOne positiveOne positiveTwo " +
                                "positiveTwo negativeOne negativeOne negativeOne negativeOne negativeOne"
                            }
                        }
            };

            analyzer.outputWordCount(JsonConvert.SerializeObject(mockCollection.reviews));
            string log = debugLog.ToString();

            Assert.AreEqual(0, "negativeone 20\r\npositiveone 16\r\npositivetwo 8\r\n".CompareTo(log));
        }
        [TestMethod]
        public void outputWordCount_CustomObject()
        {
            List<AnalyzerRule> rules = new List<AnalyzerRule>()
            {
                new AnalyzerRule(){
                    Key = "testProperty",
                    Rules = new List<KeyWeight>()
                    {
                        new KeyWeight(){Keyword = "positiveOne", Weight = 1},
                        new KeyWeight(){Keyword = "negativeOne", Weight = -1},
                        new KeyWeight(){Keyword = "positiveTwo", Weight = 2}
                    }
                }
            };

            JsonAnalyzer<testType> analyzer = new JsonAnalyzer<testType>(rules);

            StringWriter debugLog = new StringWriter();
            Console.SetOut(debugLog);
            Console.SetError(debugLog);

            List<testType> testList = new List<testType>()
            {
                new testType(){ testProperty = "positiveTwo" },
                new testType(){ testProperty = "negativeOne negativeOne" }
            };

            analyzer.outputWordCount(JsonConvert.SerializeObject(testList));

            string log = debugLog.ToString();
            Assert.AreEqual(0, "negativeone 2\r\npositivetwo 1\r\n".CompareTo(log));
        }
        [TestMethod]
        public void outputWordCount_BadRule()
        {
            List<AnalyzerRule> rules = new List<AnalyzerRule>()
            {
                new AnalyzerRule(){
                    Key = "aPropertyThatDoesNotExist",
                    Rules = new List<KeyWeight>()
                    {
                        new KeyWeight(){Keyword = "positiveOne", Weight = 1},
                        new KeyWeight(){Keyword = "negativeOne", Weight = -1},
                        new KeyWeight(){Keyword = "positiveTwo", Weight = 2}
                    }
                }
            };

            JsonAnalyzer<testType> analyzer = new JsonAnalyzer<testType>(rules);

            List<testType> testList = new List<testType>()
            {
                new testType(){ testProperty = "positiveTwo" },
                new testType(){ testProperty = "negativeOne negativeOne" }
            };

            Assert.ThrowsException<Exception>(() => analyzer.outputWordCount(JsonConvert.SerializeObject(testList)));
        }
        [TestMethod]
        public void outputWordCount_ReviewWithNoProperty()
        {
            List<AnalyzerRule> rules = new List<AnalyzerRule>()
            {
                new AnalyzerRule(){
                    Key = "testProperty",
                    Rules = new List<KeyWeight>()
                    {
                        new KeyWeight(){Keyword = "positiveOne", Weight = 1},
                        new KeyWeight(){Keyword = "negativeOne", Weight = -1},
                        new KeyWeight(){Keyword = "positiveTwo", Weight = 2}
                    }
                }
            };

            JsonAnalyzer<testType> analyzer = new JsonAnalyzer<testType>(rules);

            List<testType> testList = new List<testType>()
            {
                new testType(),
                new testType()
            };

            Assert.ThrowsException<Exception>(() => analyzer.outputWordCount(JsonConvert.SerializeObject(testList)));
        }
        // Run Rules
        // OneReviewOneRule
        // TwoReviewsTwoRules
        // OneReviewTwoRules
        // TwoReviewsOneRule
        // Custom Object
        // Bad Rule (rule property does not exist)
        // Bad Review (review property empty)
        [TestMethod]
        public void runRules_OneReviewOneRule()
        {
            List<AnalyzerRule> rules = new List<AnalyzerRule>()
            {
                new AnalyzerRule(){
                    Key = "comments",
                    Rules = new List<KeyWeight>()
                    {
                        new KeyWeight(){Keyword = "positiveOne", Weight = 1},
                        new KeyWeight(){Keyword = "negativeOne", Weight = -1},
                        new KeyWeight(){Keyword = "positiveTwo", Weight = 2}
                    }
                }
            };

            JsonAnalyzer<Review> analyzer = new JsonAnalyzer<Review>(rules);

            ReviewCollection mockCollection = new ReviewCollection()
            {
                dealerId = "12345",
                ratingURl = "test/ratings",
                name = "testDealer",
                reviewCount = 1,
                reviews = new List<Review>() {
                            new Review()
                            {
                                id = "001",
                                dateWritten = "01/19/2021",
                                comments = "positiveOne positiveOne positiveOne positiveOne positiveTwo " +
                                "positiveTwo negativeOne negativeOne negativeOne negativeOne negativeOne"
                            }
                        }
            };

            analyzer.runRules(JsonConvert.SerializeObject(mockCollection.reviews));

            KeyValuePair<Review,int> review = analyzer.getTop(1)[0];

            Assert.AreEqual(3, review.Value);
        }
        [TestMethod]
        public void runRules_OneReviewTwoRules()
        {
            List<AnalyzerRule> rules = new List<AnalyzerRule>()
            {
                new AnalyzerRule(){
                    Key = "comments",
                    Rules = new List<KeyWeight>()
                    {
                        new KeyWeight(){Keyword = "positiveOne", Weight = 1},
                        new KeyWeight(){Keyword = "negativeOne", Weight = -1},
                        new KeyWeight(){Keyword = "positiveTwo", Weight = 2}
                    }
                },
                new AnalyzerRule(){
                    Key = "comments",
                    Rules = new List<KeyWeight>()
                    {
                        new KeyWeight(){Keyword = "positiveOne", Weight = 1},
                        new KeyWeight(){Keyword = "negativeOne", Weight = -1},
                        new KeyWeight(){Keyword = "positiveTwo", Weight = 2}
                    }
                }
            };

            JsonAnalyzer<Review> analyzer = new JsonAnalyzer<Review>(rules);

            ReviewCollection mockCollection = new ReviewCollection()
            {
                dealerId = "12345",
                ratingURl = "test/ratings",
                name = "testDealer",
                reviewCount = 1,
                reviews = new List<Review>() {
                            new Review()
                            {
                                id = "001",
                                dateWritten = "01/19/2021",
                                comments = "positiveOne positiveOne positiveOne positiveOne positiveTwo " +
                                "positiveTwo negativeOne negativeOne negativeOne negativeOne negativeOne"
                            }
                        }
            };

            analyzer.runRules(JsonConvert.SerializeObject(mockCollection.reviews));

            KeyValuePair<Review, int> review = analyzer.getTop(1)[0];

            Assert.AreEqual(6, review.Value);
        }
        [TestMethod]
        public void runRules_TwoReviewsOneRule()
        {
            List<AnalyzerRule> rules = new List<AnalyzerRule>()
            {
                new AnalyzerRule(){
                    Key = "comments",
                    Rules = new List<KeyWeight>()
                    {
                        new KeyWeight(){Keyword = "positiveOne", Weight = 1},
                        new KeyWeight(){Keyword = "negativeOne", Weight = -1},
                        new KeyWeight(){Keyword = "positiveTwo", Weight = 2}
                    }
                }
            };

            JsonAnalyzer<Review> analyzer = new JsonAnalyzer<Review>(rules);

            ReviewCollection mockCollection = new ReviewCollection()
            {
                dealerId = "12345",
                ratingURl = "test/ratings",
                name = "testDealer",
                reviewCount = 1,
                reviews = new List<Review>() {
                            new Review()
                            {
                                id = "001",
                                dateWritten = "01/19/2021",
                                comments = "positiveOne positiveOne positiveOne positiveOne positiveTwo " +
                                "positiveTwo negativeOne negativeOne negativeOne negativeOne negativeOne"
                            },
                            new Review()
                            {
                                id = "002",
                                dateWritten = "01/19/2021",
                                comments = "positiveOne positiveOne positiveOne positiveOne positiveTwo " +
                                "positiveTwo negativeOne negativeOne negativeOne negativeOne negativeOne"
                            }
                        }
            };

            analyzer.runRules(JsonConvert.SerializeObject(mockCollection.reviews));

            KeyValuePair<Review, int> review = analyzer.getTop(2)[0];
            Assert.AreEqual(3, review.Value);
            review = analyzer.getTop(2)[1];
            Assert.AreEqual(3, review.Value);
        }
        [TestMethod]
        public void runRules_TwoReviewsTwoRules()
        {
            List<AnalyzerRule> rules = new List<AnalyzerRule>()
            {
                new AnalyzerRule(){
                    Key = "comments",
                    Rules = new List<KeyWeight>()
                    {
                        new KeyWeight(){Keyword = "positiveOne", Weight = 1},
                        new KeyWeight(){Keyword = "negativeOne", Weight = -1},
                        new KeyWeight(){Keyword = "positiveTwo", Weight = 2}
                    }
                },
                new AnalyzerRule(){
                    Key = "comments",
                    Rules = new List<KeyWeight>()
                    {
                        new KeyWeight(){Keyword = "positiveOne", Weight = 1},
                        new KeyWeight(){Keyword = "negativeOne", Weight = -1},
                        new KeyWeight(){Keyword = "positiveTwo", Weight = 2}
                    }
                }
            };

            JsonAnalyzer<Review> analyzer = new JsonAnalyzer<Review>(rules);

            ReviewCollection mockCollection = new ReviewCollection()
            {
                dealerId = "12345",
                ratingURl = "test/ratings",
                name = "testDealer",
                reviewCount = 1,
                reviews = new List<Review>() {
                            new Review()
                            {
                                id = "001",
                                dateWritten = "01/19/2021",
                                comments = "positiveOne positiveOne positiveOne positiveOne positiveTwo " +
                                "positiveTwo negativeOne negativeOne negativeOne negativeOne negativeOne"
                            },
                            new Review()
                            {
                                id = "002",
                                dateWritten = "01/19/2021",
                                comments = "positiveOne positiveOne positiveOne positiveOne positiveTwo " +
                                "positiveTwo negativeOne negativeOne negativeOne negativeOne negativeOne"
                            }
                        }
            };


            analyzer.runRules(JsonConvert.SerializeObject(mockCollection.reviews));

            KeyValuePair<Review, int> review = analyzer.getTop(2)[0];
            Assert.AreEqual(6, review.Value);
            review = analyzer.getTop(2)[1];
            Assert.AreEqual(6, review.Value);
        }
        [TestMethod]
        public void runRules_CustomObject()
        {
            List<AnalyzerRule> rules = new List<AnalyzerRule>()
            {
                new AnalyzerRule(){
                    Key = "testProperty",
                    Rules = new List<KeyWeight>()
                    {
                        new KeyWeight(){Keyword = "positiveOne", Weight = 1},
                        new KeyWeight(){Keyword = "negativeOne", Weight = -1},
                        new KeyWeight(){Keyword = "positiveTwo", Weight = 2}
                    }
                }
            };

            JsonAnalyzer<testType> analyzer = new JsonAnalyzer<testType>(rules);

            StringWriter debugLog = new StringWriter();
            Console.SetOut(debugLog);
            Console.SetError(debugLog);

            List<testType> testList = new List<testType>()
            {
                new testType(){ testProperty = "positiveTwo" },
                new testType(){ testProperty = "negativeOne negativeOne" }
            };


            analyzer.runRules(JsonConvert.SerializeObject(testList));

            KeyValuePair<testType, int> testType = analyzer.getTop(2)[0];
            Assert.AreEqual(2, testType.Value);
            testType = analyzer.getTop(2)[1];
            Assert.AreEqual(-2, testType.Value);
        }
        [TestMethod]
        public void runRules_BadRule()
        {
            List<AnalyzerRule> rules = new List<AnalyzerRule>()
            {
                new AnalyzerRule(){
                    Key = "aPropertyThatDoesNotExist",
                    Rules = new List<KeyWeight>()
                    {
                        new KeyWeight(){Keyword = "positiveOne", Weight = 1},
                        new KeyWeight(){Keyword = "negativeOne", Weight = -1},
                        new KeyWeight(){Keyword = "positiveTwo", Weight = 2}
                    }
                }
            };

            JsonAnalyzer<testType> analyzer = new JsonAnalyzer<testType>(rules);

            List<testType> testList = new List<testType>()
            {
                new testType(){ testProperty = "positiveTwo" },
                new testType(){ testProperty = "negativeOne negativeOne" }
            };

            Assert.ThrowsException<Exception>(() => analyzer.runRules(JsonConvert.SerializeObject(testList)));
        }
        [TestMethod]
        public void runRules_ReviewWithNoProperty()
        {
            List<AnalyzerRule> rules = new List<AnalyzerRule>()
            {
                new AnalyzerRule(){
                    Key = "testProperty",
                    Rules = new List<KeyWeight>()
                    {
                        new KeyWeight(){Keyword = "positiveOne", Weight = 1},
                        new KeyWeight(){Keyword = "negativeOne", Weight = -1},
                        new KeyWeight(){Keyword = "positiveTwo", Weight = 2}
                    }
                }
            };

            JsonAnalyzer<testType> analyzer = new JsonAnalyzer<testType>(rules);

            List<testType> testList = new List<testType>()
            {
                new testType(),
                new testType()
            };

            Assert.ThrowsException<Exception>(() => analyzer.runRules(JsonConvert.SerializeObject(testList)));
        }
        // Get Top
        // With a parameter of 0 returns all
        // With a parameter > the total
        // With a parameter < the total
        // With an empty list
        [TestMethod]
        public void getTop_ReturnAll() {
            List<AnalyzerRule> rules = new List<AnalyzerRule>()
            {
                new AnalyzerRule(){
                    Key = "comments",
                    Rules = new List<KeyWeight>()
                    {
                        new KeyWeight(){Keyword = "amazing", Weight = 2},
                        new KeyWeight(){Keyword = "helpful", Weight = 1},
                        new KeyWeight(){Keyword = "bad", Weight = -1}
                    }
                }
            };
            JsonAnalyzer<Review> analyzer = new JsonAnalyzer<Review>(rules);


            ReviewCollection mockCollection = new ReviewCollection()
            {
                dealerId = "12345",
                ratingURl = "test/ratings",
                name = "testDealer",
                reviewCount = 1,
                reviews = new List<Review>() {
                            new Review()
                            {
                                id = "001",
                                dateWritten = "01/19/2021",
                                comments = "Helpful and amazing"
                            },
                            new Review()
                            {
                                id = "002",
                                dateWritten = "01/19/2021",
                                comments = "Amazing and a little bad"
                            },
                            new Review()
                            {
                                id = "003",
                                dateWritten = "01/19/2021",
                                comments = "Helpful and a little bad"
                            },
                            new Review()
                            {
                                id = "003",
                                dateWritten = "01/19/2021",
                                comments = "Just bad"
                            }
                        }
            };

            analyzer.runRules(JsonConvert.SerializeObject(mockCollection.reviews));

            List<KeyValuePair<Review, int>> returned = analyzer.getTop(0);

            Assert.AreEqual(mockCollection.reviews.Count, returned.Count);
        }
        [TestMethod]
        public void getTop_ReturnTooMany() {
            List<AnalyzerRule> rules = new List<AnalyzerRule>()
            {
                new AnalyzerRule(){
                    Key = "comments",
                    Rules = new List<KeyWeight>()
                    {
                        new KeyWeight(){Keyword = "amazing", Weight = 2},
                        new KeyWeight(){Keyword = "helpful", Weight = 1},
                        new KeyWeight(){Keyword = "bad", Weight = -1}
                    }
                }
            };
            JsonAnalyzer<Review> analyzer = new JsonAnalyzer<Review>(rules);


            ReviewCollection mockCollection = new ReviewCollection()
            {
                dealerId = "12345",
                ratingURl = "test/ratings",
                name = "testDealer",
                reviewCount = 1,
                reviews = new List<Review>() {
                            new Review()
                            {
                                id = "001",
                                dateWritten = "01/19/2021",
                                comments = "Helpful and amazing"
                            },
                            new Review()
                            {
                                id = "002",
                                dateWritten = "01/19/2021",
                                comments = "Amazing and a little bad"
                            },
                            new Review()
                            {
                                id = "003",
                                dateWritten = "01/19/2021",
                                comments = "Helpful and a little bad"
                            },
                            new Review()
                            {
                                id = "003",
                                dateWritten = "01/19/2021",
                                comments = "Just bad"
                            }
                        }
            };

            analyzer.runRules(JsonConvert.SerializeObject(mockCollection.reviews));

            List<KeyValuePair<Review, int>> returned = analyzer.getTop(100);

            Assert.AreEqual(mockCollection.reviews.Count, returned.Count);
        }
        [TestMethod]
        public void getTop_ReturnSubset() {
            List<AnalyzerRule> rules = new List<AnalyzerRule>()
            {
                new AnalyzerRule(){
                    Key = "comments",
                    Rules = new List<KeyWeight>()
                    {
                        new KeyWeight(){Keyword = "amazing", Weight = 2},
                        new KeyWeight(){Keyword = "helpful", Weight = 1},
                        new KeyWeight(){Keyword = "bad", Weight = -1}
                    }
                }
            };
            JsonAnalyzer<Review> analyzer = new JsonAnalyzer<Review>(rules);


            ReviewCollection mockCollection = new ReviewCollection()
            {
                dealerId = "12345",
                ratingURl = "test/ratings",
                name = "testDealer",
                reviewCount = 1,
                reviews = new List<Review>() {
                            new Review()
                            {
                                id = "001",
                                dateWritten = "01/19/2021",
                                comments = "Helpful and amazing"
                            },
                            new Review()
                            {
                                id = "002",
                                dateWritten = "01/19/2021",
                                comments = "Amazing and a little bad"
                            },
                            new Review()
                            {
                                id = "003",
                                dateWritten = "01/19/2021",
                                comments = "Helpful and a little bad"
                            },
                            new Review()
                            {
                                id = "003",
                                dateWritten = "01/19/2021",
                                comments = "Just bad"
                            }
                        }
            };

            analyzer.runRules(JsonConvert.SerializeObject(mockCollection.reviews));

            int numToReturn = 2;

            List<KeyValuePair<Review, int>> returned = analyzer.getTop(numToReturn);

            Assert.AreEqual(numToReturn, returned.Count);
        }

    }

    public class testType
    {
        public string testProperty { get; set; }
    }
}
