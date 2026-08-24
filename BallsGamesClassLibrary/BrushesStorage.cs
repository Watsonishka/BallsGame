using System.Drawing;

namespace BallsGamesClassLibrary
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
            var randomIndex = Randomizer.GetNumberInRange(0, 10);
            return _brushes[randomIndex];
        }
    }
}

