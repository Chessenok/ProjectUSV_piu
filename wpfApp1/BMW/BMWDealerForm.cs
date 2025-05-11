using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroFramework;
using MetroFramework.Forms;
using System.Windows.Forms;
using ProjectUSV_piu;
using wpfApp1.BMW;

namespace wpfApp1
{
    public partial class BMWDealerForm : MetroForm
    {
        private ErrorProvider errorProvider;
        private Administrate_BMW_File admin;
        private FactoryBMW factory;
        BMWNewCars Cars;
        public BMWDealerForm()
        {
            InitializeComponent();
           errorProvider = new ErrorProvider();
            factory = new FactoryBMW();
            admin = new Administrate_BMW_File("BmwDealer.txt", factory);
            Cars = new BMWNewCars(admin, factory, this);
            this.FormClosed += BMWDealerForm_FormClosed;
        }

        private void BMWDealerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
           Application.Exit();
        }

        private void BMWDealerForm_Load(object sender, EventArgs e)
        {
            
        }

        private void CommandCar_Click(object sender, EventArgs e)
        {
            var addCarForm = new AddCarForm(this,factory,admin);
            this.Hide();
            addCarForm.ShowDialog();
            this.Show();
        }

        private void UsedCars_Click(object sender, EventArgs e)
        { 
            Cars.ShowUsedCars();
            this.Hide();
        }       


        private void SoldCars_Click(object sender, EventArgs e)
        {

        }

        private void NewCars_Click(object sender, EventArgs e)
        {

            Cars.ShowNewCars();
            this.Hide();
        }


    }
}
