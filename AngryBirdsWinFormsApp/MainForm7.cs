using BallsGameWinFormsLibrary;

namespace AngryBirdsWinFormsApp
{
    public partial class MainForm7 : Form
    {
        private int windowWidth;
        private int windowHeight;
        private const float velocity = 0.6f;
        private const float timeToPeak = 25f;
        private const int standartLimitCount = 3;
        private static readonly Brush _pigColor = Brushes.Green;
        private int hitPigs;
        private int score;
        private int attemptCount;
        private int userAttemptCount;
        private int extraAttemptCount;
        private int round;
        private List<RandomLocationSpeedBall> pigs;
        private List<RandomLocationSpeedBall> backupPigs;
        private List<GravityBall> explosionBalls;
        private List<GravityBall> doppelgangerBalls;
        private GravityBall bird;
        private float xPeakCoordinate;
        private float yPeakCoordinate;
        private bool isFlyingBird;
        private bool hasExplodedBird;
        private bool hasDuplicatedBird;
        private bool hasHit;

        public MainForm7()
        {
            InitializeComponent();
            MessageBox.Show(
                "ПРАВИЛА:\n\n" +
                "• Кликни на поле → задай траекторию\n" +
                "• Сбивай зеленых свиней\n" +
                "• Черная птица → ВЗРЫВ\n" +
                "• Синяя птица → ДВОЙНИКИ (3 шт).\n" +
                "• Чем меньше попыток осталось - тем больше бонус!\n\n" +
                "Победа: уничтожить всех свиней!",
                "Правила",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
                );
            DoubleBuffered = true;
            windowWidth = ClientSize.Width;
            windowHeight = ClientSize.Height;
            RestartGame();
        }
        private void RestartGame()
        {
            Refresh();
            timer.Stop();

            explosionBalls = new List<GravityBall>();
            doppelgangerBalls = new List<GravityBall>();
            isFlyingBird = false;
            hasExplodedBird = false;
            hasDuplicatedBird = false;
            hasHit = false;

            round = 1;
            hitPigs = 0;
            userAttemptCount = 0;
            extraAttemptCount = 0;
            score = 0;

            GenerateBird();
            GeneratePigs();
            SetAttemptCount(pigs.Count);

            attemptCountLabel.Text = $"Количество попыток: ";
            pigsCountLabel.Text = $"Количество сбитых свиней: ";
            roundLabel.Text = $"Раунд ";
            scoreLabel.Text = $"Счет: ";
        }
        private void GenerateBird()
        {
            var color = BrushesStorage.GetRandomBirdBrush();
            var diameter = Randomizer.GetBirdDiameter(color);

            bird = new GravityBall(diameter - 30, windowHeight - diameter - 20, diameter, color, -1);
        }
        private void CreateExplodeBalls(GravityBall bird)
        {
            var generateBallsCount = Randomizer.GetNumberInRange(20, 41);

            for (var i = 0; i < generateBallsCount; i++)
            {
                var ball = new GravityBall(bird.XCoordinate, bird.YCoordinate, Randomizer.GetNumberInRange(7, 12), bird.Color, 100);
                explosionBalls.Add(ball);
            }
        }
        private void CreateDoppelgangerBirds(GravityBall bird)
        {
            for (var i = 0; i < standartLimitCount; i++)
            {
                var offsetX = Randomizer.GetNumberInRange(-20, 20);
                var offsetY = Randomizer.GetNumberInRange(-20, 20);

                var ball = new GravityBall(bird.XCoordinate + offsetX, bird.YCoordinate + offsetY, bird.Diameter / 2, bird.Color, 100);

                ball.Direction = Randomizer.GetDirection();
                var speedVariation = (float)(Randomizer.GetNumberInRange(70, 130) / 100.0);
                ball.Speed = bird.Speed * speedVariation;
                ball.VerticalSpeed = bird.VerticalSpeed * speedVariation;

                doppelgangerBalls.Add(ball);
            }
        }
        private void GeneratePigs()
        {
            pigs = new List<RandomLocationSpeedBall>();
            var pigsCount = Randomizer.GetNumberInRange(2, 6);

            for (var i = 0; i < pigsCount; i++)
            {
                while (true)
                {
                    var pig = new RandomLocationSpeedBall(windowWidth, windowHeight);
                    var touchesBird = BallsAnimation.IsBallsTouchingEachOther(bird, pig);
                    var isInsideScreen = BallsAnimation.IsBallFullyInsideScreen(pig, windowWidth, windowHeight);
                    var touchesOtherPig = false;

                    foreach (var existingPig in pigs)
                    {
                        if (BallsAnimation.IsBallsTouchingEachOther(pig, existingPig))
                        {
                            touchesOtherPig = true;
                            break;
                        }
                    }

                    if (!touchesBird && isInsideScreen && !touchesOtherPig)
                    {
                        pig.Color = _pigColor;
                        pigs.Add(pig);
                        break;
                    }
                }
            }

            backupPigs = new List<RandomLocationSpeedBall>(pigs);
        }
        private void SetAttemptCount(int pigsCount)
        {
            if (userAttemptCount > 0 && userAttemptCount % standartLimitCount == 0)
            {
                extraAttemptCount++;
            }

            attemptCount = (int)Math.Ceiling(pigsCount / 2.0) + extraAttemptCount;
        }
        private void PaintField()
        {
            bird.Paint(CreateGraphics());

            foreach (var pig in pigs)
            {
                pig.Paint(CreateGraphics());
            }
        }
        private GravityBall MoveBird(GravityBall ball)
        {
            ball.Clear(CreateGraphics(), ball);
            var newBall = BallsAnimation.MoveGravityToPeak(ball, ball.Gravity);
            newBall.Paint(CreateGraphics());
            return newBall;
        }
        private void MoveExplosion(GravityBall ball)
        {
            ball.Clear(CreateGraphics(), ball);
            ball = BallsAnimation.MoveGravaity(ball);
            ball.Paint(CreateGraphics());
        }
        private void MainForm7_MouseDown(object sender, MouseEventArgs e)
        {
            Refresh();
            PaintField();

            if (isFlyingBird)
            {
                return;
            }
            else
            {
                isFlyingBird = true;
                restartButton.Enabled = false;

                xPeakCoordinate = e.X;
                yPeakCoordinate = e.Y;

                var dx = xPeakCoordinate - bird.XCoordinate;
                var dy = yPeakCoordinate - bird.YCoordinate;

                bird.Speed = dx / timeToPeak;

                if (Math.Abs(bird.Speed) < 1) bird.Speed = bird.Speed > 0 ? 3 : -3;

                bird.VerticalSpeed = (dy - (bird.Gravity * timeToPeak * timeToPeak) / 2f) / timeToPeak;

                if (dx > 0)
                {
                    bird.Direction = Direction.rightUp;
                }
                else
                {
                    bird.Direction = Direction.leftUp;
                }

                timer.Start();
                attemptCount--;

                attemptCountLabel.Text = $"Количество попыток: {attemptCount}";
                roundLabel.Text = $"Раунд {round}";
            }
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            pigsCountLabel.Text = $"Количество сбитых свиней: {hitPigs}";
            scoreLabel.Text = $"Счет: {score}";

            if (!hasExplodedBird && !hasDuplicatedBird)
            {
                bird = MoveBird(bird);
                BallsAnimation.BounceFromWallsWithGravity(bird, velocity, xPeakCoordinate, yPeakCoordinate, this);
                hasHit = CheckHit(bird);

                if (bird.Color == Brushes.Black && hasHit)
                {
                    hasExplodedBird = true;
                    CreateExplodeBalls(bird);
                    bird.Color = Brushes.WhiteSmoke;
                    bird.Clear(CreateGraphics(), bird);
                }
                else if (bird.Color == Brushes.Blue && hasHit)
                {
                    hasDuplicatedBird = true;
                    CreateDoppelgangerBirds(bird);
                    bird.Color = Brushes.WhiteSmoke;
                    bird.Clear(CreateGraphics(), bird);
                }
            }

            if (hasDuplicatedBird)
            {
                for (var i = doppelgangerBalls.Count - 1; i >= 0; i--)
                {
                    doppelgangerBalls[i] = MoveBird(doppelgangerBalls[i]);
                    BallsAnimation.BounceFromWallsWithGravity(doppelgangerBalls[i], velocity, xPeakCoordinate, yPeakCoordinate, this);
                    CheckHit(doppelgangerBalls[i]);
                }
            }

            else if (hasExplodedBird)
            {
                for (var i = explosionBalls.Count - 1; i >= 0; i--)
                {
                    if (explosionBalls[i].LifeSpawn > 0)
                    {
                        MoveExplosion(explosionBalls[i]);
                        CheckHit(explosionBalls[i]);
                    }
                    explosionBalls[i].LifeSpawn--;

                    if (explosionBalls[i].LifeSpawn <= 0 || BallsAnimation.IsBallCompletelyOffScreen(explosionBalls[i], windowWidth, windowHeight))
                    {
                        explosionBalls[i].Clear(CreateGraphics(), explosionBalls[i]);
                        explosionBalls.RemoveAt(i);
                    }
                }
            }

            if (CheckBirdsStop())
            {
                ResetBirdState();
                isFlyingBird = false;
                restartButton.Enabled = true;
                CheckLoseRound();
            }
        }
        private void ResetBirdState()
        {
            hasExplodedBird = false;
            hasDuplicatedBird = false;
            hasHit = false;

            doppelgangerBalls.Clear();

            bird.Clear(CreateGraphics(), bird);

            Refresh();
            GenerateBird();
            PaintField();

            timer.Stop();
        }
        private bool CheckBirdsStop()
        {
            if (hasDuplicatedBird)
            {
                foreach (var doppelgangerBall in doppelgangerBalls)
                {
                    if (doppelgangerBall.VerticalSpeed != 0)
                    {
                        return false;
                    }
                }
                return true;
            }
            return (bird.VerticalSpeed == 0 && !hasExplodedBird) || (explosionBalls.Count <= 0 && hasExplodedBird);
        }
        private bool CheckHit(Ball ball)
        {
            for (var i = pigs.Count - 1; i >= 0; i--)
            {
                if (BallsAnimation.IsBallsTouchingEachOther((GravityBall)ball, pigs[i]))
                {
                    IncreaseScore();

                    pigs[i].Clear(CreateGraphics(), pigs[i]);
                    pigs.RemoveAt(i);

                    Refresh();
                    PaintField();

                    return true;
                }
            }
            return false;
        }
        private void IncreaseScore()
        {
            var points = 10;

            if (attemptCount < 0)
            {
                points += attemptCount * 5;
            }
            score += points;
            hitPigs++;
        }
        private void CheckLoseRound()
        {
            if (attemptCount <= 0 && pigs.Count > 0)
            {
                userAttemptCount++;

                var pigsRemoved = backupPigs.Count - pigs.Count;
                hitPigs = Math.Max(0, hitPigs - pigsRemoved);

                pigs = new List<RandomLocationSpeedBall>(backupPigs);

                SetAttemptCount(pigs.Count);
                PaintField();
            }
            else if (pigs.Count == 0)
            {
                round++;
                userAttemptCount = 0;
                extraAttemptCount = 0;

                GeneratePigs();
                SetAttemptCount(pigs.Count);
                PaintField();

                roundLabel.Text = $"Раунд {round}";
            }
        }
        private void restartButton_Click(object sender, EventArgs e)
        {
            Refresh();
            RestartGame();
        }
    }
}