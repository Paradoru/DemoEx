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
    public partial class HousesOfZKH : Form
    {
        private readonly ModelDB _db;

        public HousesOfZKH()
        {
            InitializeComponent();
            _db = new ModelDB();
            InitializeDataGridView();
            comboBoxZKH.Items.AddRange(_db.ResidentialComplex.Select(rc => rc.Name).ToArray());
            UpdateDataGrid();
        }

        private void InitializeDataGridView()
        {
            dataGridViewHouses.Columns.AddRange(
                new DataGridViewColumn[]
                {
                    new DataGridViewTextBoxColumn { Name = "ID", HeaderText = "ID", Visible = false },
                    new DataGridViewTextBoxColumn { Name = "ResidentialComplexName", HeaderText = "ЖК" },
                    new DataGridViewTextBoxColumn { Name = "Street", HeaderText = "Улица" },
                    new DataGridViewTextBoxColumn { Name = "Number", HeaderText = "Номер дома" },
                    new DataGridViewTextBoxColumn { Name = "Status", HeaderText = "Статус" },
                    new DataGridViewTextBoxColumn { Name = "SoldApartmentsCount", HeaderText = "Проданные квартиры" },
                    new DataGridViewTextBoxColumn { Name = "AvailableApartmentsCount", HeaderText = "Продающиюся квартиры" }
                });
        }

        private void UpdateDataGrid()
        {
            dataGridViewHouses.Rows.Clear();

            var houseNumberFilter = textBoxHouseNumber.Text.Trim();
            var selectedZKH = comboBoxZKH.SelectedItem?.ToString();

            var houses = _db.House
                .Where(h =>
                    (string.IsNullOrEmpty(houseNumberFilter) || h.Number == houseNumberFilter) &&
                    (string.IsNullOrEmpty(selectedZKH) || h.ResidentialComplex.Name == selectedZKH))
                .ToList();

            foreach (var house in houses)
            {
                int soldApartmentsCount = house.Apartment.Count(a => a.IsSold);
                int availableApartmentsCount = house.Apartment.Count(a => !a.IsSold);

                dataGridViewHouses.Rows.Add(
                    house.ID,
                    house.ResidentialComplex.Name,
                    house.Street,
                    house.Number,
                    house.ResidentialComplex.Status,
                    soldApartmentsCount,
                    availableApartmentsCount
                );
            }
        }

        private void comboBoxZKH_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            UpdateDataGrid();
        }

        private void textBoxHouseNumber_TextChanged_1(object sender, EventArgs e)
        {
            UpdateDataGrid();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new EditHouse(0))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    UpdateDataGrid();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewHouses.SelectedRows.Count > 0)
            {
                int houseId = (int)dataGridViewHouses.SelectedRows[0].Cells["ID"].Value;
                using (var form = new EditHouse(houseId))
                {
                    form.HouseUpdated += (s, ev) => UpdateDataGrid(); // Подписываемся на событие
                    form.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Выберите дом для редактирования.");
            }
        }



        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewHouses.SelectedRows.Count > 0)
            {
                int houseId = (int)dataGridViewHouses.SelectedRows[0].Cells["ID"].Value;
                var houseToDelete = _db.House.Find(houseId);

                if (houseToDelete != null)
                {
                    _db.House.Remove(houseToDelete);
                    _db.SaveChanges();
                    UpdateDataGrid();
                }
            }
            else
            {
                MessageBox.Show("Выберите дом для удаления.");
            }
        }
    }
}