using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESoft
{
    public partial class CreateZKH : Form
    {
        public CreateZKH()
        {
            InitializeComponent();
            btnSave.Text = "Создать";
            FillStatusComboBox();
        }
        private void FillStatusComboBox()
        {
            using (ModelDB db = new ModelDB())
            {
                var statuses = db.ResidentialComplex.Select(x => x.Status).Distinct().ToList();
                comboBoxStatus.Items.AddRange(statuses.ToArray());
            }
            comboBoxStatus.Items.Clear();
            comboBoxStatus.Items.AddRange(new string[] { "реализация", "строительство", "план" });
        }
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            using (ModelDB db = new ModelDB())
            {
                try
                {
                    ResidentialComplex zkhToSave = new ResidentialComplex
                    {
                        Name = textBoxName.Text,
                        Status = comboBoxStatus.SelectedItem?.ToString(),
                        BuildingCost = int.Parse(textBoxBuildingCost.Text),
                        ComplexValueAdded = int.Parse(textBoxComplexValueAdded.Text),
                        City = textBoxCity.Text
                    };

                    db.ResidentialComplex.Add(zkhToSave);
                    db.SaveChanges();

                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch (DbEntityValidationException ex)
                {
                    // Обработка ошибок валидации, если необходимо
                    MessageBox.Show("Ошибка при сохранении данных. Проверьте корректность введенных данных.");
                }
            }
        }
    }
}
