namespace BallsGameWinFormsLibrary
{
    public class BrushesStorage
    {
        private static readonly List<Brush> _brushes;

        static BrushesStorage()
        {
            _brushes = new List<Brush>
            {
                Brushes.Aquamarine,
                Brushes.Coral,
                Brushes.Lavender,
                Brushes.LightGreen,
                Brushes.LightSkyBlue,
                Brushes.Moccasin,
                Brushes.PeachPuff,
                Brushes.Pink,
                Brushes.Plum,
                Brushes.Salmon
            };
        }
        public static Brush GetRandom()
        {
            var randomIndex = Randomizer.GetNumberInRange(0, _brushes.Count);
            return _brushes[randomIndex];
        }
        public static Brush GetRandomFruitBrush()
        {
            var randomValue = Randomizer.GetNumberInRange(0, 100);

            if (randomValue < 30)
            {
                return Brushes.Red;
            }
            if (randomValue < 40)
            {
                return Brushes.Orange;
            }
            if (randomValue < 50)
            {
                return Brushes.HotPink;
            }
            if (randomValue < 60)
            {
                return Brushes.Purple;
            }
            if (randomValue < 70)
            {
                return Brushes.LimeGreen;
            }
            if (randomValue < 80)
            {
                return Brushes.DarkBlue;
            }
            if (randomValue < 90)
            {
                return Brushes.Yellow;
            }
            return Brushes.Black;
        }
        public static Brush GetRandomBirdBrush()
        {
            var randomValue = Randomizer.GetNumberInRange(0, 100);

            if (randomValue < 50)
            {
                return Brushes.Red;
            }
            if (randomValue < 80)
            {
                return Brushes.Blue;
            }
            return Brushes.Black;
        }
    }
}
