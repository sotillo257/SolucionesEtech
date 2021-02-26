$(document).ready(function () {

    $(".app").on("click", "#dropdown-sidebar-button", function () {
        if ($("#dropdown-sidebar").hasClass("open")) {
            $('#dropdown-sidebar').removeClass("open");
        } else {
            $('#dropdown-sidebar').addClass("open");
        }
    });

    $(".app").on("click", ".sidebar-panel nav", function () {
        $('#dropdown-sidebar').removeClass("open");
    });

    $('.datepickerExp').pickadate({
        selectYears: 60,
        format: 'dd/m/yyyy',
        formatSubmit: 'dd/m/yyyy',
        min: true,
        max: 10950
    });

    $('.datepickerBirth').pickadate({
        selectYears: 80,
        format: 'dd/m/yyyy',
        formatSubmit: 'dd/m/yyyy',
        min: -21900,
        max: true
    });

    $('.datepickerForWork').pickadate({
        selectYears: 40,
        format: 'dd/m/yyyy',
        formatSubmit: 'dd/m/yyyy',
        min: true,
        max: 10950
    });

    $('.datepickerFrom').pickadate({
        selectYears: 40,
        format: 'dd/m/yyyy',
        formatSubmit: 'dd/m/yyyy',
        min: -21900,
        max: -2
    });

    $('.datepickerTo').pickadate({
        selectYears: 40,
        format: 'dd/m/yyyy',
        formatSubmit: 'dd/m/yyyy',
        min: -21900,
        max: -1
    });
    $('.mdb-select').materialSelect();

    $('#dt-personal').dataTable({
        paging: false,
        searching: false,
        ordering: false
    });

    $('#dt-records').dataTable({
        paging: false,
        searching: false,
        ordering: false
    });

    //Solo numero. Validacion para inputs v2
    $('.num-va').on('input', function () {
        this.value = this.value.replace(/[^0-9]/g, '');
    });

    //Solo numero y simbol $. Validacion para inputs v2
    $('.prc-va').on('input', function () {
        this.value = this.value.replace(/[^0-9$]/g, '');
    });

    //Solo texto. Validacion para inputs v2
    $('.txt-va').on('input', function () {
        this.value = this.value.replace(/[^a-zA-ZáéíóúüñÁÉÍÓÚÑÜ ]/g, '');
    });

    //Alfanumerico descripciones. Validacion para inputs v2
    $('.al-va').on('input', function (event) {
        this.value = this.value.replace(/[^0-9a-zA-ZáéíóúüñÁÉÍÓÚÑÜ#(),. ]/g, '');
    });

    //Alfanumerico Licence. Validacion para inputs v2
    $('.lc-va').on('input', function (event) {
        this.value = this.value.replace(/[^0-9a-zA-Z/-]/g, '');
    });

    //Alfanumerico y caracteres Username. Validacion para inputs v2
    $('.un-va').on('input', function (event) {
        this.value = this.value.replace(/[^0-9a-zA-Z_-]/g, '');
    });

    $('.em-va').on('input', function (event) {
        this.value = this.value.replace(/[^0-9a-zA-Z@@._\-]/g, '');
    });

    //Passwords. Validacion para inputs v2
    $('.pss-va').on('input', function (event) {
        this.value = this.value.replace(/[^0-9a-zA-Z!$*%&_\-]/g, '');
    });

    $(".dp-control").bind({
        copy: function (e) {
            e.preventDefault();
        },
        cut: function (e) {
            e.preventDefault();
        },
        paste: function (e) {
            e.preventDefault();
        },
    });

    $('.dp-control').bind('keypress', function (e) {
        e.preventDefault();
    });

    $('.dp-control').datepicker({

    }).on('change', function () {
        $('.datepicker').hide();
    });
});