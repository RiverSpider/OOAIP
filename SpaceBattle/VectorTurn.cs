namespace SpaceBattle;
public class Angle
{
    private int _angle;

    public virtual int StartAngle
    {
        get => _angle;
        set => _angle = value % 360;
    }

    public virtual void Rotate(int degrees)
    {
        var newAngle = (_angle + degrees) % 360;
        _angle = newAngle < 0 ? newAngle + 360 : newAngle;
    }

    public int CurrentAngle => _angle;
}