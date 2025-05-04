namespace wpfApp1
{
    partial class BMWDealerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.NewCars = new MetroFramework.Controls.MetroButton();
            this.UsedCars = new MetroFramework.Controls.MetroButton();
            this.SoldCars = new MetroFramework.Controls.MetroButton();
            this.CommandCar = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // NewCars
            // 
            this.NewCars.Location = new System.Drawing.Point(23, 63);
            this.NewCars.Name = "NewCars";
            this.NewCars.Size = new System.Drawing.Size(139, 61);
            this.NewCars.TabIndex = 0;
            this.NewCars.Text = "Show New Cars For Sale";
            this.NewCars.Click += new System.EventHandler(this.NewCars_Click);
            // 
            // UsedCars
            // 
            this.UsedCars.Location = new System.Drawing.Point(327, 63);
            this.UsedCars.Name = "UsedCars";
            this.UsedCars.Size = new System.Drawing.Size(139, 61);
            this.UsedCars.TabIndex = 1;
            this.UsedCars.Text = "Show Used Cars For Sale";
            this.UsedCars.Click += new System.EventHandler(this.UsedCars_Click);
            // 
            // SoldCars
            // 
            this.SoldCars.Location = new System.Drawing.Point(638, 63);
            this.SoldCars.Name = "SoldCars";
            this.SoldCars.Size = new System.Drawing.Size(139, 61);
            this.SoldCars.TabIndex = 2;
            this.SoldCars.Text = "Show Sold Cars";
            this.SoldCars.Click += new System.EventHandler(this.SoldCars_Click);
            // 
            // CommandCar
            // 
            this.CommandCar.Location = new System.Drawing.Point(23, 366);
            this.CommandCar.Name = "CommandCar";
            this.CommandCar.Size = new System.Drawing.Size(754, 61);
            this.CommandCar.TabIndex = 3;
            this.CommandCar.Text = "Command Custom New Car";
            this.CommandCar.Click += new System.EventHandler(this.CommandCar_Click);
            // 
            // BMWDealerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CommandCar);
            this.Controls.Add(this.SoldCars);
            this.Controls.Add(this.UsedCars);
            this.Controls.Add(this.NewCars);
            this.Name = "BMWDealerForm";
            this.Text = "BMWDealerForm2";
            this.Load += new System.EventHandler(this.BMWDealerForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton NewCars;
        private MetroFramework.Controls.MetroButton UsedCars;
        private MetroFramework.Controls.MetroButton SoldCars;
        private MetroFramework.Controls.MetroButton CommandCar;
    }
}