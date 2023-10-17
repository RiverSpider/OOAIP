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
            var ICoordinates = new ICoordinates { Position = new Vectors.Vector(new int[] { 12, 5 }), Velocity = new Vectors.Vector(new int[] { -5, 3 }) };

            var mock = new Mock<ICoordinates>();

            mock.Setup(mock => mock.Position).Returns(new Vectors.Vector(new int[] { 12, 5 }));
            mock.Setup(mock => mock.Velocity).Returns(new Vectors.Vector(new int[] { -5, 3 }));

            //Act
            var emd = new Move(mock.Object);
            emd.movement();

            //Assert
            mock.VerifySet(mock => mock.Position = new Vectors.Vector(new int[] { 7, 8 }));
            mock.VerifyAll();
        }
     
}