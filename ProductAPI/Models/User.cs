namespace ProductAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using Microsoft.IdentityModel.Tokens;

    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id
        {
            get;
            set;
        }

        public string name
        {
            get;
            set;
        }

        public string username
        {
            get;
            set;
        }

        public string password
        {
            get;
            set;
        }

        public string email
        {
            get;
            set;
        }

        public string phone
        {
            get;
            set;
        }

        public string website
        {
            get;
            set;
        }

        public ICollection<Product> products
        {
            get;
            set;
        }

        public Address address
        {
            get;
            set;
        }

        public int companyId
        {
            get;
            set;
        }

        public Company company
        {
            get;
            set;
        }

        public bool isValidPassword(string inputPassword)
        {
            return password == inputPassword;
        }
    }
}