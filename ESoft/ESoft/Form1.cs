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
    public partial class Form1 : Form
    {
        private readonly ModelDB _db;

        public Form1()
        {
            InitializeComponent();
            _db = new ModelDB();

            var cities = _db.ResidentialComplex.Where(x => !x.IsDeleted).Select(x => x.City).Distinct().ToList();
            comboBoxCity.Items.AddRange(cities.ToArray());
            var statuses = _db.ResidentialComplex.Where(y => !y.IsDeleted).Select(y => y.Status).Distinct().ToList();
            comboBoxStatus.Items.AddRange(statuses.ToArray());

            comboBoxCity.SelectedIndexChanged += (sender, e) => UpdateDataGrid();
            comboBoxStatus.SelectedIndexChanged += (sender, e) => UpdateDataGrid();
            UpdateDataGrid();
        }

        private void UpdateDataGrid()
        {
            string selectedCity = comboBoxCity.SelectedItem?.ToString();
            var zkhQuery = _db.ResidentialComplex
                .Where(x => !x.IsDeleted)
                .GroupJoin(_db.House,
                    u => u.ID,
                    c => c.ResidentialComplexID,
                    (u, c) => new
                    {
                        ID = u.ID,
                        Name = u.Name,
                        Status = u.Status,
                        BuildingCost = u.BuildingCost,
                        ComplexValueAdded = u.ComplexValueAdded,
                        Houses = c.Count(),
                        City = u.City
                    })
                .Distinct();

            if (!string.IsNullOrEmpty(selectedCity))
            {
                zkhQuery = zkhQuery.Where(x => x.City == selectedCity);
            }

            string selectedStatus = comboBoxStatus.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedStatus))
            {
                zkhQuery = zkhQuery.Where(x => x.Status == selectedStatus);
            }

            var sortedData = zkhQuery
                .OrderBy(x => x.City)
                .ThenBy(x => x.Status == "План" ? 1 : x.Status == "Строительство" ? 2 : 3)
                .ToList();

            dataGridView1.DataSource = sortedData;
        }

        private void btnAdd_Click_2(object sender, EventArgs e)
        {
            using (ModelDB db = new ModelDB())
            {
                using (EditZKH editForm = new EditZKH(db))
                {
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        UpdateDataGrid();
                    }
                }  
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                int selectedZKHId = (int)dataGridView1.Rows[selectedRowIndex].Cells["ID"].Value;

                ResidentialComplex selectedZKH = _db.ResidentialComplex.Find(selectedZKHId);

                if (selectedZKH != null)
                {
                    using (EditZKH editForm = new EditZKH(selectedZKH))
                    {
                        if (editForm.ShowDialog() == DialogResult.OK)
                        {
                            UpdateDataGrid();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Выбранный ЖК не найден в базе данных.");
                }
            }
            else
            {
                MessageBox.Show("Выберите ЖК для редактирования.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                int selectedZKHId = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["ID"].Value);
                var zkhToDelete = _db.ResidentialComplex.Find(selectedZKHId);

                if (zkhToDelete != null)
                {
                    zkhToDelete.IsDeleted = true;
                    _db.SaveChanges();
                    UpdateDataGrid();
                }
            }
            else
            {
                MessageBox.Show("Выберите ЖК для удаления.");
            }
        }
        private void btnHouses_Click(object sender, EventArgs e)
        {
            HousesOfZKH HousesOfZKH = new HousesOfZKH();
            HousesOfZKH.ShowDialog();
        }

        private void btnApartments_Click(object sender, EventArgs e)
        {
            ApartmentListForm ApartmentListForm = new ApartmentListForm();
            ApartmentListForm.ShowDialog();
        }
    }
}
