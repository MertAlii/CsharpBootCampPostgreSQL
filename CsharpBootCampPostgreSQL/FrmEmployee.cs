using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsharpBootCampPostgreSQL
{
    public partial class FrmEmployee : Form
    {
        public FrmEmployee()
        {
            InitializeComponent();
        }

        string connectionString = "Server=localhost;port=5432;Database=CustomerDb;user Id=postegres;Password=123456";
        void EmployeeList()
        {
            var connection = new Npgsql.NpgsqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM Employess";
            var command = new Npgsql.NpgsqlCommand(query, connection);
            var adapter = new Npgsql.NpgsqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            connection.Close();
        }

        void DepartmentList()
        {
            var connection = new Npgsql.NpgsqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM Departments";
            var command = new Npgsql.NpgsqlCommand(query, connection);
            var adapter = new Npgsql.NpgsqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            cmbEmloyeeDepartment.DisplayMember = "DepartmentName";
            cmbEmloyeeDepartment.ValueMember = "DepartmentId";
            cmbEmloyeeDepartment.DataSource = dataTable;
            connection.Close();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            EmployeeList();
        }

        private void FrmEmployee_Load(object sender, EventArgs e)
        {
            EmployeeList();
            DepartmentList();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string employeeName = txtEmployeeName.Text;
            string employeeSurname = txtEmployeeSurname.Text;
            decimal employeeSalary = decimal.Parse(txtEmployeeSalary.Text);
            int departmenId = int.Parse(cmbEmloyeeDepartment.SelectedValue.ToString());

            var connection = new Npgsql.NpgsqlConnection(connectionString);
            connection.Open();
            string query = "INSERT INTO Employess (EmployeeName, EmployeeSurname, EmployeeSalary, DepartmentId) VALUES (@employeename, @employeesurname, @employeesalary, @departmentid)";
            var command = new Npgsql.NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@employeename", employeeName);
            command.Parameters.AddWithValue("@employeesurname", employeeSurname);
            command.Parameters.AddWithValue("@employeesalary", employeeSalary);
            command.Parameters.AddWithValue("@departmentid", departmenId);
            command.ExecuteNonQuery();
            MessageBox.Show("Ekleme işlemi başarılı");
            connection.Close();
            EmployeeList();

        }
    }
}
