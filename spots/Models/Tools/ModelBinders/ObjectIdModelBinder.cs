using System.Web.Mvc;
using MongoDB.Bson;

namespace spots.Models.Tools.ModelBinders
{
    public class ObjectIdBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, System.Web.Mvc.ModelBindingContext bindingContext)
        {
            try
            {
                var result = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
                return result == null ? ObjectId.Empty : ObjectId.Parse((string)result.ConvertTo(typeof(string)));
            }
            catch
            {
                return ObjectId.Empty;
            }
        }
    }
}