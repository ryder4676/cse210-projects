public class Fraction
{
    private int topNumber;
    private int bottomNumber;

    // Constructor with no parameters, initializes to 1/1
    public Fraction()
    {
        topNumber = 1;
        bottomNumber = 1;
    }
    public Fraction(int top)
    {
        topNumber = top;
        bottomNumber = 1;
    }
    public Fraction(int top, int bottom)
    {
        topNumber = top;
        bottomNumber = bottom;
    }
    public int TopNumber
    {
        get { return topNumber; }
        set { topNumber = value; }
    }
    public int BottomNumber
    {
        get { return bottomNumber; }
        set { bottomNumber = value; }
    }
    
    public string GetFractionString()
    {
        return $"{topNumber}/{bottomNumber}";
    }
    public double GetDecimalValue()
    {
        return (double) topNumber / bottomNumber;
    }
}