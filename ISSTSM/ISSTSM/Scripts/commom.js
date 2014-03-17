function Commom(data, callback) {
    if (data.status == -1) {
        msgbox.showMsgOk(data.stateStr);
    } else if (data.status == 304) {
        msgbox.showMsgOk(data.stateStr, function () {
            window.location = data.url;
        });
    } else {
        callback();
    }
}