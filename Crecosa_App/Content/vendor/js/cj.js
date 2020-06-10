
function CJ_MostrarForm(frm,val1,val2) {

    if (frm != null) {
        //El INPUT [nombreId] debe contener el valor del INPUT donde se va a retornar ej: el codigo de cliente encontrado y dato adicional.
        $("input:hidden[name=nombreId]").val(val1);
        if (val2 != null) {
            $("input:hidden[name=nombreVal]").val(val2);

        }
        $('#'+frm).show();
    }
}

function CJ_LimpiaBuscar() {
    $("#c1s").html("");
    $("input:text[name=BuscarVal]").val("");
}

function CJ_buscar() {
    var t = $("select[name=BuscarPor] option:selected").val();
    var v = $("input:text[name=BuscarVal]").val();
    var x = $("input:hidden[name=nombreId]").val();
    
    if (v != null) {
        $.get("/cj/buscar",
            {
                tip: t,
                val: v,
                ide: x
            }).done(function (data) {
                $("#c1s").html(data);
            }).fail(function () {
                alert("Ha ocurrido un error en la petición de la data JS.");
            });
    }
}

function CJ_idCliente(c, d) {
    var i = $("input:hidden[name=nombreId]").val();
    $("input:text[name=" + i + "]").val(c);
    if (d != null) {
        var n = $("input:hidden[name=nombreVal]").val();
        $("input:text[name=" + n + "]").val(d);
    }
    document.getElementById('objBuscarCL').style.display = 'none';
}

function alertas() {
    var tipo = $('input:hidden[name=TIPO_USUARIO]').val();
    if (tipo == 'CAJA') {
        $.get("/cj/alerta", {}).done(function (data) {
            $("#nalert").html(data);
        }).fail(function () {
            alert("Ha ocurrido un error en la petición de la data JS. (Cargar Datos de Alertas)");
        });
    }
}

setInterval(function () {
    alertas();
}, 20000); //ejecutar tras (n) cantidad de minutos