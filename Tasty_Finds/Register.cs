using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tasty_Finds
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        //connecting the database
        static String databaseString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source= Database1.mdb";
        OleDbConnection database = new OleDbConnection(databaseString);
        OleDbCommand command = new OleDbCommand();

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                password.PasswordChar = '\0';
                confirmpassword.PasswordChar = '\0';
            }
            else
            {
                password.PasswordChar = '*';
                confirmpassword.PasswordChar = '*';
            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox3.Text = string.Empty;
            password.Text = string.Empty;
            confirmpassword.Text = string.Empty;
            textBox4.Text = string.Empty;


        }

        private void button1reg_Click(object sender, EventArgs e)
        {
            if(password == confirmpassword)
            {
                database.Open();
                String entry = "INSTERT INTO Table1 VALUES('" + textBox1.Text + "'', '" + textBox3.Text + "','" + textBox4.Text + "')";
                command = new OleDbCommand(entry, database);
                command.ExecuteNonQuery();
                database.Close();

                MessageBox.Show("Registration successful", "Good" , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Passwords do not match!" , "Error" , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Login().ShowDialog();

        }
    }
}
