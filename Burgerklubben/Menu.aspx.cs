using Burgerklubben.Classes;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Burgerklubben
{
    public partial class Menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ImgEasterEgg.Visible = false;
        }
       // When a button in the Burger Menu is clicked it redirects to the order page.
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Response.Redirect("Order.aspx");
        }

        // When a button in the Burger Menu is clicked it redirects to the order page.
        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {                   
            Response.Redirect("Order.aspx");
        }
        
        // User search. When button is clicked a list of products containing the search parameter is being displayed in the label on the Menu page.
        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            #region EasterEgg
            if (txtSearch.Text == "ninjaburger")
            {
                ImgEasterEgg.Visible = true;
            }
            #endregion EasterEgg
            List<Product> searchList = new ProductManager().GetSearch(txtSearch.Text);

            String sb = "<table>";

            foreach (Product item in searchList)
            {
                sb = sb + ("<tr><td>" + item.PName + ", " + item.Price + " kr., " + item.PDescription + "</td></tr>" + "<tr><td><br /></td></tr>");
            }

            sb = sb + ("</table>");

          

            lblSearchResult.Text = sb;
            txtSearch.Text = "";
        }

        //protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Response.Redirect("Order.aspx");
        //}
    }
}