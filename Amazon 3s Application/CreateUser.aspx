<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="Amazon_3s_Application.CreateUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 126px;
        }

        .auto-style2 {
            width: 333px;
        }
        .auto-style3 {
            width: 127px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <table>
                <tr>
                    <td class="auto-style1">View Bucket List :
                                                    
                    </td>
                    <td>
                        <asp:ListBox ID="lbList" runat="server" Width="341px"></asp:ListBox>
                    </td>
                </tr>

            </table>

            <table>
                <tr>
                    <td class="auto-style1">View Bucket Files :

                    </td>
                    <td>
                        <asp:ListBox ID="lbBucketFiles" runat="server" Width="341px"></asp:ListBox>
                    </td>
                </tr>
            </table>


            <table>
                <tr>
                    <td class="auto-style1">Choose File :

                    </td>
                    <td>
                        <asp:FileUpload ID="btnChooseFile" runat="server" />
                    </td>
                </tr>
            </table>


            <br />
            <br />

            <table>
                <tr>
                    <td>Create User Bucket :
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtBucketName" runat="server" Height="19px" Width="177px"></asp:TextBox>&nbsp;&nbsp; &nbsp;
                        <asp:Button ID="btnSave" runat="server" Text="Create" OnClick="btnSave_Click" Height="26px" Width="128px" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td class="auto-style2">
                        <asp:Label ID="lblmessage" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>

            <table>
                <tr>
                    <td class="auto-style3">Create Folders :
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtFolderName" runat="server" Height="19px" Width="177px"></asp:TextBox>&nbsp;&nbsp; &nbsp;
                        <asp:Button ID="btnCreateFolder" runat="server" Text="Create Folder" OnClick="btnCreateFolder_Click" Height="26px" Width="128px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3"></td>
                    <td class="auto-style2">
                        <asp:Label ID="lblfolderMessage" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>

            <br />
            <br />

            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnBucketFile" runat="server" Text="Bucket Files" OnClick="btnBucketFile_Click" Height="26px" Width="128px" />
                    </td>

                    <td>
                        <asp:Button ID="btnUploadFiles" runat="server" Text="Upload Files" OnClick="btnUploadFiles_Click" Height="26px" Width="128px" />
                    </td>

                    <td>
                        <asp:Button ID="btnDownload" runat="server" Text="Download Files" OnClick="btnDownload_Click" Height="26px" Width="128px" />
                    </td>

                    <td>
                        <asp:Button ID="btnDelete" runat="server" Text="Delete Files" OnClick="btnDelete_Click" Height="26px" Width="128px" />
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
