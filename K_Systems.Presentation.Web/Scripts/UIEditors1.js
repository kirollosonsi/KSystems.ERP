/// <reference path="jquery-1.10.2.min.js" />

$(function () {
    $('[data-date]').datepicker({
        dateFormat: "dd-M-yy",
        changeYear: true,
        changeMonth: true,
        yearRange: "c-100:c+10"
    });

    $('input[data-auto]').each(function () {
        $(this).autocomplete({
            source: $(this).attr('data-auto'),
            select: function (e, ui) {
                var $elem = $(e.target);
                $elem.val(ui.item.label)
                $('#'.concat($elem.attr("data-target"))).val(ui.item.value);
                return false;
            }
        });
    });


}())



