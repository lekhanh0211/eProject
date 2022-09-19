using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medical.Models
{
    public class Login
    {
        public AdminLogin ChiTiet(string username)
        {
            eProjectEntities db = new eProjectEntities();
            try
            {
                var model = db.AdminLogins.SingleOrDefault(x => x.Username == username.ToLower());
                return model;
            }
            catch
            {
                return null;
            }

        }
    }
}