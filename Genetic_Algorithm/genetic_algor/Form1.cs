using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace genetic_algor
{
    using System.Linq;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1Load(object sender, EventArgs e)
        {

        }

        private void Button1Click(object sender, EventArgs e)
        {
            foreach (var series in average_max.Series)
            {
                series.Points.Clear();
            }
            List<int> key = new List<int> { 5, 6, 8, 10 };


            key.Aggregate("", (current, item) => current + item.ToString());

            Population poppopulation = new Population();

            for (int i1 = 0; i1 < 15; i1++)
            {
                average_max.Series["Average"].Points.AddXY(i1, poppopulation.GetAvgWeight());
                average_max.Series["Max"].Points.AddXY(i1, poppopulation.GetBestIndividual().GetAdeptness());
                poppopulation.MakeCycle();
                
            }

            string result = poppopulation.GetBestIndividual().GetParams().Aggregate("", (current, item) => current + item.ToString());

            txt_result.Text = result;


        }

        private void Button2Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
