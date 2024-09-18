<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Vehiculos.aspx.cs" Inherits="TestObligatorioP2.Vehiculos" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
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
            <h3>Registro de Vehiculos</h3>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-5">
            <asp:TextBox ID="txtMatricula" runat="server" CssClass="form-control" placeholder="Matricula del Vehiculo"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvMatricula" runat="server" ControlToValidate="txtMatricula"
                ErrorMessage="Ingrese una matrícula" ForeColor="Red" Display="Dynamic" ValidationGroup="Guardar">
            </asp:RequiredFieldValidator>
        </div>
        <div class="row">
            <div class="col-lg-5">
                <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red">Vehículo ya existente.</asp:Label>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-5">
            <asp:TextBox ID="txtMarca" runat="server" CssClass="form-control" placeholder="Marca del Vehiculo"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvMarca" runat="server" ControlToValidate="txtMarca"
                ErrorMessage="Ingrese la marca del vehículo" ForeColor="Red" Display="Dynamic" ValidationGroup="Guardar">
            </asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-5">
            <asp:TextBox ID="txtModelo" runat="server" CssClass="form-control" placeholder="Modelo del Vehiculo"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvModelo" runat="server" ControlToValidate="txtModelo"
                ErrorMessage="Ingrese el modelo del vehículo" ForeColor="Red" Display="Dynamic" ValidationGroup="Guardar">
            </asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-5">
            <asp:TextBox TextMode="Number" min="1" ID="txtPrecioVenta" runat="server" CssClass="form-control" placeholder="Precio de venta"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPrecioVenta" runat="server" ControlToValidate="txtPrecioVenta"
                ErrorMessage="Ingrese el precio de venta" ForeColor="Red" Display="Dynamic" ValidationGroup="Guardar">
            </asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-5">
            <asp:TextBox ID="txtPrecioAlquilerDia" runat="server" CssClass="form-control" placeholder="Precio de alquiler diario"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPrecioAlquiler" runat="server" ControlToValidate="txtPrecioAlquilerDia"
                ErrorMessage="Ingrese el precio de alquiler por día" ForeColor="Red" Display="Dynamic" ValidationGroup="Guardar">
            </asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-5">
            <asp:TextBox ID="txtImagen1" TextMode="Url" runat="server" CssClass="form-control" placeholder="Imagen1 del Vehiculo"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="txtImagen1" runat="server" ErrorMessage="Debe ingresar 3 imagenes" ForeColor="Red" Display="Dynamic" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-5">
            <asp:TextBox ID="txtImagen2" TextMode="Url" runat="server" CssClass="form-control" placeholder="Imagen2 del Vehiculo"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="txtImagen2" runat="server" ErrorMessage="Debe ingresar 3 imagenes" ForeColor="Red" Display="Dynamic" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-5">
            <asp:TextBox ID="txtImagen3" TextMode="Url" runat="server" CssClass="form-control" placeholder="Imagen3 del Vehiculo"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="txtImagen2" runat="server" ErrorMessage="Debe ingresar 3 imagenes" ForeColor="Red" Display="Dynamic" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row radio-list">
        <div class="col-lg-5">
            <asp:RadioButtonList ID="rblTipoVehiculo" runat="server" OnSelectedIndexChanged="rblTipoVehiculo_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Value="Moto" Selected="True">Moto</asp:ListItem>
                <asp:ListItem Value="Auto">Auto</asp:ListItem>
                <asp:ListItem Value="Camion">Camion</asp:ListItem>
            </asp:RadioButtonList>
        </div>
    </div>
    <br />
    <div class="row" id="rowCilindrada">
        <div class="col-lg-5">
            <asp:TextBox ID="txtCilindrada" min="1" Visible="true" runat="server" CssClass="form-control" placeholder="Cilindrada"></asp:TextBox>
        </div>
    </div>

    <div class="row" id="rowNumPasajeros">
        <div class="col-lg-5">
            <asp:TextBox ID="txtNumeroPasajeros" min="1" Visible="false" runat="server" CssClass="form-control" placeholder="Número de Pasajeros"></asp:TextBox>
        </div>
    </div>

    <div class="row" id="rowToneladasCarga">
        <div class="col-lg-5">
            <asp:TextBox ID="txtToneladasCarga" min="1" Visible="false" runat="server" CssClass="form-control" placeholder="Toneladas de Carga"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-5">
            <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" ValidationGroup="Guardar" Text="Guardar" OnClick="btnGuardar_Click" />
        </div>
    </div>

    <hr />

    <div class="row">
        <div class="col-lg-12">
            <h3>Listado de Vehículos</h3>
            <asp:GridView ID="gvVehiculos" runat="server" CssClass="table"
                OnRowCancelingEdit="gvVehiculos_RowCancelingEdit"
                OnRowDeleting="gvVehiculos_RowDeleting"
                OnRowEditing="gvVehiculos_RowEditing"
                OnRowUpdating="gvVehiculos_RowUpdating"
                AutoGenerateColumns="false"
                DataKeyNames="Matricula">
                <Columns>
                    <asp:TemplateField HeaderText="Matricula" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lbl1" runat="server" Text='<%# Bind("Matricula") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lbl2" runat="server" Text='<%# Bind("Matricula") %>'></asp:Label>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Marca" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lbl3" runat="server" Text='<%# Bind("Marca") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtMarcaGrid" runat="server" Text='<%# Bind("Marca") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Modelo" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lbl23" runat="server" Text='<%# Bind("Modelo") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtModeloGrid" runat="server" Text='<%# Bind("Modelo") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Precio Venta" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lbl27" runat="server" Text='<%# Bind("PrecioVenta") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPrecioVentaGrid" runat="server" Text='<%# Bind("PrecioVenta") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Precio Alquiler" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lbl28" runat="server" Text='<%# Bind("PrecioAlquilerDia") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPrecioAlquilerGrid" runat="server" Text='<%# Bind("PrecioAlquilerDia") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Activo" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lbl29" runat="server" Text='<%# Bind("Activo") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtActivoGrid" runat="server" Text='<%# Bind("Activo") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Imagen 1" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Image ID="lbl20" runat="server" ImageUrl='<%# Bind("Imagen1") %>' Width="200"></asp:Image>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtImagen1Grid" runat="server" Text='<%# Bind("Imagen1") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>


                    <asp:CommandField ShowEditButton="True" ControlStyle-Width="50" />
                    <asp:CommandField ShowDeleteButton="True" ControlStyle-Width="50" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
