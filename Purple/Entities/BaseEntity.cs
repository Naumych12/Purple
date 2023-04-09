using System;
using Newtonsoft.Json;

namespace Purple.Entities;

public class BaseEntity
{
    [JsonProperty("id")]
    public Guid Id { get; set; }
    
    [JsonProperty("dateCreated")]
    public DateTime DateAdded { get; set; }    
    
    [JsonProperty("dateModified")]
    public DateTime DateModified { get; set; }
}