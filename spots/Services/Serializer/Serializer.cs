using System.Collections.Generic;

namespace spots.Services.Serializer
{
    public static class Serializer<T>
    {
        public static string ToJson(IEnumerable<T> collection)
        {
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return  serializer.Serialize(collection);
        }

        public static string ToJson(T model)
        {
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(model);
        }
    }
}