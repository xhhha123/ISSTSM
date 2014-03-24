<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleManager.aspx.cs" Inherits="ISSTSM.Views.Admin.RoleManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    
    <link href="../../Content/themes/default/easyui.css" rel="stylesheet" />
    <link href="../../Content/themes/icon.css" rel="stylesheet" />
    <link href="../../css/usermanager.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.8.0.min.js"></script>
    <script src="../../Scripts/jquery.easyui.min.js"></script>
    <script src="../../Scripts/jquery-validation/jquery.metadata.js"></script>
    <script src="../../Scripts/jquery-validation/jquery.validate.min.js"></script>
    <script src="../../Scripts/jquery-validation/messages_cn.js"></script>
    <script src="../../Scripts/commom.js"></script>
    <script src="../../Scripts/jquery.easyui.GlobalParas.js"></script>
        <script src="../../Scripts/datagrid-detailview.js"></script>

     <script type="text/javascript">

         var isEdit = 0;
         var date = new Date();
         var subIndex;//子节点所在的行
         var roleId;//临时存储RoleId
         var moduleId;//临时存储moduleId
         $(function () {
             //初始化日期
             $('#CreateDate').datebox({
                 required:true,
                 formatter: function (date) { return date.getFullYear() + '-' + (date.getMonth() + 1) + '-' + date.getDate(); },
             });
             $("#btnSave").click(function () {
                 alert("123");
             });
             $("#dg").datagrid({
                 heigth: 700,
                 idField: 'id',
                 url: '/Actions/RoleHandler.ashx?t=load',
                 singleSelect: true,
                 fitColumns: true,
                 nowrap: true,
                 height: '450',
                 pagination: true,
                 columns: [[
                     { field: 'RoleName', title: 'RoleName', width: 50, editor: 'text', sortable: true },
                     { field: 'Description', title: 'Description', width: 100, editor: 'text', sortable: true },
                     {
                         field: 'CreateDate', title: 'CreateDate', width: 100, editor: 'text', sortable: true, formatter: function (value) {
                             return $.globalParas.changeDateFormat(value);
                         }
                     }
                 ]],
             });
             var p = $('#dg').datagrid('getPager');
             $(p).pagination({
                 pageSize: 10,
                 pageList: [10, 20, 50]
             });
         });

         $(function () {
             //Cancel 取消修改
             $("#wincan").click(function () {
                 $('#win').window("close", true);
             });
             //Cancel 取消修改
             $("#CancelModPer").click(function () {
                 $('#win').window("close", true);
             });
             //表单验证
             $.metadata.setType("attr", "validate");
             $("#editwindow").validate({
                 submitHandler: function () {
                     var params = $("#editwindow").serialize();
                     var dataText = null;
                     $.ajax({
                         cache: false,
                         async: false,
                         url: isEdit == "1" ? "/Actions/RoleHandler.ashx?t=edit" : "/Actions/RoleHandler.ashx?t=add",//判断是添加还是修改
                         type: "post",
                         success: function (data) {
                             dataText = data;
                         },
                         data: params,
                         timeout: 10000
                     });
                     if (dataText == "Success")//后台处理成功返回的数据
                     {
                         isEdit = 0;
                         $.messager.show({
                             msg: ' Successfully !',
                         });
                         $('#win').window('close');
                         $('#dg').datagrid('clearSelections');
                         //Grid.reload();
                         $('#dg').datagrid('reload');
                     }
                     else {
                         $.messager.show({
                             msg: dataText,
                         });
                     }
                 }
             });

             //加载模块操作权限
             var moduleId = "<%=GetModuleId() %>";
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

         });

         //增加或者编辑
         function edit(judge) {
             var row = $('#dg').datagrid('getSelected');
             //编辑
             if (judge > -1) {
                 if (row == null )
                 { alert("You have not selected! "); }
                 else {
                     isEdit = 1;
                     $.ajax({
                         type: "get",
                         url:  "/Actions/RoleHandler.ashx?t=edit&&editOrload=load&&id=" + row.ID,
                         success: function (data) {
                             var arr = eval(data);
                             for (var i = 0; i < arr.length; i++) {
                                 $("#ID").val(arr[i].ID);
                                 $("#RoleName").val(arr[i].RoleName);
                                 $("#CreateUserID").val(arr[i].CreateUserID);
                                 $("#Description").val(arr[i].Description);
                                 $('#CreateDate').datebox('setValue', $.globalParas.changeDateFormat(arr[i].CreateDate));
                                 $("#Sort").val(arr[i].Sort);
                             }
                         },
                         error: function () { alert("Error!Please contact administrator!"); }
                     });
                     //弹出弹窗
                     $('#win').window({ title: "EditRole" });
                     $('#win').window('open');
                 }
             }
                 //增加 父节点增加时，不要选中行，子节点增加时，要选中父节点
             else {
                 $('#CreateDate').datebox('setValue', date.getFullYear() + '-' + (date.getMonth() + 1) + '-' + date.getDate());
                 $("#RoleName").val("");
                 $("#CreateUserID").val(1);
                 $("#Sort").val(0);
                 $("#Description").val("");
                 //弹出弹窗
                 $('#win').window({ title: "AddRole" });
                 $('#win').window('open');
             }
         }

         ////删除
         function del() {
             var row = $('#dg').datagrid('getSelected');
             if (row == null) {
                 alert("You have not selected! ");
             }
             else {
                 $.messager.confirm('确认', 'Are you sure you want to delete this record？', function (r) {
                     if (r) {
                         $.ajax({
                             type: "get",
                             async: false,
                             url:  "/Actions/RoleHandler.ashx?t=del&&id=" + row.ID,
                             success: function (data) {
                                 if (data == "Success") {
                                     $.messager.show({
                                         msg: ' Successfully Delete!',
                                     });
                                     $('#dg').datagrid('clearSelections');
                                     $('#dg').datagrid('reload');
                                 }
                             },
                             error: function () { alert("Error!Please contact administrator!"); }
                         });
                     }
                 });

             }

         }

         ///角色权限授权
         function Authorize() {
             var row = $('#dg').datagrid('getSelected');
             
             if (row == null) {
                 alert("You have not selected! ");
             }
             else {
                 roleId = row.ID;
                 $('#AuthorizeWin').window({ title: "Role-Authorize" });
                 $("#AuthorizeWin").window('open');
                 $(function () {
                     $("#tbRole").datagrid({
                         idField: 'ID',
                         url: '/Actions/RoleHandler.ashx?t=loadMolPer&&MolOrPer=SubMol&&id='+row.ID,
                         singleSelect: true,
                         fitColumns: true,
                         nowrap: true,
                         height: '350',
                         width: '250',
                         pagination: true,
                         columns: [[
                             { field: 'ckmol', checkbox: true },
                             { field: 'ID', title: 'ID', width: 50, editor: 'text', sortable: true },
                             { field: 'ModuleName', title: 'ModuleName', width: 100, editor: 'text', sortable: true }
                         ]],
                         onSelect: function (rowIndex, rowData) {
                             $("#AllPer").html("");
                             moduleId = rowData.ID;
                             //初始化全部权限多选框
                             $.ajax({
                                 url: '/Actions/RoleHandler.ashx?t=loadMolPer&&MolOrPer=Per&&id=' + roleId + "&&ModuleId=" + rowData.ID,
                                 success: function (data) {
                                     var arr = eval(data);
                                     var permission = "";
                                     for (var i = 0; i < arr.length; i++) {

                                         if (!arr[i]["IsButton"]) {
                                             permission += "<div class='perAll perCur' id='" + arr[i].ID
    + "'><input type='checkbox' name='permissionIDs'   checked='true' value='"
    + arr[i].PermissionName + "'  />"
    + arr[i].PermissionName + "</div>";
                                         }
                                     else{
                                       permission += "<div class='perAll' id='" + arr[i].ID
    + "'><input type='checkbox' name='permissionIDs' value='"
    + arr[i].PermissionName + "' />"
    + arr[i].PermissionName + "</div>";
                                     }
                                     }
                                     $("#AllPer").html(permission);
                                 }
                             });
                         }
                     });
                     //checkbox 勾选事件
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

                     //SaveModule 保存模块权限修改数据
                     $("#SaveModPer").click(function () {
                         var perIdAdds = "", perIdDels = "";
                         $.each($(".perAll").filter(".perAdd"), function (i, add) {
                             perIdAdds += add.id + ",";
                         });
                         $.each($(".perAll").filter(".perDel"), function (i, del) {
                             perIdDels += del.id + ",";
                         });
                        
                         $.ajax({
                             type: "post",
                             url: "/Actions/RoleHandler.ashx",
                             data: {
                                 t: "OptMolPer", roleId: roleId, ModuleId: moduleId, PerIdAdds: perIdAdds, PerIdDels: perIdDels
                             },
                             success: function (data) {
                                 if (data == "Success") {
                                     $.messager.show({
                                         msg: ' Successfully !',
                                     });
                                     $('#dg').datagrid('clearSelections');
                                     $('#dg').datagrid('reload');
                                     $('#AuthorizeWin').window("close", true);
                                 }
                             },
                         });
                     });
                     //Cancel 取消修改
                     $("#Cancel").click(function () {
                         $('#AuthorizeWin').window("close", true);
                     });

                     var p = $('#tbRole').datagrid('getPager');
                     $(p).pagination({
                         pageSize: 20,
                         pageList: [20, 50]
                     });
                 });
             }
         }

         //角色模块授权
         function AuthorizeMol() {
             var row = $('#dg').datagrid('getSelected');
             if (row == null) {
                 alert("You have not selected! ");
             }
             else {
                 roleId = row.ID;
                 $('#AuthorizeWin').window({ title: "Module-Authorize" });

                 $("#AuthorizeWin").window({
                     height: 350,
                     width:300
                 });
                 $("#AuthorizeWin").window("open");
                 $("#AllMol").html("");
                 //初始化全部权限多选框
                 $.ajax({
                     url: '/Actions/RoleHandler.ashx?t=loadMolPer&&MolOrPer=Mol&&id=' + row.ID,
                     success: function (data) {
                         var arr = eval(data);
                         var permission = "";
                         for (var i = 0; i < arr.length; i++) {
                             if (arr[i]["IsDeleted"]) {
                                 permission += "<div class='MolAll MolCur' id='" + arr[i].ID
+ "'><input type='checkbox' name='ModuleIDs'   checked='true' value='"
+ arr[i].ModuleName + "'  />"
+ arr[i].ModuleName + "</div>";
                             }
                             else {
                                 permission += "<div class='MolAll' id='" + arr[i].ID
+ "'><input type='checkbox' name='ModuleIDs' value='"
+ arr[i].ModuleName + "' />"
+ arr[i].ModuleName + "</div>";
                             }
                         }
                         $("#AllMol").html(permission);
                     }
                 });
                 //checkbox 勾选事件
                 $(".MolAll").live('click', function () {
                     if ($(this).hasClass("MolCur")) {
                         if ($(this).hasClass("MolDel")) {
                             //还原，不删除
                             $(this).removeClass("MolDel");
                         }
                         //删除数据
                         $(this).addClass("MolDel");
                         //
                     } else {
                         if ($(this).hasClass("MolAdd")) {
                             //还原，不添加
                             $(this).removeClass("MolAdd");
                         }
                         $(this).addClass("MolAdd");
                     }
                 });
                 //SaveModule 保存模块权限修改数据
                 $("#SaveModPer").click(function () {
                     var molIdAdds = "", molIdDels = "";
                     $.each($(".MolAll").filter(".MolAdd"), function (i, add) {
                         molIdAdds += add.id + ",";
                     });
                     $.each($(".MolAll").filter(".MolDel"), function (i, del) {
                         molIdDels += del.id + ",";
                     });
                     $.ajax({
                         type: "post",
                         url: "/Actions/RoleHandler.ashx",
                         data: {
                             t: "OptRMP", id: roleId, molIdAdds: molIdAdds, molIdDels: molIdDels
                         },
                         success: function (data) {
                             if (data == "Success") {
                                 $.messager.show({
                                     msg: ' Successfully !',
                                 });
                                 $('#dg').datagrid('clearSelections');
                                 $('#dg').datagrid('reload');
                                 $('#AuthorizeWin').window("close", true);
                             }
                         },
                     });
                 });
                 //Cancel 取消修改
                 $("#Cancel").click(function () {
                     $('#AuthorizeWin').window("close", true);
                 });

             }
         };

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
                     edit(1);
                     break;
                 case "Add":
                     edit(-1);
                     break;
                 case "Delete":
                     del();
                     break;
                 case "Authorize":
                     Authorize();
                     break;
                 case "AuthorizeMol":
                     AuthorizeMol();
                     break;
                 default:
                     break;
             }
         };


     </script>
