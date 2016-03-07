using AABZGames.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AABZGames
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] == null)
            {
                panelLogin.Visible = true;
            }
            else
            {
                panelLogin.Visible = false;
            }
        }
        public void btn_login(Object sender, EventArgs e)
        {

            var email = txtUserName.Text;
            var Pass = txtPwd.Text;
            Pass = base64Encode(Pass);
            using (AABZContext context = new AABZContext())
            {
                try
                {
                    var s = (from c in context.Users
                             where c.email == email && c.password == Pass
                             select c).FirstOrDefault();
                    //if valid create session and session cookie
                    if (s != null)
                    {
                        Session["ID"] = s.Id.ToString();
                        panelLogin.Visible = false;
                    }
                    else
                    {
                        lblResults.Text = "User Name or Password are incorrect.";
                    }
                }
                catch (Exception ex)
                {
                    lblResults.Text = ex.ToString();
                }
            }
        }
        //source: http://www.c-sharpcorner.com/UploadFile/145c93/save-password-using-salted-hashing/
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
        public static string base64Decode(string sData) //Decode    
        {
            try
            {
                var encoder = new System.Text.UTF8Encoding();
                System.Text.Decoder utf8Decode = encoder.GetDecoder();
                byte[] todecodeByte = Convert.FromBase64String(sData);
                int charCount = utf8Decode.GetCharCount(todecodeByte, 0, todecodeByte.Length);
                char[] decodedChar = new char[charCount];
                utf8Decode.GetChars(todecodeByte, 0, todecodeByte.Length, decodedChar, 0);
                string result = new String(decodedChar);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Decode" + ex.Message);
            }
        }
    }
}