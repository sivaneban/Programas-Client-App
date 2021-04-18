using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DataContext
{
    public static class DBInitializer
    {
        public static void Initialize(CustomerContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Customers.Any())
            {
                return;   // DB has been seeded
            }
            var customers = new Customer[]
            {
                new Customer{Firstname="Carson",Lastname="marlk",Mobile ="077535436",Email="sdfdbfd@gmail.com",Username="Carsonmarlk",CustomerAddress=new Address{AddressFull="1 GEORGE ST, TAMBELLUP WA 6320",AddressLine1="1 GEORGE ST",AddressLine2 ="TAMBELLUP WA 6320",City="TAMBELLUP",State="WA",Postcode="124235",Country="USA"}},
                new Customer{Firstname="Caron",Lastname="karlk",Mobile ="075354236",Email="fsgfdbfd@gmail.com",Username="sdjfdbb asfdjb", CustomerAddress =new Address{AddressFull="1 GEORGE RD, TAMBELLUP WA 6320",AddressLine1="1 GEORGE RD",AddressLine2 ="TAMBELLUP WA 6320",City="TAMBELLUP",State="WA",Postcode="124235",Country="USA"}},
                new Customer{Firstname="Carsdfdon",Lastname="madfdfrlk",Mobile ="011535436",Email="azxdbfd@gmail.com",Username="Asdfd Dlk", CustomerAddress= new Address{AddressFull="84 GEORGE ST, TAMBELLUP WA 6320",AddressLine1="84 GEORGE ST",AddressLine2 ="TAMBELLUP WA 6320",City="TAMBELLUP",State="WA",Postcode="124235",Country="USA"}}
            };
            foreach (Customer c in customers)
            {
                context.Customers.Add(c);
            }
            context.SaveChanges();
/*
            var addresses = new Address[]
            {
                new Address{AddressFull="1 GEORGE ST, TAMBELLUP WA 6320",AddressLine1="1 GEORGE ST",AddressLine2 ="TAMBELLUP WA 6320",City="TAMBELLUP",State="WA",Postcode="124235",Country="USA"},
                new Address{AddressFull="1 GEORGE RD, TAMBELLUP WA 6320",AddressLine1="1 GEORGE RD",AddressLine2 ="TAMBELLUP WA 6320",City="TAMBELLUP",State="WA",Postcode="124235",Country="USA",CustomerId="102"},
                new Address{AddressFull="84 GEORGE ST, TAMBELLUP WA 6320",AddressLine1="84 GEORGE ST",AddressLine2 ="TAMBELLUP WA 6320",City="TAMBELLUP",State="WA",Postcode="124235",Country="USA",CustomerId="104"},
            };
            foreach (Address a in addresses)
            {
                context.Addresses.Add(a);
            }
            context.SaveChanges();
*/
        }

    }
}
