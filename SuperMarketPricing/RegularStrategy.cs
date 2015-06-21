﻿namespace SuperMarketPricing
{
    public class RegularStrategy : IPricingStrategy
    {
        private double _price;

        public Sku Sku { get; }

        public RegularStrategy(Sku sku, double price)
        {
            Sku = sku;
            _price = price;
        }

        public double GetPrice(int count)
        {
            return _price * count;
        }
    }
}