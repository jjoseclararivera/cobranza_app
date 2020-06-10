function loadCmb(mod,cb, vl,vl2, lb, lo) {
    var dato = $("select[id=" + vl + "] option:selected").val();
    var dato2 = $("select[id=" + vl2 + "] option:selected").val();

    if (dato != null) {
        $.get("/"+mod+"/cmb",
            {
                c: cb,
                v: dato,
                v2: dato2,
                nlbl: lb
            }).done(function (data) {
                $("#" + lo).html(data);
            }).fail(function (response) {
                alert("Ha ocurrido un error en la petición de la data JS de cmb." + response.responseText);
            });
    }
}


function cargarpdf() {
    
    const $ifr = document.querySelector('#reporte')

    fetch("/rptcg/rptshow?numRep=1&indMes=12&indAnio=2018&usu=admin")
        .then(response => response.blob())
        .then(binaryLargeObject => {
            const domString = URL.createObjectURL(binaryLargeObject)
              $ifr.setAttribute('src', domString)
        })
}

function appexterna() {
    $.get("http://192.168.1.110:3000", { }).done(function (data) {
        $("#appext").html(data);
        }).fail(function (response) {
            alert("Ha ocurrido un error en la petición de la data JS de appex." + response.responseText);
        });
}