using System;
using TechTalk.SpecFlow;
using System.Numerics;

using Movement;

namespace Tests
{
    [Binding]
    public class StepDefinitions
    {
        Move move = new Move();
        
        double[] initial_coordinates, speed;
        bool exception = true;

        [Given(@"космический корабль находится в точке пространства с координатами \((.*), (.*)\)")]
        public void ДопустимКосмическийКорабльНаходитсяВТочкеПространстваСКоординатами(double p0, double p1)
        {
            initial_coordinates = new double[] { p0, p1 };
            move = new Move(initial_coordinates);
        }

        [Given(@"имеет мгновенную скорость \((.*), (.*)\)")]
        public void ИИмеетМгновеннуюСкорость(double p0, double p1)
        {
            speed = new double[] { p0, p1 };
        }

        [Given(@"скорость корабля определить невозможно")]
        public void ДопустимСкоростьКорабляОпределитьНевозможно()
        {
            exception = false;
        }
    
        [Given(@"изменить положение в пространстве космического корабля невозможно")]
        public void ДопустимИзменитьПоложениеВПространствеКосмическогоКорабляНевозможно()
        {
            exception = false;
        }

        [Given(@"космический корабль, положение в пространстве которого невозможно определить")]
        public void ДопустимКосмическийКорабльПоложениеВПространствеКоторогоНевозможноОпределить()
        {
            exception = false;
        }

        [When(@"происходит прямолинейное равномерное движение без деформации")]
        public void ПроисходитПрямолинейноеРавномерноеДвижениеБезДеформации()
        {
            try{
            initial_coordinates = move.movement(speed, exception);
            }
            catch{}
        }

        [Then(@"космический корабль перемещается в точку пространства с координатами \((.*), (.*)\)")]
        public void КосмическийКорабльПеремещаетсяВТочкуПространстваСКоординатами(double p0, double p1)
        {
            double[] values = new double[] { p0, p1 };
            Assert.True(initial_coordinates.SequenceEqual(values));
        }

        [Then(@"возникает ошибка Exception")]
            public void ТоВозникаетОшибкаException()
            {
                Assert.Throws<System.Exception>(() => move.movement(speed, exception));
            }  
        }
}