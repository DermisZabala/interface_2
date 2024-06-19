using System;

namespace Interface_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Caballo miCaballo = new Caballo("Paso fino");
            Aguila miAguila = new Aguila("Hamel");
            Paloma miPaloma = new Paloma("PIPITA");
            Mono miMono = new Mono("Pepe");

            //Aguila
            Console.WriteLine($"Soy un aguila y {miAguila.GetNombre()}");
            miAguila.Comer();
            miAguila.Volar();
            Console.WriteLine("Puedo alcanzar una altura de " + miAguila.MetrosDeAltura() + " metros");
            Console.WriteLine("Puedo alcanzar una velocidad maxima de " + miAguila.VelocidadMaxima() + " km/h");
            Console.WriteLine();

            //Caballo
            Console.WriteLine("Soy un caballo y " + miCaballo.GetNombre());


            /* Método de sustitución 'ES-UN' para poder llamar a los métodos iguales 
            de las interfaces IMamiferosNumPatas y IPatasParaSaltar */
            IMamiferosNumPatas misPatas = miCaballo;
            IPatasParaSaltar miSalto = miCaballo;

            Console.WriteLine("Tengo " + misPatas.NumPatas() + " patas");//De esta forma puedo llamar numero de patas que tiene miCaballo

            Console.WriteLine("Utilizo " + miSalto.NumPatas() + " patas para saltar");//De esta forma puedo llamar a numero de patas que utiliza para saltar miCaballo

            miCaballo.Comer();
            miCaballo.Galopar();
            Console.WriteLine();

            //Mono
            Console.WriteLine("Soy un mono y " + miMono.GetNombre());
            miMono.Comer();


            misPatas = miMono;
            miSalto = miMono;

            Console.WriteLine("Tengo " + misPatas.NumPatas() + " patas");
            Console.WriteLine("Utilizo " + miSalto.NumPatas() + " patas para impulsar mi salto");

            miMono.Trepar();

        }
    }
    interface IAlas
    {
        int VelocidadMaxima();
        int MetrosDeAltura();
    }
    interface IMamiferosNumPatas
    {
        int NumPatas();
    }
    interface IPatasParaSaltar
    {
        int NumPatas();
    }

    class Mamifero
    {
        private string nombre;
        public Mamifero(string nombre)
        {
            this.nombre = nombre;
        }
        public void Respirar()
        {
            Console.WriteLine("Puedo respirar");
        }
        public virtual void Comer()
        {
            Console.WriteLine("Debo comer para sobrevivir");
        }

        public string GetNombre()
        {
            return "Mi nombre es " + nombre;
        }

    }
    class Caballo : Mamifero, IMamiferosNumPatas, IPatasParaSaltar
    {
        public Caballo(string nombreCaballo) : base(nombreCaballo) { }

        public override void Comer()
        {
            Console.WriteLine("Prefiero comer del pasto");
        }
        public void Galopar()
        {
            Console.WriteLine("Soy capaz de galopar");
        }
        int IPatasParaSaltar.NumPatas() //método NumPatas de la interface IPatasParaSaltar
        {
            return 2;
        }
        int IMamiferosNumPatas.NumPatas() //método NumPatas de la interface IMamiferosNumPatas
        {
            return 4;
        }
    }
    class Paloma : Mamifero, IAlas, IMamiferosNumPatas
    {
        public Paloma(string nombreGallo) : base(nombreGallo) { }

        public override void Comer()
        {
            //base.Comer();
            Console.WriteLine("Me gusta comer maíz");
        }
        public void Paz()
        {
            Console.WriteLine("Soy el símbolo de la paz");
        }
        public int MetrosDeAltura()
        {
            return 1800; //Metros
        }
        public int VelocidadMaxima()
        {
            return 95; // km/h
        }
        public int NumPatas()
        {
            return 2;
        }
    }
    class Mono : Mamifero, IMamiferosNumPatas, IPatasParaSaltar
    {
        public Mono(string nombreMono) : base(nombreMono) { }

        public override void Comer()
        {
            //base.Comer();
            Console.WriteLine("Me gusta comer banana");
        }
        public void Trepar()
        {
            Console.WriteLine("Me encanta trepar");
        }
        int IPatasParaSaltar.NumPatas()
        {
            return 2;
        }
        int IMamiferosNumPatas.NumPatas()
        {
            return 2;
        }
    }
    class Aguila : Mamifero, IMamiferosNumPatas, IAlas
    {
        public Aguila(string nombreAguila) : base(nombreAguila) { }

        public void Volar()
        {
            Console.WriteLine("Soy capaz de volar alto");
        }
        public int MetrosDeAltura()
        {
            return 4500; //Metros
        }
        public int VelocidadMaxima()
        {
            return 320; // km/h
        }
        public int NumPatas()
        {
            return 2;
        }
    }
}