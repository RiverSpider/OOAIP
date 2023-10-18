using System;
using System.Numerics;
using Moq;
using NUnit.Framework;

using Movement;
using Vectors;

    [TestFixture]
    public class StepDefinitions
    {

        [Test]
        public void MovingStraightLine() {
            var mock = new Mock<ICoordinates>();

            mock.SetupGet(m => m.Position).Returns(new Vectors.Vector(new int[] { 12, 5 }));
            mock.SetupGet(m => m.Velocity).Returns(new Vectors.Vector(new int[] { -5, 3 }));

            // Act
            var emd = new Move(mock.Object);
            emd.movement();

            // Assert
            mock.VerifySet(m => m.Position = new Vectors.Vector(new int[] { 7, 8 }));
            mock.VerifyAll();
        }

        [Test]
        public void ImpossibleDetermineCurrentPosition() {
            var mock = new Mock<ICoordinates>();

            mock.SetupGet(m => m.Velocity).Returns(new Vectors.Vector(new int[] { -5, 3 }));
            // Act
            var emd = new Move(mock.Object);

            mock.Setup(m => m.Position).Throws<Exception>();

            // Assert
            Assert.Throws<Exception>(() => emd.movement());
        }

        [Test]
        public void ImpossibleDetermineCurrentVelocity() {
            var mock = new Mock<ICoordinates>();

            mock.SetupGet(m => m.Position).Returns(new Vectors.Vector(new int[] { 12, 5 }));
            // Act
            var emd = new Move(mock.Object);

            mock.Setup(m => m.Velocity).Throws<Exception>();

            // Assert
            Assert.Throws<Exception>(() => emd.movement());
        }

        [Test]
        public void ImpossibleChangeCurrentPosition() {
            bool exp = false;

            var mock = new Mock<ICoordinates>();
        
            mock.SetupGet(m => m.Position).Returns(new Vectors.Vector(new int[] { 12, 5 }));
            mock.SetupGet(m => m.Velocity).Returns(new Vectors.Vector(new int[] { -5, 3 }));

            // Act
            var emd = new Move(mock.Object);

            // Assert
            Assert.Throws<Exception>(() => emd.movement(exp));
        }
     
}