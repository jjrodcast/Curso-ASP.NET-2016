<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="GestionarAtencionCita.aspx.cs" Inherits="CapaPresentacion.GestionarAtencionCita" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">
    <section class="content-header">
        <div class="text-center">
            <h3>DATOS DEL PACIENTE</h3>
        </div>
    </section>
    <section class="content invoice">
        <div class="row invoice-info">
            <div class="col-sm-3 invoice-col">
                <asp:Image ID="imgPaciente" runat="server" Height="200px" Width="200px" ImageUrl="~/img/avatar5.png" />
            </div>
            <div class="col-sm-5 invoice-col">
                <br />
                <strong>Nombres:</strong>
                <asp:Label ID="lblNombres" runat="server"></asp:Label>
                <br />
                <strong>Apellidos:</strong>
                <asp:Label ID="lblApellidos" runat="server"></asp:Label>
                <br />
                <strong>Edad:</strong>
                <asp:Label ID="lblEdad" runat="server"></asp:Label>
                <br />
                <strong>Sexo:</strong>
                <asp:Label ID="lblSexo" runat="server"></asp:Label>
            </div>
            <div class="col-sm-4 invoice-col">
                <br />
                <strong>Observaciones</strong>
                <br />
                <asp:TextBox ID="txtObservaciones" runat="server" TextMode="MultiLine" Width="100%" Height="150px"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <br />
            <div class="col-sm-12 invoice-col">
                <br />
                <strong>Diagnóstico</strong>
                <br />
                <asp:TextBox ID="txtDiagnostico" runat="server" TextMode="MultiLine" Width="100%" Height="100px"></asp:TextBox>
            </div>
            <div class="invoice-info">
                <div class="center-block">
                    <div class="col-sm-12 invoice-col">
                        <br />
                        <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="btn btn-block btn-primary" OnClick="btnRegistrar_Click" />
                        <br />
                    </div>
                </div>
            </div>
        </div>
    </section>
    <asp:HiddenField ID="hfIdPaciente" runat="server" Visible="false" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
