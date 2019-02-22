// 下拉菜单
$(function () {
    var objStr = ".topsr dl";
    $(objStr).each(function (i) {
        $(this).mouseover(function () {
            $($(objStr + " dd")[i]).show();
            $($(objStr + " dt")[i]).addClass("topsrdt");
        });
        $(this).hover(function () { }, function () {
            $($(objStr + " dd")[i]).hide();
            $($(objStr + " dt")[i]).removeClass("topsrdt");
        });
    });
});
// 顶部打开关闭
$(function () {
    $(".topClose a").click(function () {
        $(".top").slideUp(0, function () { $(".topOpen").slideDown(0); });
    });
    $(".topOpen a").click(function () {
        $(".topOpen").slideUp(0, function () { $(".top").slideDown(0); });
    });
});
// 商品搜索
$(function () {
    var objStr = $("#searchInput");
    var objStrVal = "苹果MP4";
    objStr.val(objStrVal);
    objStr.focus(function () {
        if (objStr.val() == objStrVal)
            objStr.val("");
    });
    objStr.blur(function () {
        if (objStr.val() == "")
            objStr.val(objStrVal);
    });
});
// 热门搜索关键字
$(function () {
    $(".tags a:first").addClass("c1");
    $(".notice a:first").addClass("c2");
});
// 顶部导航
$(function shownav() {
    var a1 = $("url");
    var a2 = $(".nav ul li");
    for (var i = 0; i < a2.length; i++) {
        if (a2[i] == a1) {
            $(a2[i]).addClass("select");
            return;
        }
    }
    $(a2[0]).addClass("select");
})