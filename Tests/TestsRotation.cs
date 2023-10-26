using TechTalk.SpecFlow;
using Moq;
using SpaceBattle;
using Xunit; 
using System;

namespace Tests
{
    [Binding]
    public class RotationSteps
    {
        int initialDegrees;
        int rotationDegrees;
        Mock<IRotate> rotateMock;
        Mock<Angle> vectorMock;
        ICommand rotationCommand;

        public RotationSteps()
        {
            rotateMock = new Mock<IRotate>();
            vectorMock = new Mock<Angle>();
            rotationCommand = new RotationCommand(rotateMock.Object, vectorMock.Object);
        }

        [Given(@"космический корабль имеет угол наклона (.*) град к оси OX")]
        public void GivenКосмическийКорабльИмеетУголНаклонаГрадКОсиOX(int tiltAngle)
        {
            this.initialDegrees = tiltAngle;
            vectorMock.Setup(v => v.StartAngle).Returns(tiltAngle);
        }

        [Given(@"имеет мгновенную угловую скорость (.*) град")]
        public void GivenИмеетМгновеннуюУгловуюСкоростьГрад(int angularSpeed)
        {
            this.rotationDegrees = angularSpeed;
            rotateMock.Setup(r => r.RotationRate).Returns(angularSpeed);
        }

        [Given(@"космический корабль, угол наклона которого невозможно определить")]
        public void GivenКосмическийКорабльУголНаклонаКоторогоНевозможноОпределить()
        {
            vectorMock.Setup(v => v.StartAngle).Throws<Exception>();
        }

        [Given(@"мгновенную угловую скорость невозможно определить")]
        public void GivenМгновеннуюУгловуюСкоростьНевозможноОпределить()
        {
            rotateMock.Setup(r => r.RotationRate).Throws<Exception>();
        }

        [Given(@"невозможно изменить угол наклона к оси OX космического корабля")]
        public void GivenНевозможноИзменитьУголНаклонаКОсиOXКосмическогоКорабля()
        {
            vectorMock.Setup(v => v.Rotate(It.IsAny<int>())).Throws<Exception>();
        }

        [When(@"происходит вращение вокруг собственной оси")]
        public void WhenПроисходитВращениеВокругСобственнойОси()
        {
            try{
            rotationCommand.Execute();
            }
            catch{}
        }

        [Then(@"угол наклона космического корабля к оси OX составляет (.*) град")]
        public void ThenУголНаклонаКосмическогоКорабляКОсиOXСоставляетГрад(int expectedTiltAngle)
        {
            rotateMock.Verify(r => r.RotationRate, Times.Once);
            vectorMock.Verify(v => v.StartAngle, Times.Once);
            vectorMock.Verify(v => v.Rotate(rotationDegrees), Times.Once);
        }

        [Then(@"возникает ошибка Exception")]
        public void ThenВозникаетОшибкаException()
        {
            Assert.Throws<Exception>(() => rotationCommand.Execute());
        }  
    }
}