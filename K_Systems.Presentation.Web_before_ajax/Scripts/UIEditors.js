/// <reference path="jquery-1.10.2.min.js" />

$(function () {
    $('[data-date]').datepicker({
        dateFormat: "dd-M-yy",
        changeYear: true,
        changeMonth: true,
        yearRange: "c-100:c+10"
    });

    $('input[data-auto]').autocomplete({
        source: '/hr/TrainingHistories/EmployeeAuto',//$(this).attr('data-auto')
        select: function (e,ui) {
            console.log(ui);
        }
    }
       );
}())



