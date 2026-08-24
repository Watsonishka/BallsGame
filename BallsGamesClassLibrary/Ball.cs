using System.Drawing;

namespace BallsGamesClassLibrary
{
    public class Ball
    {
        protected int size;
        protected int xCoordinate;
        protected int yCoordinate;
        protected string direction;
        protected int speed;
        protected Brush color;
        protected Rectangle rectangle;
        protected const int minSpeed = 10;
        protected const int maxSpeed = 51;
        protected const int minSize = 50;
        protected const int maxSize = 101;

        public int Size
        {
            get => size;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Значение не может быть меньше или равно нулю!");
                }
                size = value;
            }
        }
        public int XCoordinate
        {
            get => xCoordinate;
            set
            {
                xCoordinate = value;
            }
        }
        public int YCoordinate
        {
            get => yCoordinate;
            set
            {
                yCoordinate = value;
            }
        }
        public int Speed
        {
            get => speed;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Значение не может быть меньше или равно нулю!");
                }
                speed = value;
            }
        }
        public string Direction
        {
            get => direction;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Значение не может быть пустым или null!");
                }
                direction = value;
            }
        }
        public Ball(int xCoordinate, int yCoordinate)
        {
            this.xCoordinate = xCoordinate;
            this.yCoordinate = yCoordinate;
            size = Randomizer.GetNumberInRange(minSize, maxSize);
            color = BrushesStorage.GetRandom();
            direction = Randomizer.GetDirection();
            speed = Randomizer.GetNumberInRange(minSpeed, maxSpeed);
        }
        public void Paint(Graphics graphics)
        {
            rectangle = new Rectangle(xCoordinate, yCoordinate, size, size);
            graphics.FillEllipse(color, rectangle);
        }
        public void Clear(Graphics graphics, Ball ball)
        {
            var brush = Brushes.WhiteSmoke;
            rectangle = new Rectangle(ball.xCoordinate, ball.yCoordinate, ball.size, ball.size);
            graphics.FillEllipse(brush, rectangle);
        }
    }
}
