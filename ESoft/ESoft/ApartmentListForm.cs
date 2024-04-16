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
    public partial class ApartmentListForm : Form
    {
        private EditApartment editApartmentForm;
        private readonly ModelDB _db;
        private BindingSource _apartmentBindingSource;
        private int _currentPage = 1;
        private int _totalPages;

        public ApartmentListForm()
        {
            InitializeComponent();
            _db = new ModelDB();
            InitializeControls();
            LoadApartments();
        }

        private void InitializeControls()
        {
            dataGridViewApartments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _apartmentBindingSource = new BindingSource();

            comboBoxZKH.DisplayMember = "Name";
            comboBoxZKH.ValueMember = "ID";
            comboBoxZKH.DataSource = _db.ResidentialComplex.ToList();

            dataGridViewApartments.AutoGenerateColumns = false;
            dataGridViewApartments.DataSource = _apartmentBindingSource;

            dataGridViewApartments.Columns.AddRange(
                new DataGridViewTextBoxColumn { Name = "ID", HeaderText = "ID", DataPropertyName = "ID" },
                new DataGridViewTextBoxColumn { Name = "ResidentialComplexName", HeaderText = "Жилой комплекс", DataPropertyName = "ResidentialComplexName" },
                new DataGridViewTextBoxColumn { Name = "Address", HeaderText = "Адрес", DataPropertyName = "Address" },
                new DataGridViewTextBoxColumn { Name = "Area", HeaderText = "Площадь", DataPropertyName = "Area" },
                new DataGridViewTextBoxColumn { Name = "CountOfRooms", HeaderText = "Кол-во комнат", DataPropertyName = "CountOfRooms" },
                new DataGridViewTextBoxColumn { Name = "Section", HeaderText = "Секция", DataPropertyName = "Section" },
                new DataGridViewTextBoxColumn { Name = "Floor", HeaderText = "Этаж", DataPropertyName = "Floor" },
                new DataGridViewTextBoxColumn { Name = "Status", HeaderText = "Статус", DataPropertyName = "Status" }
            );

            dataGridViewApartments.Columns["Address"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            comboBoxZKH.SelectedIndexChanged += FilterChanged;
            textBoxHouseNumber.TextChanged += FilterChanged;
            numericFloor.ValueChanged += FilterChanged;
            numericSection.ValueChanged += FilterChanged;
            radioBtnStatusSelled.CheckedChanged += FilterChanged;
            radioBtnStatusOnSell.CheckedChanged += FilterChanged;
            radioBtnStatusAll.CheckedChanged += FilterChanged;

            btnFirstPage.Click += BtnFirstPage_Click;
            btnPrevPage.Click += BtnPrevPage_Click;
            btnNextPage.Click += BtnNextPage_Click;
            btnLastPage.Click += BtnLastPage_Click;

            editApartmentForm = new EditApartment(null);

            editApartmentForm.DataSaved += EditApartmentForm_DataSaved;
        }
        private void EditApartmentForm_DataSaved(object sender, EventArgs e)
        {
            LoadApartments(); 
        }

        private void FilterChanged(object sender, EventArgs e)
        {
            _currentPage = 1;
            LoadApartments();
        }

        private void LoadApartments()
        {
            var selectedComplexId = comboBoxZKH.SelectedValue as int?;
            var houseNumber = string.IsNullOrEmpty(textBoxHouseNumber.Text) ? null : textBoxHouseNumber.Text;
            var floor = (int)numericFloor.Value;
            var section = (int)numericSection.Value;
            var isSold = radioBtnStatusSelled.Checked ? true :
                         radioBtnStatusOnSell.Checked ? false :
                         (bool?)null;

            var apartments = _db.Apartment
                .Where(a =>
                    (!selectedComplexId.HasValue || a.House.ResidentialComplexID == selectedComplexId) &&
                    (string.IsNullOrEmpty(houseNumber) || a.House.Number == houseNumber) &&
                    (floor == 0 || a.Floor == floor) &&
                    (section == 0 || a.Section == section) &&
                    (!isSold.HasValue || a.IsSold == isSold)
                )
                .ToList()
                .Select((a, index) => new
                {
                    ID = a.ID,
                    ResidentialComplexName = a.House.ResidentialComplex.Name,
                    Address = $"ул. {a.House.Street} д.{a.House.Number} кв.{a.Number}",
                    Area = a.Area,
                    CountOfRooms = a.CountOfRooms,
                    Section = a.Section,
                    Floor = a.Floor,
                    Status = a.IsSold ? "Продана" : "Продается"
                })
                .ToList();

            _totalPages = (int)Math.Ceiling((double)apartments.Count / 20);

            var currentPageApartments = apartments
                .Skip((_currentPage - 1) * 20)
                .Take(20)
                .ToList();

            _apartmentBindingSource.DataSource = currentPageApartments;

            UpdatePageInfo();
        }

        private void UpdatePageInfo()
        {
            labelPageInfo.Text = $"Страница {_currentPage} из {_totalPages}";
        }

        private void BtnFirstPage_Click(object sender, EventArgs e)
        {
            _currentPage = 1;
            LoadApartments();
        }

        private void BtnPrevPage_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                LoadApartments();
            }
        }

        private void BtnNextPage_Click(object sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                LoadApartments();
            }
        }

        private void BtnLastPage_Click(object sender, EventArgs e)
        {
            _currentPage = _totalPages;
            LoadApartments();
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewApartments.SelectedRows.Count > 0)
            {
                int apartmentId = (int)dataGridViewApartments.SelectedRows[0].Cells["ID"].Value;

                editApartmentForm = new EditApartment(_db.Apartment.Find(apartmentId));

                if (editApartmentForm.ShowDialog() == DialogResult.OK)
                {
                    LoadApartments();
                }
            }
            else
            {
                MessageBox.Show("Выберите квартиру для редактирования.");
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Создаем экземпляр формы редактирования и отображаем его как диалоговое окно
            EditApartment editApartmentForm = new EditApartment();
            if (editApartmentForm.ShowDialog() == DialogResult.OK)
            {
                LoadApartments(); // Перезагружаем список квартир после добавления новой
            }
        }
    }
}


