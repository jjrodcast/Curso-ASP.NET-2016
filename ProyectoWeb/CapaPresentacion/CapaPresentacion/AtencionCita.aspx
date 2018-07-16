<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="AtencionCita.aspx.cs" Inherits="CapaPresentacion.AtencionCita" %>

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
                <asp:Label ID="lblNombres" runat="server" Text=""></asp:Label>
                <br />
                <strong>Apellidos:</strong>
                <asp:Label ID="lblApellidos" runat="server" Text=""></asp:Label>
                <br />
                <strong>Edad:</strong>
                <asp:Label ID="lblEdad" runat="server" Text=""></asp:Label>
                <br />
                <strong>Sexo:</strong>
                <asp:Label ID="lblSexo" runat="server" Text=""></asp:Label>
                <br />
            </div>
            <div class="col-sm-4 invoice-col">
                <br />
                <strong>Observaciones</strong>
                <br />
                <asp:TextBox ID="txtObservaciones" runat="server" Width="100%" Height="150px" TextMode="MultiLine"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <br />
            <div class="col-sm-12 invoice-col">
                <br />
                <strong>Diagnóstico</strong>
                <br />
                <asp:TextBox ID="txtDiagnostico" runat="server" Width="100%" Height="90px" TextMode="MultiLine"></asp:TextBox>
            </div>
            <div class="invoice-info">
                <div class="center-block">
                    <div class="col-sm-12 invoice-col">
                        <br />
                        <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-block btn-primary" Text="Registrar" />
                        <br />
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
