<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SectionManager.aspx.cs" Inherits="ISSTSM.Views.Admin.SectionManager" %>

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
    <script src="../../Scripts/datagrid-detailview.js"></script>

     <script type="text/javascript">
         var Grid;
         var isEdit = 0;
         var $tbGrid = null;
         var subIndex;//子节点所在的行

         $(function(){  
             $("#dg").datagrid({  
                 heigth:700,     
                 idField:'id',  
                 url: '/Actions/SectionHandler.ashx?t=load&&ParentID=0',
                 singleSelect:true,  
                 fitColumns:true,  
                 nowrap: true,
                 height: '450',
                 pagination: true,
                 columns:[[  
                     { field: 'ID', title: 'ID', width: 50, editor: 'text', sortable: true },
                     { field: 'ParentID', title: 'ParentID', width: 50, editor: 'text', sortable: true },
                     { field: 'SectionName', title: 'SectionName', width: 100, editor: 'text', sortable: true },
                     { field: 'SectionCode', title: 'SectionCode', width: 100, editor: 'text', sortable: true },
                     { field: 'Description', title: 'Description', width: 100, editor: 'text', sortable: true }
                 ]],   
                 view: detailview,  
                 detailFormatter:function(index,row){  
                     return '<div style="padding:2px"><table id="ddv-' + index + '"></table></div>';  
                 },  
                 onExpandRow: function (index, row) {
                     subIndex = index;
                     $('#ddv-'+index).datagrid({  
                         url:'/Actions/SectionHandler.ashx?t=loadSub&&ParentID='+row.ID,  
                         fitColumns:true,  
                         singleSelect:true,  
                         rownumbers:true,  
                         loadMsg:'Loading',  
                         height:'auto',  
                         columns:[[  
                             {field:'ID',title:'ID',width:50},  
                             {field:'ParentID',title:'ParentID',width:50,align:'right'},  
                             {field:'SectionName',title:'SectionName',width:100,align:'right'},
                             {field:'SectionCode',title:'SectionCode',width:100,align:'right'},
                             {field:'Description',title:'Description',width:100,align:'right'},
                             {field:'Sort',title:'Sort',width:100,align:'right'}
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
             });
             var p = $('#dg').datagrid('getPager');
             $(p).pagination({
                 pageSize: 10,
                 pageList: [10, 20, 50]
             });
         });  

         $(function () {

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
             //Cancel 取消修改
             $("#wincan").click(function () {
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
                         url: isEdit == "1" ? "/Actions/SectionHandler.ashx?t=edit" : "/Actions/SectionHandler.ashx?t=add",//判断是添加还是修改
                         type: "post",
                         success: function (data) {
                             dataText = data;
                         },
                         data: params,
                         timeout: 10000
                     });
                     if (dataText == "Success")//后台处理成功返回的数据
                     {
                         $.messager.show({
                             msg: ' Successfully !',
                         });
                         $('#win').window('close');
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

         
         //增加或者编辑父子节点：父节点增加时，不要选中行，子节点增加时，要选中父节点
         function edit(judge) {
             var row = $('#dg').datagrid('getSelected');
             var subrow;
             if (subIndex != null) {
                 subrow = $('#ddv-' + subIndex).datagrid('getSelected');
             }
             //编辑
             if (judge > -1) {
                 if (row == null&&subrow==null)
                 { alert("You have not selected! "); }
                 else {
                     isEdit = 1;
                     $.ajax({
                         type: "get",
                         url: subrow == null ? "/Actions/SectionHandler.ashx?t=edit&&editOrload=load&&id=" + row.ID : "/Actions/SectionHandler.ashx?t=edit&&editOrload=load&&id=" + subrow.ID,
                         success: function (data) {
                             var arr = eval(data);
                             for (var i = 0; i < arr.length; i++) {
                                 $("#ID").val(arr[i].ID);
                                 $("#ParentID").val(arr[i].ParentID);
                                 $("#SectionName").val(arr[i].SectionName);
                                 $("#SectionCode").val(arr[i].SectionCode);
                                 $("#Description").val(arr[i].Description);
                                 $("#Sort").val(arr[i].Sort);
                             }
                         },
                         error: function () { alert("Error!Please contact administrator!"); }
                     });
                     //弹出弹窗
                     $('#win').window({ title: "EditSection" });
                     $('#win').window('open');
                 }
             }
                 //增加 父节点增加时，不要选中行，子节点增加时，要选中父节点
             else {
                 $("#SectionName").val("");
                 $("#SectionCode").val("");
                 $("#Description").val("");
                 $("#Sort").val("");
                 //弹出弹窗
                 $('#win').window({ title: "AddSection" });
                 $('#win').window('open');
                 //增加父节点
                 if (row == null) {
                     $("#ParentID").val("0");
                 }
                 else {
                     $("#ParentID").val(row.ID);
                 }
             }
         }

         ////删除子节点
         function del() {
             var row = $('#dg').datagrid('getSelected');
             var subrow;
             if (subIndex != null) {
                 subrow = $('#ddv-' + subIndex).datagrid('getSelected');
             }
             if (row == null&&subrow==null) {
                 alert("You have not selected! ");
             }
             else {
                 $.messager.confirm('确认', 'Are you sure you want to delete this record？', function (r) {
                     if (r) {
                         $.ajax({
                             type: "get",
                             async: false,
                             url: subrow == null ? "/Actions/SectionHandler.ashx?t=del&&id=" + row.ID : "/Actions/SectionHandler.ashx?t=del&&id=" + subrow.ID,
                             success: function (data) {
                                 if (data == "Success") {
                                     //$.messager.show({
                                     //    msg: ' Successfully Delete!',
                                     //});
                                     //$('#win').window('close');                                            
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
                        <td align="left">
                            ParentID:
                            <input id="ParentID" name="ParentID" />
                        </td>
                </tr>
                <tr>
                        <td align="left">
                            SectionName:
                            <input id="SectionName" name="SectionName" />
                        </td>
                </tr>
                 <tr>
                        <td id="passtd" align="left"> 
                            SectionCode:
                            <input id="SectionCode"  name="SectionCode" />
                        </td>
                </tr>
                 <tr>
                        <td align="left">
                            Description :
                            <input id="Description"  name="Description" />
                        </td>
                </tr>
                <tr>
                        <td align="left">
                            Sort :
                            <input id="Sort" name="Sort" />
                        </td>
                </tr>

                <tr>
                        <td>
                            <input id="winsub" type="submit"  value="Submit"/>
                            <input id="wincan" type="button" value="Cancel" />
                        </td>
                </tr>
            </table>
           </div>
        </form>
    </div>
</body>
</html>


