using System;
using System.Collections.Generic;
using System.Linq;

namespace Bangazon.Managers
{
    public class PaymentTypeManager
    {
        private List<PaymentType> _paymentType = new List<PaymentType>();

        public void AddPaymentType(PaymentType paymentType)
        {
            _paymentType.Add(paymentType);
        }
    }
}