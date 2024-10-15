using System;

    internal class Program
    {
        static int[][] asientos = new int[20][]; 
        static bool vuelosCreado = false;

        static void Main()
        {
            bool salir = false;
            int opcion = 0;

            while (!salir)
            {
                Console.WriteLine("BIENVENIDOS A LA AEROLINEA");
                Console.WriteLine("¿Qué queres hacer?:" +
                    "\n1) Crear un vuelo" +
                    "\n2) Reservar un asiento" +
                    "\n3) Cancelar una reserva" +
                    "\n4) Mostrar el estado del vuelo" +
                    "\n5) Mostrar cantidad de asientos disponibles y ocupados" +
                    "\n6) Buscar un asiento" +
                    "\n0) Salir");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        CrearVuelo();
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
                    case 0:
                        Console.WriteLine("Saliste del sistema");
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }
            }

            Console.ReadKey();
        }

        static void CrearVuelo()
        {
            if (!vuelosCreado)
            {

                for (int i = 0; i < asientos.Length; i++)
                {
                    asientos[i] = new int[3];
                }
                vuelosCreado = true;
                Console.WriteLine("¡Tu vuelo ya se creó! Tenes 60 asientos disponibles ");
            }
            else
            {
                Console.WriteLine("El vuelo ya se creó");
            }
        }

        static void ReservarAsiento()
        {
            if (!vuelosCreado)
            {
                Console.WriteLine("Debes crear un vuelo.");
                return;
            }

            Console.WriteLine("Ingrese el número de fila (1-20):");
            int fila = int.Parse(Console.ReadLine());
            if (fila<=0 || fila > 20)
            {
                Console.WriteLine("Número de fila no válido. Vas a volver al inicio.");
                return;
            }
            Console.WriteLine("Ingrese el número de asiento (1-3):");
            int columna = int.Parse(Console.ReadLine());
            if (columna<=0 ||columna > 3)
            {
                Console.WriteLine("Número de asiento no válido. Vas a volver al inicio.");
                return;
            }

            if (fila > 0 && fila <=20 && columna > 0 && columna <=3)
            {
                if (asientos[fila][columna] == 0)
                {
                    asientos[fila][columna] = 1;
                    Console.WriteLine("Asiento reservado con éxito!");
                }
                else
                {
                    Console.WriteLine("Asiento ocupado, seleccione otro.");
                }
            }
            
        }

        static void CancelarReserva()
        {
            if (!vuelosCreado)
            {
                Console.WriteLine("Debes crear un vuelo.");
                return;
            }

            Console.WriteLine("Ingrese el número de fila (0-20):");
            int fila = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el número de asiento (0-2):");
            int columna = int.Parse(Console.ReadLine());

            if (fila >= 0 && fila < 20 && columna >= 0 && columna < 3)
            {
                if (asientos[fila][columna] == 1)
                {
                    asientos[fila][columna] = 0; 
                    Console.WriteLine("Cancelaste la reserva.");
                }
                else
                {
                    Console.WriteLine("El asiento no está reservado.");
                }
            }
            else if (fila < 0 || fila >= 20)
            {
                Console.WriteLine("Número de fila no válido.");
            }
            else if (columna < 0 || columna >= 3)
            {
                Console.WriteLine("Número de asiento no válido.");
            }
        }

        static void MostrarEstadoVuelo()
        {
            if (!vuelosCreado)
            {
                Console.WriteLine("Debes crear un vuelo.");
                return;
            }

            Console.WriteLine("Estado del vuelo:");

            for (int i = 0; i < asientos.Length; i++)
            {
                for (int j = 0; j < asientos[i].Length; j++)
                {
                    if (asientos[i][j] == 0)
                    {
                        Console.Write(asientos[i][j] +" Disponible\t");// Imprime el elemento y una tabulación
                    }
                    else
                    {
                        Console.Write(asientos[i][j] + " Ocupado\t" ); 
                    }
                     
                }
                    Console.WriteLine(); // Salto de línea al final de cada fila
            }

        }

        static void MostrarCantidadAsientos()
        {
            if (!vuelosCreado)
            {
                Console.WriteLine("Debes crear un vuelo.");
                return;
            }

            int contadorDisponibles = 0, contadorOcupados = 0;
            for (int i = 0; i < asientos.Length; i++)
            {
                for (int j = 0; j < asientos[i].Length; j++)
                {
                    if (asientos[i][j] == 0)
                    {
                        contadorDisponibles++;
                    }
                    else
                    {
                        contadorOcupados++;
                    }
                }
            }
            Console.WriteLine("Asientos disponibles: " + contadorDisponibles + ", Asientos ocupados: " + contadorOcupados);
        }

        static void BuscarAsiento()
        {
            if (!vuelosCreado)
            {
                Console.WriteLine("Debes crear un vuelo.");
                return;
            }

            Console.WriteLine("Ingrese el número de fila (0-20):");
            int fila = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el número de asiento (0-2):");
            int columna = int.Parse(Console.ReadLine());

            if (fila >= 0 && fila < 20 && columna >= 0 && columna < 4)
            {
                if (asientos[fila][columna] == 0)
                {
                    Console.WriteLine("El estado del asiento " + (columna + 1) + " en la fila " + (fila + 1) + " esta disponible");
                }
                else
                {
                    Console.WriteLine("El estado del asiento " + (columna + 1) + " en la fila " + (fila + 1) + " esta ocupado");
                }
            }
            else if (fila < 0 || fila >= 20)
            {
                Console.WriteLine("Número de fila no válido.");
            }
            else if (columna < 0 || columna >= 3)
            {
                Console.WriteLine("Número de asiento no válido.");
            }
        }
    }