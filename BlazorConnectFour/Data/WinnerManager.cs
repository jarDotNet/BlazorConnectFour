namespace BlazorConnectFour.Data
{
    public class WinnerManager
    {
        public DiscColor Winner;

        public WinnerManager()
        {
            Winner = DiscColor.Blank;
        }

        public void SetWinner(DiscColor color)
        {
            Winner = color;
        }

        public bool IsThereAWinner()
        {
            return Winner != DiscColor.Blank;
        }
    }
}
