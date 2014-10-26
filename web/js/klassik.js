var color = '#66cedb';
$(document).ready(function(){
    $('.vv_slide_text').hover(function(){
        $('.vv_img_info', this).stop(true, false).animate({
            left: '0px'
        }, 1000);
    },function(){
        $('.vv_img_info', this).animate({
            left: '212px'
        }, 1000);
    });

    $('.vv_side_information a').hover(function(){
        $(this).stop().animate({
            width: '180px'
        }, 1000);
    },function(){
        $(this).stop().animate({
            width: '55px'
        }, 1000);
    });
					
    $("a[href='#vv_wrapper_top']").click(function() {
        $("html, body").animate({
            scrollTop: 0
        }, "slow");
        return false;
    });

    //main menu
    $('ul.vv_menu ul').hide();
    $('ul.vv_menu li').hover(function() {		
        $('ul',this).stop(true, true).slideDown(500, "jswing");
    },
    function() {
        $('ul',this).slideUp(500, "jswing");
    });

    $('.vv_contact, .vv_side_contact').click(function() {
        $('#vv_hidden_contact').modal({
            onOpen: function (dialog) {
                dialog.overlay.fadeIn(500, function () {
                    dialog.data.hide();
                    dialog.container.fadeIn(0, function () {
                        dialog.data.fadeIn(800);
                    });
                });
            },
            onClose: function (dialog) {
                dialog.data.fadeOut(500, function () {
                    dialog.container.hide(0, function () {
                        dialog.overlay.fadeOut(500, function () {
                            $.modal.close();
                        });
                    });
                });
            },
            overlayClose:true
        });
    });

    $('.vv_search, .vv_side_search').click(function() {
        $('#vv_hidden_search').modal({
            onOpen: function (dialog) {
                dialog.overlay.fadeIn(500, function () {
                    dialog.data.hide();
                    dialog.container.fadeIn(0, function () {
                        dialog.data.fadeIn(800);
                    });
                });
            },
            onClose: function (dialog) {
                dialog.data.fadeOut(500, function () {
                    dialog.container.hide(0, function () {
                        dialog.overlay.fadeOut(500, function () {
                            $.modal.close();
                        });
                    });
                });
            },
            overlayClose:true
        });
    });

    //script used by plugin Slides
    $(function(){
        // Set starting slide to 1
        var startSlide = 1;
        // Get slide number if it exists
        if (window.location.hash) {
            startSlide = window.location.hash.replace('#','');
        }
        // Initialize Slides
        $('#slides').slides({
            preload: true,
            preloadImage: 'img/loading.gif',
            generatePagination: true,
            play: 5000,
            pause: 2500,
            hoverPause: true,
            // Get the starting slide
            start: startSlide,
            animationComplete: function(current){
            // Set the slide number as a hash
            //window.location.hash = '#' + current;
            }
        });
					
        $('#slides2').slides({
            preload: true,
            preloadImage: 'img/loading.gif',
            generatePagination: true,
            pause: 2500,
            hoverPause: true,
            autoHeight: true,
            // Get the starting slide
            start: startSlide,
            animationComplete: function(current){
            // Set the slide number as a hash
            //window.location.hash = '#' + current;
            }
        });
    });

});

