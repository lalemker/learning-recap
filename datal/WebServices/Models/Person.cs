namespace WebServices.Models;

using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

public partial class Person
{
    [JsonProperty("name")]
    public virtual string? Name { get; set; }

    [JsonProperty("language")]
    public virtual string? Language { get; set; }

    [JsonProperty("id")]
    public virtual string? Id { get; set; }

    [JsonProperty("bio")]
    public virtual string? Bio { get; set; }

    [JsonProperty("version")]
    public virtual double Version { get; set; }
}

public partial class Person
{
    public static Person? FromJson(string json)
    {
        return JsonConvert.DeserializeObject<Person>(json, WebServices.Models.Converter.Settings);
    }

}

public static class Serialize
{
    public static string ToJson(this Person self) => JsonConvert.SerializeObject(self, WebServices.Models.Converter.Settings);        
}

internal static class Converter
{
    public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
    {
        MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
        DateParseHandling = DateParseHandling.None,
        Converters =
        {
            new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
        },
    };
}
