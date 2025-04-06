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
        private const int TEXTBOX_WIDTH = 100;

        private ErrorProvider errorProvider;

        private TextBox caroserie;
        private TextBox complectation;

         
        private Button addCarScreenButton;
        private Button addCarButton;
        private Button backToMainScreen;
        FactoryBMW factory;


        public CarForm()
        {
            errorProvider = new ErrorProvider();
            factory = new FactoryBMW();
            admin = new Administrate_BMW_File("BmwDealer.txt", factory);


            this.Size = new Size(700, 700);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Location = new Point(100, 100);
            this.Text = $"Available BMW Cars";
            this.ForeColor = Color.Orange;

            ShowDataScreen();
        }



        private void OnNewCarScreenClick(object sender, EventArgs args)
        {
            NewCarScreen();
        }
        private void NewCarScreen()
        {
            this.Controls.Clear();
            int i = 0;
            Label labelComplectation = new Label();
            labelComplectation.Text = "Complectatie";
            labelComplectation.ForeColor = Color.Orange;
            labelComplectation.Font = new Font("Arial", 10);
            labelComplectation.Location = new Point(0,i * STEP_Y);
            labelComplectation.Width = TEXTBOX_WIDTH;
            this.Controls.Add(labelComplectation);

            complectation = new TextBox();
            complectation.Width = TEXTBOX_WIDTH;
            complectation.Location = new Point(TEXTBOX_WIDTH, i*STEP_Y);
            this.Controls.Add(complectation);
            i++;
            
            addCarButton = new Button();
            addCarButton.Location = new Point(0,i * STEP_Y);
            addCarButton.Size = new Size(TEXTBOX_WIDTH, STEP_Y);
            addCarButton.Text = "Add Car";
            addCarButton.Click += OnNewCarClick;
            this.Controls.Add(addCarButton);

            backToMainScreen = new Button();
            backToMainScreen.Location = new Point(TEXTBOX_WIDTH+5,i * STEP_Y);
            backToMainScreen.Size = new Size(TEXTBOX_WIDTH,STEP_Y);
            backToMainScreen.Text = "Return back";
            backToMainScreen.Click += OnBackButtonClick;
            this.Controls.Add(backToMainScreen);

        }

       

        private void OnBackButtonClick(object sender, EventArgs e)
        {
            ShowDataScreen();
        }

        private void OnNewCarClick(object sender, EventArgs e)
        {
            string sComplectation = complectation.Text;
            //string sCaroserie = caroserie.Text;
            if (admin.Factory.ComplectationExists(sComplectation))
            {
                errorProvider.Clear();
                Label label = new Label();
                label.Location = new Point(TEXTBOX_WIDTH * 2 + 5, 0);
                label.ForeColor = Color.Green;
                
                label.Font = new Font("Arial", 10, FontStyle.Bold);
                label.Text = $"Complectatia {sComplectation} a fost adaugata cu succes";
                label.Width = TEXTBOX_WIDTH * 4;
                this.Controls.Add(label);
                if (sComplectation[0] == '5')
                {
                    admin.AddCar(factory.BuildNew5Series(sComplectation, null));
                }
                else
                {
                    admin.AddCar(factory.BuildNew3Series(sComplectation, null));
                }
            }
            else
            {
                errorProvider.SetError(complectation, "Nu exista asa complectatie/model, sau nu a fost gasit");
            }

        }
        private async void ShowDataScreen() {
            this.Controls.Clear();
            int i = 0;
            List<Label> labels = new List<Label>();
            await Task.Delay(300);
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

            addCarScreenButton = new Button();
            addCarScreenButton.Location = new Point(0,i*STEP_Y);
            addCarScreenButton.Size = new Size(100,25);
            addCarScreenButton.Text = "Add New Car";
            addCarScreenButton.ForeColor = Color.Green;
            addCarScreenButton.Click += OnNewCarScreenClick;
            this.Controls.Add(addCarScreenButton);
            i++;


        }
    }
}
