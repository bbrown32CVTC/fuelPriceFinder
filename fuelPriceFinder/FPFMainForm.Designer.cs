namespace fuelPriceFinder
{
    partial class FPFMainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cityLabel = new Label();
            cityTB = new TextBox();
            fuelCB = new ComboBox();
            fuelTypeLabel = new Label();
            searchBtn = new Button();
            resetBtn = new Button();
            menuStrip1 = new MenuStrip();
            helpMenuItem = new ToolStripMenuItem();
            aboutMenuItem = new ToolStripMenuItem();
            printMenuItem = new ToolStripMenuItem();
            stateLabel = new Label();
            stateCB = new ComboBox();
            errorLabel = new Label();
            gasDisplayLabel = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // cityLabel
            // 
            cityLabel.AutoSize = true;
            cityLabel.Font = new Font("Verdana", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            cityLabel.Location = new Point(51, 93);
            cityLabel.Name = "cityLabel";
            cityLabel.Size = new Size(56, 23);
            cityLabel.TabIndex = 0;
            cityLabel.Text = "City:";
            // 
            // cityTB
            // 
            cityTB.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            cityTB.Location = new Point(120, 90);
            cityTB.Name = "cityTB";
            cityTB.Size = new Size(307, 26);
            cityTB.TabIndex = 1;
            // 
            // fuelCB
            // 
            fuelCB.DropDownStyle = ComboBoxStyle.DropDownList;
            fuelCB.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fuelCB.FormattingEnabled = true;
            fuelCB.Location = new Point(167, 138);
            fuelCB.Name = "fuelCB";
            fuelCB.Size = new Size(260, 26);
            fuelCB.TabIndex = 2;
            // 
            // fuelTypeLabel
            // 
            fuelTypeLabel.AutoSize = true;
            fuelTypeLabel.Font = new Font("Verdana", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            fuelTypeLabel.Location = new Point(51, 139);
            fuelTypeLabel.Name = "fuelTypeLabel";
            fuelTypeLabel.Size = new Size(110, 23);
            fuelTypeLabel.TabIndex = 3;
            fuelTypeLabel.Text = "Fuel Type:";
            // 
            // searchBtn
            // 
            searchBtn.BackColor = Color.LightGreen;
            searchBtn.Font = new Font("Verdana", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            searchBtn.Location = new Point(51, 188);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(376, 32);
            searchBtn.TabIndex = 4;
            searchBtn.Text = "Search";
            searchBtn.UseVisualStyleBackColor = false;
            searchBtn.Click += searchBtn_Click;
            // 
            // resetBtn
            // 
            resetBtn.BackColor = Color.Gold;
            resetBtn.Font = new Font("Verdana", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            resetBtn.Location = new Point(51, 406);
            resetBtn.Name = "resetBtn";
            resetBtn.Size = new Size(376, 32);
            resetBtn.TabIndex = 5;
            resetBtn.Text = "Clear/Reset";
            resetBtn.UseVisualStyleBackColor = false;
            resetBtn.Click += resetBtn_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { helpMenuItem, aboutMenuItem, printMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(480, 24);
            menuStrip1.TabIndex = 6;
            menuStrip1.Text = "menuStrip1";
            // 
            // helpMenuItem
            // 
            helpMenuItem.Name = "helpMenuItem";
            helpMenuItem.Size = new Size(44, 20);
            helpMenuItem.Text = "Help";
            helpMenuItem.Click += helpMenuItem_Click;
            // 
            // aboutMenuItem
            // 
            aboutMenuItem.Name = "aboutMenuItem";
            aboutMenuItem.Size = new Size(52, 20);
            aboutMenuItem.Text = "About";
            aboutMenuItem.Click += aboutMenuItem_Click;
            // 
            // printMenuItem
            // 
            printMenuItem.Name = "printMenuItem";
            printMenuItem.Size = new Size(44, 20);
            printMenuItem.Text = "Print";
            printMenuItem.Click += printMenuItem_Click;
            // 
            // stateLabel
            // 
            stateLabel.AutoSize = true;
            stateLabel.Font = new Font("Verdana", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            stateLabel.Location = new Point(51, 47);
            stateLabel.Name = "stateLabel";
            stateLabel.Size = new Size(68, 23);
            stateLabel.TabIndex = 8;
            stateLabel.Text = "State:";
            // 
            // stateCB
            // 
            stateCB.DropDownStyle = ComboBoxStyle.DropDownList;
            stateCB.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            stateCB.FormattingEnabled = true;
            stateCB.Location = new Point(120, 46);
            stateCB.Name = "stateCB";
            stateCB.Size = new Size(307, 26);
            stateCB.TabIndex = 7;
            stateCB.SelectedIndexChanged += stateCB_SelectedIndexChanged;
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = true;
            errorLabel.BackColor = SystemColors.Control;
            errorLabel.Font = new Font("Verdana", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            errorLabel.ForeColor = Color.Red;
            errorLabel.Location = new Point(46, 370);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(55, 18);
            errorLabel.TabIndex = 9;
            errorLabel.Text = "Error:";
            // 
            // gasDisplayLabel
            // 
            gasDisplayLabel.AutoSize = true;
            gasDisplayLabel.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            gasDisplayLabel.Location = new Point(55, 254);
            gasDisplayLabel.Name = "gasDisplayLabel";
            gasDisplayLabel.Size = new Size(52, 18);
            gasDisplayLabel.TabIndex = 10;
            gasDisplayLabel.Text = "City: ";
            // 
            // FPFMainForm
            // 
            AcceptButton = searchBtn;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(480, 450);
            Controls.Add(gasDisplayLabel);
            Controls.Add(errorLabel);
            Controls.Add(stateLabel);
            Controls.Add(stateCB);
            Controls.Add(resetBtn);
            Controls.Add(searchBtn);
            Controls.Add(fuelTypeLabel);
            Controls.Add(fuelCB);
            Controls.Add(cityTB);
            Controls.Add(cityLabel);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FPFMainForm";
            Text = "Fuel Price Finder";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label cityLabel;
        private TextBox cityTB;
        private ComboBox fuelCB;
        private Label fuelTypeLabel;
        private Button searchBtn;
        private Button resetBtn;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem helpMenuItem;
        private ToolStripMenuItem aboutMenuItem;
        private Label stateLabel;
        private ComboBox stateCB;
        private Label errorLabel;
        private Label gasDisplayLabel;
        private ToolStripMenuItem printMenuItem;
    }
}
