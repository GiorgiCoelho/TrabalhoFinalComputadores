using Si.Dev.Uniplac.TrabalhoFinal.Dominio.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Si.Dev.Uniplac.TrabalhoFinal.Dominio.Entidades;
using System.Configuration;
using TweetSharp;

namespace Si.Dev.Uniplac.TrabalhoFinal.Infra.Twitter.Repositorios
{
    public class TwitterPostRepositorio : IPostRepositorio
    {
        private readonly string _consumerKey;
        private readonly string _consumerSecret;
        private readonly string _accessToken;
        private readonly string _accessTokenSecret;

        public TwitterPostRepositorio()
        {
            _consumerKey = "tWlN8sWsiKLRV7PLrRxdRwt4A";
            _consumerSecret = "vhav7gpWfdgIeQx6WwLK43tSJs0nv73pwm8K3ENmjd0iQwXvdc";
            _accessToken = "749380798688657408-Vre4y3d9bAwCYJ2VfnuCQnFLrudpUui";
            _accessTokenSecret = "k6kOb1A9QpKQx8peCvfAR2iE0oVkn6hHRUg2czFpVAQjV";
        }

        public void SaveOrUpdate(Computador computador)
        {
            var service = GetAuthenticatedService();

            var status = "Novo computador: " + computador.ToString();
            var tweet = service.SendTweet(new SendTweetOptions { Status = status });
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
