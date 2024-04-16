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
    public partial class EditApartment : Form
    {
        public event EventHandler DataSaved; 
        protected virtual void OnDataSaved(EventArgs e)
        {
            DataSaved?.Invoke(this, e);
        }
        private readonly ModelDB _db;
        private readonly ApartmentListForm _apartmentListForm;
        private Apartment _apartment;

        public EditApartment(Apartment apartment = null) 
        {
            InitializeComponent();
            _db = new ModelDB();
            _apartment = apartment ?? new Apartment();

            comboBoxStatus.Items.Add("Продана");
            comboBoxStatus.Items.Add("Продается");

            InitializeControls();
            PopulateResidentialComplexes();
            if (_apartment != null)
            {
                PopulateApartmentData();
            }
        }

        private void InitializeControls()
        {
            comboBoxZKH.SelectedValueChanged += ComboBoxZKH_SelectedValueChanged;
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
        }
        private void ComboBoxZKH_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBoxZKH.SelectedValue != null)
            {
                int residentialComplexId = (int)comboBoxZKH.SelectedValue;
                PopulateHouses(residentialComplexId);
            }
            else
            {
                comboBoxHouse.DataSource = null;
            }
        }

        private void PopulateResidentialComplexes()
        {
            comboBoxZKH.DisplayMember = "Name";
            comboBoxZKH.ValueMember = "ID";
            comboBoxZKH.DataSource = _db.ResidentialComplex.ToList();
        }

        private void PopulateHouses(int residentialComplexId)
        {
            comboBoxHouse.DisplayMember = "FullAddress";
            comboBoxHouse.ValueMember = "ID";
            comboBoxHouse.DataSource = _db.House
                .Where(h => h.ResidentialComplexID == residentialComplexId)
                .ToList()
                .Select(h => new { ID = h.ID, FullAddress = h.Street + " " + h.Number })
                .ToList();
        }

        private void PopulateApartmentData()
        {
            if (_apartment != null && _apartment.House != null)
            {
                comboBoxZKH.SelectedValue = _apartment.House.ResidentialComplexID;
                PopulateHouses(_apartment.House.ResidentialComplexID);
                comboBoxHouse.SelectedValue = _apartment.HouseID;
                numericNumber.Value = decimal.Parse(_apartment.Number);
                textBoxSquare.Text = _apartment.Area.ToString();
                numericRooms.Value = _apartment.CountOfRooms;
                numericSection.Value = _apartment.Section;
                numericFloor.Value = _apartment.Floor;
                foreach (var item in comboBoxStatus.Items)
                {
                    Console.WriteLine($"Элемент списка comboBoxStatus: {item}");
                }
                comboBoxStatus.SelectedItem = _apartment.IsSold ? "Продана" : "Продается";
                textBoxConstructionCost.Text = _apartment.BuildingCost.ToString();
                textBoxValueAdded.Text = _apartment.ApartmentValueAdded.ToString();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                try
                {
                    SaveChanges();
                    OnDataSaved(EventArgs.Empty);
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error while saving data: {ex.Message}");
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                try
                {
                    SaveNewApartment();
                    OnDataSaved(EventArgs.Empty);
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error while saving data: {ex.Message}");
                }
            }
        }
        private void SaveNewApartment()
        {
            _apartment = new Apartment(); // Инициализируем объект _apartment
            _apartment.HouseID = (int)comboBoxHouse.SelectedValue;
            _apartment.Number = numericNumber.Value.ToString();
            _apartment.Area = (double)decimal.Parse(textBoxSquare.Text);
            _apartment.CountOfRooms = (int)numericRooms.Value;
            _apartment.Section = (int)numericSection.Value;
            _apartment.Floor = (int)numericFloor.Value;
            _apartment.IsSold = comboBoxStatus.SelectedItem.ToString() == "Продана";
            _apartment.BuildingCost = int.Parse(textBoxConstructionCost.Text);
            _apartment.ApartmentValueAdded = int.Parse(textBoxValueAdded.Text);

            _db.Apartment.Add(_apartment);
            _db.SaveChanges();
        }

        private bool ValidateData()
        {
            if (string.IsNullOrWhiteSpace(textBoxSquare.Text) ||
                string.IsNullOrWhiteSpace(textBoxConstructionCost.Text) ||
                string.IsNullOrWhiteSpace(textBoxValueAdded.Text) ||
                comboBoxHouse.SelectedValue == null ||
                comboBoxStatus.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all required fields.");
                return false;
            }

            return true;
        }

        private void SaveChanges()
        {
            if (_apartment == null)
            {
                MessageBox.Show("Apartment object is null. Cannot save changes.");
                return; // Возврат из метода, если объект _apartment равен null
            }
            else
            {
                _apartment = _db.Apartment.Find(_apartment.ID);
            }

            _apartment.HouseID = (int)comboBoxHouse.SelectedValue;
            _apartment.Number = numericNumber.Value.ToString();
            _apartment.Area = (double)decimal.Parse(textBoxSquare.Text);
            _apartment.CountOfRooms = (int)numericRooms.Value;
            _apartment.Section = (int)numericSection.Value;
            _apartment.Floor = (int)numericFloor.Value;
            _apartment.IsSold = comboBoxStatus.SelectedItem.ToString() == "Продана";
            _apartment.BuildingCost = int.Parse(textBoxConstructionCost.Text);
            _apartment.ApartmentValueAdded = int.Parse(textBoxValueAdded.Text);

            _db.SaveChanges();
        }
    }
}
