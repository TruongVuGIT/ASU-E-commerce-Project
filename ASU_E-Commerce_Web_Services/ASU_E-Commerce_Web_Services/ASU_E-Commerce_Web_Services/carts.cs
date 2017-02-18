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

        // function to used to check if a given product is still available
        public bool checkProductExists(string productid)
        {
            // result variable that will determine if product exists
            bool result = false;
            // flag if product is book or not
            bool bookFlag = true;

            // char array to hold product id
            char[] id = new char[11];
            id = productid.ToCharArray();

            // initialize file location variable
            string file_location = "";

            // check if first letter of id is 'B'
            if (id[0] == 'B')
            {
                // set file location to books xml
                file_location = AppDomain.CurrentDomain.BaseDirectory + @"/books.xml";
            }
            // check if first letter of id is 'S'
            else if (id[0] == 'S')
            {
                // set file location to shirts xml
                file_location = AppDomain.CurrentDomain.BaseDirectory + @"/shirts.xml";
                // set the book flag to false, since this is a shirt product
                bookFlag = false;
            }

            // create xml document, load the filepath
            XmlDocument xml = new XmlDocument();
            xml.Load(file_location);

            // variable to hold the type of single node
            string nodeType = "";
            // determine based on bookFlag
            if (bookFlag == true)
            {
                // set the type to book
                nodeType = "//book";
            }
            else
            {
                // set the type to shirt
                nodeType = "//shirt";
            }

            // loop through each book
            foreach (XmlNode node in xml.SelectNodes(nodeType))
            {
                // get productid
                string n_prodId = node.SelectSingleNode("productid").InnerText;

                // check if it equals the parameter productid
                if (n_prodId == productid)
                {
                    // found - the product exists
                    result = true;
                    // break from loop
                    break;
                }
                else
                {
                    // not found - continue looping, set result to false
                    result = false;
                }
            }
            
            // return the result of the search
            return result;
        }

        // function to check and return the current quantity value of a given product
        public string checkCurrentQuantity(string productid, string quantity)
        {
            // variable for updated quantity - initialized to original quantity
            string updatedQuantity = quantity;

            // flag if product is book or not
            bool bookFlag = true;

            // char array to hold product id
            char[] id = new char[11];
            id = productid.ToCharArray();

            // initialize file location variable
            string file_location = "";

            // check if first letter of id is 'B'
            if (id[0] == 'B')
            {
                // set file location to books xml
                file_location = AppDomain.CurrentDomain.BaseDirectory + @"/books.xml";
            }
            // check if first letter of id is 'S'
            else if (id[0] == 'S')
            {
                // set file location to shirts xml
                file_location = AppDomain.CurrentDomain.BaseDirectory + @"/shirts.xml";
                // set the book flag to false, since this is a shirt product
                bookFlag = false;
            }

            // create xml document, load the filepath
            XmlDocument xml = new XmlDocument();
            xml.Load(file_location);

            // variable to hold the type of single node
            string nodeType = "";
            // determine based on bookFlag
            if (bookFlag == true)
            {
                // set the type to book
                nodeType = "//book";
            }
            else
            {
                // set the type to shirt
                nodeType = "//shirt";
            }

            // loop through each book
            foreach (XmlNode node in xml.SelectNodes(nodeType))
            {
                // get productid
                string n_prodId = node.SelectSingleNode("productid").InnerText;

                // check if it equals the parameter productid
                if (n_prodId == productid)
                {
                    // get the quantity
                    string n_quantity = node.SelectSingleNode("quantity").InnerText;

                    // check if the quantity is the same
                    if (n_quantity == quantity)
                    {
                        // break from loop - quantity is the same, nothing to change
                        break;
                    }
                    else
                    {
                        // set the return variable to the new value
                        updatedQuantity = n_quantity;
                    }
                }
                else
                {
                    // product not found - continue looping
                    
                }
            }
            return updatedQuantity;
        }

        // function to check and return the current price value of a given product
        public string checkCurrentPrice(string productid, string price)
        {
            // variable for updated price - initialized to original price
            string updatedPrice = price;

            // flag if product is book or not
            bool bookFlag = true;

            // char array to hold product id
            char[] id = new char[11];
            id = productid.ToCharArray();

            // initialize file location variable
            string file_location = "";

            // check if first letter of id is 'B'
            if (id[0] == 'B')
            {
                // set file location to books xml
                file_location = AppDomain.CurrentDomain.BaseDirectory + @"/books.xml";
            }
            // check if first letter of id is 'S'
            else if (id[0] == 'S')
            {
                // set file location to shirts xml
                file_location = AppDomain.CurrentDomain.BaseDirectory + @"/shirts.xml";
                // set the book flag to false, since this is a shirt product
                bookFlag = false;
            }

            // create xml document, load the filepath
            XmlDocument xml = new XmlDocument();
            xml.Load(file_location);

            // variable to hold the type of single node
            string nodeType = "";
            // determine based on bookFlag
            if (bookFlag == true)
            {
                // set the type to book
                nodeType = "//book";
            }
            else
            {
                // set the type to shirt
                nodeType = "//shirt";
            }

            // loop through each book
            foreach (XmlNode node in xml.SelectNodes(nodeType))
            {
                // get productid
                string n_prodId = node.SelectSingleNode("productid").InnerText;

                // check if it equals the parameter productid
                if (n_prodId == productid)
                {
                    // get the price
                    string n_price = node.SelectSingleNode("price").InnerText;

                    // check if the price is the same
                    if (n_price == price)
                    {
                        // break from loop - price is the same, nothing to change
                        break;
                    }
                    else
                    {
                        // set the return variable to the new value
                        updatedPrice = n_price;
                        // break from the loop, price has been updated
                        break;
                    }
                }
                else
                {
                    // product not found - continue looping

                }
            }
            return updatedPrice;
        }

        // function to return a shopping cart for a given userid
        public string[,] listCartProducts(string userid)
        {
            // create new variable to hold all cart information
            string[,] cart = new string[50,12];

            // set the filepath
            string file_location = AppDomain.CurrentDomain.BaseDirectory + @"/carts.xml";

            // create xml document, load the filepath
            XmlDocument xml = new XmlDocument();
            xml.Load(file_location);

            foreach (XmlNode node in xml.SelectNodes("//cart"))
            {
                // get the userid from the userid attribute of the current node
                string id = node.Attributes["userid"].Value;

                // determine if the cart has been found
                if (id == userid)
                {
                    // cart has been found - begin retrieving data

                    // initialize variables to keep track of position in 2d array
                    int x = 0;
                    
                    // loop through each child node
                    foreach (XmlNode child in node.ChildNodes)
                    {
                        // get the product id
                        string tempid = child.SelectSingleNode("productid").InnerText;
                        // set the product id
                        cart[x,0] = tempid;

                        // get the title or brand

                        // TO DO --------------------------------------------------
                        string tempname = child.Attributes["name"].Value;

                        // set the name value to the cart at [x, 1]
                        cart[x, 1] = tempname;

                        // get the price
                        string tempprice = child.Attributes["price"].Value;
                        
                        // set the price value to the cart at [x, 2]
                        cart[x, 2] = tempprice;

                        // get the quantity
                        string tempquantity = child.Attributes["quantity"].Value;

                        // set the quantity to the cart at [x, 3]
                        cart[x, 3] = tempquantity;
                    }
                }
                else
                {
                    // cart not yet found, continue looping
                }
            }

            return cart;

        }
    }
}