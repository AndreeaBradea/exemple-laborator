using Exemple.Domain.Models;
using System;
using System.Collections.Generic;
using static Exemple.Domain.Models.Carucior;
using static Exemple.Domain.PriceOperations;
using Exemple.Domain;

namespace MainProgram
{
    class Program
    {
        private static readonly Random random = new Random();

        static void Main(string[] args)
        {
            var listOfProducts = ReadListOfProducts().ToArray();
            PublishQuantityCommand command = new(listOfProducts);
            PublishProductWorkflow workflow = new PublishProductWorkflow();
            var result = workflow.Execute(command, (productCode) => true);

            result.Match(
                    whenPaidCaruciorFaildEvent: @event =>
                    {
                        Console.WriteLine($"Publish failed: {@event.Reason}");
                        return @event;
                    },
                    whenPaidCaruciorScucceededEvent: @event =>
                    {
                        Console.WriteLine($"Publish succeeded.");
                        return @event;
                    }
                );

            Console.WriteLine("END!");
        }

        private static List<UnvalidatedProductQuantity> ReadListOfProducts()
        {
            List<UnvalidatedProductQuantity> listOfProducts = new();
            string flag = "N";
            do
            {
                var productCode = ReadValue("Cod produs: ");
                while (string.IsNullOrEmpty(productCode))
                {
                    productCode = ReadValue("Codul nu trebuie sa fie vid: ");
                }

                var quantity = ReadValue("Cantitate: ");
                while (string.IsNullOrEmpty(quantity))
                {
                    quantity = ReadValue("Cantitatea nu trebuie sa fie vida: ");
                }

                var address = ReadValue("Adresa: ");
                while (string.IsNullOrEmpty(address))
                {
                    address = ReadValue("Adresa nu trebuie sa fie vida: ");
                }

                listOfProducts.Add(new(productCode, quantity, address));
                flag = ReadValue("Adaugati si alte produse? [Y/N] ");
            } while (flag != "N");
            return listOfProducts;
        }

        private static string? ReadValue(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}
