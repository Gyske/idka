using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
//using System.Drawing;
//using System.Drawing;
//using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static idka.Dl;
using static idka.Driv;
using static idka.Ex;
using static idka.Func;
using static idka.GuiInteracts;
using static idka.Pics;

/* DLN :
 * Methods : 
 *      1. Screenshot and cut
 *      2. send keys
 *      3. online shit
 *      */


namespace idka
{
    class Program
    {
        public const string acc = "", pw = "", prof = "https://www.instagram.com/birnhausen", path = "H:\\instar\\";
        public static Form1 guiForm = null;
        public static IWebDriver driver = null;
        public static DateTime start = DateTime.MinValue, end = DateTime.MinValue;
        public static bool _state;
        public static string temp = null;
        static string uf= "https://www.instagram.com/hirikihime/";
        static string deb = "https://scontent-frx5-1.cdninstagram.com/vp/d724474692085edd4411019903893f9b/5BA31C48/t51.2885-15/e35/33567726_394713021043185_5772670233210781696_n.jpg";


        public static bool state
        {
            get { return _state; }
            set
            {
                
                _state = value;
                itsSoBad();
            }
        }
        static void Main(string[] args)
        {

            /*FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();
            service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\Firefox.exe";
            
            driver = new FirefoxDriver(service);
            */
            //debug();
            driver = new ChromeDriver();
            login();
            Thread.Sleep(300);
            driver.Navigate().GoToUrl(prof);
            fknDis();
            
            //Console.Read();
        }
    

        
      
      


   


        
     


    }
}

