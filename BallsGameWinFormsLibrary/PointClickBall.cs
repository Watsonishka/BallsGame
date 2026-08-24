namespace BallsGameWinFormsLibrary
{
    public class PointClickBall : Ball
    {
        private const int ballMaxDiameter = 1;
        public PointClickBall(int xCoordinate, int yCoordinate) : base(xCoordinate, yCoordinate)
        {
            diameter = ballMaxDiameter;
            this.xCoordinate = xCoordinate - diameter / 2;
            this.yCoordinate = yCoordinate - diameter / 2;
            color = Brushes.WhiteSmoke;
        }
    }
}
