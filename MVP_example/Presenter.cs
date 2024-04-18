using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVP_example
{
    internal class Presenter
    {
        private readonly View view; //Создали объект View
        private readonly Model model; //Создали объект модели


        Matrix3x2 baseToView;
        Vector2 robotTgtSpd;    //Вектор для хранения целевой скорости робота

        public Presenter()
        {
            view = new View();      // Инициализировали объекты view и model 
            model = new Model();    //  тут в объекты можно передать какие-либо параметры
                                    //  через конструкторы этих объектов

            baseToView = new Matrix3x2(1, 0,
                                       0, -1,
                                       0, view.ViewHeigh);

            robotTgtSpd = new Vector2(0, 0);    //Инициализируем вектор целевой скорости робота

            view.viewTick += redrawView;    //Записываем в делегат таймера перерисовки ссылку на функцию перерисовки
            view.tick += updateModel;
            view.addFieldObj += addFieldObj;

            view.keyDown += keyDown;    
            view.keyUp += keyUp;
        }

        public void Run()
        {
            view.Show();
        }

        public void redrawView()
        {
            Robot robot = model.Robot;
            Vector2 robotPose = Vector2.Transform(robot.Center, baseToView);        //Расчитываем положение робота в СК окна

            view.drawCurcle(new Point((int)robotPose.X, (int)robotPose.Y), (int)robot.Rad, new Pen(Color.Blue, 3)); //Отрисовываем тело робота

            Vector2 lineSP = Vector2.Transform(robot.Center, baseToView);       //Расчитываем положение центра робота в СК окна
            Vector2 lineEP = Vector2.Transform(new Vector2((int)robot.Rad, 0), Physics.roboToBaseM(robot) * baseToView);    //Расчитываем конечную точку линии
                                                                                                                            //длинной в радиус робота
            view.drawLine(new Point((int)lineSP.X, (int)lineSP.Y), new Point((int)lineEP.X, (int)lineEP.Y), new Pen(Color.Blue, 3));    //Рисуем линию


            foreach (Obstacle obs in model.Obses)
            {
                Vector2 obsPose = Vector2.Transform(obs.Center, baseToView);        //Приводим координаты центра препятсвия к СК окна
                view.drawCurcle(new Point((int)obsPose.X, (int)obsPose.Y), (int)obs.Rad, new Pen(Color.Black, 1));  //Отрисовываем препятствие 
            }
        }

        public void addFieldObj(Vector2 center, int rad, View.FieldObjType objType)
        {
            switch (objType)
            {
                case View.FieldObjType.OBSTACLE:
                    model.addRoundObs(Vector2.Transform(center, baseToView), rad);
                    break;
            }
        }

        private void keyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    robotTgtSpd.X = Robot.baseLinSpd;
                    break;
                case Keys.S:
                    robotTgtSpd.X = -Robot.baseLinSpd;
                    break;
                case Keys.A:
                    robotTgtSpd.Y = Robot.baseAngSpd;
                    break;
                case Keys.D:
                    robotTgtSpd.Y = -Robot.baseAngSpd;
                    break;
                default:
                    break;
            }
            model.setRobotSpd(robotTgtSpd);
        }

        private void keyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    robotTgtSpd.X = 0;
                    break;
                case Keys.S:
                    robotTgtSpd.X = 0;
                    break;
                case Keys.A:
                    robotTgtSpd.Y = 0;
                    break;
                case Keys.D:
                    robotTgtSpd.Y = 0;
                    break;
                default:
                    break;
            }
            model.setRobotSpd(robotTgtSpd);
        }

        public void updateModel()
        {
            model.updateModel();
        }
    }

    
}
