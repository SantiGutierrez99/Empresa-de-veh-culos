<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Alquileres.aspx.cs" Inherits="TestObligatorioP2.Alquileres" %>

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


        .row {
            margin-bottom: 20px;
        }

        h1 {
            color: #6a5acd;
            margin-bottom: 0;
        }

        h3 {
            color: #6a5acd;
            margin-top: 10px;
        }

        .form-control {
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

        #lblPrecioSimbolo,
        #lblPrecio {
            color: red;
            font-weight: bold;
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
            <h3>Registro de Alquiler</h3>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-5">
            Clientes:
                <asp:DropDownList ID="lstClientes" runat="server" CssClass="form-control" DataTextField="Cedula" DataValueField="Cedula"></asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-5">
            Vehiculos:
                <asp:DropDownList ID="cboVehiculos" runat="server" CssClass="form-control" DataTextField="Matricula" DataValueField="Matricula" AutoPostBack="true" OnSelectedIndexChanged="cboVehiculos_SelectedIndexChanged"></asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-5">
            Fecha:
                <asp:TextBox ID="txtFecha" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvFecha" runat="server" ControlToValidate="txtFecha"
                ErrorMessage="Ingrese la fecha de inicio del alquiler" ForeColor="Red" Display="Dynamic" ValidationGroup="Guardar">
            </asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-5">
            Días de Alquiler:
                <asp:TextBox ID="txtDiasAlquiler" min="1" type="number" runat="server" placeholder="Ingrese los dias del alquiler" CssClass="form-control" oninput="calcularPrecio();" ClientIDMode="Static" OnTextChanged="txtDiasAlquiler_TextChanged"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvDiasAlquiler" runat="server" ControlToValidate="txtDiasAlquiler"
                ErrorMessage="Ingrese la cantidad de días" ForeColor="Red" Display="Dynamic" ValidationGroup="Guardar">
            </asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-5">
            <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" ValidationGroup="Guardar" Text="Guardar" OnClick="btnGuardar_Click" />
        </div>
    </div>
    <div class="row">
        <div class="col-lg-5">
            <asp:Label ID="lblPrecio" ForeColor="Blue" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="lblPrecioSimbolo" ForeColor="Blue" runat="server" Visible="false">$</asp:Label>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-12">
            <h3>Listado de Alquileres</h3>
            <asp:GridView ID="gridAlquileres" runat="server" AutoGenerateColumns="False" CssClass="table" DataKeyNames="numAlquiler">
                <Columns>
                    <asp:TemplateField HeaderText="Numero de Alquiler" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lbl10" runat="server" Text='<%# Bind("numAlquiler") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="150px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Matricula" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lbl11" runat="server" Text='<%# Bind("Matricula") %>'></asp:Label>

                        </ItemTemplate>
                        <ItemStyle Width="150px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Tipo" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblTipo" runat="server" Text='<%#ObtenerTipoVehiculo(Eval("Matricula"))%>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="150px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Marca" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblMarca" runat="server" Text='<%#ObtenerMarcaVehiculo(Eval("Matricula"))%>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="150px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Documento Cliente" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lbCedula" runat="server" Text='<%# ObtenerDocumentoCliente(Eval("Cedula"))%>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="150px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre Cliente" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblNombre" runat="server" Text='<%#ObtenerNombreApellidoCliente(Eval("Cedula")) %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="150px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Precio Alquiler" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblPrecioAlquiler" runat="server" Text='<%#ObtenerPrecioAlquilerVehiculo(Eval("Matricula"), Eval("numAlquiler")) %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="200px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Estado del Vehículo">
                        <ItemTemplate>
                            <asp:Label ID="lblEstadoVehiculo" runat="server" Text='<%# (bool)Eval("EstadoVehiculo") ? "Al día" : "Retrasado" %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>



</asp:Content>
