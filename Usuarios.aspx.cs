using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestObligatorioP2.Clases;


namespace TestObligatorioP2
{

    public partial class Usuarios : System.Web.UI.Page
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
                this.gvUsuarios.DataSource = BaseDeDatos.listaUsuarios;
                this.gvUsuarios.DataBind();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            if (chkVerClientes.Checked)
            {
                Label1.Visible = false;
                bool userCorrecto = true;

                foreach (Usuario usuario in BaseDeDatos.listaUsuarios)
                {
                    if (usuario.User == txtUsername.Text)
                    {
                        lblError.Visible = true;
                        txtUsername.Text = string.Empty;
                        userCorrecto = false;
                    }
                }

                if (userCorrecto == true)
                {
                    Usuario usuario = new Usuario();

                    int IdAnterior = BaseDeDatos.listaUsuarios.Any() ? BaseDeDatos.listaUsuarios.Max(usuario1 => usuario1.IdUsuario) : 0;
                    int IdNuevo = IdAnterior + 1;
                    usuario.setIdUsuario(IdNuevo);

                    usuario.setUser(txtUsername.Text);
                    usuario.setNombreUsuario(txtNombreUsuario.Text);
                    usuario.setApellidoUsuario(txtApellidoUsuario.Text);
                    usuario.setContrasena(txtPassword.Text);
                    usuario.setVerClientes(chkVerClientes.Checked);
                    usuario.setVerUsuarios(chkVerUsuarios.Checked);
                    usuario.setVerVentas(chkVerVentas.Checked);
                    usuario.setVerVehiculos(chkVerVehiculos.Checked);
                    usuario.setVerAlquileres(chkVerAlquileres.Checked);

                    BaseDeDatos.listaUsuarios.Add(usuario);
                    this.gvUsuarios.DataSource = BaseDeDatos.listaUsuarios;
                    this.gvUsuarios.DataBind();

                    txtUsername.Text = string.Empty;
                    txtNombreUsuario.Text = string.Empty;
                    txtApellidoUsuario.Text = string.Empty;
                    txtPassword.Text = string.Empty;
                    chkVerClientes.Checked = false;
                    chkVerUsuarios.Checked = false;
                    chkVerVentas.Checked = false;
                    chkVerVehiculos.Checked = false;
                    chkVerAlquileres.Checked = false;

                }

            }
            else
            {
                Label1.Visible = true;
            }

        }

        protected void gvUsuarios_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.gvUsuarios.EditIndex = -1;
            this.gvUsuarios.DataSource = BaseDeDatos.listaUsuarios;
            this.gvUsuarios.DataBind();
        }

        protected void gvUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Obtener el índice de la fila que se está eliminando
            int rowIndex = e.RowIndex;

            // Verificar si hay valores en las DataKeys y si la fila está dentro del rango
            if (gvUsuarios.DataKeys != null && rowIndex >= 0 && rowIndex < gvUsuarios.DataKeys.Count)
            {
                // Obtener el valor de "User" desde las DataKeys
                string username = gvUsuarios.DataKeys[rowIndex]?.Values["User"]?.ToString();

                if (username != null)
                {
                    // Buscar y eliminar el usuario por su username
                    Usuario usuarioAEliminar = BaseDeDatos.listaUsuarios.FirstOrDefault(u => u.getUser() == username);

                    if (usuarioAEliminar != null)
                    {
                        BaseDeDatos.listaUsuarios.Remove(usuarioAEliminar);
                        gvUsuarios.EditIndex = -1;
                        gvUsuarios.DataSource = BaseDeDatos.listaUsuarios;
                        gvUsuarios.DataBind();
                    }
                }
            }
        }


        protected void gvUsuarios_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow filaSeleccionada = gvUsuarios.Rows[e.RowIndex];

            // Verificar si hay valores en las DataKeys
            if (gvUsuarios.DataKeys != null)
            {
                // Obtener el valor de "User" desde las DataKeys
                string username = gvUsuarios.DataKeys[e.RowIndex]?.Values["User"]?.ToString();

                if (username != null)
                {
                    string nombre = (filaSeleccionada.FindControl("TextBox1") as TextBox).Text;
                    string apellido = (filaSeleccionada.FindControl("txtApellidoGrid") as TextBox).Text;

                    foreach (var usuario in BaseDeDatos.listaUsuarios)
                    {
                        if (usuario.getUser() == username)
                        {
                            usuario.setNombreUsuario(nombre);
                            usuario.setApellidoUsuario(apellido);
                        }
                    }

                    gvUsuarios.EditIndex = -1;
                    gvUsuarios.DataSource = BaseDeDatos.listaUsuarios;
                    gvUsuarios.DataBind();
                }
            }
        }




        protected void gvUsuarios_RowDataBound(object sender, GridViewRowEventArgs e) //metodo para que cuando se está editando no se pueda usar el boton de eliminar en esa línea y en las demás líneas
        {
            if (gvUsuarios.EditIndex != -1 && e.Row.RowType == DataControlRowType.DataRow)
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

        protected void gvUsuarios_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.gvUsuarios.EditIndex = e.NewEditIndex;
            this.gvUsuarios.DataSource = BaseDeDatos.listaUsuarios;
            this.gvUsuarios.DataBind();
        }

    }
}