
function dpicker() {
    $('.datepicker').datepicker({
        format: 'dd-mm-yyyy',
        language: 'ni',
        autoclose: true
    });
}

$(function () {
    $('.datepicker').datepicker({
        format: 'dd-mm-yyyy',
        language: 'ni',
        autoclose: true
    });
});

$(function () {
    $('.datepicker-mmyyyy').datepicker({
        format: 'mm-yyyy',
        startView: "decade",
        minViewMode:"months",
        language: 'ni',
        autoclose: true
    });
});

$(function () {
    $('.datepicker-dia').datepicker({
        format: 'dd',
        language: 'ni',
        autoclose: true
    });
});

$(function () {
    $('.datepicker-mes').datepicker({
        format: "mm",
        startView: 1,
        minViewMode: 1,
        language: "ni",
        autoclose: true
    });
});

$(function () {
    $('.datepicker-anio').datepicker({
        format: "yyyy",
        startView: "decade",
        minViewMode: 2,
        language: 'ni',
        autoclose: true
    });
});

$(window).load(function () {
    $('.loader').fadeOut('slow');
});

$(document).ready(function () {
    //FORMATO DE MASCARAS
    $('.num-cedula').mask('000-000000-0000A', { placeholder: '000-000000-0000A' });
    $('.num-inss').mask('0000000000', { placeholder: '0000000000' }); //placeholder
    $('.x-fecha').mask('00-00-0000', { placeholder: 'DD-MM-YYYY' });
    $('.x-monto').mask("#,###,###.##", { reverse: true });
    $('.num-tel').mask('(000) 0000-0000', { placeholder: '(000) 0000-0000' }); //placeholder
    $('.cuenta-conta').mask('000000000000', { placeholder: '000000000000' }); //placeholder
    $('.codigo-mes').mask('000000', { placeholder: '000000' }); //placeholder
    $('.num-entero').mask("#########", { reverse: true });
});

$(document).ready(function () {
    $('[data-toggle="tooltip"]').tooltip();
});


if (history.forward(1)) { location.replace(history.forward(1)); }