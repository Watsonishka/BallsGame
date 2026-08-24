using BallsGameWinFormsLibrary;

namespace BallsGame2WinFormsApp
{
    public partial class MainForm2 : Form
    {
        private int windowWidth;
        private int windowHeight;
        private List<RandomLocationSpeedBall> randomBalls;
        private int catchedBallsCount;
        private int generateBallsCount;
        private int roundCount;
        private int minSpeed;
        private int maxSpeed;
        private const int increaseRoundStep = 3;
        public MainForm2()
        {
            MessageBox.Show("Поймай как можно больше шаров! Шарик будет считаться пойманым, если ты кликнул на него курсором мышки! " +
                "С каждым новым раундом скорость шариков будет постепенно возрастать!");
            InitializeComponent();
            windowWidth = ClientSize.Width;
            windowHeight = ClientSize.Height - panel.Height;
            restartGame();
        }
        private void restartGame()
        {
            Refresh();
            roundCount = 1;
            minSpeed = 1;
            maxSpeed = 15;
            generate.Enabled = true;
            roundLabel.Text = $"Раунд {roundCount}";
            catchBallsCountLabel.Text = "Шаров поймано:";
            commonBallsCountLabel.Text = "Шаров создано:";
            randomBalls = new List<RandomLocationSpeedBall>();
        }
        private void generate_Click(object sender, EventArgs e)
        {
            Refresh();
            generateBallsCount = Randomizer.GetNumberInRange(5, 16);

            for (var i = 0; i < generateBallsCount; i++)
            {
                var randomBall = new RandomLocationSpeedBall(windowWidth, windowHeight, minSpeed, maxSpeed);
                randomBalls.Add(randomBall);
            }

            timer.Start();
            roundLabel.Text = $"Раунд {roundCount}";
            catchBallsCountLabel.Text = "Шаров поймано:";
            commonBallsCountLabel.Text = $"Шаров создано: {randomBalls.Count}";
            generate.Enabled = false;
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            foreach (var ball in randomBalls)
            {
                MoveBall(ball);
            }
            if (BallsAnimation.AreAllBallsCompletelyOffScreen(randomBalls.Cast<Ball>().ToList(), windowWidth, windowHeight))
            {
                EndRound();
            }
        }
        private void MoveBall(Ball ball)
        {
            ball.Clear(CreateGraphics(), ball);
            ball = BallsAnimation.MoveRandom(ball, ball.Speed);
            ball.Paint(CreateGraphics());
        }
        private void MainForm2_MouseDown(object sender, MouseEventArgs e)
        {
            timer.Stop();
            var pointBall = new PointClickBall(e.X, e.Y);
            pointBall.Paint(CreateGraphics());
            CheckCatchedBall(pointBall);
            timer.Start();
        }
        private void CheckCatchedBall(PointClickBall pointBall)
        {
            for (var i = 0; i < randomBalls.Count; i++)
            {
                if (BallsAnimation.IsHit(randomBalls[i], pointBall))
                {
                    catchedBallsCount++;
                    randomBalls[i].Clear(CreateGraphics(), randomBalls[i]);
                    randomBalls.Remove(randomBalls[i]);
                }
            }
            catchBallsCountLabel.Text = $"Шаров поймано: {catchedBallsCount}";
        }
        private void restartButton_Click(object sender, EventArgs e)
        {
            restartGame();
        }
        private void EndRound()
        {
            timer.Stop();
            MessageBox.Show($"Раунд закончен! Все шарики убежали из поля! Твой результат: {catchedBallsCount} из {generateBallsCount}!");
            StartNewRound();
        }
        private void StartNewRound()
        {
            randomBalls.Clear();
            roundCount++;
            IncreaseSpeed();
            catchedBallsCount = 0;
            catchBallsCountLabel.Text = $"Шаров поймано: {catchedBallsCount}";
            generate.Enabled = true;
        }
        private void IncreaseSpeed()
        {
            if (roundCount % increaseRoundStep == 0 && minSpeed < Ball.MaxSpeed)
            {
                minSpeed += 1;
            }
            if (roundCount % (increaseRoundStep * 2) == 0 && maxSpeed < Ball.MaxSpeed)
            {
                maxSpeed += 1;
            }
        }
        private void MainForm2_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show(
                "Вы уверены, что хотите выйти из игры?",
                "Подтверждение выхода",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}

