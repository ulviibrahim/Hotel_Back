
window.onload = function () {

    $(document).ready(function () {
       
        var cart = [];
        $("#homeslide .owl-carousel").owlCarousel({
            items: 1,
            loop: true,
            autoplay: true,
            autoplayTimeout: 3000,
            autoplayHoverPause: true
        });

        $('#CardRooms .owl-theme').owlCarousel({
            loop: true,
            margin: 10,
            nav: true,
            responsive: {
                0: {
                    items: 1
                },
                600: {
                    items: 2
                },
                1000: {
                    items: 3
                }
            }
        })
        $("#Testimonials .owl-carousel").owlCarousel({
            items: 1,
            loop: true,
            autoplay: true,
            autoplayTimeout: 3000,
            autoplayHoverPause: true
        });

        $('.Information li').click(function () {
            $('.Information li').toggleClass("changed")
            console.log("test")
            //  .css({
            //   "content": "\f068",
            //   "font-family": "Font Awesome 5 Free",
            //   "font-weight": 900


        })

        $(window).scroll(function (e) {
            var scrollTop = $(window).scrollTop();
            if (scrollTop > 92) {
                $("#header").addClass("fixed-top")
                $("#header").addClass("fadeIn")



            } else {
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
            $(".catlist i").removeClass("fs")

            $(this).parents(".catlist").find("i").addClass("fs")
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
                        test()
                            ;

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
        function test() {
            `<form class="yoxla" action="/test/orders" method="post">

            <input type="text" name="testinput" value="test" />
            <button id="test" type="submit"></button>
        </form>`
        }

        $(document).on("click", "#OpenModal", function (s) {
            s.preventDefault();
            $(".load").removeClass("d-none")
            console.log($(this).parents("tr").find("input").val())
            
            $.ajax({
                method: "get",
                url: "/Paid/AddOrder",
                data: create = {
                    id: $(this).data("id"),
                    count: $(this).parents("tr").find("input").val()
                },
                dataType: "json",
                success: function (response) {
                    $(".load").addClass("d-none")
                    if (response.status === 303) {
                        toastr.info(response.message)
                    }

                    if (response.status === 432) {
                        location.href = "/Account/Login"
                    }
                    if (response.status === 200) {


                        toastr.success("Sifarisiniz qebul olundu")

                        $("input[name=Subject]").val(`${response.id}`)
                        console.log($("input[name=Email]").val())
                        console.log($("input[name=Subject]").val())
                        $("#yoxla").submit();
                    }
                },
                error: function (e) {
                    console.log(e);
                    toastr.error("error")
                }
            })

            $(this).parents("tr").find("input").val("1")

        });

        $(document.body).click(function (e) {
                console.log($(e.target))

            if ($(e.target)=="body") {
                alert("table");
              

            } else {
                $("#myInput").focus();
            }
           
        });
        $(document).on("keyup", "#myInput", function () {

            var value = $(this).val().toLowerCase();
            $("#ProductTable tr").filter(function () {
                $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
            });
        });
        $("#testbuton").click(function () {

        })


        $("#Rateform .ratedeg").click(function (e) {
            e.preventDefault()

            $(`#Rateform ul li a i  `).css("color", "rgba(206, 199, 199, 0.87)")



            $("#Rateform input").val($(this).find("span").text())
            //$(`ul li: nth - child(n +${$(this).find("span").text()} ) span`).css("background-color","green")
            //$(`#Rate ul li:nth-child(-n+${$(this).find("span").text()}) i  `).css("color", "#e86508")
            if ($(`#Rateform ul li:nth-child(-n+${$(this).find("span").text()}) i  `).css("color") == "rgba(206, 199, 199, 0.87)") {
                $(`#Rateform ul li:nth-child(-n+${$(this).find("span").text()}) i  `).css("color", "rgb(232, 101, 8)")

            } else {
                $(`#Rateform ul li:nth-child(-n+${$(this).find("span").text()}) i  `).css("color", "rgba(206, 199, 199, 0.87)")

            }

        })


        $("#opencardform").click(function () {
            $(".form-back").toggleClass("d-none animated fadeIn")

        })
     
        if ($("#mustpay").text() == "0$") {

            $("#opencardform").addClass("d-none")
        }
        $("#payforcard").submit(function (e) {
            e.preventDefault();
            var form = $(this)
            console.log($("#TotalPrice").val())
            $.ajax({
                method: "post",
                url: "/Cash/CashOnline",
                dataType: "json",
                data: { TotalPrice : $("#TotalPrice").val()} ,
                success: function (response) {
                    if (response.status === 200) {
                        $("#mustpay").html("0%")
                        toastr.success(response.message)
                        console.log("text")
                    }
                },
                error: function (er) {
                    toastr.error("sehv var")
                    console.log(er)
                }
            })
        })
    });

}