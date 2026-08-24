using System.Timers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace BallsGameWinFormsLibrary
{
    public class BallsAnimation
    {
        public static Ball MoveRandom(Ball ball, int speed)
        {
            if (ball.Direction == Direction.rightUp)
            {
                ball.XCoordinate += speed;
                ball.YCoordinate += speed;
                return ball;
            }
            else if (ball.Direction == Direction.rightDown)
            {
                ball.XCoordinate += speed;
                ball.YCoordinate -= speed;
                return ball;
            }
            else if (ball.Direction == Direction.leftUp)
            {
                ball.XCoordinate -= speed;
                ball.YCoordinate += speed;
                return ball;
            }
            else
            {
                ball.XCoordinate -= speed;
                ball.YCoordinate -= speed;
                return ball;
            }
        }
        public static Direction ChangeDirectionFromWall(Ball ball, bool hitLeftRightWall, bool hitTopBottomWall)
        {
            if (hitLeftRightWall)
            {
                if (ball.Direction == Direction.rightUp)
                {
                    return Direction.leftUp;
                }
                if (ball.Direction == Direction.rightDown)
                {
                    return Direction.leftDown;
                }
                if (ball.Direction == Direction.leftUp)
                {
                    return Direction.rightUp;
                }
                if (ball.Direction == Direction.leftDown)
                {
                    return Direction.rightDown;
                }
            }
            if (hitTopBottomWall)
            {
                if (ball.Direction == Direction.rightUp)
                {
                    return Direction.rightDown;
                }
                if (ball.Direction == Direction.rightDown)
                {
                    return Direction.rightUp;
                }
                if (ball.Direction == Direction.leftUp)
                {
                    return Direction.leftDown;
                }
                if (ball.Direction == Direction.leftDown)
                {
                    return Direction.leftUp;
                }
            }
            return Randomizer.GetDirection();
        }
        public static Ball CorrectBallPosition(Ball ball, int widthWindow, int heightWindow)
        {
            if (ball.XCoordinate < 0)
            {
                ball.XCoordinate = 0;
            }
            if (ball.XCoordinate + ball.Diameter > widthWindow)
            {
                ball.XCoordinate = widthWindow - ball.Diameter;
            }
            if (ball.YCoordinate < 0)
            {
                ball.YCoordinate = 0;
            }
            if (ball.YCoordinate + ball.Diameter > heightWindow)
            {
                ball.YCoordinate = heightWindow - ball.Diameter;
            }
            return ball;
        }
        public static (bool hitLeftRight, bool hitTopBottom) GetWallHits(Ball ball, int widthWindow, int heightWindow)
        {
            var hitLeftRightWall = ball.XCoordinate <= 0 || ball.XCoordinate + ball.Diameter >= widthWindow;
            var hitTopBottomWall = ball.YCoordinate <= 0 || ball.YCoordinate + ball.Diameter >= heightWindow;

            return (hitLeftRightWall, hitTopBottomWall);
        }
        public static bool IsHit(Ball firstBall, Ball secondBall)
        {
            return secondBall.XCoordinate >= firstBall.XCoordinate &&
                   secondBall.XCoordinate <= firstBall.XCoordinate + firstBall.Diameter &&
                   secondBall.YCoordinate >= firstBall.YCoordinate &&
                   secondBall.YCoordinate <= firstBall.YCoordinate + firstBall.Diameter;
        }
        public static bool AreAllBallsCompletelyOffScreen(List<Ball> balls, int windowWidth, int windowHeight)
        {
            foreach (var ball in balls)
            {
                if (ball.XCoordinate + ball.Diameter > 0 &&
                    ball.XCoordinate < windowWidth &&
                    ball.YCoordinate + ball.Diameter > 0 &&
                    ball.YCoordinate < windowHeight)
                {
                    return false;
                }
            }
            return true;
        }
        public static bool IsBallCompletelyOffScreen(Ball ball, int windowWidth, int windowHeight)
        {
            return ball.XCoordinate + ball.Diameter < 0 ||
                   ball.XCoordinate > windowWidth ||
                   ball.YCoordinate + ball.Diameter < 0 ||
                   ball.YCoordinate > windowHeight;
        }
        public static bool IsBallFullyInsideScreen(Ball ball, int windowWidth, int windowHeight)
        {
            return ball.XCoordinate >= 0 &&
                   ball.XCoordinate + ball.Diameter <= windowWidth &&
                   ball.YCoordinate >= 0 &&
                   ball.YCoordinate + ball.Diameter <= windowHeight;
        }
        public static bool IsBallsTouchingEachOther(Ball firstBall, Ball secondBall)
        {
            var firstCenterX = firstBall.XCoordinate + firstBall.Diameter / 2;
            var firstCenterY = firstBall.YCoordinate + firstBall.Diameter / 2;
            var secondCenterX = secondBall.XCoordinate + secondBall.Diameter / 2;
            var secondCenterY = secondBall.YCoordinate + secondBall.Diameter / 2;

            var offsetX = firstCenterX - secondCenterX;
            var offsetY = firstCenterY - secondCenterY;
            var distanceSquared = offsetX * offsetX + offsetY * offsetY;
            var radiusSum = firstBall.Diameter / 2 + secondBall.Diameter / 2;
            var radiusSumSquared = radiusSum * radiusSum;

            return distanceSquared <= radiusSumSquared;
        }
        public static bool IsBallsTouchingEachOther(GravityBall firstBall, Ball secondBall)
        {
            var firstCenterX = firstBall.XCoordinate + firstBall.Diameter / 2;
            var firstCenterY = firstBall.YCoordinate + firstBall.Diameter / 2;
            var secondCenterX = secondBall.XCoordinate + secondBall.Diameter / 2;
            var secondCenterY = secondBall.YCoordinate + secondBall.Diameter / 2;

            var offsetX = firstCenterX - secondCenterX;
            var offsetY = firstCenterY - secondCenterY;
            var distanceSquared = offsetX * offsetX + offsetY * offsetY;
            var radiusSum = firstBall.Diameter / 2 + secondBall.Diameter / 2;
            var radiusSumSquared = radiusSum * radiusSum;

            return distanceSquared <= radiusSumSquared;
        }
        public static GravityBall MoveGravaity(GravityBall ball)
        {
            ball.VerticalSpeed += ball.Gravity;
            if (ball.Direction == Direction.rightUp)
            {
                ball.XCoordinate += ball.Speed;
            }
            else
            {
                ball.XCoordinate -= ball.Speed;
            }
            ball.YCoordinate += ball.VerticalSpeed;
            return ball;
        }
        public static GravityBall MoveGravityToPeak(GravityBall ball, float gravity)
        {
            ball.VerticalSpeed += gravity;
            ball.XCoordinate += ball.Speed;
            ball.YCoordinate += ball.VerticalSpeed;

            return ball;
        }
        public static GravityBall BounceFromWallsWithGravity(GravityBall ball, float velocity, float xPeakCoordinate, float yPeakCoordinate, Form form)
        {
            if (ball.YCoordinate + ball.Diameter >= form.ClientSize.Height)
            {
                ball.Clear(form.CreateGraphics(), ball);
                ball.YCoordinate = form.ClientSize.Height - ball.Diameter;
                ball.VerticalSpeed = -ball.VerticalSpeed * velocity;

                if (Math.Abs(ball.VerticalSpeed) < 1f)
                {
                    ball.VerticalSpeed = 0;
                }
            }
            if (ball.XCoordinate <= 0)
            {
                ball.Clear(form.CreateGraphics(), ball);
                ball.XCoordinate = 0;
                ball.Speed = -ball.Speed * velocity;
            }
            if (ball.XCoordinate + ball.Diameter >= form.ClientSize.Width)
            {
                ball.Clear(form.CreateGraphics(), ball);
                ball.XCoordinate = form.ClientSize.Width - ball.Diameter;
                ball.Speed = -ball.Speed * velocity;
            }
            return ball;
        }
    }
}
