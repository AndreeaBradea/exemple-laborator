using System;
using Lucrarea01.Domain;
using System.Collections.Generic;
using static Lucrarea01.Domain.Cos;

namespace Lucrarea01
{
    class Program
    {

        static void Main(string[] args)
        {

            
                var ListaProduse = ReadProduse().ToArray();
                var DetaliiC = ReadDetails();

                CosNevalid CosNevalid = new(ListaProduse, DetaliiC);

                ICos result = CheckCos(CosNevalid);
                result.Match(
                    whenCosNevalid: CosNevalid => CosNevalid,
                    whenCosGol: invalidResult => invalidResult,
                    whenCosInvalid: invalidResult => invalidResult,
                    whenCosValid: CosValid => CosPlatit(CosValid, DetaliiC,DateTime.Now),
                    whenCosPlatit: cosPlatit => cosPlatit
                    
                );
                string mesaj = result.ToString().Substring(0, 10);
                Console.WriteLine(mesaj);

           

        }
        private static ICos CheckCos(CosNevalid CosNevalid) =>
           ( (CosNevalid.ProduseList.Count == 0) ? new CosGol(new List<ProduseNevalidate>(), "Cosul este gol")
                : ((string.IsNullOrEmpty(CosNevalid.DetaliiC.Adresa.Value))? new CosInvalid(new List<ProduseNevalidate>(), "Cosul este Invalid")
                      :( (CosNevalid.DetaliiC.StatusPlata.Value == 0) ? new CosValid(new List<ProduseValidate>(), CosNevalid.DetaliiC)
                             :new CosPlatit(new List<ProduseValidate>(), CosNevalid.DetaliiC, DateTime.Now))));
        
        private static ICos CosPlatit(CosValid validatedResult, DetaliiC DetaliiC, DateTime PublishedDate) =>
                new CosPlatit(new List<ProduseValidate>(), DetaliiC, DateTime.Now);

        private static List<ProduseNevalidate> ReadProduse()
        {
            List<ProduseNevalidate> ListaProduse = new();
            object answer = null;
            do
            {
                answer = ReadValue("Doriti sa adaugati un produs in cos? [da/nu]: ");

                if (answer.Equals("da") || answer.Equals("Da") || answer.Equals("DA"))
                {
                    var ProdusID = ReadValue("ID-ul produsului: ");
                    if (string.IsNullOrEmpty(ProdusID))
                    {
                        break;
                    }

                    var ProdusCantitate = ReadValue("Cantitatea produsului: ");
                    if (string.IsNullOrEmpty(ProdusCantitate))
                    {
                        break;
                    }
                    ProduseNevalidate toAdd = new(ProdusID, ProdusCantitate);
                    ListaProduse.Add(toAdd);
                }

            } while (!answer.Equals("nu") || answer.Equals("Nu") || answer.Equals("NU"));
            
            return ListaProduse;
        }

        public static DetaliiC ReadDetails()
        {
            StatusPlata StatusPlata;
            Adresa Adresa;
            DetaliiC DetaliiC;

            string answer = ReadValue("Driti sa finalizezi comanda? [da/nu]: ");

            if (answer.Contains("da") || answer.Equals("Da") || answer.Equals("DA"))
            {

                var Address = ReadValue("Adresa: ");
                if (string.IsNullOrEmpty(Address))
                {
                    Adresa = new Adresa("");
                }
                else
                {
                    Adresa = new Adresa(Address);
                }
                var payment = ReadValue("Doriti sa finalizati plata? [da/nu]: ");
                if (payment.Contains("da") || answer.Equals("Da") || answer.Equals("DA"))
                {
                    StatusPlata = new StatusPlata(1);
                }
                else
                {
                    StatusPlata = new StatusPlata(0);
                }
            }
            else
            {
                Adresa = new Adresa("");
                StatusPlata = new StatusPlata(0);
            }
            DetaliiC = new DetaliiC(Adresa, StatusPlata);
            return DetaliiC;
         }

        private static string? ReadValue(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

    }
}
