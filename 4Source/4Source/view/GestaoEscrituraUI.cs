﻿using _4Source.controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _4Source.views {
    class GestaoEscrituraUI {

        public static void Menu() {
           
                int numInput;
               

                do
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.ResetColor();
                    Console.WriteLine("\n=== Gestão de Escrituras ===\n\n");
                    Console.WriteLine("1 - Registar Escritura");
                    Console.WriteLine("2 - Pesquisar Escritura");
                    Console.WriteLine("3 - Eliminar Escritura");
                    Console.WriteLine("4 - Mostrar Lista de Escrituras");
                    Console.WriteLine("5 - Calcular Percentagem de Posse de Terreno");
                    Console.WriteLine("\n6 - Voltar ao Menu Principal\n");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("===========================\n");
                    Console.ResetColor();
                    numInput = Utils.GetIntNumber("Por favor escolha uma opção:");
                    switch (numInput)
                    {
                        case 1:
                            RegistarEscritura();
                            break;
                        case 2:
                            PesquisarEscritura();
                            break;
                        case 3:
                            EliminarEscritura();
                            break;
                        case 4:
                            ListarEscrituras();
                            break;
                        case 5:
                            CalcularPercentagem();
                            break;
                        case 6:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("\nVolta para o menu anterior.\n");
                            Console.ReadKey();
                            break;
                        default:
                            Console.Beep();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nOpção errada. Escolha novamente.\n");
                            break;
                    }
                } while (numInput != 6);
           
    
           
        }

        private static void ListarEscrituras() {
            List<Escritura> lista = RegistoEscrituraController.ObterListaEscrituras();
            foreach (Escritura escritura in lista) {

                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                Console.WriteLine(escritura.ToString());
            }
            Console.ReadKey();
      
        }


        private static void EliminarEscritura() {
            int num = Utils.GetIntNumber("Digite o numero da escritura:");
            Escritura escritura = RegistoEscrituraController.EliminarEscritura(num);
            if (escritura != null) {
                Console.WriteLine(escritura.ToString());
            } else {
                Console.Beep();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Não  existe!!!");
            }
         
        }

        private static void PesquisarEscritura() {
            int num = Utils.GetIntNumber("Digite o numero da escritura:");
            Escritura escritura = RegistoEscrituraController.PesquisarEscritura(num);
            if (escritura != null) {
                Console.WriteLine(escritura.ToString());
            } else {
                Console.Beep();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Não existe!!!");
            }
            Console.ReadKey();
          
        }

        private static void RegistarEscritura() {
            Escritura escritura = Terreno.CriarEscritura();
            RegistoEscrituraController.RegistarEscritura(escritura);
          
        }

      

        public static void CalcularPercentagem() {
            Console.WriteLine("Quantos proprietários tem o terreno?");
            int numProprietarios = int.Parse(Console.ReadLine());
            double percentagem = 0;
            double totalPercentagem = 0;
            double[] array = new double[numProprietarios];
            int count = 1;

            for (int i = 0; i < numProprietarios; i++) {
                Console.WriteLine("Introduza a percentagem do proprietario:");
                percentagem = double.Parse(Console.ReadLine());
                array[i] = percentagem;
                totalPercentagem += percentagem;
            }
            foreach (double perc in array) {

                Console.WriteLine("O proprietário {0} possui {1} % do terreno.", count, perc);
                count += 1;
            }
            double sum = array.Sum();
            Console.WriteLine("Posse total dos proprietários em relação ao terreno: {0} ", sum);
        }
    }
}
