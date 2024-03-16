using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        Biblioteca biblioteca = new Biblioteca();

        // Asignan valores a la clase autor 
        Autor autor1 = new Autor { Id = 1, Nombre = "Autor 1" };
        Autor autor2 = new Autor { Id = 2, Nombre = "Autor 2" };
        biblioteca.AgregarAutor(autor1);
        biblioteca.AgregarAutor(autor2);


        Libro libro1 = new Libro { Id = 1, Autor = autor1, Titulo = "Libro 1", Categoria = "Categoria 1", Credito = 30, Stock = 1 };
        Libro libro2 = new Libro { Id = 2, Autor = autor2, Titulo = "Libro 2", Categoria = "Categoria 2", Credito = 50, Stock = 1 };
        biblioteca.AgregarLibro(libro1);
        biblioteca.AgregarLibro(libro2);


        Cliente cliente1 = new Cliente { Id = 1, Nombre = "Cliente 1", NumeroDocumento = "123456", Telefono = "123456789", Correo = "cliente1@example.com" };
        Cliente cliente2 = new Cliente { Id = 2, Nombre = "Cliente 2", NumeroDocumento = "654321", Telefono = "987654321", Correo = "cliente2@example.com" };
        biblioteca.AgregarCliente(cliente1);
        biblioteca.AgregarCliente(cliente2);

        int opcion = 0;
        while (opcion != 3)
        {
            biblioteca.MostrarMenu();
            opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    // Realizar préstamo
                    Console.WriteLine("Ingrese el ID del cliente que realiza el préstamo:");
                    int idCliente = Convert.ToInt32(Console.ReadLine());
                    Cliente cliente = biblioteca.BuscarClientePorId(idCliente);

                    if (cliente != null)
                    {
                        Console.WriteLine("Nombre del Cliente: " + cliente.Nombre + "\n");
                    }
                   

                    if (cliente != null)
                    {
                        Console.WriteLine("Ingrese el ID del libro que desea prestar (0 para terminar):");
                        List<Libro> librosPrestamo = new List<Libro>();
                        int idLibro = Convert.ToInt32(Console.ReadLine());
                        while (idLibro != 0)
                        {
                            Libro libro = biblioteca.BuscarLibroPorId(idLibro);
                            if (libro != null)
                            {
                                librosPrestamo.Add(libro);
                                Console.WriteLine("Nombre: " + libro.Titulo);
                                Console.WriteLine("costo: " + libro.Credito + " Creditos" + "\n");
                            }
                            else
                            {
                                Console.WriteLine("Libro no encontrado.");
                            }
                            
                            Console.WriteLine("Ingrese el ID del siguiente libro que desea prestar (0 para terminar):");
                            idLibro = Convert.ToInt32(Console.ReadLine());
                        }
                        Console.WriteLine("Ingrese la fecha de solicitud (yyyy-MM-dd ):");
                        DateTime fechaSolicitud = Convert.ToDateTime(Console.ReadLine());
                        Console.WriteLine("Ingrese la fecha de vencimiento (yyyy-MM-dd ):");
                        DateTime fechaVencimiento = Convert.ToDateTime(Console.ReadLine());
                        Console.WriteLine("Ingrese el total de créditos:");
                        int totalCreditos = Convert.ToInt32(Console.ReadLine());

                        

                        biblioteca.RealizarPrestamo(cliente, librosPrestamo, fechaSolicitud, fechaVencimiento, totalCreditos);
                    }
                    else
                    {
                        Console.WriteLine("Cliente no encontrado.");
                    }
                    break;

                case 2:
                    // Realizar pago
                    
                    Console.WriteLine("Ingrese el ID del préstamo que desea pagar: " );
                    int idPrestamo = Convert.ToInt32(Console.ReadLine());
                    Prestamo prestamo = biblioteca.BuscarPrestamoPorId(idPrestamo);

                    
                    if (prestamo != null)
                    {
                        Console.WriteLine("Ingrese la fecha de pago (yyyy-MM-dd):");
                        DateTime fechaPago = Convert.ToDateTime(Console.ReadLine());
                        biblioteca.RealizarPago(prestamo, fechaPago);
                    }
                    else
                    {
                        Console.WriteLine("Préstamo no encontrado.");
                    }
                    break;

                case 3:
                    // Salir
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
    }
}