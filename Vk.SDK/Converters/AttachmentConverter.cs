using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Vk.SDK.Model;

namespace Vk.SDK.Converters
{
    public abstract class JsonCreationConverter<T> : JsonConverter
    {
        protected abstract T Create(Type objectType, JObject jsonObject);

        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);
            var target = Create(objectType, jsonObject);
            serializer.Populate(jsonObject.CreateReader(), target);
            return target;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }

    //public class AttachmentListConverter : JsonCreationConverter<List<Attachment>>
    //{
    //    protected override List<Attachment> Create(Type objectType, JObject jsonObject)
    //    {
    //        return new List<Attachment>();
    //    }
    //}

    public class AttachmentConverter : JsonCreationConverter<Attachment>
    {

        protected override Attachment Create(Type objectType, JObject jsonObject)
        {
            string typeName = "wall";
            if (jsonObject.Properties().Any(x => x.Name == "type"))
                typeName = (jsonObject["type"]).ToString();
            switch (typeName)
            {
                case "photo":
                    return new Model.Photo();
                case "Audio":
                    return new Audio();
                case "link":
                    return new Link();
                case "album":
                    return new PhotoAlbum();
                case "doc":
                    return new Document();
                case "video":
                    return new Video();
                case "wall":
                    return new Post();
                default:
                    return null;
            }
        }
    }
}
