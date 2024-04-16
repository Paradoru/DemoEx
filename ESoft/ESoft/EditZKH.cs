using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 
using System.Windows.Forms.VisualStyles;

namespace ESoft
{
    public partial class EditZKH : Form
    {
        private ResidentialComplex _zkhToEdit;
        private ModelDB _db;

        public EditZKH(ModelDB dbContext)
        {
            InitializeComponent();
            btnSave.Text = "Добавить";
            _db = dbContext;
            FillStatusComboBox();
            _zkhToEdit = new ResidentialComplex();
        }

        public EditZKH(ResidentialComplex zkhToEdit)
        {
            InitializeComponent();
            FillData(zkhToEdit);
            FillStatusComboBox();
            _zkhToEdit = zkhToEdit;
        }

        private void FillData(ResidentialComplex zkhToEdit)
        {
            _zkhToEdit = zkhToEdit;
            textBoxName.Text = zkhToEdit.Name;
            comboBoxStatus.SelectedItem = zkhToEdit.Status;
            textBoxCity.Text = zkhToEdit.City;
            textBoxBuildingCost.Text = zkhToEdit.BuildingCost.ToString();
            textBoxComplexValueAdded.Text = zkhToEdit.ComplexValueAdded.ToString();
            FillHousesDataGridView(zkhToEdit.ID);
        }

        private void FillHousesDataGridView(int residentialComplexID)
        {
            using (ModelDB db = new ModelDB())
            {
                var houses = db.House
                                .Where(h => h.ResidentialComplexID == residentialComplexID)
                                .Select(h => new { h.Street, h.Number })
                                .ToList();
                HousesDataGridView.DataSource = houses;
            }
        }

        private void FillStatusComboBox()
        {
            comboBoxStatus.Items.AddRange(new string[] { "реализация", "строительство", "план" });
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            using (ModelDB db = new ModelDB())
            {
                try
                {
                    ResidentialComplex zkhToSave;
                    zkhToSave = db.ResidentialComplex.Find(_zkhToEdit.ID);

                    if (zkhToSave != null)
                    {
                        Console.WriteLine($"Найден объект в базе данных: ID = {_zkhToEdit.ID}, Name = {zkhToSave.Name}");
                        zkhToSave.Name = textBoxName.Text;
                        zkhToSave.City = textBoxCity.Text;
                        zkhToSave.Status = comboBoxStatus.SelectedItem?.ToString();
                        zkhToSave.BuildingCost = int.Parse(textBoxBuildingCost.Text);
                        zkhToSave.ComplexValueAdded = int.Parse(textBoxComplexValueAdded.Text);
                        db.Entry(zkhToSave).State = EntityState.Modified;
                        if (zkhToSave.Status == "план" && db.House.Any(h => h.ResidentialComplexID == zkhToSave.ID && db.Apartment.Any(a => a.HouseID == h.ID && a.IsSold)))
                        {
                            MessageBox.Show("Нельзя установить статус 'план', так как есть проданные квартиры в этом жилищном комплексе.");
                            return;
                        }
                    }
                    else
                    {
                        zkhToSave = new ResidentialComplex
                        {
                            Name = textBoxName.Text,
                            City = textBoxCity.Text,
                            Status = comboBoxStatus.SelectedItem?.ToString(),
                            BuildingCost = int.Parse(textBoxBuildingCost.Text),
                            ComplexValueAdded = int.Parse(textBoxComplexValueAdded.Text)
                        };
                        db.ResidentialComplex.Add(zkhToSave);
                    }

                    db.SaveChanges();
                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch (DbEntityValidationException ex)
                {
                    MessageBox.Show("Ошибка при сохранении данных. Проверьте корректность введенных данных.");
                }
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            using (ModelDB db = new ModelDB())
            {
                if (_zkhToEdit != null)
                {
                    ResidentialComplex zkhToDelete = db.ResidentialComplex.Find(_zkhToEdit.ID);
                    if (zkhToDelete != null)
                    {
                        zkhToDelete.IsDeleted = true;
                        db.SaveChanges(); 
                    }
                }
            }
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
