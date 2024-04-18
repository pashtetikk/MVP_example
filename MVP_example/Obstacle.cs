using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MVP_example
{
    internal class Obstacle : FieldObj
    {
        public Obstacle() { }
        public Obstacle(Vector2 _center, float _alpha, Shapes _shape, float _rad)
            : base(_center, _alpha, _shape, _rad, false)
        {

        }

        public Obstacle(float _x, float _y, float _alpha, Shapes _shape, float _rad)
            : base(_x, _y, _alpha, _shape, _rad, false)
        {

        }
    }
}
