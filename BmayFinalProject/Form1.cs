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
    }
}
