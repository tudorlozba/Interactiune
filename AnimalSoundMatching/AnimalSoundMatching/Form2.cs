using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimalSoundMatching
{
    public partial class Form2 : Form
    {
        public string timeElapsed { get; set; }
        public bool show { get; set; }
        private string fileName = "leadboard.txt";

        public Form2()
        {
            InitializeComponent();
           
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label2.Text = timeElapsed;
            if (show == true)
            {
                showLeaderBoard();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showLeaderBoard();
            

        }

        private void showLeaderBoard()
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Append, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {
               sw.WriteLine((String)textBox1.Text + ";" + timeElapsed);
            }

            dataGridView1.Visible = true;
            var lines = File.ReadAllLines("leadboard.txt");
            DataTable dt = new DataTable();

            dt.Columns.Add("Name");
            dt.Columns.Add("Time");
           

            List<Tuple<string, string>> list = new List<Tuple<string, string>>();


            foreach (var line in lines)
            {
                if (line.Length > 1){
                    var splited = line.Split(';');
                    list.Add(new Tuple<string, string>(splited[0], splited[1]));
                }
            }

            list.Sort((x, y) => y.Item2.CompareTo(x.Item2));
            list.Reverse();


            foreach(var elem in list){
                 DataRow dr = dt.NewRow();
                 dr[0] = elem.Item1;
                 dr[1] = elem.Item2;
                 dt.Rows.Add(dr);
            }

            dataGridView1.DataSource = dt;


        }
    }
}
