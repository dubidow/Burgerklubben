using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Burgerklubben.Classes;

namespace Burgerklubben
{
    public partial class AdminCrud : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Redirects to Login page if AdminCrud is typed in the browser bar without a known user is logged in.
            #region RestrictedAccess
            if (Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            lblUserDetails.Text = "Username :" + Session["UserName"];
            #endregion RestrictedAccess

            // Hides labels, textboxes and one button at pageload.
            lblIdentifier.Visible = false;
            txtIdentifier.Visible = false;
            lblNewData.Visible = false;
            txtNewData.Visible = false;
            btnPickSP.Visible = true;
            btnExecuteSP.Visible = false;
            lblTryCatchSP.Visible = false;
            lblTryCatchSet.Visible = false;

        }

        // Closes the users session and redirects to the frontpage when logoutbutton is clicked.
        #region LogoutButton
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Frontpage.aspx");
        }
        #endregion LogoutButton 

        // Stores the users choice of which action is wanted, to be used to to activate the proper Stored Procedure.
        // Depending on Info or Product to be updated different label texts are shown, since email is to be used for infoUpdate and pName for ProductUpdate.
        #region PickSPButton
        protected void btnPickSp_Click(object sender, EventArgs e)
        {
            int index = SPMenu.SelectedIndex;
            if (index >= 1 && index <= 6)
            {
                lblIdentifier.Visible = true;
                txtIdentifier.Visible = true;
                lblNewData.Visible = true;
                txtNewData.Visible = true;
                btnPickSP.Visible = false;
                btnExecuteSP.Visible = true;
                lblIdentifier.Text = "Email";

            }

            else if (index >= 7 && index <= 11)
            {
                lblIdentifier.Visible = true;
                txtIdentifier.Visible = true;
                lblNewData.Visible = true;
                txtNewData.Visible = true;
                btnPickSP.Visible = false;
                btnExecuteSP.Visible = true;
                lblIdentifier.Text = "Produkt navn";
            }
            else if (index == 12)
            {
                lblIdentifier.Visible = true;
                txtIdentifier.Visible = true;
                lblNewData.Visible = false;
                txtNewData.Visible = false;
                btnPickSP.Visible = false;
                btnExecuteSP.Visible = true;
                lblIdentifier.Text = "Produkt Navn";
            }
        }
        #endregion PickSPButton

        // Sends new data to DAl through the InfomManager/ProductManager.
        // Displays message to the AdminUser.
        #region ExecuteSPButton
        protected void btnExecuteSP_Click(object sender, EventArgs e)
        {

            btnPickSP.Visible = true;
            btnExecuteSP.Visible = false;
            int index = SPMenu.SelectedIndex;
     
            switch (index)
            {
                case 0:
                    bool successfull = false;
                    break;

                case 1:
                    successfull = new InfoManager().InfoUpdateAboutUs(txtIdentifier.Text.Trim(), txtNewData.Text.Trim());

                    if (successfull == true)
                    {
                        lblTryCatchSP.Visible = true;
                        lblTryCatchSP.Text = "Ninjaerne har opdateret!";
                        lblTryCatchSP.ForeColor = System.Drawing.Color.LightGreen;
                    }
                    else if (successfull == false)
                    {
                        lblTryCatchSP.Visible = true;
                        lblTryCatchSP.Text = "FEJL! Ninjaerne har IKKE opdateret!";
                        lblTryCatchSP.ForeColor = System.Drawing.Color.Red;

                    }
                    break;

                case 2:
                    successfull = new InfoManager().InfoUpdateEmail(txtIdentifier.Text.Trim(), txtNewData.Text.Trim());

                    if (successfull == true)
                    {
                        lblTryCatchSP.Visible = true;
                        lblTryCatchSP.Text = "Ninjaerne har opdateret!";
                        lblTryCatchSP.ForeColor = System.Drawing.Color.LightGreen;
                    }
                    else if (successfull == false)
                    {
                        lblTryCatchSP.Visible = true;
                        lblTryCatchSP.Text = "FEJL! Ninjaerne har IKKE opdateret!";
                        lblTryCatchSP.ForeColor = System.Drawing.Color.Red;

                    }
                    break;

                case 3:
                    successfull = new InfoManager().InfoUpdateOpeningHours(txtIdentifier.Text.Trim(), txtNewData.Text.Trim());

                    if (successfull == true)
                    {
                        lblTryCatchSP.Visible = true;
                        lblTryCatchSP.Text = "Ninjaerne har opdateret!";
                        lblTryCatchSP.ForeColor = System.Drawing.Color.LightGreen;
                    }
                    else if (successfull == false)
                    {
                        lblTryCatchSP.Visible = true;
                        lblTryCatchSP.Text = "FEJL! Ninjaerne har IKKE opdateret!";
                        lblTryCatchSP.ForeColor = System.Drawing.Color.Red;

                    }
                    break;

                case 4:
                    
                    if (txtNewData.Text == null || txtNewData.Text.Trim().Length == 0)
                    {
                        txtNewData.Text = "1000000000";
                    }

                    successfull = new InfoManager().InfoUpdatePhone(txtIdentifier.Text.Trim(), Convert.ToInt32(txtNewData.Text.Trim()));

                    if (successfull == true)
                    {
                        lblTryCatchSP.Visible = true;
                        lblTryCatchSP.Text = "Ninjaerne har opdateret!";
                        lblTryCatchSP.ForeColor = System.Drawing.Color.LightGreen;
                    }
                    else if (successfull == false)
                    {
                        lblTryCatchSP.Visible = true;
                        lblTryCatchSP.Text = "FEJL! Ninjaerne har IKKE opdateret!";
                        lblTryCatchSP.ForeColor = System.Drawing.Color.Red;

                    }
                    break;

                case 5:
                    successfull = new InfoManager().InfoUpdateStreetNameNumber(txtIdentifier.Text.Trim(), txtNewData.Text.Trim());

                    if (successfull == true)
                    {
                        lblTryCatchSP.Visible = true;
                        lblTryCatchSP.Text = "Ninjaerne har opdateret!";
                        lblTryCatchSP.ForeColor = System.Drawing.Color.LightGreen;
                    }
                    else if (successfull == false)
                    {
                        lblTryCatchSP.Visible = true;
                        lblTryCatchSP.Text = "FEJL! Ninjaerne har IKKE opdateret!";
                        lblTryCatchSP.ForeColor = System.Drawing.Color.Red;

                    }
                    break;

                case 6:
                    if (txtNewData.Text == null || txtNewData.Text.Trim().Length == 0)
                    {
                        txtNewData.Text = "1000000000";
                    }

                    successfull = new InfoManager().InfoUpdateZipCode(txtIdentifier.Text.Trim(), Convert.ToInt32(txtNewData.Text.Trim()));

                    if (successfull == true)
                    {
                        lblTryCatchSP.Visible = true;
                        lblTryCatchSP.Text = "Ninjaerne har opdateret!";
                        lblTryCatchSP.ForeColor = System.Drawing.Color.LightGreen;
                    }
                    else if (successfull == false)
                    {
                        lblTryCatchSP.Visible = true;
                        lblTryCatchSP.Text = "FEJL! Ninjaerne har IKKE opdateret!";
                        lblTryCatchSP.ForeColor = System.Drawing.Color.Red;

                    }
                    break;

                case 7:
                    successfull = new ProductManager().ProductUpdateImgPath(txtIdentifier.Text.Trim(), txtNewData.Text.Trim());

                    if (successfull == true)
                    {
                        lblTryCatchSP.Visible = true;
                        lblTryCatchSP.Text = "Ninjaerne har opdateret!";
                        lblTryCatchSP.ForeColor = System.Drawing.Color.LightGreen;
                    }
                    else if (successfull == false)
                    {
                        lblTryCatchSP.Visible = true;
                        lblTryCatchSP.Text = "FEJL! Ninjaerne har IKKE opdateret!";
                        lblTryCatchSP.ForeColor = System.Drawing.Color.Red;

                    }
                    break;

                case 8:
                    successfull = new ProductManager().ProductUpdatePDescription(txtIdentifier.Text.Trim(), txtNewData.Text.Trim());

                    if (successfull == true)
                    {
                        lblTryCatchSP.Visible = true;
                        lblTryCatchSP.Text = "Ninjaerne har opdateret!";
                        lblTryCatchSP.ForeColor = System.Drawing.Color.LightGreen;
                    }
                    else if (successfull == false)
                    {
                        lblTryCatchSP.Visible = true;
                        lblTryCatchSP.Text = "FEJL! Ninjaerne har IKKE opdateret!";
                        lblTryCatchSP.ForeColor = System.Drawing.Color.Red;

                    }
                    break;

                case 9:
                    successfull = new ProductManager().ProductUpdatePName(txtIdentifier.Text.Trim(), txtNewData.Text.Trim());

                    if (successfull == true)
                    {
                        lblTryCatchSP.Visible = true;
                        lblTryCatchSP.Text = "Ninjaerne har opdateret!";
                        lblTryCatchSP.ForeColor = System.Drawing.Color.LightGreen;
                    }
                    else if (successfull == false)
                    {
                        lblTryCatchSP.Visible = true;
                        lblTryCatchSP.Text = "FEJL! Ninjaerne har IKKE opdateret!";
                        lblTryCatchSP.ForeColor = System.Drawing.Color.Red;

                    }
                    break;

                case 10:
                    if (txtNewData.Text == null || txtNewData.Text.Trim().Length == 0)
                    {
                        txtNewData.Text = "1000000000";
                    }

                    successfull = new ProductManager().ProductUpdatePrice(txtIdentifier.Text.Trim(), Convert.ToDouble(txtNewData.Text.Trim()));

                    if (successfull == true)
                    {
                        lblTryCatchSP.Visible = true;
                        lblTryCatchSP.Text = "Ninjaerne har opdateret!";
                        lblTryCatchSP.ForeColor = System.Drawing.Color.LightGreen;
                    }
                    else if (successfull == false)
                    {
                        lblTryCatchSP.Visible = true;
                        lblTryCatchSP.Text = "FEJL! Ninjaerne har IKKE opdateret!";
                        lblTryCatchSP.ForeColor = System.Drawing.Color.Red;

                    }
                    break;

                case 11:
                    successfull = new ProductManager().ProductUpdatePType(txtIdentifier.Text.Trim(), txtNewData.Text.Trim());

                    if (successfull == true)
                    {
                        lblTryCatchSP.Visible = true;
                        lblTryCatchSP.Text = "Ninjaerne har opdateret!";
                        lblTryCatchSP.ForeColor = System.Drawing.Color.LightGreen;
                    }
                    else if (successfull == false)
                    {
                        lblTryCatchSP.Visible = true;
                        lblTryCatchSP.Text = "FEJL! Ninjaerne har IKKE opdateret!";
                        lblTryCatchSP.ForeColor = System.Drawing.Color.Red;

                    }
                    break;

                case 12:
                    successfull = new ProductManager().ProductUpdateDelete(txtIdentifier.Text.Trim());
                    if (successfull == true)
                    {
                        lblTryCatchSP.Visible = true;
                        lblTryCatchSP.Text = "Ninjaerne har opdateret!";
                        lblTryCatchSP.ForeColor = System.Drawing.Color.LightGreen;
                    }
                    else if (successfull == false)
                    {
                        lblTryCatchSP.Visible = true;
                        lblTryCatchSP.Text = "FEJL! Ninjaerne har IKKE opdateret!";
                        lblTryCatchSP.ForeColor = System.Drawing.Color.Red;

                    }
                    break;

                default:
                    break;
            }
            txtIdentifier.Text = "";
            txtNewData.Text = "";
        }
        #endregion ExecuteSPButton

        // Sends a new product to DAL through the productmanager.
        // Gets a bool to be used to display success/failure message to the Admin user.
        protected void btnSetProduct_Click(object sender, EventArgs e)
        {
            #region SetProductMessageToAdmin
            // Needs to be a price input since it has been converted to double and cannot be null/empty
            if (txtPrice.Text == null || txtPrice.Text.Trim().Length == 0)
            {
                txtPrice.Text = "99999";
            }

            // Calls the Method from productmanager which takes the users input to create a new product to be inserted in the database through DAL.
            bool successfull = new ProductManager().CreateProduct(txtPType.Text, txtPName.Text, Convert.ToDouble(txtPrice.Text), txtPDescription.Text, txtImgPath.Text);

            // Message to Admin user
            if (successfull == true)
            {
                lblTryCatchSet.Visible = true;
                lblTryCatchSet.Text = "Ninjaerne har lavet et nyt produkt!";
                lblTryCatchSet.ForeColor = System.Drawing.Color.LightGreen;
            }
            else if (successfull == false)
            {
                lblTryCatchSet.Visible = true;
                lblTryCatchSet.Text = "FEJL! Ninjaerne har IKKE lavet et nyt produkt!";
                lblTryCatchSet.ForeColor = System.Drawing.Color.Red;

            }
            #endregion SetProductMessageToAdmin

            // Clears the textboxes after the button has been clicked.
            txtPType.Text = "";
            txtPName.Text = "";
            txtPrice.Text = "";
            txtPDescription.Text = "";
            txtImgPath.Text = "";
        }

    }
}