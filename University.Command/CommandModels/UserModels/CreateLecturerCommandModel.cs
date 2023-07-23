﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Command.CommandModels.UserModels
{
    public class CreateLecturerCommandModel
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirtsDate { get; set; }
        public string PrivateNumber { get; set; }
        public string PhoneNumber { get; set; }
        public int QualificationYare { get; set; }
        public string Profession { get; set; }
    }
}
