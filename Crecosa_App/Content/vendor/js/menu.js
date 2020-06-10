
$.ajax({
    url: "/inicio/cargamenu",
    data: {},
    type: "POST",
    success: function (response) {
        
        $("#xmenu").html(response);
    }
});
