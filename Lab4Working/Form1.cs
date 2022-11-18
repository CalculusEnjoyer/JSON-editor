using System.ComponentModel;
using System.Windows.Forms;

namespace Lab4Working
{
    public partial class Form1 : Form
    {
        private Boolean _isSaved = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void test1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void RefreshDataGrid(List<Laptop> laptops, DataGridView dataGridView)
        {
            dataGridView.ClearSelection();
            dataGridView.DataSource = null;
            dataGridView.DataSource = laptops;
        }

        private void AddToDataGrid(DataGridView dataGridView)
        {
            LaptopHandler.AddLaptop(Helper.CreateLaptopFromStringValues(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text,
                textBox5.Text, textBox6.Text, textBox7.Text));
            this.RefreshDataGrid(LaptopHandler.Laptops, dataGridView);
        }

        private void DeleteRows(DataGridView dataGridView)
        {
            foreach (DataGridViewRow row in dataGridView.SelectedRows)
            {
                LaptopHandler.Laptops.RemoveAt(row.Index);
            }
            this.RefreshDataGrid(LaptopHandler.Laptops, dataGridView1);
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Open json",

                CheckFileExists = true,
                CheckPathExists = true,

                Filter = "json files (*.json)|*.json;",
                DefaultExt = "json",

                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    LaptopHandler.FilePath = openFileDialog1.FileName;
                    LaptopHandler.Laptops = JsonConverter.DeserialiseFromJson(LaptopHandler.FilePath);
                    this.RefreshDataGrid(LaptopHandler.Laptops, dataGridView1);
                } catch (Exception ex)
                {
                    MessageBox.Show("Wrong file format", "Error: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.AddToDataGrid(dataGridView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DeleteRows(dataGridView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.RefreshDataGrid(LaptopHandler.Laptops, dataGridView1);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(LaptopHandler.FilePath))
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    InitialDirectory = @"D:\",
                    Title = "Save Json",

                    Filter = "json files (*.json)|*.json;",
                    DefaultExt = "json",
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    LaptopHandler.FilePath = saveFileDialog.FileName;
                    JsonConverter.SerializeToJson(LaptopHandler.FilePath, LaptopHandler.Laptops);
                    this.RefreshDataGrid(LaptopHandler.Laptops, dataGridView1);
                }
            }
            JsonConverter.SerializeToJson(LaptopHandler.FilePath, LaptopHandler.Laptops);
            _isSaved = true;
            MessageBox.Show("File was successfully saved at " + LaptopHandler.FilePath, "Json Converter");
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            _isSaved = false;
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            string properDataType = string.Empty;
            if (e.ColumnIndex == 0 || e.ColumnIndex == 4 || e.ColumnIndex == 6)
            {
                properDataType = "integer";
            } else if (e.ColumnIndex == 5)
            {
                properDataType = "double";
            }
            MessageBox.Show("Wrong data was entered. Only " + properDataType + " allowed.", 
                "Error: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            dataGridView1.CancelEdit();
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            double temp;
            if (double.TryParse(e.FormattedValue.ToString(), out temp) && temp <0)
            {
                    MessageBox.Show(dataGridView1.Columns[e.ColumnIndex].Name + " have to be greater than 0.",
                "Error: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
            }
        }

        private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Save Json",

                Filter = "json files (*.json)|*.json;",
                DefaultExt = "json",
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                LaptopHandler.FilePath = saveFileDialog.FileName;
                JsonConverter.SerializeToJson(LaptopHandler.FilePath, LaptopHandler.Laptops);
                _isSaved = true;
                this.RefreshDataGrid(LaptopHandler.Laptops, dataGridView1);
            }
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Save Json",

                Filter = "json files (*.json)|*.json;",
                DefaultExt = "json",
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                LaptopHandler.FilePath = saveFileDialog.FileName;
                JsonConverter.SerializeToJson(LaptopHandler.FilePath, new List<Laptop>());
                LaptopHandler.Laptops = JsonConverter.DeserialiseFromJson(LaptopHandler.FilePath);
                _isSaved = true;
                this.RefreshDataGrid(LaptopHandler.Laptops, dataGridView1);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LaptopHandler.FilteredLaptops = LaptopHandler.Laptops.ToList();
            if (checkBox1.Checked) LaptopHandler.FilteredLaptops = Filter.FilterByProducer(textBox8.Text, LaptopHandler.FilteredLaptops).ToList();
            if (checkBox2.Checked) LaptopHandler.FilteredLaptops = Filter.FilterByModel(textBox9.Text, LaptopHandler.FilteredLaptops).ToList();
            if (checkBox3.Checked) 
            {
                int year;
                if (!int.TryParse(textBox10.Text,out year))
                {
                    MessageBox.Show("Year have to be integer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                LaptopHandler.FilteredLaptops = Filter.FilterByYear(year, LaptopHandler.FilteredLaptops).ToList();
            }
            RefreshDataGrid(LaptopHandler.FilteredLaptops, dataGridView1);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isSaved) return;
            try
            {
                String msg = "Json is not saved. Do you want to save it before exit?";
                String caption = "Save Record";
                MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
                MessageBoxIcon ico = MessageBoxIcon.Question;
                DialogResult result;
                result = MessageBox.Show(this, msg, caption, buttons, ico);
                if (result == DialogResult.Yes)
                {
                    JsonConverter.SerializeToJson(LaptopHandler.FilePath, LaptopHandler.Laptops);
                    MessageBox.Show("Saved successfully", "Save update",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _isSaved = true;
                    Application.Exit();

                } else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else
                {
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Saving Failed:" + ex.Message.ToString(), "Save",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}