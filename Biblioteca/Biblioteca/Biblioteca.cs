using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Biblioteca
{
    private List<Autor> autores = new List<Autor>();
    private List<Libro> libros = new List<Libro>();
    private List<Cliente> clientes = new List<Cliente>();
    private List<Prestamo> prestamos = new List<Prestamo>();
    
    public void AgregarAutor(Autor autor)
    {
        autores.Add(autor);
    }

    public void AgregarLibro(Libro libro)
    {
        libros.Add(libro);
    }

    public void AgregarCliente(Cliente cliente)
    {
        clientes.Add(cliente);
    }

    public void RealizarPrestamo(Cliente cliente, List<Libro> libros, DateTime fechaSolicitud, DateTime fechaVencimiento, int creditoTotal)
    {
        int creditosUtilizados = 0;
        foreach (var prestamo in prestamos)
        {
            if (prestamo.Cliente == cliente)
            {
                creditosUtilizados += prestamo.CreditoTotal;
            }
        }

        foreach (var libro in libros)
        {
            creditosUtilizados += libro.Credito;
        }

        if ( creditoTotal > 100)
        {
            Console.WriteLine("No hay crédito suficiente.");
            return;
        }

        foreach (var libro in libros)
        {
            if (libro.Stock <= 0)
            {
                Console.WriteLine("No hay stock disponible para el libro: " + libro.Titulo);
                return;
            }
        }

        prestamos.Add(new Prestamo
        {
            Id = prestamos.Count + 1,
            Cliente = cliente,
            Libros = libros,
            FechaSolicitud = fechaSolicitud,
            FechaVencimiento = fechaVencimiento,
            CreditoTotal = creditoTotal
        });

        foreach (var libro in libros)
        {
            libro.Stock--;
        }
    }

    public void RealizarPago(Prestamo prestamo, DateTime fechaPago)
    {
        int diasAtraso = (int)(fechaPago - prestamo.FechaVencimiento).TotalDays;

        double montoPago = 0;
        if (diasAtraso <= 0)
        {
            montoPago = 0.09 * prestamo.CreditoTotal;
        }
        else if (diasAtraso <= 7)
        {
            montoPago = 2 * prestamo.CreditoTotal;
        }
        else if (diasAtraso <= 30)
        {
            montoPago = 2.3 * prestamo.CreditoTotal;
        }
        else
        {
            montoPago = 4.95 * prestamo.CreditoTotal;
        }

        Console.WriteLine("Monto a pagar: $" + montoPago);
    }

    //Busqueda por el id 
    public Cliente BuscarClientePorId(int idCliente)
    {
        return clientes.Find(c => c.Id == idCliente);
    }
    public Libro BuscarLibroPorId(int idLibro)
    {
        return libros.Find(l => l.Id == idLibro);
    }
    public Prestamo BuscarPrestamoPorId(int idPrestamo)
    {
        return prestamos.Find(p => p.Id == idPrestamo);
    }
    //Menu
    public void MostrarMenu()
    {
        Console.WriteLine("=== Biblioteca ===");
        Console.WriteLine("1. Realizar préstamo");
        Console.WriteLine("2. Realizar pago");
        Console.WriteLine("3. Salir");
        Console.WriteLine("==================");
        Console.Write("Seleccione una opción: ");
        
    }
}