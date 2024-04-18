using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MVP_example
{
    internal class FieldObj : ICloneable
    {
        public object Clone()
        {
            return MemberwiseClone();
        }


        public enum Shapes : int
        {
            NONE,
            ROUND,
            TRIANGLGE,
            SQUARE,
            HEXAGON,
            ROBOT,
        }

        protected Vector2 center = new Vector2(0, 0);
        protected Vector2 speed = new Vector2(0, 0);
        protected float alpha = 0;
        protected Shapes shape = Shapes.NONE;
        protected bool movable = false;
        protected float rad = 0;

        public FieldObj()
        {
        }

        public FieldObj(FieldObj obj)
        {
            this.center = obj.center;
            this.alpha = obj.alpha;
            this.shape = obj.shape;
            this.movable = obj.movable;
            this.rad = obj.rad;
        }

        //public FieldObj() { }
        public FieldObj(Vector2 _center, float _alpha, Shapes _shape, float _rad, bool _movable)
        {
            center = _center;
            alpha = _alpha;
            shape = _shape;
            rad = _rad;
            movable = _movable;
        }

        public FieldObj(float _x, float _y, float _alpha, Shapes _shape, float _rad, bool _movable)
        {
            center.X = _x;
            center.Y = _y;
            alpha = _alpha;
            shape = _shape;
            rad = _rad;
            movable = _movable;
        }

        public Vector2 Center { get => center;}
        public float Alpha { get => alpha;}
        public Shapes Shape { get => shape; }
        public float Rad { get => rad; }
        public Vector2 Speed { get => speed; set => speed = value; }

        public bool IsMovable() { return movable; }
        public void MoveTo(Vector2 _center, float _alpha)
        {
            center = _center;
            alpha = _alpha;
        }
        public void MoveTo(float _x, float _y, float _alpha)
        {
            center.X = _x;
            center.Y = _y;
            alpha = _alpha;
        }
        public void ShiftTo(float _x, float _y, float _alpha)
        {
            center.X += _x;
            center.Y += _y;
            alpha += _alpha;
        }
    }
}
