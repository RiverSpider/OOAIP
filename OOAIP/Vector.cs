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
    }
}
