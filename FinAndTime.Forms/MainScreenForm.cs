using FinAndTime.Core.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinAndTime.Forms
{
    public partial class MainScreenForm : Form
    {
        private ISplashScreenForm _splashScreenFrom;

        public MainScreenForm(ISplashScreenForm splashScreenFrom)
        {
            _splashScreenFrom = splashScreenFrom;
            InitializeComponent();
        }

        private void MainScreenForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void MainScreenForm_Load(object sender, EventArgs e)
        {

        }
    }
}
