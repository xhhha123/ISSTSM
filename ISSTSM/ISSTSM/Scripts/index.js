var MenuData;


//根据用户权限取得菜单
$(window).ready(function () {
    resizePage();
    $.post("", {}, function (data) {
        MenuData = data;
        createLeftMenu();
    }, "json");

    //创建左边菜单
    function createLeftMenu(){
        var htmlArr=[];
        
        if (MenuData && MenuData.length > 0) {
            for (var i = 0; i < MenuData.length; i++) {
                htmlArr.push('<div class="nav_banner" onclick="clickLeftMenuBanner(' + i + ')"><div class="icondiv">' + MenuData[i].title + '</div></div>');
                var children = MenuData[i].children;
                if (children && children.length > 0) {
                    htmlArr.push('<ul>');
                    for (var j = 0; j < children.length; j++) {
                        htmlArr.push('<li><img src="/Content/images/main/bg_sub_list.gif" /><span onclick="clickSndMenu('  i + ',' + j + ')">' + children[j].title + '</span></li>');
                    }
                    htmlArr.push('</ul>');
                }
            }
        }
        $("#left_nav").html(htmlArr.join(''));
        clickSndMenu(0, 0);
    };

    // 点击左部菜单事件
    function clickSndMenu(i, j, k) {
        var url = MenuData[i].children[j].href;
        $('#mainFrame').attr("src", url);
        var title = MenuData[i].children[j].title;
        $('.middle .main .layout_banner').html(title);
    };

    // 点击折叠二级菜单
    function clickLeftMenuBanner(idx) {
        //var divObj = $($("#left_nav .nav_banner")[idx]);
        //var ulObj = $($("#left_nav ul")[idx]);
        var divObj = $("#left_nav .nav_banner:eq(" + idx + ")");
        var ulObj = $("#left_nav ul:eq(" + idx + ")");
        if (ulObj.is(":hidden")) {
            ulObj.show("fast");
            divObj.find("div").removeClass("icondiv_zhe").addClass("icondiv");
        } else {
            ulObj.hide("fast");
            divObj.find("div").removeClass("icondiv").addClass("icondiv_zhe");
        }
    };