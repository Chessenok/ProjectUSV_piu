namespace wpfApp1.BMW
{
    partial class BMWNewCars
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
            this.groupCars = new MetroFramework.Controls.MetroPanel();
            this.AddNewCar = new MetroFramework.Controls.MetroButton();
            this.Return = new MetroFramework.Controls.MetroButton();
            this.TitleText = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // groupCars
            // 
            this.groupCars.AutoScroll = true;
            this.groupCars.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.groupCars.HorizontalScrollbar = true;
            this.groupCars.HorizontalScrollbarBarColor = true;
            this.groupCars.HorizontalScrollbarHighlightOnWheel = false;
            this.groupCars.HorizontalScrollbarSize = 10;
            this.groupCars.Location = new System.Drawing.Point(15, 150);
            this.groupCars.Name = "groupCars";
            this.groupCars.Size = new System.Drawing.Size(762, 270);
            this.groupCars.Style = MetroFramework.MetroColorStyle.Silver;
            this.groupCars.TabIndex = 0;
            this.groupCars.VerticalScrollbar = true;
            this.groupCars.VerticalScrollbarBarColor = true;
            this.groupCars.VerticalScrollbarHighlightOnWheel = false;
            this.groupCars.VerticalScrollbarSize = 10;
               // 
            // AddNewCar
            // 
            this.AddNewCar.Location = new System.Drawing.Point(527, 63);
            this.AddNewCar.Name = "AddNewCar";
            this.AddNewCar.Size = new System.Drawing.Size(122, 56);
            this.AddNewCar.TabIndex = 1;
            this.AddNewCar.Text = "Add New Car";
            // 
            // Return
            // 
            this.Return.Location = new System.Drawing.Point(655, 63);
            this.Return.Name = "Return";
            this.Return.Size = new System.Drawing.Size(122, 56);
            this.Return.TabIndex = 2;
            this.Return.Text = "Return Back";
            this.Return.Click += new System.EventHandler(this.Return_Click);
            // 
            // TitleText
            // 
            this.TitleText.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.TitleText.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TitleText.Location = new System.Drawing.Point(23, 85);
            this.TitleText.Name = "TitleText";
            this.TitleText.Size = new System.Drawing.Size(249, 34);
            this.TitleText.TabIndex = 3;
            this.TitleText.Text = "Cars:";
            // 
            // BMWNewCars
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TitleText);
            this.Controls.Add(this.Return);
            this.Controls.Add(this.AddNewCar);
            this.Controls.Add(this.groupCars);
            this.Name = "BMWNewCars";
            this.Text = "BMW Cars";
           // this.Load += new System.EventHandler(this.ShowNewCars);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel groupCars;
        private MetroFramework.Controls.MetroButton AddNewCar;
        private MetroFramework.Controls.MetroButton Return;
        private MetroFramework.Controls.MetroLabel TitleText;
    }
}