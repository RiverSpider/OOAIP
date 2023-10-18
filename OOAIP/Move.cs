
using System.Numerics;
using System.Linq;

using Vectors;

namespace Movement {

    interface IMove {
            void movement(bool exp = true);
    }
    public interface ICoordinates {
        public Vectors.Vector Position {get; set;}
        public Vectors.Vector Velocity {get; set;}
    }

    public class Move : IMove {

        //static IPosition movable;

        private ICoordinates movable;

        public Move(ICoordinates movable) {
            this.movable = movable;
        }

        public void movement(bool exp = true) {
            if (!exp) {
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