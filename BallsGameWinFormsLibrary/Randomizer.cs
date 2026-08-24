namespace BallsGameWinFormsLibrary
{
    public class Randomizer
    {
        private static readonly Random random = new Random();
        public static int GetNumberInRange(int min, int max)
        {
            return random.Next(min, max);
        }
        public static Direction GetDirection()
        {
            var random = GetNumberInRange(0, 4);
            switch (random)
            {
                case 0: return Direction.rightUp;
                case 1: return Direction.rightDown;
                case 2: return Direction.leftUp;
                case 3: return Direction.leftDown;
                default: return Direction.rightUp;
            }
        }
        public static Direction GetVerticalDirection()
        {
            var random = GetNumberInRange(0, 2);
            switch (random)
            {
                case 0: return Direction.rightUp;
                case 1: return Direction.leftUp;
                default: return Direction.rightUp;
            }
        }
        public static float GetFruitDiameter(Brush color)
        {
            if (color == Brushes.Black)
            {
                return 100;
            }
            if (color == Brushes.HotPink)
            {
                return 120;
            }
            if (color == Brushes.Yellow)
            {
                return 50;
            }
            if (color == Brushes.Purple)
            {
                return 60;
            }
            if (color == Brushes.DarkBlue)
            {
                return 35;
            }
            if (color == Brushes.Red || color == Brushes.Orange)
            {
                return 40;
            }
            if (color == Brushes.LimeGreen)
            {
                return 45;
            }        
            return 60; 
        }
        public static float GetBirdDiameter(Brush color)
        {
            if (color == Brushes.Black)
            {
                return 70;
            }
            if (color == Brushes.Red )
            {
                return 45;
            }
            return 30;
        }
        public static int GetFruitPoints(Brush color)
        {
            if (color == Brushes.Black)
            {
                return 0;
            }
            if (color == Brushes.HotPink)
            {
                return 1;
            }
            if (color == Brushes.Yellow)
            {
                return 30;
            }
            if (color == Brushes.Purple)
            {
                return 15;
            }
            if (color == Brushes.DarkBlue)
            {
                return 50;
            }
            if (color == Brushes.Red || color == Brushes.Orange)
            {
                return 10;
            }
            if (color == Brushes.LimeGreen)
            {
                return 20;
            }
            return 1;
        }
        public static float GetFruitSpeed(Brush color)
        {
            if (color == Brushes.Black)
            {
                return GetNumberInRange(8, 16);
            }
            if (color == Brushes.Yellow)
            {
                return GetNumberInRange(20, 30);
            }
            if (color == Brushes.DarkBlue)
            {
                return GetNumberInRange(20, 40);
            }
            return GetNumberInRange(20, 35);  
        }
    }
}
