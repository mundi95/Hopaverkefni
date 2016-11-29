using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* Sveinn Máni Jónsson
 * 23.11.2016
 * Lokaverkefni
 */
namespace lokaverk_SK
{
    
    public partial class Form1 : Form
    {
        Gagnagrunnur gagnagrunnur = new Gagnagrunnur();        
        public Form1()
        {
            
            InitializeComponent();
            try
            {
                gagnagrunnur.TengingVidGagnagrunn();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            lvTafla.Columns.Add("ID", 50);
            lvTafla.Columns.Add("Titill", 180);
            lvTafla.Columns.Add("Leikstjóri", 180);
            lvTafla.Columns.Add("Framleiðslufyrirtæki", 180);
            lvTafla.Columns.Add("Ár", 40);
            lvTafla.Columns.Add("Flokkur", 100);

            List<string> linur = new List<string>();
            string[] arr = new string[6];

            ListViewItem itm;

            try
            {
                linur = gagnagrunnur.LesaUt();

                foreach(string lin in linur)
                {
                    string[] linaUrLista = lin.Split(':');
                    string ID = linaUrLista[0];
                    string titill = linaUrLista[1];
                    string leikstjori = linaUrLista[2];
                    string utgefandi = linaUrLista[3];
                    string ar = linaUrLista[4];
                    string flokkur = linaUrLista[5];

                    arr[0] = ID;
                    arr[1] = titill;
                    arr[2] = leikstjori;
                    arr[3] = utgefandi;
                    arr[4] = ar;
                    arr[5] = flokkur;

                    itm = new ListViewItem(arr);
                    lvTafla.Items.Add(itm);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());    
            }
        }

        private void lvOutput_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvTafla.SelectedIndices.Count <=0)
            {
                return;
            }
            int intSelectedIndex = lvTafla.SelectedIndices[0];
            if (intSelectedIndex >= 0)
            {
                tbID.Text = lvTafla.SelectedItems[0].SubItems[0].Text;
                tbTitill.Text = lvTafla.SelectedItems[0].SubItems[1].Text;
                tbLeikstjori.Text = lvTafla.SelectedItems[0].SubItems[2].Text;
                tbUtgefandi.Text = lvTafla.SelectedItems[0].SubItems[3].Text;
                tbAr.Text = lvTafla.SelectedItems[0].SubItems[4].Text;
                tbFlokkur.Text = lvTafla.SelectedItems[0].SubItems[5].Text;
            }
        }    

