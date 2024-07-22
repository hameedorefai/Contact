using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsDataAccessLayer;

namespace ContactsBusinessLayer
{
    internal class clsContact
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ImagePath { get; set; }


        //clsContact(int ID, string FirstName, string LastName, string Email, string Phone, string Address,
        //                                    int CountryID, DateTime DateOfBirth, string ImagePath);
        //{
        //    this.ID = ID;


        //}


        public static clsContact Find(int ID)
        {
            string FirstName = "", LastName = "", Email = "", Phone = "",
                    Address = "", ImagePath = "";
            DateTime DateOfBirth= DateTime.Now;
            int CountryID = 1;

            if (clsContactDataAccess.GetContactInfoByID(ID,ref FirstName, ref LastName, ref Email,
                                                        ref Phone, ref Address,ref CountryID, ref DateOfBirth, ref ImagePath))
            {
                return new clsContact(ID, FirstName, LastName, Email, Phone, Address, DateOfBirth, CountryID, ImagePath);
            }    
            return null;
        }
    }
}
