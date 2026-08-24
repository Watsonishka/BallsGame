namespace BallsGamesClassLibrary
{
    public class RandomLocationBall : Ball
    {
        public RandomLocationBall(int xCoordinate, int yCoordinate) : base(xCoordinate, yCoordinate)
        {
            this.xCoordinate = Randomizer.GetNumberInRange(0, xCoordinate);
            this.yCoordinate = Randomizer.GetNumberInRange(0, yCoordinate);
        }
    }
}
