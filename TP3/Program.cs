using System;

class Program
{
    static int[] vuelos;
    static bool creado = false;
    static int cantidadVuelos;

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nMenu");
            Console.WriteLine("1. Crear vuelos");
            Console.WriteLine("2. Reservar asiento");
            Console.WriteLine("3. Cancelar reserva");
            Console.WriteLine("4. Mostrar estado del vuelo");
            Console.WriteLine("5. Mostrar cantidad de asientos disponibles/ocupados");
            Console.WriteLine("6. Buscar asiento");
            Console.WriteLine("7. Salir");

            Console.Write("Ingrese una opcion: \n");
            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    CrearVuelos();
                    break;
                case 2:
                    ReservarAsiento();
                    break;
                case 3:
                    CancelarReserva();
                    break;
                case 4:
                    MostrarEstadoVuelo();
                    break;
                case 5:
                    MostrarCantidadAsientos();
                    break;
                case 6:
                    BuscarAsiento();
                    break;
                case 7:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opcion no valida");
                    break;
            }
        }
    }

    static void CrearVuelos()
    {
        if (!creado)
        {
            Console.Write("Ingrese cantidad de vuelos: ");
            cantidadVuelos = int.Parse(Console.ReadLine());
            vuelos = new int[cantidadVuelos * 60];

            for (int i = 0; i < vuelos.Length; i++)
            {
                vuelos[i] = 0;
            }

            creado = true;
        }
        else
        {
            Console.WriteLine("Los datos ya fueron creados.");
        }
    }

    static void ReservarAsiento()
    {
        if (creado)
        {
            Console.Write("Ingrese numero de vuelo: ");
            int numVuelo;
            while (!int.TryParse(Console.ReadLine(), out numVuelo) || numVuelo <= 0 || numVuelo > cantidadVuelos)
            {
                Console.WriteLine("Numero de vuelo invalido. Intente nuevamente.");
                Console.Write("Ingrese número de vuelo: ");
            }

            Console.Write("Ingrese numero de asiento: ");
            int numAsiento;
            while (!int.TryParse(Console.ReadLine(), out numAsiento) || numAsiento < 1 || numAsiento > 60)
            {
                Console.WriteLine("Numero de asiento invalido. Intente nuevamente.");
                Console.Write("Ingrese número de asiento: ");
            }

            int indice = (numVuelo - 1) * 60 + (numAsiento - 1);
            if (vuelos[indice] == 0)
            {
                vuelos[indice] = 1;
                Console.WriteLine("Asiento reservado con exito.");
            }
            else
            {
                Console.WriteLine("Asiento ya ocupado.");
            }
        }
        else
        {
            Console.WriteLine("No se han creado los datos.");
        }
    }


    static void CancelarReserva()
    {
        if (creado)
        {
            Console.Write("Ingrese numero de vuelo: ");
            int numVuelo;
            while (!int.TryParse(Console.ReadLine(), out numVuelo) || numVuelo <= 0 || numVuelo > cantidadVuelos)
            {
                Console.WriteLine("Numero de vuelo invalido. Intente nuevamente.");
                Console.Write("Ingrese número de vuelo: ");
            }

            Console.Write("Ingrese numero de asiento: ");
            int numAsiento;
            while (!int.TryParse(Console.ReadLine(), out numAsiento) || numAsiento < 1 || numAsiento > 60)
            {
                Console.WriteLine("Numero de asiento invalido. Intente nuevamente.");
                Console.Write("Ingrese número de asiento: ");
            }

            int indice = (numVuelo - 1) * 60 + (numAsiento - 1);

            if (vuelos[indice] == 1)
            {
                vuelos[indice] = 0;
                Console.WriteLine("Reserva cancelada con exito.");
            }
            else
            {
                Console.WriteLine("Asiento ya disponible.");
            }
        }
        else
        {
            Console.WriteLine("No se han creado los datos.");
        }
    }

    static void MostrarEstadoVuelo()
    {
        if (creado)
        {
            Console.Write("Ingrese numero de vuelo: ");
            int numVuelo;
            while (!int.TryParse(Console.ReadLine(), out numVuelo) || numVuelo <= 0 || numVuelo > cantidadVuelos)
            {
                Console.WriteLine("Numero de vuelo invalido. Intente nuevamente.");
                Console.Write("Ingrese número de vuelo: ");
            }

            Console.WriteLine("Estado del vuelo:");
            for (int i = (numVuelo - 1) * 60; i < numVuelo * 60; i++)
            {
                Console.Write($"Asiento {i - (numVuelo - 1) * 60 + 1}: {(vuelos[i] == 0 ? "Disponible" : "Ocupado")}\t");
            }
        }
        else
        {
            Console.WriteLine("No se han creado los datos.");
        }
    }

    static void MostrarCantidadAsientos()
    {
        if (creado)
        {
            Console.Write("Ingrese numero de vuelo: ");
            int numVuelo;
            while (!int.TryParse(Console.ReadLine(), out numVuelo) || numVuelo <= 0 || numVuelo > cantidadVuelos)
            {
                Console.WriteLine("Numero de vuelo invalido. Intente nuevamente.");
                Console.Write("Ingrese número de vuelo: ");
            }

            int disponibles = 0;
            int ocupados = 0;

            for (int i = (numVuelo - 1) * 60; i < numVuelo * 60; i++)
            {
                if (vuelos[i] == 0)
                {
                    disponibles++;
                }
                else
                {
                    ocupados++;
                }
            }

            Console.WriteLine($"Asientos disponibles: {disponibles}");
            Console.WriteLine($"Asientos ocupados: {ocupados}");
        }
        else
        {
            Console.WriteLine("No se han creado los datos.");
        }
    }

    static void BuscarAsiento()
    {
        if (creado)
        {
            Console.Write("Ingrese numero de vuelo: ");
            int numVuelo;
            while (!int.TryParse(Console.ReadLine(), out numVuelo) || numVuelo <= 0 || numVuelo > cantidadVuelos)
            {
                Console.WriteLine("Numero de vuelo invalido. Intente nuevamente.");
                Console.Write("Ingrese número de vuelo: ");
            }

            Console.Write("Ingrese numero de asiento: ");
            int numAsiento;
            while (!int.TryParse(Console.ReadLine(), out numAsiento) || numAsiento < 1 || numAsiento > 60)
            {
                Console.WriteLine("Numero de asiento invalido. Intente nuevamente.");
                Console.Write("Ingrese número de asiento: ");
            }

            int indice = (numVuelo - 1) * 60 + (numAsiento - 1);

            if (vuelos[indice] == 0)
            {
                Console.WriteLine("Asiento disponible.");
            }
            else
            {
                Console.WriteLine("Asiento ocupado.");
            }
        }
        else
        {
            Console.WriteLine("No se han creado los datos.");
        }
    }
}
