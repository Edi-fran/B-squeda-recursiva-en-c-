using System;

class Nodo
{
    private string titulo;
    private Nodo izquierdo;
    private Nodo derecho;


    public Nodo(string titulo)
    {
        this.titulo = titulo;
        izquierdo = null;
        derecho = null;
    }

   
    public string Get_Titulo()
    {
        return titulo;
    }

    public void Set_Titulo(string titulo)
    {
        this.titulo = titulo;
    }

    public Nodo Get_Izquierdo()
    {
        return izquierdo;
    }

    public void Set_Izquierdo(Nodo izquierdo)
    {
        this.izquierdo = izquierdo;
    }

    public Nodo Get_Derecho()
    {
        return derecho;
    }

    public void Set_Derecho(Nodo derecho)
    {
        this.derecho = derecho;
    }
}

class Arbol_Revistas
{
    private Nodo raiz;

    public Arbol_Revistas()
    {
        raiz = null;
    }

    public void Insertar(string titulo)
    {
        raiz = Insertar_Recursivo(raiz, titulo);
    }

    private Nodo Insertar_Recursivo(Nodo nodo, string titulo)
    {
        if (nodo == null)
        {
            return new Nodo(titulo);
        }

        if (string.Compare(titulo, nodo.Get_Titulo(), StringComparison.OrdinalIgnoreCase) < 0)
        {
            nodo.Set_Izquierdo(Insertar_Recursivo(nodo.Get_Izquierdo(), titulo));
        }
        else if (string.Compare(titulo, nodo.Get_Titulo(), StringComparison.OrdinalIgnoreCase) > 0)
        {
            nodo.Set_Derecho(Insertar_Recursivo(nodo.Get_Derecho(), titulo));
        }

        return nodo;
    }

    public bool Buscar_Recursivo(string titulo)
    {
        return Buscar_Nodo(raiz, titulo);
    }

    private bool Buscar_Nodo(Nodo nodo, string titulo)
    {
        if (nodo == null)
            return false;

        if (titulo.Equals(nodo.Get_Titulo(), StringComparison.OrdinalIgnoreCase))
            return true;

        if (string.Compare(titulo, nodo.Get_Titulo(), StringComparison.OrdinalIgnoreCase) < 0)
            return Buscar_Nodo(nodo.Get_Izquierdo(), titulo);
        else
            return Buscar_Nodo(nodo.Get_Derecho(), titulo);
    }
}

class Catalogo_Revistas
{
    private Arbol_Revistas catalogo;


    public Catalogo_Revistas()
    {
        catalogo = new Arbol_Revistas();
    }

    public void Agregar_Titulo(string titulo)
    {
        catalogo.Insertar(titulo);
    }

    public bool Existe_Titulo(string titulo)
    {
        return catalogo.Buscar_Recursivo(titulo);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Catalogo_Revistas catalogo = new Catalogo_Revistas();

        Console.WriteLine("//////////////CATALOGO DE REVISTAS//////////////////\n");
        Console.WriteLine("**************UEA**************");
        Console.WriteLine("INGEENIERIA EN TECNOLOGIAS DE LA INFORMACION");

        // Ingreso de 10 títulos de revistas
        for (int i = 1; i <= 10; i++)
        {
            Console.Write($"Ingrese el título de la revista #{i}: ");
            string titulo = Console.ReadLine();
            catalogo.Agregar_Titulo(titulo);
        }

        string opcion;

        do
        {
            Console.WriteLine("\n*********** MENU DE BUSSQUEDA ***********************");
            Console.WriteLine("1. Buscar un título");
            Console.WriteLine("2. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese título a buscar: ");
                    string titulo_Busqueda = Console.ReadLine();

                    bool encontrado = catalogo.Existe_Titulo(titulo_Busqueda);
                    Console.WriteLine(encontrado ? " Encontrado" : " No encontrado");
                    break;

                case "2":
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine(" Opción inválida. Intente nuevamente.");
                    break;
            }
        }
        while (opcion != "2");
    }
}
