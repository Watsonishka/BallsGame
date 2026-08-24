namespace BallsGameWinFormsLibrary
{
    public class BillyardBall : Ball
    {
        public const int BillyardBallDiameter = 40;
        public static readonly int BillyardBallMinSpeed = 3;
        public static readonly int BillyardBallMaxSpeed = 31;
        public override int Speed
        {
            get => speed;
            set
            {
                if (value < 0 || value > BillyardBallMaxSpeed)
                {
                    throw new ArgumentOutOfRangeException($"Значение не может быть меньше 0 и больше {BillyardBallMaxSpeed}!");
                }
                speed = value;
            }
        }
        public BillyardBall(int xCoordinate, int yCoordinate) : base(xCoordinate, yCoordinate)
        {
            this.xCoordinate = xCoordinate;
            this.yCoordinate = yCoordinate;
            diameter = BillyardBallDiameter;
            speed = Randomizer.GetNumberInRange(BillyardBallMinSpeed, BillyardBallMaxSpeed);
        }
        public BillyardBall(int xCoordinate, int yCoordinate, Brush color) : base(xCoordinate, yCoordinate)
        {
            this.xCoordinate = xCoordinate;
            this.yCoordinate = yCoordinate;
            diameter = BillyardBallDiameter;
            speed = Randomizer.GetNumberInRange(BillyardBallMinSpeed, BillyardBallMaxSpeed);
            this.color = color;
        }
    }
}
