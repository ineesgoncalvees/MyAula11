using System;
using System.Collections.Generic;

namespace Aula11
{
    /// <summary>
    /// Classe que representa uma mochila ou saco que contem itens
    /// </summary>
    public class Bag : IStuff
    {
        /// <summary>Array que contém os itens da mochila</summary>
        private List<IStuff> stuff;

        /// <summary>Número de itens na mochila</summary>
        public int StuffCount { get { return stuff.Count; } }

        /// <summary> 
        /// Propriedade Weight respeita o contrato com IHasWeight. No caso do
        /// Bag o peso vai corresponder ao peso total dos itens.
        /// </summary>
        public float Weight
        {
            get
            {
                float totalWeight = 0;
                foreach (IStuff aThing in stuff)
                {
                    if (aThing != null)
                    {
                        totalWeight += aThing.Weight;
                    }
                }
                return totalWeight;
            }
        }

        /// <summary> 
        /// Propriedade Value respeita o contrato com IValuable. No caso do
        /// Bag o valor vai corresponder ao valor total dos itens.
        /// </summary>
        public float Value
        {
            get
            {
                float totalValue = 0;
                foreach (IStuff aThing in stuff)
                {
                    if (aThing != null)
                    {
                        totalValue += aThing.Value;
                    }
                }
                return totalValue;
            }
        }

        /// <summary>
        /// Construtor que cria uma nova instância de mochila
        /// </summary>
        /// <param name="bagSize">
        /// Número máximo de itens que é possível colocar na mochila
        /// </param>
        public Bag(int bagSize)
        {
            stuff = new List<IStuff>(bagSize);
        }

        /// <summary>Colocar um item na mochila</summary>
        /// <param name="aThing">Item a colocar na mochila</param>
        public void AddThing(IStuff aThing)
        {
            // Adicionar o item à mochila e depois incrementar o
            // número de coisas na mochila
            stuff.Add(aThing);
        }

        /// <summary>Observar um item da mochila sem o remover da mesma</summary>
        /// <param name="index">Local onde está o item a observar</param>
        /// <returns>Item a ser observado</returns>
        public IStuff GetThing(int index)
        {
            if (index > stuff.Count)
            {
                // Senão existir um item no local indicado, "lançar" uma exceção
                throw new InvalidOperationException(
                    "Bag doesn't have that much stuff!");
            }
            return stuff[index];
        }

        /// <summary>
        /// Sobreposição do método ToString() para a classe Bag.
        /// </summary>
        /// <returns>
        /// Uma string contendo informação sobre a mochila e os seus conteúdos.
        /// </returns>
        public override string ToString()
        {
            return $"Mochila com {StuffCount} itens e um peso e valor " +
                $"totais de {Weight} Kg e {Value} EUR, respetivamente";
        }
    }
}
