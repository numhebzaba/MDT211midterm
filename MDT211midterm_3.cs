using System;
using System.Collections.Generic;

namespace MDT211midterm_3
{
    class FlowerStore
    {
        public List<string> flowerList = new List<string>();
        List<string> cart = new List<string>();
        public FlowerStore()
        {
            flowerList.Add("Rose");
            flowerList.Add("Lotus");
        }
        public void addToCart(string name)
        {
            cart.Add(name);
        }

        public void showCart()
        {
            if (cart.Count == 0)
            {
                Console.WriteLine("Cart is empty");
            }
            else
            {
                Console.WriteLine("My Cart :");
                foreach (string flowers in cart)
                {
                    Console.WriteLine(flowers);
                }
            }
        }
        public void ShowNumberToSelectFlower() {
            Console.WriteLine("Select number for buy flower :");
            foreach (string flowers in this.flowerList)
            {
                Console.Write((this.flowerList.IndexOf(flowers) + 1) + " ");
                Console.WriteLine(flowers);
            }
        }
        public void TypeNumberToSelectFlower() {
            string selectFlower = Console.ReadLine();
            switch (selectFlower)
            {
                case "1":
                    this.addToCart(this.flowerList[0]);
                    Console.WriteLine("Added " + this.flowerList[0]);
                    break;
                case "2":
                    this.addToCart(this.flowerList[1]);
                    Console.WriteLine("Added " + this.flowerList[1]);
                    break;
                default:
                    Console.WriteLine("Not Added to cart. found select number of flower");
                    break;
            }
        }

    }
    class Program
    {
       
        static void Main(string[] args)
        {
            LoopSelectFlower();
        }
        static void LoopSelectFlower() {
            string decide = "nothing";
            FlowerStore flowerStore = new FlowerStore();
            do
            {
                Console.Clear();
                flowerStore.ShowNumberToSelectFlower();
                flowerStore.TypeNumberToSelectFlower();
                decide = DecideForExit( decide, flowerStore);
            }
            while (decide != "exit");

        }
        static string DecideForExit( string  decide, FlowerStore flowerStore) {
            Console.WriteLine("You can stop this progress ? exit for >> exit << progress and press any key for continue");
            decide = Console.ReadLine();
            if (decide.ToLower() == "exit")
            {
                Console.Write("Current my cart");
                flowerStore.showCart();
            }
            return decide.ToLower();
        }
    }
            
}
