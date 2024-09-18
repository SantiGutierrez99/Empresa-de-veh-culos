using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestObligatorioP2.Clases
{
    public class Venta
    {
        public string Cedula { get; set; }

        public string Matricula { get; set; }

        public string NombreUsuario { get; set; }

        public DateTime FechaVenta { get; set; }

        public long Precio { get; set; }

        public int NumVenta { get; set; }
        public Venta() { }
        public Venta(string cedula, string matricula, string nombreUsuario, DateTime fechaVenta, long precio, int numVenta)
        {
            Cedula = cedula;
            Matricula = matricula;
            NombreUsuario = nombreUsuario;
            FechaVenta = fechaVenta;
            Precio = precio;
            NumVenta = numVenta;
        }

        public string getCedula() => Cedula;
        public void setCedula(string cedula) => Cedula = cedula;

        public string getMatricula()=> Matricula;
        public void setMatricula(string matricula) => Matricula = matricula;

        public string getNombreUsuario() => NombreUsuario;
        public void setNombreUsuario(string nombreUsuario) => NombreUsuario = nombreUsuario;
        public long getPrecio() => Precio;
        public void setPrecio(long precio) => Precio = precio;

        public DateTime getFechaAlquiler() => FechaVenta;
        public void setFechaVenta(DateTime ferchaVenta) => FechaVenta = ferchaVenta;

        public int getNumVenta()=> NumVenta;
        public void setNumVenta(int NumVenta) => this.NumVenta = NumVenta;

    }
}