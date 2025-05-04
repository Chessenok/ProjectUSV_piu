using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using ProjectUSV_piu;
namespace wpfApp1.BMW
{
    public partial class BMWNewCars : MetroForm
    {
        private AdministrateCars admin;
        private FactoryBMW factory;
        private MetroForm parent;

        private const string NEW = "New Cars, available for sale:";
        private const string USED = "Used cars, available for sale:";
        private const string SOLD = "Sold Cars, not available for sale:";
        public BMWNewCars(AdministrateCars admin, FactoryBMW factory, MetroForm parent)
        {
            InitializeComponent();
            this.admin = admin;
            this.factory = factory;
            this.parent = parent;
            this.FormClosed += BMWNewCars_FormClosed;
        }

        private void BMWNewCars_FormClosed(object sender, FormClosedEventArgs e)
        {
           Application.Exit();
        }

        public void ShowNewCars()
        {
            TitleText.Text = NEW;
            DisplayNewCars(admin.GetAllCars().Where(car => car.isAvailable && car.kmOnBoard < 10).ToList());
            this.Show();
        }

        public void ShowUsedCars()
        {
            TitleText.Text = USED;
            DisplayUsedCars(admin.GetAllCars().Where(car => car.kmOnBoard > 10 && car.isAvailable).ToList());
            this.Show();
        }

        public void ShowSoldCars()
        {
            //to do
        }

        private void DisplayNewCars(List<Car> carList)
        {
            // Clear existing car entries from the panel
            groupCars.Controls.Clear();
            groupCars.AutoScroll = true;
            groupCars.AutoScrollPosition = new Point(0, 0); // Reset scroll

            int yOffset = 10;
            foreach (var car in carList)
            {
                var carPanel = new MetroPanel
                {
                    Width = groupCars.Width-2,
                    Height = 130,
                    Location = new Point(1, yOffset),
                    BackColor = Color.White,
                };

                var infoLabel = new MetroLabel
                {
                    Text = $"Model: {car.Model}\nPrice: {car.Price}$\nEngine: {car.Engine.GetVolume()}cm3 - {car.Engine.MaxHP} HP\nType: {car.Type}\nComplactation: {car.Complectation}",
                    Location = new Point(10, 10),
                    Width = 340,
                    Height = 100,
                    BackColor = Color.White
                };

                var editButton = new MetroButton
                {
                    Text = "Edit",
                    Location = new Point(370, 20),
                    Width = 120,
                    Tag = car
                };
                editButton.Click += (s, e) => EditCar((Car)((Control)s).Tag);

                var sellButton = new MetroButton
                {
                    Text = "Sell",
                    Location = new Point(370, 60),
                    Width = 120,
                    Tag = car
                };
                sellButton.Click += (s, e) => SellCar((Car)((Control)s).Tag);

    


                carPanel.Controls.Add(infoLabel);
                carPanel.Controls.Add(editButton);
                carPanel.Controls.Add(sellButton);
    

                groupCars.Controls.Add(carPanel);
                yOffset += carPanel.Height + 10;
            }

        }
        private void DisplayUsedCars(List<Car> carList)
        {
            groupCars.Controls.Clear();
            groupCars.AutoScroll = true;
            groupCars.AutoScrollPosition = new Point(0, 0); // Reset scroll

            int yOffset = 10;
            foreach (var car in carList)
            {
                var carPanel = new MetroPanel
                {
                    Width = groupCars.Width - 2,
                    Height = 150,
                    Location = new Point(1, yOffset),
                    BackColor = Color.White,
                };

                var infoLabel = new MetroLabel
                {
                    Text = $"Model: {car.Model}\nPrice: {car.Price}$\nEngine: {car.Engine.GetVolume()}cm3 - {car.Engine.MaxHP} HP\nType: {car.Type}\nComplactation: {car.Complectation}\nKm On Board: {car.kmOnBoard} ",
                    Location = new Point(10, 10),
                    Width = 340,
                    Height = 120,
                    BackColor = Color.White
                };

                var editButton = new MetroButton
                {
                    Text = "Edit",
                    Location = new Point(370, 20),
                    Width = 120,
                    Tag = car
                };
                editButton.Click += (s, e) => EditCar((Car)((Control)s).Tag);

                var sellButton = new MetroButton
                {
                    Text = "Sell",
                    Location = new Point(370, 60),
                    Width = 120,
                    Tag = car
                };
                sellButton.Click += (s, e) => SellCar((Car)((Control)s).Tag);




                carPanel.Controls.Add(infoLabel);
                carPanel.Controls.Add(editButton);
                carPanel.Controls.Add(sellButton);


                groupCars.Controls.Add(carPanel);
                yOffset += carPanel.Height + 10;
            }

        }

        private void EditCar(Car car)
        {
            MessageBox.Show($"Edit car: {car.GetFullName()}\nVIN: {car.VIN}");
            // TODO: Open a form or panel for editing
        }

        private void SellCar(Car car)
        {
            if (!car.isAvailable)
            {
                MessageBox.Show($"Car {car.GetFullName()} is already sold.");
                return;
            }

            // TODO: Process sale logic
            MessageBox.Show($"Selling car: {car.GetFullName()}");
            car.isAvailable = false;
        }


        private void Return_Click(object sender, EventArgs e)
        {
            parent.Show();
            this.Hide();
        }

    }
}
