using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Statia
{
    internal class Program
    {
        internal struct FullName
        {
            public string Surname { get; set; }
            public string Name { get; set; }
            public string Patronymic { get; set; }

            public override string ToString()
            {
                return $"{this.Surname} {this.Name} {this.Patronymic}";
            }
        }

        internal class Client
        {
            static int nextCode = 0;

            public int Code { get; set; }
            public FullName Name { get; set; }
            public string Adress { get; set; }
            public string phone;
            public int OrdersCount { get; set; }
            public decimal TotalPurchaseAmount { get; set; }

            public string Phone
            {
                get { return phone; }
                set
                {
                    string digitsOnly = new string(value.Where(char.IsDigit).ToArray());

                    if (digitsOnly.Length != 11)
                    {
                        throw new ArgumentException("Неправильный формат номера");
                    }

                    phone = $"+7 ({digitsOnly.Substring(1, 3)}) {digitsOnly.Substring(4, 3)}-{digitsOnly.Substring(7, 2)}-{digitsOnly.Substring(9, 2)}";
                }
            }

            public Client(FullName iname, string iadress, string iphone)
            {
                nextCode++;
                this.Code = nextCode;
                this.Name = iname;
                this.Adress= iadress;
                this.Phone = iphone;
                this.OrdersCount = 0;
                this.TotalPurchaseAmount = 0;
            }

            public void PrintClient()
            {
                Console.WriteLine($"Код                : {this.Code}               ");
                Console.WriteLine($"ФИО                : {this.Name}               ");
                Console.WriteLine($"Адрес              : {this.Adress}             ");
                Console.WriteLine($"Телефон            : {this.Phone}              ");
                Console.WriteLine($"Количество заказов : {this.OrdersCount}        ");
                Console.WriteLine($"Общая сумма покупки: {this.TotalPurchaseAmount}");
            }
        }

        static void Main(string[] args)
        {
            Article p1 = new Article("Nikita Ilyin", "Ekonomika", "15.12.2016");
            p1.PrintArticle();
            Console.WriteLine();

            Client c1 = new Client(
                new FullName()
                {
                    Surname = "Ilyin",
                    Name = "Nikita",
                    Patronymic = "Vladimirovich"
                },
                "Байконур 1",
                " flm7(906)5063132");
            c1.PrintClient();
            Console.WriteLine();
            Console.WriteLine(c1.Name.Name); 

            FullName fullName2 = new FullName()
            {
                Surname = "Ilyina",
                Name = "Anna",
                Patronymic = "Nikolaevna"
            };

            Client c2 = new Client(fullName2, "Байконур 11", " flm7(909)251 5669");
            c2.PrintClient();
            Console.WriteLine();
        }
    }
}
