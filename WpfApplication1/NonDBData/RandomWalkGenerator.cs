using System;
using flc.FrontDoor.Data;

namespace flc.FrontDoor.NonDBData
{
    public class DbCon
    {
        public static bool ConnecttoDb = false;
    }
    public class RandomWalkGenerator
    {
        private readonly double _bias = 0.01;
        private readonly Random _random;
        private int _i;
        private double _last;

        public RandomWalkGenerator (double bias = 0.01)
        {
            _bias = bias;
            _random = new Random();
        }

        public RandomWalkGenerator (int seed)
        {
            _random = new Random (seed);
        }

        public void Reset()
        {
            _i = 0;
            _last = 0;
        }

        public DoubleSeries GetRandomWalkSeries (int count)
        {
            var doubleSeries = new DoubleSeries (count);

            // Generate a slightly positive biased random walk
            // y[i] = y[i-1] + random, 
            // where random is in the range -0.5, +0.5
            for (var i = 0; i < count; i++)
            {
                var next = _last + (_random.NextDouble() - 0.5 + _bias);
                _last = next;

                doubleSeries.Add (new XYPoint {X = _i++, Y = next});
            }

            return doubleSeries;
        }

        public PriceSeries GetRandomCurveSeries(int count = 50)
        {
            var doubleSeries = new PriceSeries(count);

            // Generate a slightly positive biased random walk
            // y[i] = y[i-1] + random, 
            // where random is in the range -0.5, +0.5
            for (var i = 0; i < count; i++)
            {
                var next = _last + (_random.NextDouble() - 0.5 + _bias);
                _last = next;

                doubleSeries.Add(new PriceBar(DateTime.Today.AddDays(i),next,next,next,next,(long)next));
            }

            return doubleSeries;
        }
    }
}