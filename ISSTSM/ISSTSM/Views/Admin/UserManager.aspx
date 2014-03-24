<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserManager.aspx.cs" Inherits="ISSTSM.Views.Admin.UserManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    
    <link href="../../Content/themes/default/easyui.css" rel="stylesheet" />
    <link href="../../Content/themes/icon.css" rel="stylesheet" />
    <link href="../../css/usermanager.css" rel="stylesheet" />
    <link href="../../css/validation.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.8.0.min.js"></script>
    <script src="../../Scripts/jquery.easyui.min.js"></script>
    <script src="../../Scripts/jquery-validation/jquery.metadata.js"></script>
    <script src="../../Scripts/jquery-validation/jquery.validate.min.js"></script>
    <script src="../../Scripts/jquery.form.js"></script>
    <script src="../../Scripts/commom.js"></script>
     <script type="text/javascript">
         var Grid;
         var SectionID;
         var Section;
         var DicSex;
         var DicStatus;
         var isEdit = 0;
         var Role;

         $(function () {
                 Grid=$('#dg').datagrid({
                 url: '../../Actions/UserInfoHandler.ashx?t=getall',
                 columns: [[
                 { field: 'UserName', title: 'UserName', width: 150, sortable: true },
                 { field: 'RealName', title: 'RealName', width: 150, sortable: true },
                 { field: 'SectionName', title: 'Section', width: 150, sortable: true },
                 { field: 'Telephone', title: 'Telephone', width: 150, sortable: true },
                 { field: 'Email', title: 'Email', sortable: true }
                 ]],
                 rownumbers: true,
                 pagination: true,
                 singleSelect:true
             });
             var p = $('#dg').datagrid('getPager');
             $(p).pagination({
                 pageSize: 10,
                 pageList: [10, 20, 50]
             });
         });
         $(function () {
             //部门下拉框
             SectionID = $('#SectionID').combobox({
                 editable: false,
                 url: '/Actions/GetCombobox.ashx?t=getSection',
                 valueField: 'id',
                 textField: 'text'
             });

             //部门下拉框
             Section = $('#Section').combobox({
                 editable: false,
                 url: '/Actions/GetCombobox.ashx?t=getSection',
                 valueField: 'id',
                 textField: 'text'
             });

             //角色下拉框
             Role = $('#Role').combobox({
                 editable: false,
                 url: '/Actions/GetCombobox.ashx?t=getRole',
                 valueField: 'id',
                 textField: 'text',
                 multiple:true
             });
             //性别下拉框
             DicSex = $('#DicSex').combobox({
                 editable: false,
                 url: '/Actions/GetCombobox.ashx?t=getDictionary&&p=Sex',
                 valueField: 'id',
                 textField: 'text'
             });

             //用户状态下拉框
             DicStatus = $('#DicStatus').combobox({
                 editable: false,
                 url: '/Actions/GetCombobox.ashx?t=getDictionary&&p=Status',
                 valueField: 'id',
                 textField: 'text'
             });
             //Cancel 取消修改
             $("#wincan").click(function () {
                 $('#win').window("close", true);
             });

             $("#resetCans").click(function () {
                 $('#win').window("close", true);
             });
             //查询提交
             $('#searchBtn').click(function () {
                 //  alert("123");
                 var username=$("#searchName").val();
                 var sectionId = $("#SectionID").val();
                 if(username==""){alert("请输入UserName")};
                 $('#dg').datagrid('load', {
                     t: 'search',
                     name: username,
                     sectionId: sectionId,
                 });
             });


             //验证
             // 字符验证 
             jQuery.validator.addMethod("stringCheck", function (value, element) {
                 return this.optional(element) || /^[\u0391-\uFFE5\w]+$/.test(value);
             }, "只能包括中文字、英文字母、数字和下划线");

             //验证用户名是否存在
             jQuery.validator.addMethod("checkUserName", function (value, element) {
                 var result = false;
                 $.ajaxSetup({
                     async: false
                 });
                 var param = {
                     userName: value
                 };
                 $.post("", param, function (data) {
                     result = (1 == data);
                 });
                 $.ajaxSetup({
                     async: true
                 });
                 return result;
             }, "用户名已经存在");


             //验证密码
             jQuery.validator.addMethod("checkPassWord", function (value, element) {
                 if ($("#Password").val() != $("#RePassword").val()) {
                     return false;
                 } else {
                     return true;
                 }
             }, "两次输入密码不一致");

             //表单验证
             $.metadata.setType("attr", "validate");
             $("#resetwin").validate({
                 submitHandler: function () {
                     var params = $("#resetwin").serialize();
                     var dataText = null;
                     var row = $('#dg').datagrid('getSelected');
                     $.ajax({
                         cache: false,
                         async: false,
                         url: "/Actions/UserInfoHandler.ashx?t=ResetPwd&&id=" + row.ID,
                         type: "post",
                         success: function (data) {
                             if (data == "success")//后台处理成功返回的数据
                             {
                                 $.messager.show({
                                     msg: ' Successfully Changed',
                                 });
                                 $('#resetwin').window('close');
                             }
                         },
                         error: function () { alert("发生错误，请联系管理员！"); },
                         data: params,
                         timeout: 10000
                     });
                 }
             });
             $("#editwindow").validate({
                 submitHandler: function () {
                     var params = $("#editwindow").serialize();
                     var dataText = null;
                     var row = $('#dg').datagrid('getSelected');                 
                     $.ajax({
                         cache: false,
                         async: false,
                         url: isEdit == "1" ? "/Actions/UserInfoHandler.ashx?t=EditUserOK&&id="+row.ID : "/Actions/UserInfoHandler.ashx?t=AddUser",//判断是添加还是修改
                         type: "post",
                         success: function (data) {
                             dataText = data;
                         },
                         error: function () { alert("错了"); },
                         data: params,
                         timeout: 10000
                     });
                     if (dataText == "succeed")//后台处理成功返回的数据
                     {
                         $.messager.show({
                             msg: ' Successfully added!',
                         });
                         $('#win').window('close');
                         $('#dg').datagrid("reload");
                     }
                     if (dataText == "")//后台处理不成功
                     {
                         alert("Error!Please contact administrator!test");
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
                         htmlArr.push('<div class="operateblock" id="' + arr2[i].PermissionCode+'" onclick="operate(\''+arr2[i].PermissionCode+'\')">');
                         htmlArr.push('<div class="icondiv"><img class="icon" src="' + getOperateIcon(arr2[i].PermissionCode) + '"/></div>');
                         htmlArr.push('<div class="title"><font color="blue">' + arr2[i].PermissionName + '</font></div>');
                         htmlArr.push('</div>');
                      }
                      $('#operate').html(htmlArr.join(''));
                 },
                 error: function () { alert("Error!Please contact administrator!"); }
             });

         });

       
         //增加或编辑用户
         function editUser(judge)
         {
             var row = $('#dg').datagrid('getSelected');
             //编辑修改
             if (judge > -1) {
                 if (row == null)
                 { alert("You have not selected! "); }
                 else {
                     $("#editwindow")[0].reset();
                 isEdit = 1;
                 $.ajax({
                     type: "get",
                     url: "/Actions/UserInfoHandler.ashx?t=EditUser&&id=" + row.ID,
                     success: function (data) {
                         var arr = eval(data);
                         for (var i = 0; i < arr.length; i++) {
                             $("#UserName").val(arr[i].UserName);
                             $("#RealName").val(arr[i].RealName);
                             $("#Section").combobox('setValue', arr[i].SectionID);
                             GetRole(row.ID);
                             $("#Telephone").val(arr[i].Telephone);
                             $("#QQ").val(arr[i].QQ);
                             $("#Email").val(arr[i].Email);
                             $("#DicSex").combobox('setValue',arr[i].DicSex);
                             $("#DicStatus").combobox('setValue',arr[i].DicStatus);
                             $("#passtd").attr("style", "display: none");
                             $("#repasstd").attr("style", "display: none");
                             $("#repasstd").attr("style", "display: none");
                             $("#Password").attr("style", "display: none");
                             $("#RePassword").attr("style", "display: none");
                         }
                     },
                     error: function () { alert("Error!Please contact administrator!"); }
                 });
                 //弹出弹窗
                 $('#win').window({title:"EditUser"});
                 $('#win').window('open');
             }
             } else {
                 isEdit = -1;
                 $("#editwindow")[0].reset();
                 $("#UserName").val("");
                 $("#RealName").val("");
                 $("#Section").combobox('setValue', "");
                 $("#Role").combobox('setValue',"");
                 $("#Telephone").val("");
                 $("#QQ").val("");
                 $("#Email").val("");
                 $("#DicSex").combobox('setValue', "");
                 $("#DicStatus").combobox('setValue', "");
                 $("#passtd").val("");
                 $("repasstd").val("");
                 $("#passtd").removeAttr("style");
                 $("#repasstd").removeAttr("style");
                 $("#Password").removeAttr("style");
                 $("#RePassword").removeAttr("style");
                 //$("#UserName").attr("validate", "{checkUserName:true}");
                 $("#Password").attr("validate", "{required:true,minlength:3,maxlength:15,stringCheck:true }");
                 $("#RePassword").attr("validate", "{required:true,minlength:3,maxlength:15,stringCheck:true,checkPassWord:true }");
                 ////弹出弹窗
                 $('#win').window({ title: "AddUser" });
                 $('#win').window('open');
             }
         }

         ////删除用户
         function deleteUser()
         {
             var row = $('#dg').datagrid('getSelected');
             if (row == null) {
                 alert("You have not selected! ");
             } else {
                 $.messager.confirm('确认', 'Are you sure you want to delete this record？', function (r) {
                     if (r) {
                         $.ajax({
                             type: "get",
                             async: false,
                             url: "/Actions/UserInfoHandler.ashx?t=DeleteUser&&id=" + row.ID,
                             success: function (data) {
                                 if (data == "Success") {
                                     $.messager.show({
                                         msg: ' Successfully Delete!',
                                     });
                                     $('#win').window('close');                                            
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
         //编辑时获取用户角色
         function GetRole(id) {
             $.ajax({
                 type: "get",
                 async: false,
                 url: "/Actions/UserInfoHandler.ashx?t=GetRole&&id=" + id,
                 success: function (data) {
                     var t = [];
                     var rolearr = eval(data);
                     for (var i = 0; i < rolearr.length; i++) {
                         t[i] = rolearr[i].RoleID;
                     }
                     $('#Role').combobox('setValues',t);
                 },
                 error: function () { alert("Error!Please contact administrator!"); }
             });
         }
      
         //重置密码
         function resetPwd() {
             var row = $('#dg').datagrid('getSelected');
             if (row == null) {
                 alert("You have not selected! ");
             } else { 
                 $('#resetPwd').window({ title: "ResetPassword" });
                 $('#resetPwd').window('open');
             } 
         }



         //// 获取操作图标
         function getOperateIcon(title) {
             var icon = "/Content/images/main/"; 
             icon =icon+title+ "_icon.png"; 
             return icon;
         };

         //操作功能
         function operate(title) {
             
             switch (title) {
                 case "Edit":
                     editUser(1);
                     break;
                 case "Add":
                     editUser(-1);
                     break;
                 case "Delete":
                     deleteUser();
                     break;
                 case "Emport":
                     emport();
                     break;
                 case "PwdSet":
                     resetPwd();
                     break;
                 default:
                     alert("default a");
                     break;
             }
         };

     </script>
</head>
<body>
    <table id="dg" data-options="toolbar:'#tb'">

    </table>
    <div id="tb" style="padding:5px;height:auto">
		<%--<div style="margin-bottom:5px">
			<a href="javascript:void(0)" onclick="editUser(-1)" class="easyui-linkbutton" iconCls="icon-add" plain="true">Add</a>
			<a href="javascript:void(0)" onclick="editUser(1)" class="easyui-linkbutton" iconCls="icon-edit" plain="true">Edit</a>
			<a href="javascript:void(0)" onclick="deleteUser()" class="easyui-linkbutton" iconCls="icon-remove" plain="true">Remove</a>
		</div>--%>
        <div id="operate"  class="operate">
        </div>
		<div id="searchBar">
            <form>
			    UserName: <input id="searchName" style="width:80px">
                 Section :
                            <input id="SectionID" class="easyui-combobox" name="SectionID" />
			    <input id="searchBtn" type="button"  value="Search"  iconCls="icon-search">

		    </form>
        </div>
	</div>
    <div id="win" class="easyui-window" closed="true" modal="true" shadow="true" minimizable="true" style="width:560px;height:400px;">
        <form id="editwindow" runat="server">
            <div style="text-align:center">
            <table  style="margin-bottom:10px" class="optable">
                <tr>
                        <td align="right">
                            UserName:
                        </td>
                        <td align="left">
                            <input id="UserName" name="UserName" />
                        </td>
                        <td class="status"></td>
                </tr>
                <tr>
                        <td align="right">
                            RealName:
                        </td>
                        <td align="left">
                            <input id="RealName" name="RealName" />
                        </td>
                    <td class="status"></td>
                </tr>
                 <tr>
                        <td id="passtd" align="right"> 
                            Password:
                        </td>
                        <td align="left">
                            <input id="Password" type="password" name="Password" />
                        </td>
                     <td class="status"></td>
                </tr>
                 <tr>
                        <td id="repasstd" align="right">
                            Confirm Password :
                        </td>
                        <td align="left">
                            <input id="RePassword" type="password" name="RePassword" />
                        </td>
                     <td class="status"></td>
                </tr>
                 <tr>
                        <td align="right">
                            Section :
                        </td>
                        <td align="left">
                            <input id="Section" name="Section" />
                        </td>
                     <td class="status"></td>
                </tr>
                <tr>
                        <td align="right">
                            Role :
                        </td>
                        <td align="left">
                            <input id="Role" name="Role" />
                        </td>
                    <td class="status"></td>
                </tr>
                 <tr>
                        <td align="right">
                            Telephone :
                        </td>
                        <td align="left">
                            <input id="Telephone" name="Telephone" />
                        </td>
                     <td class="status"></td>
                </tr>
                 <tr>
                        <td align="right">
                            QQ :
                        </td>
                        <td align="left">
                            <input id="QQ" name="QQ" />
                        </td>
                   <td class="status"></td>
                </tr>
                <tr>
                        <td align="right">
                            Email :
                        </td>
                        <td align="left">
                            <input id="Email" name="Email" />
                        </td>
                    <td class="status"></td>
                </tr>
                <tr>
                        <td align="right">
                            Sex :
                        </td>
                        <td align="left">
                            <input id="DicSex" name="DicSex" />
                        </td>
                    <td class="status"></td>
                </tr>
                <tr>
                        <td align="right">
                             Status:
                        </td>
                        <td align="left">
                            <input id="DicStatus" name="DicStatus" />
                        </td>
                    <td class="status"></td>
                </tr>
                <tr>
                        <td colspan="2" align="center">
                            <input id="winsub" type="submit" name="submit" value="Submit"/>
                            <input id="wincan" type="button" value="Cancel">
                        </td>
                </tr>
            </table>
           </div>
        </form>
    </div>
    <div id="resetPwd" class="easyui-window" closed="true" modal="true" shadow="true" minimizable="true" style="width:560px;height:100px;">
         <form id="resetwin">
             <table align="center">
                  <tr>
                        <td id="newPwdtd" align="right"> 
                            New Password:
                            <input id="newPassword" type="text" name="newPassword" />
                        </td>
                     <td></td>
                </tr>
                 <tr>
                        <td>
                            <input id="resetSub" type="submit" name="submit" value="Submit"/>
                            <input id="resetCan" type="button" value="Cancel">
                        </td>
                </tr>
             </table>
         </form>
    </div>
</body>
</html>
