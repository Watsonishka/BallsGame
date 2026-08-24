 using BallsGameWinFormsLibrary;

namespace BallsGamesWinFormsApp
{
    public partial class MainForm : Form
    {
        private int windowWidth;
        private int windowHeight;
        private List<RandomLocationSpeedBall> randomBalls = new List<RandomLocationSpeedBall>();
        public MainForm()
        {
            MessageBox.Show("Поймай все шары! Шарик будет считаться пойманым, если он полностью находится на форме!");
            InitializeComponent();
            windowWidth = ClientSize.Width;
            windowHeight = ClientSize.Height;
        }
        private void MoveBall(Ball ball)
        {
            ball.Clear(CreateGraphics(), ball);
            ball = BallsAnimation.MoveRandom(ball, ball.Speed);
            ball.Paint(CreateGraphics());
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            foreach (var ball in randomBalls)
            {
                MoveBall(ball);
            }
        }
        private void generate_Click(object sender, EventArgs e)
        {
            Refresh();
            var randomCount = Randomizer.GetNumberInRange(5, 16);

            for (var i = 0; i < randomCount; i++)
            {
                var randomBall = new RandomLocationSpeedBall(windowWidth, windowHeight);
                randomBalls.Add(randomBall);
            }

            timer.Start();
            catchBallsCountLabel.Text = "Шаров поймано:";
            commonBallsCountLabel.Text = $"Шаров создано: {randomBalls.Count}";
            generate.Enabled = false;
            stop.Enabled = true;
        }
        private void stop_Click(object sender, EventArgs e)
        {
            timer.Stop();
            CheckCatchedBalls();
        }
        private bool CheckBallPosition(Ball ball)
        {
            if (ball.XCoordinate < 0)
            {
                return false;
            }
            if (ball.XCoordinate + ball.Diameter > windowWidth)
            {
                return false;
            }
            if (ball.YCoordinate < 0)
            {
                return false;
            }
            if (ball.YCoordinate + ball.Diameter > windowHeight)
            {
                return false;
            }
            return true;
        }
        private void CheckCatchedBalls()
        {
            var catchedBalls = 0;

            foreach (var ball in randomBalls)
            {
                if (CheckBallPosition(ball))
                {
                    catchedBalls++;
                }
            }

            randomBalls.Clear();
            catchBallsCountLabel.Text = $"Шаров поймано: {catchedBalls}";
            generate.Enabled = true;
            stop.Enabled = false;
        }
    }
}
