using ByteBank.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    public class ListaDeContaCorrente
    {
        private ContaCorrente[] _itens;
        private int _proximaPosicao;

        public int Tamanho
        {
            get
            {
                return _proximaPosicao;
            }
        }

        public ListaDeContaCorrente(int capacidade = 5)
        {
            _itens = new ContaCorrente[capacidade];
            _proximaPosicao = 0;
        }

        public void Adicionar(ContaCorrente item)
        {
            // PROXIMAPOSICAO COMEÇA EM 0, POR ISSO SOMA +1
            VerificarCapacidade(_proximaPosicao + 1);

            //Console.WriteLine($"Adicionando item na posição {_proximaPosicao}");

            _itens[_proximaPosicao] = item;

            _proximaPosicao++;
        }

        private void VerificarCapacidade(int tamanhoNecessario)
        {
            if(_itens.Length >= tamanhoNecessario)
            {
                return;
            }

            int novoTamanho = _itens.Length * 2;
            if(novoTamanho < tamanhoNecessario)
            {
                novoTamanho = tamanhoNecessario;
            }

            //Console.WriteLine($"Aumentando capacidade para {tamanhoNecessario}");

            ContaCorrente[] novoArray = new ContaCorrente[novoTamanho];

            //Array.Copy(
            //    sourceArray: _itens,
            //    destinationArray: novoArray,
            //    length: _itens.Length
            //    );

            for(int indice = 0; indice < _itens.Length; indice++)
            {
                //Console.WriteLine(".");
                novoArray[indice] = _itens[indice];
            }

            _itens = novoArray;
        }

        public void Remover(ContaCorrente item)
        {
            int indiceItem = -1;

            for(int i = 0; i < _proximaPosicao; i++)
            {
                ContaCorrente itemAtual = _itens[i];

                if(itemAtual.Equals(item))
                {
                    indiceItem = i;
                    break;
                }
            }

            if(indiceItem == -1)
            {
                return;
            }

            for(int i = indiceItem; i < _proximaPosicao - 1; i++)
            {
                _itens[i] = _itens[i + 1];
            }

            _proximaPosicao--;
            _itens[_proximaPosicao] = null;
        }

        public ContaCorrente GetItemNoIndice(int indice)
        {
            if(indice < 0 || indice >= _proximaPosicao)
            {
                throw new ArgumentOutOfRangeException(nameof(indice));
            }

            return _itens[indice];
        }

        public void AdicionarVarios(params ContaCorrente[] itens)
        {
            foreach(ContaCorrente item in itens)
            {
                Adicionar(item);
            }
        }

        public ContaCorrente this[int indice]
        {
            get
            {
                return GetItemNoIndice(indice);
            }
        }

        // params no indexador
        //public ContaCorrente[] this[params int[] indices]
        //{
        //    get
        //    {
        //        ContaCorrente[] resultado = new ContaCorrente[indices.Length];

        //        for(int i = 0; i < indices.Length; i++)
        //        {
        //            resultado[i] = GetItemNoIndice(indices[i]);
        //        }

        //        return resultado;
        //    }
        //}
    }
}
