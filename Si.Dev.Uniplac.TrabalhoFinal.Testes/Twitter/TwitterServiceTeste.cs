using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TweetSharp;
using System.Net;

namespace Si.Dev.Uniplac.TrabalhoFinal.Testes.Twitter
{
    [TestClass]
    public class TwitterServiceTeste
    {
        private readonly string _consumerKey;
        private readonly string _consumerSecret;
        private readonly string _accessToken;
        private readonly string _accessTokenSecret;

        public TwitterServiceTeste()
        {
            _consumerKey = "tWlN8sWsiKLRV7PLrRxdRwt4A";
            _consumerSecret = "vhav7gpWfdgIeQx6WwLK43tSJs0nv73pwm8K3ENmjd0iQwXvdc";
            _accessToken = "749380798688657408-Vre4y3d9bAwCYJ2VfnuCQnFLrudpUui";
            _accessTokenSecret = "k6kOb1A9QpKQx8peCvfAR2iE0oVkn6hHRUg2czFpVAQjV";
        }

        [TestMethod]
        public void CanGetRequestToken()
        {
            var service = new TwitterService(_consumerKey, _consumerSecret);
            var requestToken = service.GetRequestToken();

            Assert.AreEqual(service.Response.StatusCode, HttpStatusCode.OK);
            Assert.IsNotNull(requestToken);
        }

        [TestMethod]
        public void CanVerifyCredentials()
        {
            var service = GetAuthenticatedService();
            var user = service.VerifyCredentials(new VerifyCredentialsOptions());
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void CanTweet()
        {
            var service = GetAuthenticatedService();

            var status = "Testando aplicação! " + DateTime.Now.Ticks;
            var tweet = service.SendTweet(new SendTweetOptions { Status = status });

            Assert.AreEqual(service.Response.StatusCode, HttpStatusCode.OK);
            Assert.IsNotNull(tweet);
            Assert.AreNotEqual(0, tweet.Id);
        }

        private TwitterService GetAuthenticatedService()
        {
            var service = new TwitterService(_consumerKey, _consumerSecret);
            service.TraceEnabled = true;
            service.AuthenticateWith(_accessToken, _accessTokenSecret);
            return service;
        }
    }
}
