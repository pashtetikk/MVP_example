using System.Numerics;
using static MVP_example.View;

namespace MVP_example
{
    public partial class View : Form
    {
        Graphics g;             //Объект рисования
        Bitmap fieldBM;         //Объект, куда рисуем
        Random random;

        public enum FieldObjType    //Перечисление возможных объектов на поле
        {
            OBSTACLE,               //Препятствие
            TGT_POINT,              //Целевая точка движеняи робота
        }

        public View()
        {
            InitializeComponent();
            fieldBM = new Bitmap(fieldView.Width, fieldView.Height);    //Инициализируем объект Bitmap размером
                                                                        //с область рисования
            g = Graphics.FromImage(fieldBM);                            //Инициализируем объект графики
            random = new Random();  
        }

        public new void Show()
        {
            Application.Run(this);
        }

        public void drawCurcle(Point center, int rad, Pen pen)
        {
            g.DrawEllipse(pen, center.X - rad, center.Y - rad, 2 * rad, 2 * rad);
        }

        public void drawLine(Point beginPt, Point endPt, Pen pen)
        {
            g.DrawLine(pen, beginPt, endPt);
        }

        private void fieldView_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:                                    //Проверяем что нажата именно левая кнопка мыши
                    addFieldObj(new Vector2(e.X, e.Y), random.Next(3, 40), FieldObjType.OBSTACLE);  //Вызываем ивент добавления объекта
                    break;
                default:
                    break;
            }
        }

        private void fieldView_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void fieldView_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void modelTim_Tick(object sender, EventArgs e)
        {
            tick(); //Вызов евента обновления модели
        }

        private void viewTim_Tick(object sender, EventArgs e)
        {
            g.Clear(Color.White);               //Очищаем поле
            viewTick();                         //Вызываем евент отрисовки в презентере
            fieldView.Image = fieldBM;          //Выводим нарисованное на экран
        }

        public delegate void modelTickContainer();
        public event modelTickContainer tick;

        public delegate void AddFieldObj(Vector2 center, int rad, FieldObjType objType);
        public event AddFieldObj addFieldObj;

        public delegate void viewTickContainer();
        public event viewTickContainer viewTick;

        public delegate void KeyDownContainer(object sender, KeyEventArgs e);
        public event KeyDownContainer keyDown;
        public delegate void KeyUpContainer(object sender, KeyEventArgs e);
        public event KeyUpContainer keyUp;


        public float ViewHeigh
        {
            get { return this.fieldView.Height; }
        }

        public float ViewWidth
        {
            get { return this.fieldView.Width; }
        }

        private void View_KeyDown(object sender, KeyEventArgs e)
        {
            keyDown(sender, e);
        }

        private void View_KeyUp(object sender, KeyEventArgs e)
        {
            keyUp(sender, e);
        }
    }
}