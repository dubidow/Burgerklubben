using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace Burgerklubben.Classes
{
    public static class DAL
    {
        // User Id and password is the user created in the database who has access to this specific database (grant all).
        private static string conn = @"Data Source=172.16.5.10;Initial Catalog=BurgerHouse;User ID=BH; Password=Kode1234!";


        // Returns a list of Food/burgers from the database to be displayed on the menu page (through the productmanager).
        #region GetBurger
        public static List<Food> GetBurger()
        {
            List<Food> allFood = new List<Food>();
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(@"DECLARE @return_value int
                                                EXEC @return_value = [dbo].[SP_ProductGetBurger]", connection);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    string pName = (string)rdr["PName"];
                    decimal price = (decimal)rdr["price"];
                    string pDescription = (string)rdr["PDescription"];
                    string imgPath = (string)rdr["ImgPath"];

                    Food f = new Food(pName, Convert.ToDouble(price), pDescription, imgPath);
                    allFood.Add(f);
                }              
            }
            return allFood;
        }
        #endregion GetBurger

        // Returns a list of Drinks/Beverages from the database to be displayed on the menu page (through the productmanager).
        #region GetBeverages
        public static List<Drinks> GetBeverages()
        {
            List<Drinks> allBeverages = new List<Drinks>();
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(@"DECLARE @return_value int
                                                EXEC @return_value = [dbo].[SP_ProductGetBeverages]", connection);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string pName = (string)rdr["PName"];
                    decimal price = (decimal)rdr["price"];
                    string pDescription = (string)rdr["PDescription"];

                    Drinks d = new Drinks(pName, Convert.ToDouble(price), pDescription);
                    allBeverages.Add(d);
                }      
            }
            return allBeverages;
        }
        #endregion GetBeverages

        // Sends the users search word to the database and returns a list of products to the menu page (through the productmanager).
        #region GetSearch
        public static List<Product> GetSearch(string search)
        {
            List<Product> searchList = new List<Product>();
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(@"DECLARE @return_value int
                                                EXEC @return_value = [dbo].[SP_ProductSearchProduct] @Search", connection);
                cmd.Parameters.AddWithValue("@Search", search);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string pName = (string)rdr["PName"];
                    decimal price = (decimal)rdr["Price"];
                    string pDescription = (string)rdr["PDescription"];

                    Product p = new Product(pName, Convert.ToDouble(price), pDescription);
                    searchList.Add(p);
                }
            }
            return searchList;
        }
        #endregion GetSearch

        // Returns an Info object with properties from the database to be displayed on the info page (through the infomanager).
        #region GetInfo
        public static Info GetInfo()
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();
                Info i = new Info();
                SqlCommand cmd = new SqlCommand(@"DECLARE @return_value int
                                                EXEC @return_value = [dbo].[SP_InfoGetInfo]", connection);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string email = (string)rdr["Email"];
                    string streetNameNumber = (string)rdr["StreetNameNumber"];
                    int zipCode = (int)rdr["ZipCode"];
                    string city = (string)rdr["City"];
                    int phone = (int)rdr["Phone"];
                    string openingHours = (string)rdr["OpeningHours"];
                    string aboutUs = (string)rdr["AboutUs"];

                    i = new Info(email, streetNameNumber, zipCode, city, phone, openingHours, aboutUs);

                }
                return i;
            }
        }

        #endregion GetInfo

        // Inserts a new product in the database with the data from the AdminCrud page (through the productmanager).
        // Returns a bool to be used to tell the Admin user if the product was created successfully.
        #region CreateProduct
        public static bool CreateProduct(Product p)
        {
            bool successfull = false;
            using (SqlConnection connection = new SqlConnection(conn))
            {
               

                if (p is Food)
                {
                    SqlCommand cmd = new SqlCommand(@"DECLARE @return_value int
                                                EXEC @return_value = [dbo].[SP_ProductSetProduct]@PType, @PName, @Price, @PDescription, @ImgPath", connection);
                    cmd.Parameters.AddWithValue("@PType", p.PType);
                    cmd.Parameters.AddWithValue("@PName", p.PName);
                    cmd.Parameters.AddWithValue("@Price", p.Price);
                    cmd.Parameters.AddWithValue("@PDescription", p.PDescription);
                    cmd.Parameters.AddWithValue("@ImgPath", ((Food)p).ImagePath);

                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        successfull = true;
                    }
                    catch (SqlException e)
                    {
                        successfull = false;
                    }
                    finally
                    {
                        connection.Close();
                    }

                }

                else
                {
                    SqlCommand cmd = new SqlCommand(@"DECLARE @return_value int
                                                EXEC @return_value = [dbo].[SP_ProductSetProduct]@PType, @PName, @Price, @PDescription, @ImgPath", connection);
                    cmd.Parameters.AddWithValue("@PType", p.PType);
                    cmd.Parameters.AddWithValue("@PName", p.PName);
                    cmd.Parameters.AddWithValue("@Price", p.Price);
                    cmd.Parameters.AddWithValue("@PDescription", p.PDescription);
                    cmd.Parameters.AddWithValue("@ImgPath", string.Empty);

                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        successfull = true;
                    }
                    catch (SqlException e)
                    {
                        successfull = false;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }              
            }
            return successfull;
        }
        #endregion CreateProduct

        // Method to be called from the InfoManager and ProductManager sending a bool/message to be displayed on the AdminCrud page.
        // Sets new data in the database.
        #region SelectSP
        public static bool InfoUpdateAboutUs(string email, string aboutUs)
        {
            bool successfull = false;
            using (SqlConnection connection = new SqlConnection(conn))
            {                
                SqlCommand cmd = new SqlCommand(@"DECLARE @return_value int
                                                EXEC @return_value = [dbo].[SP_InfoUpdateAboutUs]@Email, @AboutUsNew", connection);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@AboutUsNew", aboutUs);
                
                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    successfull = true;
                }
                catch (SqlException e)
                {
                    successfull = false;
                }
                finally
                {
                    connection.Close();
                }
            }
            return successfull;           
        }
        public static bool InfoUpdateEmail(string emailOld, string emailNew)
        {
            bool successfull = false;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand(@"DECLARE @return_value int
                                                EXEC @return_value = [dbo].[SP_InfoUpdateEmail] @EmailOld, @EmailNew", connection);
                cmd.Parameters.AddWithValue("@EmailOld", emailOld);
                cmd.Parameters.AddWithValue("@EmailNew", emailNew);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    successfull = true;
                }
                catch (SqlException e)
                {
                    successfull = false;
                }
                finally
                {
                    connection.Close();
                }
            }
            return successfull;
        }
        public static bool InfoUpdateOpeningHours(string email, string openingHours)
        {
            bool successfull = false;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand(@"DECLARE @return_value int
                                                EXEC @return_value = [dbo].[SP_InfoUpdateOpeningHours] @Email, @OpeningHoursNew", connection);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@OpeningHoursNew", openingHours);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    successfull = true;
                }
                catch (SqlException e)
                {
                    successfull = false;
                }
                finally
                {
                    connection.Close();
                }
            }
            return successfull;
        }
        public static bool InfoUpdatePhone(string email, int newPhone)
        {
            bool successfull = false;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand(@"DECLARE @return_value int
                                                EXEC @return_value = [dbo].[SP_InfoUpdatePhone] @Email, @PhoneNew", connection);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@PhoneNew", newPhone);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    successfull = true;
                }
                catch (SqlException e)
                {
                    successfull = false;
                }
                finally
                {
                    connection.Close();
                }
            }
            return successfull;
        }
        public static bool InfoUpdateStreetNameNumber(string email, string streetNameNumber)
        {
            bool successfull = false;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand(@"DECLARE @return_value int
                                                EXEC @return_value = [dbo].[SP_InfoUpdateStreetNameNumber] @Email, @StreetNameNumberNew", connection);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@StreetNameNumberNew", streetNameNumber);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    successfull = true;
                }
                catch (SqlException e)
                {
                    successfull = false;
                }
                finally
                {
                    connection.Close();
                }
            }
            return successfull;
        }
        public static bool InfoUpdateZipCode(string email, int zipCode)
        {
            bool successfull = false;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand(@"DECLARE @return_value int
                                                EXEC @return_value = [dbo].[SP_InfoUpdateZipCode] @Email, @ZipCodeNew", connection);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@ZipCodeNew", zipCode);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    successfull = true;
                }
                catch (SqlException e)
                {
                    successfull = false;
                }
                finally
                {
                    connection.Close();
                }
            }
            return successfull;
        }
        public static bool ProductUpdateImgPath(string pName, string imgPathNew)
        {
            bool successfull = false;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand(@"DECLARE @return_value int
                                                EXEC @return_value = [dbo].[SP_ProductUpdateImgPath] @PName, @ImgPathNew", connection);
                cmd.Parameters.AddWithValue("@PName", pName);
                cmd.Parameters.AddWithValue("@ImgPathNew", imgPathNew);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    successfull = true;
                }
                catch (SqlException e)
                {
                    successfull = false;
                }
                finally
                {
                    connection.Close();
                }
            }
            return successfull;
        }
        public static bool ProductUpdatePDescription(string pName, string pDescriptionNew)
        {
            bool successfull = false;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand(@"DECLARE @return_value int
                                                EXEC @return_value = [dbo].[SP_ProductUpdatePDescription] @PName, @PDescriptionNew", connection);
                cmd.Parameters.AddWithValue("@PName", pName);
                cmd.Parameters.AddWithValue("@PDescriptionNew", pDescriptionNew);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    successfull = true;
                }
                catch (SqlException e)
                {
                    successfull = false;
                }
                finally
                {
                    connection.Close();
                }
            }
            return successfull;
        }
        public static bool ProductUpdatePName(string pName, string pNameNew)
        {
            bool successfull = false;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand(@"DECLARE @return_value int
                                                EXEC @return_value = [dbo].[SP_ProductUpdatePName] @PNameOld, @PNameNew", connection);
                cmd.Parameters.AddWithValue("@PNameOld", pName);
                cmd.Parameters.AddWithValue("@PNameNew", pNameNew);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    successfull = true;
                }
                catch (SqlException e)
                {
                    successfull = false;
                }
                finally
                {
                    connection.Close();
                }
            }
            return successfull;
        }
        public static bool ProductUpdatePrice(string pName, double priceNew)
        {
            bool successfull = false;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand(@"DECLARE @return_value int
                                                EXEC @return_value = [dbo].[SP_ProductUpdatePrice] @PName, @PriceNew", connection);
                cmd.Parameters.AddWithValue("@PName", pName);
                cmd.Parameters.AddWithValue("@PriceNew", priceNew);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    successfull = true;
                }
                catch (SqlException e)
                {
                    successfull = false;
                }
                finally
                {
                    connection.Close();
                }
            }
            return successfull;
        }
        public static bool ProductUpdatePType(string pName, string pTypeNew)
        {
            bool successfull = false;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand(@"DECLARE @return_value int
                                                EXEC @return_value = [dbo].[SP_ProductUpdatePType] @PName, @PTypeNew", connection);
                cmd.Parameters.AddWithValue("@PName", pName);
                cmd.Parameters.AddWithValue("@PTypeNew", pTypeNew);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    successfull = true;
                }
                catch (SqlException e)
                {
                    successfull = false;
                }
                finally
                {
                    connection.Close();
                }
            }
            return successfull;
        }
        public static bool ProductUpdateDelete(string pName)
        {
            bool successfull = false;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand(@"DECLARE @return_value int
                                                EXEC @return_value = [dbo].[SP_ProductDeleteProduct] @PName", connection);
                cmd.Parameters.AddWithValue("@PName", pName);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    successfull = true;
                }
                catch (SqlException e)
                {
                    successfull = false;
                }
                finally
                {
                    connection.Close();
                }
            }
            return successfull;
        }
        #endregion SelectSP

        // Checks if Admins login credentials is valid/exists in the database.
        #region CheckLogin
        public static int CheckLogin(Admin a)
        {
            int count = 0;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(1) FROM AdminUser WHERE UserName = @userName AND AdminPassword =@password", connection);
                cmd.Parameters.AddWithValue("@userName", a.UserName);
                cmd.Parameters.AddWithValue("@password", a.AdminPassword);
                count = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return count;
        }
        #endregion CheckLogin

    }


}