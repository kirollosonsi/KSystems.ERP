/// <reference path="jquery-1.12.4.min.js" />
/// <reference path="jquery.validate.js" />

$(function () {
    var $tableBody = $('#tableBody'),
         $productName = $('#product'),
         $productId = $('#productId'),
         $price = $('#Price'),
         $units = $('#Units'),
        $rowTemplate = $('#template tr').clone(),
             data = { order: {}, OrderDetails: [] };

    //remove the added row in the orderdetail table
    $('#tableBody').on('click', 'button.remove', function () {
        $(this).closest('tr').remove();
    });

    //submit the order to server vi ajax
    $('#submit').on('click', function () {
        $(this).disabled = true;
        data.order.customerID = $('#Customer').attr('data-productID');
        data.order.employeeID = $('#Employee').attr('data-productID');
        debugger;
        $tableBody.children('tr').each(function () {
            data.OrderDetails.push({
                productID: $(this).attr('data-productID'),
                price: $(this).attr('data-price'),
                quantity: $(this).attr('data-units')
            });
        });
        console.log(data);
        $.ajax({
            url: '/sales/orders/Add',
            type: 'post',
            contentType: 'application/json',
            data: JSON.stringify(data),
            success: function () {
                alertify.defaults.glossary.title = "Success";
                alertify.alert("Order Saved Successfully :)").show();
                $(this).disabled = false;
                Clear();
                ClearTable();
            }
        });
        data = { order: {}, OrderDetails: [] };
    });

    // validate  attributes before adding new row to orderdetail table
    checkAttrValues = function (selector, attrName) {
        let attrValue = $(selector).attr(attrName);
        if (attrValue === undefined) {
            return false
        }
        let res = attrValue.match(/^[0-9]{1,}$/);
        return (res === null ? false : true);
    }

    // validate  inputs before adding new row to orderdetail table
    checInputValues = function (selector) {
        let inputValue = $(selector).val();
        if (inputValue === undefined) {
            return false
        }
        let res = inputValue.match(/^[0-9]{0,8}.*[0-9]{1,6}$/);
        return (res === null ? false : true);
    }

    //Clear Input Types
    Clear = function () {
        $productName.val("");
        $price.val("");
        $units.val("");
        $productName.focus();
    }

    //clear table areas
    ClearTable = function () {
        $tableBody.empty();
    }

    //add a row to order detail table
    $('#Add').on('click', function () {
        let res1 = checkAttrValues("#Employee", "data-productid");
        res2 = checkAttrValues("#Customer", "data-productid"),
        res3 = checkAttrValues("#product", "data-productid"),
        res4 = checInputValues("#Units"),
        res5 = checInputValues("#Price");


        if (res1 && res2 && res3 && res4 && res5) {
            var total = Number($price.val()) * Number($units.val());
            var $row = $rowTemplate.clone();
            $row.children('td.product').text($productName.val());
            $row.children('td.price').text($price.val());
            $row.children('td.units').text($units.val());
            $row.children('td.total').text(total);
            $row.attr('data-productID', $productName.attr('data-productID'));
            $row.attr('data-price', $price.val());
            $row.attr('data-units', $units.val());
            $tableBody.append($row);

            Clear();
        } else {
            alertify.defaults.glossary.title = "Error";
            alertify.alert("One of the inputs have problem ...!").show();
        }
    });
}())