using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShipperClient.NwService;

namespace ShipperClient
{
    public partial class Index : System.Web.UI.Page
    {
        private ShipperServiceClient host;
        public Index()
        {
            host = new ShipperServiceClient();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TextBox2.Text = host.GetShipperByID(Convert.ToInt32(TextBox1.Text)).ShipperID.ToString();
            TextBox3.Text = host.GetShipperByID(Convert.ToInt32(TextBox1.Text)).CompanyName;
            TextBox4.Text = host.GetShipperByID(Convert.ToInt32(TextBox1.Text)).Phone;

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            host.UpdateShipper(Convert.ToInt32(TextBox2.Text), TextBox3.Text, TextBox4.Text);
        }
    }
}