namespace BallsGameWinFormsLibrary
{
    public class RandomLocationSpeedBall : Ball
    {
        public RandomLocationSpeedBall(int xCoordinate, int yCoordinate) : base(xCoordinate, yCoordinate)
        {
            this.xCoordinate = Randomizer.GetNumberInRange(0, xCoordinate);
            this.yCoordinate = Randomizer.GetNumberInRange(0, yCoordinate);
        }
        public RandomLocationSpeedBall(int xCoordinate, int yCoordinate, int minSpeed, int maxSpeed) : base(xCoordinate, yCoordinate)
        {
            this.xCoordinate = Randomizer.GetNumberInRange(0, xCoordinate);
            this.yCoordinate = Randomizer.GetNumberInRange(0, yCoordinate);
            speed = Randomizer.GetNumberInRange(minSpeed, maxSpeed);
        }
    }
}
