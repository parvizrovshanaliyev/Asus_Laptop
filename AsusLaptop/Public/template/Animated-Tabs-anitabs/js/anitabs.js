(function($){
	// defaults
	var defaults = {drag:true, dragSpeed:500, animation:"fade", animationSpeed:500, autoHeight:true, slideDirection:"left"},
		options;
		
	// tabs function
	$.fn.aniTabs = function(params){
		var options = $.extend({}, defaults, params);
		// if drag is false
		if(!options.drag){
			$(this).closest(".js-tabs-nav").find(".js-tabs-drag").css("display","none");
		}			
		// click event
		$(this).click(function(e){
			e.preventDefault();
			if($(this).closest(".js-tabs-item.active").length<1){
				// if fade (set transition speed)
				if(options.animation=="fade"){
					$(this).closest(".js-tabs").find(".js-tabs-wrap:first .js-tabs-content").css({"-webkit-transition-duration":(options.animationSpeed/1000)+"s", "-ms-transition-duration":(options.animationSpeed/1000)+"s", "transition-duration":(options.animationSpeed/1000)+"s"});
				}
				// if slide (set animation speed)
				if(options.animation=="slide"){
					 $(this).closest(".js-tabs").find(".js-tabs-wrap:first .js-tabs-content").addClass("slide").css({"-webkit-animation-duration":(options.animationSpeed/1000)+"s", "-ms-animation-duration":(options.animationSpeed/1000)+"s", "animation-duration":(options.animationSpeed/1000)+"s"});
				}	
											
				// set auto height
				if(options.autoHeight){
					$(this).closest(".js-tabs").find(".js-tabs-wrap:first").css({"-webkit-transition-duration":(options.animationSpeed/1000)+"s", "-ms-transition-duration":(options.animationSpeed/1000)+"s", "transition-duration":(options.animationSpeed/1000)+"s"});
				}							
				// base functionality
				var currentHref = $(this).attr("href"); // get current href
				$(this).closest(".js-tabs-item").siblings(".js-tabs-item").removeClass("active"); // remove .active in closest nav
				$(this).closest(".js-tabs-item").addClass("active"); // add .active to closest item
				var oldHeight = $(currentHref).siblings(".js-tabs-content.active").height(); // get old height
				$(currentHref).closest(".js-tabs-wrap").css("height",oldHeight+"px"); // set old height		
				// if slide (animation out)
				if(options.animation=="slide"){
					// if direction is left
					if(options.slideDirection=="left"){
						$(this).closest(".js-tabs").find(".js-tabs-wrap:first .js-tabs-content").removeClass("slideOutLeft slideInRight moved");					
						$(currentHref).siblings(".js-tabs-content.active").addClass("slideOutLeft moved");
					}
					// if direction is right
					if(options.slideDirection=="right"){
						$(this).closest(".js-tabs").find(".js-tabs-wrap:first .js-tabs-content").removeClass("slideOutRight slideInLeft moved");					
						$(currentHref).siblings(".js-tabs-content.active").addClass("slideOutRight moved");
					}					
				}								
				$(currentHref).addClass("active").siblings(".js-tabs-content").removeClass("active"); // change tab
				var newHeight = $(currentHref).height(); // get new height	
				$(currentHref).closest(".js-tabs-wrap").css("height",newHeight+"px"); // set new height
				// if slide (animation in)
				if(options.animation=="slide"){
					// if direction is left
					if(options.slideDirection=="left"){					
						$(currentHref).addClass("slideInRight");
					}
					// if direction is right
					if(options.slideDirection=="right"){					
						$(currentHref).addClass("slideInLeft");
					}					
				}				
				// some fixes when animation's done
				setTimeout(function(){
					// set height:auto
					$(currentHref).closest(".js-tabs-wrap").css("height","auto");
					// if slide (remove classes)
					if(options.animation=="slide"){
						 $(currentHref).siblings(".js-tabs-content").removeClass("slideOutLeft slideOutRight moved");
					}						
				}, options.animationSpeed)					
				// move drag
				if(options.drag){
					var positionTop = $(this).closest(".js-tabs-item").position().top,
						positionLeft = $(this).closest(".js-tabs-item").position().left,
						itemWidth = $(this).closest(".js-tabs-item").width();
					$(this).closest(".js-tabs-nav").find(".js-tabs-drag").css({"width":itemWidth+"px", "top":positionTop+"px", "left":positionLeft+"px", "-webkit-transition-duration":(options.dragSpeed/1000)+"s", "-ms-transition-duration":(options.dragSpeed/1000)+"s", "transition-duration":(options.dragSpeed/1000)+"s"});
				}
			}
		})
		return this;
	};
	
	// drag size and position on load and resize
	var resizeFix = function(){
		$(".js-tabs-drag").each(function(){
			var positionTop = $(this).closest(".js-tabs-nav").find(".js-tabs-item.active").position().top,
				positionLeft = $(this).closest(".js-tabs-nav").find(".js-tabs-item.active").position().left,
				itemWidth = $(this).closest(".js-tabs-nav").find(".js-tabs-item.active").width();
			$(this).css({"width":itemWidth+"px", "top":positionTop+"px", "left":positionLeft+"px"});        
		}).addClass("active");
	}
	$(window).bind('load', resizeFix);
	$(window).bind('orientationchange', resizeFix);
	$(window).bind('resize', resizeFix);	
})(jQuery);