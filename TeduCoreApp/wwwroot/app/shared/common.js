var shareCommon = function () {
    this.initilizer = function () {
        registerEvents();       
        searchProduct();
        showOpTop();
    };
    function registerEvents() {
     
       
        $('body').on('click', '#btnSearchProduct', function (e) {
            $("#search_mini_form").submit();
        });

        $('body').on('click', '.chosecategory', function (e) {
            $("#categoryid").val($(this).data('categoryid'));
        });


    }


    function searchProduct() {
        $("#search").autocomplete({
            minLength: 0,
            source: function (request, response) {
                $.ajax({
                    url: "/product/search",
                    dataType: "json",
                    type: "GET",
                    data: {
                        term: request.term,
                        categoryid: $("#categoryid").val()
                    },
                    success: function (data) {
                        response(data.data);
                    }
                });
            },
            focus: function (event, ui) {
                $("#search").val(ui.item.label);
                return false;
            },
            select: function (event, ui) {
                $("#search").val(ui.item.label);
                return false;
            }
        })
            .autocomplete("instance")._renderItem = function (ul, item) {
                return $("<li>")
                    .append("<div>" + item.label + "</div>")
                    .appendTo(ul);
            };
    }


   function  showOpTop(options) {
        var defaults = {
            text: '',
            min: 200,
            inDelay: 600,
            outDelay: 400,
            containerID: 'toTop',
            containerHoverID: 'toTopHover',
            scrollSpeed: 1200,
            easingType: 'linear'
        };
        var settings = jQuery.extend(defaults, options);
        var containerIDhash = '#' + settings.containerID;
        var containerHoverIDHash = '#' + settings.containerHoverID;
        jQuery('body').append('<a href="#" id="' + settings.containerID + '">' + settings.text + '</a>');
        jQuery(containerIDhash).hide().on("click", function () {
            jQuery('html, body').animate({
                scrollTop: 0
            }, settings.scrollSpeed, settings.easingType);
            jQuery('#' + settings.containerHoverID, this).stop().animate({
                'opacity': 0
            }, settings.inDelay, settings.easingType);
            return false;
        }).prepend('<span id="' + settings.containerHoverID + '"></span>').hover(function () {
            jQuery(containerHoverIDHash, this).stop().animate({
                'opacity': 1
            }, 600, 'linear');
        }, function () {
            jQuery(containerHoverIDHash, this).stop().animate({
                'opacity': 0
            }, 700, 'linear');
        });
        jQuery(window).scroll(function () {
            var sd = jQuery(window).scrollTop();
            if (typeof document.body.style.maxHeight === "undefined") {
                jQuery(containerIDhash).css({
                    'position': 'absolute',
                    'top': jQuery(window).scrollTop() + jQuery(window).height() - 50
                });
            }
            if (sd > settings.min) jQuery(containerIDhash).fadeIn(settings.inDelay);
            else jQuery(containerIDhash).fadeOut(settings.Outdelay);
        });
    }
    
   
};

