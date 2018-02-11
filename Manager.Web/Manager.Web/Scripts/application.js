$(document).ready(function () {
    $("#sidebar").mCustomScrollbar({
        theme: "minimal"
    });
    $.jgrid.defaults.responsive = true;
    $.jgrid.defaults.styleUI = 'Bootstrap';
    $.jgrid.styleUI.Bootstrap.base.rowTable = "table table-bordered table-striped";


    $('#sidebarCollapse').on('click', function () {
        $('#sidebar, #content').toggleClass('active');
        $('.collapse.in').toggleClass('in');
        $('a[aria-expanded=true]').attr('aria-expanded', 'false');
        $(window).bind('resize', function () {
            $.jgrid.defaults.width = $("#panel").width();
        }).trigger('resize');
    });
});

function getHeightForResize(ajuste) {

    var divHp = document.getElementById('bandeja');
    var divTp = document.getElementById('panel');
    var divMb = document.getElementById('MenuBar');
    var divSP = document.getElementById('seachPanel');
    var divCh = document.getElementById('ContentHeader');

    var intHeight = 0;

    if (divHp)
        intHeight += divHp.offsetHeight;

    if (divTp)
        intHeight += divTp.offsetHeight;

    if (divMb)
        intHeight += divMb.offsetHeight;

    if (divSP)
        intHeight += divSP.offsetHeight;

    if (divCh)
        intHeight += divCh.offsetHeight;

    var intHDif = $(document).height() - (intHeight + (ajuste || 0));
    return intHDif;
};