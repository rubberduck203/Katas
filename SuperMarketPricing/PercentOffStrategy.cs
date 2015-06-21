﻿using System;

namespace SuperMarketPricing
{
    /// <summary>
    /// Uses a "X% Off" Pricing Strategy.
    /// </summary>
    public class PercentOffStrategy : IPricingStrategy
    {
        private int _percentOff;
        private double _price;

        public Sku Sku { get; }

        /// <param name="sku">The <see cref="Sku"/> to that uses this strategy.</param>
        /// <param name="price">The regular every day price.</param>
        /// <param name="percentOff">Whole number from 1 to 99.</param>
        public PercentOffStrategy(Sku sku, double price, int percentOff)
        {
            if (percentOff <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(percentOff), percentOff, "Cannot be less than or equal to zero.");
            }

            if (percentOff >= 100)
            {
                throw new ArgumentOutOfRangeException(nameof(percentOff), percentOff, "Cannot be equal to or greater than 100.");
            }

            if (price < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(price), price, "Cannot be less than zero.");
            }

            _percentOff = percentOff;
            _price = price;
   
            Sku = sku;
        }

        public double GetPrice(int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), count, "Cannot be less than zero.");
            }

            return (_price - (_price / _percentOff)) * count;
        }
    }
}