namespace Ferrari
{
    public interface ICar
    {
        string Driver { get; set; }

        string GasPedal();
        string BreakPedal();
    }
}
