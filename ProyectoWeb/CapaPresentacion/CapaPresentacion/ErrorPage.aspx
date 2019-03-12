<%@ Page Title="" Language="C#" MasterPageFile="~/MasterError.Master" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="CapaPresentacion.ErrorPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">
    <div class="text-center">
        <h3>La ruta indicada no existe.</h3>
        <br />
        <asp:Button ID="btnReturnError" runat="server" OnClick="btnReturnError_Click" Text="Regresar" CssClass="btn btn-primary" />
    </div>
</asp:Content>
