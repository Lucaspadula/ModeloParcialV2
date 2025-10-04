using TwitterCloneApi.Data.Dtos;

namespace TwitterCloneApi.Services
{
    public interface ItweetsServices
    {
        public Task<IEnumerable<TweetsDtos>> ObtenerTodosAlgunosTweets(string? user, string? country );
        public Task<TweetsDtos> ObtenerTweetPorId(int id);
        public Task<bool> CrearTweet(CreateTweetsDtos createTweetsDtos);
        public Task<bool> ActualizarTweet(int id, ActualizarTweetsDtos actualizarTweetsDtos);
        public Task<bool> BorrarTweet(int id);
    }
}
