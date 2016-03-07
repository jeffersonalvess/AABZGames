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
                        var isValid = (from c in entities.Users
                                       where c.email == txtEmail.Text
                                       select c).FirstOrDefault();
                        if (isValid != null && isValid.Equals(txtEmail.Text))
                        {
                            error.Text = "Username is not valid!";
                            return;
                        }
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

                        if (!chkBill.Checked)
                        {
                            info.isBilling = false;
                            var billingInfo = entities.UserInfoes.Create();
                            billingInfo.address_1 = txtBill1.Text;
                            billingInfo.address_2 = txtBill2.Text;
                            billingInfo.user_id = user.Id;//LINK TO USER    
                            billingInfo.city = txtCity.Text;
                            billingInfo.state = txtState.Text;
                            billingInfo.zipcode = txtZip.Text;
                            user.UserInfoes.Add(billingInfo);

                        }
                        else
                        {
                            info.isBilling = true;
                        }
                        user.UserInfoes.Add(info);
                        entities.Users.Add(user);
                        entities.UserInfoes.Add(info);
                        entities.SaveChanges();
                        Response.Redirect("Login.aspx");
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
        public void onCheckChangedMethod(Object sender, EventArgs e)
        {
            panelBilling.Visible = chkBill.Checked ? false : true;
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
