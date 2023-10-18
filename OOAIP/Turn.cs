namespace Rotatable{
using Vectorss;
public class SpaceshipRotation
{
    private IVector _vector;

    public SpaceshipRotation(IVector vector)
    {
        _vector = vector ?? throw new ArgumentNullException(nameof(vector));
    }

    public void RotateSpaceship(double startDegrees, double rotationDegrees)
    {
        try {
                _vector.Angle = startDegrees;
                _vector.Rotate(rotationDegrees);
            } catch {
                throw new Exception();
            }
    }
}
}