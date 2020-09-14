using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace LessonGB6
{
    delegate double function(double x, double a);
    delegate double funcEX2(double x);
    class Program
    {

        #region'Ex1
        static void Ex1()
        {
            Plot(g, -5, 10);
            Console.WriteLine();
            Plot(f, -5, 10);
            Console.Read();
        }
        static double f(double x, double a)
        {
            return a * x * x;

        }
        static double g(double x, double a)
        {
            return a * Math.Sin(x);

        }

        static void Plot(function f, int start, int end)
        {
            double a = 12;
            for (int x = start; x <= end; x++)
            {

                Console.WriteLine($"f({x,2}) = {f(x, a),2 }");

            }


        }
        #endregion

        #region EX2
        public static double F(double x)
        {
            return x * x * x;
        }
        public static double S(double x)
        {
            return x * x;
        }
        public static double D(double x)
        {
            return Math.Cos(x);
        }




        public static void SaveFunc(string fileName, funcEX2 f, double a, double b, double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(f(x));
                x += h;// x=x+h;
            }
            bw.Close();
            fs.Close();
        }
        public static double Load(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            double min = double.MaxValue;
            double d;
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                // Считываем значение и переходим к следующему
                d = bw.ReadDouble();
                if (d < min) min = d;
            }
            bw.Close();
            fs.Close();
            return min;


        }

        static void Ex2()
        {
            int userChoose = 0;

            List<funcEX2> functions = new List<funcEX2> { new funcEX2(F), new funcEX2(S), new funcEX2(D) };
            string func = "";
            Console.WriteLine("Даны три функции: F(x * x * x),S (x * x), D (Math.Cos(x))");
            Console.WriteLine("Введите букву, необходимой вам функции (F,S,D)");
            func = Console.ReadLine();
            if (func == "F")
                userChoose = 0;
            else if (func == "S")
                userChoose = 1;
            else if (func == "D")
                userChoose = 2;
            else
                Ex2();




            Console.WriteLine("Задайте начало отрезка (например 10,1) :");
            double a = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Задайте начало отрезка (например 100,9)");

            double b = Convert.ToDouble(Console.ReadLine());

            SaveFunc("data.bin", functions[userChoose], a, b, 0.5);
            Console.WriteLine(Load("data.bin"));
            Console.ReadKey();
        }

        #endregion

        static void Main(string[] args)
        {
          //  Ex1();
            Ex2();
        }


        

    }







    #region рубик
    //delegate void Skill();

    //class Rubick
    //{
    //    Skill spellSkill;
    //    public void SpellSteal(Skill skill)
    //    {
    //        spellSkill = skill;

    //    }

    //    public void UseSkill()
    //    {
    //        Console.Write("Rubick применяет скилл: ");
    //       // if (spellSkill!= null)      spellSkill();
    //        spellSkill?.Invoke();

    //    }
    //}


    //class Antimage
    //{
    //    public Skill LastSkill { get; set; }
    //    public void Blink()
    //    {
    //        LastSkill = Blink;
    //        Console.WriteLine("Телепортация");
    //    }
    //    public void CounterSpell()
    //    {
    //        LastSkill = CounterSpell;
    //        Console.WriteLine("CounterSpell");
    //    }
    //}
    //class WR
    //{
    //    public void PowerShot()
    //    {
    //        Console.WriteLine("Стрела");
    //    }
    //}
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Rubick rubick = new Rubick();
    //        Antimage antimage = new Antimage();
    //        WR wr = new WR();

    //        antimage.Blink();
    //        wr.PowerShot();

    //        rubick.SpellSteal(antimage.Blink);
    //        rubick.UseSkill();

    //        Console.Read();
    //    }
    //}
    #endregion
}
