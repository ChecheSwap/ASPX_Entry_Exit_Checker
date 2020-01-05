<%@ Page Language="C#" Title="Manipular Usuarios" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfUpdateUsr.aspx.cs" Inherits="checadorAsp.wfUpdateUsr" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br>
    <div class="page-header">
        <h1>Panel de Usuarios</h1>
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
        <center>
            <label for="txtcabecero">Folio de Usuario</label>
            <asp:TextBox ID="txtcabecero" runat="server" Height="19px" Width="200px" ></asp:TextBox> 
            <br /> 
            <asp:Button ID="btnbusqueda" runat="server" Text="Cargar Usuario" width="350 px" OnClick="btnbusqueda_Click"/>            
        </center>
    </div>

    <div class="jumbotron"> 
    <div class="container-fluid">  
        <center>
        <div class="row">
            <div class="col-md-4">
                <label for="txtfolio">Folio de Usuario</label>
                <asp:TextBox ID="txtfolio" runat="server" Height="25px" Width="200px" ReadOnly="true"></asp:TextBox>  
            </div>
            <div class="col-md-4">
                <label for="txtnombre">Nombre Usuario</label>
                <asp:TextBox ID="txtnombre" runat="server" Height="25px" Width="350px"></asp:TextBox>  
            </div>
            <div class="col-md-4">
                <label for="txtapellido">Apellido Usuario</label>
                <asp:TextBox ID="txtapellido" runat="server" Height="25px" Width="350px"></asp:TextBox>  
            </div>
        </div>        
        <br>   
        <asp:Button ID="btnGuardaUsr" runat="server" Text="Actualizar Datos" width="250 px" OnClick="btnGuardaUsr_Click" OnClientClick="return confirm('Desea Actualizar el Usuario?');"/>                                    
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar Usuario" width="250 px"  OnClientClick="return confirm('Desea Eliminar Usuario y todo su historial?');" OnClick="btnEliminar_Click"/>                                    
        </center>                          
    </div>
    </div>         

    <asp:UpdatePanel ID="UpdatePanelConsulta" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnbusqueda" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>  

    <asp:UpdatePanel ID="UpdatePanelUpdate" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnGuardaUsr" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanelDelete" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnEliminar" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>