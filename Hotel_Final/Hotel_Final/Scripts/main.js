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

    var count = 0;
    let check = [];
 
    //$(".FreeShops .img img,h6,.detail").click(function (e) {
    //    let checktext = $(this).parents(".img").find("h6").text()

    //    $(this).parents(".img").find(".detail input").toggleClass("d-none")
    //    //  if(istrue=true){
    //    //   count++

    //    if ($(this).parents(".img").find("input").hasClass("d-none")) {
    //        $(this).parents(".img").find("input").prop("checked", false)

    //        istrue = false

    //        count--
    //        var removeItem = $(this).parents(".img").find("h6").text() + " " + $(this).parents(".img").find("span").text()

    //        cart = jQuery.grep(cart, function (value) {


    //            return value != removeItem;


    //        });

    //        check = jQuery.grep(check, function (value) {


    //            return value != checktext;
    //        });


    //        $(".Login a span").html(count)
    //        if (count == 0) {
    //            $(".Login a span").html("")

    //        }


    //    }
    //    else {
    //        $(this).parents(".img").find("input").prop("checked", true)


    //    }
    //})
    $(".cat").click(function (ev) {
        ev.preventDefault();
       
        $.ajax({
            method: "get",
            url: $(this).attr("href"),
            dataType: "json",
            success: function (response) {
                $("#ProductTable").find("tbody").html("")
                console.log(response)
                $.each(response, function (index, item) {
                        addToTable(item)
                        console.log(item)
                    })
                
                 },

            })
        })

    function addToTable(product) {
        var tr = `<tr>
            <th scope="row">${product.OrderBy}</th>
            <td>${product.Name}</td>
            <td>${product.Price}$</td>
            <td><input style="width:50px" min="1" type="number" name="Countorder" value="1" /></td>

            <td>
              <a id="OpenModal" href="/Paid/AddOrder" data-id="${product.Id}">Əlavə et <i class="fas fa-arrow-left"></i></a>
            </td>
        </tr>`;
        $("#ProductTable").find("tbody").append(tr)
    }
    $("")
 
    $(document).on("click", "#OpenModal", function (s) {
        s.preventDefault();
        console.log($(this).parents("tr").find("input").val())
        $.ajax({
            method: "get",
            url: "/Paid/AddOrder",
            data: create = create = {
                id:$(this).data("id"),
                count : $(this).parents("tr").find("input").val()
            },
            dataType: "json",
            success: function (response) {
                console.log(response)
                if (response.status === 432) {
                   location.href="/Account/Login"
                }
                toastr.success("Sifarisiniz qebul olundu")

            },
            error: function (e) {
                console.log(e);
                toastr.error("error")
            }
    })

      
});
});

