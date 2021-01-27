using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProductModuleDataAccess.Models
{
    public class Contacts
    {
        [Key]
        public int contactsid { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string mobileno { get; set; }

        public override string ToString()
        {
            return $"contactsid : {contactsid}\n" +
                $"name: {name}\n mobileno : {mobileno}";
        }
    }
}
