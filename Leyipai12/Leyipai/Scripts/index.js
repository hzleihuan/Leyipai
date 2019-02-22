// 指定所有链接方式（只为测试，实际文档中可去除）
$(document).ready(function(){

	$("html").find("img").attr("alt","乐易商城");
});
// 下拉菜单
$(function(){
	var objStr = ".topsr dl";
	$(objStr).each(function(i){
		$(this).mouseover(function(){
			$($(objStr+" dd")[i]).show();
			$($(objStr+" dt")[i]).addClass("topsrdt");
		});
		$(this).hover(function(){},function(){
			$($(objStr+" dd")[i]).hide();
			$($(objStr+" dt")[i]).removeClass("topsrdt");
		});	
	});
});
// 顶部打开关闭
$(function(){
	$(".topClose a").click(function(){
		$(".top").slideUp(0,function(){$(".topOpen").slideDown(0);});
	});
	$(".topOpen a").click(function(){
		$(".topOpen").slideUp(0,function(){$(".top").slideDown(0);});
	});
});
// 商品搜索
$(function(){
	var objStr = $("#searchInput");
	var objStrVal = "苹果MP4";
	objStr.val(objStrVal);
	objStr.focus(function(){
		if(objStr.val()==objStrVal)
			objStr.val("");
	});
	objStr.blur(function(){
		if(objStr.val()=="")
			objStr.val(objStrVal);	
	});
});
// 热门搜索关键字
$(function(){
	$(".tags a:first").addClass("c1");
	$(".notice a:first").addClass("c2");
});
// 顶部导航
$(function shownav(){
	var a1 = $("url");
	var a2 = $(".nav ul li");
	for(var i=0;i<a2.length;i++){
		if(a2[i] == a1){
			$(a2[i]).addClass("select");
			return;
		}
	}
	$(a2[0]).addClass("select");
})
// 第一板块 - 自动轮换广告
$(function(){
	var objText = ".rotation ul.text li";
	var objContent = ".rotation ul.img li";
	$("objText:first").addClass("on");
	$("objContent:not(:first)").addClass("none");
	autoroll();
	hookThumb();
	
	var i=-1; 
	var offset = 4000; 
	var timer = null;
	function autoroll(){
		n = $(objText).length-1;
		i++;
		if(i > n){
		i = 0;
	}
	slide(i);
		timer = window.setTimeout(autoroll, offset);
	}
	function slide(i){
		$(objText).eq(i).addClass("on").siblings().removeClass("on");
		$(objContent).eq(i).fadeIn(1000).siblings(objContent).hide();
	}
	function hookThumb(){    
		$(objText).hover(
			function () {
				if (timer) {
					clearTimeout(timer);
					i = $(this).prevAll().length;
					slide(i); 
				}
			},
			function () {
				timer = window.setTimeout(autoroll, offset);  
				this.blur();            
				return false;
			}
		); 
	}
});
// 第一板块 - 自动轮换选项卡
$(function(){
	var objText = ".rotationcard .text li";
	var objContent = ".rotationcard .content ul";
	$("objText:first").addClass("on");
	$("objContent:not(:first)").addClass("none");
	autoroll();
	hookThumb();
	
	var i=-1; 
	var offset = 6000; 
	var timer = null;
	function autoroll(){
		n = $(objText).length-1;
		i++;
		if(i > n){
		i = 0;
	}
	slide(i);
		timer = window.setTimeout(autoroll, offset);
	}
	function slide(i){
		$(objText).eq(i).addClass("on").siblings().removeClass("on");
		$(objContent).eq(i).show().siblings(objContent).hide();
	}
	function hookThumb(){    
		$(objText).hover(
			function () {
				if (timer) {
					clearTimeout(timer);
					i = $(this).prevAll().length;
					slide(i); 
				}
			},
			function () {
				timer = window.setTimeout(autoroll, offset);  
				this.blur();            
				return false;
			}
		); 
	}
});
// 单行滚动
function SingleScroll(){
	$(".tips2 ul").animate({marginTop:"-25px"},500,function(){
		$(this).css({marginTop:"0px"}).find("li:first").appendTo(this);
	});
}
$(setInterval("SingleScroll()",4000));

// 幕帘伸缩广告
$(document).ready(function(){
	setTimeout("showBanner();",5000);
});
function showBanner(){
	$(".banner p:eq(0)").slideUp(1000,function(){$(".banner p:eq(1)").slideDown(1000);});
}