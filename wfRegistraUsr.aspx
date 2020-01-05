<%@ Page Title= "Actualizar Datos de Usuario" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfRegistraUsr.aspx.cs" Inherits="checadorAsp.wfRegistraUsr" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br>
    <div class="page-header">
        <h1>Registro de Usuarios</h1>
    </div>

    <asp:UpdatePanel ID="panelLog" runat="server" UpdateMode="Conditional">
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnLog" EventName="Click" />
    </Triggers>
        <ContentTemplate>
        <asp:Button class="btn btn-danger" ID="btnLog" runat="server" OnClientClick="return confirm('Desea Salir?');" Text="Cerrar Sesion" OnClick="btnLog_Click"/>
        </ContentTemplate>
    </asp:UpdatePanel>

    <div class="jumbotron"> 
    <div class="container-fluid">  
        <center>
        <div class="row">
            <div class="col-md-4">
                <label for="txtfolio">Folio de Usuario</label>
                <asp:TextBox ID="txtfolio" runat="server" Height="19px" Width="200px" ReadOnly="true"></asp:TextBox>  
            </div>
            <div class="col-md-4">
                <label for="txtnombre">Nombre Usuario</label>
                <asp:TextBox ID="txtnombre" runat="server" Height="19px" Width="200px"></asp:TextBox>  
            </div>
            <div class="col-md-4">
                <label for="txtapellido">Apellido Usuario</label>
                <asp:TextBox ID="txtapellido" runat="server" Height="19px" Width="200px"></asp:TextBox>  
            </div>
        </div>        
        <br>   
        <asp:Button ID="btnGuardaUsr" runat="server" Text="Guardar" width="350 px" OnClick="btnGuardaUsr_Click"/>            
        </center>                          
    </div>
    </div>               

    <asp:UpdatePanel ID="UpdatePanel33" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnGuardaUsr" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>