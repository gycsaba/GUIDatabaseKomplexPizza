using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuiDatabaseKomplexPizzaZarodolgozatMinta
{
    public partial class FormMain : Form
    {
        #region mezőtulajdonságok
        private PizzaFutar pf;
        private Vezerlo vezerlo;
        #endregion

        #region Konstruktor
        public FormMain()
        {
            pf = new PizzaFutar("Pizza Futár Kft.");
            vezerlo = new Vezerlo();
            InitializeComponent();

            beallitPizzaVezerloketKezdetiAllapotba();
        }
        #endregion

        #region TabControl és menünpontok összekötése    
        private void pizzaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //tabControlPizza.SelectTab(0);
            tabControlPizza.SelectedTab = tabPagePizza;
        }

        private void vevőToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControlPizza.SelectedTab = tabPageVevo;
        }

        private void futárToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControlPizza.SelectedTab = tabPageFutar;
        }
        #endregion
        #region Menüpontok
        private void névjegyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                pf.getCegnev(),
                "Program információ",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void kilépésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion      
    }
}
