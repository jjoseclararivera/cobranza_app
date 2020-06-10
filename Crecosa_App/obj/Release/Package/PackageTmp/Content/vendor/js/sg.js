
function guardar(frmName, btnName) {
    $('input:hidden[name=btn]').val(btnName);
    document.getElementById(frmName).submit();
}

function ira(ct, ar) {
    if (ct != null & ar != null) {
        location.href = "../" + ct + "/" + ar;
    }
}

function buscarCli() {
    var t = $("select[name=BuscarPor] option:selected").val();
    var v = $("input:text[name=BuscarVal]").val();
    var x = $("input:hidden[name=nombreId]").val();

    if (v != null) {
        $.get("/sg/buscar",
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

function cliSelect(frm,id,c,nom,d) {
    
    if (id != null & c != null & nom != null & d != null) {
        $("input:text[name=" + id + "]").val(c);
        $("input:text[name=" + nom + "]").val(d);
    }
    document.getElementById(frm).style.display = 'none';
}

function mnu_x_rol(r, m, s) {

    var x = $("input:hidden[name=chk_" + m + s + "]").val();
    var i = "";
    if (x == "A") {
        document.getElementById("chk_" + m + s).style.display = 'none';
        $("input:hidden[name=chk_" + m + s + "]").val("I");
        i = "A";
    }
    else {
        document.getElementById("chk_" + m + s).style.display = "initial";
        $("input:hidden[name=chk_" + m + s + "]").val("A");
        i = "I";
    }

    $.post("/sg/sgmnu",
        {
            xrol: r,
            menu: m,
            smnu: s,
            modo: i
        })
        .done()
        .fail(function () {
            alert("Ha ocurrido un error en la petición de la data JS. menu x rol");
        });
}
