<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BulletImage.aspx.cs" Inherits="DemoWeb.BulletImage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <style>
        .indexItem {
            display: inline;
            float: left;
            position: relative;
            width: 204px;
            padding: 0;
            list-style: none
        }

        .MainBrowerItem_magin {
            margin-right: 24px
        }

        .item-details h5 {
            color: #555;
            text-align: left;
            font-size: 14px;
            font-family: 'Open Sans', sans-serif;
        }
    </style>
    <form id="form1" runat="server">
    <div>
        <!--
        <div>
            <div class="floatL"><img src="Uploads/Penguins.jpg" width='204' alt="ccc"/></div>
            <div class="floatL"><img src="Uploads/Penguins.jpg" width='204' alt="ccc"/></div>
            <div class="floatL"><img src="Uploads/Penguins.jpg" width='204' alt="ccc"/></div>
        </div>
        -->

<div>


</div>
        <!--
        <ul>
            <li><a>附綁帶蕾絲拼無袖連身洋裝<img src='ABC/Penguins.jpg' width='204'/></a></li>
            <li><a>附綁帶蕾絲拼無袖連身洋裝<img src='ABC/Penguins.jpg' width='204'/></a></li>
        </ul>
        -->
    </div>
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </form>
</body>
</html>
