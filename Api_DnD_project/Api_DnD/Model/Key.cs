namespace Api_DnD.Model
{
    public class Key
    {
        public int Id { get; set; }
        public string ApiKey { get; set; }

        public string Role { get; set; }

        public Key(string apiKey, string role) 
        {
            ApiKey = apiKey;
            Role = role;
        }

        public Key() { }
    }
}
