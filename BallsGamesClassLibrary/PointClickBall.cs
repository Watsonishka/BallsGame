namespace BallsGamesClassLibrary
{
    public class PointClickBall : Ball
    {
        public PointClickBall(int ballSize, int xCoordinate, int yCoordinate) : base(xCoordinate, yCoordinate)
        {
            size = ballSize;
            this.xCoordinate = xCoordinate - ballSize / 2;
            this.yCoordinate = yCoordinate - ballSize / 2;
        }
    }
}

