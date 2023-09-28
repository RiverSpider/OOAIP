
using System.Numerics;
using System.Linq;

using Vectors;

namespace Movement {

    interface IMove {
            void movement(bool exception = true);
    }

    public class Coordinates {
        public Vectors.Vector Position {get; set;}
        public Vectors.Vector Velocity {get; set;}
    }

    public class Move : IMove {

        //static IPosition movable;

        private Coordinates movable;

        public Move(Coordinates movable) {
            this.movable = movable;
        }

        public Vectors.Vector getPosition() {
            return movable.Position;
        }

        public void movement(bool exception = true) {
            if (!exception) {
                throw new Exception();
            }
            try {
                movable.Position = Vectors.Vector.sum(movable.Position, movable.Velocity);
            } catch (Exception ex) {
                throw new Exception();
            }
        }
    }
}