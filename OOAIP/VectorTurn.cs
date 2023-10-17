using System;

namespace Vectorss{
public interface IVector
{
    double Angle { get; set; } 
    double AngularVelocity { get; set; } 
    double Rotatable { get; set; } 

    void Rotate(double degrees); 
}

public class Vector : IVector
{
    private double _angle;
    private double _angularVelocity;
    private double _rotatability;

    public double Angle
    {
        get { return _angle; }
        set
        {
            if (double.IsNaN(value))
                throw new ArgumentException();
            _angle = value;
        }
    }

    public double AngularVelocity
    {
        get { return _angularVelocity; }
        set
        {
            if (double.IsNaN(value))
                throw new ArgumentException();
            _angularVelocity = value;
        }
    }

    public double Rotatable
    {
        get { return _rotatability; }
        set
        {
            if (double.IsNaN(value))
                throw new ArgumentException();
            _rotatability = value;
        }
    }

    public void Rotate(double degrees)
    {
        if (double.IsNaN(degrees))
            throw new ArgumentException();

        double newAngle = (_angle + degrees) % 360;
        if (double.IsNaN(newAngle))
            throw new InvalidOperationException();

        _angle = newAngle;
    }
}
}