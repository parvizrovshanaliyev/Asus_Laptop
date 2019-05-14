var Header_search = {
  default_container: $("#search_button"),
  ws_seq: "AW000001",
  action_url: "autocomplete",
  default_search_url: "search",
  keyword: "",
  keyword_default: "",
  hot_key:
    typeof HOT_KEYWORD === "undefined" || HOT_KEYWORD === "null"
      ? ""
      : JSON.parse(HOT_KEYWORD),
  default_key:
    typeof DEFAULT_KEYWORD === "undefined" || DEFAULT_KEYWORD === "null"
      ? ""
      : JSON.parse(DEFAULT_KEYWORD),
  jump_key: typeof JUMP_KEYWORD !== "undefined" ? JSON.parse(JUMP_KEYWORD) : "",
  IS_CROSS: IS_CROSS == "1" ? true : false,
  cross_country: cross_country ? cross_country : "",
  bind_plugin: ["autocomplete"],
  init: function() {
    if (typeof this.default_container == "undefined") {
      return false;
    }
    if (typeof ws_seq != "undefined") {
      this.ws_seq = ws_seq;
    }
    var controller = window.location.pathname;
    if (controller.match(/search/) !== null) {
      var search_word = window.location.search.match(/[^?=&]+=([^&]*)?/);
      var keyword = decodeURIComponent(search_word[1]);
      if (
        typeof keyword == "undefined" ||
        keyword == "undefined" ||
        keyword == null
      ) {
        this.keyword = "";
      } else {
        this.keyword = keyword;
      }
    } else {
      if (window.location.search.match(/type=3/) !== null) {
        var match_word = window.location.search.match(/[^?=&]+=([^&]*)?/);
        this.keyword = decodeURIComponent(match_word[1]);
      }
      this.keyword_default =
        typeof this.default_key[0] === "undefined"
          ? ""
          : this.default_key[0].keyword;
    }
    this.create_form();
    this.create_hotkey(this.hot_key);
    var _parent = this;
    if (this.IS_CROSS == false) {
      $.each(this.bind_plugin, function(k, _action) {
        if (
          _action == "autocomplete" &&
          typeof $.fn.autocomplete != "undefined"
        ) {
          var inputObj = _parent.default_container.find("input[name=q]");
          var formObj = _parent.default_container.find("form");
          inputObj.autocomplete({
            source: www_url + _parent.action_url + "/",
            select: function(e, ui) {
              inputObj.val(ui.item.value);
              window.location.href = _parent.search_url(ui.item.value);
            },
            delay: 300
          });
        }
      });
    }
  },
  create_div: function() {},
  create_hotkey: function(hot_key) {
    var hotkeyDiv = $("<div></div>")
      .addClass("recommend")
      .appendTo("#search_button");
    hotkeyDiv.append(this.generate_li_list(hot_key));
  },
  check_http: function(url) {
    return url.match(/^(http|https):\/\//g) ? url : "http://" + url;
  },
  generate_li_list: function(json_hotkey) {
    if (json_hotkey === "") {
      return "";
    }
    var hotkey_menu = "",
      _self = this;
    $.each(json_hotkey, function(key, val) {
      var url =
        val["url"] === null || val["url"] === ""
          ? www_url +
            "search/?q=" +
            encodeURIComponent(val["keyword"]) +
            "&s_c=0"
          : _self.check_http(val["url"]);
      hotkey_menu +=
        '<li><a href="' + url + '">' + val["keyword"] + "</a></li>";
    });
    return hotkey_menu;
  },
  create_form: function() {
    var action_uri = www_url + this.default_search_url;
    var placeholder =
      "" === this.keyword_default
        ? LANG.web_line("Site_Label_search_holder")
        : this.keyword_default;
    var form = $(
      '<form id="form_header_search" method="GET" onsubmit="return false;" class="form"></form>'
    ).attr("action", action_uri);
    var inputContent = $(
      '<input name="q" type="search" class="input-search" maxlength="128" placeholder="' +
        placeholder +
        '"/>'
    )
      .val("")
      .attr("action", this.action_url);
    var inputBtn = $('<button type="submit">').addClass("btn-submit");
    var iconBtn = $("<i>").addClass("fa fa-search icon-search");
    inputBtn.append(iconBtn);
    form
      .append(inputContent)
      .append(inputBtn)
      .appendTo(this.default_container);
    $("form#form_header_search")
      .eq(1)
      .attr("id", "form_header_search_mobile");
    $("#form_header_search")
      .find("input")
      .attr("id", "q")
      .bind("keypress", this, this.search_keyup);
    $("#form_header_search")
      .find("button")
      .bind("click", this, this.search);
    $("#form_header_search_mobile")
      .find("input")
      .attr("id", "q_mobile")
      .bind("keypress", this, this.search_keyup_mobile);
    $("#form_header_search_mobile")
      .find("button")
      .bind("click", this, this.search_mobile);
    if ($("#cross_country_select").val() != undefined) {
      $("#cross_country_select").val(this.cross_country);
    }
    if (Header_search.keyword != "") {
      window.setTimeout(function() {
        Header_search.keyword.replace(/\++/g, " ");
        $("#form_header_search")
          .find("input")
          .val(Header_search.keyword);
        $("#form_header_search_mobile")
          .find("input")
          .val(Header_search.keyword);
      }, 1000);
    }
  },
  search: function(event) {
    var _self = event ? event.data : this;
    var q = $("#q")
      .val()
      .replace(/(^[\s]*)|([\s]*$)/g, "");
    if (q == "" && typeof _self.default_key[0] === "undefined") {
      return false;
    } else {
      if ("" === q && "undefined" !== typeof _self.default_key[0]) {
        var url =
          _self.default_key[0].url === null || _self.default_key[0].url === ""
            ? www_url +
              "search/?q=" +
              encodeURIComponent(_self.default_key[0].keyword) +
              "&s_c=0"
            : _self.check_http(_self.default_key[0].url);
        window.location.href = url;
      } else {
        var action = true;
        if ("" !== _self.jump_key) {
          action = _self.search_jump(_self.jump_key, q);
        }
        if (action) {
          window.location.href = _self.search_url(q);
        }
      }
      return true;
    }
  },
  search_jump: function(jumpkey_obj, user_input) {
    var items = [],
      _self = this;
    $.each(jumpkey_obj, function(key, val) {
      if (user_input == val["keyword"]) {
        var url = _self.check_http(val["url"]);
        items.push(url);
        return false;
      }
    });
    if (items.length > 0) {
      window.location.href = items[0];
      return false;
    }
    return true;
  },
  search_keyup: function(event) {
    var _self = event ? event.data : this;
    if (event.keyCode == 13) {
      _self.search();
    }
  },
  search_mobile: function() {
    var q = $("#q_mobile").val();
    if (q == "") {
      return false;
    }
    window.location.href =
      www_lib + "search?q=" + encodeURIComponent(q) + "&s_c=1";
  },
  search_keyup_mobile: function(event) {
    var _self = event ? event.data : this;
    if (event.keyCode == 13) {
      _self.search_mobile();
    }
  },
  search_url: function(q) {
    var controller = "search";
    var country = "";
    var s_c = "&s_c=1";
    if (this.IS_CROSS == true && this.cross_country != "GLOBAL") {
      controller = "cross_search";
      country = "&country=" + this.cross_country;
      if ($("#cross_country_select").val() != undefined) {
        country = "&country=" + $("#cross_country_select").val();
      }
    }
    var search_url =
      www_lib + controller + "?q=" + encodeURIComponent(q) + country + s_c;
    return search_url;
  }
};
$(function() {
  Header_search.init();
  $("input[placeholder]").placeholder();
});
var tab_type_id = "";
function cart_tab(cart_tab) {
  tab_type_id = cart_tab;
  $.cookie("tab_type_id", cart_tab, { path: "/" });
  draw_float_cart_pcs();
  draw_float_cart_list();
}
function SetshopCart(items) {
  shopCart();
}
function shoping_cart_build(items) {
  var cart_list = build_cart_list(items);
  cart_list += cart_campaign(items);
  cart_list += cart_list_total(items);
  return cart_list;
}
function build_cart_list(items) {
  if (
    typeof items[ws_seq] === "undefined" &&
    typeof items[ws_seq + "_store"] === "undefined"
  ) {
    return false;
  }
  var css_online = "";
  var css_store = "";
  var css_online_active = "";
  var css_store_active = "";
  tab_type_id = $.cookie("tab_type_id");
  if (tab_type_id == "online" || tab_type_id == "") {
    css_online_active = "active";
    css_store_active = "";
    css_online = "show";
    css_store = "hide";
  } else {
    css_online_active = "";
    css_store_active = "active";
    css_online = "hide";
    css_store = "show";
  }
  if (
    typeof items.pcs_ec !== "undefined" &&
    parseInt(items.pcs_ec) > 0 &&
    (typeof items.pcs_store !== "undefined" && parseInt(items.pcs_store) === 0)
  ) {
    css_online_active = "active";
    css_online = "show";
    css_store_active = "";
    css_store = "hide";
  }
  if (
    typeof items.pcs_ec !== "undefined" &&
    parseInt(items.pcs_ec) === 0 &&
    (typeof items.pcs_store !== "undefined" && parseInt(items.pcs_store) > 0)
  ) {
    css_online_active = "";
    css_online = "hide";
    css_store_active = "active";
    css_store = "show";
  }
  var cart_list = '<div class="list">';
  if (IS_O2O == 1) {
    if (
      (typeof items.pcs_ec !== "undefined" && parseInt(items.pcs_ec) > 0) ||
      (typeof items.pcs_store !== "undefined" && parseInt(items.pcs_store) > 0)
    ) {
      cart_list += '<div class="float-cart-tab">';
      if (parseInt(items.pcs_ec) > 0) {
        cart_list +=
          '<div class="cart_tab ' +
          css_online_active +
          '" id="tabitme_online" onclick="cart_tab(\'online\')">' +
          LANG.web_line("Cart_tab_online_title") +
          "(" +
          items.pcs_ec +
          ")</div>";
      }
      if (parseInt(items.pcs_store) > 0) {
        cart_list +=
          '<div class="cart_tab ' +
          css_store_active +
          '" id="tabitme_store" onclick="cart_tab(\'store\')">' +
          LANG.web_line("Cart_tab_store_title") +
          "(" +
          items.pcs_store +
          ")</div>";
      }
      cart_list += "</div>";
    }
  }
  var row_count = 0;
  var camp_data = "";
  if (items[ws_seq] != undefined) {
    $.each(items[ws_seq], function(index, row) {
      switch (row.options.kind) {
        case "1":
          if (0 === row_count) {
            cart_list +=
              '<div class="items div_items_online ' +
              css_online +
              '" id="' +
              row.rowid +
              '">';
          } else {
            cart_list += camp_data;
            cart_list +=
              '</div><div class="items div_items_online ' +
              css_online +
              '" id="' +
              row.rowid +
              '">';
          }
          camp_data = campaign_meet_up(row);
          var combine_row = find_all_combine(items, row, "");
          if (combine_row !== false) {
            cart_list += combine_items(combine_row);
            if (combine_row.options.limit.type !== null) {
              cart_list += limit_item(combine_row);
            }
          } else {
            cart_list += item(row);
            if (
              row.options.limit.type !== null &&
              row.options.limit.limit == 1
            ) {
              cart_list += limit_item(row);
            }
            if (row.special_promo != 0) {
              cart_list += special_promo(row);
            }
          }
          break;
        case "2":
          cart_list += gift(row);
          break;
        case "3":
          cart_list += add(row);
          break;
        case "8":
          cart_list += add_on(row);
          break;
        case "9":
          cart_list += buy_and_discount(row);
          break;
      }
      row_count++;
    });
    cart_list += camp_data;
    cart_list += "</div>";
  }
  var ws_seq_store = ws_seq + "_store";
  if (items[ws_seq_store] != undefined) {
    var row_count2 = 0;
    $.each(items[ws_seq_store], function(index, row) {
      switch (row.options.kind) {
        case "1":
          if (0 === row_count2) {
            cart_list +=
              '<div class="items div_items_store ' +
              css_store +
              '" id="store' +
              row.rowid +
              '">';
          } else {
            cart_list += camp_data;
            cart_list +=
              '</div><div class="items div_items_store ' +
              css_store +
              '" id="store' +
              row.rowid +
              '">';
          }
          camp_data = campaign_meet_up(row);
          var combine_row = find_all_combine(items, row, "_store");
          if (combine_row !== false) {
            cart_list += combine_items(combine_row);
            if (
              combine_row.options.limit.type !== null &&
              (typeof combine_row.options.limit.limit !== "undefined" &&
                parseInt(combine_row.options.limit.limit) > 0)
            ) {
            }
          } else {
            cart_list += item(row);
            if (
              row.options.limit.type !== null &&
              row.options.limit.limit == 1
            ) {
            }
            if (row.special_promo != 0) {
              cart_list += special_promo(row);
            }
          }
          break;
        case "2":
          cart_list += gift(row);
          break;
        case "3":
          cart_list += add(row);
          break;
        case "8":
          cart_list += add_on(row);
          break;
        case "9":
          cart_list += buy_and_discount(row);
          break;
      }
      row_count2++;
    });
    cart_list += camp_data;
    cart_list += "</div>";
  }
  cart_list += "</div>";
  return cart_list;
  function item(row) {
    var cart_list =
      '<div class="item" type="original" row_id="' + row.id + '">';
    cart_list +=
      '<a href="' +
      www_url +
      "item/" +
      row.options.sell_no +
      '" class="crop"><img src="' +
      img_inside_url +
      row.options.it_pic +
      '!t64x64" alt=""/></a>';
    cart_list += '<div class="name">' + row.name + "</div>";
    cart_list += '<div class="buy">';
    cart_list += '<span class="currency">' + currency_symbol + "</span>";
    if (row.special_promo != 0) {
      cart_list +=
        '<span class="price">' + row.special_promo_ori_price + "</span>";
    } else {
      cart_list += '<span class="price">' + row.price + "</span>";
    }
    cart_list += "</div>";
    cart_list += '<div class="quantity small">';
    cart_list += num_select(row.options.max_select, row.qty, row.rowid);
    cart_list += "</div>";
    cart_list +=
      '<a href="javascript:void(0)" class="del" onclick="cart_del(this)" rowid="' +
      row.rowid +
      '" store="' +
      row.store +
      '">' +
      LANG.web_line("Site_Label_cart_delete") +
      "</a>";
    cart_list += "</div>";
    return cart_list;
  }
  function add(row) {
    var cart_list = '<div class="item" type="plus" row_id="' + row.id + '">';
    cart_list += '<span class="crop-no"></span>';
    cart_list += '<div class="name">' + row.name + "</div>";
    cart_list += '<div class="buy">';
    cart_list += '<span class="currency">' + currency_symbol + "</span>";
    cart_list += '<span class="price">' + row.price + "</span>";
    cart_list += "</div>";
    cart_list += '<div class="quantity small">';
    cart_list += num_select(row.options.max_select, row.qty, row.rowid);
    cart_list += "</div>";
    cart_list +=
      '<a href="javascript:void(0)" class="del" onclick="cart_del(this)" rowid="' +
      row.rowid +
      '" store="' +
      row.store +
      '">' +
      LANG.web_line("Site_Label_cart_delete") +
      "</a>";
    cart_list += "</div>";
    return cart_list;
  }
  function add_on(row) {
    var cart_list = '<div class="item" type="plus" row_id="' + row.id + '">';
    cart_list +=
      '<a href="' +
      www_url +
      "item/" +
      row.options.sell_no +
      '" class="crop"><img src="' +
      img_inside_url +
      row.options.it_pic +
      '!t64x64" alt=""/></a>';
    cart_list +=
      '<div class="name">' +
      LANG.web_line("Site_Label_add_on_shopping_cart") +
      " - " +
      row.name +
      "</div>";
    cart_list += '<div class="buy">';
    cart_list += '<span class="currency">' + currency_symbol + "</span>";
    cart_list += '<span class="price">' + row.price + "</span>";
    cart_list += "</div>";
    cart_list += '<div class="quantity small">';
    cart_list += num_select(row.options.max_select, row.qty, row.rowid);
    cart_list += "</div>";
    cart_list +=
      '<a href="javascript:void(0)" class="del" onclick="cart_del(this)" rowid="' +
      row.rowid +
      '" store="' +
      row.store +
      '">' +
      LANG.web_line("Site_Label_cart_delete") +
      "</a>";
    cart_list += "</div>";
    return cart_list;
  }
  function combine_items(row) {
    var cart_list = '<div class="item">';
    cart_list +=
      '<a href="' +
      www_url +
      "item/" +
      row.options.sell_no +
      '" class="crop"><img src="' +
      img_inside_url +
      row.options.k6_s_pic +
      '!t64x64" alt=""/></a>';
    cart_list += '<div class="name">' + row.options.sell_name + "</div>";
    cart_list += '<div class="buy">';
    cart_list += '<span class="currency">' + currency_symbol + "</span>";
    cart_list += '<span class="price">' + row.options.k6_s_total + "</span>";
    cart_list += "</div>";
    cart_list += '<div class="quantity small">';
    cart_list += num_select(row.options.max_select, row.qty, row.rowid);
    cart_list += "</div>";
    cart_list +=
      '<a href="javascript:void(0)" class="del" onclick="cart_del(this)" rowid="' +
      row.rowid +
      '" store="' +
      row.store +
      '">' +
      LANG.web_line("Site_Label_cart_delete") +
      "</a>";
    cart_list += "</div>";
    cart_list += '<div class="item" type="combine">';
    cart_list += '<span class="crop-no"></span>';
    cart_list += '<div class="name combo">';
    cart_list += "<p>" + LANG.web_line("Item_Label_have_the_product") + "</p>";
    $.each(row.combine, function(key, combine) {
      cart_list +=
        '<p class="combo_item" id="' +
        combine.id +
        '" price="' +
        combine.price +
        '" qty="' +
        combine.qty +
        '" indx="' +
        key +
        '">' +
        combine.name +
        "</p>";
    });
    cart_list += "</div>";
    cart_list += "</div>";
    return cart_list;
  }
  function limit_item(row) {
    var cart_list = '<div class="item">';
    cart_list += '<span class="crop-no"></span>';
    cart_list +=
      '<div class="name limited">' + row.options.limit.doc + "</div>";
    cart_list += "</div>";
    return cart_list;
  }
  function gift(row) {
    var cart_list = '<div class="item">';
    cart_list += '<span class="crop-no"></span>';
    cart_list += '<div class="name">' + row.name + "</div>";
    cart_list += "</div>";
    return cart_list;
  }
  function buy_and_discount(row) {
    var cart_list = '<div class="item">';
    cart_list += '<span class="crop-no"></span>';
    cart_list +=
      '<div class="name">' +
      LANG.web_line("Buy_Text_diacount_of_buy_now") +
      "</div>";
    cart_list += '<div class="buy">';
    cart_list += '<span class="negative_sign">-</span>';
    cart_list += '<span class="currency">' + currency_symbol + "</span>";
    cart_list += '<span class="price">' + row.price + "</span>";
    cart_list += "</div>";
    cart_list += "</div>";
    return cart_list;
  }
  function special_promo(row) {
    var cart_list = '<div class="item">';
    cart_list += '<span class="crop-no"></span>';
    cart_list +=
      '<div class="name">' +
      LANG.web_line("Small_Cart_Special_Promo_on_shopping_cart") +
      "</div>";
    cart_list += '<div class="buy">';
    cart_list += '<span class="currency">-' + currency_symbol + "</span>";
    cart_list += '<span class="price">' + row.special_promo + "</span>";
    cart_list += "</div>";
    cart_list += "</div>";
    return cart_list;
  }
  function campaign_meet_up(row) {
    var cart_list = "";
    if (!$.isArray(row.options.ma)) {
      return cart_list;
    }
    $.each(row.options.ma, function(key, camp) {
      if (parseInt(camp.camp_reach) >= 1) {
        cart_list += '<div class="item">';
        cart_list += '<span class="crop-no"></span>';
        cart_list += '<div class="name full">';
        cart_list +=
          '<span class="tag">' +
          LANG.web_line("Campaign_Text_qualified_campaign_event") +
          "</span>";
        cart_list += camp.camp_name;
        cart_list += "</div>";
        cart_list += "</div>";
      }
    });
    return cart_list;
  }
  function num_select(max_count, qty, rowid) {
    if (max_count > 99) {
      max_count = 99;
    }
    var select_list = '<span class="quantity-input">' + qty + "</span>";
    return select_list;
  }
  function find_all_combine(items, row, store) {
    var flag = false;
    var itemObj = row;
    itemObj.combine = new Array();
    itemObj.combine.push({
      id: row.id,
      name: row.name,
      price: row.price,
      qty: row.qty,
      it_large: row.options.it_large,
      options: row.options
    });
    $.each(items[ws_seq + store], function(key, value) {
      if (value.options.master_id === row.id && value.options.kind == "6") {
        flag = true;
        itemObj.combine.push({
          id: value.id,
          name: value.name,
          price: value.price,
          qty: value.qty,
          it_large: value.options.it_large,
          options: row.options
        });
      }
    });
    if (flag === false) {
      return false;
    } else {
      return itemObj;
    }
  }
}
function cart_campaign(items) {
  if (
    typeof items.activity_data_ec == "undefined" &&
    typeof items.activity_data_store == "undefined"
  ) {
    return "";
  }
  var css_online = "";
  var css_store = "";
  if (
    typeof tab_type_id == "undefined" ||
    tab_type_id == "online" ||
    tab_type_id == ""
  ) {
    css_online = "show";
    css_store = "hide";
  } else {
    css_online = "hide";
    css_store = "show";
  }
  if (
    typeof items.pcs_ec !== "undefined" &&
    parseInt(items.pcs_ec) > 0 &&
    (typeof items.pcs_store !== "undefined" && parseInt(items.pcs_store) === 0)
  ) {
    css_online_active = "active";
    css_online = "show";
    css_store_active = "";
    css_store = "hide";
  }
  if (
    typeof items.pcs_ec !== "undefined" &&
    parseInt(items.pcs_ec) === 0 &&
    (typeof items.pcs_store !== "undefined" && parseInt(items.pcs_store) > 0)
  ) {
    css_online_active = "";
    css_online = "hide";
    css_store_active = "active";
    css_store = "show";
  }
  var cart_list_campaign = "";
  if (typeof items.activity_data_ec !== "undefined") {
    var camp_list_data = get_activity_data(items.activity_data_ec);
    cart_list_campaign += buildt_activity_html(camp_list_data, css_online);
  }
  if (typeof items.activity_data_store !== "undefined") {
    var camp_list_data = get_activity_data(items.activity_data_store);
    cart_list_campaign += buildt_activity_html(camp_list_data, css_store);
  }
  return cart_list_campaign;
}
function get_activity_data(activity_data) {
  var camp_list_data = new Array();
  $.each(activity_data, function(camp_seq, activity) {
    $.each(activity.item, function(item_index, item) {
      $.each(item.options.ma, function(ma_index, ma) {
        if (ma.camp_seq === camp_seq && parseInt(ma.camp_reach, 10) >= 1) {
          camp_list_data[camp_seq] = {
            camp_name: ma.camp_name,
            camp_discount: ma.camp_discount,
            camp_type: ma.camp_type
          };
          return false;
        }
      });
    });
  });
  return camp_list_data;
}
function buildt_activity_html(camp_list_data, css_action) {
  var cart_list_campaign =
    '<ul class="cart-sale cart-actions-online ' + css_action + '">';
  for (var camp_seq in camp_list_data) {
    cart_list_campaign += "<li>";
    switch (camp_list_data[camp_seq].camp_type) {
      case "0":
        var formatted_camp_discount = countryf(
          camp_list_data[camp_seq].camp_discount
        );
        cart_list_campaign +=
          '<span class="sale-name">' +
          LANG.web_line("Campaign_Label_event_discount") +
          ' <span class="negative_sign">-</span> (' +
          camp_list_data[camp_seq].camp_name +
          ")</span>";
        cart_list_campaign +=
          '<span class="sale-discount"><span class="negative_sign">-</span>' +
          '<span class="currency">' +
          currency_symbol +
          "</span>" +
          formatted_camp_discount +
          "</span>";
        break;
      case "1":
        break;
      case "2":
        break;
      default:
        break;
    }
    cart_list_campaign += "</li>";
  }
  if (cart_list_campaign.length > 0) cart_list_campaign += "</ul>";
  return cart_list_campaign;
}
function cart_list_total(items) {
  var css_online = "";
  var css_store = "";
  if (tab_type_id == "online" || tab_type_id == "") {
    css_online = "show";
    css_store = "hide";
  } else {
    css_online = "hide";
    css_store = "show";
  }
  if (
    typeof items.pcs_ec !== "undefined" &&
    parseInt(items.pcs_ec) > 0 &&
    (typeof items.pcs_store !== "undefined" && parseInt(items.pcs_store) === 0)
  ) {
    css_online_active = "active";
    css_online = "show";
    css_store_active = "";
    css_store = "hide";
  }
  if (
    typeof items.pcs_ec !== "undefined" &&
    parseInt(items.pcs_ec) === 0 &&
    (typeof items.pcs_store !== "undefined" && parseInt(items.pcs_store) > 0)
  ) {
    css_online_active = "";
    css_online = "hide";
    css_store_active = "active";
    css_store = "show";
  }
  var cart_list_total =
    '<div class="cart-actions cart-actions-online ' + css_online + '">';
  cart_list_total +=
    '<span class="total-title">' +
    LANG.web_line("Buy_Label_total_count") +
    "</span>";
  cart_list_total += '<span class="total">';
  cart_list_total += '<span class="currency">' + currency_symbol + "</span>";
  cart_list_total += '<span class="price">' + items["total_price"] + "</span>";
  cart_list_total += "</span>";
  cart_list_total +=
    '<a href="javascript:void(0)" ga_class="header shopping-cart" ga_event_label="check out btn" class="button onclick_cart_checkout">';
  cart_list_total += LANG.web_line("Buy_Label_chckout");
  cart_list_total += "</a>";
  cart_list_total += "</div>";
  cart_list_total +=
    '<div class="cart-actions cart-actions-store ' + css_store + '">';
  cart_list_total +=
    '<span class="total-title">' +
    LANG.web_line("Buy_Label_total_count") +
    "</span>";
  cart_list_total += '<span class="total">';
  cart_list_total += '<span class="currency">' + currency_symbol + "</span>";
  cart_list_total +=
    '<span class="price">' + items["total_price_store"] + "</span>";
  cart_list_total += "</span>";
  cart_list_total +=
    '<a href="javascript:void(0)" ga_class="header shopping-cart" ga_event_label="check out btn" class="button onclick_cart_checkout_store">';
  cart_list_total += LANG.web_line("Buy_Label_chckout");
  cart_list_total += "</a>";
  cart_list_total += "</div>";
  return cart_list_total;
}
function empty_cart_list() {
  var cart_list = '<div class="list">';
  cart_list += '<li class="list">';
  cart_list += '<div class="prod">';
  cart_list += "<p>" + LANG.web_line("Buy_Text_please_add_item") + "</p>";
  cart_list += "</div>";
  cart_list += "</li>";
  cart_list += "</div>";
  return cart_list;
}
var cart_update_click = false;
$(".cart-btn").on("change", ".item_qty", function(e) {
  var _this = this;
  var value = parseInt($(this).val(), 10);
  var orig_value = parseInt($(this).data("qty"), 10);
  var rowid = $(this).attr("rowid");
  var value_max = parseInt($(this).attr("max"), 10);
  if (isNaN(value)) {
    alert(LANG.web_line("Buy_Text_pls_type_number"));
    $(this).val(orig_value);
  } else if (value > value_max) {
    alert(LANG.web_line("Buy_Text_over_limit"));
    $(this).val(orig_value);
  } else if (value <= 0) {
    alert(LANG.web_line("Buy_Text_qantity_not_zero"));
    $(this).val(orig_value);
  } else {
    cart_update_click = true;
    cart.cartupdate(rowid, value, function(response_obj) {
      $("li.cart-actions")
        .find("span.price")
        .text(response_obj.total_price);
      if (typeof start_draw !== "undefined") {
        start_draw(cart.response_data_obj);
        draw_float_cart_pcs();
      }
      draw_float_cart_list();
    });
  }
});
function cart_update(obj) {
  var min = 1;
  var obj_content = $(obj)
    .parent()
    .parent()
    .find('input[class="quantity-input type item_qty"]');
  var rowid = obj_content.attr("rowid");
  var max = obj_content.attr("max");
  var customer = parseInt(obj_content.val(), 10);
  var act = parseInt($(obj).attr("act"), 10);
  var menuCartItem = $(".site-cart");
  if (act === 0) {
    customer = customer - 1;
  } else if (act === 1) {
    customer = customer + 1;
  }
  if (typeof customer != "number" || isNaN(customer)) {
    menuCartItem.addClass("hide");
    shopcart_bubble_pop(obj_content, LANG.web_line("Buy_Text_pls_type_number"));
    return false;
  } else if (customer > max) {
    var html =
      '<div class="quantity-alert">' +
      LANG.web_line("Buy_Text_over_limit") +
      "</div>";
    $(obj).css("position", "relative");
    $(obj).append(html);
    setTimeout(function() {
      $(".quantity-alert").fadeOut("slow");
    }, 2500);
    return false;
  } else if (customer < min) {
    menuCartItem.addClass("hide");
    shopcart_bubble_pop(
      obj_content,
      LANG.web_line("Buy_Text_qantity_not_zero")
    );
    return false;
  } else {
    cart_update_click = true;
    cart.cartupdate(rowid, customer, function(response_obj) {
      obj_content.val(customer);
      $(".site-cart > .cart-actions")
        .find(".total > .price")
        .text(response_obj.total_price);
      var check_act_cart_exist = $("div.act-cart");
      if (
        check_act_cart_exist.length === 0 &&
        typeof start_draw == "function"
      ) {
        start_draw(response_obj);
      } else {
        if (typeof update_camp_cart == "function") {
          update_camp_cart(rowid, customer);
        }
      }
      draw_float_cart_pcs();
      draw_float_cart_list();
    });
  }
}
function shopcart_bubble_pop(obj, msg) {
  alert(msg);
}
function cart_del(obj) {
  var rowid = $(obj).attr("rowid");
  var store = $(obj).attr("store");
  var obj_content = $("div.list").find("#" + rowid);
  cart_update_click = true;
  get_value_for_ga(obj);
  cart.cartdelete(rowid, store, function(response_obj) {
    obj_content.css("display", "none");
    $("i.icon-cart")
      .find("span.count")
      .text(response_obj.count);
    $("a.icon-cart")
      .find("span.count")
      .text(response_obj.count);
    $(".site-cart > .cart-actions")
      .find(".total > .price")
      .text(response_obj.total_price);
    if (parseInt(response_obj.count, 10) === 0) {
      shopCart();
    }
    if (typeof camp_cart_del == "function") {
      camp_cart_del(rowid);
    }
    draw_float_cart_pcs();
    draw_float_cart_list();
  });
}
function shopcart_send_ga(page) {
  var ref = "?u=";
  ref = ref + $.base64.encode(window.location.toString());
  if ($(window).width() < WINDOW_WIDTH) {
    cart.link(m_cart_link);
  } else {
    cart.link(cart_link);
  }
}
function shopcart_send_ga_store(page) {
  var ref = "?u=";
  ref = ref + $.base64.encode(window.location.toString());
  if ($(window).width() < WINDOW_WIDTH) {
    cart.link(m_cart_link);
  } else {
    cart.link(cart_link_store);
  }
}
function bind_shopcart_event() {
  var menuCartItemList = $(".site-cart > .list");
  menuCartItemList.find(".onclick_cart_update").each(function(index) {
    $(this).off("click");
    $(this).on("click", function() {
      cart_update(this);
    });
  });
  menuCartItemList.find(".onclick_cart_del").each(function(index) {
    $(this).off("click");
    $(this).on("click", function() {
      cart_del(this);
    });
  });
  $(".site-cart > .cart-actions")
    .find(".onclick_cart_checkout")
    .each(function(index) {
      $(this).off("click");
      $(this).on("click", function() {
        if (typeof ga !== "undefined") {
          ga(
            "send",
            "event",
            $(this).attr("ga_class"),
            "clicked",
            $(this).attr("ga_event_label")
          );
        }
        if (
          typeof SSO_CERTIFICATION !== "undefined" &&
          SSO_CERTIFICATION === "2"
        ) {
          cart.sso_status = true;
        }
        shopcart_send_ga("check out btn");
        return false;
      });
    });
  $(".site-cart > .cart-actions")
    .find(".onclick_cart_checkout_store")
    .each(function(index) {
      $(this).off("click");
      $(this).on("click", function() {
        if (typeof ga !== "undefined") {
          ga(
            "send",
            "event",
            $(this).attr("ga_class"),
            "clicked",
            $(this).attr("ga_event_label")
          );
        }
        if (
          typeof SSO_CERTIFICATION !== "undefined" &&
          SSO_CERTIFICATION === "2"
        ) {
          cart.sso_status = true;
        }
        shopcart_send_ga_store("check out btn");
        return false;
      });
    });
}
/*! http://mths.be/placeholder v2.0.8 by @mathias */
(function(window, document, $) {
  var isOperaMini =
    Object.prototype.toString.call(window.operamini) == "[object OperaMini]";
  var isInputSupported =
    "placeholder" in document.createElement("input") && !isOperaMini;
  var isTextareaSupported =
    "placeholder" in document.createElement("textarea") && !isOperaMini;
  var prototype = $.fn;
  var valHooks = $.valHooks;
  var propHooks = $.propHooks;
  var hooks;
  var placeholder;
  if (isInputSupported && isTextareaSupported) {
    placeholder = prototype.placeholder = function() {
      return this;
    };
    placeholder.input = placeholder.textarea = true;
  } else {
    placeholder = prototype.placeholder = function() {
      var $this = this;
      $this
        .filter((isInputSupported ? "textarea" : ":input") + "[placeholder]")
        .not(".placeholder")
        .bind({
          "focus.placeholder": clearPlaceholder,
          "blur.placeholder": setPlaceholder
        })
        .data("placeholder-enabled", true)
        .trigger("blur.placeholder");
      return $this;
    };
    placeholder.input = isInputSupported;
    placeholder.textarea = isTextareaSupported;
    hooks = {
      get: function(element) {
        var $element = $(element);
        var $passwordInput = $element.data("placeholder-password");
        if ($passwordInput) {
          return $passwordInput[0].value;
        }
        return $element.data("placeholder-enabled") &&
          $element.hasClass("placeholder")
          ? ""
          : element.value;
      },
      set: function(element, value) {
        var $element = $(element);
        var $passwordInput = $element.data("placeholder-password");
        if ($passwordInput) {
          return ($passwordInput[0].value = value);
        }
        if (!$element.data("placeholder-enabled")) {
          return (element.value = value);
        }
        if (value == "") {
          element.value = value;
          if (element != safeActiveElement()) {
            setPlaceholder.call(element);
          }
        } else if ($element.hasClass("placeholder")) {
          clearPlaceholder.call(element, true, value) ||
            (element.value = value);
        } else {
          element.value = value;
        }
        return $element;
      }
    };
    if (!isInputSupported) {
      valHooks.input = hooks;
      propHooks.value = hooks;
    }
    if (!isTextareaSupported) {
      valHooks.textarea = hooks;
      propHooks.value = hooks;
    }
    $(function() {
      $(document).delegate("form", "submit.placeholder", function() {
        var $inputs = $(".placeholder", this).each(clearPlaceholder);
        setTimeout(function() {
          $inputs.each(setPlaceholder);
        }, 10);
      });
    });
    $(window).bind("beforeunload.placeholder", function() {
      $(".placeholder").each(function() {
        this.value = "";
      });
    });
  }
  function args(elem) {
    var newAttrs = {};
    var rinlinejQuery = /^jQuery\d+$/;
    $.each(elem.attributes, function(i, attr) {
      if (attr.specified && !rinlinejQuery.test(attr.name)) {
        newAttrs[attr.name] = attr.value;
      }
    });
    return newAttrs;
  }
  function clearPlaceholder(event, value) {
    var input = this;
    var $input = $(input);
    if (
      input.value == $input.attr("placeholder") &&
      $input.hasClass("placeholder")
    ) {
      if ($input.data("placeholder-password")) {
        $input = $input
          .hide()
          .next()
          .show()
          .attr("id", $input.removeAttr("id").data("placeholder-id"));
        if (event === true) {
          return ($input[0].value = value);
        }
        $input.focus();
      } else {
        input.value = "";
        $input.removeClass("placeholder");
        input == safeActiveElement() && input.select();
      }
    }
  }
  function setPlaceholder() {
    var $replacement;
    var input = this;
    var $input = $(input);
    var id = this.id;
    if (input.value == "") {
      if (input.type == "password") {
        if (!$input.data("placeholder-textinput")) {
          try {
            $replacement = $input.clone().attr({ type: "text" });
          } catch (e) {
            $replacement = $("<input>").attr(
              $.extend(args(this), { type: "text" })
            );
          }
          $replacement
            .removeAttr("name")
            .data({ "placeholder-password": $input, "placeholder-id": id })
            .bind("focus.placeholder", clearPlaceholder);
          $input
            .data({
              "placeholder-textinput": $replacement,
              "placeholder-id": id
            })
            .before($replacement);
        }
        $input = $input
          .removeAttr("id")
          .hide()
          .prev()
          .attr("id", id)
          .show();
      }
      $input.addClass("placeholder");
      $input[0].value = $input.attr("placeholder");
    } else {
      $input.removeClass("placeholder");
    }
  }
  function safeActiveElement() {
    try {
      return document.activeElement;
    } catch (exception) {}
  }
})(this, document, jQuery);
var Cart = function() {
  var _this = this;
  var shop_domains = SHOP_DOMAIN;
  var shop_type = "";
  var url_json2 = shop_domains + "js/json2.js";
  var url_get_sdata = shop_domains + "cart_api/get_sdata";
  var url_set_sdata = shop_domains + "cart_api/set_sdata";
  var url_cart_update = shop_domains + "cart_api/cart_update_by_web";
  var url_cart_delete = shop_domains + "cart_api/cart_delete_by_web";
  var url_from_client = shop_domains + "cart_api/from_client";
  var url_islogin = shop_domains + "member/islogin";
  var cookie_seq = null;
  this.response_data_obj = null;
  this.member_data_obj = null;
  this.cart_data_obj = null;
  this.sso_status = null;
  this.sso_return_uri = null;
  this.init = function() {
    if (typeof JSON === "undefined") {
      $.getScript(url_json2);
    }
    if (this.member_data_obj === null) {
      _init_member_data_obj();
    }
    if (this.cart_data_obj === null) {
      _init_cart_data_obj();
    }
    if (cookie_seq === null) {
      _init_cookie_seq();
    }
    if (typeof SSO_CERTIFICATION !== "undefined" && SSO_CERTIFICATION === "2") {
      _this.sso_logout();
    }
  };
  this.check_is_b2b = function() {
    if (IS_B2B) {
      $.cookie("b2b_status", null);
    }
  };
  this.link = function(url, open_type) {
    if (this.check_web_status() === false) {
      return;
    }
    _drop_member_data_obj();
    _drop_cart_data_obj();
    this.response_data_obj = null;
    _default_link(url, open_type);
  };
  function _default_link(url, open_type) {
    if (open_type == "_blank") {
      window.open(url, open_type);
    } else {
      if (
        (cart.check_web_status() === false || _this.sso_status === null) &&
        typeof SSO_CERTIFICATION !== "undefined" &&
        SSO_CERTIFICATION === "2"
      ) {
        cart.do_sso();
      } else {
        window.location.href = url;
      }
    }
  }
  function _check_cookie() {
    if (
      typeof $.cookie("login_status-" + ws_seq) === "undefined" ||
      typeof $.cookie("login_guid-" + ws_seq) === "undefined" ||
      typeof $.cookie("id-" + ws_seq) === "undefined"
    ) {
      return false;
    }
    return true;
  }
  this.cookie_refresh = function() {
    var tmp_cookie_seq = $.cookie("cookie_seq-" + ws_seq);
    if (
      cookie_seq !== null &&
      typeof tmp_cookie_seq !== "undefined" &&
      cookie_seq !== parseInt(tmp_cookie_seq, 10)
    ) {
      _init_cart_data_obj();
      _init_member_data_obj();
      this.response_data_obj = null;
    }
    return true;
  };
  this.refresh_float_shopcart = function(callback) {
    if (this.response_data_obj === null) {
      _drop_member_data_obj();
      _drop_cart_data_obj();
      this.get_session(callback);
    }
  };
  function _init_member_data_obj() {
    var tmp_status = $.cookie("login_status-" + ws_seq);
    var tmp_guid = $.cookie("login_guid-" + ws_seq);
    var tmp_id = $.cookie("id-" + ws_seq);
    if (
      typeof tmp_status === "undefined" ||
      typeof tmp_guid === "undefined" ||
      typeof tmp_id === "undefined"
    ) {
      tmp_status = false;
      tmp_guid = "";
      tmp_id = "";
    }
    tmp_status = parseInt(tmp_status, 10) === 1 ? true : false;
    _this.member_data_obj = {
      login_status: tmp_status,
      login_guid: tmp_guid,
      id: tmp_id
    };
  }
  function _update_member_data_obj() {
    if (typeof _this.response_data_obj.login_status === "undefined") {
      return false;
    }
    $.cookie(
      "login_status-" + ws_seq,
      _this.response_data_obj.login_status.is_login,
      { path: "/" }
    );
    $.cookie(
      "login_guid-" + ws_seq,
      _this.response_data_obj.login_status.guid,
      { path: "/" }
    );
    $.cookie("id-" + ws_seq, _this.response_data_obj.login_status.id, {
      path: "/"
    });
    _init_member_data_obj();
  }
  function _drop_member_data_obj() {
    $.cookie("login_status-" + ws_seq, null, { path: "/", expires: -1 });
    $.cookie("login_guid-" + ws_seq, null, { path: "/", expires: -1 });
    $.cookie("id-" + ws_seq, null, { path: "/", expires: -1 });
    _init_member_data_obj();
  }
  function _init_cart_data_obj() {
    var tmp_count = $.cookie("count-" + ws_seq);
    var tmp_price = $.cookie("total_price-" + ws_seq);
    if (typeof tmp_count === "undefined" || typeof tmp_price === "undefined") {
      tmp_count = "0";
      tmp_price = "0";
    }
    tmp_count = parseInt(tmp_count, 10);
    _this.cart_data_obj = { count: tmp_count, total_price: tmp_price };
  }
  function _update_cart_data_obj() {
    _update_cookie_seq();
    if (
      typeof _this.response_data_obj.pcs === "undefined" ||
      typeof _this.response_data_obj.total_price === "undefined"
    ) {
      return false;
    }
    $.cookie("count-" + ws_seq, _this.response_data_obj.pcs.toString(), {
      path: "/"
    });
    $.cookie(
      "total_price-" + ws_seq,
      _this.response_data_obj.total_price.toString(),
      { path: "/" }
    );
    _init_cart_data_obj();
  }
  function _drop_cart_data_obj() {
    $.cookie("count-" + ws_seq, null, { path: "/", expires: -1 });
    $.cookie("total_price-" + ws_seq, null, { path: "/", expires: -1 });
    _init_cart_data_obj();
  }
  function _init_cookie_seq() {
    var tmp = parseInt($.cookie("cookie_seq-" + ws_seq), 10);
    if (typeof tmp === "undefined") {
      _update_cookie_seq();
    } else {
      cookie_seq = tmp;
    }
  }
  function _update_cookie_seq() {
    cookie_seq = $.now();
    $.cookie("cookie_seq-" + ws_seq, cookie_seq.toString(), { path: "/" });
  }
  this.check_web_status = function() {
    if (parseInt(WS_STATUS, 10) == 2) {
      return false;
    }
    return true;
  };
  this.check_snapshot = function() {
    if (parseInt(IS_SNAPSHOT, 10) == 1) {
      return true;
    }
    return false;
  };
  this.get_login_status = function() {
    if (_check_cookie() === false) {
      this.get_session(function() {
        return _this.member_data_obj.login_status;
      });
    }
    if (typeof this.member_data_obj.login_status === "undefined") {
      _init_member_data_obj();
    }
    return this.member_data_obj.login_status;
  };
  this.header_click_event = function(target) {
    var open_type = "";
    var target_obj = $(target);
    var target_id = target_obj.attr("id");
    var target_url = "";
    if (
      $(window).width() < WINDOW_WIDTH &&
      typeof target_obj.attr("mlinkinfo") != "undefined"
    ) {
      target_url = target_obj.attr("mlinkinfo");
    } else {
      target_url = target_obj.attr("linkinfo");
    }
    if (
      target_id == "orderlist_link" &&
      typeof SSO_CERTIFICATION !== "undefined" &&
      SSO_CERTIFICATION === "2"
    ) {
      this.sso_return_uri = target_url;
    }
    if (target_id == "login_link" || target_id == "logout_link") {
      var connect = /\?/.test(target_url) ? "&" : "?";
      var u = window.location.toString();
      if (
        typeof SSO_CERTIFICATION !== "undefined" &&
        SSO_CERTIFICATION === "2" &&
        typeof SSO_WWW_URL !== "undefined" &&
        target_obj.data("page") == "item_track"
      ) {
        u = SSO_WWW_URL;
      }
      target_url += connect + "u=" + $.base64.encode(u);
    }
    if (target_id == "login_link") {
      cart.check_is_b2b();
    }
    if (
      (target_id !== "login_link" || target_id !== "signup_link") &&
      _this.member_data_obj.login_status === true &&
      typeof SSO_CERTIFICATION !== "undefined" &&
      SSO_CERTIFICATION === "2"
    ) {
      _this.sso_status = true;
    }
    cart.link(target_url, open_type);
  };
  this.get_session = function(callback) {
    if (this.check_snapshot() === true) {
      return;
    }
    if (
      this.check_web_status() !== false &&
      (_check_cookie() === false || this.get_login_status() === false)
    ) {
      $.ajax({
        url: url_get_sdata,
        type: "get",
        async: false,
        dataType: "jsonp",
        jsonp: "callback",
        data: { ws_seq: ws_seq },
        success: function(data) {
          _this.response_data_obj = data;
          _update_cart_data_obj();
          _update_member_data_obj();
          if (typeof callback !== "undefined") {
            callback(_this.response_data_obj);
          }
        },
        error: function() {}
      });
    } else {
      if (typeof callback !== "undefined") {
        callback(_this.response_data_obj);
      }
    }
  };
  this.set_session = function(send_data, type, source_link, callback) {
    var is_store = 0;
    var shipping_way = $(".span_active").attr("shipping_way_value");
    if (shipping_way == "3") {
      is_store = 1;
    }
    if (this.check_web_status() === false) {
      if (typeof callback !== "undefined") {
        callback(_this.response_data_obj);
      }
      return;
    }
    $.ajax({
      url: url_set_sdata,
      type: "get",
      dataType: "jsonp",
      jsonp: "callback",
      data: {
        source: source_link,
        send_data: JSON.stringify(send_data),
        ws_seq: ws_seq,
        store: is_store
      },
      success: function(data) {
        if (
          typeof data.status !== "undefined" &&
          data.status === false &&
          typeof data.doc !== "undefined" &&
          data.doc != ""
        ) {
          alert(data.doc);
          return false;
        }
        if (is_store == 0) {
          $.cookie("tab_type_id", "online", { path: "/" });
        } else {
          $.cookie("tab_type_id", "store", { path: "/" });
        }
        _this.response_data_obj = data;
        _update_cart_data_obj();
        _update_member_data_obj();
        if (typeof callback !== "undefined") {
          callback(_this.response_data_obj);
        }
        var add_cart_ga_json = [];
        $.each(data[ws_seq], function(k, product_row) {
          var no = send_data.s;
          if (product_row.id.match(no) && product_row.options.kind === "1") {
            add_cart_ga_json = [
              {
                id: send_data.s,
                name: product_row.name,
                price: ga_price_format(product_row.price),
                brand: "ASUS",
                category: product_row.options.gtm_category,
                variant: product_row.options.color,
                quantity: product_row.qty
              }
            ];
          }
        });
        window.dataLayer = window.dataLayer || [];
        var result = window.dataLayer.push({
          event: "addToCart",
          ecommerce: {
            currencyCode: CS_CODE,
            add: { products: add_cart_ga_json }
          }
        });
      },
      error: function() {}
    });
  };
  this.cartupdate = function(row_id, qty, callback) {
    if (this.check_web_status() === false) {
      if (typeof callback !== "undefined") {
        callback(_this.response_data_obj);
      }
      return;
    }
    $.ajax({
      url: url_cart_update,
      type: "GET",
      dataType: "jsonp",
      jsonp: "callback",
      data: { rowid: row_id, qty: qty, ws_seq: ws_seq },
      success: function(data) {
        _this.response_data_obj = data;
        _update_cart_data_obj();
        _update_member_data_obj();
        if (typeof callback !== "undefined") {
          callback(_this.response_data_obj);
        }
      },
      error: function() {}
    });
  };
  this.cartdelete = function(rowid, store, callback) {
    if (this.check_web_status() === false) {
      if (typeof callback !== "undefined") {
        callback(_this.response_data_obj);
      }
      return;
    }
    $.ajax({
      url: url_cart_delete,
      type: "GET",
      dataType: "jsonp",
      data: { rowid: rowid, ws_seq: ws_seq, store: store },
      success: function(data) {
        _this.response_data_obj = data;
        _update_cart_data_obj();
        _update_member_data_obj();
        if (typeof callback !== "undefined") {
          callback(_this.response_data_obj);
        }
        if (data.status === true) {
          var delete_cart_ga_json = [];
          var product_row = data.delete_row;
          if (product_row.rowid.match(rowid)) {
            delete_cart_ga_json = [
              {
                id: product_row.options.sell_no,
                name: product_row.name,
                price: ga_price_format(product_row.price),
                brand: "ASUS",
                category: product_row.options.gtm_category,
                variant: product_row.options.color,
                quantity: product_row.qty
              }
            ];
          }
          window.dataLayer = window.dataLayer || [];
          var result = window.dataLayer.push({
            event: "removeFromCart",
            ecommerce: { remove: { products: delete_cart_ga_json } }
          });
        }
      },
      error: function() {}
    });
  };
  this.do_sso = function() {
    var method = "post";
    var return_uri = window.location.toString();
    if (
      this.sso_return_uri !== null &&
      typeof SSO_CERTIFICATION !== "undefined" &&
      SSO_CERTIFICATION === "2"
    ) {
      return_uri = this.sso_return_uri;
    }
    var params = {
      lang: lang_code,
      site: SSO_COUNTRY,
      login_background: "general_white",
      login_panel: "simply",
      AppID: SSO_APPID,
      ReturnURL:
        MEMBER_DOMAIN + "maccount/do_sso?u=" + $.base64.encode(return_uri)
    };
    var form = document.createElement("form");
    form.setAttribute("method", method);
    form.setAttribute("action", SSO_ACTION_DOMAIN);
    for (var key in params) {
      if (params.hasOwnProperty(key)) {
        var hiddenField = document.createElement("input");
        hiddenField.setAttribute("type", "hidden");
        hiddenField.setAttribute("name", key);
        hiddenField.setAttribute("value", params[key]);
        form.appendChild(hiddenField);
      }
    }
    document.body.appendChild(form);
    form.submit();
  };
  this.sso_logout = function() {
    var referrer = document.referrer;
    var referrer_url =
      referrer.split("/")[0] +
      "//" +
      referrer.split("/")[2] +
      referrer
        .replace(/^[^:]+:\/\/[^/]+/, "")
        .replace(/#.*/, "")
        .split("?")[0];
    if (
      (typeof "SSO_LOGOUT_DOMAIN" !== "undefined" &&
        referrer_url === SSO_LOGOUT_DOMAIN) ||
      (typeof SSO_ATICKET !== "undefined" && SSO_ATICKET === "")
    ) {
      _drop_member_data_obj();
      _drop_cart_data_obj();
      this.response_data_obj = null;
    }
  };
  this.init();
};
var cart = new Cart();
var Shopcart = function() {
  var _this = this;
  var addcartflag = true;
  this.init = function() {};
  this.add_cart = function(cart_param, effect, type, ga_param) {
    var ws_status_data = parseInt(WS_STATUS, 10);
    if (ws_status_data === 2) {
      alert(LANG.web_line("Gate_Text_website_status_try"));
      return false;
    }
    if (ws_status_data === 4) {
      alert(LANG.web_line("Gate_Text_website_status_close"));
      return false;
    }
    if (typeof ga !== "undefined") {
      ga(
        "send",
        "event",
        ga_param.ga_class,
        "clicked",
        ga_param.ga_event_label
      );
    }
    if (
      cart.member_data_obj.login_status === true &&
      typeof SSO_CERTIFICATION !== "undefined" &&
      SSO_CERTIFICATION === "2"
    ) {
      cart.sso_status = true;
    }
    if (addcartflag === false) {
      return;
    }
    addcartflag = false;
    if (typeof cart_param.s === "undefined") {
      addcartflag = true;
      return false;
    }
    if (typeof cart_param.t === "undefined") {
      return false;
    }
    if (typeof cart_param.q === "undefined" || cart_param.q === "") {
      cart_param.q = 1;
    }
    if (cart_param.t === 0 && typeof cart_param.m === "undefined") {
      return false;
    }
    if (typeof cart_param.g === "undefined" || cart_param.g === "") {
      cart_param.g = new Array();
    }
    if (typeof cart_param.p === "undefined" || cart_param.p === "") {
      cart_param.p = new Array();
    }
    var ad_data = _get_partner_ad();
    if (cart_param.is_market_cross == "1") {
      var item_url =
        www_url +
        "item/" +
        cart_param.mc_country +
        "_" +
        cart_param.mc_area +
        "_" +
        cart_param.s;
    } else {
      var item_url = www_url + "item/" + cart_param.s;
    }
    var send_data = {
      s: cart_param.s,
      t: cart_param.t,
      q: parseInt(cart_param.q),
      g: cart_param.g,
      p: cart_param.p,
      m: cart_param.m,
      c: ad_data.partner,
      a: ad_data.content,
      item_source: item_url,
      is_market_cross: cart_param.is_market_cross
    };
    var effect_data = {
      type: effect,
      img: cart_param.img,
      obj: cart_param.obj
    };
    var source_link = window.location.toString();
    if (source_link.indexOf("xxx/window") != -1) {
      source_link = window.parent.location.href.toString();
    }
    _cart_effect(send_data, effect_data, type, source_link);
  };
  function _cart_effect(send_data, effect, type, source_link) {
    var effect_type = 1;
    if (typeof effect == "object") {
      effect_type = effect.type;
    }
    switch (parseInt(effect_type)) {
      case 1:
        var content_div = $(
          '<div class="cart-mark"><p>' +
            LANG.web_line("Buy_Text_adding_to_cart") +
            ".....</p></div>"
        )
          .css({ opacity: "0.5" })
          .appendTo($("body")[0]);
        addcartflag = true;
        content_div.animate({ quene: false, opacity: 0.3 }, 800, function() {
          $(this).remove();
        });
        break;
      case 2:
        var float_cart_obj1 = $(".cart-btn .count");
        var float_cart_obj2 = $(".cart-btn-top .count");
        var class_name = $(".cart-btn-top").css("display");
        var float_cart_obj =
          class_name != "none" ? float_cart_obj2 : float_cart_obj1;
        var fly_axis = $(effect.obj).offset();
        fly_axis.top = fly_axis.top;
        fly_axis.left = fly_axis.left;
        var fly_cart_img = GA_DOMAIN + "/c/img/fly_cart.jpg";
        var move_pic = $(
          '<div class="fly-cart" style="background-image:url(' +
            fly_cart_img +
            ')"><img src="' +
            effect.img +
            '" width="30"></div>'
        )
          .css({
            position: "absolute",
            "z-index": 999,
            width: 60,
            height: 60,
            padding: "30px 10px 0 10px",
            top: fly_axis.top,
            left: fly_axis.left
          })
          .appendTo($("body")[0]);
        var bezier_params = {
          start: { x: fly_axis.left, y: fly_axis.top, angle: -50 },
          end: {
            x: float_cart_obj.offset().left,
            y: float_cart_obj.offset().top
          }
        };
        move_pic
          .animate(
            { path: new $.path.bezier(bezier_params) },
            {
              quene: false,
              duration: "slow",
              step: function(now, fx) {
                var dis_top =
                  float_cart_obj.offset().top - $(this).offset().top - 0;
                var dis_left =
                  float_cart_obj.offset().left - $(this).offset().left - 0;
                if (dis_top <= 3 && dis_left <= 10) {
                }
              },
              complete: function() {}
            }
          )
          .hide("fadeOut", function() {
            addcartflag = true;
            $(this).remove();
          });
        break;
    }
    cart.set_session(send_data, type, source_link, function(response_obj) {
      _special_sale(response_obj, send_data.q);
      var pre = parseInt(response_obj.pre, 10);
      shopCart();
      if (type === 1) {
        parent.$.fancybox.close();
      }
      if (typeof GLOBAL !== "undefined") {
        if (GLOBAL.page_object.controller == "campaign") {
          if (GLOBAL.IS_MOBILE_SET == "1") {
            if (typeof mobile_campaignCart === "function") {
              mobile_campaignCart.start_draw(response_obj);
            }
            if (typeof parent.mobile_campaignCart.start_draw === "function") {
              parent.mobile_campaignCart.start_draw(response_obj);
            }
          } else {
            if (typeof campaignCart === "function") {
              campaignCart.start_draw(response_obj);
            }
            if (typeof parent.campaignCart.start_draw === "function") {
              parent.campaignCart.start_draw(response_obj);
            }
          }
          if (false) {
            var campaignObject =
              GLOBAL.IS_MOBILE_SET == "1" ? mobile_campaignCart : campaignCart;
            if (typeof campaignObject.start_draw === "function") {
              campaignObject.start_draw(response_obj);
            }
            if (typeof parent.campaignObject.start_draw === "function") {
              parent.campaignObject.start_draw(response_obj);
            }
          }
        }
      }
    });
  }
  this.ga_click_event = function(ga_param) {
    if (IS_USE_GA !== "1" || !$.isFunction(ga)) {
      return false;
    }
    if (typeof ga_param.type === "undefined") {
      return false;
    }
    if (ga_param.type === 0 && typeof ga_param.page === "undefined") {
      return false;
    }
    if (typeof ga_param.button === "undefined") {
      return false;
    }
    switch (ga_param.type) {
      case 1:
        ga("send", "event", ga_param.button, "click");
        break;
      case 2:
        ga("send", "event", ga_param.button, "click", ga_param.page);
        break;
      case 0:
      default:
        ga(
          "send",
          "event",
          ga_param.button,
          "click",
          "in " + ga_param.page + " page"
        );
        break;
        break;
    }
    return true;
  };
  function _get_partner_ad() {
    var contentData = { partner: "", content: "" };
    var partnerCookie = $.cookie("asapcps");
    if (typeof partnerCookie !== "undefined" && partnerCookie !== "") {
      var partnerObj = jQuery.parseJSON(partnerCookie);
      contentData.content = partnerObj.alliance_id;
      contentData.partner = partnerObj.adr_id;
    }
    return contentData;
  }
  function _process_limit_type(items, qty) {
    var check = true;
    var show_type = "";
    var max_num = parseInt(items["max_num"], 10);
    var buy_num = parseInt(items["buy_num"], 10);
    var final_num = max_num - buy_num;
    if (buy_num === max_num) {
      show_type = _error_dialog_data(1, items);
      check = false;
    } else {
      if (final_num > 0 && (qty > final_num || qty > max_num)) {
        show_type =
          qty > final_num
            ? _error_dialog_data(2, items)
            : _error_dialog_data(3, items);
      }
    }
    return { check: check, type: show_type };
  }
  function _error_dialog_data(type, items) {
    var max_num = parseInt(items["max_num"], 10);
    var buy_num = parseInt(items["buy_num"], 10);
    var final_num = max_num - buy_num;
    var error_msg =
      "<div>" +
      LANG.web_line("Campaign_Text_limit_unit_count_each_account", {
        limit_unit: max_num
      }) +
      "</div>";
    switch (type) {
      case 1:
        error_msg +=
          "<div>" +
          LANG.web_line("Buy_Text_account_already_buy") +
          " " +
          buy_num +
          " ";
        error_msg +=
          LANG.web_line("Campaign_Text_limit_unit_count") +
          LANG.web_line("Buy_Text_choose_other_product") +
          "</div>";
        break;
      case 2:
        error_msg +=
          "<div>" +
          LANG.web_line("limitsale_account_buy") +
          buy_num +
          LANG.web_line("limitsale_part");
        error_msg +=
          LANG.web_line("Buy_Text_max_buy") + " " + final_num + "</div>";
        break;
      case 3:
        error_msg +=
          "<div>" +
          LANG.web_line("Buy_Text_account_already_buy") +
          " " +
          buy_num +
          " ";
        error_msg += LANG.web_line("Campaign_Text_limit_unit_count");
        error_msg +=
          LANG.web_line("Buy_Text_last_buy") + " " + final_num + "</div>";
        break;
      case 4:
        error_msg = "";
        error_msg +=
          "<div>" + LANG.web_line("Buy_Text_limit_sale_zero_error") + "</div>";
        error_msg +=
          "<div>" +
          LANG.web_line("Buy_Text_limit_sale_zero_error_clear") +
          "</div>";
        break;
    }
    return error_msg;
  }
  function _special_sale(items, qty) {
    if (
      typeof items["pre"] !== "undefined" &&
      typeof items["limit"] !== "undefined"
    ) {
      var zero_error = parseInt(items["zero_error"], 10);
      var pre = parseInt(items["pre"], 10);
      var limit = parseInt(items["limit"], 10);
      var status = parseInt(items["status"], 10);
      var show_type = "";
      var check = true;
      if (status === true) {
        if (limit === 1 || (pre === 1 && limit === 1)) {
          var limit_typ = _process_limit_type(items, qty);
          show_type = limit_typ.type;
          check = limit_typ.check;
        }
      } else {
        if (zero_error === 1) {
          check = false;
        } else {
          if (limit === 1 || (pre === 1 && limit === 1)) {
            var limit_typ = _process_limit_type(items, qty);
            show_type = limit_typ.type;
            check = limit_typ.check;
          }
        }
      }
      var is_show_dialog = false;
      if (check) {
        if (limit === 1 && show_type !== "") {
          is_show_dialog = true;
        }
      } else {
        if (pre === 1 || limit === 1) {
          if (zero_error === 1) {
            show_type = _error_dialog_data(4, items);
          }
          is_show_dialog = true;
        }
      }
      if (is_show_dialog) {
        var content_dialog =
          '<div id="dialog_limit_onsale" title="" style="display:none;" class="ui-dialog-buttonpane ui-widget-content ui-helper-clearfix"><div></div></div>';
        $("body").append(content_dialog);
        $("#dialog_limit_onsale").dialog({
          autoOpen: false,
          width: 500,
          modal: true
        });
        show_type +=
          '<div onclick="close_limit_onsale()" class="submit">' +
          LANG.web_line("Buy_Text_close_window") +
          "</div>";
        $("#dialog_limit_onsale div").html(show_type);
        $("#dialog_limit_onsale").dialog("open");
      }
    }
    return true;
  }
  this.init();
};
var shopcart = new Shopcart();
(function($) {
  $.path = {};
  var V = {
    rotate: function(p, degrees) {
      var radians = (degrees * Math.PI) / 180,
        c = Math.cos(radians),
        s = Math.sin(radians);
      return [c * p[0] - s * p[1], s * p[0] + c * p[1]];
    },
    scale: function(p, n) {
      return [n * p[0], n * p[1]];
    },
    add: function(a, b) {
      return [a[0] + b[0], a[1] + b[1]];
    },
    minus: function(a, b) {
      return [a[0] - b[0], a[1] - b[1]];
    }
  };
  $.path.bezier = function(params, rotate) {
    params.start = $.extend({ angle: 0, length: 0.3333 }, params.start);
    params.end = $.extend({ angle: 0, length: 0.3333 }, params.end);
    this.p1 = [params.start.x, params.start.y];
    this.p4 = [params.end.x, params.end.y];
    var v14 = V.minus(this.p4, this.p1),
      v12 = V.scale(v14, params.start.length),
      v41 = V.scale(v14, -1),
      v43 = V.scale(v41, params.end.length);
    v12 = V.rotate(v12, params.start.angle);
    this.p2 = V.add(this.p1, v12);
    v43 = V.rotate(v43, params.end.angle);
    this.p3 = V.add(this.p4, v43);
    this.f1 = function(t) {
      return t * t * t;
    };
    this.f2 = function(t) {
      return 3 * t * t * (1 - t);
    };
    this.f3 = function(t) {
      return 3 * t * (1 - t) * (1 - t);
    };
    this.f4 = function(t) {
      return (1 - t) * (1 - t) * (1 - t);
    };
    this.css = function(p) {
      var f1 = this.f1(p),
        f2 = this.f2(p),
        f3 = this.f3(p),
        f4 = this.f4(p),
        css = {};
      if (rotate) {
        css.prevX = this.x;
        css.prevY = this.y;
      }
      css.x = this.x =
        (this.p1[0] * f1 +
          this.p2[0] * f2 +
          this.p3[0] * f3 +
          this.p4[0] * f4 +
          0.5) |
        0;
      css.y = this.y =
        (this.p1[1] * f1 +
          this.p2[1] * f2 +
          this.p3[1] * f3 +
          this.p4[1] * f4 +
          0.5) |
        0;
      css.left = css.x + "px";
      css.top = css.y + "px";
      return css;
    };
  };
  $.path.arc = function(params, rotate) {
    for (var i in params) {
      this[i] = params[i];
    }
    this.dir = this.dir || 1;
    while (this.start > this.end && this.dir > 0) {
      this.start -= 360;
    }
    while (this.start < this.end && this.dir < 0) {
      this.start += 360;
    }
    this.css = function(p) {
      var a = ((this.start * p + this.end * (1 - p)) * Math.PI) / 180,
        css = {};
      if (rotate) {
        css.prevX = this.x;
        css.prevY = this.y;
      }
      css.x = this.x = (Math.sin(a) * this.radius + this.center[0] + 0.5) | 0;
      css.y = this.y = (Math.cos(a) * this.radius + this.center[1] + 0.5) | 0;
      css.left = css.x + "px";
      css.top = css.y + "px";
      return css;
    };
  };
  $.fx.step.path = function(fx) {
    var css = fx.end.css(1 - fx.pos);
    if (css.prevX != null) {
      $.cssHooks.transform.set(
        fx.elem,
        "rotate(" + Math.atan2(css.prevY - css.y, css.prevX - css.x) + ")"
      );
    }
    fx.elem.style.top = css.top;
    fx.elem.style.left = css.left;
  };
})(jQuery);
var mediaWidth = $(window).width();
var event_type = "";
$(window).resize(function() {
  if (mediaWidth != $(window).width()) {
    mediaWidth = $(window).width();
    chg_menu();
  }
});
$(function() {
  $(window).on("focus", function() {
    cart.cookie_refresh();
    shopCart();
  });
  sideMenu();
  shopCart();
  goTop();
  bind_topMenu();
  $("div.cart-btn > a.icon-cart")
    .attr("href", "javascript:void(0)")
    .on("click", function() {
      if (typeof ga !== "undefined") {
        ga(
          "send",
          "event",
          $(this).attr("ga_class"),
          "clicked",
          $(this).attr("ga_event_label")
        );
      }
    });
  $("nav.nav-menu-mobile a.icon-cart")
    .attr("href", "javascript:void(0)")
    .on("click", function() {
      if (typeof ga !== "undefined") {
        ga(
          "send",
          "event",
          $(this).attr("ga_class"),
          "clicked",
          $(this).attr("ga_event_label")
        );
      }
      if (
        typeof SSO_CERTIFICATION !== "undefined" &&
        SSO_CERTIFICATION === "2"
      ) {
        cart.sso_status = true;
      }
      shopcart_send_ga("check out btn");
    });
  $("#accounthome_link").hover(
    function() {
      $(".myaccount_detail").append(add_myaccount());
      var mycart_width = $("#mycart").outerWidth();
      var myaccount_padding = $("#myaccount_word")
        .css("padding-right")
        .replace("px", "");
      var myaccount_left =
        parseInt(mycart_width, 10) + parseInt(myaccount_padding, 10);
      $("#myaccount").css("right", myaccount_left);
    },
    function() {
      $(".myaccount_detail")
        .find(".myaccount")
        .remove();
    }
  );
});
function add_myaccount() {
  var modify_pwd_url = MEMBER_DOMAIN + "account/modifyPwd";
  var unsubscribe_url = MEMBER_DOMAIN + "subscribe/index";
  var target = "";
  if (typeof "SSO_CERTIFICATION" !== "undefined" && SSO_CERTIFICATION === "2") {
    if (typeof "SSO_CHGPWD_DOMAIN" !== "undefined") {
      modify_pwd_url = SSO_CHGPWD_DOMAIN;
    }
    if (typeof "SSO_SUBSCRIBE_DOMAIN" !== "undefined") {
      unsubscribe_url = SSO_SUBSCRIBE_DOMAIN;
    }
    target = " target='_blank'";
  }
  var lang = "";
  if (typeof "lang_code" !== "undefined" && lang_code !== "") {
    var lang = "?lang=" + lang_code;
  }
  var changePassowrd =
    "<div>" +
    "<a class='slaves'" +
    target +
    " href='" +
    modify_pwd_url +
    lang +
    "'>" +
    LANG.web_line("lang_change_password") +
    "</a>" +
    "</div>";
  var unsubscribe =
    "<div>" +
    "<a class='slaves'" +
    target +
    " href='" +
    unsubscribe_url +
    lang +
    "'>" +
    LANG.web_line("lang_subscribe_unsubscribe") +
    "</a>" +
    "</div>";
  var flow_cart = "";
  if (ws_seq == "BW000169") {
    var flow_cart =
      "<div id='myaccount' class='myaccount'>" +
      "<div>" +
      "<a class='main' href='" +
      MEMBER_DOMAIN +
      "morder/orderList'>" +
      LANG.web_line("lang_view_order") +
      "</a>" +
      "</div>" +
      "<div>" +
      "<a class='main' href='https:" +
      www_url +
      "item_track'>" +
      LANG.web_line("lang_wish_list") +
      "</a>" +
      "</div>" +
      "<div>" +
      "<a class='main' href='" +
      MEMBER_DOMAIN +
      "account/home'>" +
      LANG.web_line("lang_account_settings") +
      "</a>" +
      "</div>" +
      changePassowrd +
      "<div>" +
      "<a class='slaves' href='" +
      MEMBER_DOMAIN +
      "address_book/lists'>" +
      LANG.web_line("lang_address_book") +
      "</a>" +
      "</div>" +
      unsubscribe +
      "</div>";
  } else {
    var bmanual_url;
    if (www_url.match("local") || www_url.match("dev")) {
      bmanual_url = MEMBER_DOMAIN + "bonus/bmanual";
    } else {
      bmanual_url = www_url + LANG.web_line("bonus_bmanual_url");
    }
    var flow_cart =
      "<div id='myaccount' class='myaccount'>" +
      "<div>" +
      "<a class='main' href='" +
      MEMBER_DOMAIN +
      "morder/orderList'>" +
      LANG.web_line("lang_view_order") +
      "</a>" +
      "</div>" +
      "<div>" +
      "<a class='main' href='https:" +
      www_url +
      "item_track'>" +
      LANG.web_line("lang_wish_list") +
      "</a>" +
      "</div>" +
      "<div>" +
      "<a class='main' href='" +
      MEMBER_DOMAIN +
      "account/home'>" +
      LANG.web_line("lang_shopping_points") +
      "</a>" +
      "</div>" +
      "<div>" +
      "<a class='slaves' href='" +
      MEMBER_DOMAIN +
      "bonus/blist'>" +
      LANG.web_line("lang_check_shopping_points") +
      "</a>" +
      "</div>" +
      "<div>" +
      "<a class='slaves' href='" +
      MEMBER_DOMAIN +
      "bonus/bonus_return'>" +
      LANG.web_line("lang_redeem_points") +
      "</a>" +
      "</div>" +
      "<div>" +
      "<a class='slaves' href='" +
      bmanual_url +
      "'>" +
      LANG.web_line("lang_shopping_points_policy") +
      "</a>" +
      "</div>" +
      "<div>" +
      "<a class='main' href='" +
      MEMBER_DOMAIN +
      "account/home'>" +
      LANG.web_line("lang_account_settings") +
      "</a>" +
      "</div>" +
      changePassowrd +
      "<div>" +
      "<a class='slaves' href='" +
      MEMBER_DOMAIN +
      "address_book/lists'>" +
      LANG.web_line("lang_address_book") +
      "</a>" +
      "</div>" +
      unsubscribe +
      "</div>";
  }
  return $(flow_cart);
}
function chg_menu() {
  $(".menu-two").addClass("hide");
  $(".menu-three").addClass("hide");
  if (mediaWidth >= 1000) {
    $(".menu-one").removeClass("hide");
    $(".site-search").removeClass("hide");
    $(".nav-user").removeClass("hide");
    event_type = "mouseenter";
  } else if (mediaWidth <= 999) {
    $(".menu-one").addClass("hide");
    if (chg_menu.is_init) {
      chg_menu.is_init = false;
      $(".site-search").addClass("hide");
    }
    $(".nav-user").addClass("hide");
    event_type = "click";
  }
}
chg_menu.is_init = true;
function bind_topMenu() {
  chg_menu();
  var menuOne = $(".menu-one"),
    menuOneLi = menuOne.find("li"),
    menuTwo = menuOne.find(".menu-two"),
    mobileNav = $(".nav-menu-mobile"),
    mobileMenu = $(".icon-menu"),
    mobileSearch = $(".icon-search"),
    mobileAccount = mobileNav.find(".icon-account"),
    siteSearch = $(".site-search"),
    mobileUesr = $(".nav-user");
  $("section.site-body").css("margin-top", "1px");
  mobileMenu.on("click", function() {
    $(".site-search").addClass("hide");
    $(".nav-user").addClass("hide");
    menuOne.toggleClass("hide");
  });
  mobileSearch.on("click", function() {
    if (mediaWidth <= 999) {
      $(".menu-one").addClass("hide");
      $(".nav-user").addClass("hide");
      siteSearch.toggleClass("hide");
    }
  });
  mobileAccount.on("click", function() {
    $(".menu-one").addClass("hide");
    $(".site-search").addClass("hide");
    mobileUesr.toggleClass("hide");
  });
  $(".menu-one > li")
    .bind("mouseenter click", function(e) {
      $(this)
        .find(" > a")
        .attr("href", "javascript:void(0)");
      if (e.type == "click") {
        hide_menu_ul(0);
        if (event_type == "mouseenter") {
          location.href = $(this)
            .find(" > a")
            .attr("origin_href");
        }
      }
      if (e.type == event_type) {
        if ($(this).find(".menu-two").length > 0) {
          $(this)
            .find(".menu-two")
            .removeClass("hide");
        } else {
          append_menu($(this).attr("id"), 1);
        }
      }
    })
    .bind("mouseleave", function() {
      if (event_type == "mouseenter") {
        $(".menu-one .menu-two").addClass("hide");
        $(".menu_box").remove();
      }
    })
    .bind("contextmenu", function() {
      if (event_type == "mouseenter") {
        var url = $(this)
          .find(" > a")
          .attr("origin_href");
        $(this)
          .find(" > a")
          .attr("href", url);
      }
    });
}
function append_menu(sid, level) {
  var api_url = www_url + "get_menu";
  var menu_lest = "";
  if ($("#" + sid).find("> ul").length > 0) {
    $("#" + sid).removeClass("hide");
  } else {
    $.ajax({
      url: api_url,
      type: "post",
      dataType: "jsonp",
      jsonp: "callback",
      data: { si_seq: sid },
      success: function(menu_lest_string) {
        var menu_obj = JSON.parse(JSON.stringify(menu_lest_string));
        append_sub_menu(sid, menu_obj, level);
        if (menu_obj.length <= 0) {
          $("#" + sid + " > a").attr({
            href: $("#" + sid + " > a").attr("origin_href")
          });
          if (event_type == "click") {
            location.href = $("#" + sid + " > a").attr("origin_href");
          }
        }
      },
      error: function() {
        return false;
      }
    });
  }
  var append_sub_menu = function(sid, menu_obj, level) {
    var sub_menu = "";
    var class_name = get_class_name(level);
    if (menu_obj.length <= 0) {
      sub_menu +=
        '<ul class="' + class_name + ' icon-sub-arrow" style="display:none">';
      sub_menu += "</ul>";
      $("." + class_name).addClass("hide");
      $("#" + sid).append($(sub_menu));
    } else {
      sub_menu += '<ul class="' + class_name + '">';
      $.each(menu_obj, function(sid, row) {
        sub_menu +=
          "<li id=" +
          row.sid +
          '><a href="javascript:void(0)" origin_href="' +
          row.link +
          '">' +
          row.name +
          "</a></li>";
      });
      sub_menu += "</ul>";
      $("." + class_name).addClass("hide");
      $("#" + sid).append($(sub_menu));
      var hover_div = $("<div></div>").addClass("menu_box");
      $("#" + sid + " ul." + class_name + " > li")
        .bind("mouseenter click", function(e) {
          if (level == 2) {
            hover_div.css({
              height: $("#" + sid + " ul." + class_name).height() + 100 + "px",
              width: $("#" + sid + " ul." + class_name).width() + "px",
              left:
                $("#" + sid + " ul." + class_name)
                  .parent()
                  .width() + "px"
            });
            $(".menu_box").remove();
            $("#" + sid).append(hover_div);
          } else if (level == 3) {
            hover_div.css({
              height:
                $("#" + sid)
                  .parent()
                  .height() +
                100 +
                "px",
              width:
                $("#" + sid)
                  .parent()
                  .width() + "px",
              left:
                $("#" + sid)
                  .parent()
                  .parent()
                  .width() + "px"
            });
            $(".menu_box").remove();
            hover_div.appendTo(
              $("#" + sid)
                .parent()
                .parent()
            );
          } else {
            $(".menu_box").remove();
          }
          e.stopPropagation();
          if (e.type == "click") {
            hide_menu_ul(level);
            if (event_type == "mouseenter") {
              location.href = $(this)
                .find("> a")
                .attr("origin_href");
            }
          }
          if (e.type == event_type) {
            if ($(this).find("> ul").length > 0) {
              $(this)
                .find("> ul")
                .removeClass("hide");
            } else {
              append_menu($(this).attr("id"), level + 1, event_type);
            }
          }
        })
        .bind("mouseleave", function() {
          if (event_type == "mouseenter") {
            $(this)
              .find("ul")
              .addClass("hide");
          }
        });
    }
  };
}
function hide_menu_ul(level) {
  var class_name = get_class_name(level + 1);
  $("ul." + class_name).addClass("hide");
}
function get_class_name(level) {
  var class_name = "";
  switch (level) {
    case 1:
      class_name = "menu-two";
      break;
    case 2:
      class_name = "menu-three";
      break;
    case 3:
      class_name = "menu-four";
      break;
    default:
      class_name = "menu-end";
  }
  return class_name;
}
var refresh_float_shopcart_status = false;
function draw_shopcart() {
  var menuCart = $(".cart-btn");
  var menuCartItem = $(".site-cart");
  var envent_count = 0;
  if (cart.get_login_status() === true) {
    $("#signup_link").hide();
    $("#login_link").hide();
    $("#logout_link").show();
  } else {
    $("#signup_link").show();
    $("#login_link").show();
    $("#logout_link").hide();
  }
  $("#nav-user").css("visibility", "visible");
  draw_float_cart_pcs();
  draw_float_cart_list();
  menuCart.on("mouseenter", function(e) {
    if (envent_count < 1) {
      if (cart_update_click == true) {
        menuCartItem.removeClass("hide");
      } else {
        menuCartItem.html("");
        if (
          cart.response_data_obj === null &&
          refresh_float_shopcart_status === false
        ) {
          refresh_float_shopcart_status = true;
          cart.refresh_float_shopcart(function() {
            draw_float_cart_list();
            menuCartItem.removeClass("hide");
            refresh_float_shopcart_status = false;
          });
        } else {
          draw_float_cart_list();
          menuCartItem.removeClass("hide");
        }
      }
    }
    envent_count = envent_count + 1;
  });
  menuCart.on("mouseleave", function(e) {
    envent_count = 0;
    menuCartItem.addClass("hide");
  });
}
function draw_float_cart_pcs() {
  $("div.cart-btn")
    .find("span.count")
    .text(cart.cart_data_obj.count);
  $(".nav-menu-mobile")
    .find("span.count")
    .text(cart.cart_data_obj.count);
}
function draw_float_cart_list() {
  var have_items = cart.cart_data_obj.count > 0 ? true : false;
  var menuCartItem = $(".site-cart");
  var cart_list = "";
  if (have_items && cart.response_data_obj !== null) {
    cart_list += shoping_cart_build(cart.response_data_obj);
  } else {
    cart_list += empty_cart_list();
    $.removeCookie("as_seq", { path: "/", domain: "asus.com" });
    $.removeCookie("as_seq_checked", { path: "/", domain: "asus.com" });
  }
  menuCartItem.html(cart_list);
  bind_shopcart_event();
}
function shopCart() {
  if (cart.response_data_obj === null) {
    cart.get_session(function() {
      draw_shopcart();
    });
  } else {
    draw_shopcart();
  }
}
function sideMenu() {
  var width = $(window).width(),
    menu = $(".main-menu"),
    menuli = menu.find("li");
  if (width <= WINDOW_WIDTH) {
    $(".main-menu .sec-nav:not(:first)").hide();
    menuli.on("click", function() {
      $(this)
        .find(".sec-nav")
        .slideToggle()
        .siblings()
        .find(".arrow-right")
        .removeClass("icon-arrow-right")
        .addClass("icon-arrow-down");
      $(this)
        .siblings()
        .find(".sec-nav:visible")
        .slideUp("500")
        .siblings()
        .find(".arrow-right")
        .removeClass("icon-arrow-down")
        .addClass("icon-arrow-right");
    });
  }
}
function goTop() {
  var node = {};
  node.root = $("#goTop");
  var $window = $(window);
  node.windowTop = $window.height();
  node.root.hide();
  $window.on("scroll", function() {
    node.docHeight = $(document).scrollTop();
    if (node.docHeight >= node.windowTop) {
      node.root.slideDown();
    } else if (node.docHeight < node.windowTop) {
      node.root.slideUp();
    }
  });
  $("#goTop").on("click", function() {
    $("html, body").animate({ scrollTop: 0 }, 500);
  });
}
var _promotion_view_promotions = [];
var _push_promotion_view_promotions = function(id, name, position) {
  _promotion_view_promotions.push({ id: id, name: name, position: position });
};
var promotion_view_json_datalayer = function() {
  window.dataLayer = window.dataLayer || [];
  window.dataLayer.push({
    event: "promotionView",
    ecommerce: { promoView: { promotions: _promotion_view_promotions } }
  });
};
var _product_impression = [];
var _push_product_impression = function(
  name,
  id,
  price,
  variant,
  position,
  list
) {
  list = list || "Product List";
  _product_impression.push({
    name: name,
    id: id,
    price: ga_price_format(price),
    brand: "ASUS",
    category: GA_CATEGORY,
    variant: variant,
    list: list,
    position: position
  });
};
var product_impression_json_datalayer = function() {
  window.dataLayer = window.dataLayer || [];
  window.dataLayer.push({
    event: "productImpression",
    ecommerce: { currencyCode: CS_CODE, impressions: _product_impression }
  });
};
var product_index_set_data = function(prod) {
  $(".container").each(function(i, e) {
    if ($(e).find("figure > a").length > 0) {
      $(e)
        .find("figure > a")
        .each(function(si, se) {
          var product_url = $(this).attr("href"),
            product_url_arr = "",
            product_url_id_arr = "",
            product_name = product_url_arr[1];
          if (typeof product_url != "undefined") {
            product_url_arr = product_url.split("/-");
          }
          if (typeof product_url_arr[0] != "undefined") {
            product_url_id_arr = product_url_arr[0].split("/");
          }
          var product_id = product_url_id_arr[product_url_id_arr.length - 1];
          if (product_id == prod["id"]) {
            $(se)
              .find("img")
              .attr("data-id", prod["id"])
              .attr("data-price", prod["price"])
              .attr("data-color", prod["data-variant"]);
            $(se)
              .find("img")
              .attr("data-brand", prod["brand"])
              .attr("data-position", prod["position"])
              .attr("data-list", prod["list"]);
          }
        });
    }
  });
};
var ga_price_format = function(price) {
  if (typeof GA_COUNTRY != "undefined" && GA_COUNTRY == "IT") {
    return price.replace(/\s+/g, "").replace(/\,+/g, ".");
  } else {
    return price.replace(/[^0-9\.-]+/g, "");
  }
};
function ga_promo_click(promoObj) {
  window.dataLayer = window.dataLayer || [];
  window.dataLayer.push({
    event: "promotionClick",
    ecommerce: {
      promoClick: {
        promotions: [
          { id: promoObj.id, name: promoObj.name, position: promoObj.position }
        ]
      }
    },
    eventCallback: function() {
      if (typeof promoObj.url != "undefined") {
        document.location = promoObj.url;
      }
    }
  });
}
function ga_product_click(productObj) {
  var variant = productObj.color || "";
  window.dataLayer = window.dataLayer || [];
  window.dataLayer.push({
    event: "productClick",
    ecommerce: {
      click: {
        actionField: { list: productObj.list },
        products: [
          {
            name: productObj.name,
            id: productObj.id,
            price: productObj.price,
            brand: productObj.brand,
            category: productObj.category,
            variant: variant,
            list: productObj.list,
            position: productObj.position
          }
        ]
      }
    },
    eventCallback: function() {
      if (typeof productObj.url != "undefined") {
      }
    }
  });
}
function ga_add_category_event() {
  $(" figure > a").on("click", function() {
    var product_data = {};
    if ($(this).find("div").length > 0) {
      var product_index = $(
        "div.item-list > div.container > div.items > figure > a"
      ).index(this);
      if (product_index < 0) {
        product_index = $(
          "div.item-list-four > div.container > div.items > figure > a"
        ).index(this);
      }
      var product_url = this.href;
      product_data = _product_impression[product_index];
      product_data["url"] = product_url;
    } else {
      var product_img = $(this).find("img");
      product_data["name"] = product_img.attr("alt");
      product_data["id"] = product_img.data("id");
      product_data["price"] = product_img.data("price");
      product_data["brand"] = product_img.data("brand");
      product_data["category"] = GA_CATEGORY;
      product_data["variant"] = product_img.data("variant");
      product_data["list"] = product_img.data("list");
      product_data["position"] = product_img.data("position");
    }
    ga_product_click(product_data);
  });
}
function ga_add_item_event() {
  $(".items figure .photo").on("click", function() {
    ga_product_click(get_product_data($(this).parent(".item")));
  });
  $(".items figure .name > a").on("click", function() {
    ga_product_click(
      get_product_data(
        $(this)
          .parent(".name")
          .parent(".info")
          .parent(".item")
      )
    );
  });
}
function get_product_data(productObj) {
  var product_data = {};
  product_data["brand"] = "ASUS";
  product_data["list"] = "Product List";
  product_data["category"] = GA_CATEGORY;
  product_data["name"] = productObj.find("figcaption .name > a").html();
  product_data["id"] = productObj.find("figcaption .name > a").attr("href");
  if (typeof product_data["id"] != "undefined") {
    product_url_arr = product_data["id"].split("/-");
  }
  if (typeof product_url_arr[0] != "undefined") {
    product_url_id_arr = product_url_arr[0].split("/");
  }
  var product_id = product_url_id_arr[product_url_id_arr.length - 1];
  product_data["id"] = product_id;
  product_data["url"] = productObj.find("figcaption .name > a").attr("href");
  product_data["price"] = ga_price_format(
    productObj.find("figcaption .buy > .price").html()
  );
  product_data["position"] = productObj
    .find(".checkbox > input")
    .attr("id")
    .replace("add-", "");
  if (!isNaN(parseInt(product_data["position"]))) {
    product_data["position"] = parseInt(product_data["position"]) + 1;
  } else {
    product_data["position"] = "0";
  }
  product_data["variant"] = "";
  return product_data;
}
function homepage_product_column(cols, section_rwd_index) {
  if ($(section_rwd_index).length > 0) {
    $(section_rwd_index).each(function() {
      var section_title = $(this)
        .find("h3.title-h3")
        .text();
      for (var i = 0; i < cols; i++) {
        var section_item = $(this).find("figure.item > figcaption.info")[i];
        var position = i + 1;
        homepage_product_item(section_item, position, section_title);
      }
    });
  }
}
function homepage_product_item(section_item, position, section_title) {
  var section_product_name = $(section_item)
    .find("h1.name > a")
    .text();
  if (typeof section_product_name == "undefined") {
    section_product_name = null;
  }
  var section_product_position = position;
  var hero_product_home_section_title = "hero-product-home-" + section_title;
  var section_title_product_name_position =
    section_title + "-" + section_product_name + "-" + section_product_position;
  var section_click_element = $(section_item).find("h1.name > a");
  var section_click_img_element = $(section_item)
    .parent("figure.item")
    .find("a > img");
  var section_click_img_element_one = $(section_item)
    .parent("figure.item-one")
    .find("a > img");
  $(section_click_element).on("click", function() {
    homepage_product_ga(
      hero_product_home_section_title,
      section_title_product_name_position
    );
  });
  $(section_click_img_element).on("click", function() {
    homepage_product_ga(
      hero_product_home_section_title,
      section_title_product_name_position
    );
  });
  $(section_click_img_element_one).on("click", function() {
    homepage_product_ga(
      hero_product_home_section_title,
      section_title_product_name_position
    );
  });
}
function homepage_product_ga(var1, var2) {
  if (typeof ga !== "undefined") {
    if (mediaWidth > 500) {
      ga("send", "event", var1, "clicked", var2);
    } else {
      ga("send", "event", var1, "m-clicked", var2);
    }
  }
}
$(document).ready(function() {
  if (
    $(".site-ad-top").find("img").length > 0 &&
    $(".site-ad-top")
      .find("img")
      .attr("src") != ""
  ) {
    var promotion_view_top_img = $(".site-ad-top").find("img"),
      promotion_view_id = promotion_view_top_img.attr("src");
    if (
      promotion_view_id.indexOf("http://") == -1 &&
      promotion_view_id.indexOf("https://") == -1 &&
      promotion_view_id.indexOf("//") != -1
    ) {
      promotion_view_id = "https:" + promotion_view_id;
    }
    var promotion_view_name = promotion_view_top_img.attr("desc"),
      promotion_view_position = "banner_top",
      promotion_view_url = promotion_view_top_img.parent("a").attr("href");
    if (
      typeof promotion_view_id != "undefined" &&
      typeof promotion_view_name != "undefined" &&
      typeof promotion_view_position != "undefined"
    ) {
      _push_promotion_view_promotions(
        promotion_view_id,
        promotion_view_name,
        promotion_view_position
      );
    }
    var ga_top = {
      id: promotion_view_id,
      name: promotion_view_name,
      position: promotion_view_position,
      url: promotion_view_url
    };
    $(".site-ad-top a").on("click", function() {
      ga_promo_click(ga_top);
    });
  }
  if (typeof ga_data_category_deploy !== "undefined") {
    if (
      typeof ga_data_category_deploy["prod"] !== "undefined" &&
      ga_data_category_deploy["prod"].length > 0
    ) {
      $.each(ga_data_category_deploy["prod"], function(i, e) {
        product_index_set_data(e);
      });
    }
  }
  if (typeof ga_data_index !== "undefined") {
    if (
      typeof ga_data_index["prod"] !== "undefined" &&
      ga_data_index["prod"].length > 0
    ) {
      $.each(ga_data_index["prod"], function(i, e) {
        product_index_set_data(e);
        _push_product_impression(
          e["name"],
          e["id"],
          e["price"],
          e["variant"],
          e["position"],
          e["list"]
        );
      });
      product_impression_json_datalayer();
    }
    var section_rwd_index = ".rwd-index-002";
    homepage_product_column(2, section_rwd_index);
    var section_rwd_index = ".rwd_index_004";
    homepage_product_column(4, section_rwd_index);
    var section_rwd_index = ".rwd_index_006";
    homepage_product_column(5, section_rwd_index);
    var section_rwd_index = ".rwd_index_005";
    if ($(section_rwd_index).length > 0) {
      $(section_rwd_index).each(function() {
        var section_title = $(this)
          .find("h3.title-h3")
          .text();
        var section_item = $(this).find("figure.item-one > figcaption.info")[0];
        var position = 1;
        homepage_product_item(section_item, position, section_title);
        var section_item = $(this).find("figure.item > figcaption.info")[0];
        var position = 2;
        homepage_product_item(section_item, position, section_title);
        var section_item = $(this).find("figure.item > figcaption.info")[1];
        var position = 4;
        homepage_product_item(section_item, position, section_title);
        var section_item = $(this).find("figure.item > figcaption.info")[2];
        var position = 3;
        homepage_product_item(section_item, position, section_title);
        var section_item = $(this).find("figure.item > figcaption.info")[3];
        var position = 5;
        homepage_product_item(section_item, position, section_title);
      });
    }
    $("figure.item")
      .find("a")
      .on("click", function() {
        var product_img = $(this).find("img"),
          product_data = {};
        product_data["name"] = product_img.attr("alt");
        product_data["id"] = product_img.data("id");
        product_data["price"] = product_img.data("price");
        product_data["brand"] = product_img.data("brand");
        product_data["variant"] = product_img.data("color");
        product_data["category"] = GA_CATEGORY;
        product_data["variant"] = product_img.data("variant");
        product_data["list"] = product_img.data("list");
        product_data["position"] = product_img.data("position");
        product_data["url"] = $(this).attr("href");
        ga_product_click(product_data);
      });
  }
  $(".swiper-container").each(function(i, e) {
    var swiper_count = i + 1;
    var swiper_indexs = [];
    if ($(this).find(".swiper-slide").length > 0) {
      $(this)
        .find(".swiper-slide")
        .each(function(si, se) {
          var swiper_ad = $(se),
            swiper_index = swiper_ad.attr("data-swiper-slide-index"),
            ad_conut = si,
            ad_img = swiper_ad.find("img"),
            ad_img_desc = ad_img.attr("alt") || "",
            ad_link = ad_img.attr("src"),
            ad_url = ad_img.parent("a").attr("href") || "",
            ad_tag = "banner_ad_" + swiper_count + "_" + ad_conut;
          if (
            typeof ad_link != "undefined" &&
            ad_link.indexOf("http://") == -1 &&
            ad_link.indexOf("https://") == -1 &&
            ad_link.indexOf("//") != -1
          ) {
            ad_link = "https:" + ad_link;
          }
          ad_img.parent("a").attr("href", ad_url);
          ad_img.attr("data-alt", ad_img_desc);
          ad_img.attr("data-href", ad_url);
          ad_img.attr("data-index", ad_conut);
          ad_img.attr("data-tag", ad_tag);
          if ($.inArray(swiper_index, swiper_indexs) == -1) {
            swiper_indexs.push(swiper_index);
            if (
              typeof ad_link != "undefined" &&
              typeof ad_img_desc != "undefined" &&
              typeof ad_conut != "undefined"
            ) {
              _push_promotion_view_promotions(ad_link, ad_img_desc, ad_tag);
            }
          }
        });
    }
    if (
      $(this)
        .parent()
        .parent()
        .find(".col-right img").length > 0
    ) {
      var swiper_right_indexs = [];
      $(this)
        .parent()
        .parent()
        .find(".col-right img")
        .each(function(si, se) {
          var ad_right_img = $(se),
            swiper_right_index = swiper_indexs.length + si,
            ad_right_img_desc = ad_right_img.attr("alt") || "",
            ad_right_link = ad_right_img.attr("src") || "",
            ad_right_url = ad_right_img.parent().attr("href"),
            ad_right_index_tag =
              "banner_ad_" + swiper_count + "_" + swiper_right_index;
          if (
            typeof ad_right_url != "undefined" &&
            ad_right_url.indexOf("http://") == -1 &&
            ad_right_url.indexOf("https://") == -1 &&
            ad_right_url.indexOf("//") != -1
          ) {
            ad_right_url = "https:" + ad_right_url;
          }
          ad_right_img.parent("a").attr("href", ad_right_url);
          ad_right_img.attr("data-alt", ad_right_img_desc);
          ad_right_img.attr("data-href", ad_right_url);
          ad_right_img.attr("data-index", swiper_right_index);
          ad_right_img.attr("data-tag", ad_right_index_tag);
          if ($.inArray(swiper_right_indexs, swiper_right_index) == -1) {
            swiper_right_indexs.push(swiper_right_index);
            if (
              typeof ad_right_link != "undefined" &&
              typeof ad_right_img_desc != "undefined" &&
              typeof swiper_right_index != "undefined"
            ) {
              _push_promotion_view_promotions(
                ad_right_link,
                ad_right_img_desc,
                ad_right_index_tag
              );
            }
          }
        });
    }
  });
  if (_promotion_view_promotions.length > 0) {
    promotion_view_json_datalayer();
  }
  $(".swiper-slide > a").on("click", function() {
    var ad_name = "";
    if ($(this).parents(".col-left").length > 0) {
      ad_name = "AD Roller";
    }
    var ad_img = $(this).find("img"),
      position = ad_img.data("tag"),
      ad_img_desc = ad_img.attr("alt") || ad_name,
      ad_img_src = ad_img.attr("src"),
      ad_url = $(this).attr("href");
    if (
      ad_img_src.indexOf("http://") == -1 &&
      ad_img_src.indexOf("https://") == -1 &&
      ad_img_src.indexOf("//") != -1
    ) {
      ad_img_src = "https:" + ad_img_src;
    }
    var desc = ad_img_desc + "-" + ad_url;
    if (typeof ga !== "undefined") {
      if (mediaWidth > 500) {
        ga("send", "event", position, "clicked", desc);
      } else {
        ga("send", "event", position, "m-clicked", desc);
      }
    }
    var datalayer_data = {
      id: ad_img_src,
      name: ad_img_desc,
      position: position,
      url: ad_url
    };
    ga_promo_click(datalayer_data);
  });
  $(".container .col-right > a").on("click", function() {
    var ad_img = $(this).find("img"),
      position = ad_img.data("tag"),
      ad_img_desc = ad_img.attr("alt") || "AD Roller",
      ad_img_src = ad_img.attr("src"),
      ad_url = $(this).attr("href");
    if (
      ad_img_src.indexOf("http://") == -1 &&
      ad_img_src.indexOf("https://") == -1 &&
      ad_img_src.indexOf("//") != -1
    ) {
      ad_img_src = "https:" + ad_img_src;
    }
    var desc = ad_img_desc + "-" + ad_url;
    if (typeof ga !== "undefined") {
      if (mediaWidth > 500) {
        ga("send", "event", position, "clicked", desc);
      } else {
        ga("send", "event", position, "m-clicked", desc);
      }
    }
    var datalayer_data = {
      id: ad_img_src,
      name: ad_img_desc,
      position: position,
      url: ad_url
    };
    ga_promo_click(datalayer_data);
  });
  if (
    typeof ga_data_category !== "undefined" &&
    ga_data_category["prod"].length > 0
  ) {
    var dl_category = [];
    var dl_currency = CS_CODE;
    for (var i in ga_data_category["prod"]) {
      dl_category.push({
        name: ga_data_category["prod"][i]["name"],
        id: ga_data_category["prod"][i]["id"],
        price: ga_data_category["prod"][i]["price"],
        brand: ga_data_category["prod"][i]["brand"],
        category: ga_data_category["prod"][i]["category"],
        variant: ga_data_category["prod"][i]["variant"],
        list: ga_data_category["prod"][i]["list"],
        position: ga_data_category["prod"][i]["position"]
      });
    }
    window.dataLayer = window.dataLayer || [];
    window.dataLayer.push({
      event: "productImpression",
      ecommerce: { currencyCode: dl_currency, impressions: dl_category }
    });
  }
  if (typeof ga_data_product !== "undefined") {
    window.dataLayer = window.dataLayer || [];
    window.dataLayer.push({
      event: "productDetailView",
      ecommerce: {
        detail: {
          actionField: { list: "Product Detail" },
          products: [
            {
              name: ga_data_product["prod"]["name"],
              id: ga_data_product["prod"]["id"],
              price: ga_data_product["prod"]["price"],
              brand: ga_data_product["prod"]["brand"],
              category: ga_data_product["prod"]["category"],
              variant: ga_data_product["prod"]["variant"]
            }
          ]
        }
      }
    });
    if (ga_data_product["add"].length > 0) {
      var prod_adds = {};
      for (var i = 0; i < ga_data_product["add"].length; i++) {
        prod_adds[i] = {
          name: ga_data_product["add"][i]["name"],
          id: ga_data_product["add"][i]["id"],
          price: ga_data_product["add"][i]["price"],
          brand: ga_data_product["add"][i]["brand"],
          category: ga_data_product["add"][i]["category"],
          variant: ga_data_product["add"][i]["variant"],
          list: ga_data_product["add"][i]["list"],
          position: ga_data_product["add"][i]["position"]
        };
      }
      window.dataLayer = window.dataLayer || [];
      window.dataLayer.push({
        event: "productImpression",
        ecommerce: { currencyCode: CS_CODE, impressions: prod_adds }
      });
    }
  }
  if (GA_PAGE == "item") {
    ga_add_item_event();
  }
});
Number.prototype.formatMoney = function(n, x) {
  var re = "\\d(?=(\\d{" + (x || 3) + "})+" + (n > 0 ? "\\." : "$") + ")";
  return this.toFixed(Math.max(0, ~~n)).replace(new RegExp(re, "g"), "$&,");
};
Number.prototype.formatToFixed = function(n, x) {
  var re = "\\d(?=(\\d{" + (x || 3) + "})+" + (n > 0 ? "\\." : "$") + ")";
  return this.toFixed(Math.max(0, ~~n));
};
var currency_format = null;
if (currency_format === null) {
  get_currency_format(function(data) {
    currency_format = data;
  });
}
function pointf(p_number) {
  var regex, price, decimal_notation, comma_style;
  if (currency_format === null) {
    get_currency_format(function(currency_format) {
      decimal_notation = currency_format.dec_point;
      comma_style = currency_format.thousands_sep;
    });
  } else {
    decimal_notation = currency_format.dec_point;
    comma_style = currency_format.thousands_sep;
  }
  if (typeof p_number === "number" || typeof p_number === "string") {
    p_number = this.trim(p_number);
    if (p_number === "") {
      return "";
    }
    regex = new RegExp("\\" + comma_style, "g");
    price = p_number.toString().replace(regex, "");
    return parseFloat(price.toString().replace(decimal_notation, "."));
  } else {
    console.log("pointf pointf wrong type");
  }
}
function countryf(p_number) {
  var regex, decimal_notation, comma_style;
  if (currency_format === null) {
    get_currency_format(function(currency_format) {
      decimal_notation = currency_format.dec_point;
      comma_style = currency_format.thousands_sep;
    });
  } else {
    decimal_notation = currency_format.dec_point;
    comma_style = currency_format.thousands_sep;
  }
  p_number = this.trim(p_number);
  if (typeof p_number === "string" && p_number === "") {
    return "";
  }
  var check_format_regex = new RegExp("^-?[0-9]*(\\.[0-9]*)?$");
  if (check_format_regex.test(p_number) === false) {
    console.log("countryf check_format_regex is not accepted" + p_number);
    return p_number;
  }
  return this.set_comma(
    p_number.toString().replace(".", decimal_notation),
    comma_style
  );
}
this.trim = function(str) {
  var regex;
  if (typeof str === "string") {
    regex = new RegExp("^s+|s+$", "gm");
    return str.replace(regex, "");
  }
  return str;
};
this.set_comma = function(number, comma_style) {
  var p_number = number.toString();
  var pattern = /(^\d+)(\d{3})/;
  while (pattern.test(p_number)) {
    p_number = p_number.replace(pattern, "$1" + comma_style + "$2");
  }
  return p_number;
};
function get_currency_format(callback) {
  var shop_domains = SHOP_DOMAIN;
  var url_get_currency_format = shop_domains + "cart_api/get_currency_format";
  $.ajax({
    url: url_get_currency_format,
    type: "get",
    async: false,
    dataType: "jsonp",
    jsonp: "callback",
    success: function(data) {
      callback(data);
    },
    error: function(e) {
      console.log("error:" + JSON.stringify(e));
    }
  });
}
function digitLength(num) {
  const eSplit = num.toString().split(/[eE]/);
  const len = (eSplit[0].split(".")[1] || "").length - +(eSplit[1] || 0);
  return len > 0 ? len : 0;
}
function float2Fixed(num) {
  if (num.toString().indexOf("e") === -1) {
    return Number(num.toString().replace(".", ""));
  }
  const dLen = digitLength(num);
  return dLen > 0 ? num * Math.pow(10, dLen) : num;
}
function checkBoundary(num) {
  if (num > Number.MAX_SAFE_INTEGER || num < Number.MIN_SAFE_INTEGER) {
  }
}
function num_times(num1, num2) {
  const num1Changed = float2Fixed(num1);
  const num2Changed = float2Fixed(num2);
  const baseNum = digitLength(num1) + digitLength(num2);
  const leftValue = num1Changed * num2Changed;
  return leftValue / Math.pow(10, baseNum);
}
function num_plus(num1, num2) {
  const baseNum = Math.pow(10, Math.max(digitLength(num1), digitLength(num2)));
  return (num_times(num1, baseNum) + num_times(num2, baseNum)) / baseNum;
}
function num_minus(num1, num2) {
  const baseNum = Math.pow(10, Math.max(digitLength(num1), digitLength(num2)));
  return (num_times(num1, baseNum) - num_times(num2, baseNum)) / baseNum;
}
function num_divide(num1, num2) {
  const num1Changed = float2Fixed(num1);
  const num2Changed = float2Fixed(num2);
  return num_times(
    num1Changed / num2Changed,
    Math.pow(10, digitLength(num2) - digitLength(num1))
  );
}
function round(num, ratio) {
  const base = Math.pow(10, ratio);
  return num_divide(Math.round(num_times(num, base)), base);
}
var newWindow = null;
function tab_url() {
  if (newWindow == null || newWindow.closed) {
    newWindow = window.open(
      "https://chat-tw.asus.com/chatservice/index.htm?tenant=STORE",
      "com",
      ""
    );
  } else {
    newWindow.focus();
  }
}
function ga_check_shop_cart_products() {
  if (cart.response_data_obj == null) {
    return false;
  }
  var product_obj = cart.response_data_obj;
  var ga_float_cart;
  if (typeof $.cookie("ga_float_cart") != "undefined") {
    ga_float_cart = JSON.parse($.cookie("ga_float_cart"));
  } else {
    ga_float_cart = {};
  }
  $.each(product_obj[ws_seq], function(index, row) {
    if (
      row.options.kind == 1 ||
      row.options.kind == 3 ||
      row.options.kind == 9
    ) {
      var combine_row = find_all_combine(product_obj, row);
      var indx = 0;
      if (combine_row !== false) {
        var combine_count = 0;
        $.each(combine_row.combine, function(key, value) {
          update_ga_and_save_cookie(combine_row, combine_count, ga_float_cart);
          combine_count++;
        });
      } else {
        update_ga_and_save_cookie(row, indx, ga_float_cart);
      }
    }
  });
}
function find_all_combine(items, row) {
  var flag = false;
  var itemObj = row;
  itemObj.combine = new Array();
  itemObj.combine.push({
    id: row.id,
    name: row.name,
    price: row.price,
    qty: row.qty
  });
  $.each(items[ws_seq], function(key, value) {
    if (value.options.master_id === row.id && value.options.kind == "6") {
      flag = true;
      itemObj.combine.push({
        id: value.id,
        name: value.name,
        price: value.price,
        qty: value.qty
      });
    }
  });
  if (flag === false) {
    return false;
  } else {
    return itemObj;
  }
}
function update_ga_and_save_cookie(row, indx, ga_float_cart) {
  var arr_id = row.id.split("-");
  row.itno = arr_id[1];
  row.sm_seq = arr_id[0];
  if (
    !jQuery.isEmptyObject(ga_float_cart) &&
    !jQuery.isEmptyObject(ga_float_cart[row.sm_seq]) &&
    !jQuery.isEmptyObject(ga_float_cart[row.sm_seq][row.itno]) &&
    !jQuery.isEmptyObject(ga_float_cart[row.sm_seq][row.itno][indx])
  ) {
    if (!jQuery.isEmptyObject(ga_float_cart[row.sm_seq][row.itno][indx].itno)) {
      if (ga_float_cart[row.sm_seq][row.itno][indx].qty != row.qty) {
        remove_product_for_shop_cart(row, indx, ga_float_cart);
      } else {
        return;
      }
    }
  }
  ga_float_cart[row.sm_seq] = {};
  ga_float_cart[row.sm_seq][row.itno] = {};
  ga_float_cart[row.sm_seq][row.itno][indx] = {};
  ga_float_cart[row.sm_seq][row.itno][indx].itno = row.itno;
  ga_float_cart[row.sm_seq][row.itno][indx].qty = row.qty;
  ga("uitoxTracker.ec:addProduct", {
    id: row.itno,
    name: row.name,
    price: String(row.price),
    quantity: String(row.qty)
  });
  ga("uitoxTracker.ec:setAction", "add");
  ga("uitoxTracker.send", "event", "Ecommerce", "cart", "Add");
  ga_float_cart = JSON.stringify(ga_float_cart);
  $.cookie("ga_float_cart", ga_float_cart, { path: "/" });
}
function remove_product_for_shop_cart(row, indx, ga_float_cart) {
  if (!jQuery.isEmptyObject(ga_float_cart[row.sm_seq][row.itno][indx])) {
    ga("uitoxTracker.ec:addProduct", {
      id: ga_float_cart[row.sm_seq][row.itno][indx].itno,
      name: row.name,
      price: String(row.price),
      quantity: String(ga_float_cart[row.sm_seq][row.itno][indx].qty)
    });
    ga("uitoxTracker.ec:setAction", "remove");
    ga("uitoxTracker.send", "event", "Ecommerce", "cart", "Remove");
    delete ga_float_cart[row.sm_seq][row.itno][indx];
  }
}
function remove_product_for_float_shopcart_delete() {
  $.each(itemObj, function(index, row) {
    var arr_id = row.id.split("-");
    row.itno = arr_id[1];
    row.sm_seq = arr_id[0];
    if (typeof $.cookie("ga_float_cart") != "undefined") {
      var ga_float_cart = JSON.parse($.cookie("ga_float_cart"));
      delete ga_float_cart[row.sm_seq][row.itno][row.indx];
      ga_float_cart = JSON.stringify(ga_float_cart);
      $.cookie("ga_float_cart", ga_float_cart, { path: "/" });
    } else {
      ga_check_shop_cart_products();
    }
    ga("uitoxTracker.ec:addProduct", {
      id: row.itno,
      name: row.name,
      price: String(row.price),
      quantity: String(row.qty)
    });
    ga("uitoxTracker.ec:setAction", "remove");
    ga("uitoxTracker.send", "event", "Ecommerce", "cart", "Remove");
  });
  itemObj = {};
}
var itemObj = new Array();
function get_value_for_ga(obj) {
  var rowid = $(obj).attr("rowid");
  itemObj = new Array();
  $("#" + rowid + ":first > div.item").each(function(i) {
    var _this = $(this);
    var type = _this.attr("type");
    var row_id = _this.attr("row_id");
    switch (type) {
      case "combine":
        _this.find("p.combo_item").each(function(j) {
          $combo_item_id = $(this).attr("id");
          itemObj.push({
            id: $(this).attr("id"),
            name: $(this).text(),
            price: $(this).attr("price"),
            qty: $(this).attr("qty"),
            indx: $(this).attr("indx")
          });
        });
        break;
      case "original":
      case "plus":
        itemObj.push({
          id: $(this).attr("row_id"),
          name: $(this)
            .find("div.name")
            .text(),
          price: $(this)
            .find("span.price")
            .text(),
          qty: $(this)
            .find("input.quantity-input")
            .val(),
          indx: 0
        });
        break;
    }
  });
}
