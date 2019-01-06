using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuiDatabaseKomplexPizzaZarodolgozatMinta
{
    partial class FormMain : Form
    {
        private void buttonPizzaLoad_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridViewPizza.DataSource = vezerlo.getPizzakTabla();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        private void beallitPizzaVezerloketKezdetiAllapotba()
        {
            buttonPizzaLoad.Visible = true;
            buttonPizzaNew.Visible = false;
            buttonPizzaModify.Visible = false;
            buttonPizzaDelete.Visible = false;

        }
    }
}
