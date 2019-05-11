using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AsusLaptop.Models
{
    public enum State
    {
        Pending = 0,
        Accepted = 1,
        canceled = 2
    }
    public class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }
        public int Id { get; set; }

        [Required]
        public string UserAppId { get; set; }

        public State Status { get; set; }

        public DateTime Date { get; set; }

        public virtual UserApp UserApp { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}