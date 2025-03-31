using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Drawing.Text;


namespace ProjectUSV_piu
{
    public class CarForm : Form
    {
        private AdministrateFile admin;

        private const int STEP_X = 75;
        private const int STEP_Y = 30;



        public CarForm()
        {
            FactoryBMW factory = new FactoryBMW();
            admin = new Administrate_BMW_File("BmwDealer.txt", factory);


            this.Size = new Size(700, 700);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Location = new Point(100, 100);
            this.Text = $"Available BMW Cars";
            this.ForeColor = Color.Orange;

            ShowData();
        }
        private async void ShowData() {

            int i = 0;
            List<Label> labels = new List<Label>();
            await Task.Delay(100);
            List<Car> cars = admin.GetAllCars().ToList();
            foreach (Car car in cars)
            {
                labels.Add(new Label());
                labels[i].Top = i * STEP_Y;
                labels[i].Font = new Font("Arial",10,FontStyle.Bold);
                labels[i].Width = 600;
                labels[i].ForeColor = Color.Orange;
                labels[i].Text = $" Car info: {car.ProducerCompany} {car.Model} {car.Complectation} , an {car.Year}, {car.Type.ToString()}, motor de {car.Engine.GetVolume()}cm3 si {car.Engine.MaxHP} cai putere. Pret: {car.Price} Euro ";
                this.Controls.Add(labels[i]);
                i++;
            }

        }
    }
}
