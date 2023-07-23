﻿namespace University.Command.CommandModels.AuthModels
{
    public class RegisterLecturerCommandModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirtsDate { get; set; }
        public string PrivateNumber { get; set; }
        public string PhoneNumber { get; set; }
        public int QualificationYare { get; set; }
        public string Profession { get; set; }
    }
}
