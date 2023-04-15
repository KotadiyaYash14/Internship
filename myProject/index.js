var table;
let form = $("#form");
let NameInput = $("#NameInput");
let EmailInput = $("#EmailInput");
let msg = $("#msg");
let msgid = $("#msgid")
let add = $("#add");

$(document).ready(function () {
    table = $('#myTable').DataTable();
    $('#add').click(function () {
        formValidation();
    })

    ///////////////////////// DELETE LOGIC /////////////////////////

    $('#myTable').on('click', '#delete', function () {
        alert("Do you want yo delete the revord ?")
        table.row($(this).parents('tr')).remove().draw();
    });

    ///////////////////////// EDIT LOGIC /////////////////////////

    $('#myTable').on('click', '#edit', function () {
        var NameInput = $(this).parents('tr').find("td:eq(0)").text();
        var EmailInput = $(this).parents('tr').find("td:eq(1)").text();
        var index = $(this).parents('tr').index();
        $("#NameInput").val(NameInput);
        $("#EmailInput").val(EmailInput);
        $("#index").val(index);
    });

    $(".closeBtn").click(function () {
        $("#form").trigger("reset")
    })

    $('.updateBtn').click(updateform);
});

///////////////////////// ADD DATA TO THE DATA TABLE /////////////////////////

function addData() {
    table.row.add([NameInput.val(), EmailInput.val(), '<i class="fa-solid fa-trash-can" id="delete"></i>&nbsp;&nbsp;&nbsp;<i class="fa-solid fa-pen-to-square" id="edit" data-bs-toggle="modal" data-bs-target="#form"></i>']).draw();
}

function resetform() {
    NameInput.val("");
    EmailInput.val("");
}

///////////////////////// UPDATE ROW /////////////////////////

function updateform() {
    var index = parseInt($('#index').val()) + 1;
    var row = $(`tr:eq(${index})`);
    var name = $("#NameInput").val();
    var desc = $("#EmailInput").val();
    row.find("td:eq(0)").html(name);
    row.find("td:eq(1)").html(desc);
    resetform();
}

///////////////////////// VALIDATION /////////////////////////

function formValidation() {
    isValid = true;
    if (NameInput.val() == '' || !/^[a-zA-Z ]*$/.test($("#NameInput").val())) {
        msg.html("Please Enter Valid Name");
        isValid = false;
    }
    else {
        $("#msg").html("");
    }

    if (EmailInput.val() == '' || !/[^\s@]+@[^\s@]+\.[^\s@]+/.test($("#EmailInput").val())) {
        msgid.html("Please Enter Valid Email")
        isValid = false;
    }
    else {
        $("#msgid").html("");
    }

    if (isValid) {
        addData();
        resetform();
    }
}