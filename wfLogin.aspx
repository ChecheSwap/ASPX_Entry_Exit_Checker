<%@ Page Title="Login" Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfLogin.aspx.cs" Inherits="checadorAsp.wfLogin" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br>
    <div class="page-header">
        <h1>Iniciar Sesión</h1>
    </div>

    <asp:UpdatePanel ID="panelx" runat="server" UpdateMode="Conditional">

    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnInicio" EventName="Click" />
    </Triggers>

    <ContentTemplate>
    <div class="jumbotron"> 
        <div class="form-group">
          <center>
            <div class="panel-group">
                <div class="panel">
                    <div class="panel-heading" style="background-color:darkgray">                                                       
                        <img src="Media/secrecy-icon.png" class="card-img-top" width="150 px" height="150 px" align="center">    
                         Credenciales de Acceso                                 
                    </div>
                        <div class="panel-body">
               
                            <label>*Usuario:</label>
                            <br />
                            <asp:TextBox ID="txtusuario" runat="server" BorderColor="#999999" Width="450 px" height="30px"></asp:TextBox>
                            <br />
                            <label >*Password:</label>
                            <br />
                            <asp:TextBox ID="txtpassword" runat="server" BorderColor="#999999" Width="450 px" height="30px" TextMode="Password"></asp:TextBox>
                            <br />
                            <br />
                            <asp:Button class="btn btn-primary btn-block" id="btnInicio" runat="server"  Text="Acceder" width="450 px"  OnClick="btnInicio_Click"/>
                            <br />

                        </div>
                   </div>
            </div>
        </center>            
        </div>
    </div>


    </ContentTemplate>
    
    </asp:UpdatePanel>


</asp:Content>