using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using ProjectUSV_piu;

namespace wpfApp1
{
    public partial class AddCarForm: MetroForm
    {
        MetroForm parent;
        private Factory factory;
        private string selectedType;
        int price;
        List<Product> optionBuffer =  new List<Product>();
        
        AdministrateCars admin;
        public AddCarForm(MetroForm parent,Factory factory,AdministrateCars admin)
        {
            InitializeComponent();
            this.parent = parent;
            this.admin = admin;
            this.FormClosed += ReturnBack;
            this.factory = factory;
            
            UpdateColorBox(factory.GetColors());
            UpdateRadioButtons(this, null);
        }

        private void UpdateRadioButtons(object sender, EventArgs e)
        {
            foreach (var btns in radioButtonsPanel.Controls.OfType<MetroRadioButton>())
            {
                if (btns.Checked)
                {
                    selectedType = btns.Text;
                    UpdateModelBox(factory.GetModelsForType(selectedType));
                }
            }
        }
        


        private void UpdateColorBox(List<string> colors)
        {
            ColorComboBox.Items.Clear();
            ColorComboBox.Items.AddRange(colors.ToArray());
        }
        private void UpdateComplectationBox(List<string> complectations)
        {
            var CurrentSelection = ComplectationComboBox.SelectedItem as String;
            ComplectationComboBox.Items.Clear();
            ComplectationComboBox.Items.AddRange(complectations.ToArray());
            if (complectations.Contains(CurrentSelection))        
                ComplectationComboBox.SelectedItem = CurrentSelection;
    
            else
                ComplectationComboBox.SelectedIndex = -1;
        }

        private void UpdateOptionsPanel(List<Product> options)
        {
            // Clear previous checkboxes
            OptionsPanel.Controls.Clear();

            for (int i = 0; i < options.Count; i++)
            {
                Product product = options[i];
                MetroCheckBox chk = new MetroCheckBox();
                chk.Text = $"{product.Description} for {product.Price}$";
                chk.Location = new Point(10, i * 30); // Simple vertical stacking
                chk.AutoSize = true;
                chk.CheckedChanged += (s, ev) => OnBuyCheckBox(s, ev, product);
                OptionsPanel.Controls.Add(chk);
            }
        }
        private void UpdateModelBox(List<string> models)
        {
            var CurrentSelection = SelectModelComboBox.SelectedItem as String;
            SelectModelComboBox.Items.Clear();
            SelectModelComboBox.Items.AddRange(models.ToArray());
            if (models.Contains(CurrentSelection))
                SelectModelComboBox.SelectedItem = CurrentSelection;

            else
            {
                SelectModelComboBox.SelectedIndex = -1;
                ComplectationComboBox.SelectedIndex = -1;
                ComplectationComboBox.Items.Clear();
                UpdatePriceLabel();
            }
        }


        private void OnBuyCheckBox(object sender, EventArgs e, Product product) 
        {
            MetroCheckBox chk = (MetroCheckBox)sender;
            if (chk.Checked) {
               
                this.price += product.Price;
                UpdatePriceLabel();
                optionBuffer.Add(product); 
            }
            else
            {
                this.price -= product.Price;
                UpdatePriceLabel();
                optionBuffer.Remove(product);
            }
        }

        private void ModelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateComplectationBox(factory.GetAllComplectationsForModel(SelectModelComboBox.SelectedItem.ToString()));
            OptionsPanel.Controls.Clear();
            optionBuffer.Clear();
            UpdatePriceLabel();
        }

        private void ComplectationBox_SelectedIndexChanged(object sender,EventArgs e)
        {
            UpdateOptionsPanel(factory.GetAllOptions());
            price =  factory.GetPriceForComplectation(ComplectationComboBox.SelectedItem.ToString());
            UpdatePriceLabel();
        }
        private void ColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void AddCarForm_Load(object sender, EventArgs e)
        {
           
        }

        private void AddCar(bool available)
        {
            if (SelectModelComboBox.SelectedItem == null || ComplectationComboBox.SelectedItem == null || ColorComboBox.SelectedItem == null)
            {
                ErrorProvider errorProvider = new ErrorProvider();
                errorProvider.SetError(PriceLabel,"Select model,color and complectation.");
                return;
            }

            string model = SelectModelComboBox.SelectedItem.ToString();
            string complectation = ComplectationComboBox.SelectedItem.ToString();
            string color = ColorComboBox.SelectedItem.ToString();
            admin.AddCar(factory.BuildNew(complectation, color, optionBuffer.ToArray(), price, available));
            if (available) {
                MessageBox.Show("Car added to new Cars list!");
            }
            else
            {
                MessageBox.Show("Car sold!");
            }
        }


        private void UpdatePriceLabel()
        {
            PriceLabel.Text = $"Price: {price.ToString()}$";
        }
        private void ReturnBack(object sender, EventArgs e)
        {
            this.Close();
        }

        private void metroRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            UpdateRadioButtons(this, null);
        }

        private void metroRadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            UpdateRadioButtons(this, null);
        }

        private void metroRadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            UpdateRadioButtons(this, null);
        }

        private void metroRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            UpdateRadioButtons(this, null);
        }

        private void metroRadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            UpdateRadioButtons(this, null);
        }

        private void metroRadioButton6_CheckedChanged(object sender, EventArgs e)
        {
            UpdateRadioButtons(this, null);
        }

        private void sellButton_Click(object sender, EventArgs e)
        {
            AddCar(false);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            AddCar(true);
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            ReturnBack(this, null);
        }
    }
}
