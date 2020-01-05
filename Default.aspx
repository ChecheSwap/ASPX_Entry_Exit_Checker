<%@ Page Title="Registro de Asistencia" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="checadorAsp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <br>
    <div class="page-header">
        <h1>Registro de Asistencia</h1>
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
        <div class="container">
          <center>
            <asp:Label ID="Label1" runat="server" Text="Folio de Usuario:"></asp:Label>
            <asp:TextBox ID="txtfolio" runat="server" Height="19px"></asp:TextBox>  
            <br>
            <asp:Button ID="btnreg" runat="server" Text="Registrar" OnClick="btnreg_Click" />
          </center>
        </div>
    </div>

    <div class="jumbotron">

        <asp:UpdatePanel runat="server" id="UpdatePanel" updatemode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger controlid="btnreg" eventname="Click" />
        </Triggers>
            <ContentTemplate>
       <div class="row">
            <asp:Table ID="tab1" runat="server" BorderStyle="Solid" Width="100%">
                <asp:TableRow>
                    <asp:TableCell style="background-color:lightgray;border-style:Solid;" HorizontalAlign="Center">-Clave de Usuario</asp:TableCell>
                    <asp:TableCell style="background-color:lightgray;border-style:Solid;" HorizontalAlign="Center">-Fecha Chequeo</asp:TableCell>
                    <asp:TableCell style="background-color:lightgray;border-style:Solid;" HorizontalAlign="Center">-Hora Chequeo</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>             
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</asp:Content>
