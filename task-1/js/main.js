var dt;
var row_index;
var value7;
let info = [
  {
    index: "1",
    first: "Yash",
    last: "Kotadiya",
    company: "Shaligram Infotech",
    address: "Junagadh",
    Email: "yashkotadiya222@gmail.com",
    phone: "9737012270",
  },
];

$(document).ready(function () {
  dt = $("#Mytable").DataTable();
  $("table").on("click", ".dltbtn", function () {
    row_index = $(this).parents("tr").index();
    alert("Do You Want to Delete the Record ?")
    dt.row($(this).parents("tr")).remove().draw();
    info.splice(row_index, 1);
  });

  $("#addbtn").click(function () {
    $(".formdata").css("display", "block");
    $("#maintable").css("display", "none");
  });

  $("tbody").on("click", ".editbtn", function () {
    value7 = $(this).parents("tr").find("td:eq(0)").html();
    var value1 = $(this).parents("tr").find("td:eq(1)").html();
    var value2 = $(this).parents("tr").find("td:eq(2)").html();
    var value3 = $(this).parents("tr").find("td:eq(3)").html();
    var value4 = $(this).parents("tr").find("td:eq(4)").html();
    var value5 = $(this).parents("tr").find("td:eq(5)").html();
    var value6 = $(this).parents("tr").find("td:eq(6)").html();
    row_index = $(this).parents("tr").index();

    $(".first1").val(value1);
    $(".last1").val(value2);
    $(".company1").val(value3);
    $(".addr1").val(value4);
    $(".email1").val(value5);
    $(".number1").val(value6);

    $(".formdata2").css("display", "block");
    $("#maintable").css("display", "none");
  });

  $(".Close").click(function (e) {
    e.preventDefault();
    $(".formdata").css("display", "none");
    $("#maintable").css("display", "block");
  });

  $(".Submit").click(function (e) {
    e.preventDefault();
    // let show = `<button class="btn btn-primary submit1 showbtn">Show</button>`
    let first = $("#form6Example1").val();
    let last = $(".last").val();
    let company = $(".company").val();
    let address = $(".addr").val();
    let Email = $(".email").val();
    let phone = $(".number").val();
    let edit = `<button class="btn btn-outline-primary submit1 editbtn">Edit</button>`;
    let delet = `<button class="btn btn-outline-danger submit1 dltbtn">Delete</button>`;
    isValid = true;

    if (first == "") {
      $("#first1").html("enter your first name");
      $("#first1").css("color", "red");
      isValid = false;
    } else {
      $("#first1").html("");
    }

    if (last == "") {
      $("#Last1").html("enter your last name");
      $("#Last1").css("color", "red");
      isValid = false;
    } else {
      $("#Last1").html("");
    }

    if (company == "") {
      $("#Company1").html("enter your company name");
      $("#Company1").css("color", "red");
      isValid = false;
    } else {
      $("#Company1").html("");
    }

    if (address == "") {
      $("#Address1").html("enter your address");
      $("#Address1").css("color", "red");
      isValid = false;
    } else {
      $("#Address1").html("");
    }

    if (Email == "") {
      $("#Email1").html("enter your Email");
      $("#Email1").css("color", "red");
      isValid = false;
    } else {
      $("#Email1").html("");
    }

    if (phone == "") {
      $("#Phone1").html("enter your phone");
      $("#Phone1").css("color", "red");
      isValid = false;
    } else {
      $("#Phone1").html("");
    }

    if (isValid) {
      info.push({
        index: info.length + 1,
        first: first,
        last: last,
        company: company,
        address: address,
        Email: Email,
        phone: phone,
      });
      dt.clear().draw();
      info.forEach((ele) =>
        dt.row
          .add([
            ele.index,
            ele.first,
            ele.last,
            ele.company,
            ele.address,
            ele.Email,
            ele.phone,
            edit,
            delet
          ])
        .draw()
      );
      $(".formdata").css("display", "none");
      $("#maintable").css("display", "block");
      $(".formdata").trigger("reset");
    }
  });

  $(".Submit1").click(function (e) {
    e.preventDefault();
    // let show1 = `<button class="btn btn-primary submit1 showbtn">Show</button>`
    let first1 = $(".first1").val();
    let last1 = $(".last1").val();
    let company1 = $(".company1").val();
    let address1 = $(".addr1").val();
    let Email1 = $(".email1").val();
    let phone1 = $(".number1").val();
    let edit1 = `<button class="btn btn-outline-primary submit1 editbtn">Edit</button>`;
    let delet1 = `<button class="btn btn-outline-danger submit1 dltbtn">delete</button>`;
    isValid = true;

    if (first1 == "") {
      $("#first2").html("enter your first name");
      $("#first2").css("color", "red");
      isValid = false;
    } else {
      $("#first2").html("");
    }

    if (last1 == "") {
      $("#Last2").html("enter your last name");
      $("#Last2").css("color", "red");
      isValid = false;
    } else {
      $("#Last2").html("");
    }

    if (company1 == "") {
      $("#Company2").html("enter your company name");
      $("#Company2").css("color", "red");
      isValid = false;
    } else {
      $("#Company2").html("");
    }

    if (address1 == "") {
      $("#Address2").html("enter your address");
      $("#Address2").css("color", "red");
      isValid = false;
    } else {
      $("#Address2").html("");
    }

    if (Email1 == "") {
      $("#Email2").html("enter your Email");
      $("#Email2").css("color", "red");
      isValid = false;
    } else {
      $("#Email2").html("");
    }

    if (phone1 == "") {
      $("#Phone2").html("enter your phone");
      $("#Phone2").css("color", "red");
      isValid = false;
    } else {
      $("#Phone2").html("");
    }

    if (isValid) {
      let upinfo = {
        index: info.length,
        first: first1,
        last: last1,
        company: company1,
        address: address1,
        Email: Email1,
        phone: phone1,
      };

      info[value7 - 1] = upinfo;
      dt.clear().draw();
      info.forEach((ele) =>
        dt.row
          .add([
            ele.index,
            ele.first,
            ele.last,
            ele.company,
            ele.address,
            ele.Email,
            ele.phone,
            edit1,
            delet1
          ])
          .draw()
      );

      $(".formdata2").css("display", "none");
      $("#maintable").css("display", "block");
    }
  });
});
