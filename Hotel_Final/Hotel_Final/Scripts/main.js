$(document).ready(function () {

 var cart=[];
    $("#homeslide .owl-carousel").owlCarousel({
      items:1,
      loop:true,
      autoplay:true,
      autoplayTimeout:3000,
      autoplayHoverPause:true
    });
    
    $('#CardRooms .owl-theme').owlCarousel({
      loop:true,
      margin:10,
      nav:true,
      responsive:{
          0:{
              items:1
          },
          600:{
              items:2
          },
          1000:{
              items:3
          }
      }
  })
  $("#Testimonials .owl-carousel").owlCarousel({
    items:1,
    loop:true,
    autoplay:true,
    autoplayTimeout:3000,
    autoplayHoverPause:true
  });

  $('.Information li').click(function(){
    $('.Information li').toggleClass("changed")
   console.log("test")
  //  .css({
    //   "content": "\f068",
    //   "font-family": "Font Awesome 5 Free",
    //   "font-weight": 900

    
  })

    $(window).scroll(function(e){
      var scrollTop = $(window).scrollTop();
   if(scrollTop>92){
      $("#header").addClass("fixed-top")
      $("#header").addClass("fadeIn")
 


    }else{
      $("#header").removeClass("fixed-top")
      $("#header").removeClass("fadeIn")


    }

    })

   var istrue=false;
    var count = 0;
    let check = [];
 
    $(".FreeShops .img img,h6,.detail").click(function (e) {
        let checktext = $(this).parents(".img").find("h6").text()

 $(this).parents(".img").find(".detail input").toggleClass("d-none")
//  if(istrue=true){
//   count++

 if($(this).parents(".img").find("input").hasClass("d-none")){
     $(this).parents(".img").find("input").prop("checked",false)

     istrue = false
   
  count--
  var removeItem=$(this).parents(".img").find("h6").text()+" "+$(this).parents(".img").find("span").text()
  
  cart = jQuery.grep(cart, function(value) {
  

      return value != removeItem;


  });
       
         check = jQuery.grep(check, function (value) {


             return value != checktext;
         });
   

  $(".Login a span").html(count)
  if(count==0){
  $(".Login a span").html("")
    
  }


 }
 else {
     $(this).parents(".img").find("input").prop("checked", true)

  istrue=true
     count++
     check.push(checktext)
     

     
  cart.push($(this).parents(".img").find("h6").text()+" "+$(this).parents(".img").find("span").text())
  $(".Login a span").html(count)

        }
       
 
     
        console.log(check)
        console.log($(".img").find("input").prop("checked"))
      
  })

 $(".basket").click(function(e){
     e.preventDefault()
     console.log(check)
     localStorage["check"] = JSON.stringify(check)

     $(".mycart").find(".apply").addClass("d-none")
    
  $(".mycart").toggleClass("d-none")
     $(".mycart #myform").html("")
  for(var i=0;i<check.length;i++){
    
      $(".mycart #myform").append("<input name=products  class='childol form-control' value= " + check[i] +"/>")
  }
     if ($(".mycart #myform input").hasClass("childol")) {
                            
         $(".mycart").append("<button type='Submit' class='apply  btn btn-primary'>Apply</button>")
      console.log("testttt")

  }
  else{
    $(".mycart").find(".apply").addClass("d-none")

  }
  
 })
 
    $(document).on("click", ".mycart .apply", function (e) {
        $("#myform").submit()
        //var t = $(".mycart ").html();
        
    //    var stored_product = JSON.parse(localStorage["check"]);
    //    console.log(stored_product)
    //    $.ajax({
    //        type: "Post",
    //        url: "/Cash/index",
    //        data: { "products": stored_product},
    //        success: function (res) {
    //            $.each(res, function (index, item) {

    //                console.log(item)

                 
    //            })


    //            },
    //            error: function (er) {
    //                console.log(er.statusText)
    //            }

       
    //})
    })
    $(".meta").click(function () {
        $("#myform").submit()
    })
       
});

