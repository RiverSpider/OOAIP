
using System.Numerics;
using System.Linq;

interface IMove {
        double[] movement(double[] speed, bool exception);
    }

namespace Movement {
    public class Move : IMove {

        static double[] position;

        public Move() {

        }
        public Move(double[] startingPosition) {
            position = startingPosition;
        }
        public double[] movement(double[] speed, bool exception = true) {
            if (!exception) {
                throw new Exception();
            }
            try {
                position = position.Zip(speed, (a, b) => a + b).ToArray();

                return position;
            } catch (Exception ex) {
                throw new Exception();
            }
        }
    }
}