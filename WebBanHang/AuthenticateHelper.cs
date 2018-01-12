﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using BUS;
using Entities;

namespace WebBanHang
{
    public static class AuthenticateHelper
    {
        public static bool Login(string username, string password, bool remember, HttpResponse Response)
        {
            UserEntity user = BUS.UserBus.Instance.GetUser(username, password);
            string roles;
            string usernameincookie;
            if (user == null)
            {
                CustomerEntity customer = BUS.CustomerBus.Instance.GetCustomer(username, password);
                if (customer != null)
                {
                    roles = "";
                    usernameincookie = customer.CustomerId.ToString();
                }    
                else
                    return false;
            }
            else
            {
                usernameincookie = user.Username;
                roles = BUS.UserBus.Instance.GetPermissionStr(user.Username);
            }
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, usernameincookie, DateTime.Now, DateTime.Now.AddMinutes(60 * 24 * 10), remember, roles);
            string hashString = FormsAuthentication.Encrypt(ticket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hashString);
            if (ticket.IsPersistent)
            {
                cookie.Expires = ticket.Expiration;
            }
            Response.Cookies.Add(cookie);
            return true;
        }
    }
}