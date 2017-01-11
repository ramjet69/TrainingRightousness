using System;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace TrainRightMVCommon.Helpers
{
    public static class ControllerExtensions
    {
        public static JsonpResult Jsonp(this Controller controller, object data, string callbackName = "callback")
        {
            JsonpResult jsonpResult = new JsonpResult(callbackName);
            object obj = data;
            jsonpResult.Data = obj;
            int num = 0;
            jsonpResult.JsonRequestBehavior = (JsonRequestBehavior)num;
            return jsonpResult;
        }

        public static T DeserializeObject<T>(this Controller controller, string key) where T : class
        {
            try
            {
                string input = controller.HttpContext.Request.QueryString.Get(key);
                if (string.IsNullOrEmpty(input))
                    return default(T);
                return new JavaScriptSerializer().Deserialize<T>(input);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}