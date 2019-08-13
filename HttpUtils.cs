using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Collections.Specialized;
using System.IO.Compression;
using System.Text.RegularExpressions;

namespace IQIYI.PlayList
{
    public class HttpUtils
    {

          public static string HttpGet(string url, string parms)
        {
            string ret = "";
            string u = url;
            if (parms != "")
            {
                u = url + "?" + parms;
            }
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(u);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream,Encoding.UTF8);
                ret = reader.ReadToEnd();
                reader.Close();
            }
            return ret;
        }
        public static string HttpGet(string url, string parms,string cookie)
        {
            string ret = "";
            string u = url;
            if (parms != "")
            {
                u = url + "?" + parms;
            }
            Uri uri = new Uri(url, true);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
            request.Method = "GET";
            //request.Headers.Add("Upgrade-Insecure-Requests", "1");
            request.Headers.Add("Cookie", cookie);
            
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                ret = reader.ReadToEnd();
                reader.Close();
            }
            return ret;
        }


        public static string HttpGet(string url,string parms, string  cookie, Dictionary<string, string> headers)
        {
            string ret = "";
            Uri uri = new Uri(url,true);
           
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
            //request.CookieContainer = cookieContainer;
            request.Method = "GET";
            //request.ContentType = "application/x-www-form-urlencoded;charset=utf8";
            foreach (var s in headers)
            {
                if (s.Key == "Accept")
                {
                    request.Accept = s.Value;
                }
                else if (s.Key == "Connection")
                {
                    SetHeaderValue(request.Headers, s.Key, s.Value);
                }
                else if (s.Key == "Host")
                {
                    SetHeaderValue(request.Headers, s.Key, s.Value);
                }
                else if (s.Key == "User-Agent")
                { request.UserAgent = s.Value; }
                else if (s.Key == "Referer")
                { request.Referer = s.Value; }
                else if (s.Key == "Cookie")
                {
                    request.Headers.Add("Cookie", s.Value);
                }
                else if (s.Key == "Content-Type")
                {
                    request.ContentType = s.Value;
                }
                else
                {
                    request.Headers.Add(s.Key + ": " + s.Value);
                }
            }
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                    ret = reader.ReadToEnd();
                    reader.Close();
                }
            }
            catch
            {

            }
            return ret;
        }
        public static void SetHeaderValue(WebHeaderCollection header, string name, string value)
        {
            var property = typeof(WebHeaderCollection).GetProperty("InnerCollection",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            if (property != null)
            {
                var collection = property.GetValue(header, null) as NameValueCollection;
                collection[name] = value;
            }
        }




        public static string HttpGet(string url, string parms, Dictionary<string, string> headers)
        {
            string ret = "";
            if (parms != "")
            {
                url = url + "?" + parms;
            }
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "GET";
            //request.ContentType = "application/x-www-form-urlencoded;charset=utf8";
            foreach (var s in headers)
            {
                if (s.Key == "Accept")
                {
                    request.Accept = s.Value;
                }
                else if (s.Key == "Connection")
                {
                    SetHeaderValue(request.Headers, s.Key, s.Value);
                }
                else if (s.Key == "Host" || s.Key=="accept")
                {
                    SetHeaderValue(request.Headers, s.Key, s.Value);
                }
                else if (s.Key == "User-Agent")
                { request.UserAgent = s.Value; }
                else if (s.Key == "Referer")
                {
                    request.Referer = s.Value;
                }
                else
                {
                    request.Headers.Add(s.Key + ": " + s.Value);
                }
            }
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {
                    string responseUri = response.ResponseUri.ToString();
                    StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                    ret = reader.ReadToEnd();
                    reader.Close();
                }
            }
            catch
            {

            }
            return ret;
        }




        public static string HttpGet(string url, string parms, Dictionary<string, string> headers,out string u_code)
        {
            string ret = "";
            if (parms != "")
            {
                url = url + "?" + parms;
            }
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "GET";
            //request.ContentType = "application/x-www-form-urlencoded;charset=utf8";
            foreach (var s in headers)
            {
                if (s.Key == "Accept")
                {
                    request.Accept = s.Value;
                }
                else if (s.Key == "Connection")
                {
                    SetHeaderValue(request.Headers, s.Key, s.Value);
                }
                else if (s.Key == "Host" || s.Key == "accept")
                {
                    SetHeaderValue(request.Headers, s.Key, s.Value);
                }
                else if (s.Key == "User-Agent")
                { request.UserAgent = s.Value; }
                else if (s.Key == "Referer")
                {
                    request.Referer = s.Value;
                }
                else
                {
                    request.Headers.Add(s.Key + ": " + s.Value);
                }
            }
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {
                    string responseUri = response.ResponseUri.ToString();
                    Regex reg = new Regex("u_code=([^&]+)");
                    Match match = reg.Match(responseUri);
                    if (match != null)
                    {
                        u_code = match.Groups[1].Value;
                    }
                    else {
                        u_code = "";
                    }
                    StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                    ret = reader.ReadToEnd();
                    reader.Close();
                }
            }
            catch
            {
                u_code = "";
            }
            return ret;
        }

        public static string HttpPost(string url, string parms, Dictionary<string, string> headers)
        {
            string ret = "";
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "POST";
            request.ServicePoint.Expect100Continue = false;
            //request.ContentType = "application/x-www-form-urlencoded;charset=utf8";
            foreach (var s in headers)
            {
                if (s.Key == "Accept")
                {
                    request.Accept = s.Value;
                }
                else if (s.Key == "Connection")
                {
                    SetHeaderValue(request.Headers, s.Key, s.Value);
                }
                else if (s.Key == "Host")
                {
                    SetHeaderValue(request.Headers, s.Key, s.Value);
                }
                else if (s.Key == "User-Agent")
                { request.UserAgent = s.Value; }

                else if (s.Key == "Content-Type")
                { request.ContentType = s.Value; }
                else if (s.Key == "Referer")
                { request.Referer = s.Value; }
                else
                {
                    request.Headers.Add(s.Key + ": " + s.Value);
                }
            }
            byte[] data = Encoding.UTF8.GetBytes(parms);
            request.ContentLength = data.Length;
            try
            {
      
                using (Stream stream = request.GetRequestStream())
                {

                    stream.Write(data, 0, data.Length);
                    stream.Close();
                }
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                    ret = reader.ReadToEnd();
                }
                return ret;
            }
            catch
            {

            }
            return ret;
        }
        public static string HttpPost(string url, string parms)
        {
            string ret = "";
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url );
            request.Method = "POST";
            using (Stream stream = request.GetRequestStream())
            {
                StreamWriter writer = new StreamWriter(stream, Encoding.UTF8);
                writer.Write(Encoding.UTF8.GetBytes(parms));
                writer.Close();
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                ret = reader.ReadToEnd();
            }
            return ret;
        }

      


       
    }
}
