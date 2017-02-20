using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Xml;
using System.Xml.Linq;
using System.Text;
using System.IO;

namespace ASU_E_Commerce_Web_Services
{
    public class users
    {
        public string sign_up(string fname, string lname, string pname, string email, string id, string pword, string street1, string street2, string city, string state, string zip)
        {
            string result = "Fail";
            string id_exist = check_id(id);
            string email_exist = check_email(email);
            string length = check_length(fname, lname, pname, email, id, pword, street1, street2, city, state, zip);
            string empty = check_null(fname, lname, pname, email, id, pword, street1, street2, city, state, zip);
            //string valid = check_validity(fname, lname, pname, email, id, pword, street1, street2, city, state, zip);

            if (id_exist == "" && email_exist == "" && length == "" && empty == "")
            {
                string user_id = get_n_update_id();

                string file_location = AppDomain.CurrentDomain.BaseDirectory + @"/users.xml";
                XElement xml = XElement.Load(file_location);
                xml.Add(new XElement("user",
                    new XElement("fname", fname),
                    new XElement("lname", lname),
                    new XElement("pname", pname),
                    new XElement("email", email),
                    new XElement("loginid", id.ToLower()),
                    new XElement("password", hash(pword)),
                    new XElement("streetaddress1", street1),
                    new XElement("streetaddress2", street2),
                    new XElement("city", city),
                    new XElement("state", state),
                    new XElement("zipcode", zip),
                    new XElement("userid", user_id)));
                xml.Save(file_location);

                add_cart(user_id);

                result = "Pass";
            }
            else
            {
                if (id_exist != "")
                {
                    result = id_exist;
                }
                if (email_exist != "")
                {
                    result = email_exist;
                }
                if (length != "")
                {
                    result = length;
                }
                if (empty != "")
                {
                    result = empty;
                }
            }
            return result;
        }

        public string[] sign_in(string id, string pword)
        {
            string[] result = new string[2];
            result[0] = null;
            result[1] = null;

            XmlDocument xml = new XmlDocument();
            xml.Load(AppDomain.CurrentDomain.BaseDirectory + @"/users.xml");

            foreach (XmlNode node in xml.SelectNodes("//user"))
            {
                string login_id = node.SelectSingleNode("loginid").InnerText;
                string password = node.SelectSingleNode("password").InnerText;
                string user_id = node.SelectSingleNode("userid").InnerText;
                if (login_id.ToLower() == id.ToLower() && password.Substring(0, 88) == hash(pword))
                {
                    result[0] = login_id;
                    result[1] = user_id;
                    break;
                }
            }

            return result;
        }

        public string[] get_user_info(string user_id)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(AppDomain.CurrentDomain.BaseDirectory + @"/users.xml");

            string[] acctInfo;
            acctInfo = new String[11];

            foreach (XmlNode node in xml.SelectNodes("//user"))
            {
                string foundLogin = node.SelectSingleNode("userid").InnerText;
                if (user_id == foundLogin)
                {
                    acctInfo[0] = node.SelectSingleNode("fname").InnerText;
                    acctInfo[1] = node.SelectSingleNode("lname").InnerText;
                    acctInfo[2] = node.SelectSingleNode("pname").InnerText;
                    acctInfo[3] = node.SelectSingleNode("email").InnerText;
                    acctInfo[4] = node.SelectSingleNode("loginid").InnerText;
                    acctInfo[5] = node.SelectSingleNode("streetaddress1").InnerText;
                    acctInfo[6] = node.SelectSingleNode("streetaddress2").InnerText;
                    acctInfo[7] = node.SelectSingleNode("city").InnerText;
                    acctInfo[8] = node.SelectSingleNode("state").InnerText;
                    acctInfo[9] = node.SelectSingleNode("zipcode").InnerText;
                    acctInfo[10] = node.SelectSingleNode("userid").InnerText;
                    break;
                }
            }

            return acctInfo;
        }

        public string edit_user_info(string userid, string pname, string email, string loginid, string n_pword, string rn_pword, string st_addr1, string st_addr2, string city, string state, string zip)
        {
            string result = "Fail";
            bool pword_change = false;
            string file_location = AppDomain.CurrentDomain.BaseDirectory + @"/users.xml";
            XmlDocument xml = new XmlDocument();
            xml.Load(file_location);

            if (n_pword == "" || rn_pword == "")
            {
                pword_change = false;
            }
            else
            {
                pword_change = true;
            }

            foreach (XmlNode node in xml.SelectNodes("//user"))
            {
                string user_id = node.SelectSingleNode("userid").InnerText;
                string password = node.SelectSingleNode("password").InnerText;

                if (n_pword == rn_pword && user_id == userid)
                {
                    node.SelectSingleNode("pname").InnerText = pname;
                    node.SelectSingleNode("email").InnerText = email;
                    node.SelectSingleNode("loginid").InnerText = loginid;
                    node.SelectSingleNode("streetaddress1").InnerText = st_addr1;
                    node.SelectSingleNode("streetaddress2").InnerText = st_addr2;
                    node.SelectSingleNode("city").InnerText = city;
                    node.SelectSingleNode("state").InnerText = state;
                    node.SelectSingleNode("zipcode").InnerText = zip;

                    xml.Save(file_location);
                    result = "Pass";
                    break;
                }
                else
                {
                    result = "Fail";
                }
            }

            foreach (XmlNode node in xml.SelectNodes("//user"))
            {
                string user_id = node.SelectSingleNode("userid").InnerText;
                string password = node.SelectSingleNode("password").InnerText;

                if (n_pword == rn_pword && user_id == userid)
                {
                    if (pword_change == true)
                    {
                        node.SelectSingleNode("password").InnerText = hash(rn_pword);
                    }
                    xml.Save(file_location);
                    break;
                }
                else
                {
                }
            }

            return result;
        }

