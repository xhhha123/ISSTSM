<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserManager.aspx.cs" Inherits="ISSTSM.Views.Admin.UserManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    
    <script src="Scripts/jquery-1.8.0.min.js"></script>
    <script src="Scripts/jquery.easyui.min.js"></script>
    <link href="Content/themes/default/easyui.css" rel="stylesheet" />
    <link href="Content/themes/icon.css" rel="stylesheet" />
     <script type="text/javascript">
         $(function () {
             
             $('#dg').datagrid({
                 url: 'Actions/GetUserInfo.ashx',
                 columns: [[
                 { field: 'UserName', title: 'UserName', width: 100 },
                 { field: 'RealName', title: 'RealName', width: 100 },
                 { field: 'SectionName', title: 'Section', width: 100 },
                 { field: 'Telephone', title: 'Telephone', width: 100 },
                 { field: 'Email', title: 'Email', width: 100 }
                 ]],
                 rownumbers: true
             });
         });
     </script>
</head>
<body>
    <table id="dg" data-options="toolbar:'#tb'">

    </table>
    <div id="tb" style="padding:5px;height:auto">
		<div style="margin-bottom:5px">
			<a href="#" class="easyui-linkbutton" iconCls="icon-add" plain="true"></a>
			<a href="#" class="easyui-linkbutton" iconCls="icon-edit" plain="true"></a>
			<a href="#" class="easyui-linkbutton" iconCls="icon-save" plain="true"></a>
			<a href="#" class="easyui-linkbutton" iconCls="icon-cut" plain="true"></a>
			<a href="#" class="easyui-linkbutton" iconCls="icon-remove" plain="true"></a>
		</div>
		<div>
			Date From: <input class="easyui-datebox" style="width:80px">
			To: <input class="easyui-datebox" style="width:80px">
			
			<a href="#" class="easyui-linkbutton" iconCls="icon-search">Search</a>
		</div>
	</div>
</body>
</html>
