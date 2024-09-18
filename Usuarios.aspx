<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="TestObligatorioP2.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background-image: url('img/fnd.jpg');
            margin: 0;
            padding: 0;
            background-size: cover;
        }

        .main-container {
            max-width: 1200px;
            margin: 20px auto;
            box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
            padding: 30px;
            border-radius: 10px;
            background-color: #f1f8e9;
            transition: box-shadow 0.3s ease;
        }

            .main-container:hover {
                box-shadow: 0 0 30px rgba(0, 0, 0, 0.2);
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

        .checkbox-options h4 {
            color: #6a5acd;
        }

        .checkbox-options div {
            margin-bottom: 10px;
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

        .table-container {
            margin-top: 20px;
        }

        .gvUsuarios-header {
            background-color: #6a5acd;
            color: #fff;
            font-weight: bold;
        }

        .gvUsuarios-row {
            background-color: #f9f9f9;
        }

            .gvUsuarios-row:hover {
                background-color: #f5f5f5;
            }
    </style>


    <div class="main-container">
        <div class="row">
            <div class="col-lg-12">
                <h3>Agregar un nuevo Usuario</h3>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-5">
                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Username" Style="width: 250px;"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername"
                    ErrorMessage="Ingrese un username" ForeColor="Red" Display="Dynamic" ValidationGroup="Guardar">
                </asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-5">
                <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red">Usuario ya registrado.</asp:Label>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-5">
                <asp:TextBox ID="txtNombreUsuario" runat="server" CssClass="form-control" placeholder="Nombre del Usuario" Style="width: 250px;"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNombreUsuario" runat="server" ControlToValidate="txtNombreUsuario"
                    ErrorMessage="Ingrese el nombre del Usuario" ForeColor="Red" Display="Dynamic" ValidationGroup="Guardar">
                </asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-5">
                <asp:TextBox ID="txtApellidoUsuario" runat="server" CssClass="form-control" placeholder="Apellido del Usuario" Style="width: 250px;"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvApellidoUsuario" runat="server" ControlToValidate="txtApellidoUsuario"
                    ErrorMessage="Ingrese el apellido del Usuario" ForeColor="Red" Display="Dynamic" ValidationGroup="Guardar">
                </asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-5">
                <asp:TextBox TextMode="Password" ID="txtPassword" runat="server" CssClass="form-control" placeholder="Contraseña" Style="width: 250px;"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                    ErrorMessage="Ingrese una contraseña" ForeColor="Red" Display="Dynamic" ValidationGroup="Guardar">
                </asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-5">
                <asp:TextBox TextMode="Password" ID="txtConfirmarPassword" runat="server" CssClass="form-control" placeholder="Confirmar Contraseña" Style="width: 250px;"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvConfirmarPassword" runat="server" ControlToValidate="txtConfirmarPassword"
                    ErrorMessage="Confirme la contraseña" ForeColor="Red" Display="Dynamic" ValidationGroup="Guardar">
                </asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvPasswordMatch" runat="server" ControlToValidate="txtConfirmarPassword" ControlToCompare="txtPassword"
                    ErrorMessage="Las contraseñas no coinciden" ForeColor="Red" Display="Dynamic" ValidationGroup="Guardar">
                </asp:CompareValidator>
            </div>
        </div>


        <div class="row">
            <div class="col-lg-5 checkbox-options">
                <h4>Permisos:</h4>
                <div class="row">
                    <div class="col-lg-5">
                        <asp:Label ID="Label1" runat="server" Visible="false" ForeColor="Red">Debe seleccionar al menos ver clientes.</asp:Label>
                    </div>
                </div>
                <div>
                    <asp:CheckBox ID="chkVerClientes" runat="server" Text="Ver Clientes" />
                </div>
                <div>
                    <asp:CheckBox ID="chkVerUsuarios" runat="server" Text="Ver Usuario" />
                </div>
                <div>
                    <asp:CheckBox ID="chkVerVentas" runat="server" Text="Ver Ventas" />
                </div>
                <div>
                    <asp:CheckBox ID="chkVerVehiculos" runat="server" Text="Ver Vehículos" />
                </div>
                <div>
                    <asp:CheckBox ID="chkVerAlquileres" runat="server" Text="Ver Alquileres" />
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-5">
                <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" Text="Guardar" OnClick="btnGuardar_Click" ValidationGroup="Guardar" />
            </div>
        </div>
        <hr />

        <div class="row">
            <div class="col-lg-8 table-container">
                <asp:GridView ID="gvUsuarios" runat="server" Width="100%" BorderWidth="2px" CellSpacing="5"
                    OnRowCancelingEdit="gvUsuarios_RowCancelingEdit"
                    OnRowDeleting="gvUsuarios_RowDeleting"
                    OnRowEditing="gvUsuarios_RowEditing"
                    OnRowUpdating="gvUsuarios_RowUpdating"
                    AutoGenerateColumns="false"
                    OnRowDataBound="gvUsuarios_RowDataBound"
                    DataKeyNames="User"
                    CssClass="table">
                    <HeaderStyle CssClass="gvUsuarios-header" />
                    <RowStyle CssClass="gvUsuarios-row" />
                    <Columns>
                        <asp:TemplateField HeaderText="Número ID Usuario" ItemStyle-Width="150px">
                            <ItemTemplate>
                                <asp:Label ID="lblidUsuario" runat="server" Text='<%# Bind("IdUsuario") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Username" ItemStyle-Width="150px">
                            <ItemTemplate>
                                <asp:Label ID="lbl1" runat="server" Text='<%# Bind("User") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtNombreGrid" runat="server" Text='<%# Bind("User") %>'></asp:TextBox>
                            </EditItemTemplate>

                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Nombre" ItemStyle-Width="150px">
                            <ItemTemplate>
                                <asp:Label ID="lbl3" runat="server" Text='<%# Bind("NombreUsuario") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("NombreUsuario") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Apellido" ItemStyle-Width="150px">
                            <ItemTemplate>
                                <asp:Label ID="lbl4" runat="server" Text='<%# Bind("ApellidoUsuario") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtApellidoGrid" runat="server" Text='<%# Bind("ApellidoUsuario") %>'></asp:TextBox>
                            </EditItemTemplate>

                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Editar" ItemStyle-Width="150px">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False" CommandName="Edit" Text="Editar"></asp:LinkButton>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton ID="lnkUpdate" runat="server" CausesValidation="True" CommandName="Update" Text="Actualizar"></asp:LinkButton>
                                <asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar"></asp:LinkButton>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Eliminar" ItemStyle-Width="150px">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="False" CommandName="Delete" Text="Eliminar"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
