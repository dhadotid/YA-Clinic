using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YA_Clinic.model
{
    public class PaymentHelperModel
    {
        public double totalPayment { get; set; }
        public PaymentHelperModel()
        {

        }
        public PaymentHelperModel(double totalPayment)
        {
            this.totalPayment = totalPayment;
        }
    }
}