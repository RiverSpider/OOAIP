using System;
using TechTalk.SpecFlow;
using System.Numerics;

using Turning;

namespace Tests
{
    [Binding]
    public class StepDefinitions
    {
        Turn turn = new Turn();
        
        int angle;
        int[] degree = new int[2];
        bool exception = true;
        int def = 360;

        [Given(@"космический корабль имеет угол наклона (.*) град к оси OX")]
        public void ДопустимКосмическийКорабльИмеетУголНаклона(int p0)
        {
            angle = p0;
            turn = new Turn(angle);
        }

        [Given(@"имеет мгновенную угловую скорость (.*) град")]
        public void ИИмеетМгновеннуюСкорость(int p0)
        {
            degree = new int[] { p0, def };
        }

        [Given(@"космический корабль, угол наклона которого невозможно определить")]
        public void ДопустимУголКорабляОпределитьНевозможно()
        {
            exception = false;
        }
    
        [Given(@"мгновенную угловую скорость невозможно определить")]
        public void ДопустимМгновеннуюУгловуюСкоростьНевозможноОпределить()
        {
            exception = false;
        }

        [Given(@"невозможно изменить угол наклона к оси OX космического корабля")]
        public void ДопустимНевозможноИзменитьУголНаклонаКОсиOXКосмическогоКорабля()
        {
            exception = false;
        }

        [When(@"происходит вращение вокруг собственной оси")]
        public void ПроисходитВращениеВокругСобственнойОси()
        {
            try{
            angle = turn.turning(degree, exception);
            }
            catch{}
        }

        [Then(@"угол наклона космического корабля к оси OX составляет (.*) град")]
        public void УголНаклонаКосмическогоКорабляКОсиOXСоставляет(int p0)
        {
            Assert.Equal(p0, angle);
        }

        [Then(@"возникает ошибка Exception")]
            public void ТоВозникаетОшибкаException()
            {
                Assert.Throws<System.Exception>(() => turn.turning(degree, exception));
            }  
        }
}