<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TSStaffManager.aspx.cs" Inherits="ISSTSM.Views.Staff.TSStaffManager" %>

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
         var subIndex;//子节点所在的行
         var userID;

         $(function () {
             userID = $("#userID").val();
             $("#dg").datagrid({
                 heigth: 700,
                 idField: 'ID',
                 url: '/Actions/TimeSheetHandler.ashx?view=staff&&t=loadStaffTS&&userID='+userID,
                 singleSelect: true,
                 fitColumns: true,
                 nowrap: true,
                 height: '450',
                 pagination: true,
                 columns: [[
                     {
                         field: 'Date', title: 'Date', width: 50, editor: 'text', sortable: true, formatter: function (value) {
                             return $.globalParas.changeDateFormat(value);
                         }
                     },
                     { field: 'IncidentName', title: 'IncidentName', width: 80, editor: 'text', sortable: true },
                     { field: 'BillableHour', title: 'BillableHour', width: 20, editor: 'text', sortable: true },
                      { field: 'UserName', title: 'UserName', width: 50, editor: 'text', sortable: true },
                      { field: 'DicTitleName', title: 'TitleName', width: 50, editor: 'text', sortable: true },
                     { field: 'DicProjectName', title: 'ProjectName', width: 50, editor: 'text', sortable: true },
                     { field: 'DicGroupName', title: 'GroupName', width: 60, editor: 'text', sortable: true },
                     { field: 'DicTypeName', title: 'TypeName', width: 50, editor: 'text', sortable: true },
                      { field: 'SubProject', title: 'SubProject', width: 150, editor: 'text', sortable: true },
                      { field: 'Tasks', title: 'Tasks', width: 150, editor: 'text', sortable: true }
                 ]],
             });
             var p = $('#dg').datagrid('getPager');
             $(p).pagination({
                 pageList: [20, 50, 100]
             });
         });

         $(function () {

             //查询提交
             $('#searchForm').submit(function () {
                 if ($('#searchForm').form('validate')) {
                     $('#dg').datagrid({
                         queryParam: $('#searchForm').serializeJson()
                     });
                 }
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
                         url: isEdit == "1" ? "/Actions/DictionaryHandel.ashx?t=edit" : "/Actions/DictionaryHandel.ashx?t=add",//判断是添加还是修改
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
                 if (row == null && subrow == null)
                 { alert("You have not selected! "); }
                 else {
                     isEdit = 1;
                     $.ajax({
                         type: "get",
                         url: subrow == null ? "/Actions/DictionaryHandel.ashx?t=edit&&editOrload=load&&id=" + row.ID : "/Actions/DictionaryHandel.ashx?t=edit&&editOrload=load&&id=" + subrow.ID,
                         success: function (data) {
                             var arr = eval(data);
                             for (var i = 0; i < arr.length; i++) {
                                 $("#ID").val(arr[i].ID);
                                 $("#ParentID").val(arr[i].ParentID);
                                 $("#ItemCode").val(arr[i].ItemCode);
                                 $("#ItemName").val(arr[i].ItemName);
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
                 $("#ItemCode").val("");
                 $("#ItemName").val("");
                 $("#Sort").val("");
                 //弹出弹窗
                 $('#win').window({ title: "AddDictionary" });
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

         function fillTS() {
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
                 case "Emport":
                     emport();
                     break;
                 case "FillTS":
                     fillTS();
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
		<div id="searchBar">
            <form id="searchForm">
			    ItemName: <input id="SearchItemName" style="width:80px" />
			    <input type="submit"  value="Search"  iconCls="icon-search" />
		    </form>
        </div>
	</div>

    <div id="win" class="easyui-window" closed="true" modal="true" shadow="true" minimizable="true" style="width:560px;height:400px;">
        <form id="editwindow" runat="server">
            <div style="text-align:center">
            <table align="center" style="margin-bottom:10px" class="optable">
                 <tr>
                    <td><input type="hidden" id="ID" name="ID" /></td>  
                     <td><input type="hidden" id="userID" name="userID"  value="<%=CurUser.ID %>"/> </td>  
                </tr>
                <tr>
                        <td> IncidentNumber:</td>
                       <td >
                            <input id="IncidentNumber" name="IncidentNumber" />
                        </td>
                </tr>
                  <tr>
                     <td> Date:</td>
                        <td > 
                            <input id="Date" type="text"name="Date" />
                        </td>
                </tr>
                <tr>
                        
                            <td> BillableHour: </td>
                    <td>
                            <input id="BillableHour" name="BillableHour" />
                        </td>
                </tr>
                 <tr>
                     <td> Title:  </td>
                     <td>
                            <input id="Title"  name="Title" />
                        </td>
                </tr>
                <tr>
                    <td> Project : </td>
                        <td >
                              <input id="Project" name="Project" />
                        </td>
                </tr>
                 <tr>
                                    <td> Group:  </td>
                        <td >
                            <input id="Group" name="Group" />
                        </td>
                </tr>
                <tr>
                     <td>  Type:  </td>
                        <td >
                            <input id="Type" name="Type" />
                        </td>
                </tr>

                <tr>
                    <td> SubProject : </td>
                        <td >
                           <input id="SubProject" name="SubProject" />
                        </td>
                </tr>                
                <tr>
                    <td>  Tasks:</td>
                        <td >
                            <input  id="Tasks" name="Tasks" />
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

</body>
</html>
