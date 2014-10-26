$(window).load(function() {
    var show_sidebar = $.cookie('klassik_sidebar');
    if(show_sidebar == undefined) {
        show_sidebar = ''
    }
    var theme_color = $.cookie('klassik_color');
    if(theme_color != undefined && theme_color != '') {
       changeColor(theme_color);
    }
	$('body').append('<div id="sidebar" class="'+(show_sidebar!=''?'in_switcher hidden':'out_switcher')+'" '+show_sidebar+'>'
        +'<div id="sidebar-content">'
            +'<form action="">'
               +'<div class="form-item"><label for="color">Chose your favourite color!:</label></div><div id="picker"></div>'
               +'<div class="form-input"><input type="text" id="klassik_colorbg_input" name="color" value="#f9f9f9" />'
               +'<span id="sidebar_default"><a href="#">X</a></span></div>'
            +'</form>'
        +'</div>'
        +'<div id="sidebar-button"></div>'
    +'</div>');
    
    $sidebar = $('#sidebar');
    $sidebar.css("top", (($(window).height() - $sidebar.outerHeight()) / 2) + $(window).scrollTop() + "px");
    $('#sidebar-button', $sidebar).click(function() {
        if($sidebar.is('.hidden')) {
            $sidebar.stop(true,true).animate({left: '+=' + ($sidebar.width() - 35)}, 500);
            $sidebar.removeClass('hidden in_switcher' );
            $sidebar.addClass('out_switcher');
            $.cookie('klassik_sidebar', '');
        }
        else {
            $sidebar.addClass('hidden');
            $sidebar.stop(true,true).animate({left: '-=' + ($sidebar.width() - 35)}, 500);
            $sidebar.removeClass('out_switcher' );
            $sidebar.addClass('in_switcher');
            $.cookie('klassik_sidebar', 'style="left: -'+($sidebar.width() - 35)+'px"');
        }
    });
    
    $('#sidebar_default').click(function() {
       $.cookie('klassik_color', '');
       window.location.reload();
    })
	
    
    
   
    
    
	
   
   var fb = $('#picker').farbtastic(function(data) {
      changeColor(data);
   });
   //fb.setColor('#f9f9f9');
});

function changeColor(data) {
   $('#vv_top_dark_main, #vv_top_dark').css('background-color', data);
   $('a, #vv_menu_active, h1, h2, h3, h4, h5, h6, ul.vv_menu ul li a:hover, ul.vv_menu a:hover, ul.vv_menu .vv_menuhover, .vv_left_box_info h3,span#vv_construction_info, .vv_drop1').each(function() {
      if(!$(this).parent().parent().hasClass('vv_menu') && !$(this).parent().parent().parent().parent().hasClass('vv_menu') &&
         !$(this).parent().parent().parent().hasClass('vv_side_information') && !$(this).parent().parent().hasClass('vv_page_name') &&
         !$(this).parent().parent().hasClass('vv_mini_arrow') && $(this).parent().attr('id') != 'vv_error')
         $(this).css('color', data);
   });
   $('#vv_menu_active').css('color', data);
   $('.vv_highlight1, .vv_drop3, .gal_pagination .current').each(function() {
      $(this).css('background-color', data);
   });
   $('.gal_pagination a').hover(function() {
      $(this).css({'background-color': data, 'color': '#FFF', 'border-color': data});
   }, function() {
      $(this).css({'background-color': '#FFF', 'color': data, 'border-color': '#CCC'});
   });

   $('.navigation a:not(.selected)').hover(function() {
      $(this).css({'background-color': data, 'border-color': data});
      $(this).find('h5').css('color', '#FFF');
   }, function() {
      $(this).css({'background-color': '#FFF', 'color': data, 'border-color': '#EDEDED'});
      $(this).find('h5').css('color', data);
   });
   
   $('#navigation_styles').remove();
   $('.navigation').after('<style id="navigation_styles">.selected, .not_selected:hover, a.toggle:hover, a.togg_active {background-color: '+data+' !important;}'
    +'.selected h5, .not_selected:hover h5, a.toggle:hover, a.togg_active {color: #FFFFFF !important;}'
    +'a.selected, .not_selected:hover {border-color: '+data+' !important}'
    +'</style>')
   $('.gal_pagination .current').css('border-color', data);
   $('.vv_circle').bColor("#bfbfbf", data);
   $('.vv_circle_min').bColor("#e2e2e2", data);
   $('.vv_send_circle').bColor("#bfbfbf", data);
   $('.vv_more_circle').bColor("#e4e4e4", data);
   $('.vv_menu a:not(#vv_menu_active)').bColor("#8A8A8A", data, 250, 'color');
   $('#klassik_colorbg_input').val(data);
   $.cookie('klassik_color', data);
}