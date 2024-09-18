using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestObligatorioP2.Clases
{
    public class Alquiler
    {
        public string Cedula { get; set; }

        public string Matricula { get; set; }

        public string NombreUsuario { get; set; }

        public DateTime FechaAlquiler { get; set; }

        public int Dias { get; set; }

        public int Precio { get; set; }

        public bool AutoDevuelto { get; set; }
        public int numAlquiler { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public bool EstadoVehiculo { get; set; }
        public Alquiler() { }

        public Alquiler(string cedula, string matricula, string nombreUsuario, DateTime fechaAlquiler, int dias, int precio, bool autoDevuelto, int numAlquiler, DateTime? fechaDevolucion, bool EstadoVehiculo)
        {
            this.Cedula = cedula;
            this.Matricula = matricula;
            this.NombreUsuario = nombreUsuario;
            this.FechaAlquiler = fechaAlquiler;
            this.Dias = dias;
            this.Precio = precio;
            this.AutoDevuelto = autoDevuelto;
            this.numAlquiler = numAlquiler;
            this.FechaDevolucion = null;
            this.EstadoVehiculo = EstadoVehiculo;
        }

        public int getNumAlquiler() => numAlquiler;
        public void setNumAlquiler(int numAlquiler)=> this.numAlquiler=numAlquiler;
        public string getCedula() => Cedula;
        public void setCedula(string cedula) => Cedula = cedula;


        public string getMatricula() => Matricula;
        public void setMatricula(string matricula) => Matricula = matricula;

        public string getNombreUsuario() => NombreUsuario;
        public void setNombreUsuario(string nombreUsuario) => NombreUsuario = nombreUsuario;


        public DateTime getFechaAlquiler() => FechaAlquiler;
        public void setFechaAlquiler(DateTime ferchaAlquiler) => FechaAlquiler = ferchaAlquiler;


        public int getDias() => Dias;
        public void setDias(int dias) => Dias = dias;


        public int getPrecio()=> Precio;
        public void setPrecio(int precio) => Precio = precio;


        public bool getAutoDevuelto()=> AutoDevuelto;
        public void setAutoDevuelto(bool autoDevuelto)=> AutoDevuelto = autoDevuelto;
      
    }
}