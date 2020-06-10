
function include(file) {

    var script = document.createElement('script');
    script.src = file;
    script.type = 'text/javascript';
    script.defer = true;

    document.getElementsByTagName('head').item(0).appendChild(script);

} 

include("../Content/vendor/js/cl.js");
include("../Content/vendor/js/cr.js");
include("../Content/vendor/js/cj.js");
include("../Content/vendor/js/pa.js");
include("../Content/vendor/js/sg.js");
include("../Content/vendor/js/cg.js");