using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Registros
{

    class StringInt {

 
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public StringInt(string Nombre, int Edad){
            this.Nombre = Nombre.ToUpper();
            this.Edad = Edad;
        }
    }


    class Program{

        static void Main(string[] args){


            Console.WriteLine("Buen día" + Environment.NewLine + "Para ingresar datos por archivo presion 1, manual presione 2:");
            int Selección = int.Parse(Console.ReadLine());

            if (Selección == 0 || Selección > 2)
                System.Environment.Exit(0);

            else if (Selección == 1){

                using (StreamReader leer = new StreamReader(@"C:\Users\LENOVO\Documents\Programas\Registros.txt")){

                    string x = leer.ReadLine(), Registro = " ", Nombre = " ";
                    int Edad = 0;

                    string[] ListaRegistro = new string[2];
                    List<StringInt> Nomdad = new List<StringInt>();
                    StringInt temp;
                

                    for (int i = 0; i < int.Parse(x); i++){

                        Registro = leer.ReadLine();
                        ListaRegistro = Registro.Split(' ');

                        Nombre = (ListaRegistro[0]);
                        Edad = int.Parse(ListaRegistro[1]);

                        temp = new StringInt(Nombre, Edad);

                        Nomdad.Add(temp);
                    }
                    Sanco(Nomdad);
                }
            }

            else if (Selección == 2){

                int n;
                Console.WriteLine("¿Cuantos nombre quiere almacenar?");
                n = int.Parse(Console.ReadLine());

                List<StringInt> Nomdad = new List<StringInt>();

                string Registro = " ";
                string Nombre = " ";
                int Edad = 0;
                string[] ListaRegistro = new string[2];

                StringInt temp;

                for (int i = 0; i < n; i++){
                    Console.WriteLine("Ingrese el nombre y la edad");
                    Registro = Console.ReadLine();
                    ListaRegistro = Registro.Split(' ');

                    Nombre = (ListaRegistro[0]);

                    Edad = int.Parse(ListaRegistro[1]);
                    temp = new StringInt(Nombre, Edad);

                    Nomdad.Add(temp);
                }
                Sanco(Nomdad);
            }
        }

        public static void Sanco(List<StringInt> NomdadSanco) {

            char[] abc = new char[] { 'A' , 'B' , 'C' , 'D' , 'E' , 'F' , 'G' , 'H' , 'I' , 'J' , 'K' , 'L' ,
                        'M' , 'N' , 'Ñ' , 'O' , 'P' , 'Q' , 'R' , 'S' , 'T', 'U' , 'V' , 'W' , 'X' , 'Y' , 'Z'};
            int[] Contador = new int[27];
            
            for (int i = 0; i < Contador.Length; i++)
                Contador[i] = 0;
            foreach (StringInt a in NomdadSanco)
            {
                foreach (char b in a.Nombre)
                {
                    if (abc.Contains(b)){
                        int index = Array.FindIndex(abc, (letter) => letter == b);
                        Contador[index] += 1;
                    }
                }
                Console.WriteLine("Nombre: " + a.Nombre + "\nEdad: " + a.Edad + "\n---");
            }
            int max = 0, indece = 0;
            for (int i = 0; i < Contador.Length; i++)
            {
                if (Contador[i] > max){
                    max = Contador[i];
                    indece = i;
                }
            }

            float promedio = 0;
            foreach (StringInt c in NomdadSanco){

                promedio += c.Edad; // => promedio=promedio+c.Edad;
            }
                promedio /= NomdadSanco.Count; // => promedio=promedio/x;

            Console.WriteLine("La letra con mayor repetición es: " + abc[indece]);
            Console.WriteLine("Y el promedio de las edades es: " + promedio);

            Console.ReadKey();
            
        }
       
    }
}
