

function g_ides(id) {
    var url = "/cl/ides?idc=" + $('input:text[name=ID_CLIENTE]').val();
    $.get(url, {})
        .done(function (data) {
            $("#xOtrasIDs").html(data);
        }).fail(function () {
            alert("Ha ocurrido un error en la petición de la data JS.");
        });
    
}

function p_ides() {
    var id = $('input:text[name=ID_CLIENTE]').val();
    var tipoId = $('#tide').val();
    var numId = $('input:text[name=nide]').val();
    var paisOrg = $('#pae').val();
    var fecIni = $('input:text[name=fec1]').val();
    var fecFin = $('input:text[name=fec2]').val();
    $.post("/cl/ides",
        {
        idc: id,
        tide: tipoId,
        nide: numId,
        pae: paisOrg,
        fec1: fecIni,
        fec2: fecFin
        })
        .done(function (data) {
            $("#xOtrasIDs").html(data);
        })
        .fail(function () {
            alert("Ha ocurrido un error en la petición de la data JS.");
        });
}

function showform(frmId) {
    var id = $('input:text[name=ID_CLIENTE]').val();
    if (id > 0) {
        $('#' + frmId).show();
    }
    else { alert("grabe primero al cliente"); }
}

function nuevo_id() {
    var id = $('input:text[name=ID_CLIENTE]').val();
    if (id > 0) {
        $('input:text[name=nide]').val('');
    }
}

function xtab(tab) {

    var c = $('#icli').val();
    var id = $('input:text[name=ID_CLIENTE]').val();

    switch (tab) {
        case 2:
            if (id > 0) {
                g_ides(c);
            }
            break;
        case 3:
            if (id > 0) {
                gDirs(c);
            }
            break;
        case 4:
            if (id > 0) {
                gRefs(c);
            }
            break;
        case 5:
            if (id > 0) {
                gJDtv(c);
            }
    }
    $('#tab').val(tab);
}

function gDirs() {
    var url = "/cl/dir?id=" + $('input:text[name=ID_CLIENTE]').val();
    $.get(url, {})
        .done(function (data) {
            $("#xOtrasDirs").html(data);
        }).fail(function (response) {
            alert("Ha ocurrido un error en la petición de la data JS." + response.responseText);
        });
}

function gRefs() {
    var url = "/cl/refs?id=" + $('input:text[name=ID_CLIENTE]').val();
    $.get(url, {})
        .done(function (data) {
            $("#xRefencias").html(data);
        }).fail(function (response) {
            alert("Ha ocurrido un error en la petición de la data JS." + response.responseText);
        });
}

function gJDtv() {
    var url = "/cl/jdtv?id=" + $('input:text[name=ID_CLIENTE]').val();
    $.get(url, {})
        .done(function (data) {
            $("#xJuntaDtva").html(data);
        }).fail(function (response) {
            alert("Ha ocurrido un error en la petición de la data JS." + response.responseText);
        });
}

function saveDir() {
    var id = $('input:text[name=ID_CLIENTE]').val();
    var td = $("select[name=tipodir] option:selected").val(); 
    var dpa = $("select[name=deparmto] option:selected").val();
    var mun = $("select[name=muni] option:selected").val();
    var dtr = $("select[name=distri] option:selected").val();
    var bar = $("select[name=barrio] option:selected").val();
    var dir = $('input:text[name=xdireccion]').val();
    var obr = $('input:text[name=observadir]').val();
    $.post("/cl/dir",
        {
            idCli: id,
            tipoDir: td,
            depa: dpa,
            muni: mun,
            distri: dtr,
            barrio: bar,
            direccion: dir,
            notas: obr
        })
        .done(function (data) {
            $("#xOtrasDirs").html(data);
        })
        .fail(function () {
            alert("Ha ocurrido un error en la petición de la data JS.(dir)");
        });
}

function buscar() {
    var t = $("select[name=BuscarPor] option:selected").val();
    var v = $("input:text[name=BuscarVal]").val();
    var x = $("input:hidden[name=nombreId]").val();

    if (v != null)
    {
        $.get("/cl/buscar",
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

function idCliente(c,d) {
    var i = $("input:hidden[name=nombreId]").val();
    $("input:text[name=" + i + "]").val(c);
    if (d != null)
    {
        var n = $("input:hidden[name=nombreVal]").val();
        $("input:text[name=" + n + "]").val(d);
    }
    document.getElementById('form1').style.display = 'none';
}

function load_cmb(cb,vl,lb,lo) {
    var dato = $("select[id="+vl+"] option:selected").val();
    
    if (dato != null) {
        $.get("/cl/cmb",
            {
                c: cb,
                v: dato,
                nlbl: lb
            }).done(function (data) {
                $("#" + lo).html(data);
            }).fail(function (response) {
                alert("Ha ocurrido un error en la petición de la data JS de cmb." + response.responseText);
            });
    }
}

function tipRef() {
    var dato = $("select[id=IND_TIPO_REF] option:selected").val();
    if (dato != 'C') {
        $("#refCome").hide();
    }
    else {
        $("#refCome").show();
    }
}

function saveRef() {
    var id = $('input:text[name=ID_CLIENTE]').val();
    var tr = $("select[name=IND_TIPO_REF] option:selected").val();
    var pt = $("select[name=ID_PARENTESCO] option:selected").val();
    var nr = $('input:text[name=NOM_REFERENCIA]').val();
    var tl = $('input:text[name=NUM_TELEFONO]').val();
    var mr = $('input:text[name=MON_REF_COME]').val();
    var fp = $("select[name=IND_FORMA_PAGO] option:selected").val();

    $.post("/cl/refs",
        {
            txtid: id,
            cmbtr: tr,
            cmbpt: pt,
            txtnr: nr,
            txttel: tl,
            txtmr: mr,
            cmbfp: fp
        })
        .done(function (data) {
            $("#xOtrasDirs").html(data);
        })
        .fail(function (response) {
            alert("Ha ocurrido un error en la petición de la data JS.(dir)" + response.responseText);
        });
}

function saveJDtv() {
    var ide = $('input:text[name=ID_CLIENTE]').val();
    var n = $('input:text[name=NOM_DIRECTIVO]').val();
    var c = $("select[name=ID_CARGO] option:selected").val();
    var nta = $('input:text[name=NOTA]').val();
    var e = $("select[name=IND_ESTADO] option:selected").val();

    $.post("/cl/jdtv",
        {
            id: ide,
            nom: n,
            idcgo: c,
            notas: nta,
            est: e
        })
        .done(function (data) {
            $("#xJuntaDtva").html(data);
        })
        .fail(function (response) {
            alert("Ha ocurrido un error en la petición de la data JS.(dir)" + response.responseText);
        });
}