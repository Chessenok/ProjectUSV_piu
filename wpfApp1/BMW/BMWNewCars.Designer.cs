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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.vinTextBox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.IndexTextBox = new MetroFramework.Controls.MetroTextBox();
            this.SearchVinButton = new MetroFramework.Controls.MetroButton();
            this.SearchIndexButton = new MetroFramework.Controls.MetroButton();
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
            this.TitleText.Location = new System.Drawing.Point(23, 60);
            this.TitleText.Name = "TitleText";
            this.TitleText.Size = new System.Drawing.Size(249, 34);
            this.TitleText.TabIndex = 3;
            this.TitleText.Text = "Cars:";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(23, 109);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(95, 19);
            this.metroLabel1.TabIndex = 4;
            this.metroLabel1.Text = "Search By VIN";
            // 
            // vinTextBox
            // 
            this.vinTextBox.Location = new System.Drawing.Point(134, 109);
            this.vinTextBox.Name = "vinTextBox";
            this.vinTextBox.Size = new System.Drawing.Size(166, 23);
            this.vinTextBox.TabIndex = 5;
            this.vinTextBox.Text = "ULQ9LL5USDVRO89VN";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(23, 85);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(105, 19);
            this.metroLabel2.TabIndex = 6;
            this.metroLabel2.Text = "Search by Index";
            // 
            // IndexTextBox
            // 
            this.IndexTextBox.Location = new System.Drawing.Point(134, 80);
            this.IndexTextBox.Name = "IndexTextBox";
            this.IndexTextBox.PromptText = "ex. G30,G05,etc";
            this.IndexTextBox.Size = new System.Drawing.Size(166, 23);
            this.IndexTextBox.TabIndex = 7;
            // 
            // SearchVinButton
            // 
            this.SearchVinButton.Location = new System.Drawing.Point(340, 109);
            this.SearchVinButton.Name = "SearchVinButton";
            this.SearchVinButton.Size = new System.Drawing.Size(100, 23);
            this.SearchVinButton.TabIndex = 8;
            this.SearchVinButton.Text = "Search by VIN";
            this.SearchVinButton.Click += new System.EventHandler(this.OnSearchVinNew_Click);
            // 
            // SearchIndexButton
            // 
            this.SearchIndexButton.Location = new System.Drawing.Point(340, 80);
            this.SearchIndexButton.Name = "SearchIndexButton";
            this.SearchIndexButton.Size = new System.Drawing.Size(100, 23);
            this.SearchIndexButton.TabIndex = 9;
            this.SearchIndexButton.Text = "Search by Index";
            this.SearchIndexButton.Click += new System.EventHandler(this.OnSearchIndexNew_Click);
            // 
            // BMWNewCars
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SearchIndexButton);
            this.Controls.Add(this.SearchVinButton);
            this.Controls.Add(this.IndexTextBox);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.vinTextBox);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.TitleText);
            this.Controls.Add(this.Return);
            this.Controls.Add(this.AddNewCar);
            this.Controls.Add(this.groupCars);
            this.Name = "BMWNewCars";
            this.Text = "BMW Cars";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroPanel groupCars;
        private MetroFramework.Controls.MetroButton AddNewCar;
        private MetroFramework.Controls.MetroButton Return;
        private MetroFramework.Controls.MetroLabel TitleText;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox vinTextBox;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox IndexTextBox;
        private MetroFramework.Controls.MetroButton SearchVinButton;
        private MetroFramework.Controls.MetroButton SearchIndexButton;
    }
}