using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using Burgerklubben.Classes;

namespace Burgerklubben
{
    public partial class Info : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
           
            // Gets the data from the info object created in DAL through the InfoManager to be displayed in the labels on the Info page
            lblAboutUs.Text = InfoManager.GetInfo().AboutUs;
            lblStreetNameNumber.Text = InfoManager.GetInfo().StreetNameNumber + ", ";
            lblZipCode.Text = InfoManager.GetInfo().ZipCode.ToString();
            lblCity.Text = InfoManager.GetInfo().City;
            lblOpeningHours.Text = InfoManager.GetInfo().OpeningHours;
            lblEmail.Text = InfoManager.GetInfo().Email + " - ";
            lblPhone.Text = "Tlf: " + InfoManager.GetInfo().Phone.ToString();
        }
    }
}