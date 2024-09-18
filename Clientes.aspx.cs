using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestObligatorioP2.Clases;

namespace TestObligatorioP2
{
    public partial class Clientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.FindControl("lnkUsuarios").Visible = BaseDeDatos.usuarioLogeado.getVerUsuarios();
            Master.FindControl("lnkClientes").Visible = BaseDeDatos.usuarioLogeado.getVerClientes();
            Master.FindControl("lnkVehiculos").Visible = BaseDeDatos.usuarioLogeado.getVerVehiculos();
            Master.FindControl("lnkVentas").Visible = BaseDeDatos.usuarioLogeado.getVerVentas();
            Master.FindControl("lnkAlquileres").Visible = BaseDeDatos.usuarioLogeado.getVerAlquileres();

            if (!Page.IsPostBack)
            {
                this.gvClientes.DataSource = BaseDeDatos.listaClientes;
                this.gvClientes.DataBind();
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            bool documentoCorrecto = true;

            foreach (Cliente cliente in BaseDeDatos.listaClientes)
            {
                if (cliente.getCedula() == ValidarCedula(txtDocumento.Text))
                {
                    lblError.Visible = true;
                    lblIngresoCorrecto.Visible = false;
                    lblErrorCedulaUruguaya.Visible = false;

                    txtDocumento.Text = string.Empty;

                    documentoCorrecto = false;
                }
            }

            if (documentoCorrecto == true)
            {
                Cliente cliente = new Cliente();

                if (ValidarCedula(txtDocumento.Text) != null)
                {
                    cliente.setCedula(ValidarCedula(txtDocumento.Text));
                    cliente.setNombre(txtNombre.Text);
                    cliente.setApellido(txtApellido.Text);
                    cliente.setDireccion(txtDireccion.Text);
                    cliente.setTelefono(txtTelefono.Text);
                    BaseDeDatos.listaClientes.Add(cliente);

                    lblError.Visible = false; // oculta el LABEL de error si anteriormente se ingresó un documento duplicado
                    lblIngresoCorrecto.Visible = true; //muestra LABEL de ingresado correctamente
                    lblErrorCedulaUruguaya.Visible = false;

                    this.gvClientes.DataSource = BaseDeDatos.listaClientes;
                    this.gvClientes.DataBind();

                    txtDocumento.Text = string.Empty;
                    txtNombre.Text = string.Empty;
                    txtApellido.Text = string.Empty;
                    txtDireccion.Text = string.Empty;
                    txtTelefono.Text = string.Empty;
                }
                else
                {
                    lblErrorCedulaUruguaya.Visible = true;
                    lblError.Visible = false;
                    lblIngresoCorrecto.Visible = false;
                    txtDocumento.Text = string.Empty;
                }

            }
        }

