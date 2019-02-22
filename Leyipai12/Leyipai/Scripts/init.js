$(document).ready(function () {

    $(".signin").click(function () {

        var winWidth = 0;
        if (window.innerWidth)
            winWidth = window.innerWidth;
        else if ((document.body) && (document.body.clientWidth))
            winWidth = document.body.clientWidth;
        // 通过深入Document内部对body进行检测，获取窗口大小  
        if (document.documentElement && document.documentElement.clientHeight && document.documentElement.clientWidth) {
            winWidth = document.documentElement.clientWidth;
        }
        $("fieldset#signin_menu").toggle();
        $(".signin").toggleClass("menu-open");
        $("fieldset#signin_menu").css("margin-left",((winWidth - 951) / 2 +50) + 'px');
    });

    $("fieldset#signin_menu").mouseup(function () {
        return false
    });
    $(document).mouseup(function (e) {
        if ($(e.target).parent("a.signin").length == 0) {
            $(".signin").removeClass("menu-open");
            $("fieldset#signin_menu").hide();
        }
    });

});