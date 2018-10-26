using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static idka.Program;
using static idka.Ex;
using static idka.Dl;

namespace idka
{
    class Driv
    {


        public static void update(List<string> list)
        {

        }
        public static List<string> getAbos()
        {
            List<string> lst = new List<string>();
            try
            {
                var header = driver.FindElement(By.TagName("header"));
                var btn = header.FindElement(By.XPath("./section/ul/li[3]/a"));
                btn.Click();
                Thread.Sleep(200);
                var body = driver.FindElement(By.TagName("body"));
                var div = body.FindElement(By.XPath("./div[3]/div[1]/div[1]"));
                var ul = div.FindElement(By.XPath("./div[2]/ul"));
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                string eval = "*/body/div[3]/div[1]/div[1]/div[2]/ul/div";
                string str = "document.evaluate('" + eval + "/li[last()]',document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null ).singleNodeValue.scrollIntoView()";
                for (int i = 0; i < 50; i++) { js.ExecuteScript(str); Thread.Sleep(200); }

                var li = ul.FindElement(By.XPath("./div"));                 //div vor LI elem 
                var asd = js.ExecuteScript("return document.evaluate('" + eval + "',document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null ).singleNodeValue.children.length");
                int len = Convert.ToInt32(asd);
                //Console.WriteLine(len);
                Thread.Sleep(200);
                for (int i = 1; i < len; i++) //3=len
                {
                    var a = li.FindElement(By.XPath("./li[" + i + "]/div/div[1]/div/div[1]/a"));
                    string st = a.GetAttribute("href");
                    lst.Add(st);
                }
            }
            catch (Exception e) { ex(e); }
            return lst;
        }
        public static void OpenUrlInNewTab(string url, IWebDriver driver)
        {
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("window.open('" + url + "', '_blank');");
                driver.SwitchTo().Window(driver.WindowHandles.Last());
            }catch(Exception e) { ex(e); }
        }

        public static void scrollPlox(string div,IWebDriver driver)
        {
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                //string eval = "*/body/span/section/main/div/article/div[1]/div";
                string str = "document.evaluate('" + div + "/div[last()]',document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null ).singleNodeValue.scrollIntoView()";
                for (int i = 0; i < 3; i++) { js.ExecuteScript(str); Thread.Sleep(200); }
            }
            catch (Exception e) { ex(e); }

        }
        public static void scrollToEnd(IWebDriver driver)
        {
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                string eval = "*/body/span/section/main/div/article/div[1]/div";
                string str = "document.evaluate('" + eval + "/div[last()]',document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null ).singleNodeValue.scrollIntoView()";
                for (int i = 0; i < 80; i++) { js.ExecuteScript(str); Thread.Sleep(200); }
            }catch(Exception e) { ex(e); }
        }


        public static IWebDriver login()
        {
            try
            {
                driver.Navigate().GoToUrl("https://www.instagram.com/accounts/login/");
                Thread.Sleep(400);
                var form = driver.FindElement(By.TagName("form"));
                var acc_inp = form.FindElement(By.XPath("./div[1]/div/div[1]/input[1]"));
                var pw_inp = form.FindElement(By.XPath("./div[2]/div/div[1]/input[1]"));
                acc_inp.SendKeys(acc);
                pw_inp.SendKeys(pw);
                Thread.Sleep(300);
                form.FindElement(By.XPath("./span/button")).Click();
                Thread.Sleep(400);
                if (isElementPresent(By.XPath("/html/body/span/section/main/div/article/div/div[2]/p/a"),driver))
                {
                    Console.WriteLine("=====");
                    do
                    {
                        form.FindElement(By.XPath("./span/button")).Click();
                        Console.WriteLine("AAA");
                        Thread.Sleep(100);
                    } while (isElementPresent(By.XPath("/html/body/span/section/main/div/article/div/div[2]/p/a"),driver));
                }
                else { Console.WriteLine("????"); }
                //id:slfErrorAlert
                //Console.WriteLine("XXX");
            }
            catch (Exception e) {
                ex(e);
                /*if (isElementPresent(By.XPath("//*[@id=\"slfErrorAlert\"]")))
                {
                    var form = driver.FindElement(By.TagName("form"));
                    do
                    {
                        Console.WriteLine("AAA");
                        Thread.Sleep(100);
                        form.FindElement(By.XPath("./span/button")).Click();
                    } while (isElementPresent(By.XPath("//*[@id=\"slfErrorAlert\"]")));
                }*/
            }
            //finally {  Environment.Exit(1); }
            return driver;
        }
        public static bool isElementPresent(By by, IWebDriver driver)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
