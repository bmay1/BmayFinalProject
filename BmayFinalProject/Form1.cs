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
        //Collects information form MongDB.
        //Database in MongoDB is 'statesDB'.
        //The collection on MongoDB is called  'states'.

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

            txtState.Text = "";
            txtCapital.Text = "";
            txtYear.Text = "";
            txtMammal.Text = "";
            txtBird.Text = "";
            txtGovernor.Text = "";

        }

        public Form1()
        {
            InitializeComponent();
            ReadAllDcouments();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Gridview shows list of state, state's capital, year of becoming a state, state's mammal,
            //state's bird and state's governor.
            //The id is coming from the database. It is self generated.

            txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtState.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtCapital.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtYear.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtMammal.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtBird.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtGovernor.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();




        }

        private void button1_Click(object sender, EventArgs e)
        {

            //Insert Button.
            //Insert new information into gridview and database.

            if (txtState.Text == "" || txtCapital.Text == "" || txtYear.Text == "" || txtMammal.Text == "" || txtBird.Text == "" || txtGovernor.Text == "")
            {
                MessageBox.Show("Please fill in each textbox.");
            }
            else
            {
                try
                {
                    States s = new States(txtState.Text, txtCapital.Text, int.Parse(txtYear.Text), txtMammal.Text, txtBird.Text, txtGovernor.Text);
                    collection.InsertOne(s);
                    ReadAllDcouments();

                    txtState.Text = "";
                    txtCapital.Text = "";
                    txtYear.Text = "";
                    txtMammal.Text = "";
                    txtBird.Text = "";
                    txtGovernor.Text = "";

                    MessageBox.Show("Inert Into Database Succesfully!");
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
            //Update Button.
            //Update's inforation when changes are made to any state's that are alreay listed.

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

                    txtState.Text = "";
                    txtCapital.Text = "";
                    txtYear.Text = "";
                    txtMammal.Text = "";
                    txtBird.Text = "";
                    txtGovernor.Text = "";

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

            //Delete Button.
            //Delete's information on gridview and database.

            if (txtState.Text == "" || txtCapital.Text == "" || txtYear.Text == "" || txtMammal.Text == "" || txtBird.Text == "" || txtGovernor.Text == "")
            {
                MessageBox.Show("Textboxes cannot be empty");
            }
            else
            {
                try
                {
                    collection.DeleteOne(s => s.Id == ObjectId.Parse(txtId.Text));
                    ReadAllDcouments();

                    txtState.Text = "";
                    txtCapital.Text = "";
                    txtYear.Text = "";
                    txtMammal.Text = "";
                    txtBird.Text = "";
                    txtGovernor.Text = "";

                    MessageBox.Show("Delete was successful!");
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //Exit button.
            //Gives user option to exit or not to exit the program.

            DialogResult dialog = MessageBox.Show("Do you really want to close the program?",
                "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                this.Close();
            }
            else if (dialog == DialogResult.No)
            {
              
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
