using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Authorization
{
    public class PolitycyNames
    {
        public const string HasFirstName = "HasFirstName";

        public const string HasLastName = "HasLastName";

        public const string HasCountry = "HasCountry";

        public const string Over18YearsOld = "Over18YearsOld";
    }
    
    public class AppClaimTypes
    {
        public const string FirstName = "FirstName";

        public const string LastName = "LastName";

        public const string Country = "Country";  
        
        public const string DateOfBirth = "DateOfBirth";        
    }
}
