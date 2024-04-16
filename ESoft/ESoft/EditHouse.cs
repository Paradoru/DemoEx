    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

namespace ESoft
{
    public partial class EditHouse : Form
    {
        private readonly ModelDB _db;
        private House _house;
        public event EventHandler HouseUpdated;

        public EditHouse(int houseId)
        {
            InitializeComponent();
            _db = new ModelDB();
            InitializeComboBox();
            _house = _db.House.FirstOrDefault(h => h.ID == houseId);
            PopulateFields();
        }

        private void InitializeComboBox()
        {
            comboBoxResidentialComplex.Items.AddRange(_db.ResidentialComplex.Where(rc => !rc.IsDeleted).Select(rc => rc.Name).ToArray());
        }

        private void PopulateFields()
        {
            if (_house != null)
            {
                textBoxStreet.Text = _house.Street;
                textBoxHouseNumber.Text = _house.Number;
                textBoxConstructionCost.Text = _house.BuildingCost.ToString();
                textBoxValueAdded.Text = _house.HouseValueAdded.ToString();
                comboBoxResidentialComplex.SelectedItem = _house.ResidentialComplex.Name;
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                if (_house == null)
                {
                    _house = new House();
                    _db.House.Add(_house);
                }

                _house.Street = textBoxStreet.Text.Trim();
                _house.Number = textBoxHouseNumber.Text.Trim();
                _house.BuildingCost = (int)Convert.ToDecimal(textBoxConstructionCost.Text);
                _house.HouseValueAdded = (int)Convert.ToDecimal(textBoxValueAdded.Text);
                _house.ResidentialComplex = _db.ResidentialComplex.FirstOrDefault(rc => rc.Name == comboBoxResidentialComplex.SelectedItem.ToString());

                _db.SaveChanges();
                MessageBox.Show("Данные сохранены успешно.");
                HouseUpdated?.Invoke(this, EventArgs.Empty); 
                this.DialogResult = DialogResult.OK; 
                this.Close();
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(textBoxStreet.Text) ||
                string.IsNullOrWhiteSpace(textBoxHouseNumber.Text) ||
                string.IsNullOrWhiteSpace(textBoxConstructionCost.Text) ||
                string.IsNullOrWhiteSpace(textBoxValueAdded.Text) ||
                comboBoxResidentialComplex.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return false;
            }

            decimal buildingCost, valueAdded;
            if (!decimal.TryParse(textBoxConstructionCost.Text, out buildingCost) ||
                !decimal.TryParse(textBoxValueAdded.Text, out valueAdded))
            {
                MessageBox.Show("Некорректный формат числовых данных.");
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
