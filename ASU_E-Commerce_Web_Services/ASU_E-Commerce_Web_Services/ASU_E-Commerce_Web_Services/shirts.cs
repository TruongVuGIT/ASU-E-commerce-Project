using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.IO;
using System.Xml;

namespace ASU_E_Commerce_Web_Services
{
    public class shirts
    {
        // Add Shirt Service --- Done (Dakota)
        public string add_shirts(string brand, string size, string color, string material, string gender, string agegroup, string quantity, string priceperitem, string biddingprice, string userid)
        {
            string image_1 = generate_image_id1();
            string image_2 = generate_image_id2();

            //image1.SaveAs(AppDomain.CurrentDomain.BaseDirectory + @"/Images/" + image_1 + ".jpg");
            //image2.SaveAs(AppDomain.CurrentDomain.BaseDirectory + @"/Images/" + image_2 + ".jpg");

            string result = "";
            if (result == "")
            {
                string file_location = AppDomain.CurrentDomain.BaseDirectory + @"/shirts.xml";
                XElement xml = XElement.Load(file_location);
                xml.Add(
                    new XElement("brand", brand),
                    new XElement("size", size),
                    new XElement("color", color),
                    new XElement("material", material),
                    new XElement("gender", gender),
                    new XElement("agegroup", agegroup),
                    new XElement("quantity", quantity),
                    new XElement("priceperitem", priceperitem),
                    new XElement("biddingprice", biddingprice),
                    new XElement("image1", generate_image_id1()),
                    new XElement("image2", generate_image_id2()),
                    new XElement("productid", generate_product_id()),
                    new XElement("userid", userid));
                xml.Save(file_location);

                result = "Pass";
            }
            else
            {
                result = "Fail";
            }
            return result;
        }

        private string generate_product_id()
        {
            int productid;
            string[] info;

            StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"/data.txt");
            string line = sr.ReadToEnd();
            info = line.Split('\n');

            productid = Convert.ToInt32(info[1]);
            productid++;

            sr.Close();

            StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"/data.txt");
            sw.Write(info[0]);
            sw.Write(Convert.ToString(productid));
            sw.Write(info[2]);
            sw.Write(info[3]);
            sw.Write(info[4]);
            sw.Write(info[5]);
            sw.Write(info[6]);
            sw.Close();

            return prefix(Convert.ToString(productid), 0) + productid;
        }

        private string generate_image_id1()
        {
            int imageid;
            string[] info;

            StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"/data.txt");
            string line = sr.ReadToEnd();
            info = line.Split('\n');

            imageid = Convert.ToInt32(info[3]);
            imageid++;

            sr.Close();

            StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"/data.txt");
            sw.Write(info[0]);
            sw.Write(info[1]);
            sw.Write(info[2]);
            sw.Write(Convert.ToString(imageid));
            sw.Write(info[4]);
            sw.Write(info[5]);
            sw.Write(info[6]);
            sw.Close();

            return prefix(Convert.ToString(imageid), 1) + imageid;
        }

        private string generate_image_id2()
        {
            int imageid;
            string[] info;

            StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"/data.txt");
            string line = sr.ReadToEnd();
            info = line.Split('\n');

            imageid = Convert.ToInt32(info[4]);
            imageid++;

            sr.Close();

            StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"/data.txt");
            sw.Write(info[0]);
            sw.Write(info[1]);
            sw.Write(info[2]);
            sw.Write(info[3]);
            sw.Write(Convert.ToString(imageid));
            sw.Write(info[5]);
            sw.Write(info[6]);
            sw.Close();

            return prefix(Convert.ToString(imageid), 2) + imageid;
        }

        // Changed B to S
        private string prefix(string input, int type)
        {
            int count = 9 - input.Length;
            string add = "";

            if (type == 0)
            {
                add = "S";
            }
            else if (type == 1)
            {
                add = "W";
            }
            else
            {
                add = "X";
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

        // Edit Shirt service --- Done [ possibly remove price adjustment? ] (Dakota)
        public string edit_shirt(string productid, string brand, string size, string color, string material, string gender, string agegroup, string quantity, string priceperitem, string biddingprice, string image1, string image2)
        {
            string result = "Fail";

            string file_location = AppDomain.CurrentDomain.BaseDirectory + @"/shirts.xml";

            XmlDocument xml = new XmlDocument();
            xml.Load(file_location);

            foreach (XmlNode node in xml.SelectNodes("//shirt"))
            {
                string id = node.SelectSingleNode("productid").InnerText;

                if (productid == id)
                {
                    node.SelectSingleNode("brand").InnerText = brand;
                    node.SelectSingleNode("size").InnerText = size;
                    node.SelectSingleNode("color").InnerText = color;
                    node.SelectSingleNode("material").InnerText = material;
                    node.SelectSingleNode("gender").InnerText = gender;
                    node.SelectSingleNode("agegroup").InnerText = agegroup;
                    node.SelectSingleNode("quantity").InnerText = quantity;
                    node.SelectSingleNode("priceperitem").InnerText = priceperitem;
                    node.SelectSingleNode("biddingprice").InnerText = biddingprice;
                    node.SelectSingleNode("image1").InnerText = image1;
                    node.SelectSingleNode("image2").InnerText = image2;

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

        // Delete Shirt service --- Done (Dakota)
        public string delete_shirt(string productid)
        {
            XmlDocument xml = new XmlDocument();

            string file_location = AppDomain.CurrentDomain.BaseDirectory + @"/shirts.xml";

            xml.Load(file_location);

            string result = "";

            foreach (XmlNode node in xml.SelectNodes("//shirt"))
            {
                string foundproductid = node.SelectSingleNode("productid").InnerText;
                if (productid == foundproductid)
                {
                    node.ParentNode.RemoveChild(node);
                    xml.Save(file_location);
                    result = "Pass";
                }
                else
                {
                    result = "Fail";
                }
            }

            return result;
        }

        // Shirt Details service --- Done (Dakota)
        public string[] shirt_details(string productid)
        {
            string result = "Fail";
            string[] details = new string[13];

            string file_location = AppDomain.CurrentDomain.BaseDirectory + @"/shirts.xml";

            XmlDocument xml = new XmlDocument();
            xml.Load(file_location);

            foreach (XmlNode node in xml.SelectNodes("//shirt"))
            {
                string id = node.SelectSingleNode("productid").InnerText;

                if (productid == id)
                {
                    details[0] = productid;
                    details[1] = node.SelectSingleNode("brand").InnerText;
                    details[2] = node.SelectSingleNode("size").InnerText;
                    details[3] = node.SelectSingleNode("color").InnerText;
                    details[4] = node.SelectSingleNode("material").InnerText;
                    details[5] = node.SelectSingleNode("gender").InnerText;
                    details[6] = node.SelectSingleNode("agegroup").InnerText;
                    details[7] = node.SelectSingleNode("quantity").InnerText;
                    details[8] = node.SelectSingleNode("priceperitem").InnerText;
                    details[9] = node.SelectSingleNode("biddingprice").InnerText;
                    details[10] = node.SelectSingleNode("image1").InnerText;
                    details[11] = node.SelectSingleNode("image2").InnerText;
                    details[12] = node.SelectSingleNode("userid").InnerText;

                    xml.Save(file_location);
                    result = "Pass";
                    break;
                }
                else
                {
                    result = "Fail";
                }
            }

            if (result == "Pass")
            {
                return details;
            }
            else
            {
                string[] error = new string[9];
                for (int i = 0; i < 10; i++)
                {
                    error[i] = "error";
                }

                return error;
            }
        }
    }
}