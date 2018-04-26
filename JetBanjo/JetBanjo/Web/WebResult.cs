using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace JetBanjo.Web
{
    /// <summary>
    /// Genereic result object used to return information from a web call
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class WebResult<T>
    {

        public WebResult (T result, HttpStatusCode code, object message)
        {
            Result = result;
            ResponseCode = code;
            ResponseMessage = message;
        }

        /// <summary>
        /// The result from the web call, can be null
        /// </summary>
        public T Result
        {
            get; private set;
        }

        /// <summary>
        /// The reponse code from the web call
        /// </summary>
        public HttpStatusCode ResponseCode
        {
            get; private set;
        }

        /// <summary>
        /// The response message from the web call, can be null
        /// </summary>
        public object ResponseMessage
        {
            get; private set;
        }
    }
}
