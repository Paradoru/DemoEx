namespace ESoft
{
    partial class EditHouse
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
            this.textBoxValueAdded = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxHouseNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.textBoxStreet = new System.Windows.Forms.TextBox();
            this.comboBoxResidentialComplex = new System.Windows.Forms.ComboBox();
            this.textBoxConstructionCost = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxValueAdded
            // 
            this.textBoxValueAdded.Location = new System.Drawing.Point(658, 56);
            this.textBoxValueAdded.Name = "textBoxValueAdded";
            this.textBoxValueAdded.Size = new System.Drawing.Size(131, 20);
            this.textBoxValueAdded.TabIndex = 42;
            // 
            // label7
            // 
            this.label7.AutoEllipsis = true;
            this.label7.Location = new System.Drawing.Point(662, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 28);
            this.label7.TabIndex = 40;
            this.label7.Text = "Затраты компании на строительство дома";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(499, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "КФ добавочной стоимости";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(218, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Номер дома";
            // 
            // textBoxHouseNumber
            // 
            this.textBoxHouseNumber.Location = new System.Drawing.Point(209, 56);
            this.textBoxHouseNumber.Name = "textBoxHouseNumber";
            this.textBoxHouseNumber.Size = new System.Drawing.Size(89, 20);
            this.textBoxHouseNumber.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(378, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Выбор ЖК";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Название улицы";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(339, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Введите данные для дома";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(534, 138);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 33;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(213, 138);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 32;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // textBoxStreet
            // 
            this.textBoxStreet.Location = new System.Drawing.Point(6, 56);
            this.textBoxStreet.Name = "textBoxStreet";
            this.textBoxStreet.Size = new System.Drawing.Size(168, 20);
            this.textBoxStreet.TabIndex = 31;
            // 
            // comboBoxResidentialComplex
            // 
            this.comboBoxResidentialComplex.FormattingEnabled = true;
            this.comboBoxResidentialComplex.Location = new System.Drawing.Point(342, 55);
            this.comboBoxResidentialComplex.Name = "comboBoxResidentialComplex";
            this.comboBoxResidentialComplex.Size = new System.Drawing.Size(133, 21);
            this.comboBoxResidentialComplex.TabIndex = 30;
            // 
            // textBoxConstructionCost
            // 
            this.textBoxConstructionCost.Location = new System.Drawing.Point(502, 56);
            this.textBoxConstructionCost.Name = "textBoxConstructionCost";
            this.textBoxConstructionCost.Size = new System.Drawing.Size(131, 20);
            this.textBoxConstructionCost.TabIndex = 43;
            // 
            // EditHouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 182);
            this.Controls.Add(this.textBoxConstructionCost);
            this.Controls.Add(this.textBoxValueAdded);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxHouseNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.textBoxStreet);
            this.Controls.Add(this.comboBoxResidentialComplex);
            this.Name = "EditHouse";
            this.Text = "EditHouse";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxValueAdded;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxHouseNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox textBoxStreet;
        private System.Windows.Forms.ComboBox comboBoxResidentialComplex;
        private System.Windows.Forms.TextBox textBoxConstructionCost;
    }
}