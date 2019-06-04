﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoustonOnWire.Lib;
using HoustonOnWire.Models;

namespace HoustonOnWire.OtherLayers
{
    public interface ICustomerService
    {
        PagedList<Customer> GetCustomers(FilterParams filterParams);

        Customer GetCustomer(long id);
    }
}
