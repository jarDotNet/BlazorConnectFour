namespace BlazorConnectFour.Data
{
    public class ColoredDisc
    {
        public DiscColor Color;
        public bool IsEmpty() => Color == DiscColor.Blank;

        public ColoredDisc()
        {
            Color = DiscColor.Blank;
        }
        public ColoredDisc(DiscColor color)
        {
            Color = color;
        }
    }
}
