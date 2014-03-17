<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PermissionManager.aspx.cs" Inherits="ISSTSM.Views.Admin.PermissionManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <link href="../../css/usermanager.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.8.0.min.js"></script>
    <script src="../../Scripts/jquery.easyui.min.js"></script>
    <link href="../../Content/themes/default/easyui.css" rel="stylesheet" />
    <link href="../../Content/themes/icon.css" rel="stylesheet" />
    <script type="text/javascript">

        $(function () {

            $tbGrid = $('#dg').datagrid({
                url: '../../Actions/PermissionHandlers.ashx?action=load',
                columns: [[
                { field: 'PermissionName', title: 'PermissionName', width: 100 },
                { field: 'Sort', title: 'Sort', width: 100 },
                { field: 'Icon', title: 'Icon', width: 100 },
                { field: 'IsVisible', title: 'IsVisible', width: 100 },
                { field: 'IsButton', title: 'IsButton', width: 100 },
                { field: 'PermissionCode', title: 'PermissionCode', width: 100 },
                { field: 'Description', title: 'Description', width: 100 }
                ]],
                rownumbers: true,
                pagination: true,
                singleSelect: true
            });

            $("#Submit").click(function () {
                var _id = $("#ID").val();
                var _permissionName = $("#PermissionName").val();
                var _icon = $("#Icon").val();
                var _isVisible = $('input:radio[name="IsVisible"][checked]').val();
                var _isButton = $('input:radio[name="IsButton"][checked]').val();
                var _permissionCode = $("#PermissionCode").val();
                var _description = $("#Description").val();
                $.ajax({
                    type: "post",
                    url: "/Actions/PermissionHandlers.ashx",
                    data: {
                        action: "save", ID: _id, Sort: 10, PermissionName: _permissionName, Icon: _icon, IsVisible: _isVisible, IsButton: _isButton, PermissionCode: _permissionCode, Description: _description
                    },
                    success: function (data, status) {
                        if (_id == "") {
                            message("Add " + _permissionName, " success !");
                        } else {
                            message("Update " + _permissionName, " success !");
                        }
                    },
                    error: function () {
                        message("Edit  " + row.PermissionName, "  faile !");
                    }
                }); 
                reloadDataGrid();
            });

            $("#Cancel").click(function () {
                $('#operate_permission').window("close", true);
                cleanFormData();
            });

        });

        //add permission
        function addPermission() {
            $('#operate_permission').window("open");
        }
        //update permission
        function editPermission() {
            var row = $('#dg').datagrid('getSelected');
            if (row != null) {
                $("#ID").val(row.ID);
                $("#PermissionName").val(row.PermissionName);
                $("#Icon").val(row.Icon);
                $("input:radio[name='IsVisible'][value='" + row.IsVisible + "']").attr("checked", true);
                $("input:radio[name='IsButton'][value='" + row.IsButton + "']").attr("checked", true);
                $("#PermissionCode").val(row.PermissionCode);
                $("#Description").val(row.Description);
                //show view
                $('#operate_permission').window("open");
            } else {
                alert("You have not selected! ");
            }
        }
        //delete record from the data
        function deletePermission() {
            var row = $('#dg').datagrid('getSelected');
            var index = $('#dg').datagrid('getRowIndex', row);
            if (row != null) {
                $.messager.confirm('Comfirm', 'Delete this record？', function (r) {
                    if (r) {
                        $.ajax({
                            type: "post",
                            url: "/Actions/PermissionHandlers.ashx",
                            data: { action: "delete", ID: row.ID },
                            success: function (data, status) {
                                message("Delete " + row.PermissionName, " success !");
                                $('#dg').datagrid('deleteRow', index);
                                window.parent.updateDataGridInTab();
                            },
                            error: function () { message("delete  " + row.PermissionName, "  faile !"); }
                        });
                    }
                }); 
            } else {
                alert("You have not selected! ");
            }

        }
        //-------------------utils base--------------------------------------
        //加载模块操作权限
        var moduleId = '<%=GetModuleId()%>';
        var GetPerurl = "/Actions/GetModulePermission.ashx?t=operate&&moduleid=" + moduleId;
        $.ajax({
            type: "get",
            url: GetPerurl,
            success: function (data) {
                var arr2 = eval(data);
                var htmlArr = [];
                //alert(data);
                for (var i = 0; i < arr2.length; i++) {
                    htmlArr.push('<div class="operateblock" id="' + arr2[i].PermissionCode + '" onclick="operate(\'' + arr2[i].PermissionCode + '\')">');
                    htmlArr.push('<div class="icondiv"><img class="icon" src="' + getOperateIcon(arr2[i].PermissionCode) + '"/></div>');
                    htmlArr.push('<div class="title"><font color="blue">' + arr2[i].PermissionName + '</font></div>');
                    htmlArr.push('</div>');
                }
                $('#operate').html(htmlArr.join(''));
            },
            error: function () { alert("Error!Please contact administrator!"); }
        });

        //// 获取操作图标
        function getOperateIcon(title) {
            var icon = "/Content/images/main/";
            icon = icon + title + "_icon.png";
            return icon;
        };

        //操作功能
        function operate(title) {

            switch (title) {
                case "Edit":
                    editPermission();
                    break;
                case "Add":
                    addPermission();
                    break;
                case "Delete":
                    deletePermission();
                    break;
                default:
                    alert("default a");
                    break;
            }
        };

        //
        function reloadDataGrid() {
            cleanFormData();
            $('#operate_permission').window("close", true);
            window.parent.updateDataGridInTab();
        }
        //clean operate_permission Form data
        function cleanFormData() {
            $("#ID").val("");
            $("#PermissionName").val("");
            $("#Icon").val("");
            $("input:radio[name='IsVisible'][value='true']").attr("checked", true);
            $("input:radio[name='IsButton'][value='true']").attr("checked", true);
            $("#PermissionCode").val("");
            $("#Description").val("");
        }

        //load a message window
        function message(action_permission, status) {
            $.messager.show({
                msg: action_permission + status,
                showType: 'slide',
                timeout: 1400
            });
        }
        //--------------------utils base end-----------------------------------
    </script>
