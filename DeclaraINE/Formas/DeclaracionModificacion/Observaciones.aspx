<%@ Page Title="" Language="C#" MasterPageFile="~/Formas/DeclaracionModificacion/_Modificacion.master" AutoEventWireup="true" CodeBehind="Observaciones.aspx.cs" Inherits="DeclaraINE.Formas.DeclaracionModificacion.Observaciones" Culture="es-MX" UICulture="es-MX" %>

<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent2" runat="server">
    <style>
     .VerDoc {
            padding: 7px 7px 7px 30px;
            font-size: 14px;
            font-weight: normal;
            text-align: center;
            white-space: nowrap;
            vertical-align: middle;
            -ms-touch-action: manipulation;
            touch-action: manipulation;
            cursor: pointer;
            -webkit-user-select: none;
            -moz-user-select: none;
            -ms-user-select: none;
            user-select: none;
            border: .5px solid transparent;
            border-radius: 4px;
            border-color: #afafaf;
            color: #000;
            background-image: url(../../Images/icons/ColorX24/Search.png);
            background-repeat: no-repeat;
            background-position: left;
        }

    #btnDocumento:disabled {

    color: #e3e3e3;
    border-color: #e3e3e3;
    cursor:none;

}
</style>
    <%-- <script type="text/javascript">
        function nombrecampo(nombre, area, maximo) {
            NombreTXT = nombre;
            limite = maximo;
            numeroDeC = area.value.length;

            if (numeroDeC > limite) {
                area.value = area.value.substring(0, limite);
            }
            else {
                if (NombreTXT == "txtObservaciones") {
                    $('#<%=txtcuenta.ClientID%>').val(Text = "Número de caractéres capturados:" + numeroDeC);
                }
            }
        }
    </script>--%>


    <%-- <asp:AlanQuestionBox runat="server" ID="QstBox" NoText="No" YesText="Si" OnNo="QstBox_No" OnYes="QstBox_Yes"  YesCssClass="" NoCssClass="" />

    <div class="subtitulo">
        <asp:Literal ID="ltrSubTitulo" runat="server" Text="Observaciones y Aclaraciones"></asp:Literal>
    </div>
    <asp:AlanMessageBox runat="server" ID="MsgBox" />
    <asp:AlanAlert runat="server" ID="AlertaSuperior" />
 <div id="cuerpo">
       <%-- <asp:TextBox ID="txtcuenta" Text="Número de caractéres capturados: 0" runat="server" BackColor="#EEEEEE" ReadOnly="True"></asp:TextBox>
        <asp:TextBox ID="TextBox1" Text="Número máximo de caracteres permitidos: 1000" runat="server" BackColor="#EEEEEE" ReadOnly="True"></asp:TextBox>
        <asp:TextBox ID="txtObservaciones" runat="server" onkeyDown="nombrecampo('txtObservaciones',this,'1000')"
            onkeyup="nombrecampo('txtObservaciones',this,'1000')" MaxLength="1000" TextMode="MultiLine" Width="100%"></asp:TextBox>

    </div>--%>



    <div class="modal-dialog" style="display: contents;">
        <%--  <Triggers>
             <asp:PostBackTrigger ControlID = "idConducta_Click"/>
     </Triggers>--%>
        <div class="modal-content" style="margin: 3% 10% 2% 10%;">
            <div class="modal-body etica" style="margin: 0px 2% 0px; max-height: none;">
                <h3 class="subtitulo" style="text-align: center; font-weight: bold; margin: 3px 0; padding: 0px 0px 17px; background-color: #ffffff;">COMUNIDAD INAI</h3>
                <p style="text-align: justify">Derivado de la aprobación del Código de Ética, por parte del Órgano Interno de Control, el cual contiene los principios, valores y reglas
                    de integridad de los funcionarios públicos del INAI, lo hacemo de tu conocimiento, a fin de que en el desarrollo de tus funciones conduzcas tu comportamiento apegado
                    al código, como integrante del INAI.</p>
                <br />
                <br />
                <p style="text-align: justify"><a style="font-weight: bold">El Código de Ética </a>contiene y abarca los principios constitucionales, los valores y reglas de integridad en el 
                    ejercicio de nuestro servicio público, explicados de manera sencilla para facilitar su comprensión por nosotros, quienes formamos parte del servicio público, así como de los
                    particulares vinculados al mismo.</p>
                <p style="text-align: right">
                <p style="text-align: right">
                    <div class="  button-container" style="text-align: right;">
                        <asp:Button ID="btnsBuscaridEtica" Style="background-color: #fff;" runat="server" OnClick="idEtica_Click" Text="Ver" />
                    </div>
                </p>
                <br />
                <br />
                
                <p style="text-align: justify"><a style="font-weight: bold">El Código de Conducta </a>busca explicar cómo deben ponerse en práctica los principios y valores contenidos en el 
                    Código de Ética del INAI, así como los estándares de comportamiento que deben guiar la actuación de las funcionarias y funcionarios del INAI.</p>
                <p style="text-align: right">
                    <div class="  button-container" style="text-align: right;">
                        <asp:Button ID="btnsBuscaridConducta" Style="background-color: #fff;" runat="server" Text="Ver" OnClick="idConducta_Click" ClientIDMode="Static" />
                    </div>
                </p>
                
                <p style="text-align: justify">Deberás oprimir el botón de "VER" para poder continuar con tu declaración.</p>
                <br />
                <br />
            </div>
        </div>

    </div>


    <style>
        .etica p {
            font-size: 14px;
            font-weight: normal;
        }
    </style>


    <br />
    <br />
    <br />
    <asp:AlanModalPopUp runat="server" ID="mppAcepta" HeaderText="Confirmar">
        <ContentTemplate>
            <p>En cumplimiento de la normatividad aplicable, declaro BAJO PROTESTA DE DECIR VERDAD que:
                <br/>
                Con la emisión de la presente declaración reconozco que tengo pleno conocimiento del contenido del Código de Ética y Código de Conducta del Instituto Nacional de Transparencia,
                Acceso a la Información y Protección de Datos Personales, por lo tanto, no tengo inconveniente alguno en realizar cuando se me solicite las evaluaciones de conocimiento, comprensión
                y cumplimiento que apruebe el Comité de Ética; comprometiéndome a denunciar los hechos y actos que fueren de mi conocimiento, contrarios a los principios, valores, reglas de integridad
                y reglas de conducta previstas en los códigos mencionados.</p>

            <div class="center">
                <div class="center button-container">
                    <asp:Button ID="btnsGuardar" runat="server" Text="Acepto" OnClick="btnGuardar_Click" Style="background-color: #fff;" ClientIDMode="Static" />
                </div>
            </div>
        </ContentTemplate>
    </asp:AlanModalPopUp>

    <asp:AlanModalPopUp runat="server" ID="mppMensaje">
        <ContentTemplate>
            <p>
                El presente
                <asp:Label ID="lblMensaje" runat="server" Text=""  ></asp:Label>
              
                debe observarse por las personas que desempeñen un
empleo, cargo o comisión de manera permanente o temporal en el Instituto
Nacional de Transparencia, Acceso a la Información y Protección de Datos Personales.
            </p>
            <div class="center button-container">
                <asp:Button ID="btnDocumento" runat="server" Text="Acepto" Enabled="false" Style="background-color: #fff; " OnClick="btnDocumento_Click" ClientIDMode="Static" />
            </div>
        </ContentTemplate>
    </asp:AlanModalPopUp>
    <script>    
       


         function ValidarDescargaEtica() {
             //$('#btnDocumento').show(); 
             $('#btnDocumento').prop( "disabled", false );
            window.open('../../pdf1/etica.pdf', '_blank');
        }
        function ValidarDescargaCodigo() {
            $('#btnDocumento').prop( "disabled", false );
             window.open('../../pdf1/conducta.pdf', '_blank');
            //$('#btnDocumento').show(); 
        }         
    </script>
   
</asp:Content>
