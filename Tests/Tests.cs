using System;
using TechTalk.SpecFlow;
using System.Numerics;

using Movement;
using Vectors;

namespace Tests
{
    [Binding]
    public class StepDefinitions
    {
        Move move;
        Coordinates position = new Coordinates();
        
        bool exception = true;

        [Given(@"космический корабль находится в точке пространства с координатами \((.*), (.*)\)")]
        public void ДопустимКосмическийКорабльНаходитсяВТочкеПространстваСКоординатами(int p0, int p1)
        {
            position.Position = new Vectors.Vector(new int[] { p0, p1 });
        }

        [Given(@"имеет мгновенную скорость \((.*), (.*)\)")]
        public void ИИмеетМгновеннуюСкорость(int p0, int p1)
        {
            position.Velocity = new Vectors.Vector(new int[] { p0, p1 });
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
                move = new Move(position);
                move.movement(exception);
            }
            catch{}
        }

        [Then(@"космический корабль перемещается в точку пространства с координатами \((.*), (.*)\)")]
        public void КосмическийКорабльПеремещаетсяВТочкуПространстваСКоординатами(int p0, int p1)
        {
            //IPosition values new IPosition();
            int[] values = new int[] { p0, p1 };
            Assert.Equal(values, move.getPosition().getVector());
        }

        [Then(@"возникает ошибка Exception")]
            public void ТоВозникаетОшибкаException()
            {
                Assert.Throws<System.Exception>(() => move.movement(exception));
            }  
        }
}