
var exp = $("#expira").val();

//$(document).keydown(function (e) { if (e.keyCode == 27) return false; });



exec = setTimeout(function () {
    if (exp > 0)
    {
        $("#protg").modal({ backdrop: "static" });
        $("#xyz").val("1");
    }
}, exp*60000); //ejecutar tras (exp) cantidad de minutos

$(function () {
    var g = $("#xyz").val();
    if (g == 1)
    {
        clearTimeout(exec); //detener el tiempo hasta que se recargeue la pagina
        $("#protg").modal({ backdrop: "static" });
    }
}
);

function showscreensg()
{
    $("#protg").modal({ backdrop: "static" });
}

$(function () {
    if (exp == 0) {
        clearTimeout(exec);
    }
});

$(function () {
    $("#screen1").click(function () {
        var vUsr = $("#usr").val();
        var vKey = $("#pass").val();

        $.ajax({
            url: "/inicio/screen",
            data: { u: vUsr, k: vKey },
            type: "POST",
            success: function (response) {

                if (response == "ok") {

                    $("#protg").modal("hide");
                    $("#usr").val("");
                    $("#pass").val("");
                    if (exp > 0) {
                        setTimeout(function () {
                            $("#protg").modal({ backdrop: "static" });
                            $("#xyz").val("1"); //en uno es para detener el tiempo en la funcion de arriba
                        }, exp * 60000);
                        $("#xyz").val("0"); //no detiene el tiempo
                    }
                }
                else
                {
                    alert("Usuario o contraseña no valio...!");
                }
            }
        });
    });
});

//function onKeyUp(event) {
//    var keycode = event.keyCode;
//    if (keycode == '13') {

//        $.ajax({
//            url: "/inicio/screen",
//            data: { u: vUsr, k: vKey },
//            type: "POST",
//            success: function (response) {

//                if (response == "ok") {

//                    $("#protg").modal("hide");
//                    $("#usr").val("");
//                    $("#pass").val("");
//                    setTimeout(function () {
//                        $("#protg").modal({ backdrop: "static" });
//                        $("#xyz").val("1");
//                    }, exp * 60000);
//                    $("#xyz").val("0");
//                }
//                else {
//                    alert("Usuario o contraseña no valio...!");
//                }
//            }
//        });

//    }
//}

var txtpass = document.getElementById("pass");
txtpass.focus();
txtpass.addEventListener("keydown", e => {
    if (e.keyCode == 13)
    {
        var vUsr = $("#usr").val();
        var vKey = $("#pass").val();

        $.ajax({
            url: "/inicio/screen",
            data: { u: vUsr, k: vKey },
            type: "POST",
            success: function (response) {

                if (response == "ok") {

                    $("#protg").modal("hide");
                    $("#usr").val("");
                    $("#pass").val("");
                    
                }
                else {
                    alert("Usuario o contraseña no valio...!");
                }
            }
        });
    }
});