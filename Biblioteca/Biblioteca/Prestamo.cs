using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Prestamo
{
    public int Id { get; set; }
    public Cliente Cliente { get; set; }
    public List<Libro> Libros { get; set; }
    public DateTime FechaSolicitud { get; set; }
    public DateTime FechaVencimiento { get; set; }
    public int CreditoTotal { get; set; }
}