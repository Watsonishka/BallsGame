namespace BallsGameWinFormsLibrary
{
    public class GravityBall : PointClickBall
    {        
        public readonly float Gravity = 0.4f;
        private const float rocketDiameter = 10f;
        private new const int MinSpeed = 4;
        private new const int MaxSpeed = 8;
        private float verticalSpeed = -12f;
        private new float xCoordinate;
        private new float yCoordinate;
        private new float diameter;
        private new float speed;
        private int lifeSpawn = -1;
        public new float XCoordinate
        {
            get => xCoordinate;
            set => xCoordinate = value;
        }
        public new float YCoordinate
        {
            get => yCoordinate;
            set => yCoordinate = value;
        }
        public new float Diameter
        {
            get => diameter;
            set => diameter = value;
        }
        public new float Speed
        {
            get => speed;
            set => speed = value;
        }
        public float VerticalSpeed
        {
            get => verticalSpeed;
            set => verticalSpeed = value;
        }
        public int LifeSpawn
        {
            get => lifeSpawn;
            set => lifeSpawn = value;
        }
        public GravityBall(float xCoordinate, float yCoordinate) : base(0, 0)
        {
            this.xCoordinate = xCoordinate;
            this.yCoordinate = yCoordinate;
            diameter = rocketDiameter;
            speed = Randomizer.GetNumberInRange(MinSpeed, MaxSpeed);
            verticalSpeed = Randomizer.GetNumberInRange(-15, -8);
            color = Brushes.Brown;
            direction = Randomizer.GetVerticalDirection();
        }
        public GravityBall(float xCoordinate, float yCoordinate, float diameter) : base(0, 0)
        {
            this.xCoordinate = xCoordinate;
            this.yCoordinate = yCoordinate;
            this.diameter = diameter;
            speed = Randomizer.GetNumberInRange(MinSpeed, MaxSpeed);
            verticalSpeed = Randomizer.GetNumberInRange(-10, -3);
            color = BrushesStorage.GetRandom();
            direction = Randomizer.GetDirection();
        }
        public GravityBall(float xCoordinate, float yCoordinate, float diameter, Brush color, int lifespawn) : base(0, 0)
        {
            this.xCoordinate = xCoordinate;
            this.yCoordinate = yCoordinate;
            this.diameter = diameter;
            speed = Randomizer.GetNumberInRange(MinSpeed, MaxSpeed);
            verticalSpeed = Randomizer.GetNumberInRange(-10, -3);
            this.color = color;
            direction = Randomizer.GetDirection();
            this.lifeSpawn = lifespawn;
        }
        public GravityBall(int windowWidth, int windowHeight, Brush color) : base(0, 0)
        {
            xCoordinate = Randomizer.GetNumberInRange(windowWidth / 2, windowWidth / 2);
            yCoordinate = windowHeight;
            diameter = Randomizer.GetFruitDiameter(color);
            speed = Randomizer.GetFruitSpeed(color);
            verticalSpeed = Randomizer.GetNumberInRange(-18, -10);
            this.color = color;
            direction = Randomizer.GetVerticalDirection();
        }
        public override void Paint(Graphics graphics)
        {
            var rectangle = new RectangleF(xCoordinate, yCoordinate, diameter, diameter);
            graphics.FillEllipse(color, rectangle);
        }
        public override void Clear(Graphics graphics, Ball ball)
        {
            var brush = Brushes.WhiteSmoke;
            var rectangle = new RectangleF(xCoordinate, yCoordinate, diameter, diameter);
            graphics.FillEllipse(brush, rectangle);
        }
    }
}