        public LinkedList<string> list_products(string user_id)
        {
            LinkedList<string> product_list = new LinkedList<string>();

            string book_location = AppDomain.CurrentDomain.BaseDirectory + @"/books.xml";

            XmlDocument book_xml = new XmlDocument();
            book_xml.Load(book_location);

            foreach (XmlNode book_node in book_xml.SelectNodes("//book"))
            {
                string found_id = book_node.SelectSingleNode("userid").InnerText;

                if (user_id == found_id)
                {
                    product_list.AddLast(book_node.SelectSingleNode("productid").InnerText);
                }
                else
                {
                    // do nothing
                }
            }
            /*
            string shirt_location = AppDomain.CurrentDomain.BaseDirectory + @"/shirts.xml";

            XmlDocument shirt_xml = new XmlDocument();
            shirt_xml.Load(shirt_location);

            foreach (XmlNode shirt_node in shirt_xml.SelectNodes("//shirt"))
            {
                string found_id = shirt_node.SelectSingleNode("userid").InnerText;

                if (id == found_id)
                {
                    product_list.AddLast(shirt_node.SelectSingleNode("productid").InnerText);
                }
                else
                {
                    // do nothing
                }
            }
            */
            return product_list;
        }

        //private functions

        private string hash(string data)
        {
            using (var sha = new SHA512CryptoServiceProvider())
            {
                var hashed_string = sha.ComputeHash(Encoding.Default.GetBytes(data + "9090"));
                return Convert.ToBase64String(hashed_string);
            }
        }

        private string get_n_update_id()
        {
            string current_user = "";
            XmlDocument doc = new XmlDocument();
            doc.Load(AppDomain.CurrentDomain.BaseDirectory + @"/data.xml");
            XmlElement root = doc.DocumentElement;

            XmlNodeList nodes = root.SelectNodes("//data");

            foreach (XmlNode node in nodes)
            {
                current_user = Convert.ToString(Convert.ToInt32(node["users"].InnerText) + 1);
                node["users"].InnerText = current_user;
                doc.Save(AppDomain.CurrentDomain.BaseDirectory + @"/data.xml");
                break;
            }

            return current_user;
        }

        private string check_id(string id)
        {
            XDocument doc = XDocument.Load(AppDomain.CurrentDomain.BaseDirectory + @"/users.xml");
            var Exist = doc.Descendants("user")
                            .Any(x => (string)x.Element("loginid") == id);

            if (Exist)
            {
                return "login ID exist";
            }
            else
            {
                return "";
            }
        }

        private string check_email(string email)
        {
            XDocument doc = XDocument.Load(AppDomain.CurrentDomain.BaseDirectory + @"/users.xml");
            var Exist = doc.Descendants("user")
                            .Any(x => (string)x.Element("email") == email);

            if (Exist)
            {
                return "Email exist";
            }
            else
            {
                return "";
            }
        }

        private string check_length(string fname, string lname, string pname, string email, string id, string pword, string street1, string street2, string city, string state, string zip)
        {
            string result = "";
            if (fname.Length > 50)
            {
                result = "First Name is too long";
            }
            if (lname.Length > 50)
            {
                result = "Last Name is too long";
            }
            if (pname.Length > 50)
            {
                result = "Prefered Name is too long";
            }
            if (email.Length > 100)
            {
                result = "Email is too long";
            }
            if (id.Length > 50)
            {
                result = "Login ID is too long";
            }
            if (pword.Length > 50)
            {
                result = "Password is too long";
            }
            if (street1.Length > 150)
            {
                result = "Street Address 1 is too long";
            }
            if (street2.Length > 150)
            {
                result = "Street Address 1 is too long";
            }
            if (city.Length > 50)
            {
                result = "City is too long";
            }
            if (state.Length > 50)
            {
                result = "State is too long";
            }
            if (zip.Length > 15)
            {
                result = "Zip Code is too long";
            }
            return result;
        }

        private string check_null(string fname, string lname, string pname, string email, string id, string pword, string street1, string street2, string city, string state, string zip)
        {
            string result = "";
            if (fname == "")
            {
                result = "First Name was not entered";
            }
            if (lname == "")
            {
                result = "Last Name was not entered";
            }
            if (pname == "")
            {
                result = "Prefered Name was not entered";
            }
            if (email == "")
            {
                result = "Email was not entered";
            }
            if (id == "")
            {
                result = "Login ID was not entered";
            }
            if (pword == "")
            {
                result = "Password was not entered";
            }
            if (street1 == "")
            {
                result = "Street Address 1 was not entered";
            }
            if (city == "")
            {
                result = "City was not entered";
            }
            if (state == "")
            {
                result = "State was not entered";
            }
            if (zip == "")
            {
                result = "Zip Code was not entered";
            }
            return result;
        }

        //for gligor
        private string check_validity(string fname, string lname, string pname, string email, string id, string pword, string street1, string street2, string city, string state, string zip)
        {
            return null;
        }

        private void add_cart(string userid)
        {
            string file_location = AppDomain.CurrentDomain.BaseDirectory + @"/carts.xml";
            XElement xml = XElement.Load(file_location);
            xml.Add(new XElement("cart", new XAttribute("userid", userid)));
            xml.Save(file_location);
        }

    }
}