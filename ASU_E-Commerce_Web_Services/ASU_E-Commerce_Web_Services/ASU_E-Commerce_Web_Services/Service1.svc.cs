﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using System.Security.Cryptography;

namespace ASU_E_Commerce_Web_Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        users myusers = new users();
        books mybooks = new books();
        public string sign_up(string fname, string lname, string pname, string email, string id, string pword, string street1, string street2, string city, string state, string zip, string host_email, string host_credential)
        {
            return myusers.sign_up(fname, lname, pname, email, id, pword, street1, street2, city, state, zip);
        }

        //done
        public string[] sign_in(string id, string pword, string host_email, string host_credential)
        {
            return myusers.sign_in(id, pword);
        }

        //done
        public string[] get_user_info(string login, string host_email, string host_credential)
        {
            return myusers.get_user_info(login);
        }

        //error with everything except editing password
        public string edit_user_info(string userid, string pname, string email, string loginid, string n_pword, string rn_pword, string st_addr1, string st_addr2, string city, string state, string zip, string host_email, string host_credential)
        {
            return myusers.edit_user_info(userid,pname, email, loginid, n_pword, rn_pword, st_addr1, st_addr2, city, state, zip);
        }

        //missing description in web service
        public string add_books(string login_id, string isbn, string title, string subject, string quantity, string price, string bidding, string host_email, string host_credential)
        {
            return mybooks.add_books(login_id, isbn, title, subject, quantity, price, bidding);
        }

        public string edit_books(string product_id, string isbn, string title, string subject, string quantity, string price, string bidding, string host_email, string host_credential)
        {
            return mybooks.edit_books(product_id, isbn, title, subject, quantity, price, bidding);
        }

        //done
        public LinkedList<string> search_books(string type, string input, string host_email, string host_credential)
        {
            return mybooks.search_books(type, input);
        }

        public string delete_book(string productid, string host_email, string host_credential)
        {
            return mybooks.delete_book(productid);
        }

        
        public string[] book_details(string productid, string host_email, string host_credential)
        {
            return mybooks.book_details(productid);
        }

        public LinkedList<string> list_products(string id, string host_email, string host_credential)
        {
            return myusers.list_products(id);
        }

        //private functions
        private bool user_authentication(string email, string cred)
        {
            bool result = false;

            XmlDocument xml = new XmlDocument();
            xml.Load("http://webstrar48.fulton.asu.edu/page10/Users.xml");

            foreach (XmlNode node in xml.SelectNodes("//user"))
            {
                string e = node.SelectSingleNode("email").InnerText;
                string c = node.SelectSingleNode("cred").InnerText;
                if (e == email && c.Substring(0, 88) == hash(cred))
                {
                    result = true;
                    break;
                }
                else
                {
                    result = false;
                }
            }

            return result;
        }

        private string hash(string data)
        {
            using (var sha = new SHA512CryptoServiceProvider())
            {
                var hashed_string = sha.ComputeHash(Encoding.Default.GetBytes(data + "9090"));
                return Convert.ToBase64String(hashed_string);
            }
        }
    }
}