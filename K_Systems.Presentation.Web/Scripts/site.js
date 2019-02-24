/// <reference path="jquery-1.10.2.min.js" />

$(function (selector) {

    var elemId;
    var $selectedElem = $('table[data-selected]')


    //selecting table row function
    function SelectRow(e) {
        var $target = $(e.target).closest('tr');
        elemId = $target.attr('data-id');
        if ($target.hasClass('selected')) {
            $target.removeClass('selected');
            $selectedElem.attr('data-selected', "false");
        } else {
            $target.siblings().removeClass('selected');
            $target.addClass('selected');
            $selectedElem.attr('data-selected', "true");
        }
    };

    //generic ajax fn
    function EmployeeAjax(url, data, type, success, fail) {
        $.ajax({
            url: url,
            cache: false,
            data: data,
            type: type,
            success: success,
            fail: fail
        });
    }

    // select row of a table
    $(selector).on("click", 'tbody', SelectRow);


    //context menu show up
    //$(selector).on("contextmenu", 'tbody', function (e) {
    //    e.preventDefault();
    //    SelectRow(e);
    //    //e.stopImmediatePropagation();

    //    console.log(e.target);
    //    //console.log("clientY",e.clientY);
    //    //console.log("pageX",e.pageX);
    //    //console.log("pageY",e.pageY);
    //    //console.log("offsetX",e.offsetX);
    //    //console.log("offsetY", e.offsetY);
    //    //console.log("----------------------");

    //    ////var $target = $(e.target).closest('tr');
    //    ////elemId = $target.attr('data-id');
    //    //$('#contextmenu').hide(100).show(100).css({
    //    //    left: e.pageX   + ' px',
    //    //    top: e.pageY   + ' px'
    //    //});
    //    //console.log($('#contextmenu').position());
    //});

    $.contextMenu({
        selector: '#main tbody',
        callback: function (key, options, e) {
            //var m = "clicked: " + key;
            //window.console && console.log(m) || alert(m);
            //console.log(key);
            //console.log(e.target);
            //console.log(options);
        },
        events: {
            preShow: function (e) {
                //console.log(arguments);
            },
            show: function (e) {
                //console.log(e);
            }
        },
        items: {
            "Update": { name: "Update" },
            "Detail": { name: "Detail" },
            "Delete": { name: "Delete" }

        }
    });

    $('.context-menu-one').on('click', function (e) {
        //console.log('clicked', this);
    })




    //call ajax when delete (at modal showing)
    $('#DeleteModal').on('show.bs.modal', function (e) {
        $.ajax({
            url: "/employees/EmpDetail/" + elemId,
            cache: false,
            success: function (html) {
                $("#DeleteModal .modal-body").append(html);
                $('.addImg').show();
            }
        });
    });

    // confirming delete form inside modal
    $('#confDelete').on('click', function () {
        $.ajax({
            url: "/employees/delete/" + elemId,
            cache: false,
            type: 'post',
            success: function (data) {
                $("#DeleteModal").modal('hide');
            }
        });
    });


    //emplty modal on closing
    $('#DeleteModal').on('hide.bs.modal', function (e) {
        $("#DeleteModal .modal-body").children().remove();
    });


    // ajax on click update , delete , detail
    $('#actions').on('click', '[data-url]', function (e) {
        var $btn = $(e.target);
        if ($selectedElem.attr('data-selected') === 'true') {
            if ($btn.attr('id') === 'delete') {
                $('#DeleteModal').modal();
            } else {
                location.href = $($btn).attr('data-url') + '/' + elemId;
            }

        } else {
            alertify.defaults.glossary.title = "Error";
            alertify.alert("You should Select a row first ...!").show();
        }
    });

}('#main'))







//sorting in table head sleelction order - sortby
//$(selector).on("click", 'tr th span', function () {
//    var $clickedSpan = $(this);
//    //$clickedSpan.removeClass('text-muted');
//    var $order = $('#inputOrder');
//    var $sortBy = $('#inputSortBy');
//    $order.val($clickedSpan.attr('data-order'));
//    $sortBy.val($clickedSpan.parent().attr('data-sortBy'));
//    //$clickedSpan.siblings().addClass('text-muted');

//    EmployeeAjax("/employees/search",
//        {
//            search: $('#search').val(),
//            items: $('#items').val(),
//            sortBy: $('#inputSortBy').val(),
//            order: $('#inputOrder').val()
//        },
//        'get',
//        function (data) {
//            $(selector).empty();
//            $(selector).append($(data));
//        },
//        function (msg) {
//            alert("failed request" + msg);
//        });

//$clickedSpan.parent().siblings().each(function () {
//    $(this).children('span').addClass('text-muted');
//});






// serach ajax employee
//$('#btnSearch').on("click", function () {
//    EmployeeAjax("/employees/search",
//        {
//            search: $('#search').val(),
//            items: $('#items').val(),
//            sortBy: $('#inputSortBy').val(),
//            order: $('#inputOrder').val()
//        },
//        'get',
//        function (data) {
//            $(selector).empty();
//            $('#main').append($(data));
//        },
//        function (msg) {
//            alert("failed request" + msg);
//        });
//});

// ajax from pagination
//$(selector).on("click", '[data-url]', function () {
//    EmployeeAjax($(this).attr('data-url'),
//        undefined,
//        'get',
//            function (data) {
//                $(selector).empty();
//                $(selector).append($(data));
//            },
//            function (msg) {
//                alert("failed request" + msg);
//            });
//});