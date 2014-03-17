<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="RTTSM.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>ISS TimeSheet</title>
    <link href="Content/themes/default/easyui.css" rel="stylesheet" />
    <link href="Content/themes/icon.css" rel="stylesheet" />
    <link href="Content/index.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.8.0.min.js"></script>
    <script src="Scripts/jquery.easyui.min.js"></script>
    <script src="Scripts/jquery.easyui.GlobalParas.js"></script>

    <script type="text/javascript">
        //提供给 iframe里子页面 操作当前页面 的一些便捷 方法
        var topHelper = {

        };
        $(function () {

            //1.加载左侧菜单模块
            $("#moduelTree").tree({
                url: "Actions/GetTest.ashx",
                animate: true,
                lines: true,
                onClick: nodeClick//function (nodeData) { nodeClick(nodeData); }
            });
            //2.初始化 tab容器
            $("#tabBox").tabs();

            //3.初始化 公共窗体，并设置为关闭状态,最后将此 窗体对象 赋值给 topHelper.comWin 属性
            topHelper.comWin = $("#commonWindow").window({
                //collapsible: false,
                minimizable: false,
                //maximizable: false,
                closable: true,
                width: 1200,
                height: 500,
                modal: true
            }).window("close");

            //3.1添加一个 打开公共窗体的方法
            topHelper.showComWindow = function (title, url, width, height) {
                var trueTitle = "公共窗体";
                var trueWidth = 1200;
                var trueHeight = 500;
                if (title) trueTitle = title;
                if (width && parseInt(width) > 10) trueWidth = width;
                if (height && parseInt(height) > 10) trueHeight = height;
                //判断是否置顶url，如果有，则 设置 公共窗体里的 iframe 的src
                if (url && url.length && url.length > 10) {
                    $("#commonWindow iframe").attr("src", url);
                }

                //重新设置 窗体的 大小，并自动居中，然后才显示
                topHelper.comWin.window({
                    title: trueTitle,
                    width: trueWidth,
                    height: trueHeight
                }).window("center").window("open");
            };

            //3.2 添加一个 关闭 公共窗体方法
            topHelper.closeComWindow = function () {
                topHelper.comWin.window("close");
            }
            //3.3 为公共窗体 里的 iframe 绑定一个 onload 事件方法，在加载完页面后，关闭进度条
            $("#comFrame").load(function () {
                $.globalParas.progressClose();
            });

            //3.4修改密码
            $('#reset').click(function () {
                var userid = $("#userID").val();
                var newPwd = $("#newPassword").val();
                $.ajax({
                    type: "POST",
                    url: "/Actions/UserInfoHandler.ashx",
                    data: "t=ResetPwd&&id=" + userid + "&&newPassword=" + newPwd,
                    success: function (data) {
                        if (data == "success")//后台处理成功返回的数据
                        {
                            alert(data);
                            $('#resetPwd').window('close');
                        }
                    }
                });
            });

        });

        var curNodeData = null;
        //1.0树节点点击方法
        function nodeClick(nodeData) {
            curNodeData = nodeData;
            var $tabBox = $("#tabBox");
            //1.1如果 已经有 与选中节点 同名选项卡，则 重新选中 同名选项卡
            if ($tabBox.tabs("exists", nodeData.text)) {
                //判断当前选中的选项卡 是否 和 与选中节点 文字一样
                //获取选中的 选项卡对象
                var curTab = $tabBox.tabs('getSelected');
                //获取当前选中的选项卡 的标题：调用当前选项卡 的 options方法 获取 选项卡的 属性集合对象，然后获取 title属性值
                var curTabTitle = $(curTab).panel("options").title;
                //a.如果一样，刷新当前选中的选项卡
                if (curTabTitle == nodeData.text) {
                    $.messager.confirm('是否刷新', '您确定要刷新当前【' + curTabTitle + '】面板吗？', function (isOk) {
                        if (isOk) {
                            $tabBox.tabs('update', {
                                tab: curTab,//刷新当前选中面板
                                options: {
                                    content: makeIframe(nodeData.attributes.href)//重新设置 选中选项卡 对应的 面板 内容
                                }
                            });
                        }
                    });

                }
                    //b.如果不一样，选中 与选中节点 文字一样 的选项卡
                else {
                    $tabBox.tabs("select", nodeData.text);
                }

            }
                //1.2如果 没有 与选中节点 同名选项卡，则 创建 新的
            else {
                $tabBox.tabs("add", {
                    title: nodeData.text,
                    content: makeIframe(nodeData.attributes.href),
                    closable: true
                });
            }
        }

        function makeIframe(href) {
            return "<iframe src='" + href + "?menutreeid=" + $('#moduelTree').tree('getSelected').id+ "' style='border:0px;margin:0px; padding:5px; width:99%;height:460px;'></iframe>";
        }

        //2.0 新增或修改成功后，可通过此方法 更新 tab里的 dggrid组件
        function updateDataGridInTab() {
            //1.获取 后台首页的 tab容器
            var $tabBox = $("#tabBox");
            //2.获取选中的tab
            var $curTab = $tabBox.tabs('getSelected');
            //3.从选中的 tab 中 获取 iframe，并以jq对象返回
            var $ifram = $("iframe", $curTab);
            //4.从jq对象中获取iframe，并通过伟大的 contentWindow 对象 操作iframe里的 window 的全局变量 $tbGrid
            $ifram[0].contentWindow.$tbGrid.datagrid("reload");
        }

        //3.0 更改密码弹出窗口
        function repassword() {
            $("#newPassword").val("");
            $('#resetPwd').window({ title: "ResetPassword" });
            $('#resetPwd').window('open');
        };
        //4.0 退出登录
        function logout() {
            location.href = "Login.aspx";
        };

    </script>
</head>

<body class="easyui-layout"> 
    <div data-options="region:'north',border:false" style="height:60px;background:#B3DFDA">
        <div class="logo" id="logo"><input type="hidden" id="userID" value="<%=CurUser.ID %>" /></div>
        <div class="login_msg" id="login_msg">
          Welcome！<%=CurUser.RealName %> <a style="" href="javascript:void(0)"
            onclick="repassword()">[Change Password]</a>&nbsp;&nbsp; <a style="" href="javascript:void(0)" onclick="logout()">
                [Log Out]</a>
        </div>
    </div>
	<div data-options="region:'west',split:true,title:'Menu'" style="width:250px;padding:10px;">
       <ul id="moduelTree"></ul>
	</div>
    
	<%--    tab选项框--%>
    <div data-options="region:'center'" style="padding:5px;background:#fff;">
        <div id="tabBox"></div>
    </div>
    <!--公共窗体-->
    <div id="commonWindow"><iframe id="comFrame" style="width:99%;height:95%;border:0px;"></iframe></div>
<%--    底部版权信息--%>
	<div data-options="region:'south',border:false" style="height:25px;padding:10px;">
        <div class="bottom">
        <b>Copyright：</b>ISS TimeSheet &nbsp;&nbsp;&nbsp;&nbsp;<b>Technical Support：</b> iSoftStone
        </div>
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
                            <input id="reset" type="button"  value="Submit"/>
                            <input id="resetCan" type="button" value="Cancel"/>
                        </td>
                </tr>
             </table>
         </form>
    </div>
</body>
</html>