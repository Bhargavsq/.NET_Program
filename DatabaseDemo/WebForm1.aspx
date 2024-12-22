<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="DatabaseDemo.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           <asp:GridView ID="gvEmp" runat="server" />
            <br />
            <asp:DropDownList ID="ddlEmpId" runat="server" />
            <br />
            Emp ID: <asp:TextBox ID="txtEmpid" runat="server"></asp:TextBox>
            <br />
            Emp Name: <asp:TextBox ID="txtEmpName" runat="server"></asp:TextBox>
               <br />
            Emp City: <asp:TextBox ID="txtEmpCity" runat="server"></asp:TextBox>
               <br />
            Emp Salary: <asp:TextBox ID="txtEmpSalary" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnInsert" runat="server" Text="Insert" OnClick="btnInsert_Click" />
        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
        </div>
    </form>
</body>
</html>
