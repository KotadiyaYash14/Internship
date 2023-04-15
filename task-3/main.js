var datatable, add, sub, multi, div;
$(document).ready(function () {
  datatable = $("#mytable").DataTable();
  $("#save").click(function () {
    var number1 = $("#Number-1").val();
    var number2 = $("#Number-2").val();

    if ($('input[name="add"]:checked').prop("checked") == true) {
      add = parseFloat(number1) + parseFloat(number2);
    } else {
      add = "-";
    }
    if ($('input[name="Subtraction"]:checked').prop("checked") == true) {
      sub = parseFloat(number1) - parseFloat(number2);
    } else {
      sub = "-";
    }
    if ($('input[name="Multiplication"]:checked').prop("checked") == true) {
      multi = parseFloat(number1) * parseFloat(number2);
    } else {
      multi = "-";
    }
    if ($('input[name="Division"]:checked').prop("checked") == true) {
      div = parseFloat(number1) / parseFloat(number2);
    } else {
      div = "-";
    }

    datatable.row.add([number1, number2, add, sub, multi, div]).draw();
    $("input").val("");
    $('input[type="checkbox"]').prop("checked", false);
  });
});