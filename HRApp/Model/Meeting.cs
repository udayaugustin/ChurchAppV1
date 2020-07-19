﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using HRApp;
//
//    var meeting = Meeting.FromJson(jsonString);

namespace HRApp
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Meeting
    {
        [JsonProperty("Id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Date")]
        public string Date { get; set; }

        [JsonProperty("Time")]
        public string Time { get; set; }

        [JsonProperty("Location")]
        public string Location { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("status")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Status { get; set; }
    }

    public partial class Meeting
    {
        public static Meeting[] FromJson(string json) => JsonConvert.DeserializeObject<Meeting[]>(json, HRApp.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Meeting[] self) => JsonConvert.SerializeObject(self, HRApp.Converter.Settings);
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

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}
