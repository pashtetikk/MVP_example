using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MVP_example
{
    internal class Physics
    {
        public static void calcMovement(Robot _robot, float dT)
        {
            float _alpha = _robot.Alpha;            //Создаем переменную для хранения угла
            _alpha += _robot.Speed.Y * dT;          //Расчитываем новый угол робота 
                                                    //через интегрирование угловой скорости 
                                                    //В векторе Speed у робота
                                                    //X - линейная скорость; Y - Угловая
            _alpha = limAngle(_alpha);

            Vector2 _center = _robot.Center;        //Расчитываем новое положение центра робота
            _center.X += (float)Math.Cos(_alpha) * _robot.Speed.X * dT;
            _center.Y += (float)Math.Sin(_alpha) * _robot.Speed.X * dT;

            _robot.MoveTo(_center, _alpha);         //Передвигаем робот в новое положение

        }

        public static float limAngle(float ang)     //Функция для ограничения угла в пределах [-Pi; Pi]
        {
            while(ang > Math.PI)
            {
                ang -= (float)(2 * Math.PI);
            }
            while (ang < -Math.PI)
            {
                ang += (float)(2 * Math.PI);
            }
            return ang;
        }

        public static Matrix3x2 roboToBaseM(Robot robot)
        {
            return new Matrix3x2((float)Math.Cos(robot.Alpha), (float)Math.Sin(robot.Alpha),
                                            -(float)Math.Sin(robot.Alpha), (float)Math.Cos(robot.Alpha),
                                             robot.Center.X, robot.Center.Y);

        }
    }
}
