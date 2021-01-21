using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InnoLoft.Utility
{
    public class Message
    {
        public static string ok = "Ok";
        public static string someThingWentWrong = "Something went wrong";
        public static string badRequest = "Bad Request";
        public static string found = " found";
        public static string notFound = " not found";
        public static string alreadyExists = " already exists";
        public static string added = " added successfully";
        public static string addedError = " added un-successfully";
        public static string updated = " updated successfully";
        public static string updatedError = " updated un-successfully";
        public static string deleted = " deleted successfully";
        public static string deletedError = " deleted un-successfully";
        public static string referenceError = "Unable to delete due to historical data";
    }

    public class Entity
    {
        public static string Product = "Product";
    }
}
