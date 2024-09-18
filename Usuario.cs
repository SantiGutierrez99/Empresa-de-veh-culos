using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestObligatorioP2.Clases
{
    public class Usuario
    {
        public string NombreUsuario { get; set; }
        public string ApellidoUsuario { get; set; }
        public string Contrasena { get; set; }
        public bool VerClientes { get; set; }
        public bool VerUsuarios { get; set; }
        public bool VerVentas { get; set; }
        public bool VerVehiculos { get; set; }
        public bool VerAlquileres { get; set; }
        public int IdUsuario { get; set; }

        public string User { get; set; }

        public Usuario() { }
        public Usuario(string nombreUsuario, string apellidoUsuario, string contrasena, bool verClientes, bool verUsuarios, bool verVentas, bool verVehiculos, bool verAlquileres, int idUsuario, string user)
        {
            NombreUsuario = nombreUsuario;
            ApellidoUsuario = apellidoUsuario;
            Contrasena = contrasena;
            VerClientes = verClientes;
            VerUsuarios = verUsuarios;
            VerVentas = verVentas;
            VerVehiculos = verVehiculos;
            VerAlquileres = verAlquileres;
            IdUsuario = idUsuario;
            User = user;
        }

        public string getNombreUsuario() => NombreUsuario;

        public void setNombreUsuario(string nombreUsuario) => NombreUsuario = nombreUsuario;

        public string getApellidoUsuario() => ApellidoUsuario;
        public void setApellidoUsuario(string ApellidoUsuario) => this.ApellidoUsuario = ApellidoUsuario;

        public string getContrasena() => Contrasena;

        public void setContrasena(string cont) => Contrasena = cont;

        public bool getVerClientes() => VerClientes;
        public void setVerClientes(bool verClientes) => VerClientes = verClientes;


        public bool getVerUsuarios() => VerUsuarios;
        public void setVerUsuarios(bool verUsuarios) => VerUsuarios = verUsuarios;

        public bool getVerVehiculos() => VerVehiculos;
        public void setVerVehiculos(bool verVehiculos) => VerVehiculos = verVehiculos;


        public bool getVerVentas() => VerVentas;
        public void setVerVentas(bool verVentas) => VerVentas = verVentas;

        public bool getVerAlquileres() => VerAlquileres;
        public void setVerAlquileres(bool verAlquileres) => VerAlquileres = verAlquileres;

        public int getIdUsuario() => IdUsuario;
        public void setIdUsuario(int IdUsuario) => this.IdUsuario = IdUsuario;

        public string getUser() => User;
        public void setUser(string User) => this.User = User;
       
    }
}