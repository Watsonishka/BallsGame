using BallsGameWinFormsLibrary;

namespace SalutWinFormsApp
{
    public partial class MainForm5 : Form
    {
        private int windowWidth;
        private int windowHeight;
        private List<GravityBall> salutBalls = new List<GravityBall>();
        private List<GravityBall> rocketBalls = new List<GravityBall>();

        public MainForm5()
        {
            InitializeComponent();
            DoubleBuffered = true;
            windowWidth = ClientSize.Width;
            windowHeight = ClientSize.Height;
            MessageBox.Show("Запускай салюты щелчком мыши! Новый щелчок мыши прекращает предыдущцю анимацию, запуская новую!");
        }
        private GravityBall MoveBall(GravityBall ball)
        {
            ball.Clear(CreateGraphics(), ball);
            ball = BallsAnimation.MoveGravaity(ball);
            ball.Paint(CreateGraphics());
            return ball;
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            for (var i = rocketBalls.Count - 1; i >= 0; i--)
            {
                MoveBall(rocketBalls[i]);

                if (CheckExplosion(rocketBalls[i]))
                {
                    rocketBalls.RemoveAt(i);
                }
            }
            for (var i = salutBalls.Count - 1; i >= 0; i--)
            {
                MoveBall(salutBalls[i]);

                if (BallsAnimation.IsBallCompletelyOffScreen(salutBalls[i], windowWidth, windowHeight))
                {
                    salutBalls.RemoveAt(i);
                }
            }
        }
        private bool CheckExplosion(GravityBall rocket)
        {
            if (rocket.VerticalSpeed >= 0)
            {
                var generateBallsCount = Randomizer.GetNumberInRange(20, 41);
                for (var i = 0; i < generateBallsCount; i++)
                {
                    var salutBall = new GravityBall(rocket.XCoordinate, rocket.YCoordinate, Randomizer.GetNumberInRange(12, 21));
                    salutBalls.Add(salutBall);
                }
                return true;
            }
            return false;
        }
        private void CreateRockets(float xCoordinate, float yCoordinate)
        {
            var generateBallsCount = Randomizer.GetNumberInRange(3, 7);
            for (var i = 0; i < generateBallsCount; i++)
            {
                var rocket = new GravityBall(xCoordinate + Randomizer.GetNumberInRange(-20, 20), yCoordinate + Randomizer.GetNumberInRange(-20, 20));
                rocketBalls.Add(rocket);
            }
        }
        private void MainForm5_MouseDown(object sender, MouseEventArgs e)
        {
            Refresh();
            rocketBalls.Clear();
            salutBalls.Clear();
            CreateRockets(e.X, e.Y);
            timer.Start();
        }
    }
}