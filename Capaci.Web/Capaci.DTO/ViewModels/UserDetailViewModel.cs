using System;
using System.Collections.Generic;
using System.Text;

namespace Capaci.DTO.ViewModels
{
    public  class UserDetailViewModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public int PhoneNumber { get; set; }
        public string FullAddress { get; set; }
        public bool isCreator { get; set; }
    }
}
