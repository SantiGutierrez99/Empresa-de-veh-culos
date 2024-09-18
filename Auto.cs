using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestObligatorioP2.Clases
{
    public class Auto : Vehiculo
    {
        public int NumeroDePasajeros;
        public Auto() { }

        public Auto(int numeroDePasajeros, string matricula, string marca, string modelo, int precioVenta, int precioAlquilerDia, bool activo, string imagen1, string imagen2, string imagen3, string tipo) : base(matricula, marca, modelo, precioVenta, precioAlquilerDia, activo, imagen1, imagen2, imagen3, tipo)
        {
            NumeroDePasajeros = numeroDePasajeros;

        }
        public int getNumeroDePasajeros() => NumeroDePasajeros;
        public void setNumeroDePasajeros(int numeroDePasajeros) => NumeroDePasajeros = numeroDePasajeros;
    }
}