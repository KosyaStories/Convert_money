using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convert_money
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double walletRub;
            double walletUsd;
            double walletEur;

            double rubToUsd = 70.4, usdToRub = 79.4;
            double rubToEur = 75.4, eurToRub = 84.4;
            double usdToEur = 1, eurToUsd = 0.94;

            double canToSolvency;
            string exchangeOperation;

            Console.SetCursorPosition(0, 23);
            Console.WriteLine("Курсы Валют на сегодня:");
            Console.WriteLine($"Покупка рубля - USD: {rubToUsd}, EUR: {rubToEur}");
            Console.WriteLine($"Продажа рубля - USD: {usdToRub}, EUR: {eurToRub}");
            Console.WriteLine($"Покупка/продажа доллара - EUR: {usdToEur} / {eurToUsd}");


            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Добро пожаловать в наш обменник валют!");
            Console.Write("Ведите баланс рублей: ");
            walletRub = Convert.ToSingle(Console.ReadLine());
            if (walletRub < 0)
            {
                WriteError("Введено недопустимое значение.");
            }
            Console.Write("Ведите баланс долларов: ");
            walletUsd = Convert.ToSingle(Console.ReadLine());
            if (walletUsd < 0)
            {
                WriteError("Введено недопустимое значение.");
            }
            Console.Write("Ведите баланс евро:");
            walletEur = Convert.ToSingle(Console.ReadLine());
            if (walletEur < 0)
            {
                WriteError("Введено недопустимое значение.");
            }
            if (walletRub < 0 || walletUsd < 0 || walletEur < 0)
            {
                WriteError("Ошибка операции.");
            }
            else
            {
                Console.WriteLine("Выберите необходимую операцию.");
                Console.WriteLine("1 - обмен рублей в доллары.");
                Console.WriteLine("2 - обмен долларов в рубли.");
                Console.WriteLine("3 - обмен рублей в евро.");
                Console.WriteLine("4 - обмен евро в рубли.");
                Console.WriteLine("5 - обмен долларов в евро.");
                Console.WriteLine("6 - обмен евро в доллары.");
                Console.Write("Ваш выбор:");
                exchangeOperation = Console.ReadLine();

                switch (exchangeOperation)
                {
                    case "1":
                        Console.WriteLine("Операция обмена рублей на доллары:");
                        Console.Write("Сколько рублей желаете обменять? - ");
                        canToSolvency = Convert.ToSingle(Console.ReadLine());

                        if (walletRub >= canToSolvency && canToSolvency > 0)
                        {
                            walletRub -= canToSolvency;
                            walletUsd += canToSolvency / rubToUsd;
                        }
                        else
                        {
                            WriteError("Недостаточно средств на балансе либо введено недопустимое значение.");
                        }
                        break;
                    case "2":
                        Console.WriteLine("Операция обмена долларов на рубли:");
                        Console.Write("Сколько долларов желаете обменять? - ");
                        canToSolvency = Convert.ToSingle(Console.ReadLine());

                        if (walletUsd >= canToSolvency && canToSolvency > 0)
                        {
                            walletUsd -= canToSolvency;
                            walletRub += canToSolvency * usdToRub;
                        }
                        else
                        {
                            WriteError("Недостаточно средств на балансе либо введено недопустимое значение.");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Операция обмена рублей на евро:");
                        Console.Write("Сколько рублей желаете обменять? - ");
                        canToSolvency = Convert.ToSingle(Console.ReadLine());

                        if (walletRub >= canToSolvency && canToSolvency > 0)
                        {
                            walletRub -= canToSolvency;
                            walletEur += canToSolvency / rubToEur;
                        }
                        else
                        {
                            WriteError("Недостаточно средств на балансе либо введено недопустимое значение.");
                        }
                        break;
                    case "4":
                        Console.WriteLine("Операция обмена евро на рубли:");
                        Console.Write("Сколько евро желаете обменять? - ");
                        canToSolvency = Convert.ToSingle(Console.ReadLine());

                        if (walletEur >= canToSolvency && canToSolvency > 0)
                        {
                            walletEur -= canToSolvency;
                            walletRub += canToSolvency * eurToRub;
                        }
                        else
                        {
                            WriteError("Недостаточно средств на балансе либо введено недопустимое значение.");
                        }
                        break;
                    case "5":
                        Console.WriteLine("Операция обмена долларов на евро:");
                        Console.Write("Сколько долларов желаете обменять? - ");
                        canToSolvency = Convert.ToSingle(Console.ReadLine());

                        if (walletUsd >= canToSolvency && canToSolvency > 0)
                        {
                            walletUsd -= canToSolvency;
                            walletEur += canToSolvency / usdToEur;
                        }
                        else
                        {
                            WriteError("Недостаточно средств на балансе либо введено недопустимое значение.");
                        }
                        break;
                    case "6":
                        Console.WriteLine("Операция обмена евро на доллары:");
                        Console.Write("Сколько евро желаете обменять? - ");
                        canToSolvency = Convert.ToSingle(Console.ReadLine());

                        if (walletEur >= canToSolvency && canToSolvency > 0)
                        {
                            walletEur -= canToSolvency;
                            walletUsd += canToSolvency * eurToUsd;
                        }
                        else
                        {
                            WriteError("Недостаточно средств на балансе либо введено недопустимое значение.");
                        }
                        break;
                    default:
                        Console.WriteLine("Введена неверная операция.");
                        break;
                }
                Console.WriteLine($"Ваш баланс: {walletRub} руб., " + $" {walletUsd} usd., " + $" {walletEur} eur. ");
            }
        }

        static void WriteError(string text)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ForegroundColor = defaultColor;
        }
    }
}
