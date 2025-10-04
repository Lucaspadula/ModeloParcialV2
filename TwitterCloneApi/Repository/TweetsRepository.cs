using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;
using TwitterCloneApi.Data.Dtos;
using TwitterCloneApi.Models;

namespace TwitterCloneApi.Repository
{
    public class TweetsRepository : ITweetsRepository
    {

        private readonly TwitterCloneContext _context;

        public TweetsRepository(TwitterCloneContext context)
        {
            _context = context;
        }
        public async Task<bool> ActualizarTweet(Tweet tweet)
        {
            _context.Tweets.Update(tweet);
            var actualizar =  await _context.SaveChangesAsync();

            return actualizar > 0;
        }

        public async Task<bool> BorrarTweet(Tweet tweet)
        {
            _context.Tweets.Remove(tweet);
            var borrar =  await _context.SaveChangesAsync();
            return borrar > 0;
        }

        public async Task<bool> CrearTweet(Tweet tweet)
        {
            _context.Tweets.AddAsync(tweet);
            var create = await _context.SaveChangesAsync();
            return create > 0 ;
        }

        public async Task<IEnumerable<Tweet>> ObtenerTodosAlgunosTweetsAsync(string? user, string? country)
        {
            return await _context.Tweets.
                Include(t=> t.IdUserNavigation).ThenInclude(c=> c.IdCountryNavigation)
                .Where(t => (user == null || t.IdUserNavigation.Username== user) &&
                           (country == null || t.IdUserNavigation.IdCountryNavigation.Country1 == country))
                .ToListAsync() ;
        }

        public async Task<Tweet> ObtenerTweetPorId(int id)
        {
            return await _context.Tweets.FindAsync(id);
        }
    }
}
