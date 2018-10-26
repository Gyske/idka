using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static idka.Ex;
using static idka.Func;
using static idka.Program;

namespace idka
{
    class Ex
    {
        public static void ex(Exception e)
        {
            try
            {
                Exception exc = e;
                string scheme = "{0,-11}";
                var ud = e.TargetSite.ToString().Split(' ');
                //Console.WriteLine("________________________________________START________________");
                //dispArr(ud);
                //var list = new List<string>(ud);
                //list.Remove(ud.Last());
                //Console.WriteLine("_______________________________________END__________________");
                //ud = list.ToArray();
                //dispArr(ud);
                string func = String.Format(scheme, e.TargetSite.ToString().Split(' ')[1]);
                string source = String.Format(scheme, e.StackTrace);
                var asd = source.Split(' ');
                //asd=cut(asd, 1);
                string line = String.Format(scheme, asd.Last());
                asd = cut(asd, 1);
                var file = String.Format(scheme, asd.Last().Split('\\')[5].Split(':')[0]);
                string msg = String.Format(scheme, e.Message);

                // asd
                Console.WriteLine(String.Format(scheme, "---------"));
                Console.WriteLine(String.Format(scheme, "File:") + file);
                Console.WriteLine(String.Format(scheme, "Line:") + line);
                Console.WriteLine(String.Format(scheme, "Function:") + func);
                Console.WriteLine(String.Format(scheme, "Message:") + msg);
                Console.WriteLine(String.Format(scheme, "Curr Site:") + String.Format(scheme, driver.Url));
                Console.WriteLine(String.Format(scheme, "Time:") + String.Format(scheme, DateTime.Now));
                Console.WriteLine(String.Format(scheme, "---------"));
            }
            catch (Exception ex)
            {
                Console.WriteLine("DANGER:" + ex.Message);
                var fml = ex.StackTrace.Split(' ');
                int i = 0;
                foreach (var itm in fml) { Console.WriteLine(i + ":" + itm.ToString()); i++; }
            }
        }

    }
}
