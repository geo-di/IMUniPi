<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="IMUnipi.register"  MasterPageFile="~/site.Master"%>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
        <p>
            <asp:Label ID="Label1" runat="server" Text="Username: " for="TextBox1"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br /><br />
           
            <asp:Label ID="Label3" runat="server" Text="Email: "></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server" TextMode="Email"></asp:TextBox>
            <br /> <br />
             <asp:Label ID="Label2" runat="server" Text="Password: "></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
            <br /> <br />

            <asp:Label ID="Label4" runat="server" Text="Confirm Password: "></asp:Label>
            <asp:TextBox ID="TextBox4" runat="server" TextMode="Password"></asp:TextBox>
            <br /><br />

            <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" CssClass="smallbtn" />

        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Label ID="Label5" runat="server" Text="Alreday a member? Log in Here: "></asp:Label><br  />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Log in" CssClass="smallbtn" />

            <br />

        </p>
  </asp:Content> 