</head>
<body>
    <table id="dg" data-options="toolbar:'#tb'">
    </table>
    <div id="tb" style="padding: 5px; height: auto">
        <div id="operate" class="operate">
        </div>
    </div>

    <div id="operate_permission" class="easyui-window" closed="true" shadow="true" 
        style="width: 380px; height: 250px;" data-options="onClose:function(){cleanFormData();}">
        <form id="PermissionSave" runat="server">
            <table>
                <tr>
                    <td></td>
                    <td>
                        <input id="ID" name="ID" type="hidden" />
                    </td>
                </tr>
                <tr>
                    <td>PermissionName:</td>
                    <td>
                        <input id="PermissionName" name="PermissionName" />
                    </td>
                </tr>
                <tr>
                    <td>Icon:</td>
                    <td>
                        <input id="Icon" name="Icon" />
                    </td>
                </tr>
                <tr>
                    <td>IsVisible:</td>
                    <td>
                        <input type="radio" name="IsVisible" value="true" checked="checked" />true 
                        <input type="radio" name="IsVisible" value="false" />false
                    </td>
                </tr>
                <tr>
                    <td>IsButton:</td>
                    <td>
                        <input type="radio" name="IsButton" value="true" checked="checked" />true
                        <input type="radio" name="IsButton" value="false" />false
                    </td>
                </tr>
                <tr>
                    <td>PermissionCode:</td>
                    <td>
                        <input id="PermissionCode" name="PermissionCode" />
                    </td>
                </tr>
                <tr>
                    <td>Description :</td>
                    <td>
                        <input id="Description" name="Description" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <input id="Submit" name="Submit" type="button" value="Submit" />
                        <input id="Cancel" name="Cancel" type="button" value="Cancel" />
                    </td>
                </tr>
            </table>
        </form>
    </div>
</body>
</html>
