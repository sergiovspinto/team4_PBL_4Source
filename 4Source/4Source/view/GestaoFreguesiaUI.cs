﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _4Source.controllers;


namespace _4Source.views
{
    class GestaoFreguesiaUI
    {
        public static void Menu()
        {
           
                int numInput;

                

                do
                {   
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n===Gestão de Freguesias===\n\n");
                    Console.ResetColor();
                    Console.WriteLine("1 - Inserir Freguesia");
                    Console.WriteLine("2 - Listar Freguesia");
                    Console.WriteLine("3 - Eliminar Freguesia");
                    Console.WriteLine("4 - Alterar Freguesia");
                    Console.WriteLine("5 - Listar Freguesias");
                    Console.WriteLine("\n6 - Voltar\n");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("===========================\n");
                    Console.ResetColor();

                    numInput = Utils.GetIntNumber("Por favor escolha uma opção:");
                    switch (numInput)
                    {

                        case 1:
                            RegistarFreguesia();
                            break;
                        case 2:
                            PesquisarFreguesia();
                            break;
                        case 3:
                            EliminarFreguesia();
                            break;
                        case 4:
                            AlterarFreguesia();
                            break;
                        case 5:
                            ListarFreguesias();
                            break;
                        case 6:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("\nVolta para o menu anterior.\n");
                            Console.ReadKey();

                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nOpção Errada\n");
                            Console.ReadKey();

                            break;
                    }

                } while (numInput != 6);
          

        }
         private static void ListarFreguesias()
        {
            List<Freguesia> lista = RegistoFreguesiaController.ObterListaFreguesias();

            if (lista.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNão existem freguesias inscritas na plataforma actualmente.");
                Console.ResetColor();
            }

            foreach (Freguesia freguesia in lista)
            {
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                Console.WriteLine("------------------------------");
                Console.WriteLine(freguesia.ToString());
                Console.WriteLine("------------------------------");
            }
            Console.ReadKey();
           
        }

        private static void AlterarFreguesia()
        {
            string nome = Utils.GetText("Digite o nome da freguesia que pretende alterar ");
            Freguesia freguesia = RegistoFreguesiaController.PesquisarFreguesia(nome);
            if (freguesia != null)
            {
                Console.WriteLine(freguesia.ToString());
                string nomeNovo = AlterarFreguesia(freguesia);
                RegistoFreguesiaController.AlterarFreguesia(freguesia, nomeNovo);
            }
            else
            {
                Console.Beep();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("A freguesia que indicou não existe na base de dados. Tente novamente.");
                Console.ResetColor();
            }
            Console.ReadKey();
        
        }
        private static void EliminarFreguesia()
        {
            string nome = Utils.GetText("Digite o Nome da Freguesia que quer eliminar: ");
            Freguesia freguesia = RegistoFreguesiaController.EliminarFreguesia(nome);
            if (freguesia != null)
            {
                Console.WriteLine(freguesia.ToString());
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nA freguesia {0} foi eliminada do sistema.", freguesia.Nome);
                Console.ResetColor();
            }
            else
            {
                Console.Beep();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Essa freguesia não existe!");
                Console.ResetColor();
            }
            Console.ReadKey();
      

        }

        private static void PesquisarFreguesia()
        {
            string nome = Utils.GetText("Digite o Nome da Freguesia que pretende pesquisar: ");
            Freguesia freguesia = RegistoFreguesiaController.PesquisarFreguesia(nome);
            if (freguesia != null)
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine(freguesia.ToString());
                Console.WriteLine("------------------------------");
            }
            else
            {
                Console.Beep();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Essa freguesia não existe!");
                Console.ResetColor();
            }
            Console.ReadKey();
    

        }
        private static void RegistarFreguesia()
        {
            Freguesia freguesia = Autarquia.CriarFreguesia();
            RegistoFreguesiaController.RegistarFreguesia(freguesia);
          
        }

       

        public static string AlterarFreguesia(Freguesia freguesia)
        {
            bool flag;
            string nome = "";
           
            do
            {
                try
                {
                    flag = false;
                    nome = Utils.GetText("Nome");
                }
                catch (NomeFreguesiaInvalidoException e)
                {
                    flag = true;
                    Console.Beep();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Atenção: " + e.ToString());
                    Console.ResetColor();
                }
            } while (flag);
            return nome;
        }

    }
}

