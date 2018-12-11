using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BmayFinalProject
{
    public partial class Form1 : Form
    {
        static MongoClient information = new MongoClient();
        static IMongoDatabase db = information.GetDatabase("statesDB");
        static IMongoCollection<States> collection = db.GetCollection<States>("states");

        public void ReadAllDcouments()
        {
            List<States> list = collection.AsQueryable().ToList<States>();
            dataGridView1.DataSource = list;
            txtId.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
            txtState.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
            txtCapital.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
            txtYear.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();
            txtMammal.Text = dataGridView1.Rows[0].Cells[4].Value.ToString();
            txtBird.Text = dataGridView1.Rows[0].Cells[5].Value.ToString();
            txtGovernor.Text = dataGridView1.Rows[0].Cells[6].Value.ToString();

        }

        public Form1()
        {
            InitializeComponent();
            ReadAllDcouments();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtState.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtCapital.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtYear.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtMammal.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtBird.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtGovernor.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();

            //txtState.Text = "";
            //txtCapital.Text = "";
            //txtYear.Text = "";
            //txtMammal.Text = "";
            //txtBird.Text = "";
            //txtGovernor.Text = "";
        

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtState.Text == "" || txtCapital.Text == "" || txtYear.Text == "" || txtMammal.Text == "" || txtBird.Text == "" || txtGovernor.Text == "")
            {

            }
            else
            {
                try
                {
                    States s = new States(txtState.Text, txtCapital.Text, int.Parse(txtYear.Text), txtMammal.Text, txtBird.Text, txtGovernor.Text);
                    collection.InsertOne(s);
                    ReadAllDcouments();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (txtState.Text == "" || txtCapital.Text == "" || txtYear.Text == "" || txtMammal.Text == "" || txtBird.Text == "" || txtGovernor.Text == "")
            {
                MessageBox.Show("Please fill in each textbox.");
            }
            else
            {
                try
                {
                    var updateDef = Builders<States>.Update.Set("state", txtState.Text).Set("capital", txtCapital.Text).Set("year", txtYear.Text).Set("mammal", txtMammal.Text).Set("bird", txtBird.Text).Set("governor", txtGovernor.Text);
                    collection.UpdateOne(s => s.Id == ObjectId.Parse(txtId.Text), updateDef);
                    ReadAllDcouments();
                    MessageBox.Show("Update Database Succesfully!");
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            collection.DeleteOne(s=> s.Id == ObjectId.Parse(txtId.Text));
            ReadAllDcouments();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
