using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static idka.Dl;
using static idka.Pics;
using static idka.Ex;
using System.Security.Cryptography;
using System.IO;
using System.Net;
using HtmlAgilityPack;
using System.Drawing;

namespace idka
{
    class Func
    {
        public static void debug()
        {
            try
            {
                /*string url = "https://www.instagram.com/p/BlWcY5rgYO-/?taken-by=id0lls";
                var web = new HtmlWeb();
                var doc = web.Load(url);
                Console.WriteLine(doc.Text);
                doc.Save("test.html");
                */
                //var dt = doc.DocumentNode.SelectSingleNode("//*[@id=\"react-root\"]/section/main/div/div/article/div[2]/div[2]/a/time").Attributes["datetime"].Value;
                //Console.WriteLine(dt);
                Image img = Image.FromFile("H://uwu4.jpg");
               
                 
               

                /*var weq = hash("H://uwu3.jpg");
                foreach(var elem in weq)
                {
                    Console.WriteLine(elem);
                }
                Console.WriteLine("_______________________");
                var ee = hash("H://uwu2.jpg");
                foreach (var elem in ee)
                {
                    Console.WriteLine(elem);
                }*/
                /*
                WebRequest request = WebRequest.Create(url);
                // If required by the server, set the credentials.  
                request.Credentials = CredentialCache.DefaultCredentials;
                // Get the response.  
                WebResponse response = request.GetResponse();
                // Display the status.  
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                // Get the stream containing content returned by the server.  
                Stream dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.  
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.  
                string responseFromServer = reader.ReadToEnd();
                // Display the content.  
                Console.WriteLine(responseFromServer);
                // Clean up the streams and the response.  
                reader.Close();
                response.Close();
                HtmlDocument doc = new HTMLDocument();
                //string[] arr = deb.Split('/');
                //Console.Write(arr.Last());
                //driver.Navigate().GoToUrl(uf);
                //leech(new List<string> { "scarlettsirene" });
                */
                Console.Read();
                //driver.Navigate().GoToUrl(deb);
                //cull(deb, "debug", 1);
            }catch(Exception e) { ex(e); }
        }
        public static string hash(byte[] bt)
        {
            //var ret = imageToByteArray(img);

            var md = MD5.Create();
            var hash = md.ComputeHash(bt);
            return byteToName(hash);
        }


        public static string byteToName(byte[] arr)
        {
            string str = "";
            foreach(var elem in arr)
            {
                str += elem.ToString();
            }

            return (str+".jpg");
        }


        public static byte[] imageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            
            imageIn.Save(ms, imageIn.RawFormat);
            return ms.ToArray();
        }


        /*public static byte[] hash(byte[] byt)
        {

            using (var md5 = MD5.Create())
            {
                
                 return md5.ComputeHash(byt);
               
            }

        }*/

        public static string checkMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    return Encoding.Default.GetString(md5.ComputeHash(stream));
                }
            }
        }
        public static async Task cull(string str, string ppl, string name)
        {
            await savu(str, ppl,name);//, a);
            
        }
        public static string[] cut(string[] arr, int cut)
        {
            try { 
                for (int i = 0; i < cut; i++)
                {
                    var list = new List<string>(arr);
                    list.Remove(arr.Last());
                    arr = list.ToArray();
                }
                return arr;
            }catch (Exception e) { ex(e); return new String[] { }; }
        }
    }
}
