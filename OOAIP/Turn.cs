using System.Numerics;
using System.Linq;

interface ITurning {
        int turning(int[] degree, bool exception);
    }

namespace Turning {
    public class Turn : ITurning {

        static int angle;

        public Turn() {

        }
        public Turn(int startangle) {
            angle = startangle;
        }
        public int turning(int[] degree, bool exception = true) {
            if (!exception) {
                throw new Exception();
            }
            try {
                angle = (angle + degree[0]) % degree[1]; 

                return angle;
            } catch (Exception ex) {
                throw new Exception();
            }
        }
    }
}