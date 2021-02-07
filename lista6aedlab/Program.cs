using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lista6aedlab
{
    class Program
    {

        

        public static void Questao1()
        {
            //Luís Fernando
            /*Gravar em um arquivo do tipo BINÁRIO os 20 primeiros números múltiplos de 5.
             * Ler os dados gravados no arquivo e imprimir a soma de todos os valores armazenados no arquivo.*/

            BinaryWriter escrever;
            BinaryReader ler;
            int dado = 0;

            escrever = new BinaryWriter(new FileStream("C:\\Temp\\numeros.bin", FileMode.Create));
            for (int i = 5; i <= 100; i += 5)
                escrever.Write(i + "|");
            escrever.Write("FIM");
            escrever.Close();

            ler = new BinaryReader(new FileStream("C:\\Temp\\numeros.bin", FileMode.Open));
            dado = ler.ReadInt32();
            Console.WriteLine($"{dado}" );
            ler.Close();

            
        }



        public static void Questao2()
        {
            /*Gravar em um arquivo do tipo BINÁRIO uma tabela de conversão de temperaturas Fahrenheit para temperaturas Celsius 
             * fazendo a temperatura Fahrenheit variar de 32 a 212 º. Ler o arquivo gravado  e mostrar o seu conteúdo na tela.*/

            BinaryWriter escrever;
            escrever = new BinaryWriter(new FileStream("C:\\Temp\\numeros.bin", FileMode.Create));
            for (int celsius = 32; celsius <= 212; celsius++)
            {
                double fahrenheit = ((celsius * 9) / 5) + 32;
                escrever.Write($"{celsius}C° equivale a {fahrenheit}F°\n");
            }
            escrever.Close();
            String[] linhas = File.ReadAllLines("C:\\Temp\\numeros.bin");
            foreach (var o in linhas)
                Console.WriteLine(o);

           
        }


        public static void Questao3()
        {
            /*Ler um número inteiro e gravar vem um arquivo BINÁRIO os divisores do número. 
             * Abrir o arquivo para leitura e mostrar a quantidade de divisores ímpares do número.*/

            BinaryWriter escrever;
            int numero, quantidadeImpar = 0;

            Console.Write("Digite um número: ");
            numero = int.Parse(Console.ReadLine());

            escrever = new BinaryWriter(new FileStream("C:\\Temp\\numeros.bin", FileMode.Create));
            for (int i = 1; i <= numero; i++)
            {
                if (numero % i == 0)
                    escrever.Write($"O número {i} é divisor de {numero}");

                if (i % 2 != 0)
                    quantidadeImpar++;
            }
            escrever.Write($"\nQuantidade de divisores ímpares: {quantidadeImpar}");
            escrever.Close();

            String[] linhas = File.ReadAllLines("C:\\Temp\\numeros.bin");

            foreach (var conteudo in linhas)
                Console.WriteLine(conteudo);

            
        }

        public static void Questao4()
        {
            /*Gravar em um arquivo do tipo Binário os 20 primeiros termos da série: 5 6 11 12 17 18 ...*/

            BinaryWriter escrever;
            int termo = 5;

            escrever = new BinaryWriter(new FileStream("C:\\Temp\\numeros.bin", FileMode.Create));
            for (int i = 0; i < 20; i++)
            {
                escrever.Write("|" + (termo) + "|");
                termo += 1;
                escrever.Write("|" + (termo) + "|");
                termo += 5;
            }
            escrever.Write("FIM");
            escrever.Close();

            
        }

        public static void Questao5()
        {
            /*Ler do teclado um conjunto de dados contendo a altura e o sexo (‘F’ para feminino e ‘M’ para masculino) de 10 pessoas. 
             * Gravar em um arquivo do tipo BINÁRIO:
             * A maior altura do grupo
             * A menor altura do grupo
             * A média de altura das mulheres*/

            BinaryWriter escrever;
            bool verifica = false;
            int contador = 0, menorAltura = 0;
            int maiorAltura = 0, amulheres = 0;
            int[] Altura = new int[10];

            for (int i = 0; i < Altura.Length; i++)
            {
                do
                {
                    Console.Write("Sexo: ");
                    char sexo = char.Parse(Console.ReadLine().ToUpper());

                    if (sexo == 'F' || sexo == 'M')
                        verifica = true;
                    else
                        Console.WriteLine("Inválido.");

                    if (sexo == 'F')
                        contador++;
                } while (verifica != true);
                Console.Write("Altura (Em cm): ");
                int altura = int.Parse(Console.ReadLine());
                Altura[i] = altura;
                amulheres += altura;
            }
            for (int i = 0; i < 10; i++)
                for (int j = i + 1; j <= 10; j++)
                {
                    if (Altura[i] < Altura[j])
                        menorAltura = Altura[i];

                    if (Altura[i] > Altura[j])
                        maiorAltura = Altura[i];
                }
            escrever = new BinaryWriter(new FileStream("C:\\Temp\\numeros.bin", FileMode.Create));
            escrever.Write($"Maior altura: {maiorAltura}\nMenor altura: {menorAltura}\nMédia da altura feminina: {amulheres / contador}");
            escrever.Close();

            
        }



        public static void Questoes()
        {

            int opcao;

            Console.Write("Digite o número da questão a abrir: ");
            opcao = int.Parse(Console.ReadLine());

            switch(opcao){
                case 1:
                    Questao1();
                    Questoes();
                    break;
                case 2:
                    Questao2();
                    Questoes();
                    break;
                case 3:
                    Questao3();
                    Questoes();
                    break;
                case 4:
                    Questao4();
                    Questoes();
                    break;
                case 5:
                    Questao5();
                    Questoes();
                    break;
                default:
                    Questoes();
                    break;
            }
        }













        static void Main(string[] args)
        {


            Questoes();

            Console.ReadKey();


        }
    }
}
