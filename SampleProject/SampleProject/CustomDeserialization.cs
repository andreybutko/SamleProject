using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SampleProject.Model;
using System;
using System.Linq;

namespace SampleProject
{
    public class CustomDeserialization : JsonConverter
    {
        private const string Bids = "bids";
        private const string Asks = "asks";

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Info);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);

            var bids = jObject[Bids]
                .Select(_ => (Math.Round(_[0].Value<decimal>(), 3), Math.Round(_[1].Value<decimal>(), 3)))
                .ToArray();

            var asks = jObject[Asks]
                .Select(_ => (Math.Round(_[0].Value<decimal>(), 3), Math.Round(_[1].Value<decimal>(), 3)))
                .ToArray();

            return new Info(bids, asks);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            //TODO
        }
    }
}
