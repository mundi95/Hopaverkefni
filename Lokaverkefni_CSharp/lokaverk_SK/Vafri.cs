using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lokaverk_SK
{
    public partial class Vafri : Form
    {
        string linkur = null;
        public Vafri(string texti)
        {
            InitializeComponent();
            linkur = texti;
        }

        private void Vafri_Load(object sender, EventArgs e)
        {
            Uri ui = new Uri("http://www." + linkur, UriKind.RelativeOrAbsolute);
            wbVafri.Navigate(ui);
        }
    }
}
