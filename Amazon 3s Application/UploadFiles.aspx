<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadFiles.aspx.cs" Inherits="Amazon_3s_Application.UploadFiles" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <table>
                <tr>
                    <td>Please Choose Files :

                    </td>
                    <td>
                        <asp:Label ID="lblKey" runat="server"></asp:Label>
                        <asp:Label ID="lblAccessKey" runat="server"></asp:Label>
                        <asp:Label ID="lblAcl" runat="server"></asp:Label>
                        <asp:Label ID="lblPolicy" runat="server"></asp:Label>
                        <asp:Label ID="lblSignature" runat="server"></asp:Label>
                        <asp:Label ID="lblRedirect" runat="server"></asp:Label>
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" Height="26px" Width="128px" />
                    </td>
                </tr>

            </table>

        </div>
    </form>
</body>
</html>
