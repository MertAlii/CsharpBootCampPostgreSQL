using Npgsql;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string connectionString = "Server=localhost;port=5432;Database=CustomerDb;user Id=postegres;Password=123456";

        void GetAllCustomer()
        {
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM Customers";
            var command = new NpgsqlCommand(query, connection);
            var adapter = new NpgsqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            connection.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCustomerList_Click(object sender, EventArgs e)
        {
            GetAllCustomer();
        }

        private void btnCustomerCreate_Click(object sender, EventArgs e)
        {
            string customerName = txtCustomerName.Text;
            string customerCity = txtCustomerCity.Text;
            string customerSurname = txtCustomerSurname.Text;
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "INSERT INTO Customers (customerName, customerSurname, customerCity) VALUES (@customername, @customersurname, @customercity)";
            var command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@customername", customerName);
            command.Parameters.AddWithValue("@customersurname", customerSurname);
            command.Parameters.AddWithValue("@customercity", customerCity);
            command.ExecuteNonQuery();
            MessageBox.Show("Ekleme İşlemi Başarılı");
            connection.Close();
            GetAllCustomer();
        }

        private void btnCustomerDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCustomerId.Text);
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "DELETE FROM Customers WHERE CustomerId = @customerId";
            var command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@customerId", id);
            command.ExecuteNonQuery();
            MessageBox.Show("Silme İşlemi Başarılı");
            connection.Close();
            GetAllCustomer();
        }
    }
}
