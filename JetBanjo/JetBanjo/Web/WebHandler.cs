using JetBanjo.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Cache;
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

            /// <summary>
            /// The result from the web call, can be null
            /// </summary>
            public T Result { get; private set; }
            
            /// <summary>
            /// The reponse code from the web call
            /// </summary>
            public int ResponseCode { get; private set; }
            
            /// <summary>
            /// The response message from the web call, can be null
            /// </summary>
            public object ResponseMessage { get; private set; }
        }

        /// <summary>
        /// Reads data from the specified url
        /// </summary>
        /// <typeparam name="T">The type of the return object</typeparam>
        /// <param name="url">The url of the resource</param>
        /// <returns>A WebResult object that contains the result and response code </returns>
        public static async Task<WebResult<T>> ReadData<T>(string url)
        {
            T Result = default(T);
            int ResponseCode = 0;
            object ResponseMessage = null;
            try
            {
                if (!url.ToLower().StartsWith("http://") || !url.ToLower().StartsWith("https://"))
                {
                    url = "https://" + url;
                }
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url); //URL
                request.CachePolicy = new HttpRequestCachePolicy(HttpCacheAgeControl.MaxAge, Constants.cacheMaxAge);
                request.Timeout = (int) Constants.timeoutTime.TotalMilliseconds; //Timeout defined in constants

                request.Method = "GET";
                using (var response = (HttpWebResponse)await request.GetResponseAsync())
                {
                    ResponseCode = (int)response.StatusCode;
                    ResponseMessage = response.StatusDescription;
                    Stream responseStream = response.GetResponseStream(); 
                    StreamReader streamReader = new StreamReader(responseStream);
                    Result = JsonConvert.DeserializeObject<T>(streamReader.ReadToEnd());
                    streamReader.Dispose();
                    responseStream.Dispose();
                    response.Dispose();
                }
            }
            catch (WebException we)
            {
                if(we != null)
                {
                    if (we.Message != null)
                        Console.WriteLine(we.Message + " reading from " + url);
                    if(we.Response != null)
                    {
                        ResponseCode = (int)((HttpWebResponse)we.Response).StatusCode;
                        ResponseMessage = ((HttpWebResponse)we.Response).StatusDescription;
                    }
                    
                }
            }
            return new WebResult<T>(Result, ResponseCode, ResponseMessage);
        }
    }
}
