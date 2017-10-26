using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TableOfPerson
{
    public partial class Form1 : Form
    {
        TableModel tm = new TableModel();

        public Form1()
        {
            InitializeComponent();

            comboDB.SelectedIndex = 0;

            tm.SetDataBase("MsSQL");
        }

        private Person GetPerson()
        {
            int id = Int32.Parse(txtId.Text);
            string fn = txtFirstName.Text;
            string ln = txtLastName.Text;
            int age = Int32.Parse(txtAge.Text);
            return new Person(id, fn, ln, age);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            tm.Create(GetPerson());
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = tm.Read();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            tm.Update(GetPerson());
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            tm.Delete(GetPerson());
        }

        private void comboDB_SelectedIndexChanged(object sender, EventArgs e)
        {
            tm.SetDataBase(comboDB.SelectedItem.ToString());
        }
        
    }
}
