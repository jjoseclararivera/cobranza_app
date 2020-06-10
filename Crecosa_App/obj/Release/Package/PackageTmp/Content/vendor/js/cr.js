function buscar_cr(gp,d) {
    var t = $("select[name=BuscarX] option:selected").val();
    var v = $("input:text[name=BuscarV]").val();

    if (d != null) {
        $("input:hidden[name=nombreId]").val(d);
    }

    if (gp == "p") {
        $.post("/cr/buscar_cr",
            {
                BUSCAR_POR: t,
                BUSCAR: v
            }).done(function (data) {
                $("#frmbuscar").html(data);
            }).fail(function () {
                alert("Ha ocurrido un error en la petición de la data JS.");
            });
    }
    else {
        $("#objBuscar_cr").show();

        $.get("/cr/buscar_cr",
            {

            }).done(function (data) {
                $("#frmbuscar").html(data);
            }).fail(function () {
                alert("Ha ocurrido un error en la petición de la data JS.");
            });
    }
}

function obtener(v,x) {
    if (v != null) {
        switch (x) {
            case 0:
                var d = $("input:hidden[name=nombreId]").val();
                $("input:text[name=" + d + "]").val(v);
                break;
            case 1:
                var n = $("input:hidden[name=NUM_CREDITO]").val();
                if (n > 0) {
                    asunewcre(n, v, "agregar");
                } else {
                    alert("Debe guardar la solicitud antes de agregar el crédito que sera cancelado una vez se apruebe esta.");
                }

                break;
        }
        
    }

    $("#objBuscar_cr").hide();
}

function asunewcre(n, a, b) {
    var num_cr = $("input:hidden[name=NUM_CREDITO]").val();
    var ac = $("input:hidden[name=ac]").val()
    if (num_cr > 0) {
        if (n > 0 & a > 0 & b != null) {
            $.post("/cr/asunewcre",
                {
                    num: n,
                    acr: a,
                    btn: b,
                    a: ac
                }).done(function (data) {
                    $("#asu").html(data);
                }).fail(function () {
                    alert("Ha ocurrido un error en la petición de la data JS.");
                });
        } else {
            $.get("/cr/asunewcre",
                {
                    num: num_cr,
                    a: ac
                }).done(function (data) {
                    $("#asu").html(data);
                }).fail(function () {
                    alert("Ha ocurrido un error en la petición de la data JS.");
                });
        }
    }
}


function bCliente(ac) {

    if (ac == 1) {
        $("input:hidden[name=nombreId]").val("ID_CLIENTE")
        var d = $("input:hidden[name=ac]").val();
        if (d < 3) {
            $('#form1').show();
        }
    }
}

function p_plan() {

    var n = $('input:hidden[name=NUM_CREDITO]').val();
    var fa = $('input:text[name=FEC_SOLICITUD]').val();
    var mc = $('input:text[name=MON_SOLICITADO]').val();
    var c = $("input:text[name=MON_CARGO]").val();
    var p = $('input:text[name=PLAZO_CREDITO]').val();
    var fp = $('select[name=IND_FORMA_PAGO]').val();
    var tc = $('select[name=TIPO_CUOTA]').val();
    var ti = $('input:text[name=INT_CORR]').val();
    var dg = $('input:text[name=CUOTAS_GRACIA_PRIN]').val();
    var dp = $('input:text[name=DIA_PAGO]').val();
    var ver = 'S';

    if (n > 0) { s = 2; } else { s = 1; }
    if (c == null) { c = 0; }

    if (dp == null) { dp = fa;}

    $.post("../cr/planpagos",
        {
            x: s, //1) para crear, 2) para visualizar uno existente
            num: n, //numero de credito si existe.
            fec: fa, //fecha de creacion
            mto: mc, //monto
            tasa: ti, //tasa de interes
            plazo: p, //plazo del credito
            forma: fp, //forma de pago
            gracia: dg, //dias de gracias del principal
            dia: dp, //dia de pago
            tipo: tc, //tipo de cuota.
            cargo: c, //cargos
            v: ver //S) para visualizarlo, N) para no hacerlo
        })
        .done(function (data) {
            $("#xPlan").html(data);
        })
        .fail(function (response) {
            alert("Ha ocurrido un error en la petición de la data JS. (Plan pagos)" + response.responseText);
        });
}

function fvence() { //NO ESTA EN USO                                              <-----<<
    var x = $('input:text[name=FEC_SOLICITUD]').val().split('-');
    var fec = x[2] + '/' + x[1] + '/' + x[0];
    
    var fecha = new Date(fec);
    var p = $('input:text[name=PLAZO_CREDITO]').val();
    fecha.setDate(fecha.getDate() + p);

    var d = fecha.getDay();
    var m = fecha.getMonth();

    if (d < 10) { d = '0' + d; }
    if (m < 10) { m = '0' + m; }

    var f = d + '-' + m + '-' + fecha.getFullYear()

    $('input:text[name=FEC_VENCIMIENTO]').val(f);
}

function nueva_cuota() {
    var n = $('input:hidden[name=NUM_CREDITO]').val();
    var f = $('input:text[name=fecPPI]').val();

    $.post("/cr/pagoirregular",
        {
            num:n,
            fecPPI:f
        })
        .done(function (data) {
            p_plan();
        })
        .fail(function () {
            alert("Ha ocurrido un error en la petición de la data JS. (Pagos Irregulares)");
        });
}

