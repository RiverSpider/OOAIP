namespace Vectorss{
public interface IVector
{
    double Angle { get; set; } 

    void Rotate(double degrees); 
}

public class Vector : IVector
{
    private double _angle;

    public double Angle
    {
        get { return _angle; }
        set
        {
            _angle = value;
        }
    }

    public void Rotate(double degrees)
    {
        double newAngle = (_angle + degrees) % 360;
        _angle = newAngle;
    }
}
}