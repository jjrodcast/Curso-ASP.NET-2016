<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BadRequest.aspx.cs" Inherits="CapaPresentacion.BadRequest" MasterPageFile="~/Home.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- PONER LOS SCRIPT Y ESTILOS PARA ALGUNOS CONTROLES O DISEÑO ESPECIFICOS-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">
    <div class="text-center">
        <h3>No tiene permisos para acceder a la ruta. Habilitar los permisos y volver a iniciar sesión.</h3>
        <br />
        <asp:Button ID="btnReturn" CssClass="btn btn-primary" runat="server" Text="Regresar" OnClick="btnReturn_Click" />
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
