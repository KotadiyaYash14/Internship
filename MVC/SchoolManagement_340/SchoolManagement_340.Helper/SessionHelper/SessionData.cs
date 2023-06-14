using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SchoolManagement_340.Helper.SessionHelper
{
    public class SessionData
    {
        public static string UserFirstName
        {
            get
            {
                return HttpContext.Current.Session["UserFirstName"] == null ? null : (string)HttpContext.Current.Session["UserFirstName"];
            }
            set
            {
                HttpContext.Current.Session["UserFirstName"] = value;
            }
        }
        public static string UserLastName
        {
            get
            {
                return HttpContext.Current.Session["UserLastName"] == null ? null : (string)HttpContext.Current.Session["UserLastName"];
            }
            set
            {
                HttpContext.Current.Session["UserLastName"] = value;
            }
        }
        public static string UserEmail
        {
            get
            {
                return HttpContext.Current.Session["UserEmail"] == null ? null : (string)HttpContext.Current.Session["UserEmail"];
            }
            set
            {
                HttpContext.Current.Session["UserEmail"] = value;
            }
        }
        public static string UserRole
        {
            get
            {
                return HttpContext.Current.Session["UserRole"] == null ? null : (string)HttpContext.Current.Session["UserRole"];
            }
            set
            {
                HttpContext.Current.Session["UserRole"] = value;
            }
        }
        public static string Image
        {
            get
            {
                return HttpContext.Current.Session["Image"] == null ? null : (string)HttpContext.Current.Session["Image"];
            }
            set
            {
                HttpContext.Current.Session["Image"] = value;
            }
        }
    }
}