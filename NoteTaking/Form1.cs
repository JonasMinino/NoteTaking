using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteTaking
{
    public partial class Notepad : Form
    {
        DataTable table;
        private int index = -1;

        public Notepad()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Creates a table with two columns during load.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Notepad_Load(object sender, EventArgs e)
        {
            table = new DataTable();
            table.Columns.Add("Title", typeof(string));
            table.Columns.Add("Message", typeof(string));

            dgbList.DataSource = table;
            dgbList.Columns["Message"].Visible = false;
            dgbList.Columns["Title"].Width = 240;


        }
        /// <summary>
        /// Clears the Title and Message textboxes on click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            txtMessage.Clear();
            txtTitle.Clear();
            index = -1;
        }
        /// <summary>
        /// Adds the title and message to the corresponding table columns.
        /// Clears the Title and Message textboxes.
        /// Edits existing entries.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (index > -1)
            {
                table.Rows[index].SetField("Title", txtTitle.Text);
                table.Rows[index].SetField("Message", txtMessage.Text);
            }
            else
            {
                table.Rows.Add(txtTitle.Text, txtMessage.Text);
            }

            txtMessage.Clear();
            txtTitle.Clear();
        }
        /// <summary>
        /// Displays the title and message of the current table  cell in the corresponding textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRead_Click(object sender, EventArgs e)
        {
            index = dgbList.CurrentCell.RowIndex;

            if (index > -1)
            {
                txtTitle.Text = table.Rows[index].ItemArray[0].ToString();
                txtMessage.Text = table.Rows[index].ItemArray[1].ToString();
            }

        }
        /// <summary>
        /// Deletes the row for the selected cell
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            index = dgbList.CurrentCell.RowIndex;

            table.Rows[index].Delete();
            txtMessage.Clear();
            txtTitle.Clear();
        }

    }
}
