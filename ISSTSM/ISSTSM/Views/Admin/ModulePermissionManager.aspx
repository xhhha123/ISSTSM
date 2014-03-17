<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModulePermissionManager.aspx.cs" Inherits="ISSTSM.Views.Admin.PermissionManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../css/usermanager.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.8.0.min.js"></script>
    <script src="../../Scripts/jquery.easyui.min.js"></script>
    <link href="../../Content/themes/default/easyui.css" rel="stylesheet" />
    <link href="../../Content/themes/icon.css" rel="stylesheet" />
    <script src="../../Scripts/datagrid-detailview.js"></script>
    <style>
        .perAll {
            padding:1px 10px;
            width:80px;
            float:left;
        }
        .perCur {
        }
        .perAdd {
        }
        .perDel {
        }
    </style>
    <script type="text/javascript">

        var $tbGrid = null;
        var subIndex;//子节点所在的行
        var subrow;

        //初始化模块树
        $(function () {
            $("#dg").datagrid({
                heigth: 650,
                idField: 'id',
                url: "/Actions/ModuleHandlers.ashx?action=load",
                singleSelect: true,
                fitColumns: true,
                nowrap: true,
                pagination: true,
                height: '450',
                columns: [[
                    { field: 'ModuleName', title: 'ModuleName', width: 180 },
                    { field: 'ModuleUrl', title: 'ModuleUrl', width: 120 }
                ]],
                view: detailview,
                detailFormatter: function (index, row) {
                    return '<div style="padding:2px"><table id="ddv-' + index + '"></table></div>';
                },
                onExpandRow: function (index, row) {
                    $('#dg').datagrid('collapseRow', subIndex);
                    subIndex = index;
                    $('#ddv-' + index).datagrid({
                        url: "/Actions/ModuleHandlers.ashx?action=loadByParentID&&parentID=" + row.ID,
                        fitColumns: true,
                        singleSelect: true,
                        rownumbers: true,
                        loadMsg: 'Loading',
                        height: 'auto',
                        columns: [[
                                { field: 'ModuleName', title: 'ModuleName', width: 180 },
                                { field: 'ModuleUrl', title: 'ModuleUrl', width: 120 }
                        ]],
                        onResize: function () {
                            $('#dg').datagrid('fixDetailRowHeight', index);
                        },
                        onLoadSuccess: function () {
                            setTimeout(function () {
                                $('#dg').datagrid('fixDetailRowHeight', index);
                            }, 0);
                        }
                    });
                    $('#dg').datagrid('fixDetailRowHeight', index);
                },
                onCollapseRow: function () {
                    subIndex = null;
                }
            });
            var p = $('#dg').datagrid('getPager');
            $(p).pagination({
                pageSize: 10,
                pageList: [10, 20, 50]
            });
        });

        //修改表单
        $(function () {

            //初始化parentID选择下拉框
            getParentLevel(1);

            //初始化全部权限多选框
            $.ajax({
                url: "/Actions/PermissionHandlers.ashx",
                data: { action: "loadAll" },
                success: function (data) {
                    var arr = eval(data);
                    var permission = "";
                    for (var i = 0; i < arr.length; i++) {
                        permission += "<div class='perAll' id='" + arr[i].ID
                            + "'><input type='checkbox' name='permissionIDs' value='"
                            + arr[i].PermissionName + "' />"
                            + arr[i].PermissionName + "</div>";
                    }
                    $("#AllPer").html(permission);
                }
            });

            $(".perAll").live('click', function () {
                if ($(this).hasClass("perCur")) {
                    if ($(this).hasClass("perDel")) {
                        //还原，不删除
                        $(this).removeClass("perDel");
                    }
                    //删除数据
                    $(this).addClass("perDel");
                    //
                } else {
                    if ($(this).hasClass("perAdd")) {
                        //还原，不添加
                        $(this).removeClass("perAdd");
                    }
                    $(this).addClass("perAdd");
                }
            });

            //SaveModule 保存模块修改数据
            $("#SaveModule").click(function () {
                var _id = $("#ID").val();
                var _parentID = $("#ParentID").val()
                var _moduleName = $("#ModuleName").val();
                var _moduleUrl = $("#ModuleUrl").val();
                var _icon = $("#Icon").val();
                var _sort = $("#Sort").val();
                var _isVisible = $("input:radio[name='IsVisible'][checked]").val();
                var _isMenu = $("input:radio[name='IsMenu'][checked]").val();
                var _idDeleted = $("input:radio[name='IsDeleted'][checked]").val();

                $.ajax({
                    type: "post",
                    url: "/Actions/ModuleHandlers.ashx",
                    data: {
                        action: "save", ID: _id, ParentID: _parentID, ModuleName: _moduleName, ModuleUrl: _moduleUrl,
                        Icon: _icon, Sort: 1, IsVisible: _isVisible, IsMenu: _isMenu, IsDeleted: _idDeleted
                    },
                    success: function (data, status) {
                        if (_id == "") {
                            message("Add " + _moduleName, " success !");
                        } else {
                            message("Update " + _moduleName, " success !");
                        }
                        reload();
                    },
                    error: function () {
                        message("Edit  " + row.PermissionName, "  faile !");
                    }
                });
                $('#operate_module').window("close", true);
            });
            //SaveModule 保存模块权限修改数据
            $("#SaveModPer").click(function () {
                var perIdAdds = "", perIdDels = "";
                $.each($(".perAll").filter(".perAdd"), function (i, add) {
                    perIdAdds += add.id + ",";
                });
                $.each($(".perAll").filter(".perDel"), function (i, del) {
                    perIdDels += del.id + ",";
                });
                //alert("moID:" + subrow.ID+"  perDel:"+perIdDels+"  PerAdd:"+perIdAdds);
                $.ajax({
                    type: "post",
                    url: "/Actions/ModulePermissionHandlers.ashx",
                    data: {
                        action: "save", ModuleID: subrow.ID, PerIdAdds: perIdAdds, PerIdDels: perIdDels
                    },
                    success: function (data, status) {
                        reload();
                    }
                });
                $('#authModPer').window("close", true);
            });
            //Cancel 取消修改
            $("#Cancel").click(function () {
                $('#operate_module').window("close", true);
            });
            $("#CancelModPer").click(function () {
                $('#authModPer').window("close", true);
            });

        });

        //-------------------utils base--------------------------------------
        //加载模块操作权限
        var moduleId = "<%=GetModuleId() %>";
        var GetPerurl = "/Actions/GetModulePermission.ashx?t=operate&&moduleid=" + moduleId;
        $.ajax({
            type: "get",
            url: GetPerurl,
            success: function (data) {
                var arr2 = eval(data);
                var htmlArr = [];
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
                    editModule();
                    break;
                case "Add":
                    addModule();
                    break;
                case "Delete":
                    deleteModule();
                    break;
                case "ModuleAuthorize":
                    authModPer();
                    break;
                default:
                    alert("default a");
                    break;
            }
        };

        //load a message window
        function message(action_permission, status) {
            $.messager.show({
                msg: action_permission + status,
                showType: 'slide',
                timeout: 1400
            });
        }


        //reload datagrid and clear data
        function reload() {
            subIndex = null;
            $("#dg").datagrid("reload");
        }

        //增加或者编辑父子节点：父节点增加时，不要选中行，子节点增加时，要选中父节点
        function editModule() {
            var row = $('#dg').datagrid('getSelected');
            if (subIndex != null) {
                subrow = $('#ddv-' + subIndex).datagrid('getSelected');
            }
            //编辑
            if (row == null && subrow == null) {
                alert("You have not selected! ");
            } else {
                var editRow = subrow == null ? row : subrow;
                $("#ID").val(editRow.ID);
                $("#ParentID").val(editRow.ParentID);
                $("#ModuleName").val(editRow.ModuleName);
                $("#ModuleUrl").val(editRow.ModuleUrl);
                $("#Icon").val(editRow.Icon);
                $("#Sort").val(editRow.Sort);
                $("input:radio[name='IsVisible'][value='" + editRow.IsVisible + "']").attr("checked", true);
                $("input:radio[name='IsMenu'][value='" + editRow.IsMenu + "']").attr("checked", true);
                $("input:radio[name='IsDeleted'][value='" + editRow.IsDeleted + "']").attr("checked", true);

                //查出跟其上级同一等级的module名称，并形成一个下拉框
                if (editRow.ParentID === 1) {
                    //说明其是一级节点，因为只支持二级菜单，所以不能修改
                    $("#ParentID").attr("disabled", "false");
                } else {
                    $("#ParentID").removeAttr("disabled");
                }
                //弹出弹窗
                $('#operate_module').window('open');
            }
        }

        //添加节点
        function addModule() {
            $("#ID").val();
            $("#ModuleName").val();
            $("#ModuleUrl").val();
            $("#Icon").val();
            $("#Sort").val();
            $("input:radio[name='IsVisible'][value='true']").attr("checked", true);
            $("input:radio[name='IsMenu'][value='true']").attr("checked", true);
            $("input:radio[name='IsDeleted'][value='true']").attr("checked", true);
            //弹出弹窗
            $('#operate_module').window('open');
        }

        //删除子节点
        function deleteModule() {
            subrow = $('#ddv-' + subIndex).datagrid('getSelected');
            if (subrow == null) {
                alert("You have not selected! ");
            }
            else {
                $.messager.confirm('确认', 'Are you sure you want to delete this record？', function (r) {
                    if (r) {
                        $.ajax({
                            type: "post",
                            url: "/Actions/ModuleHandlers.ashx?action=del&&ID=" + subrow.ID,
                            success: function (data, status) {
                                $("#dg").datagrid("reload");
                            },
                            error: function () { alert("Error!Please contact administrator!"); }
                        });
                    }
                });
            }
        }

        //模块授权--获取当前模块的权限
        function authModPer() {
            $(".perAll").removeClass("perCur");
            $(".perAll").removeClass("perAdd");
            $(".perAll").removeClass("perDel");
            $(".perAll").children("input").removeAttr("checked");
            if (subIndex != null) {
                subrow = $('#ddv-' + subIndex).datagrid('getSelected');
            }
            //编辑
            if (subrow == null) {
                alert("You have not choose the exact module to authorize!");
            } else {
                $.ajax({
                    type: "post",
                    url: "/Actions/ModulePermissionHandlers.ashx?",
                    data: { action: "loadByModID", ModuleID: subrow.ID },
                    success: function (data) {
                        var arr = eval(data);
                        for (var i = 0; i < arr.length; i++) {
                            $("#" + arr[i].ID + "").addClass("perCur");
                            $("#" + arr[i].ID + "").children("input").attr("checked", true);
                        }
                    },
                    error: function () { alert("Error!Please contact administrator!"); }
                });
                //弹出弹窗
                $('#authModPer').window('open');
            }

        }

        //遍历所有一级节点形成一个下拉框
        function getParentLevel(parentID) {
            $.ajax({
                type: "post",
                url: "../../Actions/ModuleHandlers.ashx?action=loadByParentID&&parentID=" + parentID,
                success: function (data) {
                    var arr = eval(data);
                    var opt = "<option value='1' selected='true'>top-level</option>";
                    for (i = 0; i < arr.length; i++) {
                        opt += "<option value=" + arr[i].ID + ">" + arr[i].ModuleName + "</option>";
                    }
                    $("#ParentID").html(opt);
                }
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

    <div id="operate_module" class="easyui-window" title='Edit Module' closed="true" shadow="true" 
        style="width: 400px; height: 370px;">
        <form id="PermissionSave" runat="server">
            <table>
                <tr>
                    <td></td>
                    <td>
                        <input id="ID" name="ID" type="hidden" />
                    </td>
                </tr>
                <tr>
                    <td>ModuleName:</td>
                    <td>
                        <input id="ModuleName" name="ModuleName" />
                    </td>
                </tr>
                <tr>
                    <td>SuperModuleName:</td>
                    <td>
                        <select  id="ParentID" name="parentID">
                            
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>ModuleUrl:</td>
                    <td>
                        <input id="ModuleUrl" name="ModuleUrl" />
                    </td>
                </tr>
                <tr>
                    <td>Icon:</td>
                    <td>
                        <input id="Icon" name="Icon" />
                    </td>
                </tr>
                <tr>
                    <td>Sort :</td>
                    <td>
                        <input id="Sort" name="Sort" value="0"/>
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
                    <td>IsMenu:</td>
                    <td>
                        <input type="radio" name="IsMenu" value="true" checked="checked" />true
                        <input type="radio" name="IsMenu" value="false" />false
                    </td>
                </tr>
                <tr>
                    <td>IsDeleted:</td>
                    <td>
                        <input type="radio" name="IsDeleted" value="true" checked="checked" />true
                        <input type="radio" name="IsDeleted" value="false" />false
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <input id="SaveModule" name="Submit" type="button" value="Submit" />
                        <input id="Cancel" name="Cancel" type="button" value="Cancel" />
                    </td>
                </tr>
            </table>
        </form>
    </div>
   
     <div id="authModPer" class="easyui-window" title='Authorize Module Permission' closed="true" shadow="true" 
        style="width: 300px; height: 250px;">
        <br />
        <div id="AllPer" ></div><br />
        <div style="width:200px;float:left;padding:15px;">
            <input id="SaveModPer" name="Submit" type="button" value="Submit" />
            <input id="CancelModPer" name="Cancel" type="button" value="Cancel" />
        </div>
    </div>
</body>
</html>