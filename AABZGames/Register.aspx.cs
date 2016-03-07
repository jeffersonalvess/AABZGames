using AABZGames.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AABZGames
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnSubmit(Object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                using (AABZContext entities = new AABZContext())
                {
                    //try to add user to database, return error if fails
                    try
                    {
                        var user = entities.Users.Create();
                        user.first_name = txtFname.Text;
                        user.last_name = txtLastName.Text;
                        user.email = txtEmail.Text;
                        var Pass = base64Encode(txtPass.Text);
                        user.password = Pass;

                        var info = entities.UserInfoes.Create();
                        info.user_id = user.Id;//LINK TO USER                 
                        info.address_1 = txtAdd.Text;
                        info.address_2 = txtAdd2.Text;
                        info.city = txtCity.Text;
                        info.state = txtState.Text;
                        info.zipcode = txtZip.Text;
                        info.phone = txtPhone.Text;

                        entities.Users.Add(user);
                        entities.UserInfoes.Add(info);
                        entities.SaveChanges();
                        //load information to panel
                        //show panel and hide form
                    }
                    catch (Exception ex)
                    {
                        error.Text = "Error Occured. Error Info: " + ex.Message;
                    }
                }
            }


        }
        //SOURCE: http://www.c-sharpcorner.com/UploadFile/145c93/save-password-using-salted-hashing/
        public static string base64Encode(string sData) // Encode    
        {
            try
            {
                byte[] encData_byte = new byte[sData.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(sData);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }
    }
}