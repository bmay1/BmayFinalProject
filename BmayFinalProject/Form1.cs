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
        static MongoClient state = new MongoClient();
        static IMongoDatabase db = state.GetDatabase("States");
        static IMongoCollection<State> collection = db.GetCollection<State>("States");
        
        public void ReadAllDocuments()
        {
            List<State> list = collection.AsQueryable().ToList<State>();
            dataGridView1.DataSource = list;
            txtState.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
            txtCapital.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
            txtYear.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
            txtMammal.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();
            txtBird.Text = dataGridView1.Rows[0].Cells[4].Value.ToString();
            txtGovernor.Text = dataGridView1.Rows[0].Cells[5].Value.ToString();

        }
        public Form1()
        {
            InitializeComponent();
            ReadAllDocuments();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtState.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtCapital.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtYear.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtMammal.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtBird.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtGovernor.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            State s = new State(txtState.Text, txtCapital.Text, Int32.Parse(txtYear.Text), txtMammal.Text, txtBird.Text, txtGovernor.Text);
            collection.InsertOne(s);
            ReadAllDocuments();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var updateDB = Builders<State>.Update.Set("state", txtState.Text).Set("capital", txtCapital.Text).Set("year", txtYear.Text).Set("mammal", txtMammal.Text).Set("Bird", txtBird.Text).Set("governor", txtGovernor.Text);
            collection.UpdateOne(s => s.Id == ObjectId.Parse(txtId.Text), updateDB);
            ReadAllDocuments();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            collection.DeleteOne(s => s.Id == ObjectId.Parse(txtId.Text));
            ReadAllDocuments();
        }
    }
}
