
$.post("/Actions/GetModulePermission.ashx?t=operate", {}, function (data) {
    var htmlArr = [];
    htmlArr.push('<div style="margin-bottom:5px">');
    for (var i = data.length - 1; i >= 0; i--) {
        htmlArr.push('<a href="javascript:void(0)" onclick="operate(' + data[i].PemissionCode + ')">' + 'class="easyui-linkbutton" ' + 'iconCls="icon-' + data[i].PemissionCode + '" plain="true">' + data[i].PemissionCode + '</a>');
    }
    htmlArr.push('</div>');
    $('#tb').html(htmlArr.join(''));
}, "json");