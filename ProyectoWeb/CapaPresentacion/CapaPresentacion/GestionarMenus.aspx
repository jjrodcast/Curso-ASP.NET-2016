<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="GestionarMenus.aspx.cs" Inherits="CapaPresentacion.GestionarMenus" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .check-height {
            height: 34px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">
    <section class="content-header">
        <h1 style="text-align: center">GESTIONAR MENÚS</h1>
    </section>
    <section class="content">
        <div class="row">
            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-body">
                        <div class="form-group">
                            <label>NOMBRE</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtNombrePermiso" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>SUBMENÚ</label>
                        </div>
                        <div class="form-group">
                            <asp:CheckBox ID="chkIsSubmenu" runat="server" Height="34px" />
                        </div>
                        <br />
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-body">
                        <div class="form-group">
                            <label>RUTA</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtUrlPermiso" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>MENÚ PRINCIPAL</label>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList ID="ddlMenuPrincipal" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <br />
                    </div>
                </div>
            </div>
        </div>
        <div class="text-center">
            <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-primary" Text="REGISTRAR MENÚ" OnClick="btnRegistrar_Click" />
        </div>
        <br />
        <br />

        <div class="row">
            <div class="col-xs-12">
                <div class="box box-primary">
                    <div class="box-header">
                        <h3 class="box-title">Lista de Menús</h3>
                    </div>
                    <div class="box-body table-responsive">
                        <table id="tbl_menus" class="table table-bordered table-hover text-center">
                            <thead>
                                <tr>
                                    <th>Código</th>
                                    <th>Nombre</th>
                                    <th>Ruta</th>
                                    <th>Activo/Inactivo</th>
                                    <th>Sub-Menú</th>
                                    <th>Menu Padre</th>
                                    <th>Acciones</th>
                                </tr>
                            </thead>
                            <tbody>
                                <!-- DATA POR MEDIO DE AJAX-->
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>

        <div class="modal fade" id="imodal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="myModalLabel">Actualizar Permiso</h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label>NOMBRE</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtANombrePermiso" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>RUTA</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtAUrlPermiso" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>MENÚ PRINCIPAL</label>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList ID="ddlAMenuPrincipal" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>SUBMENÚ</label>
                        </div>
                        <div class="form-group">
                            <asp:CheckBox ID="chkAIsSubmenu" runat="server" />
                        </div>
                        <div class="form-group">
                            <label>ACTIVAR</label>
                        </div>
                        <div class="form-group">
                            <asp:CheckBox ID="chkAActivo" runat="server" />
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-primary" id="btnactualizar">Actualizar</button>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
    <script src="js/menus.js" type="text/javascript"></script>
</asp:Content>
