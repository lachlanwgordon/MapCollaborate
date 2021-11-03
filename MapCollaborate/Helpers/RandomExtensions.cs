using System;


namespace MapCollaborate.Helpers
{
    public static class RandomExtensions
    {
        public static double NextDouble(this Random random, double minimum, double maximum)
        {
            return random.NextDouble() * (maximum - minimum) + minimum;
        }
    }
}