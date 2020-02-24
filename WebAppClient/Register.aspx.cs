using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Linq;
using System.Web;

namespace WebFormsIdentity
{
    public partial class Register : System.Web.UI.Page
    {

       



        protected void CreateUser_Click(object sender, EventArgs e)
        {
            // Default UserStore constructor uses the default connection string named: DefaultConnection
            var userStore = new UserStore<IdentityUser>();
            var manager = new UserManager<IdentityUser>(userStore);

            var user = new IdentityUser() { UserName = UserName.Text };
            IdentityResult result = manager.Create(user, Password.Text);

            if (result.Succeeded)
            {
                StatusMessage.Text = string.Format("User {0} was created successfully!", user.UserName);


                //Creating cookie for user ID
                HttpCookie userIDCookie = new HttpCookie("user");
                userIDCookie.Value = user.Id;

                Response.Cookies.Add(userIDCookie);
                
                //fetching cookie
                var co_val = Response.Cookies["user"].Value;


                //DBshit
                //redirect
            }
            else
            {
                StatusMessage.Text = result.Errors.FirstOrDefault();
            }
        }


 

    }
}