        private void btSkra_Click(object sender, EventArgs e)
        {
            gagnagrunnur.SettInnSqlToflu(tbSkraTitill.Text, tbSkraLeikstjori.Text, tbSkraUtgefandi.Text, cbSkraAr.Text, cbSkraFlokkur.Text);
            tbSkraTitill.Clear();
            tbSkraLeikstjori.Clear();
            tbSkraUtgefandi.Clear();            

            //Uppfæri ListView hér eftir skráningu.
            lvTafla.Clear();
            lvTafla.Columns.Add("ID", 50);
            lvTafla.Columns.Add("Titill", 180);
            lvTafla.Columns.Add("Leikstjóri", 180);
            lvTafla.Columns.Add("Framleiðslufyrirtæki", 180);
            lvTafla.Columns.Add("Ár", 40);
            lvTafla.Columns.Add("Flokkur", 100);

            List<string> linur = new List<string>();
            string[] arr = new string[6];

            ListViewItem itm;

            try
            {
                linur = gagnagrunnur.LesaUt();

                foreach (string lin in linur)
                {
                    string[] linaUrLista = lin.Split(':');
                    string ID = linaUrLista[0];
                    string titill = linaUrLista[1];
                    string leikstjori = linaUrLista[2];
                    string utgefandi = linaUrLista[3];
                    string ar = linaUrLista[4];
                    string flokkur = linaUrLista[5];

                    arr[0] = ID;
                    arr[1] = titill;
                    arr[2] = leikstjori;
                    arr[3] = utgefandi;
                    arr[4] = ar;
                    arr[5] = flokkur;

                    itm = new ListViewItem(arr);
                    lvTafla.Items.Add(itm);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }            
        }

        private void btUppfaera_Click(object sender, EventArgs e)
        {
            gagnagrunnur.Uppfaera(tbID.Text, tbTitill.Text, tbLeikstjori.Text, tbUtgefandi.Text, tbAr.Text, tbFlokkur.Text);
            tbID.Text = null;
            tbTitill.Text = null;
            tbLeikstjori.Text= null;
            tbUtgefandi.Text = null;
            tbAr.Text = null;
            tbFlokkur.Text = null;

            //Uppfæri ListView eftir uppfærslu
            //Uppfæri ListView hér eftir skráningu.
            lvTafla.Clear();
            lvTafla.Columns.Add("ID", 50);
            lvTafla.Columns.Add("Titill", 180);
            lvTafla.Columns.Add("Leikstjóri", 180);
            lvTafla.Columns.Add("Framleiðslufyrirtæki", 180);
            lvTafla.Columns.Add("Ár", 40);
            lvTafla.Columns.Add("Flokkur", 100);

            List<string> linur = new List<string>();
            string[] arr = new string[6];

            ListViewItem itm;

            try
            {
                linur = gagnagrunnur.LesaUt();

                foreach (string lin in linur)
                {
                    string[] linaUrLista = lin.Split(':');
                    string ID = linaUrLista[0];
                    string titill = linaUrLista[1];
                    string leikstjori = linaUrLista[2];
                    string utgefandi = linaUrLista[3];
                    string ar = linaUrLista[4];
                    string flokkur = linaUrLista[5];

                    arr[0] = ID;
                    arr[1] = titill;
                    arr[2] = leikstjori;
                    arr[3] = utgefandi;
                    arr[4] = ar;
                    arr[5] = flokkur;

                    itm = new ListViewItem(arr);
                    lvTafla.Items.Add(itm);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btEyda_Click(object sender, EventArgs e)
        {
            gagnagrunnur.Eyda(tbID.Text);
            tbID.Text = null;
            tbTitill.Text = null;
            tbLeikstjori.Text = null;
            tbUtgefandi.Text = null;
            tbAr.Text = null;
            tbFlokkur.Text = null;
            
            //Uppfæri töflu eftir að mynd hefur verið eytt úr gagnagrunni
            //Uppfæri ListView hér eftir skráningu.
            lvTafla.Clear();
            lvTafla.Columns.Add("ID", 50);
            lvTafla.Columns.Add("Titill", 180);
            lvTafla.Columns.Add("Leikstjóri", 180);
            lvTafla.Columns.Add("Framleiðslufyrirtæki", 180);
            lvTafla.Columns.Add("Ár", 40);
            lvTafla.Columns.Add("Flokkur", 100);

            List<string> linur = new List<string>();
            string[] arr = new string[6];

            ListViewItem itm;

            try
            {
                linur = gagnagrunnur.LesaUt();

                foreach (string lin in linur)
                {
                    string[] linaUrLista = lin.Split(':');
                    string ID = linaUrLista[0];
                    string titill = linaUrLista[1];
                    string leikstjori = linaUrLista[2];
                    string utgefandi = linaUrLista[3];
                    string ar = linaUrLista[4];
                    string flokkur = linaUrLista[5];

                    arr[0] = ID;
                    arr[1] = titill;
                    arr[2] = leikstjori;
                    arr[3] = utgefandi;
                    arr[4] = ar;
                    arr[5] = flokkur;

                    itm = new ListViewItem(arr);
                    lvTafla.Items.Add(itm);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btFlokkaFlokk_Click(object sender, EventArgs e)//Flokka ListView eftir flokk mynda
        {
            string mynd = cbFlokkaFlokk.Text;
            lvTafla.Clear();
            lvTafla.Columns.Add("ID", 50);
            lvTafla.Columns.Add("Titill", 180);
            lvTafla.Columns.Add("Leikstjóri", 180);
            lvTafla.Columns.Add("Framleiðslufyrirtæki", 180);
            lvTafla.Columns.Add("Ár", 40);
            lvTafla.Columns.Add("Flokkur", 100);

            List<string> linur = new List<string>();
            string[] arr = new string[6];

            ListViewItem itm;

            try
            {
                linur = gagnagrunnur.LesaUtFlokk(mynd);

                foreach (string lin in linur)
                {
                    string[] linaUrLista = lin.Split(':');
                    string ID = linaUrLista[0];
                    string titill = linaUrLista[1];
                    string leikstjori = linaUrLista[2];
                    string utgefandi = linaUrLista[3];
                    string ar = linaUrLista[4];
                    string flokkur = linaUrLista[5];

                    arr[0] = ID;
                    arr[1] = titill;
                    arr[2] = leikstjori;
                    arr[3] = utgefandi;
                    arr[4] = ar;
                    arr[5] = flokkur;

                    itm = new ListViewItem(arr);
                    lvTafla.Items.Add(itm);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btFlokkaAr_Click(object sender, EventArgs e)//Flokka ListView eftir árgerð
        {
            string argerd = cbFlokkaAr.Text;
            lvTafla.Clear();
            lvTafla.Columns.Add("ID", 50);
            lvTafla.Columns.Add("Titill", 180);
            lvTafla.Columns.Add("Leikstjóri", 180);
            lvTafla.Columns.Add("Framleiðslufyrirtæki", 180);
            lvTafla.Columns.Add("Ár", 40);
            lvTafla.Columns.Add("Flokkur", 100);

            List<string> linur = new List<string>();
            string[] arr = new string[6];

            ListViewItem itm;

            try
            {
                linur = gagnagrunnur.LesaUtAr(argerd);

                foreach (string lin in linur)
                {
                    string[] linaUrLista = lin.Split(':');
                    string ID = linaUrLista[0];
                    string titill = linaUrLista[1];
                    string leikstjori = linaUrLista[2];
                    string utgefandi = linaUrLista[3];
                    string ar = linaUrLista[4];
                    string flokkur = linaUrLista[5];

                    arr[0] = ID;
                    arr[1] = titill;
                    arr[2] = leikstjori;
                    arr[3] = utgefandi;
                    arr[4] = ar;
                    arr[5] = flokkur;

                    itm = new ListViewItem(arr);
                    lvTafla.Items.Add(itm);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        

        private void btFlokkaTitill_Click(object sender, EventArgs e)
        {
            gagnagrunnur.FinnaMynd(tbFlokkaTitill.Text);
            tbFlokkaTitill.Text = null;
        }

                   
    }
}
