using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestObligatorioP2.Clases
{
    public class Cliente
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string datosCliente
        {
            get { return $"Documento: {Cedula} _Nombre: {Nombre} _Apellido: {Apellido}"; }
        }

        public Cliente() { }
        public Cliente(string cedula, string nombre, string apellido, string direccion, string telefono)
        {
            Cedula = cedula;
            Nombre = nombre;
            Apellido = apellido;
            Direccion = direccion;
            Telefono = telefono;
        }

        public string getCedula() => Cedula;
        public void setCedula(string cedula) => Cedula = cedula;
       

        public string getNombre() => Nombre;
        public void setNombre(string nombre) => Nombre = nombre;
       

        public string getApellido() => Apellido;
        public void setApellido(string apellido) => Apellido = apellido;
       

        public string getDireccion() => Direccion;
        public void setDireccion(string direccion) => Direccion = direccion;
       
        public string getTelefono() => Telefono;
        public void setTelefono(string Telefono) => this.Telefono = Telefono;
    }
}