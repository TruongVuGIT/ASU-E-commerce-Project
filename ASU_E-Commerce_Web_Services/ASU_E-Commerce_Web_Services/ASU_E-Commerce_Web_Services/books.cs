using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace ASU_E_Commerce_Web_Services
{
    public class books
    {
        public string add_books(string login_id, string isbn, string title, string subject, string quantity, string price, string bidding)
        {
            string result = "Fail";
            string userid = get_userid(login_id);
            if (userid != "")
            {
                string file_location = AppDomain.CurrentDomain.BaseDirectory + @"/books.xml";
                XElement xml = XElement.Load(file_location);
                xml.Add(new XElement("book",
                    new XElement("productid", generate_product_id()),
                    new XElement("isbn", isbn),
                    new XElement("title", title),
                    new XElement("subject", subject),
                    new XElement("quantity", quantity),
                    new XElement("price", price),
                    new XElement("bidding", bidding),
                    new XElement("userid", userid)));
                xml.Save(file_location);

                result = "Pass";
            }
            else
            {
                result = "Fail";
            }
            return result;
        }

        public string edit_books(string product_id, string isbn, string title, string subject, string quantity, string price, string bidding)
        {
            string result = "Fail";

            string file_location = AppDomain.CurrentDomain.BaseDirectory + @"/books.xml";

            XmlDocument xml = new XmlDocument();
            xml.Load(file_location);

            foreach (XmlNode node in xml.SelectNodes("//book"))
            {
                string current_productid = node.SelectSingleNode("productid").InnerText;
                if (product_id == current_productid)
                {
                    node.SelectSingleNode("isbn").InnerText = isbn;
                    node.SelectSingleNode("title").InnerText = title;
                    node.SelectSingleNode("subject").InnerText = subject;
                    node.SelectSingleNode("quantity").InnerText = quantity;
                    node.SelectSingleNode("price").InnerText = price;
                    node.SelectSingleNode("bidding").InnerText = bidding;
                    xml.Save(file_location);
                    result = "Pass";
                    break;
                }
                else
                {
                    result = "Fail";
                }
            }

            return result;
        }

        public string[] book_details(string productid)
        {
            string[] details = new string[8];

            string file_location = AppDomain.CurrentDomain.BaseDirectory + @"/books.xml";

            XmlDocument xml = new XmlDocument();
            xml.Load(file_location);

            foreach (XmlNode node in xml.SelectNodes("//book"))
            {
                string id = node.SelectSingleNode("productid").InnerText;

                if (productid == id)
                {
                    details[0] = productid;
                    details[1] = node.SelectSingleNode("isbn").InnerText;
                    details[2] = node.SelectSingleNode("title").InnerText;
                    details[3] = node.SelectSingleNode("subject").InnerText;
                    details[4] = node.SelectSingleNode("quantity").InnerText;
                    details[5] = node.SelectSingleNode("price").InnerText;
                    details[6] = node.SelectSingleNode("bidding").InnerText;
                    details[7] = node.SelectSingleNode("userid").InnerText;

                    xml.Save(file_location);
                    break;
                }
            }
            return details;
        }

        public LinkedList<string> search_books(string type, string input)
        {
            LinkedList<string> list = new LinkedList<string>();
            string file_location = AppDomain.CurrentDomain.BaseDirectory + @"/books.xml";

            XmlDocument xml = new XmlDocument();
            xml.Load(file_location);

            if (type == "ISBN" || type == "Subject" || type == "Title")
            {
                if (type == "ISBN")
                {
                    foreach (XmlNode node in xml.SelectNodes("//book"))
                    {
                        string isbn = node.SelectSingleNode("isbn").InnerText;
                        string product = node.SelectSingleNode("productid").InnerText;
                        if (isbn == input)
                        {
                            list.AddLast(product);
                        }
                    }
                }
                else if (type == "Subject")
                {
                    foreach (XmlNode node in xml.SelectNodes("//book"))
                    {
                        string isbn = node.SelectSingleNode("subject").InnerText;
                        string product = node.SelectSingleNode("productid").InnerText;
                        if (isbn == input)
                        {
                            list.AddLast(product);
                        }
                    }
                }
                else
                {
                    foreach (XmlNode node in xml.SelectNodes("//book"))
                    {
                        string isbn = node.SelectSingleNode("title").InnerText;
                        string product = node.SelectSingleNode("productid").InnerText;
                        if (isbn == input)
                        {
                            list.AddLast(product);
                        }
                    }
                }
            }

            return list;
        }

        public string delete_book(string productid)
        {
            XmlDocument xml = new XmlDocument();

            string file_location = AppDomain.CurrentDomain.BaseDirectory + @"/books.xml";

            xml.Load(file_location);

            string result = "";

            foreach (XmlNode node in xml.SelectNodes("//book"))
            {
                string foundproductid = node.SelectSingleNode("productid").InnerText;
                if (productid == foundproductid)
                {
                    node.ParentNode.RemoveChild(node);
                    xml.Save(file_location);
                    result = "Pass";
                    break;
                }
                else
                {
                    result = "Fail";
                }
            }

            return result;
        }

        // private functions

        private string get_userid(string loginid)
        {
            string result = "";
            XmlDocument xml = new XmlDocument();
            xml.Load(AppDomain.CurrentDomain.BaseDirectory + @"/users.xml");

            foreach (XmlNode node in xml.SelectNodes("//user"))
            {
                string login_id = node.SelectSingleNode("loginid").InnerText;
                string userid = node.SelectSingleNode("userid").InnerText;
                if (login_id == loginid)
                {
                    result = userid;
                    break;
                }
                else
                {
                    result = "";
                }
            }
            return result;
        }

      
        private string generate_product_id()
        {
            string productid = "";
            XmlDocument doc = new XmlDocument();
            doc.Load(AppDomain.CurrentDomain.BaseDirectory + @"/data.xml");
            XmlElement root = doc.DocumentElement;

            XmlNodeList nodes = root.SelectNodes("//data");

            foreach (XmlNode node in nodes)
            {
                productid = Convert.ToString(Convert.ToInt32(node["books"].InnerText) + 1);
                node["books"].InnerText = productid;
                doc.Save(AppDomain.CurrentDomain.BaseDirectory + @"/data.xml");
                break;
            }
            return prefix(productid, 0) + productid;
        }
        private string prefix(string input, int type)
        {
            int count = 9 - input.Length;
            string add = "";

            if (type == 0)
            {
                add = "B";
            }
            if (count >= 0)
            {
                for (int x = 0; x < count; x++)
                {
                    add += "0";
                }
            }

            return add;
        }
       
    }
}