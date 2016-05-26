using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace genetic_algor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var series in average_max.Series)
            {
                series.Points.Clear();
            }
            List<int> key = new List<int>();
            string result = "";

            key.Add(5);
            key.Add(6);
            key.Add(8);
            key.Add(10);

            string skey = "";

            foreach (int item in key)
            {
                skey += item.ToString();
            }

            population poppopulation = new population();

            for (int i1 = 0; i1 < 15; i1++)
            {
                average_max.Series["Average"].Points.AddXY(i1, poppopulation.get_avg_weight());
                average_max.Series["Max"].Points.AddXY(i1, poppopulation.get_best_individual().get_adeptness());
                poppopulation.make_cycle();
                
            }

  
            foreach (int item in poppopulation.get_best_individual().GetParams())
            {
                result += item.ToString();
            }

            txt_result.Text = result;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
