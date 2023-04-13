$(document).ready(function () {
    $("#submit").click(function () {
        var first_inp = $("#txt_row").val();
        var second_inp = $("#txt_column").val();
        var tbody = '<table class="table table-responsive table-bordered table-light table-striped text-center shadow mt-4">';

        for (var i = 0; i < first_inp; i++) {
            tbody += '<tr>';
            for (var j = 0; j < second_inp; j++) {
                tbody += '<td>';
                tbody += 'Row ' + i + ',' + ' ' + 'Col ' + j;
                tbody += '</td>'
            }
            tbody += '</tr>';
        }
        tbody += '</table>';
        $("#generate_table").html(tbody);
    });
});