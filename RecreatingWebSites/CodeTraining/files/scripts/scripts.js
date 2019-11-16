$(function(){


    var btn = $('#btn-menu');
    var nav = $('#nav');
    var links = $('#links');

    btn.on('click',()=>{
        nav.toggleClass('active');
        if(nav.hasClass('active')){            
            links.css('display','flex');
        }else{
            links.css('display','none');
        }
    });

    $(window).on('resize',()=>{

        if($(this).width() >= 550){
            links.css('display','flex');
        }else{
            links.css('display','none');
            if(nav.hasClass('active')){
                nav.removeClass('active');
            }
        }


    });


});