        protected void gvClientes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.gvClientes.EditIndex = e.NewEditIndex;
            this.gvClientes.DataSource = BaseDeDatos.listaClientes;
            this.gvClientes.DataBind();
        }
        protected void gvClientes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow filaSeleccionada = gvClientes.Rows[e.RowIndex];
            string documento = this.gvClientes.DataKeys[e.RowIndex].Values[0].ToString();

            string nombre = (filaSeleccionada.FindControl("txtNombreGrid") as TextBox).Text;
            string apellido = (filaSeleccionada.FindControl("txtApellidoGrid") as TextBox).Text;
            string direccion = (filaSeleccionada.FindControl("txtDireccionGrid") as TextBox).Text;
            string telefono = (filaSeleccionada.FindControl("txtTelefonoGrid") as TextBox).Text;

            foreach (var cliente in BaseDeDatos.listaClientes)
            {
                if (cliente.getCedula() == documento)
                {
                    cliente.setNombre(nombre);
                    cliente.setApellido(apellido);
                    cliente.setDireccion(direccion);
                    cliente.setTelefono(telefono);
                }
            }

            this.gvClientes.EditIndex = -1;
            this.gvClientes.DataSource = BaseDeDatos.listaClientes;
            this.gvClientes.DataBind();
        }

        protected void gvClientes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string documento = this.gvClientes.DataKeys[e.RowIndex].Values[0].ToString();  //se carga la matricula de la fila en la que se da click en eliminar
            foreach (var cliente in BaseDeDatos.listaClientes)
            {
                if (cliente.getCedula() == documento)
                {
                    BaseDeDatos.listaClientes.Remove(cliente);
                    break;  //se agrega el break para que corte al momento de elimiar y saltar el error que dice que se está recorriendo una lista que se está modificando en tiempo real
                }
            }

            this.gvClientes.EditIndex = -1;
            this.gvClientes.DataSource = BaseDeDatos.listaClientes;
            this.gvClientes.DataBind();
        }

        protected void gvClientes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.gvClientes.EditIndex = -1;
            this.gvClientes.DataSource = BaseDeDatos.listaClientes;
            this.gvClientes.DataBind();
        }


        static string ValidarCedula(string cedulaDeIdentidad)
        {
            string regexCI = @"^([0-9]{1}[.]?[0-9]{3}[.]?[0-9]{3}[-]?[0-9]{1}|[0-9]{3}[.]?[0-9]{3}[-]?[0-9]{1})$";

            if (!Regex.IsMatch(cedulaDeIdentidad, regexCI))
            {
                return null;
            }
            else
            {
                // Limpiamos los puntos y guiones para solo quedarnos con los números.
                string numeroCedulaDeIdentidad = Regex.Replace(cedulaDeIdentidad, @"[^0-9]", "");

                // Armarmos el array que va a permitir realizar las multiplicaciones necesarias en cada digito.
                int[] arrayCoeficiente = { 2, 9, 8, 7, 6, 3, 4, 1 };

                // Variable donde se va a guardar el resultado de la suma.
                int suma = 0;

                // Simplemente para que se entienda que esto es el cardinal de digitos que tiene el array de coeficiente.
                int lengthArrayCoeficiente = 8;

                // Contamos la cantidad de digitos que tiene la cadena de números de la CI que limpiamos.
                int lengthCedulaDeIdentidad = numeroCedulaDeIdentidad.Length;

                // Esto nos asegura que si la cédula es menor a un millón, para que el cálculo siga funcionando, simplemente le ponemos un cero antes y funciona perfecto.
                if (lengthCedulaDeIdentidad == 7)
                {
                    numeroCedulaDeIdentidad = "0" + numeroCedulaDeIdentidad;
                    lengthCedulaDeIdentidad++;
                }

                for (int i = 0; i < lengthCedulaDeIdentidad; i++)
                {
                    // Voy obteniendo cada caracter de la CI.
                    char digito = numeroCedulaDeIdentidad[i];

                    // Ahora lo forzamos a ser un int.
                    int digitoInt = (int)Char.GetNumericValue(digito);

                    // Obtengo el coeficiente correspondiente a esta posición.
                    int coeficiente = arrayCoeficiente[i];

                    // Multiplico el caracter por el coeficiente y lo acumulo a la suma total
                    suma = suma + digitoInt * coeficiente;
                }

                // si la suma es múltiplo de 10 es una ci válida
                if (suma % 10 == 0)
                {
                    return numeroCedulaDeIdentidad;
                }
                else
                {
                    return null;
                }
            }
        }
        protected void gvClientes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (gvClientes.EditIndex != -1 && e.Row.RowType == DataControlRowType.DataRow)
            {
                // Estás en modo de edición, deshabilita el botón de eliminación para todas las filas
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                if (lnkDelete != null)
                {
                    lnkDelete.Enabled = false;
                    lnkDelete.CssClass = "disabled-link"; // Agrega una clase CSS para cambiar la apariencia si lo deseas
                }
            }
        }
    }
}