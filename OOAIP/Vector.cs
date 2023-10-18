using System.Numerics;

namespace Vectors {
    public class Vector {

        private static int[] vector;

        public Vector(int[] vectors) {
            vector = vectors;
        }

        public int[] getVector() {
            return vector;
        }

        public static Vector sum(Vector position, Vector velocity)
        {
            int[] vectorVelocity = velocity.getVector(), vectorPosition = position.getVector();
            for (int i = 0; i < vectorPosition.Length; i++) {
                vectorPosition[i] += vectorVelocity[i];
            }
            return new Vector(vectorPosition);
        }

        public override bool Equals(object obj)
        {
            Vector vector2 = (Vector) obj;
            int[] getVector2 = vector2.getVector();
            for(int i = 0; i < vector.Length; i++) {
                if(!vector[i].Equals(getVector2[i])) {
                    return false;
                }
            }
            return true;
            //return vector.isEqual(vector2.getVector());
        }


        public override int GetHashCode()
        {
            return HashCode.Combine(vector);
        }
    }
}
