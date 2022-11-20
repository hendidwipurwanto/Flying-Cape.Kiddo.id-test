using System;
using System.Collections.Generic;
using System.Text;

namespace Capaci.DTO.Models
{
    public class UserDetail
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string FullAddress { get; set; }
        public bool isCreator { get; set; }
    }
}
