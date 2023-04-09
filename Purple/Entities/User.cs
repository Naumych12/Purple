using Newtonsoft.Json;

namespace Purple.Entities;

public class User: BaseEntity
{
    [JsonProperty("name")]
    public string Name { get; set; }
    
    [JsonProperty("email")]
    public string Email { get; set; }
    
    [JsonProperty("password")]
    public string Password { get; set; }
    
    [JsonProperty("age")]
    public int Age { get; set; }
}
