<%@ Page Language="C#" Title="Consultas" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfConsulta.aspx.cs" Inherits="checadorAsp.wfConsulta" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br>
    <div class="page-header">
        <h1>Consultas de Movimientos</h1>
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
            <div class="container">
                <label for="txtfolio">Folio de Usuario</label>
                <asp:TextBox ID="txtfolio" runat="server" Height="19px" Width="200px"></asp:TextBox>  
                <label for="txtnombre">Nombre Usuario</label>
                <asp:TextBox ID="txtnombre" runat="server" Height="19px" Width="200px"></asp:TextBox>  
            </div>
            <br>
                <div class="container">
                <label for="txtfecha">Fecha Inicial</label>
                <asp:TextBox ID="txtfecha" runat="server" TextMode="Date" Height="19px" Width="200px"/>
                <label for="txtfechafinal">Fecha Final</label>
                <asp:TextBox ID="txtfechafinal" runat="server" TextMode="Date" Height="19px" Width="200px"/>
            </div>
            <br>
            <asp:Button ID="btnreg" runat="server" Text="Buscar" OnClick="btnreg_Click" />
            <asp:Button ID="btnall" runat="server" Text="Buscar Todo" OnClick="btnall_Click"/>
            <asp:Button ID="btnExcel" runat="server" Text="Generar Pdf" OnClick="btnExcel_Click"/>
          </center>
        </div>
    </div>

    <div class="jumbotron">        
        <asp:UpdatePanel runat="server" id="UpdatePanel" updatemode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger controlid="btnreg" eventname="Click" />
        </Triggers>
            <ContentTemplate>
            <asp:Label ID="lblcount" runat="server"/>
            <div class="row">
                <asp:Table ID="tab1" runat="server" BorderStyle="Solid" Width="100%">
                    <asp:TableRow>
                        <asp:TableCell style="background-color:lightgray;border-style:Solid;" HorizontalAlign="Center">-Clave de Usuario</asp:TableCell>
                        <asp:TableCell style="background-color:lightgray;border-style:Solid;" HorizontalAlign="Center">-Nombre Usuario</asp:TableCell>
                        <asp:TableCell style="background-color:lightgray;border-style:Solid;" HorizontalAlign="Center">-Fecha Chequeo</asp:TableCell>
                        <asp:TableCell style="background-color:lightgray;border-style:Solid;" HorizontalAlign="Center">-Hora Chequeo</asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </div>             
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <asp:UpdatePanel runat="server" id="UpdatePanel1" updatemode="Conditional">
    <Triggers>
        <asp:AsyncPostBackTrigger controlid="btnExcel" eventname="Click" />
    </Triggers>
    </asp:UpdatePanel>

</asp:Content>