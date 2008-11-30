using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Collections;
using System.IO;
using System.Globalization;
using ICSharpCode.SharpZipLib.GZip;
using System.Security.Cryptography;
namespace UniUploader
{
    internal sealed class http
    {
        public delegate void httpInfoDelegate(String s);
        public event httpInfoDelegate onInformationMessage;
        private void Info(String s)
        {
            if (!object.Equals(null, onInformationMessage))
            {
                onInformationMessage(s);
            }
        }
        private static DateTime DateCompiled()
        {
            System.Version v = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            DateTime d = new DateTime(
                v.Build * TimeSpan.TicksPerDay +
                v.Revision * TimeSpan.TicksPerSecond * 2
                ).AddYears(1999).AddHours(1);
            return d;
        }
        private static String AssemblyVersion
        {
            get
            {
                return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }
        //private string UserAgent
        //{
        //    get
        //    {
        //        string ver = AssemblyVersion;
        //        string[] ver_split = ver.Split('.');
        //        //private string local = "en/us";
        //        //return "WebParser " + ver_split[0] + ".0 (AOD " + ver + "; " + local + ")";
        //        return "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.9.0.1) Gecko/2008070208 Firefox/3.0.1";
        //    }
        //}
        public string UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.9.0.1) Gecko/2008070208 Firefox/3.0.1";
        public CookieContainer CookieJar = new CookieContainer();
        private Hashtable getQueryStringParams(string url)
        {
            int queryStringStart = url.IndexOf("?");
            if (queryStringStart == -1) return new Hashtable();
            string queryString = url.Substring(queryStringStart + 1);
            Hashtable h = new Hashtable();
            string[] pairs = queryString.Split('&');
            foreach (string pair in pairs)
            {
                try
                {
                    string[] splitPair = pair.Split('=');
                    if (splitPair[0] == String.Empty || object.Equals(null, splitPair[0])) continue;
                    h[splitPair[0]] = splitPair[1];
                }
                catch
                {
                }
            }
            return h;
        }
        private StreamWriter addVar(StreamWriter sw, string boundary, string varName, string varValue)
        {
            string newLine = "\r\n";
            sw.Write("--" + boundary + newLine);
            sw.Write("Content-Disposition: form-data; name=\"" + varName + "\"");
            sw.Write(newLine);
            sw.Write(newLine);
            sw.Flush();
            sw.Write(varValue);
            sw.Write(newLine);
            sw.Flush();
            return sw;
        }
        private ArrayList normalizePostData(ArrayList Data)
        {
            ArrayList AllParams = new ArrayList();
            Type t_hashTable = typeof(System.Collections.Hashtable);
            Type t_stringArray = typeof(string[]);
            foreach (object o in Data)
            {
                Type t = o.GetType();
                if (t == t_hashTable)
                {
                    Hashtable h = (Hashtable)o;
                    foreach (DictionaryEntry de in h)
                    {
                        AllParams.Add(new string[2] { (string)de.Key, (string)de.Value });
                    }
                }
                if (t == t_stringArray)
                {
                    string[] s = (string[])o;
                    AllParams.Add(new string[2] { s[0], s[1] });
                }
            }
            return AllParams;
        }
        private MemoryStream getPostData(Hashtable files, ArrayList _allParams, string url, string boundary, FILE_COMPRESSION_METHODS CompressionMethod)
        {
            ArrayList allParams = normalizePostData(_allParams);
            MemoryStream postData = new MemoryStream();
            string newLine = "\r\n";
            StreamWriter sw = new StreamWriter(postData);
            if (!object.Equals(null, allParams))
            {
                foreach (string[] param in allParams)
                {
                    string fieldName = param[0];
                    string fieldValue = param[1];
                    if (fieldName == String.Empty || object.Equals(null, fieldName)) continue;
                    sw = addVar(sw, boundary, fieldName, fieldValue);
                }
            }
            Hashtable queryStringParams = getQueryStringParams(url);
            IDictionaryEnumerator en = queryStringParams.GetEnumerator();
            while (en.MoveNext())
            {
                sw = addVar(sw, boundary, en.Key.ToString(), en.Value.ToString());
            }
            if (!object.Equals(null, files))
            {
                foreach (DictionaryEntry de in files)
                {
                    string fieldName = (string)de.Key;
                    string fileName = (string)de.Value;
                    byte[] fileContents = Windows.FileToByteArray(fileName);

                    if (fileContents == null) { Info("Upload: couldnt read \"" + fileName + "\""); return null; } //couldnt read the file
                    int uSize = fileContents.Length;
                    string FileNameOnlyName = Path.GetFileName(fileName);
                    switch (CompressionMethod)
                    {
                        case FILE_COMPRESSION_METHODS.GZIP:
                            MemoryStream ContentsGzippedStream = new MemoryStream();	//create the memory stream to hold the compressed file
                            Stream s = new GZipOutputStream(ContentsGzippedStream);		//create the gzip filter
                            s.Write(fileContents, 0, fileContents.Length);				//write the file contents to the filter
                            s.Flush();													//make sure everythings ready
                            s.Close();													//close and write the compressed data to the memory stream
                            byte[] ContentsGzippedA = ContentsGzippedStream.ToArray();	//make new byte array to hold the compressed data
                            decimal ratio = Math.Round(decimal.Subtract(100, decimal.Multiply(100, (decimal.Divide(ContentsGzippedA.Length, (fileContents.Length + 1))))));	// get the compression ratio
                            if (ratio < 0) { ratio = 0; } //in case Contents.lengh = 0
                            double cLen = ContentsGzippedA.Length;
                            double compressedSize = Math.Round((cLen / 1000), 2);							//get the compressed size
                            fileContents = ContentsGzippedA;								//write the byte array to the final array
                            Info(FileNameOnlyName + " - " + Convert.ToString(ratio) + "% Compression : " + compressedSize.ToString("F") + " KB");
                            FileNameOnlyName += ".gz";				//change the filename to reflect the gzip compression
                            sw = addVar(sw, boundary, "usize_" + fieldName, uSize.ToString());
                            //write the file (compressed) to the stream
                            sw.Write("--" + boundary + newLine);
                            sw.Write("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"{2}", fieldName, Path.GetFileName(FileNameOnlyName), newLine);
                            sw.Write("Content-Type: application/octet-stream" + newLine + newLine);
                            sw.Flush();
                            postData.Write(ContentsGzippedA, 0, ContentsGzippedA.Length);
                            sw.Write(newLine);
                            break;
                        default:
                            sw = addVar(sw, boundary, "md5_" + fieldName, MD5SUM(fileContents));
                            //write the file to the stream
                            sw.Write("--" + boundary + newLine);
                            sw.Write("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"{2}", fieldName, Path.GetFileName(fileName), newLine);
                            sw.Write("Content-Type: application/octet-stream" + newLine + newLine);
                            sw.Flush();
                            postData.Write(fileContents, 0, fileContents.Length);
                            sw.Write(newLine);
                            break;
                    }
                }
            }
            DateTime _datetime = DateTime.Now;
            string dateTimeNow = _datetime.ToString("s", DateTimeFormatInfo.InvariantInfo) + "Z";
            string dateTimeNowUTC = _datetime.ToUniversalTime().ToString("s", DateTimeFormatInfo.InvariantInfo) + "Z";
            sw = addVar(sw, boundary, "clientTime", dateTimeNow);
            sw = addVar(sw, boundary, "clientTimeUTC", dateTimeNowUTC);
            sw.Write("--{0}--{1}", boundary, newLine);
            sw.Flush();
            //byte[] b = postData.ToArray();
            //string s = System.Text.Encoding.UTF8.GetString(b);
            return postData;
        }
        private string MD5SUM(byte[] FileOrText) //Output: String<-> Input: Byte[] //
        {
            try
            {
                return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(FileOrText)).Replace("-", "").ToLower();
            }
            catch
            {
                //DebugLine("MD5SUM: "+e.Message);
                return null; //the addon possibly does not exist
            }
        }
        public enum ENCODING_TYPES
        {
            APP_X_WWW_FORM_URLENCODED,
            MULTI_FORM_DATA
        }
        public enum REQUEST_METHODS
        {
            GET,
            POST
        }
        public enum FILE_COMPRESSION_METHODS
        {
            NONE,
            GZIP
        }

        public CredentialCache CredentialCache;

        public int Timeout = 43200000;

        public bool post(ref Response Response, string Url)
        {
            return post(ref Response, Url, null, null, this.UserAgent, ENCODING_TYPES.MULTI_FORM_DATA, REQUEST_METHODS.POST, this.Timeout, this.CookieJar, this.CredentialCache, FILE_COMPRESSION_METHODS.NONE, "");
        }
        public bool post(ref Response Response, string Url, ArrayList Parameters)
        {
            return post(ref Response, Url, Parameters, null, this.UserAgent, ENCODING_TYPES.MULTI_FORM_DATA, REQUEST_METHODS.POST, this.Timeout, this.CookieJar, this.CredentialCache, FILE_COMPRESSION_METHODS.NONE, "");
        }
        public bool post(ref Response Response, string Url, ArrayList Parameters, Hashtable Files)
        {
            return post(ref Response, Url, Parameters, Files, this.UserAgent, ENCODING_TYPES.MULTI_FORM_DATA, REQUEST_METHODS.POST, this.Timeout, this.CookieJar, this.CredentialCache, FILE_COMPRESSION_METHODS.NONE, "");
        }
        public bool post(ref Response Response, string Url, ArrayList Parameters, Hashtable Files, FILE_COMPRESSION_METHODS FileCompressionMethods)
        {
            return post(ref Response, Url, Parameters, Files, this.UserAgent, ENCODING_TYPES.MULTI_FORM_DATA, REQUEST_METHODS.POST, this.Timeout, this.CookieJar, this.CredentialCache, FileCompressionMethods, "");
        }
        public bool post(ref Response Response, string Url, ArrayList Parameters, Hashtable Files, FILE_COMPRESSION_METHODS FileCompressionMethods, ENCODING_TYPES EncType, REQUEST_METHODS ReqMethod)
        {
            return post(ref Response, Url, Parameters, Files, this.UserAgent, EncType, ReqMethod, this.Timeout, this.CookieJar, this.CredentialCache, FileCompressionMethods, "");
        }
        public bool post(ref Response Response, string Url, ArrayList Parameters, Hashtable Files, FILE_COMPRESSION_METHODS FileCompressionMethods, ENCODING_TYPES EncType, REQUEST_METHODS ReqMethod, int Timeout)
        {
            return post(ref Response, Url, Parameters, Files, this.UserAgent, EncType, ReqMethod, Timeout, this.CookieJar, this.CredentialCache, FileCompressionMethods, "");
        }
        public bool post(ref Response Response, string Url, ArrayList Parameters, Hashtable Files, FILE_COMPRESSION_METHODS FileCompressionMethods, ENCODING_TYPES EncType, REQUEST_METHODS ReqMethod, int Timeout, string UserAgent)
        {
            return post(ref Response, Url, Parameters, Files, UserAgent, EncType, ReqMethod, Timeout, this.CookieJar, this.CredentialCache, FileCompressionMethods, "");
        }
        public bool post(ref Response Response, string Url, ArrayList Parameters, Hashtable Files, FILE_COMPRESSION_METHODS FileCompressionMethods, ENCODING_TYPES EncType, REQUEST_METHODS ReqMethod, int Timeout, string UserAgent, string Referer)
        {
            return post(ref Response, Url, Parameters, Files, UserAgent, EncType, ReqMethod, Timeout, this.CookieJar, this.CredentialCache, FileCompressionMethods, Referer);
        }
        public bool post(ref Response Response, string Url, ArrayList Parameters, Hashtable Files, FILE_COMPRESSION_METHODS FileCompressionMethods, ENCODING_TYPES EncType, REQUEST_METHODS ReqMethod, int Timeout, string UserAgent, string Referer, CookieContainer Cookies)
        {
            return post(ref Response, Url, Parameters, Files, UserAgent, EncType, ReqMethod, Timeout, Cookies, this.CredentialCache, FileCompressionMethods, Referer);
        }
        public bool post(ref Response Response, string Url, ArrayList Parameters, Hashtable Files, FILE_COMPRESSION_METHODS FileCompressionMethods, ENCODING_TYPES EncType, REQUEST_METHODS ReqMethod, int Timeout, string UserAgent, string Referer, CookieContainer Cookies, CredentialCache CredentialCache)
        {
            return post(ref Response, Url, Parameters, Files, UserAgent, EncType, ReqMethod, Timeout, Cookies, CredentialCache, FileCompressionMethods, Referer);
        }
        private bool post(ref Response Response, string Url, ArrayList Parameters, Hashtable Files, string UserAgent, ENCODING_TYPES EncType, REQUEST_METHODS ReqMethod, int Timeout, CookieContainer Cookies, CredentialCache CredentialCache, FILE_COMPRESSION_METHODS FileCompressionMethods, string Referer)
        {

            if (!object.Equals(null, Url)) Info("URL: " + Url);
            if (!object.Equals(null, Files)) Info("Files: " + Files.Count.ToString());
            if (!object.Equals(null, EncType)) Info("Encode Type: " + EncType.ToString());
            if (!object.Equals(null, ReqMethod)) Info("Request Method: " + ReqMethod.ToString());
            if (!object.Equals(null, Referer) && !object.Equals(String.Empty, Referer)) Info("Referer: " + Referer);
            //Info(req.Headers.ToString());
            //Info(s2);

            System.Net.ServicePointManager.Expect100Continue = false;
            //string newLine = "\r\n";

            string boundary = Guid.NewGuid().ToString().Replace("-", "");
            MemoryStream postData = new MemoryStream();
            string urlEncoded = "";

            switch (EncType)
            {
                case ENCODING_TYPES.APP_X_WWW_FORM_URLENCODED:
                    urlEncoded = Url + "?" + getPostDataUrlEncoded(Parameters, Url, boundary);
                    break;
                case ENCODING_TYPES.MULTI_FORM_DATA:
                    postData = getPostData(Files, Parameters, Url, boundary, FileCompressionMethods);
                    break;
            }


            if (EncType == ENCODING_TYPES.APP_X_WWW_FORM_URLENCODED)
            {
                Url = urlEncoded;
            }

            HttpWebRequest req = (new MyWebRequest().GetWebRequest2(new System.Uri(Url)) as HttpWebRequest);
            switch (EncType)
            {
                case ENCODING_TYPES.APP_X_WWW_FORM_URLENCODED:
                    req.ContentType = "application/x-www-form-urlencoded;";
                    break;
                case ENCODING_TYPES.MULTI_FORM_DATA:
                    req.ContentType = "multipart/form-data; boundary=" + boundary;
                    break;
            }
            switch (ReqMethod)
            {
                case REQUEST_METHODS.GET:
                    req.Method = "GET";
                    break;
                case REQUEST_METHODS.POST:
                    req.Method = "POST";
                    break;
            }
            if (!object.Equals(null, Referer))
            {
                req.Referer = Referer;
            }
            req.UnsafeAuthenticatedConnectionSharing = true;
            req.CookieContainer = Cookies;

            if (!object.Equals(null, Cookies))
            {
                req.CookieContainer = Cookies;
            }
            if (!object.Equals(null, CredentialCache))
            {
                req.Credentials = CredentialCache;
            }
            req.UserAgent = UserAgent;
            req.AllowWriteStreamBuffering = false;
            req.Accept = "application/x-shockwave-flash,text/xml,application/xml,application/xhtml+xml,text/html;q=0.9,text/plain;q=0.8,image/png,*/*;q=0.5";
            req.ContentLength = postData.Length;
            req.Timeout = Timeout;
            if (ReqMethod == REQUEST_METHODS.POST)
            {
                Stream oRequestStream = req.GetRequestStream();
                postData.Seek(0, SeekOrigin.Begin);

                int bytesSent = 0;
                int totalBytesSent = 0;
                int totalOutBytes = (int)postData.Length;
                byte[] buffer = new Byte[checked((uint)Math.Min(4096, (int)postData.Length))];
                while ((bytesSent = postData.Read(buffer, 0, buffer.Length)) != 0)
                {
                    oRequestStream.Write(buffer, 0, bytesSent);
                    totalBytesSent += bytesSent;
                    fireSendProgressEvent(totalBytesSent, (int)postData.Length);
                }
                oRequestStream.Close();
            }
            Info("Request Sent.  ( " + postData.Length.ToString("N0") + " Bytes )");

            HttpWebResponse lHttpWebResponse;
            Stream lHttpWebResponseStream;
            byte[] byteBuffer = new byte[1024];
            int bytesRead;
            try
            {
                lHttpWebResponse = (HttpWebResponse)req.GetResponse();

                Response.CharacterSet = lHttpWebResponse.CharacterSet;
                Response.ContentEncoding = lHttpWebResponse.ContentEncoding;
                Response.ContentType = lHttpWebResponse.ContentType;
                Response.Cookies = lHttpWebResponse.Cookies;
                Response.Headers = lHttpWebResponse.Headers;
                Response.IsFromCache = lHttpWebResponse.IsFromCache;
                Response.IsMutuallyAuthenticated = lHttpWebResponse.IsMutuallyAuthenticated;
                Response.LastModified = lHttpWebResponse.LastModified;
                Response.Method = lHttpWebResponse.Method;
                Response.ProtocolVersion = lHttpWebResponse.ProtocolVersion;
                Response.ResponseUri = lHttpWebResponse.ResponseUri;
                Response.Server = lHttpWebResponse.Server;
                Response.StatusCode = lHttpWebResponse.StatusCode;
                Response.StatusDescription = lHttpWebResponse.StatusDescription;

                lHttpWebResponseStream = req.GetResponse().GetResponseStream();
                Int32 ContentLength = Convert.ToInt32(lHttpWebResponse.ContentLength);
                int progress = 0;
                Response.Content = new MemoryStream();
                do
                {
                    bytesRead = lHttpWebResponseStream.Read(byteBuffer, 0, 1024);
                    Response.Content.Write(byteBuffer, 0, bytesRead);
                    progress += bytesRead;

                    if (progress <= ContentLength)
                    {
                        fireReceiveProgressEvent(progress, ContentLength);
                    }
                    else
                    {
                        fireReceiveProgressEvent(ContentLength, ContentLength);
                    }
                } while (bytesRead > 0);
                lHttpWebResponseStream.Close();
                postData.Close();
                lHttpWebResponse.Close();
                Info("Response Received.  ( " + ContentLength.ToString("N0") + " Bytes )");
                return true;
            }
            catch (Exception e)
            {
                Info(e.Message);
                return false;
            }

        }
        public class Response
        {
            public MemoryStream Content;
            public string CharacterSet;
            public string ContentType;
            public string ContentEncoding;
            public CookieCollection Cookies;
            public long ContentLength
            {
                get
                {
                    if (!object.Equals(null, Content))
                        return Content.Length;
                    else return -1;
                }
            }
            public WebHeaderCollection Headers;
            public bool IsFromCache;
            public bool IsMutuallyAuthenticated;
            public DateTime LastModified;
            public string Method;
            public Version ProtocolVersion;
            public Uri ResponseUri;
            public string Server;
            public HttpStatusCode StatusCode;
            public string StatusDescription;
            public override string ToString()
            {
                if (!object.Equals(null, Content))
                    return System.Text.Encoding.UTF8.GetString(Content.ToArray());
                else return "";
            }
        }
        private string getPostDataUrlEncoded(ArrayList allParams, string url, string boundary)
        {
            string postData = "";
            bool first = true;
            if (!object.Equals(null, allParams))
            {
                foreach (string[] param in allParams)
                {

                    string fieldName = param[0];
                    if (fieldName == String.Empty) continue;
                    if (fieldName == String.Empty || object.Equals(null, fieldName)) continue;
                    string fieldValue = param[1];
                    if (first)
                    {
                        first = false;
                    }
                    else
                    {
                        postData += "&";
                    }
                    postData += fieldName + "=" + fieldValue;
                }
            }
            Hashtable queryStringParams = getQueryStringParams(url);
            IDictionaryEnumerator en = queryStringParams.GetEnumerator();
            while (en.MoveNext())
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    postData += "&";
                }
                postData += en.Key + "=" + en.Value;
            }
            DateTime _datetime = DateTime.Now;
            string dateTimeNow = _datetime.ToString("s", DateTimeFormatInfo.InvariantInfo) + "Z";
            string dateTimeNowUTC = _datetime.ToUniversalTime().ToString("s", DateTimeFormatInfo.InvariantInfo) + "Z";
            if (first)
            {
                first = false;
            }
            else
            {
                postData += "&";
            }
            postData += "clientTime=" + dateTimeNow;
            if (first)
            {
                first = false;
            }
            else
            {
                postData += "&";
            }
            postData += "clientTimeUTC=" + dateTimeNowUTC;
            return postData;
        }

