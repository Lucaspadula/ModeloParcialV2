using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.IdentityModel.Tokens;
using TwitterCloneApi.Data.Dtos;
using TwitterCloneApi.Models;
using TwitterCloneApi.Repository;

namespace TwitterCloneApi.Services
{
    public class tweetsServices : ItweetsServices
    {
        private readonly ITweetsRepository _tweetsRepository;

        public tweetsServices(ITweetsRepository tweetsRepository)
        {
            _tweetsRepository = tweetsRepository;
        }

        public async Task<bool> ActualizarTweet(int id, ActualizarTweetsDtos actualizarTweetsDtos)
        {
            var validTweet = await _tweetsRepository.ObtenerTweetPorId(id);

            if (validTweet == null ) {
                throw new NotImplementedException();
            }

            validTweet.Content = actualizarTweetsDtos.Content;
            validTweet.PublishDatetime = actualizarTweetsDtos.CreatedAt;

            var actualizarTweet = await _tweetsRepository.ActualizarTweet(validTweet);
            return actualizarTweet == true;

        }

        public async Task<bool> BorrarTweet(int id)
        {
            var validTweet = _tweetsRepository.ObtenerTweetPorId(id).Result;
            if ( validTweet == null)
            {
                throw new Exception("Error no existe el Tweet");
            }
            var borrar = await _tweetsRepository.BorrarTweet(validTweet);
            return borrar == true;
        }

        public Task<bool> CrearTweet(CreateTweetsDtos createTweetsDtos)
        {
            try
            {
                var TweetDtos = new Tweet
                {
                    Content = createTweetsDtos.Content,
                    PublishDatetime = createTweetsDtos.PublishDatetime,
                    IsPublic = createTweetsDtos.isPublic,
                    IdUserNavigation = new User
                    {
                        Username = createTweetsDtos.user.UserName,
                        IsActive = createTweetsDtos.user.isActive,
                        IdCountryNavigation = new Country
                        {
                            Country1 = createTweetsDtos.user.Country.Name
                        }
                    }
                };
                return _tweetsRepository.CrearTweet(TweetDtos);
                
            }
            catch (Exception e) {
                throw new Exception("Error al eliminar el registro");
            }
        }

        public async Task<IEnumerable<TweetsDtos>> ObtenerTodosAlgunosTweets(string? user, string? country)
        {
            try
            {
                var tweets = _tweetsRepository.ObtenerTodosAlgunosTweetsAsync(user, country).Result;
                var tweetsList = tweets.Select( tweets => new TweetsDtos()
                {
                    Content = tweets.Content,
                    PublishDatetime = tweets.PublishDatetime,
                    user = new UserDtos
                    {
                        UserName = tweets.IdUserNavigation.Username,
                        Country = new CountryDtos
                        {
                            Name = tweets.IdUserNavigation.IdCountryNavigation.Country1
                        }
                    }
                });
                return tweetsList;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los tweets: " + ex.Message);
            }
        }

        public Task<TweetsDtos> ObtenerTweetPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
