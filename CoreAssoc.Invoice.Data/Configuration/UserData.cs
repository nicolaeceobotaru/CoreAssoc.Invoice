namespace CoreAssoc.Invoice.Data.Configuration
{
    public class UserData : IUserData
    {
        public UserData(string apiKey)
        {
            ApiKey = apiKey;
        }

        public string ApiKey { get; set; }
    }
}