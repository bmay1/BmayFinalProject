﻿using MongoDB.Bson;
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
            txtState.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
            txtCapital.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
            txtYear.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
            txtMammal.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();
            txtBird.Text = dataGridView1.Rows[0].Cells[4].Value.ToString();
            txtGovernor.Text = dataGridView1.Rows[0].Cells[5].Value.ToString();
            txtId.Text = dataGridView1.Rows[0].Cells[6].Value.ToString();
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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            States s = new States(txtState.Text,txtCapital.Text,int.Parse(txtYear.Text), txtMammal.Text,txtBird.Text,txtGovernor.Text);
            collection.InsertOne(s);
            ReadAllDcouments();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var updateDef = Builders<States>.Update.Set("state",txtState.Text).Set("capital",txtCapital.Text).Set("year",txtYear.Text).Set("mammal",txtMammal.Text).Set("bird",txtBird.Text).Set("governor",txtGovernor.Text);
            collection.UpdateOne(s => s.Id == ObjectId.Parse(txtId.Text), updateDef);
            ReadAllDcouments();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            collection.DeleteOne(s=> s.Id == ObjectId.Parse(txtId.Text));
            ReadAllDcouments();
        }
    }
}
