Ext.onReady(function () {
    var tabs = new Ext.TabPanel({
        renderTo: 'tabs1',
        width: 800,
        activeTab: 0,
        frame: true,
        defaults: { autoHeight: true },
        items: [
            { contentEl: 'resetPw', title: '修改密码' },
            { contentEl: 'test1', title: 'test' }
        ]
    });


    var resetPwBt = Ext.get("resetPwBt");
    resetPwBt.on("click", function submitset() {

        var oldpw = Ext.get("oldPw").getValue();
        var newpw = Ext.get("newPw").getValue();
        var newpw_c = Ext.get("newPw_c").getValue();
        if (oldpw == '' || newpw == "" || newpw_c == '') {
            Ext.Msg.alert("提示", "  填写不能为空   ");
            return;
        }
        if (newpw != newpw_c) {

            Ext.Msg.alert("提示", "两次新密码输入不一样！");
            return;
        }

        //resetMyPassWord
        var myMask = new Ext.LoadMask(Ext.getBody(), {
            msg: "请稍等正在保存...."
        });
        myMask.show();
        Ext.Ajax.request({
            url: 'user/resetMyPassWord.ashx',
            params: {
                oldpw: oldpw,
                newpw: newpw
            },
            success: function (response) {

                var success = Ext.util.JSON.decode(response.responseText).success;
                var msg = Ext.util.JSON.decode(response.responseText).msg;
                if (success) {
                    myMask.hide();
                    Ext.Msg.show({
                        title: '成功提示',
                        msg: msg,
                        buttons: Ext.Msg.OK,
                        fn: function () {
                            document.getElementById("oldPw").value = "";
                            document.getElementById("newPw").value = "";
                            document.getElementById("newPw_c").value = "";
                        },
                        icon: Ext.Msg.INFO
                    });

                } else {
                    myMask.hide();
                    Ext.Msg.show({
                        title: '操作失败',
                        msg: msg,
                        buttons: Ext.Msg.OK,
                        fn: function () {
                            document.getElementById("oldPw").value = "";
                            document.getElementById("newPw").value = "";
                            document.getElementById("newPw_c").value = "";
                        },
                        icon: Ext.Msg.INFO
                    });
                }
            },
            failure: function () {
                myMask.hide();
            }
        });

    });


});