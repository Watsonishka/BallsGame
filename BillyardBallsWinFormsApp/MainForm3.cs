using BallsGameWinFormsLibrary;

namespace BillyardBallsWinFormsApp
{
    public partial class MainForm3 : Form
    {
        private List<BillyardBall> billyardBalls;
        private int windowWidth;
        private int windowHeight;
        private int topLabelCount;
        private int downLabelCount;
        private int rightLabelCount;
        private int leftLabelCount;
        public MainForm3()
        {
            InitializeComponent();
            windowWidth = ClientSize.Width;
            windowHeight = ClientSize.Height - panel.Height;
            moveButton.Enabled = false;
            stopButton.Enabled = false;
        }
        private void RefreshLabels()
        {
            topLabelCount = 0;
            TopLabel.Text = topLabelCount.ToString();
            downLabelCount = 0;
            DownLabel.Text = downLabelCount.ToString();
            rightLabelCount = 0;
            RightLabel.Text = rightLabelCount.ToString();
            leftLabelCount = 0;
            LeftLabel.Text = leftLabelCount.ToString();
        }
        private void RefreshField()
        {
            RefreshLabels();
            Refresh();
            billyardBalls = GetBallsWithoutCollisions();

            foreach (var ball in billyardBalls)
            {
                ball.Paint(CreateGraphics());
            }

            moveButton.Enabled = true;
        }
        private List<BillyardBall> GetBallsWithoutCollisions()
        {
            billyardBalls = new List<BillyardBall>();
            var generateBallsCount = Randomizer.GetNumberInRange(5, 16);

            for (var i = 0; i < generateBallsCount; i++)
            {
                var ballAdded = false;

                while (!ballAdded)
                {
                    var xCoordinate = Randomizer.GetNumberInRange(0, windowWidth - BillyardBall.BillyardBallDiameter);
                    var yCoordinate = Randomizer.GetNumberInRange(0, windowHeight - BillyardBall.BillyardBallDiameter);
                    var randomBall = new BillyardBall(xCoordinate, yCoordinate);

                    bool hasCollision = false;

                    foreach (var ball in billyardBalls)
                    {
                        if (BallsAnimation.IsBallsTouchingEachOther(ball, randomBall))
                        {
                            hasCollision = true;
                            break;
                        }
                    }

                    if (!hasCollision)
                    {
                        billyardBalls.Add(randomBall);
                        ballAdded = true;
                    }
                }
            }
            return billyardBalls;
        }
        private BillyardBall MoveBall(BillyardBall ball)
        {
            ball.Clear(CreateGraphics(), ball);
            ball = (BillyardBall)BallsAnimation.MoveRandom(ball, ball.Speed);
            ball.Paint(CreateGraphics());
            return ball;
        }
        private void moveButton_Click(object sender, EventArgs e)
        {
            timer.Start();
            stopButton.Enabled = true;
        }
        private void generateButton_Click_1(object sender, EventArgs e)
        {
            RefreshField();
            stopButton.Enabled = false;
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            for (var i = 0; i < billyardBalls.Count; i++)
            {
                var currentBall = billyardBalls[i];
                currentBall = MoveBall(currentBall);

                var (hitLeftRightWall, hitTopBottomWall) = BallsAnimation.GetWallHits(currentBall, windowWidth, windowHeight);
                if (hitLeftRightWall || hitTopBottomWall)
                {
                    currentBall.Clear(CreateGraphics(), currentBall);
                    currentBall = (BillyardBall)BallsAnimation.CorrectBallPosition(currentBall, windowWidth, windowHeight);
                    IncreaseEdgeHitLabels(currentBall);
                    currentBall.Direction = BallsAnimation.ChangeDirectionFromWall(currentBall, hitLeftRightWall, hitTopBottomWall);
                }
            }
        }
        private void StopTimer()
        {
            timer.Stop();
        }
        private void IncreaseEdgeHitLabels(Ball ball)
        {
            if (ball.XCoordinate <= 0)
            {
                leftLabelCount++;
                LeftLabel.Text = leftLabelCount.ToString();
            }
            if (ball.XCoordinate + ball.Diameter >= windowWidth)
            {
                rightLabelCount++;
                RightLabel.Text = rightLabelCount.ToString();
            }
            if (ball.YCoordinate <= 0)
            {
                topLabelCount++;
                TopLabel.Text = topLabelCount.ToString();
            }
            if (ball.YCoordinate + ball.Diameter >= windowHeight)
            {
                downLabelCount++;
                DownLabel.Text = downLabelCount.ToString();
            }
        }
        private void stopButton_Click(object sender, EventArgs e)
        {
            StopTimer();
            MessageBox.Show("Ты остановил шарики!");
            stopButton.Enabled = false;
        }
    }
}
