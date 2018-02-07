using System;
using Xunit;
using Bangazon;
using System.Collections.Generic;

namespace Bangazon.Tests
{
    public class PaymentManagerShould
    {

        private PaymentType _paymentType;
        public PaymentManagerShould()
        {
            //Properties of PaymentType hard coded in
            _paymentType = new PaymentType(
                1,
                "Visa",
                128798725
            );

        }

        [Fact]
        public void AddPaymentType()
        {
            Assert.Equal(_paymentType.Id, 1);
        }
    }
}