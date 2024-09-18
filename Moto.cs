using Antlr.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestObligatorioP2.Clases
{
    public class Moto : Vehiculo
    {
        public int Cilindrada;
        public Moto() { }
        public Moto(int cilindrada, string matricula, string marca, string modelo, int precioVenta, int precioAlquilerDia, bool activo, string imagen1, string imagen2, string imagen3, string tipo) : base(matricula, marca, modelo, precioVenta, precioAlquilerDia, activo, imagen1,  imagen2,  imagen3, tipo)
        {
            Cilindrada = cilindrada;
        }

        public int getCilindrada() => Cilindrada;
        public void setCilindrada(int cilindrada) => Cilindrada = cilindrada;
    }
}
