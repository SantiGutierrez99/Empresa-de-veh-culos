using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestObligatorioP2.Clases
{
    public class Camion : Vehiculo
    {
        public int ToneladasDeCarga;
        public Camion() { }
        public Camion(int toneladas, string matricula, string marca, string modelo, int precioVenta, int precioAlquilerDia, bool activo, string imagen1, string imagen2, string imagen3, string tipo) : base(matricula, marca, modelo, precioVenta, precioAlquilerDia, activo, imagen1, imagen2, imagen3, tipo)
        {

            ToneladasDeCarga = toneladas;

        }

        public int getToneladas() => ToneladasDeCarga;
        public void setToneladas(int toneladas) => ToneladasDeCarga = toneladas;
    }

}