$(function(){
    $("#header").headroom();

    //Menu Responsive
    //Calculamos el ancho de la pagina

    var ancho = $(window).width();
    var enlaces = $('#enlaces');
    var enlacesA = $('#enlaces a');
    var btnmenu = $('#btn-menu');
    var icono = $('.btn-menu .icono');

    if(ancho <= 700){
        enlaces.hide();
        icono.addClass('fa-bars')
    }

    btnmenu.on('click',() => {
        //Text Icon Fix Movement
        if(icono.hasClass("fa-times")){
            btnmenu.css('margin-right','27vw');
        }else{
            btnmenu.css('margin-right','27.5vw');
        }
        enlaces.slideToggle();
        //Text Opacity Changed
        if(enlacesA.css('opacity') == '0'){
            enlacesA.css({"opacity" : "1"});
        }else{
            enlacesA.css({"opacity" : "0"});
        }
       
        //Change the Icon
        icono.toggleClass('fa-bars');
        icono.toggleClass('fa-times');
        });


    $(window).on('resize',() =>{
        if($(this).width() >= 700){
            enlaces.show();
            icono.addClass('fa-times');
            icono.removeClass('fa-bars');
        }else{
            enlaces.hide();
            icono.addClass('fa-bars');
            icono.removeClass('fa-times');
        }
    });
});