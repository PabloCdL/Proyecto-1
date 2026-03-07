using System.Collections.Concurrent;

int opcion;
do
{
    Console.WriteLine("1. Nuevo contenido");
    Console.WriteLine("2. Reglas del sistema");
    Console.WriteLine("3. Estadisticas de la sesión");
    Console.WriteLine("4. Reinicar estadisticas");
    Console.WriteLine("5. Salir");
    opcion = int.Parse(Console.ReadLine());
    switch (opcion)
    {
        case 1:
            Console.WriteLine("Caso1");
            break;
        case 2:
            Console.WriteLine("Caso2");
            break;
        case 3:
            Console.WriteLine("Caso3");
            break;
        case 4:
            Console.WriteLine("Caso4");
            break;
        case 5:
            Console.WriteLine("Salir");
            break;
        default:
            Console.WriteLine("opcion no valida");
            break;
    }
}while (opcion != 5);
Console.WriteLine("Resumen");