using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace Panacea.Events.Web.Helpers
{
    public class ServiceManager
    {
        /// <summary>
        /// Sends a get request to the restful webservice
        /// </summary>
        /// <param name="requestName"></param>
        /// <returns></returns>
        public static string DoGetRequest(string requestName)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(ConfigurationManager.AppSettings["ServiceBaseUrl"].ToString() + requestName);
                request.Method = "GET";
                string responseString = string.Empty;
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    responseString = reader.ReadToEnd();
                    reader.Close();
                    dataStream.Close();
                }
                return responseString;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Sends a post request to the restful webservice
        /// </summary>
        /// <param name="requestName"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string DoPostRequest(string requestName, string data)
        {
            string responseString = string.Empty;

            try
            {
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;

                responseString = webClient.UploadString(ConfigurationManager.AppSettings["ServiceBaseUrl"].ToString() + requestName, "POST", data);
                return responseString;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}