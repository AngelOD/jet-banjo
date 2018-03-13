using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JetBanjo.Web
{
    public class WebHandler
    {
        /// <summary>
        /// Genereic result object used to return information from a web call
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class WebResult<T>
        {

            public WebResult(T result, int code, object message)
            {
                Result = result;
                ResponseCode = code;
                ResponseMessage = message;
            }

            public T Result { get; set; }
            public int ResponseCode { get; private set; }
            public object ResponseMessage { get; private set; }
        }

        public static async Task<WebResult<T>> ReadData<T>(string url)
        {
            T Result = default(T);
            int ResponseCode = 0;
            object ResponseMessage = null;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url); //URL
                request.Timeout = 30000; //30 sec timeout

                request.Method = "GET";
                using (var response = (HttpWebResponse)await request.GetResponseAsync())
                {
                    ResponseCode = (int)response.StatusCode;
                    ResponseMessage = response.StatusDescription;
                    response.Dispose();
                }
            }
            catch (WebException we)
            {
                if(we != null && we.Message != null)
                    Console.WriteLine(we.Message +" in method ReadData with par " + url );
            }
            return new WebResult<T>(Result, ResponseCode, ResponseMessage);
        }
    }
}
