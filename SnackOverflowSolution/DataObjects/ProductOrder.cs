﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataObjects
{
    public class ProductOrder
    {
        [Key]
        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public int? EmployeeId { get; set; }
        public String OrderTypeId { get; set; }
        public String AddressType { get; set; }
        public String DeliveryTypeId { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? DateExpected { get; set; }
        public decimal? Discount { get; set; }
        public String OrderStatusId { get; set; }
        public int? UserAddressId { get; set; }
        public bool? HasArrived { get; set; }
        public String Address1 { get; set; }
        public String Address2 { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String Zip { get; set; }
        public List<BackorderPreorder> BackorderPreorderList { get; set; }
        public List<Delivery> DeliveryList { get; set; }
        public List<EmployeeOrderResponsibility> EmployeeOrderResponsibilityList { get; set; }
        public List<Package> PackageList { get; set; }
    }
}
