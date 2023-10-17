using TechTalk.SpecFlow;
using Moq;

using Rotatable;
using Vectorss;

namespace Tests
{
    [Binding]
    public class RotationSteps
    {
        SpaceshipRotation spaceshipRotation;
        double initialDegrees;
        double rotationDegrees;
        bool rotatable = true;
        SpaceshipRotation rotator;
        Mock<IVector> vectorMock;

        [Given(@"космический корабль имеет угол наклона (.*) град к оси OX")]
        public void ДопустимКосмическийКорабльИмеетУголНаклона(int tiltAngle)
        {
            this.initialDegrees = tiltAngle;
        }

        [Given(@"имеет мгновенную угловую скорость (.*) град")]
        public void ИИмеетМгновеннуюСкорость(int angularSpeed)
        {
            this.rotationDegrees = angularSpeed;
        }

        [Given(@"космический корабль, угол наклона которого невозможно определить")]
        public void ДопустимУголКорабляОпределитьНевозможно()
        {
            this.initialDegrees = double.NaN;
        }
    
        [Given(@"мгновенную угловую скорость невозможно определить")]
        public void ДопустимМгновеннуюУгловуюСкоростьНевозможноОпределить()
        {
            this.rotationDegrees = double.NaN;
        }

        [Given(@"невозможно изменить угол наклона к оси OX космического корабля")]
        public void ДопустимНевозможноИзменитьУголНаклонаКОсиOXКосмическогоКорабля()
        {
            this.rotatable = false;
        }

        [When(@"происходит вращение вокруг собственной оси")]
        public void ПроисходитВращениеВокругСобственнойОси()
        {
            try{
            vectorMock = new Mock<IVector>();
            vectorMock.SetupSet(v => v.Angle = It.IsAny<double>());
            vectorMock.Setup(v => v.Rotate(It.IsAny<double>()));

            rotator = new SpaceshipRotator(vectorMock.Object);
            }
            catch{}
        }

        [Then(@"угол наклона космического корабля к оси OX составляет (.*) град")]
        public void УголНаклонаКосмическогоКорабляКОсиOXСоставляет(int expectedTiltAngle)
        {
            rotator.RotateSpaceship(initialDegrees, rotationDegrees, rotatable);
            vectorMock.VerifySet(v => v.Angle = initialDegrees, Times.Once);
            vectorMock.Verify(v => v.Rotate(rotationDegrees), Times.Once);
        }

        [Then(@"возникает ошибка Exception")]
            public void ТоВозникаетОшибкаException()
            {
                 Assert.Throws<Exception>(() => rotator.RotateSpaceship(initialDegrees, rotationDegrees, rotatable));
            }  
        }
}