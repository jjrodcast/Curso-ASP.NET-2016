<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="GestionarPermisos.aspx.cs" Inherits="CapaPresentacion.GestionarPermisos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">
    <asp:UpdatePanel ID="upPanel" runat="server">
        <ContentTemplate>
            <section class="content-header">
                <h1 style="text-align: center">GESTIONAR PERMISOS</h1>
            </section>
            <section class="content">
                <div class="box-header">
                    <h3 style="text-align: center" class="box-title">DATOS DEL EMPLEADO</h3>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="box box-primary">
                            <div class="box-body">
                                <div class="form-group">
                                    <label>DOCUMENTO DE IDENTIDAD</label>
                                </div>
                                <div class="input-group">
                                    <asp:TextBox ID="txtDNI" CssClass="form-control" runat="server" MaxLength="8"></asp:TextBox>
                                    <div class="input-group-btn">
                                        <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-danger" Text="BUSCAR" OnClick="btnBuscar_Click" />
                                    </div>
                                </div>
                                <br />
                                <div class="form-group">
                                    <label>NOMBRES</label>
                                    <asp:TextBox ID="txtNombres" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>APELLIDOS</label>
                                    <asp:TextBox ID="txtApellidos" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="box box-primary">
                            <br />
                            <div class="box-body">
                                <div class="form-group">
                                    <label>NRO. DOCUMENTO</label>
                                    <asp:TextBox ID="txtNroDocumento" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>TIPO EMPLEADO</label>
                                    <asp:TextBox ID="txtTipoEmpleado" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>USUARIO</label>
                                    <asp:TextBox ID="txtUsuario" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <section class="content-header">
                    <h3 style="text-align: center">PERMISOS ASIGNADOS</h3>
                </section>
                <div class="row">
                    <div class="col-md-12">
                        <div class="box box-primary">
                            <div class="box-header"></div>
                            <div class="box-body">
                                <div class="row">
                                    <div class="col-md-12">
                                        <asp:GridView ID="grdPermisosAsignados" runat="server" CssClass="table table-bordered table-hover text-center" AutoGenerateColumns="false">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblHeaderAsignar" runat="server" Text="SELECCIONAR"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkSeleccionar" runat="server" Checked="true" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblHeaderNombre" runat="server" Text="NOMBRE"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="hfIdMenu" Visible="false" runat="server" Value='<%#Eval("IdMenu") %>' />
                                                        <asp:Label ID="lblNombreMenu" runat="server" Text='<%#Eval("Nombre") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblHeaderRuta" runat="server" Text="RUTA"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRutaMenu" runat="server" Text='<%#Eval("Url") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblHeaderIsSubMenu" runat="server" Text="SUBMENÚ"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblIsSubMenu" runat="server" Text='<%#(Convert.ToBoolean(Eval("IsSubMenu")) == true)? "Si":"No" %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblHeaderMenuPrincipal" runat="server" Text="MENÚ PRINCIPAL"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="hfIdParentMenu" runat="server" Visible="false" Value='<%#Eval("IdMenuParent") %>' />
                                                        <asp:Label ID="lblPadreMenu" runat="server" Text='<%#((Eval("SubMenu") as List<CapaEntidades.Menu>).Count > 0)? (Eval("SubMenu") as List<CapaEntidades.Menu>)[0].Nombre : "" %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12 text-center">
                                        <asp:Button ID="btnRemover" runat="server" CssClass="btn btn-danger" Text="REMOVER PERMISOS" OnClick="btnRemover_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <section class="content-header">
                    <h3 style="text-align: center">PERMISOS NO ASIGNADOS</h3>
                </section>
                <div class="row">
                    <div class="col-md-12">
                        <div class="box box-primary">
                            <div class="box-header"></div>
                            <div class="box-body">
                                <div class="row">
                                    <div class="col-md-12">
                                        <asp:GridView ID="grdPermisosNoAsignados" runat="server" CssClass="table table-bordered table-hover text-center" AutoGenerateColumns="false">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblHeaderAsignar" runat="server" Text="SELECCIONAR"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkSeleccionar" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblHeaderNombre" runat="server" Text="NOMBRE"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="hfIdMenu" Visible="false" runat="server" Value='<%#Eval("IdMenu") %>' />
                                                        <asp:Label ID="lblNombreMenu" runat="server" Text='<%#Eval("Nombre") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblHeaderRuta" runat="server" Text="RUTA"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRutaMenu" runat="server" Text='<%#Eval("Url") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblHeaderIsSubMenu" runat="server" Text="SUBMENÚ"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblIsSubMenu" runat="server" Text='<%#(Convert.ToBoolean(Eval("IsSubMenu")) == true)? "Si":"No" %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblHeaderMenuPrincipal" runat="server" Text="MENÚ PRINCIPAL"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="hfIdParentMenu" runat="server" Visible="false" Value='<%#Eval("IdMenuParent") %>' />
                                                        <asp:Label ID="lblPadreMenu" runat="server" Text='<%#((Eval("SubMenu") as List<CapaEntidades.Menu>).Count > 0)? (Eval("SubMenu") as List<CapaEntidades.Menu>)[0].Nombre : "" %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12 text-center">
                                        <asp:Button ID="btnAsignar" runat="server" CssClass="btn btn-primary" Text="ASIGNAR PERMISOS" OnClick="btnAsignar_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <asp:HiddenField ID="hfIdEmpleado" runat="server" Visible="false" Value="0" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
