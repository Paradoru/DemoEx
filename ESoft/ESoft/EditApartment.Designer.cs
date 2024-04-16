namespace ESoft
{
    partial class EditApartment
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.comboBoxZKH = new System.Windows.Forms.ComboBox();
            this.entityCommand1 = new System.Data.Entity.Core.EntityClient.EntityCommand();
            this.comboBoxHouse = new System.Windows.Forms.ComboBox();
            this.textBoxSquare = new System.Windows.Forms.TextBox();
            this.numericRooms = new System.Windows.Forms.NumericUpDown();
            this.numericSection = new System.Windows.Forms.NumericUpDown();
            this.numericFloor = new System.Windows.Forms.NumericUpDown();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.textBoxConstructionCost = new System.Windows.Forms.TextBox();
            this.textBoxValueAdded = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.numericNumber = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericRooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericFloor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label1.Size = new System.Drawing.Size(800, 22);
            this.label1.TabIndex = 34;
            this.label1.Text = "Введите данные комплекса";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(453, 190);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 33;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(253, 190);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 32;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // comboBoxZKH
            // 
            this.comboBoxZKH.FormattingEnabled = true;
            this.comboBoxZKH.Location = new System.Drawing.Point(12, 51);
            this.comboBoxZKH.Name = "comboBoxZKH";
            this.comboBoxZKH.Size = new System.Drawing.Size(138, 21);
            this.comboBoxZKH.TabIndex = 35;
            // 
            // entityCommand1
            // 
            this.entityCommand1.CommandTimeout = 0;
            this.entityCommand1.CommandTree = null;
            this.entityCommand1.Connection = null;
            this.entityCommand1.EnablePlanCaching = true;
            this.entityCommand1.Transaction = null;
            // 
            // comboBoxHouse
            // 
            this.comboBoxHouse.FormattingEnabled = true;
            this.comboBoxHouse.Location = new System.Drawing.Point(165, 51);
            this.comboBoxHouse.Name = "comboBoxHouse";
            this.comboBoxHouse.Size = new System.Drawing.Size(163, 21);
            this.comboBoxHouse.TabIndex = 36;
            // 
            // textBoxSquare
            // 
            this.textBoxSquare.Location = new System.Drawing.Point(497, 52);
            this.textBoxSquare.Name = "textBoxSquare";
            this.textBoxSquare.Size = new System.Drawing.Size(100, 20);
            this.textBoxSquare.TabIndex = 38;
            // 
            // numericRooms
            // 
            this.numericRooms.Location = new System.Drawing.Point(640, 53);
            this.numericRooms.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericRooms.Name = "numericRooms";
            this.numericRooms.Size = new System.Drawing.Size(109, 20);
            this.numericRooms.TabIndex = 39;
            // 
            // numericSection
            // 
            this.numericSection.Location = new System.Drawing.Point(21, 133);
            this.numericSection.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericSection.Name = "numericSection";
            this.numericSection.Size = new System.Drawing.Size(109, 20);
            this.numericSection.TabIndex = 40;
            // 
            // numericFloor
            // 
            this.numericFloor.Location = new System.Drawing.Point(190, 132);
            this.numericFloor.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericFloor.Name = "numericFloor";
            this.numericFloor.Size = new System.Drawing.Size(109, 20);
            this.numericFloor.TabIndex = 41;
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Location = new System.Drawing.Point(340, 132);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(114, 21);
            this.comboBoxStatus.TabIndex = 42;
            // 
            // textBoxConstructionCost
            // 
            this.textBoxConstructionCost.Location = new System.Drawing.Point(497, 131);
            this.textBoxConstructionCost.Name = "textBoxConstructionCost";
            this.textBoxConstructionCost.Size = new System.Drawing.Size(100, 20);
            this.textBoxConstructionCost.TabIndex = 43;
            // 
            // textBoxValueAdded
            // 
            this.textBoxValueAdded.Location = new System.Drawing.Point(640, 133);
            this.textBoxValueAdded.Name = "textBoxValueAdded";
            this.textBoxValueAdded.Size = new System.Drawing.Size(109, 20);
            this.textBoxValueAdded.TabIndex = 44;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 45;
            this.label2.Text = "ЖК";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(187, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 13);
            this.label3.TabIndex = 46;
            this.label3.Text = "Дом в выбранной ЖК";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(361, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 47;
            this.label4.Text = "Номер квартиры";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(515, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 48;
            this.label5.Text = "Площадь";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(643, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 13);
            this.label6.TabIndex = 49;
            this.label6.Text = "Количество комнат";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(49, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 50;
            this.label7.Text = "Подъезд";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(224, 114);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 51;
            this.label8.Text = "Этаж";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(377, 114);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 52;
            this.label9.Text = "Статус";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(482, 114);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(144, 13);
            this.label10.TabIndex = 53;
            this.label10.Text = "КФ добавочной стоимости";
            // 
            // numericNumber
            // 
            this.numericNumber.Location = new System.Drawing.Point(355, 51);
            this.numericNumber.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericNumber.Name = "numericNumber";
            this.numericNumber.Size = new System.Drawing.Size(109, 20);
            this.numericNumber.TabIndex = 55;
            // 
            // label11
            // 
            this.label11.AutoEllipsis = true;
            this.label11.Location = new System.Drawing.Point(637, 102);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(125, 28);
            this.label11.TabIndex = 56;
            this.label11.Text = "Затраты компании на строительство дома";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EditApartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 225);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.numericNumber);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxValueAdded);
            this.Controls.Add(this.textBoxConstructionCost);
            this.Controls.Add(this.comboBoxStatus);
            this.Controls.Add(this.numericFloor);
            this.Controls.Add(this.numericSection);
            this.Controls.Add(this.numericRooms);
            this.Controls.Add(this.textBoxSquare);
            this.Controls.Add(this.comboBoxHouse);
            this.Controls.Add(this.comboBoxZKH);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Name = "EditApartment";
            this.Text = "EditApartament";
            ((System.ComponentModel.ISupportInitialize)(this.numericRooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericFloor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox comboBoxZKH;
        private System.Data.Entity.Core.EntityClient.EntityCommand entityCommand1;
        private System.Windows.Forms.ComboBox comboBoxHouse;
        private System.Windows.Forms.TextBox textBoxSquare;
        private System.Windows.Forms.NumericUpDown numericRooms;
        private System.Windows.Forms.NumericUpDown numericSection;
        private System.Windows.Forms.NumericUpDown numericFloor;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.TextBox textBoxConstructionCost;
        private System.Windows.Forms.TextBox textBoxValueAdded;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericNumber;
        private System.Windows.Forms.Label label11;
    }
}