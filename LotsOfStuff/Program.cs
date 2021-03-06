﻿using System;

namespace Aula11
{
    /// <summary>Programa para testar o projeto</summary>
    public class Program
    {
        Bag otherBag;

        /// <summary>O programa começa aqui no Main</summary>
        /// <param name="args">
        /// Argumentos de linha de comandos (são ignorados neste programa)
        /// </param>
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Criar uma nova instância de Program e
            // invocar o método TestProjet na instância criada
            Program prog = new Program();
            prog.TestProject();
        }

        /// <summary>Método que testa este projeto</summary>
        private void TestProject()
        {
            // Instanciar um jogador com 70 quilos
            Player p = new Player(70.0f);

            Console.WriteLine(p);

            //
            // Adicionar vários itens à mochila do jogador:
            //

            // Pão com 2 dias, 500 gramas
            p.BagOfStuff.Add(new Food(FoodType.Bread, 2, 0.500f));
            // 300 gramas de vegetais com 5 dias
            p.BagOfStuff.Add(new Food(FoodType.Vegetables, 5, 0.300f));
            // Pistola com 1.5kg + 50 gramas por bala, carregada com 10 balas,
            // com um custo de 250€
            p.BagOfStuff.Add(new Gun(1.5f, 0.050f, 10, 250f));
            // 200 gramas de fruta fresca
            p.BagOfStuff.Add(new Food(FoodType.Fruit, 0, 0.200f));
            // Mais uma arma
            p.BagOfStuff.Add(new Gun(2f, 0.09f, 25, 325f));

            Console.WriteLine(p.BagOfStuff);

            otherBag = new Bag(5);

            otherBag.Add(new Food(FoodType.Meat, 1, 1f));
            otherBag.Add(new Food(FoodType.Vegetables, 2, 2.5f));

            p.BagOfStuff.Add(otherBag);

            // Mostrar informação acerca dos conteúdos da mochila
            Console.WriteLine(p.BagOfStuff);

            // Percorrer itens na mochila e tentar "imprimir" cada um
            foreach (IStuff aThing in p.BagOfStuff)
            {
                Console.WriteLine($"\t=> {aThing}");

                // Se item atual for uma arma, disparar a mesma
                if (aThing is Gun)
                {
                    (aThing as Gun).Shoot();
                }
            }

            // Mostrar de novo informação sobre a mochila
            Console.WriteLine(p.BagOfStuff);

            Console.WriteLine(p);

            Console.WriteLine("A mochila do player tem armas? " +
                p.BagOfStuff.ContainsItemOfTipe<Gun>());

            Console.WriteLine("A mochila do player tem comida? " +
                p.BagOfStuff.ContainsItemOfTipe<Food>());

            Console.WriteLine("A mochila do player tem outras mochilas? " +
                p.BagOfStuff.ContainsItemOfTipe<Bag>());

            foreach (Food f in p.BagOfStuff.GetItensOfType<Food>())
            {
                Console.WriteLine(f);
            }

            foreach (Gun g in p.BagOfStuff.BetterGetItensOfType<Gun>())
            {
                Console.WriteLine(g);
            }
        }
    }
}
