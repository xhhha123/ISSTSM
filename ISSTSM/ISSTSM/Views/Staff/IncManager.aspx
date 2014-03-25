<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IncManager.aspx.cs" Inherits="ISSTSM.Views.Staff.IncManager" %>

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
         var Title;
         var Project;
         var Country;
         var Group;
         var Type;
         var userID;

         $(function () {
             userID = $("#userID").val();
             $('#dateBefore').datebox({
                 formatter: function (date) { return date.getFullYear() + '-' + (date.getMonth() + 1) + '-' + date.getDate(); },
             });
             $('#dateAfter').datebox({
                 formatter: function (date) { return date.getFullYear() + '-' + (date.getMonth() + 1) + '-' + date.getDate(); },
             });
             $('#Date').datebox({
                 required: true,
                 formatter: function (date) { return date.getFullYear() + '-' + (date.getMonth() + 1) + '-' + date.getDate(); },
             });
             $("#dg").datagrid({
                 heigth: 700,
                 idField: 'ID',
                 url: '/Actions/IncHandlers.ashx?view=staff&&t=loadStaff&&userID='+userID,
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
                     { field: 'IncidentNumber', title: 'IncidentNumber', width: 150, editor: 'text', sortable: true },
                      { field: 'ReportedByName', title: 'ReportedBy', width: 100, editor: 'text', sortable: true },
                      { field: 'DicPriotityName', title: 'Priotity', width: 100, editor: 'text', sortable: true },
                     { field: 'DicCountryName', title: 'Country', width: 100, editor: 'text', sortable: true },
                     { field: 'DicProductName', title: 'Product', width: 100, editor: 'text', sortable: true },
                     { field: 'DicStatusName', title: 'Status', width: 50, editor: 'text', sortable: true },
                      { field: 'StatusFollowUp', title: 'StatusFollowUp', width: 120, editor: 'text', sortable: true }
                 ]],
             });
             var p = $('#dg').datagrid('getPager');
             $(p).pagination({
                 pageList: [20, 50, 100]
             });
         });

         $(function () {
             //加载AssignedTo下拉框
             Title = $('#Title').combobox({
                 editable: false,
                 url: '/Actions/GetCombobox.ashx?t=getDictionary&&p=Title',
                 valueField: 'id',
                 textField: 'text'
             });
             //加载Priority下拉框
             Project = $('#Project').combobox({
                 editable: false,
                 url: '/Actions/GetCombobox.ashx?t=getDictionary&&p=Project',
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
             Group = $('#Group').combobox({
                 editable: false,
                 url: '/Actions/GetCombobox.ashx?t=getDictionary&&p=Group',
                 valueField: 'id',
                 textField: 'text'
             });
             //加载DicStatus下拉框
             Type = $('#Type').combobox({
                 editable: false,
                 url: '/Actions/GetCombobox.ashx?t=getDictionary&&p=Type',
                 valueField: 'id',
                 textField: 'text'
             });

             //查询提交
             $('#searchBtn').click(function () {
                 var IncidentNumber = $("#SearchIncidentNumber").val();
                 var dateBefore = $('#dateBefore').datebox('getValue');// 3/6/2014
                 var dateAfter = $('#dateAfter').datebox('getValue');
                 // IncidentNumber验证以及日期验证
                 if (Date.parse(dateBefore) > Date.parse(dateAfter)) {
                     alert("结束时间应该大于开始时间");
                     return;
                 }
                 //判断日期
                 if (IncidentNumber == "" && dateBefore == "" && dateAfter == "") {
                     alert("至少输入一个查询条件")
                 };
                 $('#dg').datagrid('load', {
                     t: 'search',
                     IncidentNumber: IncidentNumber,
                     dateBefore: dateBefore,
                     dateAfter: dateAfter
                 });
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
                         url: "/Actions/TimeSheetHandler.ashx?view=staff&&t=AddStaffTS",
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

         //填写TimeSheet
         function FillTS() {
             var row = $('#dg').datagrid('getSelected');
             if (row == null)
             { alert("You have not selected! "); }
             else {
                 //弹出弹窗
                 $("#ID").val(row.ID);
                 $("#IncidentNumber").val(row.IncidentNumber);
                 $('#win').window({ title: "AddIncident" });
                 $('#win').window('open');
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
                 case "FillTS":
                     FillTS();
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
               <form >
			    IncidentNumber: <input id="SearchIncidentNumber" type="text" style="width:180px;" />
                从：<input id="dateBefore" type="text" class="easyui-datebox" style="width:80px;" />
                到：<input id="dateAfter" type="text" class="easyui-datebox" style="width:80px;" />
			    <input id="searchBtn" type="button"  value="Search"  iconCls="icon-search"/>
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

