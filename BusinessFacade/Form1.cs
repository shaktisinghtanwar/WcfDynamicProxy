using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;
using BusinessObject;
using IBusinessObject;

namespace BusinessFacade
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private ServiceHost jobServiceHost;
        Timer timer = new Timer();
        private void Form1_Load(object sender, EventArgs e)
        {
            timer.Interval = 1000;
            timer.Enabled = true;

            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
          jobServiceHost =new ServiceHost(typeof(JobService),new Uri[]{new Uri("http://localhost:4444/test") });
            jobServiceHost.AddServiceEndpoint(typeof (IJobService), new BasicHttpBinding(), "");
            jobServiceHost.Open();
            timer.Stop();
        }
    }
}
