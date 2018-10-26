using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.IO;
using OpenQA.Selenium.Chrome;
using System.Threading.Tasks;
using System.Windows.Forms;
using static idka.Func;
using static idka.Program;
using static idka.Driv;
using static idka.Ex;
using static idka.Form1;
using static idka.GuiInteracts;


namespace idka
{
    class Dl
    {
        static List<string> p1, p2, p3, p4, p5,lss = new List<string>();

        public static void dd(List<string> lst,int start,int count)
        {
            for (int f = start; f <=(start+count); f++)
            {
                lst.Add(lss.ElementAt(f));
            }

            //return lst;
        }

        public static void leech(List<string> list)
        {
            //TODO: umschreiben für mehrere tabs


            lss = list;
            int count = list.Count / 5;
            Console.WriteLine(count);
            dd(p1=new List<string>(), 0, count-1);
            dd(p2 = new List<string>(), count, count - 1);
            dd(p3 = new List<string>(), count * 2, count - 1);
            dd(p4 = new List<string>(), count * 3, count - 1);
            dd(p5 = new List<string>(), count * 4, count - 1);
            Console.WriteLine("P1:" + p1.Count + Environment.NewLine + "P2:" + p2.Count + Environment.NewLine + "P3:" + p3.Count + Environment.NewLine + "P4:" + p4.Count + Environment.NewLine + "P5:" + p5.Count);
            caller();
            int crFiles = filesInDir(path);
            
            Console.WriteLine("Start:" + start + Environment.NewLine + "End:" + DateTime.Now + Environment.NewLine + "Files Created:" + crFiles);





        }

        public static async void caller()
        {
            /*
            var driv = driver;
            bool ret1 = await Task.Run(() => idkanymore(p1, driv));
            driv = new ChromeDriver();
            bool ret2 = await Task.Run(() => idkanymore(p2, driv));
            driv = new ChromeDriver();
            bool ret3 = await Task.Run(() => idkanymore(p3, driv));
            driv = new ChromeDriver();
            bool ret4 = await Task.Run(() => idkanymore(p4, driv));
            driv = new ChromeDriver();
            bool ret5 = await Task.Run(() => idkanymore(p5, driv));
            */
            idkanymore(p1, driver, "P1");
            idkanymore(p2, new ChromeDriver(), "P2");
            idkanymore(p3, new ChromeDriver(), "P3");
            idkanymore(p4, new ChromeDriver(), "P4");
            idkanymore(p5, new ChromeDriver(), "P5");
        }


        public static async Task idkanymore(List<string> list, IWebDriver driver, string name)
        {
            await Task.Run(() => questionmark(list, driver, name));
        }

        public static void questionmark(List<string> list,IWebDriver driver,string name)
        {

        
            foreach (var ppl in list)
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

                driver.Navigate().GoToUrl("https://www.instagram.com/" + ppl + "/");
                Console.WriteLine("meh:" + ppl);
                try
                {
                    //string divv = "*/body/span/section/main/div/article/div[1]/div";
                    string divv = "*/body/span/section/main/div/div/article/div[1]/div";
                    var asd = js.ExecuteScript("return document.evaluate('" + divv + "',document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null ).singleNodeValue.children.length");
                    int len = Convert.ToInt32(asd);
                    var div = driver.FindElements(By.XPath(divv));
                    //Console.WriteLine("Q");
                    int pics = len;
                    //Console.WriteLine("PIS:" + pics);
                    //int k = 0;
                    /*
                     * 
                     * DIE LÄNGE KLÖNNTE IRRELEVANT SEIN (?)
                     * 
                     * //werden immer 2 neue divs geladen
                     * 
                     * 
                     * */
                    for (int l = 0; l < 15; l++)
                    {
                        scrollPlox(divv,driver);
                        //Console.WriteLine("W");
                        for (int i = 1; i < pics; i++)
                        {
                            for (int j = 1; j < 4; j++)
                            {
                                var src = div.ElementAt(0).FindElement(By.XPath("./div[" + i + "]/div[" + j + "]/a/div/div[1]/img"));
                                //var a = div.ElementAt(0).FindElement(By.XPath("./div[" + i + "]/div[" + j + "]/a")).GetAttribute("href");
                                string pref = src.GetAttribute("src");
                                //Console.WriteLine("R");
                                cull(pref, ppl, name);
                                //k++;
                            }
                        }
                    }
                    

                }
                catch (Exception e) { ex(e); continue; }
                //return true;

            }
            Console.WriteLine(name+": DONE");
        }


        public static int filesInDir(string path)
        {
            int count = 0;
            var dirs = Directory.GetDirectories(path);
            //var files = Directory.GetFiles(path);

            foreach(var itm in dirs)
            {
                count+=itm.Length;
            }



            return count;
        }

    }
}
