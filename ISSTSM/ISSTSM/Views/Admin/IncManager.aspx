<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IncManager.aspx.cs" Inherits="ISSTSM.Views.Admin.IncManager" %>

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
         var AssignedTo;
         var DicPriority;
         var DicCountry;
         var DicProduct;
         var DicStatus;

         $(function () {
             $('#CreateDate').datebox({
                 required: true,
                 formatter: function (date) { return date.getFullYear() + '-' + (date.getMonth() + 1) + '-' + date.getDate(); },
             });
             $("#dg").datagrid({
                 heigth: 700,
                 idField: 'ID',
                 url: '/Actions/IncHandlers.ashx?view=admin&&t=loadAdmin',
                 singleSelect: true,
                 fitColumns: true,
                 nowrap: true,
                 height: '450',
                 pagination: true,
                 columns: [[
                     {
                         field: 'CreateDate', title: 'CreateDate', width: 80, editor: 'text', sortable: true, formatter: function (value) {
                             return $.globalParas.changeDateFormat(value);
                         }
                     },
                     { field: 'IncidentNumber', title: 'IncidentNumber', width: 100, editor: 'text', sortable: true },
                     { field: 'AssignedToName', title: 'AssignedTo', width: 60, editor: 'text', sortable: true },
                      { field: 'ReportedByName', title: 'ReportedBy', width: 70, editor: 'text', sortable: true },
                      { field: 'DicPriotityName', title: 'Priotity', width: 60, editor: 'text', sortable: true },
                     { field: 'DicCountryName', title: 'Country', width:60, editor: 'text', sortable: true },
                     { field: 'DicProductName', title: 'Product', width: 60, editor: 'text', sortable: true },
                     { field: 'DicStatusName', title: 'Status', width: 50, editor: 'text', sortable: true },
                      { field: 'StatusFollowUp', title: 'StatusFollowUp', width: 120, editor: 'text', sortable: true },
                      { field: 'Summary', title: 'Summary', width: 120, editor: 'text', sortable: true },
                     { field: 'Description', title: 'Description', width: 120, editor: 'text', sortable: true }
                 ]],
             });
             var p = $('#dg').datagrid('getPager');
             $(p).pagination({
                 pageList: [20, 50, 100]
             });
         });

         $(function () {
             //加载AssignedTo下拉框
             AssignedTo = $('#AssignedTo').combobox({
                 editable: false,
                 url: '/Actions/GetCombobox.ashx?t=AssignedTo',
                 valueField: 'id',
                 textField: 'text'
             });
             //加载Priority下拉框
             Priority = $('#Priority').combobox({
                 editable: false,
                 url: '/Actions/GetCombobox.ashx?t=getDictionary&&p=Priority',
                 valueField: 'id',
                 textField: 'text'
             });
             //加载Country下拉框
             Country = $('#Country').combobox({
                 editable: false,
                 url: '/Actions/GetCombobox.ashx?t=getDictionary&&p=Country',
                 valueField: 'id',
                 textField: 'text'
             });
             //加载Product下拉框
             Product = $('#Product').combobox({
                 editable: false,
                 url: '/Actions/GetCombobox.ashx?t=getDictionary&&p=Product',
                 valueField: 'id',
                 textField: 'text'
             });
             //加载DicStatus下拉框
             Status = $('#Status').combobox({
                 editable: false,
                 url: '/Actions/GetCombobox.ashx?t=getDictionary&&p=Status',
                 valueField: 'id',
                 textField: 'text'
             });

             //查询提交
             $('#searchForm').submit(function () {
                 if ($('#searchForm').form('validate')) {
                     $('#dg').datagrid({
                         queryParam: $('#searchForm').serializeJson()
                     });
                 }
             });
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
                         url: isEdit == "1" ? "/Actions/IncHandlers.ashx?view=admin&&t=editAdmin" : "/Actions/IncHandlers.ashx?view=admin&&t=addAdmin",//判断是添加还是修改
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
                         $('#dg').datagrid('clearSelections');
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
                         url: "/Actions/IncHandlers.ashx?view=admin&&t=editAdmin&&editOrload=load&&id=" + row.ID,
                         success: function (data) {
                             var arr = eval(data);
                             for (var i = 0; i < arr.length; i++) {
                                 $("#ID").val(arr[i].ID);
                                 $("#IncidentNumber").val(arr[i].IncidentNumber);
                                 $("#AssignedTo").combobox('setValue', arr[i].AssignedTo);
                                 $("#Priority").combobox('setValue', arr[i].DicPriority);
                                 $("#Country").combobox('setValue', arr[i].DicCountry);
                                 $("#Product").combobox('setValue', arr[i].DicProduct);
                                 $("#Status").combobox('setValue', arr[i].DicStatus);
                                 $('#CreateDate').datebox('setValue', $.globalParas.changeDateFormat(arr[i].CreateDate));
                                 $("#StatusFollowUp").val(arr[i].StatusFollowUp);
                                 $("#Summary").val(arr[i].Summary);
                                 $("#Description").val(arr[i].Description);
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
                 $("#ID").val("");
                 $("#IncidentNumber").val("");
                 $("#AssignedTo").combobox('setValue',"");
                 $("#Priority").combobox('setValue', "");
                 $("#Country").combobox('setValue', "");
                 $("#Product").combobox('setValue', "");
                 $("#Status").combobox('setValue', "");
                 $('#CreateDate').datebox('setValue',"");
                 $("#StatusFollowUp").val("");
                 $("#Summary").val("");
                 $("#Description").val("");
                 //弹出弹窗
                 $('#win').window({ title: "AddIncident" });
                 $('#win').window('open');
             }
         }

         ////删除子节点
         function del() {
             var row = $('#dg').datagrid('getSelected');
             if (row == null ) {
                 alert("You have not selected! ");
             }
             else {
                 $.messager.confirm('确认', 'Are you sure you want to delete this record？', function (r) {
                     if (r) {
                         $.ajax({
                             type: "get",
                             async: false,
                             url: "/Actions/IncHandlers.ashx?view=admin&&t=delAdmin&&id=" + row.ID,
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
                     <td><input type="hidden" id="ReportedBy" name="ReportedBy"  value="<%=CurUser.ID %>"/></td>                         
                </tr>
                <tr>
                        <td> IncidentNumber:</td>
                       <td >
                            <input id="IncidentNumber" name="IncidentNumber" />
                        </td>
                </tr>
                <tr>
                        
                            <td> AssignedTo: </td>
                    <td>
                            <input id="AssignedTo" name="AssignedTo" />
                        </td>
                </tr>
                 <tr>
                     <td> Priority:  </td>
                     <td>
                            <input id="Priority"  name="Priority" />
                        </td>
                </tr>
                <tr>
                    <td> Country : </td>
                        <td >
                              <input id="Country" name="Country" />
                        </td>
                </tr>
                 <tr>
                                    <td> Product:  </td>
                        <td >
                            <input id="Product" name="Product" />
                        </td>
                </tr>
                <tr>
                     <td>  Status:  </td>
                        <td >
                            <input id="Status" name="Status" />
                        </td>
                </tr>
                 <tr>
                     <td> CreateDate:</td>
                        <td > 
                            <input id="CreateDate" type="text"name="CreateDate" />
                        </td>
                </tr>
                <tr>
                    <td> StatusFollowUp : </td>
                        <td >
                           <input id="StatusFollowUp" name="StatusFollowUp" />
                        </td>
                </tr>                
                <tr>
                    <td>  Summary:</td>
                        <td >
                            <input  id="Summary" name="Summary" />
                        </td>
                </tr>
             <tr>
                 <td> Description:</td>
                        <td >
                            <input id="Description" name="Description" />
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
