/*------------------------------------------------------------------
Table of content
-------------------
1.  Navbar window scroll Sticky menu start
2.  navbar active item
3.  section tabs new sale trending
4.  quick view modal inner slider
5.  modals: compare , quick view , mini card
6.  quantity -1+
7.  scroll top page
8.  minicart added product delete from cart
9.  compare product desktop
10. compare product desktop
-------------------------------------------------------------------*/
// $('.container').loader('show','<img src="loader.gif">');
$(document).ready(function() {
   // console.log("ssss");



  //  #region 1. Navbar window scroll Sticky menu start
  var $window = $(window);
  $window.on("scroll", function() {
    var scroll = $window.scrollTop();
    var nav = $("#nav");
    if (scroll < 300) {
      $(".sticky").removeClass("is-sticky");
    } else {
      $(".sticky").addClass("is-sticky");
    }
    if (scroll < 300 || nav.hasClass("active")) {
      nav.removeClass("active");
    }
  });
  /*------ Sticky menu end ------*/

  // /*----- sticky sidebar start -----*/
  // $('.sticky-sidebar').stickySidebar({
  // 	topSpacing: 120,
  // 	bottomSpacing: 20,
  // 	minWidth: 992,
  // });
  // /*----- sticky sidebar end -----*/

  //mobile mune click

  $(".bars").on("click", function(e) {
    e.preventDefault();
    // alert("salam seni sinsi");
    var nav = $("#nav");
    if (nav.hasClass("active")) {
      nav.removeClass("active");
    } else {
      nav.addClass("active");
    }
  });
  //  #endregion Sticky menu start



  // #region 2.navbar active item

  // $(".desktop-menu ul li a").click(function(){

  //   $('a').parent().removeClass('active');

  //   $(this).parent().addClass('active');

  // });
  // #endregion navbar active item

  // #region 3.section tabs new sale trending
  $(".js-tabs-link").aniTabs({
    animation: "slide",

    slideDirection: "left",
    animationSpeed: 1000,
    autoHeight: false
  });
  // #region  trending product
  $("#lightSlider").lightSlider({
    item: 3,
    autoWidth: false,
    slideMove: 1, // slidemove will be 1 if loop is true
    slideMargin: 10,

    addClass: "",
    mode: "slide",
    useCSS: true,
    cssEasing: "ease", //'cubic-bezier(0.25, 0, 0.25, 1)',//
    easing: "linear", //'for jquery animation',////

    speed: 400, //ms'
    auto: false,
    loop: false,
    slideEndAnimation: true,
    pause: 2000,

    keyPress: false,
    controls: true,
    prevHtml: "<",
    nextHtml: ">",

    rtl: false,
    adaptiveHeight: false,

    vertical: false,
    verticalHeight: 500,
    vThumbWidth: 100,

    thumbItem: 10,
    pager: true,
    gallery: false,
    galleryMargin: 5,
    thumbMargin: 5,
    currentPagerPosition: "middle",

    enableTouch: true,
    enableDrag: true,
    freeMove: true,
    swipeThreshold: 40,

    responsive: [],

    onBeforeStart: function(el) {},
    onSliderLoad: function(el) {},
    onBeforeSlide: function(el) {},
    onAfterSlide: function(el) {},
    onBeforeNextSlide: function(el) {},
    onBeforePrevSlide: function(el) {}
  });
  // #endregion trending product

  // #region  sale product
  $("#lightSlider2").lightSlider({
    item: 3,
    autoWidth: false,
    slideMove: 1, // slidemove will be 1 if loop is true
    slideMargin: 10,

    addClass: "",
    mode: "slide",
    useCSS: true,
    cssEasing: "ease", //'cubic-bezier(0.25, 0, 0.25, 1)',//
    easing: "linear", //'for jquery animation',////

    speed: 400, //ms'
    auto: false,
    loop: false,
    slideEndAnimation: true,
    pause: 2000,

    keyPress: false,
    controls: true,
    prevHtml: "<",
    nextHtml: ">",

    rtl: false,
    adaptiveHeight: false,

    vertical: false,
    verticalHeight: 500,
    vThumbWidth: 100,

    thumbItem: 10,
    pager: true,
    gallery: false,
    galleryMargin: 5,
    thumbMargin: 5,
    currentPagerPosition: "middle",

    enableTouch: true,
    enableDrag: true,
    freeMove: true,
    swipeThreshold: 40,

    responsive: [],

    onBeforeStart: function(el) {},
    onSliderLoad: function(el) {},
    onBeforeSlide: function(el) {},
    onAfterSlide: function(el) {},
    onBeforeNextSlide: function(el) {},
    onBeforePrevSlide: function(el) {}
  });
  // #endregion sale product

  // #region  new product
  $("#lightSlider3").lightSlider({
    item: 3,
    autoWidth: false,
    slideMove: 1, // slidemove will be 1 if loop is true
    slideMargin: 10,

    addClass: "",
    mode: "slide",
    useCSS: true,
    cssEasing: "ease", //'cubic-bezier(0.25, 0, 0.25, 1)',//
    easing: "linear", //'for jquery animation',////

    speed: 400, //ms'
    auto: false,
    loop: false,
    slideEndAnimation: true,
    pause: 2000,

    keyPress: false,
    controls: true,
    prevHtml: "<",
    nextHtml: ">",

    rtl: false,
    adaptiveHeight: false,

    vertical: false,
    verticalHeight: 500,
    vThumbWidth: 100,

    thumbItem: 10,
    pager: true,
    gallery: false,
    galleryMargin: 5,
    thumbMargin: 5,
    currentPagerPosition: "middle",

    enableTouch: true,
    enableDrag: true,
    freeMove: true,
    swipeThreshold: 40,

    responsive: [],

    onBeforeStart: function(el) {},
    onSliderLoad: function(el) {},
    onBeforeSlide: function(el) {},
    onAfterSlide: function(el) {},
    onBeforeNextSlide: function(el) {},
    onBeforePrevSlide: function(el) {}
  });
  // #endregion new product

  // #endregion section tabs new sale trending ------

  // #region 4.quick view modal slider

  $("#imageGallery").lightSlider({
    gallery: true,
    item: 1,
    loop: true,
    thumbItem: 9,
    slideMargin: 0,
    enableDrag: false,
    currentPagerPosition: "left"
  });

  // #endregion quick view modal inner slider

  // region 5.modals: compare , quick view , mini card
  // Compare desktop modal
  let modalCompare = $(".compare");
  let openCompare = $(".openBtn");
  let closeCompare = $(".close");
  // Compare desktop modal
  


  let modalCompareM = $(".compareMobile");
  let openCompareM = $(".openBtnM");

  
  // card modal
  // let closeBtn1 = $(".close-card");
  let madalCard = $("#MiniCard");
  let openCard = $(".open-card");

  //  quick view modal
  let madalQuickView = $(".quickViewModal");
  let openQuickV = $(".open-qv");

  //open close conditions for modals

  // #region compare desktop modal 
  var compareingcount = 0;
    $(document).on("change", "input:checkbox[name=cp]", function() {
    
    var line = $("#line");
    if ($(this).is(":checked")) {
      var product = $(this)
        .parent()
        .parent()
        .parent()
        .parent()
        .parent();
      var name = product.data("name");
      var img = product.data("photo");
      var input=$(this);
      modalCompare.addClass("show");
      var col_3 = `<div id="${$(this).data("id")}" data-id="${$(this).data(
        "id"
      )}" class="col-3 compare-product ">
                         <div id="${$(this).data("id")}" class="minicart-thumb">
                            <ul>            
                               <li>             
                                  <a href="#">
                                    <img id="p-img" src="${img}">                
                                  </a>                            
                                </li>            
                                <li>            
                                  <a id="p-name" href="#">${name}</a>              
                                </li>            
                            </ul>            
                          </div>          
                          <button class="minicart-remove">x</button>              
                     </div>`;
      
                     
      if ($("input:checkbox[name=cp]:checked").length>4) {
        $("input:checkbox[name=cp]").filter(`#${$(this).data("id")}`).prop("checked",false)
        swal("product compare list full .Please delete product !", {
          button: false
        });
        
        
      } else {
        line.append(col_3);
        compareingcount++;
        // console.log(compareingcount)  
      }
      
    } else {
      compareingcount--;
      $(".compare-product[id=" + $(this).data("id") + "]").remove();
    }
    if (compareingcount == 0) {
      $(".close").trigger("click");
      
    }


   
  });
  
  $(document).on("click", ".minicart-remove", function() {

    var parent = $(this).parent();
    compareingcount--;
    $(".compare-product[id=" + parent.data("id") + "]").remove();
    $("input:checkbox[name=cp]").filter(`#${parent.data("id")}`).prop("checked",false)
      

    // console.log(compareingcount)       
          if (compareingcount == 0) {
            $(".close").trigger("click");
          }
   
  });
  // #endregion compare desktop ///////////////


  // #region mobile compare
  openCompareM.on("click",function(e){
    modalCompareM.addClass("show");
  });

  var count = 0;
  $("input:checkbox[name=cp]").on("change", function() {
    
    var lineM = $("#lineM");
    if ($(this).is(":checked")) {
      var product = $(this)
        .parent()
        .parent()
        .parent()
        .parent()
        .parent();
      var name = product.data("name");
      var img = product.data("photo");
      var input=$(this);
      modalCompareM.addClass("show");

    var col_6= `<div id="${$(this).data("id")}" data-id="${$(this).data( "id")}" class="col-6 compare-product text-center p-0 ">
                  <div id="${$(this).data("id")}" class="minicart-thumb">
                      <ul>
                          <li>
                              <a href="#">
                                  <img id="p-img" src="${img}">
                              </a>
                          </li>
                          <li>
                              <a id="p-name" style="font-size: 12px;"  href="#">${name}</a>
                          </li>
                      </ul>
                  </div>
                  <button class="minicart-removeM"><span aria-hidden="true">×</span></button>
                </div> `;
      
                     
      if ($("input:checkbox[name=cp]:checked").length>4) {
        $("input:checkbox[name=cp]").filter(`#${$(this).data("id")}`).prop("checked",false)
        swal("product compare list full .Please delete product !", {
          button: false
        });
        
        
      } else {
        lineM.append(col_6);
        count++;
        // console.log(compareingcount)   

       
      }
      
    } else {
      count--;
      $(".compare-product[id=" + $(this).data("id") + "]").remove();
    }
    if (count == 0) {
      $(".close").trigger("click");
      
    }


   
  });
  
  $(document).on("click", ".minicart-removeM", function() {

    var parent = $(this).parent();
    count--;
    $(".compare-product[id=" + parent.data("id") + "]").remove();
    $("input:checkbox[name=cp]").filter(`#${parent.data("id")}`).prop("checked",false)
      

    // console.log(compareingcount)       
          if (count == 0) {
            $(".close").trigger("click");
          }
   
  });
  // #endregion mobile compare
  

 

  //desktop compare open
  openCompare.on("click", function(e) {
    e.preventDefault();
    modalCompare.addClass("show");
    // setTimeout(function() {
    //   modalCompare.addClass("show");
    //   e.preventDefault();
    // }, 100);
    // if (madalQuickView.hasClass("show") || madalCard.hasClass("show")) {
    //   madalQuickView.removeClass("show");
    //   madalCard.removeClass("show");
    // }
  });
 
  //when compare modal close button
  closeCompare.on("click", function() {
    modalCompare.removeClass("show");
    modalCompareM.removeClass("show");
  });

  //when window clcik modal compare close
  // $(window).on("click", function() {
  //   // e.preventDefault();
  //   var target = $(this.event.target)
  //     .parent()
  //     .parent();
  //   if (target.html() != modalCompare.html()) {
  //     modalCompare.removeClass("show");
  //   }
  // });

  // open card modal
  openCard.on("click", function(e) {
    e.preventDefault();
      if (modalCompare.hasClass("show") || modalCompareM.hasClass("show") || madalQuickView.hasClass("show")) {
          modalCompare.removeClass("show");
          modalCompareM.removeClass("show");
          madalQuickView.modal('hide');
    }
    // else if(madalQuickView.hasClass("show")){
    //   madalQuickView.removeClass("show");

    // }
  });

  // closeBtn1.on("click", function() {
  //   madalCard.removeClass("show");
  // });

  // #region when quick view open close compare modal
    //var str = "Visit Microsoft!";
    //var res = str.replace(" ", "-");
    //console.log(res);

    function numberRounder(number, precision) {
        precision = Math.pow(10, precision)
        return Math.ceil(number * precision) / precision
    }
  openQuickV.on("click", function(e) {
      e.preventDefault();
      var product = $(this)
          .parent()
          .parent()
          .parent()
          .parent()
          .parent();
      productImg = product.data("image");
      pPrice = product.data("price");
      

      //alert(numberRounder(123.123, 2))
      pdiscount = product.data("discount"); 
      NewPrice = pPrice - (pPrice * pdiscount / 100);
      
      //NewPrice.parseFloat("##.###")
      //alert($("#ProductQV").find(".BrandModelCat").text());
      $("#ProductQV").find(".data-model").text(product.data("model"));
      $("#ProductQV").find(".data-display").text(product.data("display"));
      $("#ProductQV").find(".data-processor").text(product.data("processor"));
      $("#ProductQV").find(".data-system").text(product.data("system"));
      $("#ProductQV").find(".data-memory").text(product.data("memory"));
      $("#ProductQV").find(".data-storage").text(product.data("storage"));
      $("#ProductQV").find(".data-price").text(`$ ${numberRounder(NewPrice, 2)}`);
      $("#ProductQV").find(".data-image").attr('src', productImg);
      $("#ProductQV").find(".data-graphic").text(product.data("graphic"));
      $("#ProductQV").find(".data-weight").text(product.data("weight"));
      $("#ProductQV").find(".data-discount").text(`$ ${pPrice}`);
      $("#ProductQV").find(".data-dimensions").text(product.data("dimensions"));
      ///add to cart btn set data id 
      $("#ProductQV").find(".minicartBtn").attr('data-id', product.data("id"));
      /// add to cart product details link
      var categoryName = product.data("category");
      var Model = product.data("href");
      $("#ProductQV").find(".quickViewDetails").attr('href', `/product/name-${categoryName}-${Model}/${product.data("id")}`)
      /// product / name -@item.Category.Name.Replace(" ", "") -@item.Model.Replace(" ", "") /@item.Id"
      console.log(product.data("href"))
    if (modalCompare.hasClass("show")) {
      modalCompare.removeClass("show");
      
    }
  });
  // #endregion when quick view open close compare modal
  // #endregion modals: compare , quick view , mini card

    // #region 6.quantity change js start ---------*/
  //$(".pro-qty").prepend('<span class="dec qtybtn">-</span>');
  //$(".pro-qty").append('<span class="inc qtybtn">+</span>');
  //$(".qtybtn").on("click", function() {
  //  var $button = $(this);
  //  var oldValue = $button
  //    .parent()
  //    .find("input")
  //    .val();
  //  if ($button.hasClass("inc")) {
  //    var newVal = parseFloat(oldValue) + 1;
  //  } else {
  //    // Don't allow decrementing below zero
  //    if (oldValue > 0) {
  //      var newVal = parseFloat(oldValue) - 1;
  //    } else {
  //      newVal = 0;
  //    }
  //  }
  //  $button
  //    .parent()
  //    .find("input")
  //    .val(newVal);
  //});
  //#endregion 6.quantity change js end ---------*/

    //#region 7. scroll top page
  $(window).scroll(function() {
    if ($(this).scrollTop() > 200) {
      $("#topBtn").fadeIn();
    } else {
      $("#topBtn").fadeOut();
    }
  });

  $("#topBtn").click(function() {
    $("html ,body").animate({ scrollTop: 0 }, 800);
  });
  //#endregion 7. scroll top page

    //  #region 8. minicart added product delete from cart
    updatetotal();
    $(document).on("click", ".minicartBtn", function (e) {
        e.preventDefault();
        var id = $(this).data("id");

        $.ajax({
            url: "/Cart/AddToCart",
            data: { id: id },
            type: "post",
            datatype: "json",
            success: function (res) {
                if (res.status == 200) {
                    Swal.fire({

                        type: 'success',
                        title: 'Your Product Added to MiniCart',
                        showConfirmButton: false,
                        timer: 1500
                    })
                    var count = parseInt($('.MiniCard-notification').html())
                    if (count == 0) {
                        $(".mini-cart-items").html("");
                    }
                    count++;
                    $(".mini-cart-items").append(` <li data-count="${count}" data-price="${Number(res.price) - (Number(res.price) * Number(res.discount) / 100)}" data-id="${id}" class="minicart-item mini-product-cart">
                                                        <div data-id="${id}" class="minicart-thumb">
                                                            <a href="/product/name-${res.category}-${res.name}/${id}">
                                                                <img src="/Public/images/${res.image}" alt="product">
                                                            </a>
                                                        </div>
                                                        <div class="minicart-content">
                                                            <h3 class="product-name">
                                                                <a href="/product/name-${res.category}-${res.name}/${id}">${res.category}<br />${res.name}"</a>
                                                            </h3>
                                                            <p>
                                                                <span class="cart-price">$${Number(res.price) - (Number(res.price) * Number(res.discount) / 100)}</span>
                                                                <span class="price-old"><del>$${Number(res.price)}</del></span>
                                                            </p>
                                                        </div>
                                                        <button data-id="${id}" class="minicart-remove mcremove"><span aria-hidden="true">×</span></button>
                                                    </li>`)

                    $('.MiniCard-notification').text(count);
                    updatetotal();
                }
                else if (res.status == 204) {

                    Swal.fire({

                        type: 'error',
                        title: res.message,
                        showConfirmButton: false,
                        timer: 1500
                    })
                }
            }


        });
    })

    //delete mini cart item 

    $(document).on("click", ".mcremove", function () {

        var productId = $(this).parent().data("id");
        //var checkProductId = $(this).parent();
        var element = $(this).parent();
        var elementCheck = $(".Checkelement").data("id");
        var elemCheck = $(".Checkelement");
        //console.log(element);
        $.ajax({

            url: "/Cart/DeleteFromCart",
            data: { id: productId },
            type: "post",
            datatype: "json",
            success: function (res) {
                if (res.status == 200) {
                    //console.log(elementCheck)
                    Swal.fire({

                        type: 'success',
                        title: 'Your Product Remove from MiniCart',
                        showConfirmButton: false,
                        timer: 1500
                    })
                    $(element).remove();
                    $(".Checkelement[id=" + elementCheck + "]").remove();
                    updatetotal();
                    var notificationCount = parseInt($('.MiniCard-notification').html());
                    //console.log(notificationCount)
                    notificationCount = notificationCount - 1;
                    //console.log(notificationCount)
                    $('.MiniCard-notification').text(notificationCount);

                } else if (res.status == 204) {

                    Swal.fire({

                        type: 'error',
                        title: res.message,
                        showConfirmButton: false,
                        timer: 1500
                    })
                }
                else if (res.status == 404) {

                    Swal.fire({

                        type: 'error',
                        title: res.message,
                        showConfirmButton: false,
                        timer: 1500
                    })
                }

            }

        });
    });

    function updatetotal() {
        var cps = $('.mini-product-cart');
        var total = 0;

        for (var i = 0; i < cps.length; i++) {
            total += $(cps[i]).data("price");
        }

        $("#totalMCart").text(`$${total.toFixed(2)}`);
        $("#SubTotalCheck").text(`$${total.toFixed(2)}`);
    }

    //function updateNotificationCount() {
    //    var MinicartItems = $('.mini-product-cart');
    //    var notificationCount = parseInt($('.MiniCard-notification').html());
    //    for (var i = 0; i < MinicartItems.length; i++) {


    //    }
    //    notificationCount -= notificationCount;
    //    $('.MiniCard-notification').text(notificationCount);
    //    console.log($(MinicartItems))
    //    console.log(notificationCount)
    //}

    //  #endregion end. minicart added product delete from cart


    //  #region 9. compare product desktop
    $("#CompareproductBtn").on("click", function (e) {
        e.preventDefault();
        var id = ","; //toString().split(",")
        productCompares = $("#line .compare-product");

        for (var i = 0; i < productCompares.length; i++) {
            id += ($(productCompares[i]).data("id")) + ",";
        }
        window.location.href = `/Compare/Index?id=${id}`

    });

    //  #endregion 9. compare product

    //  #region 10. compare product mobile
    $(document).on("click", "#CompareproductBtnM", function (e) {
        e.preventDefault();

        var id = ","; //toString().split(",")
        productCompares = $("#lineM .compare-product");

        for (var i = 0; i < productCompares.length; i++) {
            id += ($(productCompares[i]).data("id")) + ",";
        }
        window.location.href = `/Compare/Index?id=${id}`

    });
    //  #endregion 10. compare mobile





  // /*------- Countdown Activation start -------*/
  // $('[data-countdown]').each(function () {
  // 	var $this = $(this),
  // 		finalDate = $(this).data('countdown');
  // 	$this.countdown(finalDate, function (event) {
  // 		$this.html(event.strftime('<div class="single-countdown"><span class="single-countdown__time">%D</span><span class="single-countdown__text">Days</span></div><div class="single-countdown"><span class="single-countdown__time">%H</span><span class="single-countdown__text">Hours</span></div><div class="single-countdown"><span class="single-countdown__time">%M</span><span class="single-countdown__text">Mins</span></div><div class="single-countdown"><span class="single-countdown__time">%S</span><span class="single-countdown__text">Secs</span></div>'));
  // 	});
  // });
  // /*------- Countdown Activation end -------*/
});
