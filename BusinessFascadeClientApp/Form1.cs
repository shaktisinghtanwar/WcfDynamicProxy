using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessFascadeServiceProxyLib;
using Common;
using IBusinessObject;

namespace BusinessFascadeClientApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCallService_Click(object sender, EventArgs e)
        {
            var client = ClientFactory.CreateClient<IJobService>(ServiceType.Local);
           var message =  client.GetJob();

            MessageBox.Show(message);
        }
    }
}
