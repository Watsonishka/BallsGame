using BallsGameWinFormsLibrary;

namespace DiffusionWinFormsApp
{
    public partial class MainForm4 : Form
    {
        private List<BillyardBall> diffuseBalls;
        private int windowWidth;
        private int windowHeight;
        private int pinkTopLabelCount;
        private int pinkDownLabelCount;
        private int pinkRightLabelCount;
        private int pinkLeftLabelCount;
        private int greenTopLabelCount;
        private int greenDownLabelCount;
        private int greenRightLabelCount;
        private int greenLeftLabelCount;
        private const int ballsPerColorCount = 4;
        private bool isDiffusionStart;
        public MainForm4()
        {
            InitializeComponent();
            DoubleBuffered = true;
            windowWidth = ClientSize.Width;
            windowHeight = ClientSize.Height;
            panel1.Left = (ClientSize.Width - panel1.Width) / 2;
            panel1.Top = (ClientSize.Height - panel1.Height) / 2;
            MessageBox.Show("Новая генерация газов запускается по щелчку мыши! Также текущую генерацию можно поставить на паузу," +
                " если щекнуть мышью по экрану!");
        }
        private void RefreshLabels()
        {
            pinkTopLabelCount = 0;
            pinkTopLabel.Text = pinkTopLabelCount.ToString();
            pinkDownLabelCount = 0;
            pinkDownLabel.Text = pinkDownLabelCount.ToString();
            pinkRightLabelCount = 0;
            pinkRightLabel.Text = pinkRightLabelCount.ToString();
            pinkLeftLabelCount = 0;
            pinkLeftLabel.Text = pinkLeftLabelCount.ToString();

            greenTopLabelCount = 0;
            greenTopLabel.Text = greenTopLabelCount.ToString();
            greenDownLabelCount = 0;
            greenDownLabel.Text = greenDownLabelCount.ToString();
            greenRightLabelCount = 0;
            greenRightLabel.Text = greenRightLabelCount.ToString();
            greenLeftLabelCount = 0;
            greenLeftLabel.Text = greenLeftLabelCount.ToString();
        }
        private void RefreshField()
        {
            diffuseBalls = new List<BillyardBall>();
            isDiffusionStart = false;
            RefreshLabels();
            Refresh();

            diffuseBalls = GetBallsWithoutCollisions(0, windowWidth / 2 - BillyardBall.BillyardBallDiameter, Brushes.Aquamarine);
            diffuseBalls = GetBallsWithoutCollisions(windowWidth / 2, windowWidth - BillyardBall.BillyardBallDiameter, Brushes.Pink);

            foreach (var ball in diffuseBalls)
            {
                ball.Paint(CreateGraphics());
            }
        }
        private List<BillyardBall> GetBallsWithoutCollisions(int xMinCoordinateRange, int xMaxCoordinateRange, Brush color)
        {
            for (var i = 0; i < ballsPerColorCount; i++)
            {
                var ballAdded = false;

                while (!ballAdded)
                {
                    var xCoordinate = Randomizer.GetNumberInRange(xMinCoordinateRange, xMaxCoordinateRange);
                    var yCoordinate = Randomizer.GetNumberInRange(0, windowHeight - BillyardBall.BillyardBallDiameter);

                    var randomBall = new BillyardBall(xCoordinate, yCoordinate, color);
                    bool hasCollision = false;

                    foreach (var ball in diffuseBalls)
                    {
                        if (BallsAnimation.IsBallsTouchingEachOther(ball, randomBall))
                        {
                            hasCollision = true;
                            break;
                        }
                    }

                    if (!hasCollision)
                    {
                        diffuseBalls.Add(randomBall);
                        ballAdded = true;
                    }
                }
            }
            return diffuseBalls;
        }
        private void MainForm4_MouseDown(object sender, MouseEventArgs e)
        {
            if (!isDiffusionStart)
            {
                Refresh();
                RefreshField();
                timer.Start();
                isDiffusionStart = true;
            }
            else
            {
                if (timer.Enabled)
                {
                    timer.Stop();
                }
                else
                {
                    timer.Start();
                }
            }
        }
        private BillyardBall MoveBall(BillyardBall ball)
        {
            ball.Clear(CreateGraphics(), ball);
            ball = (BillyardBall)BallsAnimation.MoveRandom(ball, ball.Speed);
            ball.Paint(CreateGraphics());
            return ball;
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            for (var i = 0; i < diffuseBalls.Count; i++)
            {
                var currentBall = diffuseBalls[i];
                currentBall = MoveBall(currentBall);

                var (hitLeftRightWall, hitTopBottomWall) = BallsAnimation.GetWallHits(currentBall, windowWidth, windowHeight);

                if (hitLeftRightWall || hitTopBottomWall)
                {
                    currentBall.Clear(CreateGraphics(), currentBall);
                    currentBall = (BillyardBall)BallsAnimation.CorrectBallPosition(currentBall, windowWidth, windowHeight);
                    IncreaseEdgeHitLabels(currentBall);
                    currentBall.Direction = BallsAnimation.ChangeDirectionFromWall(currentBall, hitLeftRightWall, hitTopBottomWall);
                    currentBall.Paint(CreateGraphics());
                }
            }
            for (var i = 0; i < diffuseBalls.Count; i++)
            {
                for (var j = i + 1; j < diffuseBalls.Count; j++)
                {
                    if (BallsAnimation.IsBallsTouchingEachOther(diffuseBalls[i], diffuseBalls[j]))
                    {
                        var tempDirection = diffuseBalls[i].Direction;
                        diffuseBalls[i].Direction = diffuseBalls[j].Direction;
                        diffuseBalls[j].Direction = tempDirection;
                    }
                }
            }
            if (IsDiffusionComplete())
            {
                timer.Stop();
                isDiffusionStart = false;
                MessageBox.Show("Шары перемешались!");
            }
        }
        private bool IsDiffusionComplete()
        {
            var leftAquaBalls = 0;
            var leftPinkBalls = 0;
            var rightAquaBalls = 0;
            var rightPinkBalls = 0;

            foreach (var ball in diffuseBalls)
            {
                var ballCenter = ball.XCoordinate + ball.Diameter / 2;

                if (ballCenter < windowWidth / 2)
                {
                    if (ball.Color == Brushes.Aquamarine)
                    {
                        leftAquaBalls++;
                    }
                    else
                    {
                        leftPinkBalls++;
                    }
                }
                else
                {
                    if (ball.Color == Brushes.Aquamarine)
                    {
                        rightAquaBalls++;
                    }
                    else
                    {
                        rightPinkBalls++;
                    }
                }
            }
            return leftPinkBalls == ballsPerColorCount / 2 && rightAquaBalls == ballsPerColorCount / 2;
        }
        private void IncreaseEdgeHitLabels(Ball ball)
        {
            if (ball.XCoordinate <= 0)
            {
                if (ball.Color == Brushes.Aquamarine)
                {
                    greenLeftLabelCount++;
                    greenLeftLabel.Text = greenLeftLabelCount.ToString();
                }
                else
                {
                    pinkLeftLabelCount++;
                    pinkLeftLabel.Text = pinkLeftLabelCount.ToString();
                }
            }
            if (ball.XCoordinate + ball.Diameter >= windowWidth)
            {
                if (ball.Color == Brushes.Aquamarine)
                {
                    greenRightLabelCount++;
                    greenRightLabel.Text = greenRightLabelCount.ToString();
                }
                else
                {
                    pinkRightLabelCount++;
                    pinkRightLabel.Text = pinkRightLabelCount.ToString();
                }
            }
            if (ball.YCoordinate <= 0)
            {
                if (ball.Color == Brushes.Aquamarine)
                {
                    greenTopLabelCount++;
                    greenTopLabel.Text = greenTopLabelCount.ToString();
                }
                else
                {
                    pinkTopLabelCount++;
                    pinkTopLabel.Text = pinkTopLabelCount.ToString();
                }
            }
            if (ball.YCoordinate + ball.Diameter >= windowHeight)
            {
                if (ball.Color == Brushes.Aquamarine)
                {
                    greenDownLabelCount++;
                    greenDownLabel.Text = greenDownLabelCount.ToString();
                }
                else
                {
                    pinkDownLabelCount++;
                    pinkDownLabel.Text = pinkDownLabelCount.ToString();
                }
            }
        }
    }
}
