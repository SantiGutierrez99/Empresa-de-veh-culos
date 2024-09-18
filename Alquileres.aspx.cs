using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using TestObligatorioP2.Clases;

namespace TestObligatorioP2
{
    public partial class Alquileres : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lstClientes.DataSource = BaseDeDatos.listaClientes;
                lstClientes.DataTextField = "datosCliente";
                lstClientes.DataValueField = "Cedula";
                lstClientes.DataBind();

                cboVehiculos.DataSource = BaseDeDatos.ListadoVehiculosActivos();
                cboVehiculos.DataTextField = "datosAlquiler";
                cboVehiculos.DataValueField = "Matricula";
                cboVehiculos.DataBind();

                CargarGridAlquileres();
            }
        }

        protected void cboVehiculos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Alquiler alquiler = new Alquiler();

            alquiler.setCedula(lstClientes.SelectedItem.Value);
            alquiler.setMatricula(cboVehiculos.SelectedItem.Value);
            alquiler.setNombreUsuario(BaseDeDatos.usuarioLogeado.getUser());

            string Matricula = cboVehiculos.SelectedItem.Value;

            int cantDias = Convert.ToInt32(txtDiasAlquiler.Text);
            alquiler.setDias(cantDias);

            int precioTotal = 0;
            foreach (var vehiculo in BaseDeDatos.listaVehiculos)
            {
                if (alquiler.getMatricula() == vehiculo.getMatricula())
                {
                    precioTotal = vehiculo.getPrecioAlquilerDia() * cantDias;
                }
            }
            alquiler.Precio = precioTotal;

            DateTime fechaInicio = Convert.ToDateTime(txtFecha.Text);
            alquiler.FechaAlquiler = fechaInicio;

            int numAlquilerAnterior = BaseDeDatos.listaAlquileres.Any() ? BaseDeDatos.listaAlquileres.Max(alquiler1 => alquiler1.numAlquiler) : 0;
            int numAlquilerNuevo = numAlquilerAnterior + 1;
            alquiler.setNumAlquiler(numAlquilerNuevo);

            // Obtener la fecha de devolución esperada (por ejemplo, sumando los días de alquiler a la fecha de inicio)
            DateTime fechaDevolucionEsperada = fechaInicio.AddDays(cantDias);

            // Determinar el estado del vehículo
            bool estadoVehiculo = (DateTime.Now <= fechaDevolucionEsperada);

            alquiler.EstadoVehiculo = estadoVehiculo;

            BaseDeDatos.listaAlquileres.Add(alquiler);

            foreach (var vehiculo in BaseDeDatos.listaVehiculos)
            {
                if (alquiler.getMatricula() == vehiculo.getMatricula())
                {
                    vehiculo.Activo = false;
                }
            }

            this.gridAlquileres.DataSource = BaseDeDatos.listaAlquileres;
            this.gridAlquileres.DataBind();

            ActualizarListaVehiculos();
            LimpiarCampos();
        }

        private void ActualizarListaVehiculos() // //actualista visualmente la lista de vehiculos a vender
        {
            var vehiculosDisponibles = BaseDeDatos.ListadoVehiculosActivos();

            cboVehiculos.DataSource = vehiculosDisponibles;
            cboVehiculos.DataTextField = "Matricula";
            cboVehiculos.DataValueField = "Matricula";
            cboVehiculos.DataBind();
        }

        private void LimpiarCampos()
        {
            lstClientes.SelectedIndex = -1;
            cboVehiculos.SelectedIndex = -1;
            txtFecha.Text = string.Empty;
            txtDiasAlquiler.Text = string.Empty;
            lblPrecio.Text = string.Empty;
            lblPrecioSimbolo.Visible = false;
            lblPrecio.Visible = false;
        }


        private void ActualizarPrecio()
        {
            string Matricula = cboVehiculos.SelectedItem.Value;
            Alquiler alquiler = new Alquiler();

            int precioTotal = 0;
            int cantDias = 0;

            if (txtDiasAlquiler.Text != "")
            {
                cantDias = Convert.ToInt32(txtDiasAlquiler.Text);
            }
            alquiler.setDias(cantDias);

            foreach (var vehiculo in BaseDeDatos.listaVehiculos)
            {
                if (vehiculo.Matricula == Matricula)
                {
                    precioTotal = vehiculo.getPrecioAlquilerDia() * cantDias;
                    lblPrecio.Text = precioTotal.ToString();
                    lblPrecio.Visible = true;
                    lblPrecioSimbolo.Visible = true;
                }
            }
        }

        private void CargarGridAlquileres()
        {
            // Obtener la lista de alquileres (deberías tener una lista real en tu aplicación)
            var listaAlquileres = BaseDeDatos.ObtenerListaAlquileres();

            // Vincular la lista al GridView
            gridAlquileres.DataSource = listaAlquileres;
            gridAlquileres.DataBind();
        }

        protected void txtDiasAlquiler_TextChanged(object sender, EventArgs e)
        {
            ActualizarPrecio();
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
        protected string ObtenerPrecioAlquilerVehiculo(object matriculaObject, object numAlquilerObject)
        {
            string matricula = matriculaObject.ToString();
            int numAlquiler = Convert.ToInt32(numAlquilerObject);

            // Buscar el vehículo y el alquiler
            Vehiculo vehiculo = BaseDeDatos.ObtenerListaVehiculos().Find(v => v.Matricula == matricula);
            Alquiler alquiler = BaseDeDatos.ObtenerListaAlquileres().Find(a => a.numAlquiler == numAlquiler);

            // Verificar si vehiculo y alquiler son nulos
            if (vehiculo != null && alquiler != null)
            {
                int PrecioTotal = vehiculo.PrecioAlquilerDia * alquiler.Dias;
                return "$" + PrecioTotal.ToString();
            }
            else
            {
                return "No disponible";
            }
        }


        protected string ObtenerNombreApellidoCliente(object documentoObject)
        {
            string documento = documentoObject.ToString();
            Cliente cliente = BaseDeDatos.ObtenerListaClientes().Find(v => v.Cedula == documento);

            return cliente != null ? cliente.Nombre.ToString() + " " + cliente.Apellido.ToString() : "No disponible";
        }


    }
}