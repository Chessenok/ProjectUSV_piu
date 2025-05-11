using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using MetroFramework.Forms;
using MetroFramework.Controls;
using ProjectUSV_piu;

namespace AutoDealerFilterApp
{
    public partial class FilterForm : MetroForm
    {
        private MetroComboBox cbMake;
        private MetroComboBox cbModel;
        private Panel pnlTrims;
        private Timer fadeInTimer;
        private AdministrateCars admin;
        private Factory factory;
        private List<Car> cars;

        public FilterForm(Factory factory, AdministrateCars admin, List<Car> cars)
        {
             InitializeComponent();
     //       InitializeUI();
            this.factory = factory;
            this.admin = admin;
            this.cars = cars;
        }


    }
}
