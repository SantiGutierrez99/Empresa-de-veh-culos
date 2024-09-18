<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="TestObligatorioP2.Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

      <style>
       body {
           font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
           background-image: url('img/fnd.jpg');
           margin: 0;
           padding: 0;
           background-size: cover;
       }

       .container {
           max-width: 1200px;
           margin: 20px auto;
           box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
           padding: 30px;
           border-radius: 10px;
           background-color: #f1f8e9;
           transition: box-shadow 0.3s ease;
       }

       h3 {
           color: #6a5acd;
           margin-bottom: 15px;
       }

       .form-control {
           width: calc(100% - 20px);
           padding: 15px;
           margin-bottom: 20px;
           box-sizing: border-box;
           border: 1px solid #ddd;
           border-radius: 5px;
           background-color: #f1f8e9;
           transition: border 0.3s ease, box-shadow 0.3s ease;
       }

           .form-control:focus {
               border: 1px solid #4CAF50;
               box-shadow: 0 0 10px rgba(76, 175, 80, 0.3);
           }

       .btn-primary {
           background-color: #6a5acd;
           color: #fff;
           padding: 15px;
           border: none;
           border-radius: 5px;
           cursor: pointer;
           transition: background-color 0.3s ease;
       }

           .btn-primary:hover {
               background-color: #483d8b;
           }
            .grid-container-container {
    margin-top: 20px;
    background-color: #f1f8e9;
    padding: 20px;
    border-radius: 10px;
    box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
}

.grid-container {
    display: flex;
    flex-wrap: wrap;
    justify-content: space-around;
    background-color: #f9f9f9;
    padding: 15px;
    border-radius: 5px;
    box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
}

.grid-item {
    margin: 10px;
    width: 150px;
    transition: transform 0.3s ease;
}

    .grid-item:hover {
        transform: scale(1.2);
    }

    .grid-item img {
        max-width: 100%;
        height: auto;
        border-radius: 5px;
        box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
    }

.table {
    width: 100%;
    border-collapse: collapse;
    margin-top: 20px;
}

    .table th,
    .table td {
        padding: 10px;
        text-align: left;
        border-bottom: 1px solid #ddd;
    }

    .table th {
        background-color: #6a5acd;
        color: #fff;
    }

    .table tr:hover {
        background-color: #f5f5f5;
    }
   
    .table .grid-item:hover {
        transform: scale(1.05);
    }

   </style>

    <div class="row">
        <div class="col-lg-12">
            <h3>Agregar un nuevo Cliente</h3>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-5">
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Nombre del Cliente" Style="width: 250px;"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre"
                ErrorMessage="Ingrese el nombre del Cliente" ForeColor="Red" Display="Dynamic" ValidationGroup="Guardar">
            </asp:RequiredFieldValidator>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-5">
            <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" placeholder="Apellido del Cliente" Style="width: 250px;"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txtApellido"
                ErrorMessage="Ingrese el apellido del Cliente" ForeColor="Red" Display="Dynamic" ValidationGroup="Guardar">
            </asp:RequiredFieldValidator>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-5">
            <asp:TextBox ID="txtDocumento" runat="server" CssClass="form-control" placeholder="Documento del Cliente" Style="width: 250px;"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvDocumento" runat="server" ControlToValidate="txtDocumento"
                ErrorMessage="Ingrese el documento del Cliente" ForeColor="Red" Display="Dynamic" ValidationGroup="Guardar">
            </asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-5">
            <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red">Cliente ya registrado.</asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-5">
            <asp:Label ID="lblErrorCedulaUruguaya" runat="server" Visible="false" ForeColor="Red">El documento ingresado no es válido.</asp:Label>
        </div>
    </div>


    <div class="row">
        <div class="col-lg-5">
            <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" placeholder="Dirección del Cliente" Style="width: 250px;"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ControlToValidate="txtDireccion"
                ErrorMessage="Ingrese la dirección del Cliente" ForeColor="Red" Display="Dynamic" ValidationGroup="Guardar">
            </asp:RequiredFieldValidator>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-5">
            <asp:TextBox TextMode="Number" min="0" ID="txtTelefono" runat="server" CssClass="form-control" placeholder="Teléfono del Cliente" Style="width: 250px;"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="txtTelefono"
                ErrorMessage="Ingrese el teléfono del Cliente" ForeColor="Red" Display="Dynamic" ValidationGroup="Guardar">
            </asp:RequiredFieldValidator>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-5">
            <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" Text="Guardar" OnClick="btnGuardar_Click" ValidationGroup="Guardar" />
        </div>
    </div>

    <div class="row">
        <div class="col-lg-5">
            <asp:Label ID="lblIngresoCorrecto" runat="server" Visible="false" ForeColor="Blue">Cliente ingresado correctamente.</asp:Label>
        </div>
    </div>

    <hr />

    <div class="row">
        <div class="col-lg-12">
            <h3>Lista de Clientes</h3>
            <asp:GridView ID="gvClientes" runat="server" CssClass="table"
                OnRowCancelingEdit="gvClientes_RowCancelingEdit"
                OnRowDeleting="gvClientes_RowDeleting"
                OnRowEditing="gvClientes_RowEditing"
                OnRowUpdating="gvClientes_RowUpdating"
                AutoGenerateColumns="false"
                DataKeyNames="Cedula"
                OnRowDataBound="gvClientes_RowDataBound">

                <Columns>
                    <asp:TemplateField HeaderText="Documento" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lbl100" runat="server" Text='<%# Bind("Cedula") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="150px" />
                        <EditItemTemplate>
                            <asp:Label ID="txtDocumentoGrid" runat="server" Text='<%# Bind("Cedula") %>'></asp:Label>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Nombre" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lbl101" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="150px" />
                        <EditItemTemplate>
                            <asp:TextBox ID="txtNombreGrid" runat="server" Text='<%# Bind("Nombre") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Apellido" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lbl102" runat="server" Text='<%# Bind("Apellido") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="150px" />
                        <EditItemTemplate>
                            <asp:TextBox ID="txtApellidoGrid" runat="server" Text='<%# Bind("Apellido") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Dirección" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lbl103" runat="server" Text='<%# Bind("Direccion") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="150px" />
                        <EditItemTemplate>
                            <asp:TextBox ID="txtDireccionGrid" runat="server" Text='<%# Bind("Direccion") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Teléfono" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lbl104" runat="server" Text='<%# Bind("Telefono") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtTelefonoGrid" runat="server" Text='<%# Bind("Telefono") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle Width="150px" />
                    </asp:TemplateField>


       

                    <asp:TemplateField HeaderText="Editar" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False" CommandName="Edit" Text="Editar"></asp:LinkButton>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:LinkButton ID="lnkUpdate" runat="server" CausesValidation="True" CommandName="Update" Text="Actualizar"></asp:LinkButton>
                            <asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar"></asp:LinkButton>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Eliminar" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="False" CommandName="Delete" Text="Eliminar"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>


                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
