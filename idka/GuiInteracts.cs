using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static idka.Form1;
using static idka.Program;
using static idka.Driv;
using static idka.Pics;
using static idka.Dl;

namespace idka
{
    class GuiInteracts
    {
        public static void itsSoBad()
        {
            start = DateTime.Now;
            //Console.WriteLine("Type:" + guiForm.type);
            if (guiForm.type == 1) { update(guiForm.selected); }
            else if (guiForm.type == 0) { leech(guiForm.selected); }
            else { Console.WriteLine("pls never get here"); }
        }

        public static void fknDis()
        {
            List<string> list = getAbos();
            guiForm = new Form1(list);
            guiForm.ShowDialog();
        }

    }
}
