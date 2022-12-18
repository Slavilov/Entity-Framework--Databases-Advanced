using P03_FootballBetting;

namespace P03_FootballBetting 
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new FootBallBettingContext();
            context.Database.EnsureCreated();
        }
    }
}