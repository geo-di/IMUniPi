<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="IMUnipi.admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div style="text-align:center">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="AccessDataSource1" EmptyDataText="There are no data records to display." style="margin-top:100px" Width="100%">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="username" HeaderText="username" SortExpression="username" />
            <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
            <asp:BoundField DataField="create_time" HeaderText="create_time" SortExpression="create_time" />
            <asp:BoundField DataField="isadmin" HeaderText="isadmin" SortExpression="isadmin" />
        </Columns>
    </asp:GridView>
    <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="clip_id" DataSourceID="AccessDataSource2" EmptyDataText="There are no data records to display." style="margin-top: 100px" Width="100%">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="clip_name" HeaderText="clip_name" SortExpression="clip_name" />
            <asp:BoundField DataField="clip_artist" HeaderText="clip_artist" SortExpression="clip_artist" />
            <asp:BoundField DataField="clip_category" HeaderText="clip_category" SortExpression="clip_category" />
            <asp:BoundField DataField="clip_description" HeaderText="clip_description" SortExpression="clip_description" />
        </Columns>
    </asp:GridView>
    <asp:AccessDataSource ID="AccessDataSource2" runat="server" DataFile="~\IMUnipi.accdb" DeleteCommand="DELETE FROM `videoclips` WHERE `clip_id` = ?" InsertCommand="INSERT INTO `videoclips` (`clip_id`, `clip_name`, `clip_artist`, `clip_category`, `clip_description`, `clip_rating`, `clip_path`, `time_uploaded`) VALUES (?, ?, ?, ?, ?, ?, ?, ?)" SelectCommand="SELECT `clip_id`, `clip_name`, `clip_artist`, `clip_category`, `clip_description`, `clip_rating`, `clip_path`, `time_uploaded` FROM `videoclips`" UpdateCommand="UPDATE `videoclips` SET `clip_name` = ?, `clip_artist` = ?, `clip_category` = ?, `clip_description` = ?, `clip_rating` = ?,  WHERE `clip_id` = ?">
        <DeleteParameters>
            <asp:Parameter Name="clip_id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="clip_id" Type="Int32" />
            <asp:Parameter Name="clip_name" Type="String" />
            <asp:Parameter Name="clip_artist" Type="String" />
            <asp:Parameter Name="clip_category" Type="String" />
            <asp:Parameter Name="clip_description" Type="String" />
            <asp:Parameter Name="clip_rating" Type="String" />
            <asp:Parameter Name="clip_path" Type="String" />
            <asp:Parameter Name="time_uploaded" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="clip_name" Type="String" />
            <asp:Parameter Name="clip_artist" Type="String" />
            <asp:Parameter Name="clip_category" Type="String" />
            <asp:Parameter Name="clip_description" Type="String" />
            <asp:Parameter Name="clip_rating" Type="String" />
            <asp:Parameter Name="clip_id" Type="Int32" />
        </UpdateParameters>
    </asp:AccessDataSource>
    <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~\IMUnipi.accdb" DeleteCommand="DELETE FROM `users` WHERE `ID` = ?" InsertCommand="INSERT INTO `users` (`isadmin`) VALUES (?)" SelectCommand="SELECT `ID`, `username`, `password`, `email`, `create_time`, `isadmin` FROM `users`" UpdateCommand="UPDATE `users` SET `isadmin` = ? WHERE `username` = ?">
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="isadmin" Type="Int32" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="isadmin" Type="Int32" />
            <asp:Parameter Name="username" Type="String" />
        </UpdateParameters>
    </asp:AccessDataSource>
    <asp:GridView ID="GridView3" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="from,clip_name,time" DataSourceID="AccessDataSource3" EmptyDataText="There are no data records to display." Style="margin-top:100px;margin-bottom:200px" Width="100%" OnSelectedIndexChanged="GridView3_SelectedIndexChanged" OnRowDeleted="GridView3_RowDeleted">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" />
            <asp:BoundField DataField="from" HeaderText="from" ReadOnly="True" SortExpression="from" />
            <asp:BoundField DataField="clip_name" HeaderText="clip_name" ReadOnly="True" SortExpression="clip_name" />
            <asp:BoundField DataField="rating" HeaderText="rating" SortExpression="rating" />
            <asp:BoundField DataField="comment" HeaderText="comment" SortExpression="comment" />
            <asp:BoundField DataField="time" HeaderText="time" ReadOnly="True" SortExpression="time" />
        </Columns>
    </asp:GridView>
    <asp:AccessDataSource ID="AccessDataSource3" runat="server" DataFile="~\IMUnipi.accdb" DeleteCommand="DELETE FROM `reviews` WHERE `from` = ? AND `clip_name` = ? AND `time` = ?" InsertCommand="INSERT INTO `reviews` (`from`, `clip_name`, `rating`, `comment`, `time`) VALUES (?, ?, ?, ?, ?)" SelectCommand="SELECT `from`, `clip_name`, `rating`, `comment`, `time` FROM `reviews`" UpdateCommand="UPDATE `reviews` SET `rating` = ?, `comment` = ? WHERE `from` = ? AND `clip_name` = ? AND `time` = ?">
        <DeleteParameters>
            <asp:Parameter Name="from" Type="String" />
            <asp:Parameter Name="clip_name" Type="String" />
            <asp:Parameter Name="time" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="from" Type="String" />
            <asp:Parameter Name="clip_name" Type="String" />
            <asp:Parameter Name="rating" Type="Int32" />
            <asp:Parameter Name="comment" Type="String" />
            <asp:Parameter Name="time" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="rating" Type="Int32" />
            <asp:Parameter Name="comment" Type="String" />
            <asp:Parameter Name="from" Type="String" />
            <asp:Parameter Name="clip_name" Type="String" />
            <asp:Parameter Name="time" Type="String" />
        </UpdateParameters>
    </asp:AccessDataSource>
            </div>
        </section>
</asp:Content>
