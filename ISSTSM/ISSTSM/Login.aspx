<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ISSTSM.Login" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Avon TimeSheet System Beta 1.0</title>
    <link href="/css/userlogin.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.8.0.min.js"></script>
    <script src="Scripts/msgBox.js"></script>
</head>
<body>

    <form id="form1">
        <div id="mainContent">
            <table class="logintb" cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td style="height: 65px; text-align: center; color: #014477; font-size: 20px; font-family: 微软雅黑;" colspan="2"></td>
                </tr>
                <tr>
                    <th>用户名:
                    </th>
                    <td>
                        <input class="inpt" id="account" name="username" type="text" value="admin" />
                    </td>
                </tr>
                <tr>
                    <th>密码: 
                    </th>
                    <td>
                        <input class="inpt" id="pwd" name="pwd" type="password" value="123456" />

                    </td>
                </tr>
                <tr>
                    <th></th>
                    <td>
                        <input type="checkbox" name="ismember" id="ismember" />是否记住登录信息
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <img id="btnLogin" src="/images/login_bt.png" />
                    </td>
                </tr>


                <tr>
                    <td colspan="2" style="height: 20px"></td>
                </tr>
            </table>
        </div>

    </form>

    <script type="text/javascript">
        var msgbox = new MsgBox({ imghref: "/imgs/" });
        //1.0登录方法
        function login() {
            var parms = $("form").serialize();
            //ajax请求
            $.post("Actions/Login.ashx?t=login&&rid=" + Math.random(), parms, function (data) {
                if (data.status == 100) {
                    window.location.href = data.url;
                } else {
                    msgbox.showMsgErr(data.stateStr);
                }

            }, "json");
        }

        $(function () {
            $("#account").keydown(function (e) {
                if (e.keyCode == 13) {
                    $("#pwd").focus();
                }
            });

            $("#pwd").keydown(function (e) {
                if (e.keyCode == 13) {
                    login();
                }
            });

            $("#btnLogin").keydown(function (e) {
                if (e.keyCode == 13) {
                  login();
                }
            })
            $("#btnLogin").click(function (e) {
                    login();
            })
        });
    </script>

</body>
</html>
