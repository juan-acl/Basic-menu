using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio1_Programacion_Modular
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }
        static void Menu()
        {
            Console.Clear();
            int opInput;
            Console.WriteLine("-----Menu de opciones-----");
            Console.WriteLine("Ingrese el numero de la opcion que desea ejecutar.");
            Console.WriteLine("1. Verificar si un año es bisiesto.");
            Console.WriteLine("2. Calculo de cuota laboral.");
            Console.WriteLine("3. Numero intermedio.");
            Console.WriteLine("4. Formula de combinacion.");
            Console.WriteLine("5. Numero de billetes por una cantidad ingresada.");
            Console.WriteLine("6. Clasificacion por edades.");
            Console.WriteLine("7. Calculo de salario.");
            Console.WriteLine("8. Resulucion de sumatoria sigma.");
            Console.WriteLine("9. Ganador del partido.");
            Console.WriteLine("10. Tabla de multiplicar.");
            Console.WriteLine("11. Numero perfecto.");
            Console.WriteLine("12. Dia de la semana.");
            Console.WriteLine("13. Serie de Fibonacci.");
            Console.WriteLine("14. Formula.");
            Console.WriteLine("15. Numero positivo/negativo/nulo.");
            Console.WriteLine("0. Salir.");
            try
            {
                opInput = int.Parse(Console.ReadLine());
                string textoValidate = ValidOpcion(opInput);
                if (textoValidate == "La opcion no es valida")
                {
                    Console.Clear();
                    Console.WriteLine(textoValidate);
                    Console.ReadKey();
                    Menu();
                }

                Dictionary<int, Action> mapOp = new Dictionary<int, Action>();
                mapOp[0] = Exit;
                mapOp[1] = LeapYear;
                mapOp[2] = Quotas;
                mapOp[3] = IntermediateNumber;
                mapOp[4] = CombinationFormula;
                mapOp[5] = BillsNumber;
                mapOp[6] = Ine;
                mapOp[7] = Salary;
                mapOp[8] = Sigma;
                mapOp[9] = Winner;
                mapOp[10] = TableMultiplication;
                mapOp[11] = PerfectNumber;
                mapOp[12] = Week;
                mapOp[13] = Fibonnacci;
                mapOp[14] = FormulaResolucion;
                mapOp[15] = TypeNumber;
                mapOp[opInput]();
                if (opInput != 0) Menu();
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine("Ingrese un valor numerico.");
                Console.ReadKey();
                Menu();
            }
        }
        static void LeapYear()
        {
            // ? Verificacion del año bisiesto por formula
            Console.Clear();
            Console.WriteLine("-----Verificacion de un año bisiesto-----");
            int year;
            int yearbk;
            Console.WriteLine("Ingrese el año que desea verificar");
            year = int.Parse(Console.ReadLine());
            //if (year % 4 == 0 && year % 100 != 0 || year % 400 == 0) Console.WriteLine("El año " + year + " es bisiesto");
            //else Console.WriteLine("El año " + year + " no es bisiesto");
            // ? Verificacion del año bisiesto por metodo de DateTime
            yearbk = year;
            year = DateTime.IsLeapYear(year) ? 29 : 28;
            if (year == 29) Console.WriteLine("El año " + yearbk + " es bisiesto");
            else Console.WriteLine("El año " + yearbk + " no es bisiesto");
            Console.ReadKey();
        }
        static void Quotas ()
        {
            Console.Clear();
            Console.WriteLine("----Calculo de cuotas laborales-----");
            double salary;
            double laboralQuota;
            double employerFee; // Cuota patronal
            double liquidSalary;
            Console.WriteLine("Ingrese el salario del trabajador");
            salary = double.Parse(Console.ReadLine());
            laboralQuota = LaborQuotas(salary);
            employerFee = EmployerQuotas(salary);
            liquidSalary = LiquidSalary(salary, laboralQuota, employerFee);
            Console.WriteLine("Cuota laboral: Q " + laboralQuota);
            Console.WriteLine("Cuota patronal: Q " + employerFee);
            Console.WriteLine("El salario liquido del colaborador es de: Q " + liquidSalary);
            Console.ReadKey();
        }
        static double LaborQuotas(double salary)
        {
            return salary * 0.0483;
        }
        static double EmployerQuotas(double salary)
        {
            return salary * 0.01;
        }
        static double LiquidSalary(double salary, double laboralQuota, double employerFree)
        {
            return salary - (laboralQuota + employerFree);
        }
        static void IntermediateNumber ()
        {
            Console.Clear();
            Console.WriteLine("------Numero intermedio-----");
            int num1, num2, num3;
            Console.WriteLine("Ingrese el primer numero entero");
            num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el segundo numero entero");
            num2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el tercer numero entero");
            num3 = int.Parse(Console.ReadLine());
            int[] arrayNumbers = { num1, num2, num3 }; // Creamos un array
            Array.Sort<int>(arrayNumbers); // Ordenamos el array
            Console.WriteLine("El numero intermedio es: " + arrayNumbers[1]);
            Console.ReadKey();
        }
        static void CombinationFormula ()
        {
            Console.Clear();
            Console.WriteLine("-----Formula de combinatoria-----");
            int n, r, result;
            Console.WriteLine("Ingrese el valor de n");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el valor de r");
            r = int.Parse(Console.ReadLine());
            result = Factorial(n) / Factorial(r) * Factorial(n-r);
            Console.WriteLine("El resultado de la combinatoria es: " + result);
            Console.ReadKey();
        }
        static int Factorial(int x)
        {
            int acc = 1;
            for (int i = x; i>=1; i--)
            {
                acc *= i;
            }
            return acc;
        }
        static void BillsNumber()
        {
            Console.Clear();
            Console.WriteLine("-----Numero de billetes-----");
            int amount, bill1 = 0, bill2 = 0, bill3 = 0, bill4 = 0, bill5 = 0, bill6 = 0;
            Console.WriteLine("Ingrese la cantidad de dinero expresada en quetzales");
            amount = int.Parse(Console.ReadLine());
                bill1 = Bills(amount, 100);
                amount = amount - (bill1 * 100);

                bill2 = Bills(amount, 50);
                amount = amount - (bill2 * 50);

                bill3 = Bills(amount, 20);
                amount = amount - (bill3 * 20);
 
                bill4 = Bills(amount, 10);
                amount = amount - (bill4 * 10);

                bill5 = Bills(amount, 5);
                amount = amount - (bill5 * 5);

                bill6 = Bills(amount, 1);
                amount = amount - (bill6 * 1);
        
            Console.WriteLine("Billetes de 100: " + bill1);
            Console.WriteLine("Billetes de 50: " + bill2);
            Console.WriteLine("Billetes de 20: " + bill3);
            Console.WriteLine("Billetes de 10: " + bill4);
            Console.WriteLine("Billetes de 5: " + bill5);
            Console.WriteLine("Billetes de 1: " + bill6);
            Console.ReadKey();
        }
        static int Bills(int amount, int bill)
        {
            return amount / bill;
        }
        static void Ine ()
        {
            Console.Clear();
            Console.WriteLine("-----Clasificacion de INE-----");
            Console.WriteLine("Ingrese la edad del ciudadano");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine(Ine(age));
            Console.ReadKey();
        }
        static string Ine (int age)
        {
            string ine = "";
            if(age < 5)
            {
                ine = "El ciudadano es un bebe";
            }else if(age >= 6 && age <= 12)
            {
                ine = "El ciudadano es un niño";
            }else if(age >= 13 && age <=17)
            {
                ine = "El ciudadano es un adolescente";
            }else if(age >= 18 && age <= 50)
            {
                ine = "El ciudadano es un adulto";
            }else if(age >= 51 && age <= 100)
            {
                ine = "El ciudadano es un adulto mayor";
            }
            return ine;
        }
        static void Salary ()
        {
            Console.Clear();
            Console.WriteLine("-----Calculo de salario-----");
            double salaryByDay= 0, hours = 0, hoursPay = 0;
            string name = "";
            Console.WriteLine("Ingrese el nombre del trabajador");
            name = Console.ReadLine();
            Console.WriteLine("Ingrese las horas trabajadas");
            hours = double.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el salario por hora");
            hoursPay = double.Parse(Console.ReadLine());
            if(hours > 8)
            {
                salaryByDay = (hours - 8) * (hoursPay * 1.5) + (8 * hoursPay);
            }
            else
            {
                salaryByDay = hours * hoursPay;
            }
            Console.WriteLine("El salario de " + name + " es de: Q " + salaryByDay);
            Console.ReadKey();
        }
        static void Sigma ()
        {
            Console.Clear();
            Console.WriteLine("-----Sumatoria de sigma-----");
            double result = 0;
            for(double i =1; i<=4; i++)
            {
                result += (1 / (i * (i + 2)));
            } 
            Console.WriteLine("El resultado de la sumatoria es: " + result);
            Console.ReadKey();
        }
        static void Winner()
        {
            Console.Clear();
            Console.WriteLine("-----Ganador del partido-----");
            string team1 = "", team2 = "";
            int score1 = 0, score2 = 0;
            Console.WriteLine("Ingrese el nombre del primer equipo");
            team1 = Console.ReadLine();
            Console.WriteLine("Ingrese el nombre del segundo equipo");
            team2 = Console.ReadLine();
            Console.WriteLine("Ingrese el marcador del primer equipo");
            score1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el marcador del segundo equipo");
            score2 = int.Parse(Console.ReadLine());
            if(score1 > score2)
            {
                Console.WriteLine("El equipo ganador es: " + team1);
            }else if(score1 < score2)
            {
                Console.WriteLine("El equipo ganador es: " + team2);
            }
            else
            {
                Console.WriteLine("El partido termino en empate");
            }
            Console.ReadKey();
        }
        static void TableMultiplication()
        {
            Console.Clear();
            Console.WriteLine("-----Tabla de multiplicar-----");
            for(int i = 1; i<=10; i++)
            {
                for (int j = 1; j<=10; j++)
                {
                    Console.Write(i + " X " + j + " = " + (i * j) + "\t");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        static void PerfectNumber()
        {
            Console.Clear();
            Console.WriteLine("-----Numero perfecto-----");
            int number, total;
            Console.WriteLine("Ingrese el numero que desea verificar");
            number = int.Parse(Console.ReadLine());
            int[] divisors = new int[number];

            // ? El continue se salta el resto de codigo dentro del bucle pero sigue con el ciclo
            // ? El break cuando se cumpla la condicion ya no sigue con el resto del codigo y se sale del ciclo
            for (int i = 1; i<number; i++)
            {
                if(number % i == 0)
                {
                    divisors[i] = i;
                    continue;
                }
            }
            total = divisors.Sum();
            if(total == number) Console.WriteLine("El numero " + number + " es perfecto");
            else Console.WriteLine("El numero " + number + " no es perfecto");
            Console.ReadKey();
        }
        static void Week ()
        {
            Console.Clear();
            Console.WriteLine("-----Dia de la semana-----");
            Console.WriteLine("Ingrese el numero del dia de la semana");
            int dayNum = int.Parse(Console.ReadLine());
            Console.WriteLine("El dia correspondiente al numero " + dayNum + " " + DayForWeek(dayNum));
            Console.ReadKey();
        }
        static string DayForWeek(int dayNum)
        {
            Dictionary<int, string> day = new Dictionary<int, string>();
            day[1] = "Lunes";
            day[2] = "Martes";
            day[3] = "Miercoles";
            day[4] = "Jueves";
            day[5] = "Viernes";
            day[6] = "Sabado";
            day[7] = "Domingo";
            return day[dayNum];
        }
        static void Fibonnacci()
        {
            Console.Clear();
            Console.WriteLine("-----Serie de Fibonacci-----");
            Console.WriteLine("Ingrese el numero de elementos que desea ver");
            int n = int.Parse(Console.ReadLine());
            int n1 = 0, n2 = 1, n3;
            if (n == 0 || n == 1) Console.Write("0 ");
            else
            {
                Console.Write("0 1 ");
                for (int i = 0; i < n-2; i++)
                {
                    n3 = n1 + n2;
                    Console.Write(n3 + " ");
                    n1 = n2;
                    n2 = n3;
                }
            }
            Console.ReadKey();
        }
        static void FormulaResolucion()
        {
            Console.Clear();
            Console.WriteLine("-----Resolucion de formula-----");
            Console.WriteLine("Ingrese el valor de r");
            int r = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el valor de n");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el valor de P");
            int p = int.Parse(Console.ReadLine());
            Console.WriteLine("El resultado de la formula es: " + Formula(r, n, p));
            Console.ReadKey();
        }
        static int Formula(int r, int n, int p)
        {
            double first = 1 + r;
            double numerador = r * (Math.Pow(first, n));
            double denominador = Math.Pow(first, n) - 1;
            double A = (numerador / denominador) * p;
            return (int)A;

        }
        static void TypeNumber()
        {
            Console.Clear();
            Console.WriteLine("-----Numeros positivos/enteros/nulo-----");
            Console.WriteLine("Ingrese un numero entero");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(Type(number));
            Console.ReadKey();

        }
        static string Type(int number)
        {
            int numero = Math.Sign(number);
            string texto = "";
            if (numero == 1) texto = "El numero es positivo";
            else if(numero == 0) texto = "El numero es nulo";
            else texto = "El numero es negativo";
            return texto;
        }
        static string ValidOpcion (int op)
        {
            int[] opciones = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            string texto = "";
            if (opciones.Contains(op)) texto = "La opcion es valida";
            else texto = "La opcion no es valida";
            return texto;
        }
        static void Exit()
        {
            Console.Clear();
            Console.WriteLine("Gracias por utilizar el programa");
            Console.ReadKey();
        }
    }
}
