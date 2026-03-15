using System.Collections.Concurrent;
using System.ComponentModel.Design;
using System.Threading.Channels;
string tipocontenido = "";
int duracion = 0;
string clasificacion;
int hprogramada = 0;
string nproduccion;
int contenidos = 1;
int opcion;
int cero;
//contadores
int TotalEva = 0;
int Totalpublicados = 0;
int Totalrechazados = 0;
int TotalRevision = 0;
int PorAprovacion;


//variables para los metodos y procedimientos
string clahorario = "";
string dutipo = "";
string produccion = "";
string impacto = "";
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
        case 1: //Tipo - duracion - clasificacion - hora - nivel de produccion
    
                Console.WriteLine("Ingrese el tipo de contenido (pelicula, serie, documental, evento en vivo):");
                tipocontenido = Console.ReadLine();
                Console.WriteLine("Ingrese la duracion en minutos:");
                duracion = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese la clasificación (todo publico, +13, +18):");
                clasificacion = Console.ReadLine();
                Console.WriteLine("Ingrese la hora programada (0-23):");
                hprogramada = int.Parse(Console.ReadLine());

            TotalEva++;

            break;
        case 2: // Mostras reglas
            do
            {
                Console.WriteLine($" Debe agregar una de las opciones \n PELICULA, SERIE, DOCUMENTAL, EVENTO EN VIVO");
                Console.WriteLine($" Debe agregar la duracion obligatoriamente en MINUTOS");
                Console.WriteLine($" Debe agregar la calsificacion puede ser: \n TODO PUBLICO, +13, +18");
                Console.WriteLine($" El horario que se usa es de 24 hrs (de lo contrario sera invalidado)");
                Console.WriteLine("                                                                          VOLVER = 0");
                cero = int.Parse(Console.ReadLine());
            } while (cero != 0);
            break;
        case 3: // Estadisticas de la secion (basado en el caso1)
            
            Console.WriteLine($"La clasificacion es {valclahorario(hprogramada)}");
            Console.WriteLine($"Es de tipo: {duraciotipo(tipocontenido, duracion)}");
            Console.WriteLine($"El tipo de produccion es: {Rproduccion(clahorario)}");
            Console.WriteLine($"El Impacto es: {clsimpacto(produccion, duracion, hprogramada)}");
            break;
        case 4: // Reiniciar estadisticas
            Console.WriteLine("Reiniciando...");
            await Task.Delay(1000);
            tipocontenido = "";
            duracion = 0;
            clasificacion = "";
            hprogramada = 0;
            nproduccion = "";
            contenidos = 1;    
            break;
        case 5: // Salir
            Console.WriteLine("Salir");
            break;
        default:
            Console.WriteLine("opcion no valida");
            break;
    }
    
} while (opcion != 5);
Console.WriteLine("Resumen");

//Metodos
string valclahorario(int hprogramada)
{
    if (hprogramada >= 6 && hprogramada <= 22)
    {
        clahorario = "+13";
    }
    else if (hprogramada >= 22 || hprogramada <= 5)
    {
        clahorario = "+18";
    }
    else
    {
        clahorario = "Todo publico";
     
    }
    return clahorario;
}

string duraciotipo(string tipocontenido, int duracion)
{
    if (tipocontenido.ToLower() == "serie")
    {
        if (duracion >= 20 && duracion <= 90)
        {
            dutipo = "Valido";
        }
        else
        {
            dutipo = "Duracion invalida";
        }

    }
    else if (tipocontenido.ToLower() == "documental")
    {
        if (duracion >= 30 && duracion <= 120)
        {
            dutipo = "Valido";
        }
        else
        {
            dutipo = "Duracion invalida";
        }
    }
    else if (tipocontenido.ToLower() == "pelicula")
    {
        if (duracion >= 60 && duracion <= 100)
        {
            dutipo = "Valido";
        }else
        {
            dutipo = "Duracion invalida";
        }
    }else if (tipocontenido.ToLower() == "envento en vivo")
    {
        if ( duracion >= 30 && duracion <= 240)
        {
            dutipo = "Valido";
        }else
        {
            dutipo = "Duracion invalido";
        }
    }else
    {
        dutipo = "Tipo invalido";
    }
    return dutipo;
}

string Rproduccion(string clhorario)
{
    if (clhorario == "Todo publico" || clhorario == "+13")
    {
        produccion = "Baja";
    }else if (clahorario == "+18")
    {
        produccion = "Media";
    }
    else
    {
        produccion = "Alta";
    }
    return produccion;
}

string clsimpacto(string produccion, int duracion, int hprogamada)
{
    if (produccion.ToLower() == "Alta" || duracion > 120 || (hprogamada >= 20 && hprogamada <= 23))
    {
        impacto = "Alto";
    }
    else if (produccion.ToLower() == "Media" || (duracion >= 60 && duracion <= 120 ))
    {
        impacto = "Medio";
    }
    else if (produccion.ToLower() == "Baja" && duracion < 60)
    {
        impacto = "Baja";
    }else
    {
        Console.WriteLine("Datos erroneos");
    }
    return impacto;
}
