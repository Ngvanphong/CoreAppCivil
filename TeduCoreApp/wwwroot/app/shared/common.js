var shareCommon = function () {
    this.initilizer = function () {
        registerEvents();       
        searchProduct();       
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

    
   
};