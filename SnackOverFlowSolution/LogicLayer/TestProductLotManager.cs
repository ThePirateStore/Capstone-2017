﻿using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class TestProductLotManager : IProductLotManager
    {
        public ProductLot RetrieveNewestProductLotBySupplier(Supplier supplier)
        {
            return new ProductLot
            {
                ProductLotId = 10000,
                ProductId = 1,
                SupplierId = supplier.SupplierId,
                WarehouseId = 1,
                LocationId = 1,
                AvailableQuantity = 500,
                Quantity = 1000,
                SupplyManagerId = 10000,
                DateReceived = DateTime.Now,
                ExpirationDate = DateTime.Now.AddDays(7.0)
            };
        }
    }
}