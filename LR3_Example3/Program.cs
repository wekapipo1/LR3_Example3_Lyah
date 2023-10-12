using System;
class Transport
{
    //поля
    protected double l; //пробіг
    protected bool spravka; //наявність техогляду
    //конструктор з параметрами
    public Transport(double x, bool y)
    {
        this.l = x; this.spravka = y;
    }
    //dL відстань, яку потрібно проїхати
    //вертає true та збільшувальний загальний пробіг,
    //якщо є справка  про техогляд
    //та false, якщо немає справки
    public bool Move(double dL)
    {
        bool f = false;
        if (spravka) { l = l + dL; f = true; } 
        return f;
    }
    public string ToStr()
    {
        string s = "Загальний пробiг = " + l;
        return s;
    }
}
class Car : Transport
{
    //поля
    double RT; //розхід палива (л/км)
    double VB; //об'єм бензину в баці
    //конструктор з параметрами
    //перші два параметра з конструктора базового класу
    public Car(double x, bool y, double rt, double vb) : base(x, y)
    {
        this.RT = rt; this.VB = vb;
    }
    //парамметр х - відстань, яку потрібно проїхати
    //вертає true та змінює об'єм бензину в баці,
    //якщо бензину досить, та false, якщо бензину не достатньо
    public bool Change(double x)
    {
        bool p = false;
        double b = x * RT;
        if (VB - b >= 0) { VB=VB-b; p = true; }
        return p;
    }
    //перевизначуваний метод,
    //вертає інформацію про стан об'єкту після поїздки
    new public string ToStr()
    {
        string s = "Загальний пробiг = " + l + "; залишилось бензину = " + VB + ";";
        return s;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Random o = new Random();
        Console.WriteLine("Для автомобiля");
        double rast = o.Next(100, 500);
        Console.WriteLine("вiдстань = {0}", rast);
        double pr = o.Next(1000, 2000);
        Console.WriteLine("початковий пробiг = {0}", pr);
        double rtop = o.Next(1, 3) / 10.0;
        Console.WriteLine("розхiд топлива (л/км) = {0}", rtop);
        double vben = o.Next(50, 80);
        Console.WriteLine("об'єм бензину в бацi = {0}", vben);
        bool sp = true;
        int p = o.Next(0, 2);
        if (p == 0) sp = false;
        //створення об'єкту c
        Car c = new Car(pr, sp, rtop, vben);
        if (!c.Move(rast)) Console.WriteLine("Поїздка неможлива, техогляд не пройшов");
        else
             if (!c.Change(rast)) Console.WriteLine("Поїздка неможлива, бензина не достатньо");
        else
            //стан об'єкту після поїздки
            Console.WriteLine(c.ToStr());
    }
}