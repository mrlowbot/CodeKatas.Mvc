﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CodeKatas.Mvc.Models
{
    public class PersonModel
    {
        public Guid PersonId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? PhoneNumber { get; set; }
    }
}
