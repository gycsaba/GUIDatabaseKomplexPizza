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
        Pizza kivalasztottPizza = null;
        #region Események
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
        private void dataGridViewPizza_SelectionChanged(object sender, EventArgs e)
        {           
            if (dataGridViewPizza.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewPizza.SelectedRows[0];
                if (row!=null)
                {
                    string data = row.Cells[0].Value.ToString();
                    int pizzaAzonosito = Convert.ToInt32(data);
                    vezerlo.lekerPizzaAdatokatModositashoz(pizzaAzonosito);
                }
            }
        }
        #endregion
        #region Vezérlők beállításai
        public void beallitPizzaVezerloketUresTablaAllapotba()
        {
            buttonPizzaLoad.Visible = false;
            buttonPizzaNew.Visible = true;
            buttonPizzaModify.Visible = false;
            buttonPizzaDelete.Visible = false;
        }
        public void beallitPizzaVezerloketSikeresBetoltesUtan()
        {
            buttonPizzaLoad.Visible = false;
            buttonPizzaNew.Visible = true;
            buttonPizzaModify.Visible = true;
            buttonPizzaDelete.Visible = true;
            dataGridViewPizza.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void beallitPizzaVezerloketKezdetiAllapotba()
        {
            buttonPizzaLoad.Visible = true;
            buttonPizzaNew.Visible = false;
            buttonPizzaModify.Visible = false;
            buttonPizzaDelete.Visible = false;
        }
        #endregion
        #region Pizza modosítás
        public void eltarolEsMegjelenitPizzatModositashoz(Pizza p)
        {
            kivalasztottPizza = p;
            textBoxPizzaAzonosito.Text = p.getAzon().ToString();
            textBoxPizzaNev.Text = p.getNev();
            textBoxPizzaAr.Text = p.getAr().ToString();
        }
        #endregion
    }
}
