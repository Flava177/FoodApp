﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Order
    {
        [Column("OrderId")]
        public Guid Id { get; set; }

        [Range(typeof(DateTime), "{0}", "12/31/2024", ErrorMessage = "Order date must be between {1} and {2}.")]
        public DateTime OrderDate { get; set; }

        [Range(typeof(DateTime), "{0}", "12/31/2025", ErrorMessage = "Requested Delivery Time must be between {1} and {2}.")]
        public DateTime RequestedDeliveryTime { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        public decimal TotalAmount { get; set; }

        [Range(0, 10, ErrorMessage = "Quantity must be between 0 and 50.")]
        public int? Quantity { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public User? User { get; set; }

        [ForeignKey(nameof(Restaurant))]
        public Guid RestaurantId { get; set; }
        public Restaurant? Restaurant { get; set; }

        [ForeignKey(nameof(OrderStatus))]
        public int OrderStatusId { get; set; }
        public OrderStatus? OrderStatus { get; set; }

        [ForeignKey(nameof(DispatchDriver))]
        public Guid DispatchDriverId { get; set; }
        public DispatchDriver? DispatchDriver { get; set; }

        [ForeignKey(nameof(MenuItem))]
        public Guid MenuItemId { get; set; }
        public MenuItem? MenuItem { get; set; }

    }
}
