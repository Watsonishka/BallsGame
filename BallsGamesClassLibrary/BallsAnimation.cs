namespace BallsGamesClassLibrary
{
    public static class BallsAnimation
    {
        public static Ball Start(Ball ball, int speed)
        {
            if (ball.Direction == "rightUp")
            {
                ball.XCoordinate += speed;
                ball.YCoordinate += speed;
                return ball;
            }
            else if (ball.Direction == "rightDown")
            {
                ball.XCoordinate += speed;
                ball.YCoordinate -= speed;
                return ball;
            }
            else if (ball.Direction == "leftUp")
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
    }
}