function verCargos() {
    var n = $('input:hidden[name=NUM_CREDITO]').val();
    var t = $('select[name=ID_TIPO_CRE]').val();

    if (n >= 0) {
        $.get("/cr/mcargos",
            {
                num: n,
                tdc: t
            }).done(function (data) {
                $("#ncgs").html(data);
            }).fail(function (response) {
                alert("Ha ocurrido un error en la petición de la data JS. (Mostrar Cargos)" + response.responseText);
            });
    }
}

function editCargo(id) {
    var n = $('input:hidden[name=NUM_CREDITO]').val();
    var d = $('input:hidden[name=ac]').val();
    var t = $('select[name=ID_TIPO_CRE]').val();

    if (n >= 0 & d<3) {
        $.post("/cr/mcargos",
            {
                num: n,
                tdc: t,
                idc: id
            }).done(function (data) {
                $("#ncgs").html(data);
            }).fail(function (response) {
                alert("Ha ocurrido un error en la petición de la data JS. (Editar Cargos)" + response.responseText);
            });
    }
}

function uCargo() {

    var n = $('input:hidden[name=NUM_CREDITO]').val();
    var t = $('select[name=ID_TIPO_CRE]').val();
    var c = $('input:text[name=ID_CARGO]').val();
    var xmp = $('select[name=IND_MONTO_P100]').val();
    var v = $('input:text[name=VAL_COMISION]').val();
    var m = $('select[name=TIP_COMISION]').val();

    if (n >= 0) {
        $.post("/cr/ecargo",
            {
                num: n,
                tpCre: t,
                idcar: c,
                mp: xmp,
                val: v,
                modo: m
            }).done(function (data) {
                $("#ncgs").html(data);
            }).fail(function (response) {
                alert("Ha ocurrido un error en la petición de la data JS. (Actualizar Cargos)" + response.responseText);
            });
    }
}

function ldcmb() {
    
    x = $('select[name=TIP_DESEMBOLSO]').val();
    alert("aqui es donde se sa");
    $.get("/cr/cmb",
        {
            t: x
        }).done(function (data) {
            $("#cmbx").html(data);
        }).fail(function () {
            alert("Ha ocurrido un error en la petición de la data JS. (Cargar Datos de cmb)");
        });
}

function producto(s) {
    x = $('select[name=ID_FONDO]').val();

    $.get("/cr/cmb_idproducto",
        {
            id: x,
            e: s
        }).done(function (data) {
            $("#idProducto").html(data);
        }).fail(function () {
            alert("Ha ocurrido un error en la petición de la data JS. (Cargar Datos de cmb producto)");
        });
}

function tipo_credito(s) {
    x = $('select[name=ID_PRODUCTO]').val();

    $.get("/cr/cmb_idtipocred",
        {
            id: x,
            e: s
        }).done(function (data) {
            $("#idtipocredito").html(data);
        }).fail(function () {
            alert("Ha ocurrido un error en la petición de la data JS. (Cargar Datos de cmb tipo de credito)");
        });
}

function actividad_eco(s) {
    x = $('select[name=ID_PRODUCTO]').val();

    $.get("/cr/cmb_actividad_eco",
        {
            id: x,
            e: s
        }).done(function (data) {
            $("#idactividad").html(data);
        }).fail(function () {
            alert("Ha ocurrido un error en la petición de la data JS. (Cargar Datos de cmb Actividad Economica)");
        });
}

//Carga todos los datos iniciales del tipo de credito.
function cargar_tipo_cre(n) {
    x = $('select[name=ID_TIPO_CRE]').val();
    $.get("/cr/cargar_tipo_cre",
        {
            id: x,
        }).done(function (data) {
            var s = data;
            var d = s.split(":");
            
            d.forEach(ver);

            function ver(v, p) {
                switch (p) {
                    case 0:
                        $('input:text[name=PLAZO_CREDITO]').val(v);
                        break;
                    case 2:
                        $('select[name=IND_FORMA_PAGO]').val(v);
                        break;
                    case 3:
                        $('input:text[name=INT_CORR]').val(v);
                    case 5:
                        var num = parseInt(v);
                        $('select[name=ID_MONEDA]').val(num);
                        break;
                    case 6:
                        $('input:text[name=INT_MORA]').val(v);
                        break;
                    case 7:
                        $('input:text[name=DIAS_GRACIA_MORA]').val(v);
                        break;
                    case 8:
                        var xnum = parseInt(v);
                        $('select[name=TIPO_CUOTA]').val(xnum);
                        break;
                };
                //PLAZO_MAXIMO:0 NUM_CUOTAS:1 IND_FORMA_PAGO:2 INT_CORR_DESDE:3 INT_CORR_HASTA:4 ID_MONEDA:5 INT_MORA_HASTA:6 DIAS_GRACIA_MORA:7
            };

        }).fail(function () {
            alert("Ha ocurrido un error en la petición de la data JS. (Cargar Datos de cmb tipo de credito)");
        });
}

function save1(form_name) {
    $('input:hidden[name=btnGuardar]').val("guardar");
    document.getElementById(form_name).submit();
}
