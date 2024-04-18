using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MVP_example
{
    internal class Field
    {
        public Robot robot;                //Создаем объект робота
        public List<Obstacle> obses;       //Массив препятсивий на поле

        int width, height;
        float dT = 0.01f;                   //Состояние модели обновляется раз в 10мс
        public Field()
        {
            robot = new Robot(new Vector2(0, 0), 0, 20);    //Создаем робота в точке (0;0),
                                                            //направленного по оси X (угол alpha = 0)
                                                            //c радиусом модельки в 10 
            
            obses = new List<Obstacle>();                   //Инициализируем массив препятсивий
        }

        public void updateField()                           //Функция, в которой будет происходить
                                                            //расчет физики, лидара, автопилота,
                                                            //и всего, что должно переодически пересчитываться
        {
            Physics.calcMovement(robot, dT);                //Расчет перемещения робота на основе его скорости
        }
        
    }
}
