using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static idka.Program;

namespace idka
{
    public partial class Form1 : Form
    {
        public List<string> selected=null;
        public int type = -1;
        public Form1(List<string> list)
        {
            InitializeComponent();
            int i = 1;
            list.Sort();
            foreach (var itm in list)
            {
                string[] str = itm.Split('/');
                int le = str.Length - 2;

                checkedListBox1.Items.Add(new ComboboxItem(str[le],i));
                i++;
            }
        }


        public void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
        public void leg_Click(object sender, EventArgs e)
        {
            //var qwe=checkedListBox1.SelectedItems;
            type = 0;
            selected = new List<string>();
            foreach (var sel in checkedListBox1.CheckedItems) { selected.Add(sel.ToString()); }
            Console.WriteLine("UFF");
            Program.state = true;
            
        }

        public void button1_Click(object sender, EventArgs e)
        {
            type = 0;
            selected = new List<string>();
            foreach (var sel in checkedListBox1.Items) { selected.Add(sel.ToString()); }
            Console.WriteLine("UFF");
            
            Program.state = true;
        }

        public void button2_Click(object sender, EventArgs e)
        {
            type = 1;
            selected = new List<string>();
            foreach (var sel in checkedListBox1.CheckedItems) { selected.Add(sel.ToString()); }
            Console.WriteLine("UFF");
            Program.state = true;
        }

        public void button3_Click(object sender, EventArgs e)
        {
            type = 1;
            selected = new List<string>();
            foreach (var sel in checkedListBox1.Items) { selected.Add(sel.ToString()); }
            Console.WriteLine("UFF");
            Program.state = true;
        }

        private void cmd_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
    public class ComboboxItem
    {
        public ComboboxItem(String text, object value) { Text = text; Value = value; }
        public string Text { get; set; }
        public object Value { get; set; }
        public override string ToString()
        {
            return Text;
        }
    }
}
