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
        public bool sending = false;
        public bool receiving = false;
        public int totalBytesSent = 0;
        public int bytesReceived = 0;
        private int totalBytesSent2 = 0;
        private int bytesReceived2 = 0;
        public int totalOutBytes = 0;
        public int totalInBytes = 0;
        public delegate void httpInfoDelegate(String s);
        public event httpInfoDelegate onInformationMessage;
        private void Info(String s)
        {
            if (!object.Equals(null, onInformationMessage))
            {
                onInformationMessage(s);
            }
        }
        public delegate void OnInfoClearDelegate();
        public event OnInfoClearDelegate onInfoClear;
        private void InfoClear()
        {
            if (!object.Equals(null, onInfoClear))
            {
                onInfoClear();
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
        private CookieContainer cookieJar = new CookieContainer();
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
        private MemoryStream getPostData(Hashtable files, ArrayList allParams, string url, string boundary, COMPRESSION_METHODS CompressionMethod)
        {

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
                        case COMPRESSION_METHODS.GZIP:
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
        string MD5SUM(byte[] FileOrText) //Output: String<-> Input: Byte[] //
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
        public enum COMPRESSION_METHODS
        {
            NONE,
            GZIP
        }
        public string post(Hashtable files, ArrayList allParams, string url, ENCODING_TYPES EncType, REQUEST_METHODS ReqMethod, string Referer, COMPRESSION_METHODS CompressionMethods, CookieContainer cookies, CredentialCache credentials)
        {
            byte[] b = null;
            return post(files, allParams, url, EncType, ReqMethod, Referer, CompressionMethods, cookieJar, credentials, ref b);
        }
        public string post(Hashtable files, ArrayList allParams, string url, ENCODING_TYPES EncType, REQUEST_METHODS ReqMethod, string Referer, COMPRESSION_METHODS CompressionMethods, CookieContainer cookies, CredentialCache credentials, ref byte[] b)
        {

            InfoClear();
            if (!object.Equals(null, url)) Info("URL: " + url);
            if (!object.Equals(null, files)) Info("Files: " + files.Count.ToString());
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
                    urlEncoded = url + "?" + getPostDataUrlEncoded(allParams, url, boundary);
                    break;
                case ENCODING_TYPES.MULTI_FORM_DATA:
                    postData = getPostData(files, allParams, url, boundary, CompressionMethods);
                    break;
            }


            if (EncType == ENCODING_TYPES.APP_X_WWW_FORM_URLENCODED)
            {
                url = urlEncoded;
            }

            HttpWebRequest req = (new MyWebRequest().GetWebRequest2(new System.Uri(url)) as HttpWebRequest);
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
            req.CookieContainer = cookieJar;

            if (!object.Equals(null, cookies))
            {
                req.CookieContainer = cookies;
            }
            if (!object.Equals(null, credentials))
            {
                req.Credentials = credentials;
            }
            req.UserAgent = UserAgent;
            req.AllowWriteStreamBuffering = false;
            req.Accept = "application/x-shockwave-flash,text/xml,application/xml,application/xhtml+xml,text/html;q=0.9,text/plain;q=0.8,image/png,*/*;q=0.5";
            req.ContentLength = postData.Length;
            req.Timeout = 43200000; //12 Hours (big flac files...)
            if (ReqMethod == REQUEST_METHODS.POST)
            {
                Stream oRequestStream = req.GetRequestStream();
                postData.Seek(0, SeekOrigin.Begin);

                int bytesSent = 0;
                totalBytesSent = 0;
                totalOutBytes = (int)postData.Length;
                sending = true;
                startStatusUpdater();
                byte[] buffer = new Byte[checked((uint)Math.Min(4096, (int)postData.Length))];
                while ((bytesSent = postData.Read(buffer, 0, buffer.Length)) != 0)
                {
                    oRequestStream.Write(buffer, 0, bytesSent);
                    totalBytesSent += bytesSent;
                }
                oRequestStream.Close();
            }
            Info("Request Sent");
            receiving = true;
            sending = false;
            WebResponse oWResponse = null;
            try
            {
                oWResponse = req.GetResponse();
            }
            catch (Exception e)
            {
                Info(e.Message);
                return "";
            }

            Stream s = oWResponse.GetResponseStream();
            totalInBytes = (int)oWResponse.ContentLength;
            bytesReceived = 0;
            //StreamReader sr = new StreamReader(s);
            //String sReturnString = "";
            //while (!sr.EndOfStream)
            //{
            //    char[] c = { '\0' };
            //    sr.Read(c, 0, 1);
            //    sReturnString += c[0];
            //    bytesReceived++;
            //}
            //sr.Close();
            //s.Close();
            //System.Text.StringBuilder sb = new System.Text.StringBuilder();
            //BinaryReader br = new BinaryReader(s);
            //while (true)
            //{
            //    try
            //    {
            //        sb.Append(br.ReadChar());
            //        bytesReceived++;
            //    }
            //    catch (Exception e)
            //    {
            //        //Info(e.ToString());
            //        break;
            //    }
            //}
            //br.Close();



            HttpWebResponse lHttpWebResponse;
            // Declare a variable of type Stream named lHttpWebResponseStream.
            Stream lHttpWebResponseStream;
            // Declare a variable of type FileStream named lFileStream.
            // Use a FileStream constructor to create a new FileStream object.
            // Assign the address (reference) of the new object
            // to the lFileStream variable.
            //FileStream lFileStream = new FileStream(path_local, FileMode.Create);
            // Declare a variable of type Byte Array named byteBuffer.
            byte[] byteBuffer = new byte[999];
            // Declare a variable of type Integer named bytesRead.
            int bytesRead;
            try
            {
                // Instantiate the HttpWebRequest object.
                lHttpWebRequest = (HttpWebRequest)WebRequest.Create(path_download);
                // Instantiate the HttpWebRespose object.
                lHttpWebResponse = (HttpWebResponse)req.GetResponse();
                // Instantiate the ResponseStream object.
                lHttpWebResponseStream = req.GetResponse().GetResponseStream();
                // Set the ProgressBars Maximum property equal to the length of the file
                // to be downloaded.
                Int32 ContentLength = Convert.ToInt32(lHttpWebResponse.ContentLength);
                int progress = 0;
                do
                {
                    // Read up to 1000 bytes into the bytesRead array.
                    bytesRead = lHttpWebResponseStream.Read(byteBuffer, 0, 999);
                    // Write the bytes read to the file stream.
                    lFileStream.Write(byteBuffer, 0, bytesRead);
                    progress += bytesRead;

                    if (progress <= ContentLength)
                    {
                        http_onReceiveProgress(progress, ContentLength);
                    }
                    else
                    {
                        http_onReceiveProgress(ContentLength, ContentLength);
                    }
                } while (bytesRead > 0);
                // Close the file and web response streams.
                lHttpWebResponseStream.Close();
                // Set result to True - download was successful.
                result = true;


                postData.Close();
                receiving = false;
            }
            catch (Exception e)
            {
                Info(e.Message);
            }

            //Info("Response Received: " + sReturnString.Length.ToString() + " Char.");
            //return sReturnString;
            Info("Response Received: " + sb.Length.ToString() + " Char.");
            return sb.ToString();

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
        private void startStatusUpdater()
        {
            Thread t = new Thread(new ThreadStart(StatusUpdater));
            t.Start();
        }

        public void StatusUpdater()
        {
            while (sending || receiving)
            {
                Thread.Sleep(500);
                if (sending)
                {
                    if (totalBytesSent != totalBytesSent2)
                    {
                        totalBytesSent2 = totalBytesSent;
                        fireSendProgressEvent(totalBytesSent, totalOutBytes);
                    }
                }
                if (receiving)
                {
                    if (bytesReceived != bytesReceived2)
                    {
                        bytesReceived2 = bytesReceived;
                        fireReceiveProgressEvent(bytesReceived, totalInBytes);
                    }
                }
            }
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