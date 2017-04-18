namespace Kitchen
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using Models;
    using Models.Products;
    using Models.Utensils;

    public class StartUp
    {
        public static void Main()
        {
            var vegetables = new List<IVegetable>()
            {
                new Potato(),
                new Carrot(),
                new Potato(),
                new Carrot(),
                new Carrot()
            };

            var bowl = new Bowl();
            var chef = new Chef();
            chef.Cook(vegetables, bowl);
        }
    }
}