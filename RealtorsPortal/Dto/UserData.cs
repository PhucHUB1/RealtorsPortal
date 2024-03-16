using System;

namespace RealtorsPortal.Dto
{ 
    public class UserData
    {
        public int Id { get; set; }
        public string UserName { get; set; } = "";
        public string Email { get; set; } = ""; 
        public string? Token { get; set; }
        public string? Phone { get; set; } = "";
        public string? PersonalTaxCode { get; set; }
        public string? Picture { get; set; }
        
    }
}