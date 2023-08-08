using PractiseTests.Data.Entities;
using System;

namespace PractiseTests.Data.Entities
{
    class CheckoutStore
    {
        private readonly PaypalPaymentProcessor _paymentProcessor;
        public CheckoutStore(PaypalPaymentProcessor paymentProcessor)
        {
            this._paymentProcessor = paymentProcessor;
        }

        public void purchaseBook(int quantity, decimal price)
        {
            this._paymentProcessor.pay(quantity * price);
        }

        public void purchaseCourse(int quantity, decimal price)
        {
            this._paymentProcessor.pay(quantity * price);
        }
    }

    class PaypalPaymentProcessor
    {
        private readonly Paypal _stripe;
        public PaypalPaymentProcessor(Paypal stripeusr)
        {
            this._stripe = stripeusr;
        }

        public void pay(decimal amountInDollars)
        {
            this._stripe.makePayment(amountInDollars);
        }
    }

    class Paypal
    {
        private readonly string _user;
        public Paypal(string usr)
        {
            this._user = usr;
        }

        public void makePayment(decimal amountInDollars)
        {
            //Response.log("${ this._user} made payment of ${ amountInDollars}");
        }
    }

    //class user
    //{
    //    public string username { get; set; }

    //    public user(string name)
    //    {
    //        username = name;
    //    }
    //}

    //private user usr = new("John Doe");
   
    //private PaypalPaymentProcessor stripepayment = new PaypalPaymentProcessor(new Paypal("John Doe"));
    //private Store store = stripepayment;
    //store.purchaseBook(2, 10);
    //store.purchaseCourse(1, 15);
        
}
