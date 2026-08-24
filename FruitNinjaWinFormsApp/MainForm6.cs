using BallsGameWinFormsLibrary;

namespace FruitNinjaWinFormsApp
{
    public partial class MainForm6 : Form
    {
        private int windowWidth;
        private int windowHeight;
        private int score;
        private bool isGamePaused;
        private bool isFruitSlowDown;
        private int slowDownTime;
        private const int splashAnimationTime = 30;
        private const int splashDurationTime = 40;
        private List<GravityBall> fruitBalls = new List<GravityBall>();
        private List<GravityBall> splashBalls = new List<GravityBall>();
        public MainForm6()
        {
            InitializeComponent();
            DoubleBuffered = true;
            windowWidth = ClientSize.Width;
            windowHeight = ClientSize.Height - panel1.Height;
            EndGame();
            MessageBox.Show
                (
                "ПРАВИЛА ИГРЫ:\n" +
                "\n" +
                "- Режь фрукты (води мышкой), получай очки\n" +
                "- Бомба (черный шар) - мгновенное поражение\n" +
                "- Банан (желтый шар) - замедляет все фрукты на пару секунд\n" +
                "- Пропущенные фрукты улетают с экрана без каких-либо последствий.\n\n"
                );
        }
        private void MainForm6_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isGamePaused)
            {
                CheckFruitCut(e.X, e.Y);
            }
        }
        private void CheckFruitCut(float mouseXCoordinate, float mouseYCoordinate)
        {
            for (var i = fruitBalls.Count - 1; i >= 0; i--)
            {
                var fruitCenterX = fruitBalls[i].XCoordinate + fruitBalls[i].Diameter / 2;
                var fruitCenterY = fruitBalls[i].YCoordinate + fruitBalls[i].Diameter / 2;

                var dx = mouseXCoordinate - fruitCenterX;
                var dy = mouseYCoordinate - fruitCenterY;
                var distance = Math.Sqrt(dx * dx + dy * dy);

                if (distance < fruitBalls[i].Diameter / 2)
                {
                    if (fruitBalls[i].Color == Brushes.Black)
                    {
                        StopTimers();
                        MessageBox.Show("Бомба взорвалась!");
                        EndGame();
                        return;
                    }
                    if (fruitBalls[i].Color == Brushes.Yellow)
                    {
                        slowDownTime += 30;
                        isFruitSlowDown = true;
                        StopTimers();
                        StartTimers();
                    }

                    IncreaseScore(fruitBalls[i]);
                    SplashFruit(fruitBalls[i]);
                    fruitBalls[i].Clear(CreateGraphics(), fruitBalls[i]);
                    fruitBalls.RemoveAt(i);
                }
            }
        }
        private void SplashFruit(GravityBall fruit)
        {
            var generateBallsCount = Randomizer.GetNumberInRange(20, 41);
            for (var i = 0; i < generateBallsCount; i++)
            {
                var splashBall = new GravityBall(fruit.XCoordinate, fruit.YCoordinate, Randomizer.GetNumberInRange(7, 12), fruit.Color, splashDurationTime);
                splashBalls.Add(splashBall);
            }
        }
        private void IncreaseScore(GravityBall fruit)
        {
            score += Randomizer.GetFruitPoints(fruit.Color);
            scoreLabel.Text = $"Счет: {score}";
        }
        private void stopButton_Click(object sender, EventArgs e)
        {
            isGamePaused = true;
            StopTimers();
            stopButton.Enabled = false;
            startButton.Enabled = true;
        }
        private void restartButton_Click(object sender, EventArgs e)
        {
            EndGame();
        }
        private void EndGame()
        {
            Refresh();
            fruitBalls.Clear();
            splashBalls.Clear();
            StopTimers();
            stopButton.Enabled = false;
            startButton.Enabled = true;
            restartButton.Enabled = false;
            isFruitSlowDown = false;
            if (score > 0)
            { 
                MessageBox.Show($"Игра закончена! Твой счет: {score}"); 
            }
            score = 0;
            scoreLabel.Text = $"Счет: {score}";
            slowDownTime = 0;
            slowDownTimeLabel.Text = $"Замедление времени: {slowDownTime}";
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            UpdateAllBalls();
        }
        private void UpdateAllBalls()
        {
            for (var i = fruitBalls.Count - 1; i >= 0; i--)
            {
                MoveBall(fruitBalls[i]);
                if (BallsAnimation.IsBallCompletelyOffScreen(fruitBalls[i], windowWidth, windowHeight))
                {
                    fruitBalls.RemoveAt(i);
                }
            }
            for (var i = splashBalls.Count - 1; i >= 0; i--)
            {
                if (splashBalls[i].LifeSpawn > splashAnimationTime)
                {
                    MoveBall(splashBalls[i]);
                }
                splashBalls[i].LifeSpawn--;

                if (splashBalls[i].LifeSpawn <= 0 || BallsAnimation.IsBallCompletelyOffScreen(splashBalls[i], windowWidth, windowHeight))
                {
                    splashBalls[i].Clear(CreateGraphics(), splashBalls[i]);
                    splashBalls.RemoveAt(i);
                }
            }
        }
        private GravityBall MoveBall(GravityBall ball)
        {
            ball.Clear(CreateGraphics(), ball);
            ball = BallsAnimation.MoveGravaity(ball);
            ball.Paint(CreateGraphics());
            return ball;
        }
        private void startButton_Click(object sender, EventArgs e)
        {
            isGamePaused = false;
            StartTimers();
            startButton.Enabled = false;
            stopButton.Enabled = true;
            restartButton.Enabled = true;
        }
        private void fruitGenerationTimer_Tick(object sender, EventArgs e)
        {
            GenerateFruit();
        }
        private void GenerateFruit()
        {
            var generateCount = Randomizer.GetNumberInRange(3, 12);
            for (var i = 0; i < generateCount; i++)
            {
                var xCoordinate = Randomizer.GetNumberInRange(100, windowWidth - 100);
                var yCoordinate = windowHeight;
                var fruit = new GravityBall(xCoordinate, yCoordinate, BrushesStorage.GetRandomFruitBrush());
                fruitBalls.Add(fruit);
            }
        }
        private void slowDownTimer_Tick(object sender, EventArgs e)
        {
            slowDownTimeLabel.Text = $"Замедление времени: {slowDownTime}";
            UpdateAllBalls();
            slowDownTime--;

            if (slowDownTime == 0)
            {
                isFruitSlowDown = false;
                StopTimers();
                StartTimers();
                slowDownTimeLabel.Text = $"Замедление времени: {slowDownTime}";
            }
        }        
        private void slowFruitGenerationTimer_Tick(object sender, EventArgs e)
        {
            GenerateFruit();
        }
        private void StopTimers()
        {
            slowDownTimer.Stop();
            slowFruitGenerationTimer.Stop();
            timer.Stop();
            fruitGenerationTimer.Stop();
            
        }
        private void StartTimers()
        {
            if (isFruitSlowDown)
            {
                slowDownTimer.Start();
                slowFruitGenerationTimer.Start();
            }
            else
            {
                timer.Start();
                fruitGenerationTimer.Start();
            }
        }
    }
}
