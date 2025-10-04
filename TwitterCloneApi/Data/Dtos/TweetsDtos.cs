namespace TwitterCloneApi.Data.Dtos
{

    public class UserDtos
    {
        public string UserName { get; set; }
        public bool isActive { get; set; }
        public CountryDtos Country { get; set; }
    }

    public class CountryDtos
    {
        public string Name { get; set; }
    }

    public class TweetsDtos
    {
        public string Content { get; set; }
        public DateTime PublishDatetime { get; set; }

        public UserDtos user { get; set; }
    }

    public class CreateTweetsDtos
    {
        public string Content { get; set; }
        public DateTime PublishDatetime { get; set; }

        public bool isPublic { get; set; }
        public UserDtos user { get; set; }
    }



    public class ActualizarTweetsDtos
    {
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
    