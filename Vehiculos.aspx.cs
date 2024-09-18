using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestObligatorioP2.Clases;

namespace TestObligatorioP2
{
    public partial class Vehiculos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                CargarGridVehiculos();

            }
            Master.FindControl("lnkClientes").Visible = BaseDeDatos.usuarioLogeado.getVerClientes();
            Master.FindControl("lnkVehiculos").Visible = BaseDeDatos.usuarioLogeado.getVerVehiculos();
            Master.FindControl("lnkVentas").Visible = BaseDeDatos.usuarioLogeado.getVerVentas();
            Master.FindControl("lnkAlquileres").Visible = BaseDeDatos.usuarioLogeado.getVerAlquileres();
            Master.FindControl("lnkUsuarios").Visible = BaseDeDatos.usuarioLogeado.getVerUsuarios();
        }


        protected void gvVehiculos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.gvVehiculos.EditIndex = -1;
            this.gvVehiculos.DataSource = BaseDeDatos.listaVehiculos;
            this.gvVehiculos.DataBind();
        }

        protected void gvVehiculos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string matricula = this.gvVehiculos.DataKeys[e.RowIndex].Values[0].ToString();

            foreach (var vehiculo in BaseDeDatos.listaVehiculos)
            {
                if (vehiculo.Matricula == matricula)
                {
                    BaseDeDatos.listaVehiculos.Remove(vehiculo);
                    break;
                }
            }

            this.gvVehiculos.EditIndex = -1;
            this.gvVehiculos.DataSource = BaseDeDatos.listaVehiculos;
            this.gvVehiculos.DataBind();

        }

        protected void gvVehiculos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow filaSeleccionada = gvVehiculos.Rows[e.RowIndex];
            string matricula = this.gvVehiculos.DataKeys[e.RowIndex].Values[0].ToString();
            string marca = (filaSeleccionada.FindControl("txtMarcaGrid") as TextBox).Text;
            string modelo = (filaSeleccionada.FindControl("txtModeloGrid") as TextBox).Text;
            long precioVenta = long.Parse((filaSeleccionada.FindControl("txtPrecioVentaGrid") as TextBox).Text);
            int precioAlquiler = int.Parse((filaSeleccionada.FindControl("txtPrecioAlquilerGrid") as TextBox).Text);
            bool activo = bool.Parse((filaSeleccionada.FindControl("txtActivoGrid") as TextBox).Text);
            string imagen1 = (filaSeleccionada.FindControl("txtImagen1Grid") as TextBox).Text;


            foreach (var vehiculo in BaseDeDatos.listaVehiculos)
            {
                if (vehiculo.Matricula == matricula)
                {
                    vehiculo.Marca = marca;
                    vehiculo.Modelo = modelo;
                    vehiculo.PrecioVenta = precioVenta;
                    vehiculo.PrecioAlquilerDia = precioAlquiler;
                    vehiculo.Activo = activo;
                    vehiculo.Imagen1 = imagen1;

                }
            }

            this.gvVehiculos.EditIndex = -1;
            this.gvVehiculos.DataSource = BaseDeDatos.listaVehiculos;
            this.gvVehiculos.DataBind();

        }

        protected void gvVehiculos_RowEditing(object sender, GridViewEditEventArgs e)
        {



            this.gvVehiculos.EditIndex = e.NewEditIndex;
            this.gvVehiculos.DataSource = BaseDeDatos.listaVehiculos;
            this.gvVehiculos.DataBind();
        }



        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            bool matriculaNueva = true;

            foreach (Vehiculo vehiculos in BaseDeDatos.listaVehiculos)
            {
                if (vehiculos.Matricula == txtMatricula.Text)
                {
                    lblError.Visible = true;
                    txtMatricula.Text = string.Empty;
                    matriculaNueva = false;
                    break;
                }
            }

            if (matriculaNueva)
            {

                if (rblTipoVehiculo.SelectedItem.Value == "Moto")
                {
                    Moto vehiculo = new Moto();
                    vehiculo.Matricula = txtMatricula.Text;
                    vehiculo.Marca = txtMarca.Text;
                    vehiculo.Modelo = txtModelo.Text;
                    vehiculo.Imagen1 = txtImagen1.Text;
                    vehiculo.Imagen2 = txtImagen2.Text;
                    vehiculo.Imagen3 = txtImagen3.Text;
                    long precioventa = Convert.ToInt64(txtPrecioVenta.Text);
                    vehiculo.setPrecioVenta(precioventa);

                    // Validar que el campo txtPrecioAlquilerDia contenga solo números
                    int precioAlquilerDia;
                    if (int.TryParse(txtPrecioAlquilerDia.Text, out precioAlquilerDia))
                    {
                        vehiculo.setPrecioAlquilerDia(precioAlquilerDia);
                    }
                    else
                    {
                        lblError.Text = "Ingrese un valor válido para el precio de alquiler (solo números).";
                        lblError.Visible = true;
                        return;
                    }

                    vehiculo.Activo = true;
                    vehiculo.Cilindrada = Convert.ToInt32(txtCilindrada.Text);
                    vehiculo.Tipo = "Moto";
                    BaseDeDatos.listaVehiculos.Add(vehiculo);
                }

                if (rblTipoVehiculo.SelectedItem.Value == "Auto")
                {
                    Auto vehiculo = new Auto();
                    vehiculo.Matricula = txtMatricula.Text;
                    vehiculo.Marca = txtMarca.Text;
                    vehiculo.Modelo = txtModelo.Text;
                    vehiculo.Imagen1 = txtImagen1.Text;
                    vehiculo.Imagen2 = txtImagen2.Text;
                    vehiculo.Imagen3 = txtImagen3.Text;
                    int precioventa = Convert.ToInt32(txtPrecioVenta.Text);
                    vehiculo.setPrecioVenta(precioventa);

                    // Validar que el campo txtPrecioAlquilerDia contenga solo números
                    int precioAlquilerDia;
                    if (int.TryParse(txtPrecioAlquilerDia.Text, out precioAlquilerDia))
                    {
                        vehiculo.setPrecioAlquilerDia(precioAlquilerDia);
                    }
                    else
                    {
                        lblError.Text = "Ingrese un valor válido para el precio de alquiler (solo números).";
                        lblError.Visible = true;
                        return;
                    }

                    vehiculo.Activo = true;
                    vehiculo.NumeroDePasajeros = Convert.ToInt32(txtNumeroPasajeros.Text);
                    vehiculo.Tipo = "Auto";
                    BaseDeDatos.listaVehiculos.Add(vehiculo);
                }

                if (rblTipoVehiculo.SelectedItem.Value == "Camion")
                {
                    Camion vehiculo = new Camion();
                    vehiculo.Matricula = txtMatricula.Text;
                    vehiculo.Marca = txtMarca.Text;
                    vehiculo.Modelo = txtModelo.Text;
                    vehiculo.Imagen1 = txtImagen1.Text;
                    vehiculo.Imagen2 = txtImagen2.Text;
                    vehiculo.Imagen3 = txtImagen3.Text;
                    int precioventa = Convert.ToInt32(txtPrecioVenta.Text);
                    vehiculo.setPrecioVenta(precioventa);

                    // Validar que el campo txtPrecioAlquilerDia contenga solo números
                    int precioAlquilerDia;
                    if (int.TryParse(txtPrecioAlquilerDia.Text, out precioAlquilerDia))
                    {
                        vehiculo.setPrecioAlquilerDia(precioAlquilerDia);
                    }
                    else
                    {
                        lblError.Text = "Ingrese un valor válido para el precio de alquiler (solo números).";
                        lblError.Visible = true;
                        return;
                    }

                    vehiculo.Activo = true;
                    vehiculo.ToneladasDeCarga = Convert.ToInt32(txtToneladasCarga.Text);
                    vehiculo.Tipo = "Camion";
                    BaseDeDatos.listaVehiculos.Add(vehiculo);
                }


                this.gvVehiculos.DataSource = BaseDeDatos.listaVehiculos;
                this.gvVehiculos.DataBind();

                txtMatricula.Text = string.Empty;
                txtMarca.Text = string.Empty;
                txtModelo.Text = string.Empty;
                txtImagen1.Text = string.Empty;
                txtImagen2.Text = string.Empty;
                txtImagen2.Text = string.Empty;
                txtPrecioVenta.Text = string.Empty;
                txtPrecioAlquilerDia.Text = string.Empty;
                txtNumeroPasajeros.Text = string.Empty;
                txtCilindrada.Text = string.Empty;
                txtToneladasCarga.Text = string.Empty;
            }
        }


        protected void rblTipoVehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblTipoVehiculo.SelectedItem.Value == "Moto")
            {
                txtCilindrada.Visible = true;
                txtNumeroPasajeros.Visible = false;
                txtToneladasCarga.Visible = false;
            }
            if (rblTipoVehiculo.SelectedItem.Value == "Auto")
            {
                txtCilindrada.Visible = false;
                txtNumeroPasajeros.Visible = true;
                txtToneladasCarga.Visible = false;
            }
            if (rblTipoVehiculo.SelectedItem.Value == "Camion")
            {
                txtCilindrada.Visible = false;
                txtNumeroPasajeros.Visible = false;
                txtToneladasCarga.Visible = true;
            }
        }

        public void CargarGridVehiculos()
        {
            var listaVehiculos = BaseDeDatos.ObtenerListaVehiculos();

            // Vincular la lista al GridView
            gvVehiculos.DataSource = listaVehiculos;
            gvVehiculos.DataBind();
        }
    }
}