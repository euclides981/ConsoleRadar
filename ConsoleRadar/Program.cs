using System;
using System.Linq;
using System.Threading;

namespace Detran
{
    internal class Program
    {
        public const decimal limite = 100;

        public static void Main()

        {
            Console.WriteLine("Digite o número de Veículos que deseja analizar\n");
            int numUser = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\n- - - - - - - - - - - - -\n");

            int multados = 0;
            int suspensas = 0;


            for (int i = 1; i <= numUser; i++)
            {

                string aviso;

                string placa = GeraPlaca(3, 4);

                decimal vel = new Random().Next(40, 160);

                decimal percent = CalcularPercentual(vel);

                Console.WriteLine("Radar C# -Jundiaí-SP\n\n" + "Limite da Via: " + limite + "\n");

                Console.WriteLine("Placa Do Veículo: " + placa + "\n");

                Console.WriteLine("Velocidade No Radar: " + vel + " Km/h\n");

                if (percent > 5)
                {

                    if (percent >= 5 && percent <= 20)
                    {
                        aviso = "Multa de R$250,00";
                    }
                    else if (percent > 20 && percent <= 50)
                    {
                        aviso = "Multa de R$500,00";
                    }
                    else
                    {
                        aviso = "Multa de R$1500,00\nSuspenção da CNH";
                        suspensas++;
                    }
                    Console.WriteLine("Veículo passou a: " + CalcularPercentual(vel) + "% Acima da Velocidade Permitida...\n" + aviso);

                    multados++;
                }
                else
                {
                    Console.WriteLine("Dentro do Limite... Sem Multa!");
                }

                Console.WriteLine("\n- - - - - - - - - - - - -\n");

                if (multados % 2 == 0)
                {
                    Thread.Sleep(1000);
                }
                else
                {
                    Thread.Sleep(2000);
                }

            }
            int dentroDaVelocidade = numUser - multados;

            Console.WriteLine("Fim da Analise" +
                "\nTotal de Veículos Analizados: " + numUser +
                "\nTotal de Veículos Regular: " + dentroDaVelocidade +
                "\nTotal de Veículos Multados: " + multados +
                "\nTotal de Carteiras Suspensas: " + suspensas +
                "\n\n-----------");

            Pausa();
        }

        public static string GeraPlaca(int tamanho, int tamanhoNums)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var nums = "0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, tamanho)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            var resultNums = new string(
                Enumerable.Repeat(nums, tamanhoNums)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());

            result = result + "-" + resultNums;

            return result;
        }

        public static decimal CalcularPercentual(decimal velocidadeVeiculo)
        {
            decimal percentual = ((velocidadeVeiculo / limite) - 1) * 100;

            if (percentual < 0)
            {
                return 0;
            }

            percentual = Decimal.Floor(percentual);

            return percentual;
        }

        public static void Pausa()
        {
            Console.WriteLine("Digite 1  - Para Fazer outra Analise.\nDigite Qualquer outro Para Sair");

            string escolha = Console.ReadLine();

            if (escolha != "1")
            {
                Environment.Exit(0);
            }
            else
            {
                Console.Clear();
                Main();
            }


        }

    }

}
