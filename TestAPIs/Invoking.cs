using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using System.Xml;

namespace TestAPIs
{
    public partial class Invoking : Form
    {
        public Invoking()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            MyService1.Service1Client client = new MyService1.Service1Client();

            textBox1.Text = client.GetData(1);

            DataTable dt = client.getmydata("dd");
            dataGridView1.DataSource = dt;


            //using (MyService1.Service1Client svc = new MyService1.Service1Client())
            //{
            //    XmlNode node = svc.getmydata("s");
            //    DataSet ds = new DataSet();
            //    using (XmlNodeReader reader = new XmlNodeReader(node))
            //    {
            //        ds.ReadXml(reader);
            //    }


            //    DataTable table = ds.Tables["Table"];
            //    DataRow row = table.Rows[0];
            //    string Lastname = (string)row["lastname"];
            //    string Firstname = (string)row["firstname"];
            //    string Middlename = (string)row["middlename "];
            //    string email = (string)row["emailaddress"];
            //    string Phone = (string)row["phonenumber"];
            //}
            //client.

            //Service1Client client = new Service1Client();

            //// Use the 'client' variable to call operations on the service.

            //// Always close the client.
            //client.Close();

        }
    }
}
