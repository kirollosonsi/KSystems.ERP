/// <reference path="jquery-1.12.4.min.js" />


$(function () {

    var OnAjaxSuccess = function () {
        $('input').not('[type=submit]').not('[name=__RequestVerificationToken]').val("");
    }


    $('.thumbnail').on('change', '#uploadImg', function () {
        var file = this.files[0];
        var $img = $(this).closest('.thumbnail').children('img');

        if (file !== undefined && file.type.match('image.*')) {
            var fr = new FileReader();
            $img.show();

            fr.onload = function () {
                $img.attr("src", fr.result);
                console.log("from file reader loading");
            }
            fr.readAsDataURL(file);
        } else {
            $img.hide();
            $img.attr("src", "");
            $(this).val("");
        }



    });

    window.OnAjaxSuccess = OnAjaxSuccess;


}());



//<script>
// function showImage(src, target) {
//     var fr = new FileReader();
//     fr.onload = function () {
//         target.src = fr.result; //<img src="H://file1.jpg" />
//     }
//     fr.readAsDataURL(src.files[0]);
// }
//function putImage() {
//    if (!document.getElementById("FilePhoto").files[0].type.match('image.*')) {
//        document.getElementById("ShowImage").style["display"] = "none";
//        document.getElementById("Error").innerHTML = "Please Select Image File";
//        document.getElementById("FilePhoto").value = "";
//    }
//    else {
//        document.getElementById("Error").innerHTML = "";
//        var src = document.getElementById("FilePhoto");
//        var target = document.getElementById("ShowImage");
//        target.style["display"] = "block";
//        showImage(src, target);
//    }
//}
//document.getElementById('FilePhoto').addEventListener('change', putImage, false);
//</script>