</head>
<body>
    <table id="dg" data-options="toolbar:'#tb'">
    </table>
    <div id="tb" style="padding:5px;height:auto">
		
        <div id="operate"  class="operate">
        </div>
		
	</div>

    <div id="win" class="easyui-window" closed="true" modal="true" shadow="true" minimizable="true" style="width:560px;height:400px;">
        <form id="editwindow" runat="server">
            <div style="text-align:center">
            <table align="center" style="margin-bottom:10px" class="optable">
                 <tr>
                    <td><input type="hidden" id="ID" name="ID" /></td>                          
                </tr>
                <tr>
                    <td>RoleName:</td>
                        <td >
                            <input id="RoleName" name="RoleName" />
                        </td>
                </tr>
                <tr>
                    <td> CreateUserID:</td>
                        <td >
                            <input id="CreateUserID" name="CreateUserID" />
                        </td>
                </tr>
                 <tr>
                     <td> CreateDate:</td>
                        <td id="passtd" > 
                            <input id="CreateDate" type="text"name="CreateDate" />
                        </td>
                </tr>
                 <tr>
                     <td>  Description :</td>
                        <td >
                            <input id="Description"  name="Description" />
                        </td>
                </tr>
                <tr>
                    <td> Sort :</td>
                        <td >
                            <input id="Sort" name="Sort" />
                        </td>
                </tr>

                <tr>
                        <td colspan="2">
                            <input id="winsub" type="submit"  value="Submit"/>
                            <input id="wincan" type="button" value="Cancel" />
                        </td>
                </tr>
            </table>
           </div>
        </form>
    </div>

    <div id="AuthorizeWin" class="easyui-window" closed="true" modal="true" shadow="true" minimizable="true" style="width:560px;height:400px;">
      <div>        
          <table>
              <tr>
                  <td><table id="tbRole" >
                          </table>
                  </td>
                  <td>
                              <br />
        <div id="AllPer" ></div><br />
         <br />
        <div id="AllMol" ></div><br />
        <div style="width:200px;float:left;padding:15px;">
            <input id="SaveModPer" name="Submit" type="button" value="Submit" />
            <input id="CancelModPer" name="Cancel" type="button" value="Cancel" />
        </div>
                  </td>
              </tr>
          </table>
      </div>
    </div>


</body>
</html>


