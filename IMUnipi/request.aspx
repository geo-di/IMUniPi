<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="request.aspx.cs" Inherits="IMUnipi.request" MasterPageFile="~/site.Master"%>

    <asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
        <section style="color:#000000">
        <div>
            <h2><asp:Label ID="Label1" runat="server" Text="Request Any Video Clip for us to review!!"></asp:Label></h2>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Song Title"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox1" runat="server" MaxLength="45"></asp:TextBox>
            <br />
            <asp:Label ID="Label7" runat="server" Text="Artist"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox3" runat="server" MaxLength="45"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Video Clip Category"></asp:Label>
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server" >
                <asp:ListItem>Category</asp:ListItem>
                <asp:ListItem>Rap</asp:ListItem>
                <asp:ListItem>Pop</asp:ListItem>
                <asp:ListItem>Rock</asp:ListItem>
                <asp:ListItem>Classic</asp:ListItem>
                <asp:ListItem>Metal</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Video Clip Description"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox2" runat="server" Height="112px" MaxLength="500"></asp:TextBox>
            <br />
            <br />
            <h3><asp:Label ID="Label5" runat="server" Text="Video Clip"></asp:Label></h3>
            <br />
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Label ID="Label6" runat="server" Text="  Max File SIze: 1GB"></asp:Label>
            <br />
            <asp:RegularExpressionValidator ID="uploadifilevalidator" runat="server" ErrorMessage="Only video files to be uploaded." ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))(.mp4|.MP$|.gif|.GIF|.mkv|.MKV)$" ControlToValidate="FileUpload1"></asp:RegularExpressionValidator>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Submit Request" CssClass="smallbtn"/>
        </div>
            </section>
   </asp:Content>
