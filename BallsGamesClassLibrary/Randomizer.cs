namespace BallsGamesClassLibrary
{
    public static class Randomizer
    {
        private static readonly Random random = new Random();
        public static int GetNumberInRange(int min, int max)
        {
            return random.Next(min, max);
        }
        public static string GetDirection()
        {
            var random = GetNumberInRange(0, 4);
            switch (random)
            {
                case 0: return "rightUp";
                case 1: return "rightDown";
                case 2: return "leftUp";
                case 3: return "leftDown";
            }
            return "rightUp";
        }
    }
}
