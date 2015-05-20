using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CityInfoApp.BLL;
using CityInfoApp.Model;

namespace CityInfoApp
{
    public partial class CityInfoUI : Form
    {
        public CityInfoUI()
        {
            InitializeComponent();
        }

        Manager manager = new Manager();
        private void saveButton_Click(object sender, EventArgs e)
        {
            City aCity = new City();
            aCity.CityName = nameTextBox.Text;
            aCity.About = aboutTextBox.Text;
            aCity.Country = countryTextBox.Text;

            MessageBox.Show(manager.Save(aCity));
        }

        

    }
}
