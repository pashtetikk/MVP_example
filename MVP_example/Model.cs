using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MVP_example
{
    internal class Model
    {
        Field field;
        public Model()
        {
            field = new Field();
        }
        public void updateModel()
        {
            field.updateField();
        }
        public void setRobotSpd(Vector2 _spds)          //Задать роботу скорость
        {
            field.robot.Speed = _spds;
        }

        public Vector2 RobotBaseSpds                    //Узнать, с какой скоростью может двигаться робот
        {
            get => new Vector2(Robot.baseLinSpd, Robot.baseAngSpd);
        }

        public void addRoundObs(Vector2 center, int rad)      //Функция для добавления круглого препядствия 
                                                              //на поле
        {
            field.obses.Add(new Obstacle(center, 0, FieldObj.Shapes.ROUND, (float)rad));
        }

        public List<Obstacle> Obses {get=>field.obses;}

        public Robot Robot { get => field.robot; }
    }
}
