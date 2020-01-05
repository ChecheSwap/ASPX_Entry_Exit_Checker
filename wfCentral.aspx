<%@ Page Language="C#" Title="Menu Central" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfCentral.aspx.cs" Inherits="checadorAsp.wfCentral" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<br />
<div class="page-header">
    <h1>Menu</h1>
</div>

    <asp:UpdatePanel ID="panelLog" runat="server" UpdateMode="Conditional">
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnLog" EventName="Click" />
    </Triggers>
        <ContentTemplate>
        <asp:Button class="btn btn-danger" ID="btnLog" runat="server" OnClientClick="return confirm('Desea Salir?');" Text="Cerrar Sesion" OnClick="btnLog_Click"/>
        </ContentTemplate>
    </asp:UpdatePanel>

<div class="container-fluid">
  <div class="jumbotron">
      <div class="row">
        <div class="col-sm-4">            
            <div class="card">
              <div class="text-center">
                <img src="Media/clock.png" class="card-img-top" width="150 px" height="150 px" align="center">
              </div>
              <div class="card-body">                
                <p class="card-text text-center">Registrar Asistencia</p>
                <asp:Button id="btnA" runat="server" class="btn btn-primary btn-block" Text="Abrir" OnClick="btnA_Click" />
              </div>
            </div>
        </div>


        <div class="col-sm-4">            
            <div class="card">
              <div class="text-center">
                <img src="Media/lupa.png" class="card-img-top" width="150 px" height="150 px" align="center">
              </div>
              <div class="card-body">                
                <p class="card-text text-center">Consulta de Movimientos</p>
                <asp:Button id="Button1" runat="server" class="btn btn-primary btn-block" Text="Abrir" OnClick="Button1_Click" />
              </div>
            </div>
        </div>

        <div class="col-sm-4">            
            <div class="card">
              <div class="text-center">
                <img src="Media/add_user_group-512.png" class="card-img-top" width="150 px" height="150 px" align="center">
              </div>
              <div class="card-body">                
                <p class="card-text text-center">Registrar Usuario</p>
                <asp:Button id="Button2" runat="server" class="btn btn-primary btn-block" Text="Abrir" OnClick="Button2_Click" />
              </div>
            </div>
        </div>
     </div>

      <div class="row">
        <div class="col-sm-4">            
            <div class="card">
              <div class="text-center">
                <img src="Media/refresh_user_man-512.png" class="card-img-top" width="150 px" height="150 px" align="center">
              </div>
              <div class="card-body">                
                <p class="card-text text-center">Manipular Usuarios</p>
                <asp:Button id="Button3" runat="server" class="btn btn-primary btn-block" Text="Abrir" OnClick="Button3_Click" />
              </div>
            </div>
        </div>  
      </div>              
  </div>
</div>
</asp:Content>