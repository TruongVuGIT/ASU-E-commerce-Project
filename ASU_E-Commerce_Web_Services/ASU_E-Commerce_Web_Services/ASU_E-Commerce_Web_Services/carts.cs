using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace ASU_E_Commerce_Web_Services
{
    public class carts
    {
        public string add_cart(string userid, string productid, string quantity)
        {

            string file_location = AppDomain.CurrentDomain.BaseDirectory + @"/carts.xml";
            XElement xml = XElement.Load(file_location);
            xml.Add(new XElement("cart", new XAttribute("userid", userid),
                new XElement("productid", new XAttribute("quantity", quantity), productid)));
            xml.Save(file_location);

            return "pass";
        }
    }
}