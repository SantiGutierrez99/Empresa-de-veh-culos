using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestObligatorioP2.Clases;

namespace TestObligatorioP2
{
    public partial class Ventas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                cboVehiculos.DataSource = BaseDeDatos.ListadoVehiculosActivos();
                cboVehiculos.DataTextField = "datosVenta";
                cboVehiculos.DataValueField = "Matricula";
                cboVehiculos.DataBind();

                cboClientes.DataSource = BaseDeDatos.listaClientes;
                cboClientes.DataTextField = "datosCliente";
                cboClientes.DataValueField = "Cedula";
                cboClientes.DataBind();
            }
            
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Venta venta = new Venta();
            venta.Cedula = cboClientes.SelectedItem.Value;
            venta.Matricula = cboVehiculos.SelectedItem.Value;
            venta.NombreUsuario = BaseDeDatos.usuarioLogeado.getUser();

            string Matricula = cboVehiculos.SelectedItem.Value;
            long precio = 0;
            foreach (var vehiculo in BaseDeDatos.listaVehiculos)
            {
                if (vehiculo.Matricula == Matricula)
                {
                    precio = vehiculo.PrecioVenta;
                    break;
                }
            }
            venta.Precio = precio;
            venta.FechaVenta = DateTime.Now;

            int numVentaAnterior = BaseDeDatos.listaVentas.Any() ? BaseDeDatos.listaVentas.Max(v => v.NumVenta) : 0;
            int numVentaNuevo = numVentaAnterior + 1;
            venta.NumVenta = numVentaNuevo;

            BaseDeDatos.listaVentas.Add(venta);

            foreach (var vehiculo in BaseDeDatos.listaVehiculos)
            {
                if (venta.getMatricula() == vehiculo.getMatricula())
                {
                    vehiculo.Activo = false;
                }
            }
            this.gvVentas.DataSource = BaseDeDatos.listaVentas; 
            this.gvVentas.DataBind();

            ActualizarListaVehiculos(); 
        }
        private void ActualizarListaVehiculos() // //actualista visualmente la lista de vehiculos a vender
        {
            var vehiculosDisponibles = BaseDeDatos.ListadoVehiculosActivos();

            cboVehiculos.DataSource = vehiculosDisponibles;
            cboVehiculos.DataTextField = "datosVenta";
            cboVehiculos.DataValueField = "Matricula";
            cboVehiculos.DataBind();
        }
     
        protected void cboVehiculos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Matricula = cboVehiculos.SelectedItem.Value;

            foreach (var vehiculo in BaseDeDatos.listaVehiculos)
            {
                if (vehiculo.Matricula == Matricula)
                {
                    lblPrecio.Text = vehiculo.PrecioVenta.ToString();
                    lblPrecio.Visible = true;
                    lblPrecioSimbolo.Visible = true;
                }
            }

        }

        protected string ObtenerDocumentoCliente(object documentoObject)
        {
            string documento = documentoObject.ToString();
            Cliente cliente = BaseDeDatos.ObtenerListaClientes().Find(v => v.Cedula == documento);

            return cliente != null ? cliente.Cedula.ToString() : "No disponible";
        }

        protected string ObtenerMarcaVehiculo(object matriculaObject)
        {
            string matricula = matriculaObject.ToString();
            Vehiculo vehiculo = BaseDeDatos.ObtenerListaVehiculos().Find(v => v.Matricula == matricula);
            return vehiculo != null ? vehiculo.Marca : "No disponible";
        }

        protected string ObtenerTipoVehiculo(object matriculaObject)
        {
            string matricula = matriculaObject.ToString();
            Vehiculo vehiculo = BaseDeDatos.ObtenerListaVehiculos().Find(v => v.Matricula == matricula);

            return vehiculo != null ? vehiculo.Tipo.ToString() : "No existe";
        }

        protected string ObtenerNombreApellidoCliente(object documentoObject)
        {
            string documento = documentoObject.ToString();
            Cliente cliente = BaseDeDatos.ObtenerListaClientes().Find(v => v.Cedula == documento);

            return cliente != null ? cliente.Nombre.ToString() + " " + cliente.Apellido.ToString() : "No disponible";
        }

        protected string ObtenerPrecioVentaVehiculo(object matriculaObject)
        {
            string matricula = matriculaObject.ToString();
            Vehiculo vehiculo = BaseDeDatos.ObtenerListaVehiculos().Find(v => v.Matricula == matricula);

            return vehiculo != null ? "$" + vehiculo.PrecioVenta.ToString() : "No disponible";
        }

    }
}