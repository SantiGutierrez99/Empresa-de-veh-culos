<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TestObligatorioP2.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<style>
    body {
        background: url('img/login1.jpg') no-repeat center center fixed;
        background-size: cover;
        font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        color: #fff;
        margin: 0;
        padding: 0;
    }

    .header-container {
        background-color: rgba(0, 0, 0, 0); /* Cambiado a totalmente transparente */
        padding: 20px;
        text-align: center;
    }

    .header-container h1 {
        color: #ff4081;
        margin: 0;
    }

    .container {
        max-width: 400px;
        margin: 20px auto;
        box-shadow: 0 0 20px rgba(0, 0, 0, 0.3);
        padding: 30px;
        border-radius: 10px;
        background-color: rgba(0, 0, 0, 0); /* Cambiado a totalmente transparente */
        border: 2px solid rgba(255, 255, 255, 0.7);
        transition: box-shadow 0.3s ease;
    }

    .container:hover {
        box-shadow: 0 0 30px rgba(255, 255, 255, 0.5);
        background-color: rgba(0, 0, 0, 0); /* Cambiado a totalmente transparente */
    }

    h1 {
        color: #000;
        margin-bottom: 0;
    }

    h3 {
        color: #000;
        margin-top: 10px;
    }

    .form-control {
        width: calc(100% - 20px);
        padding: 15px;
        margin-bottom: 20px;
        box-sizing: border-box;
        border: 1px solid rgba(255, 255, 255, 0.5); /* Añadido borde */
        border-radius: 5px;
        background-color: rgba(0, 0, 0, 0); /* Cambiado a totalmente transparente */
        transition: border 0.3s ease, box-shadow 0.3s ease;
    }

    .form-control:focus {
        border: 1px solid rgba(255, 255, 255, 0.9);
        box-shadow: 0 0 10px rgba(255, 255, 255, 0.5);
        background-color: rgba(0, 0, 0, 0); /* Cambiado a totalmente transparente */
    }

    .btn-primary {
        background-color: rgba(0, 0, 0, 0.7);
        color: #fff;
        padding: 15px;
        border: none;
        border-radius: 5px;
        cursor: pointer;
        transition: background-color 0.3s ease;
    }

    .btn-primary:hover {
        background-color: rgba(0, 0, 0, 0.9);
    }

    #lblError {
        color: red;
        font-weight: bold;
    }
</style>


    <div class="container">
        <div class="row">
            <div class="col-lg-12 text-center">
                <h1 class="mt-5">Automotora Fast</h1>
                <h3>Login</h3>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12 mx-auto">
                <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" placeholder="Usuario"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12 mx-auto">
                <asp:TextBox ID="txtContrasena" TextMode="Password" runat="server" CssClass="form-control" placeholder="Contraseña"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12 mx-auto">
                <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary btn-block" Text="Ingresar" OnClick="btnGuardar_Click" />
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12 mx-auto">
                <asp:Label ID="lblError" runat="server" Visible="false" CssClass="text-danger">Usuario y/o contraseña incorrectos</asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
