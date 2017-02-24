using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ASU_E_Commerce_Web_Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string sign_up(string fname, string lname, string pname, string email, string id, string pword, string street1, string street2, string city, string state, string zip, string host_email, string host_credential);

        [OperationContract]
        string[] sign_in(string id, string pword, string host_email, string host_credential);

        [OperationContract]
        string[] get_user_info(string login, string host_email, string host_credential);

        [OperationContract]
        string edit_user_info(string userid, string pname, string email, string loginid, string n_pword, string rn_pword, string st_addr1, string st_addr2, string city, string state, string zip, string host_email, string host_credential);

        [OperationContract]
        string add_books(string login_id, string isbn, string title, string subject, string quantity, string price, string bidding, string host_email, string host_credential);

        /*
        [OperationContract]
        string edit_books(string product_id, string isbn, string title, string subject, string quantity, string price, string bidding, string host_email, string host_credential);
        */

        [OperationContract]
        string edit_books(string userid, string product_id, string isbn, string title, string subject, string quantity, string price, string bidding, string host_email, string host_credential);


        [OperationContract]
        string delete_book(string productid, string host_email, string host_credential);

        [OperationContract]
        string[] book_details(string productid, string host_email, string host_credential);

        [OperationContract]
        LinkedList<string> search_books(string type, string input, string host_email, string host_credential);

        [OperationContract]
        LinkedList<string> list_products(string id, string host_email, string host_credential);

        [OperationContract]
        string add_shirts(string brand, string size, string color, string material, string gender, string agegroup, string quantity, string price, string bidding, string userid, string host_email, string host_credential);

        [OperationContract]
        string edit_shirt(string productid, string brand, string size, string color, string material, string gender, string agegroup, string quantity, string price, string bidding, string image1, string image2, string host_email, string host_credential);

        [OperationContract]
        string delete_shirt(string productid, string host_email, string host_credential);

        [OperationContract]
        string[] shirt_details(string productid, string host_email, string host_credential);

        [OperationContract]
        string add_cart(string userid, string productid, string quantity, string host_email, string host_credential);

        [OperationContract]
        bool checkProductExists(string productid, string host_email, string host_credential);

        [OperationContract]
        string checkCurrentQuantity(string productid, string quantity, string host_email, string host_credential);

        [OperationContract]
        string checkCurrentPrice(string productid, string price, string host_email, string host_credential);

        [OperationContract]
        LinkedList<string> product_list(string userid, string host_email, string host_credential);

        [OperationContract]
        LinkedList<string> quantity(string userid, string host_email, string host_credentials);
        /*
        [OperationContract]
        string[,] listCartProducts(string userid, string host_email, string host_credential);
        */
        [OperationContract]
        string remove_cart(string userid, string productid, string quantity, string host_email, string host_credentials);
    }
}
