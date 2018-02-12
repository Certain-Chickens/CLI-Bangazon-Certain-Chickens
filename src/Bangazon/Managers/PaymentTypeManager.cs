using System;
using System.Collections.Generic;
using Bangazon;
using Bangazon.Managers;
using Microsoft.Data.Sqlite;

namespace Bangazon.Managers
{
    public class PaymentTypeManager
    {
        private List<PaymentType> _paymentType = new List<PaymentType>();

        private DatabaseConnection _db;

        // set the private DatabaseConnection variable _db to equal a DatabaseConnection named db provided as an argument
        public PaymentTypeManager(DatabaseConnection db)
        {
            _db = db;
        }

        public int AddPaymentType(PaymentType paymentType)
        {
            // _paymentType.Add(paymentType);

            int id = _db.Insert( $"insert into PaymentType values (null, '{paymentType.Name}', '{paymentType.AccountNumber}')");

            return id;
        }
    }
}