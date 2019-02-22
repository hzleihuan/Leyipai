$(document).ready(function () {
    // 找到所有菜单, 并添加显示和隐藏菜单事件
    var v_email = $("#email").val();

});

function isEmail(email) {
    if (email.length > 50) {
        return false;
    }
    var re = /^(([0-9a-zA-Z]+)|([0-9a-zA-Z]+[_.0-9a-zA-Z-]*[0-9a-zA-Z]+))@([a-zA-Z0-9-]+[.])+([a-zA-Z]{2}|net|NET|com|COM|gov|GOV|mil|MIL|org|ORG|edu|EDU|int|INT)$/;
    if (email.search(re) != -1) {
        return true;
    }
    return false;
}

function checkEmail(obj) {
    var pass = false;
    var msg = document.getElementById(obj.name + "Msg");
    if (obj.value == "") {
        msg.innerHTML = "此项为必填项，请输入有效的Email地址";
    } else {
        if (!isEmail(obj.value)) {
            msg.innerHTML = "请您输入有效的Email地址";
        } else {
            pass = true;
            msg.innerHTML = "有效的Email地址";
        }
    }
    if (!msgFunc(pass, obj, msg)) {
        return false;
    }
    return true;
}


function checkUserName(obj) {
    var pass = false;
    var msg = document.getElementById(obj.name + "Msg");
}

function checkUserName(obj) {
    var pass = false;
    var msg = document.getElementById(obj.name + "Msg");
    if (obj.value == "") {
        msg.innerHTML = "此项为必填项，请输入有效的用户名";
    } else {
        if (!/^(?!\d)[a-z0-9(\_)]{4,20}$/.test(obj.value)) {
            msg.innerHTML = "用户名是由小写英文字母、数字或下划线组成，不能以数字开头，在4-20字符之间";
        } else if (!isNaN(obj.value)) {
            msg.innerHTML = "注册用户名不能为纯数字";
        } else {
            pass = true;
            msg.innerHTML = "有效的用户名";
        }
    }
    if (!msgFunc(pass, obj, msg)) {
        return false;
    }
    return true;
}


function checkPwd(obj) {
    var pass = false;
    var msg = document.getElementById(obj.name + "Msg");
    if (obj.value == "" || obj.value.length < 6 || obj.value.length > 16) {
        msg.innerHTML = "密码长度必须为6-16个字符";
    } else {
        pass = true;
        msg.innerHTML = "&nbsp;";
    }
    if (!msgFunc(pass, obj, msg)) {
        return false;
    }
    return true;
}
function checkPwd2(obj) {
    var pass = false;
    var msg = document.getElementById(obj.name + "Msg");
    var pwd = document.getElementById("password");
    if (obj.value == "") {
        msg.innerHTML = "请再输入一遍您上面输入的密码";
    } else if (pwd.value != obj.value) {
        msg.innerHTML = "两次输入的密码不一致，请重新输入";
        obj.value = "";
    } else if (obj.value == "" || obj.value.length < 6 || obj.value.length > 16) {
        msg.innerHTML = "密码长度必须为6-16个字符";
    } else {
        pass = true;
        msg.innerHTML = "&nbsp;";
    }
    if (!msgFunc(pass, obj, msg)) {
        return false;
    }
    return true;
}

function checkCode(obj) {
    var pass = false;
    var msg = document.getElementById(obj.name + "Msg");
    if (obj.value == "") {
        msg.innerHTML = "请填写验证码";
    } else {
        pass = true;
        msg.innerHTML = "&nbsp;"
    }
    if (!msgFunc(pass, obj, msg)) {
        return false;
    }
    return true;
}

function msgFunc(pass, obj, msg) {
    if (pass == false) {//不通过
        obj.className = "reginfo_input2";
        msg.setAttribute("class", "reginfo_tr4");
        return false;
    } else {
        obj.className = "reginfo_input2";
        msg.className = "reginfo_trcheck";
        return true;
    }
}

function clearMsg(obj) {
    var msg = document.getElementById(obj.name + "Msg");
    msg.className = "";
    msg.setAttribute("class", "");
    msg.innerHTML = "";
}


function checkForm(form) {
    if (!checkEmail(form.email)) {
        form.email.focus();
        return false;
    }
    //changeGroup(form.Email);
    if (!checkUserName(form.username)) {
        form.username.focus();
        return false;
    }
    if (!checkPwd(form.password)) {
        form.password.focus();
        return false;
    }
    if (!checkPwd2(form.password2)) {
        form.password2.focus();
        return false;
    }
    if (!checkCode(form.validateCode)) {
        form.validateCode.focus();
        return false;
    }
    return true;
}