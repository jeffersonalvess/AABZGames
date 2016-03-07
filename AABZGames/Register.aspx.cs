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
                using (DBContext entities = new DBContext())
                {
                    //try to add user to database, return error if fails
                    try
                    {
                        var user = entities.User.Create();
                        user.firstName = txtFname.Text;
                        user.lastName = txtLastName.Text;
                        user.email = txtEmail.Text;
                        var Pass = base64Encode(txtPass.Text);
                        user.password = Pass;

                        var info = entities.User_info.Create();
                        info.userId = user.id;//LINK TO USER                 
                        info.address = txtAdd.Text;
                        info.address2 = txtAdd2.Text;
                        info.city = txtCity.Text;
                        info.state = txtState.Text;
                        info.zip = txtZip.Text;
                        info.Phone = txtPhone.Text;

                        entities.Users.Add(user);
                        entities.User_info.Add(info);
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