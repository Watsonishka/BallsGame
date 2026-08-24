
namespace BallsGameWinFormsLibrary
{
    public class Ball
    {
        public static readonly int MinSpeed = 5;
        public static readonly int MaxSpeed = 71;
        public static readonly int MinDiameter = 50;
        public static readonly int MaxDiameter = 101;
        protected int diameter;
        protected int xCoordinate;
        protected int yCoordinate;
        protected Direction direction;
        protected int speed;
        protected Brush color;
        protected Rectangle rectangle;
        public int Diameter
        {
            get => diameter;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Значение не может быть меньше или равно нулю!");
                }
                diameter = value;
            }
        }
        public int XCoordinate
        {
            get => xCoordinate;
            set => xCoordinate = value;
        }
        public int YCoordinate
        {
            get => yCoordinate;
            set => yCoordinate = value;
        }
        public virtual int Speed
        {
            get => speed;
            set
            {
                if (value < MinSpeed || value > MaxSpeed)
                {
                    throw new ArgumentOutOfRangeException($"Значение не может быть меньше {MinSpeed} и больше {MaxSpeed}!");
                }
                speed = value;
            }
        }
        public Direction Direction
        {
            get => direction;
            set => direction = value;
        }
        public Brush Color
        {
            get => color;
            set => color = value;
        }
        public Ball(int xCoordinate, int yCoordinate)
        {
            this.xCoordinate = xCoordinate;
            this.yCoordinate = yCoordinate;
            diameter = Randomizer.GetNumberInRange(MinDiameter, MaxDiameter);
            color = BrushesStorage.GetRandom();
            direction = Randomizer.GetDirection();
            speed = Randomizer.GetNumberInRange(MinSpeed, MaxSpeed);
        }
        public Ball(int xCoordinate, int yCoordinate, Brush color)
        {
            this.xCoordinate = xCoordinate;
            this.yCoordinate = yCoordinate;
            diameter = Randomizer.GetNumberInRange(MinDiameter, MaxDiameter);
            this.color = color;
            direction = Randomizer.GetDirection();
            speed = Randomizer.GetNumberInRange(MinSpeed, MaxSpeed);
        }
        public virtual void Paint(Graphics graphics)
        {
            rectangle = new Rectangle(xCoordinate, yCoordinate, diameter, diameter);
            graphics.FillEllipse(color, rectangle);
        }
        public virtual void Clear(Graphics graphics, Ball ball)
        {
            var brush = Brushes.WhiteSmoke;
            rectangle = new Rectangle(ball.xCoordinate, ball.yCoordinate, ball.diameter, ball.diameter);
            graphics.FillEllipse(brush, rectangle);
        }
    }
}
