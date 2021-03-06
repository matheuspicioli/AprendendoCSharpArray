﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteBank.Modelos;
using ByteBank.Modelos.Funcionarios;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
        }

        static void TestarListaContaCorrente()
        {
            ListaDeContaCorrente lista = new ListaDeContaCorrente();

            ContaCorrente contaMatheus = new ContaCorrente(111, 123123);

            for (int i = 0; i < lista.Tamanho; i++)
            {
                ContaCorrente itemAtual = lista[i];
                Console.WriteLine($"Item na posição {i} = Conta {itemAtual.Numero}/{itemAtual.Agencia}");
            }

            lista.AdicionarVarios(
                contaMatheus,
                new ContaCorrente(0001, 7687152),
                new ContaCorrente(0001, 7687153)
            );
        }

        static void TestaArrayContaCorrente()
        {
            ContaCorrente[] contas = new ContaCorrente[]
            {
                new ContaCorrente(0001, 7687150),
                new ContaCorrente(0001, 7687199)
            };

            for (int indice = 0; indice < contas.Length; indice++)
            {
                ContaCorrente conta = contas[indice];
                Console.WriteLine($"Número da conta = {conta.Numero}");
            }
        }

        static void TestaArrayInt()
        {
            int[] idades = null;
            idades = new int[5];

            idades[0] = 15;
            idades[1] = 28;
            idades[2] = 35;
            idades[3] = 50;
            idades[4] = 28;

            int acumulador = 0;

            for (int indice = 0; indice < idades.Length; indice++)
            {
                acumulador += idades[indice];

                Console.WriteLine($"Indíce na posição {indice} = {idades[indice]}");
            }

            int media = acumulador / idades.Length;

            Console.WriteLine($"Média entre as idades = {media}");
        }
    }
}
