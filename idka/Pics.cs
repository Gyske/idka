using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static idka.Program;
using static idka.Ex;
using static idka.Func;
using static idka.Form1;

namespace idka
{
    class Pics
    {
        public static async Task savu(string link, string ppl, string nam)
        {
            try
            {
                string np = path + ppl;
                /*if (Directory.Exists(np))
                {
                    DateTime newest = new DateTime(1999, 1, 1, 0, 1, 0);
                    var files = Directory.GetFiles(np);
                    foreach(var itm in files)
                    {
                        if (newest.CompareTo(File.GetCreationTime(itm)) >= 1) { newest = File.GetCreationTime(itm); } 
                    }
                    
                }
                */




                HttpWebRequest lxRequest = (HttpWebRequest)WebRequest.Create(link);
                string[] arr = link.Split('/');
                //TODO : name auf hashwert umwandeln
                //string name = arr[3] + arr[4] + arr[5] + arr[6] + arr[7] + arr[8];
                //if (picExists(name, ppl)) { return; }
                String lsResponse = string.Empty;
                using (HttpWebResponse lxResponse = (HttpWebResponse)lxRequest.GetResponse())
                {
                    using (BinaryReader reader = new BinaryReader(lxResponse.GetResponseStream()))
                    {
                        Byte[] lnByte = reader.ReadBytes(1 * 1024 * 1024 * 10);
                        string name = hash(lnByte);
                        if (picExists(name, ppl)) return;
                        
                        //if (name.Equals(temp)) { return; }
                        //temp = name;
                        Directory.CreateDirectory(np);
                        using (FileStream lxFS = new FileStream(np + "\\" + name , FileMode.Create))
                        {

                            lxFS.Write(lnByte, 0, lnByte.Length);
                            //appendText(nam + "-> Wrote:" + np + "\\" + name);
                            //Console.WriteLine(nam + "-> Wrote:" + np + "\\" + name);
                        }
                    }
                }
            }
            catch (Exception e) { ex(e); }
        }
        public static bool picExists(string name, string folder)
        {

            if (!Directory.Exists(path + folder))
            {
                Directory.CreateDirectory(path + folder);
                return false;
            }
            //TODO: global array? e.g. 200pics von einer person = 200x den vergleich
            string[] files = null;
            try
            {
                //asdkjn
                files = Directory.GetFiles(path + folder);
            }catch (Exception e) { ex(e);return false; }


            foreach (var itm in files)
            {
                if (itm == name) return true;
                //if (itm + ".jpg" == name) return true;
            }

            return false;
        }

        public static void newestPic()
        {
            //TODO: newest=hidden dat im ordner für last run?
        }
    }
}