$(window).load(function(){
    //img hover1

    $('.vv_img_hover1').hover(function(){
        $('img', this).stop(true, false).animate({
            opacity: 0.5
        }, 500);
    },
    function(){
        $('img', this).animate({
            opacity: 1
        }, 500);
    });
	
    //img hover2
    $('.vv_img_hover2').hover(function(){
        $('img', this).stop(true, false).animate({
            opacity: 0.5
        }, 500);
    },
    function(){
        $('img', this).animate({
            opacity: 1
        }, 500);
    });
	
    //img hover3
    $('.vv_img_hover3').hover(function(){
        $('img', this).stop(true, false).animate({
            opacity: 0.5
        }, 500);
    },
    function(){
        $('img', this).animate({
            opacity: 1
        }, 500);
    });
	

    jQuery.fn.bColor = function(s_color, e_color, speed, prop) {
        //default values
        if(speed == undefined)
            speed = 600;
        var s_prop = new Object;
        var e_prop = new Object;
        if(prop == undefined) {
            s_prop['background-color'] = s_color;
            e_prop['background-color'] = e_color;
        }
        if(prop == 'color') {
            s_prop[prop] = s_color;
            e_prop[prop] = e_color;
        }
        return this.each(function() {
            $(this).hover(function(){
                $(this).stop(true, false).animate(e_prop, speed, 'swing');
            },
            function(){
                $(this).animate(s_prop, speed, 'swing');
            }	
            );
        });
    }
    $('.vv_circle').bColor("#bfbfbf", color);
    $('.vv_circle_min').bColor("#e2e2e2", color);
    $('.vv_more_circle').bColor("#e4e4e4", color);
    $('.vv_send_circle').bColor("#bfbfbf", '#80c4cc');
    $('.vv_send_circle_2').bColor("#bfbfbf", '#80c4cc');
    $('.vv_menu a:not(#vv_menu_active)').bColor("#8A8A8A", color, 250, 'color');

});

if ( typeof Object.create !== 'function' ) {
    Object.create = function( obj ) {
        function F() {};
        F.prototype = obj;
        return new F();
    }
}
(function( $ ) {
    var Plugins = {
        init: function( options, elem ) {
            var self = this;
            
            self.elem = elem;
            self.$elem = $(elem);
            
            if( typeof options === 'string' ) {
                self.plugin = options;
            } else {
                self.plugin = options.plugin;
                self.options = $.extend( {}, $.fn.pluginCollector.options, options);
                console.log(self.options);
            }
        }
    }
    $.fn.pluginCollector = function( options ) {
        return this.each(function() {
            var plugin = Object.create( Plugins );
            plugins.init( options, this );
        })
    }
    
    $.fn.pluginCollector.options = {
        plugin: 'test'
    }
})( jQuery );

//this script is used in footer for social icons and their hidden names
$(window).load(function() {
    $(function () {
        $('.bubbleInfo').each(function () {
            // options
            var distance = 5;
            var time = 250;
            var hideDelay = 250;

            var hideDelayTimer = null;

            // tracker
            var beingShown = false;
            var shown = false;
    
            var trigger = $('.trigger', this);
            var popup = $('.popup', this).css('opacity', 0);

            // set the mouseover and mouseout on both element
            $([trigger.get(0), popup.get(0)]).mouseover(function () {
                // stops the hide event if we move from the trigger to the popup element
                if (hideDelayTimer) clearTimeout(hideDelayTimer);

                // don't trigger the animation again if we're being shown, or already visible
                if (beingShown || shown) {
                    return;
                } else {
                    beingShown = true;

                    // reset position of popup box
                    popup.css({
                        top: -30,
                        left: -5,		  
                        display: 'block' // brings the popup back in to view
                    })

                    // (we're using chaining on the popup) now animate it's opacity and position
                    .animate({
                        top: '-=' + distance + 'px',
                        opacity: 1
                    }, time, 'swing', function() {
                        // once the animation is complete, set the tracker variables
                        beingShown = false;
                        shown = true;
                    });
                }
            }).mouseout(function () {
                // reset the timer if we get fired again - avoids double animations
                if (hideDelayTimer) clearTimeout(hideDelayTimer);
      
                // store the timer so that it can be cleared in the mouseover if required
                hideDelayTimer = setTimeout(function () {
                    hideDelayTimer = null;
                    popup.animate({
                        top: '-=' + distance + 'px',
                        opacity: 0
                    }, time, 'swing', function () {
                        // once the animate is complete, set the tracker variables
                        shown = false;
                        // hide the popup entirely after the effect (opacity alone doesn't do the job)
                        popup.css('display', 'none');
                    });
                }, hideDelay);
            });
        });
    });
})