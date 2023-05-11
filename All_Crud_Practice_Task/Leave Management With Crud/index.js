var dt;
var counter = 0;
var data = [];
var obj;
$(document).ready(function () {
    dt = $("#MyTable").DataTable({
        data: data,
        columns: [
            {
                title: "",
                data: null,
                defaultContent: "",
                class: "dt-control"
            },
            {
                title: "index",
                data: "index",
                class: "display"
            },
            {
                title: "Name",
                data: "name"
            },
            {
                title: "Email",
                data: "email"
            },
            {
                title: "DOB",
                data: "dob"
            },
            {
                title: "Leave",
                data: "leave"
            },
            {
                title: "LeaveType",
                data: "leavetype"
            },
            {
                title: "LeaveHalf",
                data: "leavehalf"
            },
            {
                title: "Action",
                data: null,
                defaultContent: `<button class="btn btn-outline-danger Delete">Delete</button>`
            }
        ]
    });

    $("#Add").click(function () {
        $(".modal-body input").val("");
        $("#Day").val("Select One");
        $(".Error").html("");
        $("#SelectHalfDiv").hide();
    });
    // if (data.length > 0) {
    //     $("#Email").keyup(function () {
    //         if (data[data.findIndex(x => x.email == $(this).val())].leavetype == "Half Day" && data[data.findIndex(x => x.email == $(this).val())].leavehalf == "First Half") {
    //             $("#Day").change(function () {
    //                 var MyDay = $('#Day').val();
    //                 if (MyDay == "Half Day") {
    //                     $("#SelectHalfDiv").show();
    //                     $("#SelectHalfDiv select").html(`<option value="-1">Select One</option>
    //             <option value="Second Half">Second Half</option>`);
    //                 }
    //                 else {
    //                     $("#SelectHalfDiv").hide();
    //                 }
    //             });
    //         }
    //         else if (data[data.findIndex(x => x.email == $(this).val())].leavetype == "Half Day" && data[data.findIndex(x => x.email == $(this).val())].leavehalf == "Second Half") {
    //             $("#Day").change(function () {
    //                 var MyDay = $('#Day').val();
    //                 if (MyDay == "Half Day") {
    //                     $("#SelectHalfDiv").show();
    //                     $("#SelectHalfDiv select").html(`<option value="-1">Select One</option>
    //             <option value="First Half">First Half</option>`);
    //                 }
    //                 else {
    //                     $("#SelectHalfDiv").hide();
    //                 }
    //             });
    //         }
    //     });
    // }
 
    $("#Day").change(function () {
        var Leave = $("#Leave").val();
        var Email = $("#Email").val();
        var MyDay = $('#Day').val();
        if (MyDay == "Half Day") {
            $("#SelectHalfDiv").show();
            if(data.some(x => x.email== Email && x.leave == Leave && x.leavehalf == 'First Half')){
                $("#Half").html("")
                $("#Half").html(`<option value="Select One">Select One</option><option value="Second Half">Second Half</option>`)
            }
            else if(data.some(x => x.email== Email && x.leave == Leave && x.leavehalf == 'Second Half'))
            {
                $("#Half").html("")
                $("#Half").html(`<option value="Select One">Select One</option><option value="First Half">First Half</option>`)
            }
            else{
                $("#Half").html("")
                $("#Half").html(`<option value="Select One">Select One</option><option value="First Half">First Half</option><option value="Second Half">Second Half</option>`)
            }
        }
        else {
            $("#SelectHalfDiv").hide();
        }
    });

    $("#Submit").click(function () {
        isValid = true;
        var Name = $("#Name").val();
        var Email = $("#Email").val();
        var DOB = $("#DOB").val();

        const today = new Date();
        const UserDate = new Date(DOB);
        var age = (parseInt(today.getFullYear()) - parseInt(UserDate.getFullYear()));

        var Leave = $("#Leave").val();
        var LeaveType = $("#Day").val();
        var LeaveHalf = $("#Half").val();

        if (Name == "") {
            $("#NameValidation").html("Name is Required");
            $("#NameValidation").css("color", "red");
            isValid = false;
        }
        else {
            $("#NameValidation").html("");
        }

        if (Email == "") {
            $("#EmailValidation").html("Email is Required");
            $("#EmailValidation").css("color", "red");
            isValid = false;
        }
        else if (!/[^\s@]+@[^\s@]+\.[^\s@]+/.test(Email)) {
            $("#EmailValidation").html("Enter Correct Email");
            $("#EmailValidation").css("color", "red");
            isValid = false;
        }
        else if (data.some(x => x.email == Email &&  x.leavehalf ==  LeaveHalf && x.leave == Leave)) {
            // data.some(x => x.leave == Leave) && data.some(x => x.leavehalf == LeaveHalf)
            $("#EmailValidation").html("This Email is Already registered");
            $("#EmailValidation").css("color", "red");
            isValid = false;
        }
        else {
            $("#EmailValidation").html("");
        }

        if (DOB == "") {
            $("#DOBValidation").html("Date of Birth is Required");
            $("#DOBValidation").css("color", "red");
            isValid = false;
        }
        else if (age < 18) {
            $("#DOBValidation").html("Age Must be Greater than 18");
            $("#DOBValidation").css("color", "red");
            isValid = false;
        }
        else {
            $("#DOBValidation").html("");
        }

        if (Leave == "") {
            $("#LeaveValidation").html("Plese Enter a Leave Date");
            $("#LeaveValidation").css("color", "red");
            isValid = false;
        }
        else {
            $("#LeaveValidation").html("");
        }

        if (LeaveType == "Select One") {
            $("#DayValidation").html("LeaveDay is Required");
            $("#DayValidation").css("color", "red");
            isValid = false;
        }
        else if (data.some(x => x.email == Email &&  x.leavehalf ==  LeaveHalf && x.leavetype == LeaveType)){
            $("#DayValidation").html("Leave is Already Taken");
            $("#DayValidation").css("color", "red");
            isValid = false;
        }
        else {
            $("#DayValidation").html("");
        }

        if (LeaveType == "Half Day") {
            if (LeaveHalf == "Select One") {
                $("#HalfValidation").html("DayHalf is Required");
                $("#HalfValidation").css("color", "red");
                isValid = false;
            }
        }
        else {
            $("#HalfValidation").html("");
        }

        if (LeaveType == "Full Day") {
            LeaveHalf = "-"
        }

        if (isValid) {
            obj = {
                index: ++counter,
                name: Name,
                email: Email,
                dob: DOB,
                leave: Leave,
                leavetype: LeaveType,
                leavehalf: LeaveHalf
            }
            data.push(obj)
            dt.row.add(obj).draw();
            $(".modal").modal('hide');
        }
    });
});

$(document).on("click", ".Delete", function () {
    alert("Do You Want to Delete record ?")
    var DeleteTempIndex = $(this).parents('tr').find('td:eq(1)').text();
    var DeleteIndex = data.findIndex(x => x.index == DeleteTempIndex);
    data.splice(DeleteIndex, 1);
    dt.clear().draw();
    dt.rows.add(data).draw();
});