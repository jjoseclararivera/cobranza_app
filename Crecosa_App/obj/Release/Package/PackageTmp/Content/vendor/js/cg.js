function astocierre() {
    var pa = $("input:hidden[name=ID_PAIS]").val();
    var em = $("input:hidden[name=ID_EMPRESA]").val();
    var me = $("input:hidden[name=MES_ABIERTO]").val();
    var an = $("input:hidden[name=ANIO_ABIERTO]").val();
    var us = $("input:hidden[name=ID_USUARIO]").val();

    $.post("../cg/astocierre",
          {
              p: pa,
              e: em,
              m: me,
              a: an,
              u: us
        })
        .done(function (data) {
            $("#astocierre").html(data);
        })
        .fail(function (response) {
            alert("Ha ocurrido un error en la petición de la data JS. (Asiento de cierre)" + response.responseText);
        });
}