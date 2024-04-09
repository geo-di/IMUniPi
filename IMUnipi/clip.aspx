<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="clip.aspx.cs" Inherits="IMUnipi.clip" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <h1 style="z-index:100;color:black;margin-right:5%" id="clipname" runat="server"></h1>
            <br/>
            <div style="text-align: center;">
                <video id="vid" autoplay="autoplay" muted="muted" controls="controls" runat="server" >
                    <source type="video/mp4"/>
                    
                    Your browser does not support HTML video.
                    </video>
                <div style="padding:2%;margin-top:2%;line-height:200%">
                    <br />
                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                </div>
            </div>   
     </section>

    <section>
        <div class="container">
            
            <asp:Button ID="Button2" CssClass="button" runat="server" Text="Log In to Write a Review" OnClick="Button2_Click" />
            <br />
            <asp:Label ID="Label8" runat="server" Text="Write us your review here!" Width="100%"></asp:Label>
            
            <br />
            <asp:TextBox ID="TextBox1" runat="server"   Width="100%"></asp:TextBox>
            <asp:Label ID="Label9" runat="server" Text="Give A Rate" Width="40%" Style="margin-top:2%;margin-bottom:1%"></asp:Label><br />
            <asp:TextBox ID="TextBox2" TextMode="Number" runat="server" Style="margin-bottom:2%;" Width="20%" min="1" Max="10" step="1" OnTextChanged="TextBox2_TextChanged">10</asp:TextBox>
            <br/>
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Submit Review" CssClass="smallbtn" Visible="false" />
            
        </div>
    </section>

    <section>
        <div style="text-align:center">
            <h2 >Reviews</h2><br /><br />
        <asp:PlaceHolder ID="PlaceHolder1" runat="server">
        </asp:PlaceHolder>
        </div>
        
    </section>
</asp:Content>
