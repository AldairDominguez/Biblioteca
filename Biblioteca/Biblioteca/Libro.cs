using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Libro
{
    public int Id { get; set; }
    public Autor Autor { get; set; }
    public string Titulo { get; set; }
    public string Categoria { get; set; }
    public int Credito { get; set; }
    public int Stock { get; set; }
}