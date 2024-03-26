
public abstract class Shape
{
    // Add the color member variable
    private string _color;
    // Create a constructor that accepts the color and set its.
    public Shape(string color)
    {
        _color = color;
    }
    // Add a getter for the color variable
    public string GetColor()
    {
        return _color;
    }
    // Add a setter for the color variable
    public void SetColor(string color)
    {
        _color = color;
    }
    //Create a virtual method for GetArea()
    public abstract double GetArea();




}