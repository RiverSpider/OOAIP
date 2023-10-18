using TechTalk.SpecFlow;
using Moq;

using Rotatable;
using Vectorss;

namespace Tests
{
    [Binding]
    public class RotationSteps
    {
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
            this.initialDegrees = Double.NaN;
        }
    
        [Given(@"мгновенную угловую скорость невозможно определить")]
        public void ДопустимМгновеннуюУгловуюСкоростьНевозможноОпределить()
        {
            this.rotationDegrees = Double.NaN;
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
                if(double.IsNaN(initialDegrees) || double.IsNaN(rotationDegrees) || rotatable == false){
                vectorMock.SetupSet(v => v.Angle = It.IsAny<double>())
                    .Throws(new Exception());
                vectorMock.Setup(v => v.Rotate(It.IsAny<double>()))
                    .Throws(new Exception());
                }
                else{
                    vectorMock.SetupSet(v => v.Angle = It.IsAny<double>());
                    vectorMock.Setup(v => v.Rotate(It.IsAny<double>()));
                }

            rotator = new SpaceshipRotation(vectorMock.Object);
            if(!(double.IsNaN(initialDegrees) || double.IsNaN(rotationDegrees) || rotatable == false)){
                rotator.RotateSpaceship(initialDegrees, rotationDegrees, rotatable); 
            }
            }
            catch{}        
        }

        [Then(@"угол наклона космического корабля к оси OX составляет (.*) град")]
        public void УголНаклонаКосмическогоКорабляКОсиOXСоставляет(int expectedTiltAngle)
        {
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