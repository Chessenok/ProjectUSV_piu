using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using ProjectUSV_piu;
namespace wpfApp1
{
    public partial class EditCarForm: MetroForm
    {
        Car car;
        public EditCarForm(Car car)
        {
            InitializeComponent();
            this.FormClosed += Return;
            this.car = car;
            PriceTextBox.Text = car.Price.ToString();
        }

        public void Edit_Click(object sender, EventArgs e)
        {
            string newPrice = PriceTextBox.Text;
            int price = 0;
            if (Int32.TryParse(newPrice, out price) && price < 1000000)
            {
               
                car.EditPrice(price);
                this.Close();
            }
            else
            {
                MessageBox.Show("Enter a valid integer");
            }
        }

        public void Return(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
