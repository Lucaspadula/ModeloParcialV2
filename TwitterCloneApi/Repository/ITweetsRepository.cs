using TwitterCloneApi.Data.Dtos;
using TwitterCloneApi.Models;

namespace TwitterCloneApi.Repository
{
    public interface ITweetsRepository
    {
        //public Task<> SaveChangesAsync();
        public Task<IEnumerable<Tweet>> ObtenerTodosAlgunosTweetsAsync(string? user, string? country );
        public Task<Tweet> ObtenerTweetPorId(int id);
        public Task<bool> CrearTweet(Tweet tweet);
        public Task<bool> ActualizarTweet(Tweet tweet);
        public Task<bool> BorrarTweet(Tweet tweet);

    }
}
