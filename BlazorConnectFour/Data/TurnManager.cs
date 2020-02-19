namespace BlazorConnectFour.Data
{
    public class TurnManager
    {
        readonly Turn RedTurn = new Turn(DiscColor.Red, "🔴");

        readonly Turn YellowTurn = new Turn(DiscColor.Yellow, "🟡");

        public Turn CurrentTurn;

        public TurnManager()
        {
            CurrentTurn = RedTurn;
        }

        public void SwitchTurns()
        {
            CurrentTurn = CurrentTurn == RedTurn ? YellowTurn : RedTurn;
        }
    }
}
