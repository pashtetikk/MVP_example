using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MVP_example
{
    internal class Robot : FieldObj
    {
        public const float baseLinSpd = 100;
        public const float baseAngSpd = baseLinSpd * 0.1f;         //Зададим скорости робота

        public Robot()
            : base(new Vector2(0,0), 0, Shapes.ROBOT, 10, true)     //Передача параметров в конструктор базового класса
        {
        }

        public Robot(Vector2 center, float alpha, float rad)
            :base(center, alpha, Shapes.ROBOT, rad, true)       
        {
        }

        public Robot(float _x, float _y, float _alpha, float _rad)
            : base(_x, _y, _alpha, Shapes.TRIANGLGE, _rad, true)
        {
        }
        public void Handler() { }


    }
}
