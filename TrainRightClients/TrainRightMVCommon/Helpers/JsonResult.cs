using System;
using System.Web;
using System.Web.Mvc;

namespace TrainRightMVCommon.Helpers
{
    public class JsonpResult : JsonResult
    {
        public string CallbackName { get; set; }

        public JsonpResult(string callbackName)
        {
            this.CallbackName = callbackName;
        }

        public JsonpResult()
          : this("jsoncallback")
        {
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            HttpRequestBase request = context.HttpContext.Request;
            HttpResponseBase response = context.HttpContext.Response;
            string str = (context.RouteData.Values[this.CallbackName] as string ?? request[this.CallbackName]) ?? this.CallbackName;
            if (!string.IsNullOrEmpty(str))
            {
                if (string.IsNullOrEmpty(this.ContentType))
                    this.ContentType = "application/x-javascript";
                response.Write(string.Format("{0}(", (object)str));
            }
            base.ExecuteResult(context);
            if (string.IsNullOrEmpty(str))
                return;
            response.Write(")");
        }
    }
}