using System;
using System.Collections.Generic;
using System.Text;

namespace Capaci.DTO.Models
{
    public class Subscription
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string SubscriberName { get; set; }
        public double Price { get; set; }
        public string PhoneNumber { get; set; }
        public string FullAddress { get; set; }
    }
}
