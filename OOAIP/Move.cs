
using System.Numerics;
using System.Linq;

using Vectors;
using ICommand;

namespace Movement {

    public interface ICoordinates {
        public Vectors.Vector Position {get; set;}
        public Vectors.Vector Velocity {get;}
    }

    public class Move : ICommand.ICommand {

        private ICoordinates movable;

        public Move(ICoordinates movable) {
            this.movable = movable;
        }

        public void Execute() {
            try {
                movable.Position = Vectors.Vector.sum(movable.Position, movable.Velocity);
            } catch (Exception) {
                throw new Exception();
            }
        }
    }
}