        public delegate void ReceiveProgressDelegate(int CurrentPosition, int TotalSize);
        public event ReceiveProgressDelegate onReceiveProgress;
        private void fireReceiveProgressEvent(int CurrentPosition, int TotalSize)
        {
            if (!object.Equals(null, onReceiveProgress))
            {
                onReceiveProgress(CurrentPosition, TotalSize);
            }
        }

        public delegate void SendProgressDelegate(int CurrentPosition, int TotalSize);
        public event SendProgressDelegate onSendProgress;
        private void fireSendProgressEvent(int CurrentPosition, int TotalSize)
        {
            if (!object.Equals(null, onSendProgress))
            {
                onSendProgress(CurrentPosition, TotalSize);
            }
        }
    }
    internal class AcceptAllCertificatePolicy : ICertificatePolicy
    {
        public AcceptAllCertificatePolicy()
        {
        }
        public bool CheckValidationResult(ServicePoint sPoint,
           System.Security.Cryptography.X509Certificates.X509Certificate cert, System.Net.WebRequest wRequest, int certProb)
        {
            // Always accept
            return true;
        }
    }
    internal class MyWebRequest : System.Net.WebClient
    {
        protected override System.Net.WebRequest GetWebRequest(Uri uri)
        {
            HttpWebRequest webRequest = (HttpWebRequest)base.GetWebRequest(uri);
            webRequest.KeepAlive = false;
            return webRequest;
        }
        public System.Net.WebRequest GetWebRequest2(Uri uri)
        {
            return GetWebRequest(uri);
        }
    }
}