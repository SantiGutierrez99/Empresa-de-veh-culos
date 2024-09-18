using System.Text.RegularExpressions;
using System.Web.UI.HtmlControls;

namespace TestObligatorioP2.Clases
{
    public class Vehiculo
    {
        public string Matricula { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }

        public long PrecioVenta { get; set; }
        public int PrecioAlquilerDia { get; set; }
        public bool Activo { get; set; }

        public string Imagen1 { get; set; }
        public string Imagen2 { get; set; }
        public string Imagen3 { get; set; }

        public string Tipo { get; set; }

        public string datosVenta
        {
            get { return $"Tipo: {this.GetType().Name} _Matricula: {Matricula}_ Marca: {Marca} _Precio: ${PrecioVenta}"; }
        }

        public string datosAlquiler
        {
            get { return $"Tipo: {this.GetType().Name} _Matricula: {Matricula}_ Marca: {Marca} _Precio diaro: ${PrecioAlquilerDia}"; }
        }


        public Vehiculo() { }

        public Vehiculo(string matricula, string marca, string modelo, long precioVenta, int precioAlquilerDia, bool activo, string imagen1, string imagen2, string imagen3, string tipo)
        {
            Matricula = matricula;
            Marca = marca;
            Modelo = modelo;
            PrecioVenta = precioVenta;
            PrecioAlquilerDia = precioAlquilerDia;
            Activo = activo;
            Imagen1 = imagen1;
            Imagen2 = imagen2;
            Imagen3 = imagen3;
            Tipo = tipo; // Inicializar el nuevo atributo Tipo
        }

        public string getMatricula() => Matricula;
        public void setMatricula(string matricula) => Matricula = matricula;
        public string getMarca() => Marca;
        public void setMarca(string marca) => Marca = marca;
        public string getModelo() => Modelo;
        public void setModelo(string modelo) => Modelo = modelo;
        public long getPrecioVenta() => PrecioVenta;
        public void setPrecioVenta(long precioVenta) => PrecioVenta = precioVenta;
        public int getPrecioAlquilerDia() => PrecioAlquilerDia;
        public void setPrecioAlquilerDia(int precioAlquilerDia) => PrecioAlquilerDia = precioAlquilerDia;
        public bool getEstado() => Activo;
        public void setEstado(bool estado) => Activo = estado;

        public string getImagen1() => Imagen1;
        public void setImagen1(string imagen1) => Imagen1 = imagen1;
        public string getImagen2() => Imagen2;
        public void setImagen2(string imagen2) => Imagen2 = imagen2;
        public string getImagen3() => Imagen3;
        public void setImagen3(string imagen3) => Imagen3 = imagen3;

        public string getTipo() => Tipo;
        public void setTipo(string tipo) => Tipo = tipo;


    }
}
