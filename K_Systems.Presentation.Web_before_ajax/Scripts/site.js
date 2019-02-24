/// <reference path="jquery-1.10.2.min.js" />

$(function (selector) {

    var elemId;
    var $selectedElem = $('table[data-selected]')
    //var $order = $('#inputOrder');
    //var $sortBy = $('#inputSortBy');

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
    $(selector).on("click", 'tbody', function (e) {
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
    });

    //sorting in table head sleelction order - sortby
    $(selector).on("click", 'tr th span', function () {
        var $clickedSpan = $(this);
        //$clickedSpan.removeClass('text-muted');
        var $order = $('#inputOrder');
        var $sortBy = $('#inputSortBy');
        $order.val($clickedSpan.attr('data-order'));
        $sortBy.val($clickedSpan.parent().attr('data-sortBy'));
        //$clickedSpan.siblings().addClass('text-muted');

        EmployeeAjax("/employees/search",
            {
                search: $('#search').val(),
                items: $('#items').val(),
                sortBy: $('#inputSortBy').val(),
                order: $('#inputOrder').val()
            },
            'get',
            function (data) {
                $(selector).empty();
                $(selector).append($(data));
            },
            function (msg) {
                alert("failed request" + msg);
            });

        //$clickedSpan.parent().siblings().each(function () {
        //    $(this).children('span').addClass('text-muted');
        //});


    });

    //context menu show up
    $(selector).on("contextmenu", 'tbody', function (e) {
        e.preventDefault();
        console.log(e);
        var $target = $(e.target).closest('tr');
        elemId = $target.attr('data-id');
        $('#contextmenu').css({
            display: "block",
            left: e.pageX,
            right: e.pageY
        });
    });

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

    // serach ajax employee
    $('#btnSearch').on("click", function () {
        EmployeeAjax("/employees/search",
            {
                search: $('#search').val(),
                items: $('#items').val(),
                sortBy: $('#inputSortBy').val(),
                order: $('#inputOrder').val()
            },
            'get',
            function (data) {
                $(selector).empty();
                $('#main').append($(data));
            },
            function (msg) {
                alert("failed request" + msg);
            });
    });

    // ajax from pagination
    $(selector).on("click", '[data-url]', function () {
        EmployeeAjax($(this).attr('data-url'),
            undefined,
            'get',
                function (data) {
                    $(selector).empty();
                    $(selector).append($(data));
                },
                function (msg) {
                    alert("failed request" + msg);
                });
    });

    //emplty modal on closing
    $('#DeleteModal').on('hide.bs.modal', function (e) {
        $("#DeleteModal .modal-body").children().remove();
    });


    // ajax on click update , delete , detail
    $('#actions').on('click', function (e) {
        var $btn = $(e.target);
        if ($selectedElem.attr('data-selected') === 'true') {
            if ($btn.attr('id') === 'delete') {
                $('#DeleteModal').modal();
            } else {
                location.href = $($btn).attr('data-url') + '/' + elemId;
            }

        } else {
            // todo add Error message for not selectig any row
            //$(this).tooltip("show");
        }
    });

}('#main'))