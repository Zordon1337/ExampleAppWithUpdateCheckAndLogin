using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExampleAppWithLogin
{
    public partial class Form2 : MetroFramework.Forms.MetroForm
    {
        public Form2(String Username)
        {
            InitializeComponent();
            metroLabel1.Text = ("Hello " + Username + "!");
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }
    }
}
