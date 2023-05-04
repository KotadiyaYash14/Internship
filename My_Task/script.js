var dt;
var counter = 0;
var data = [];
var obj;
var StudentObj
var EditIndex;
var NewState, NewCity;

var Country = [
    { id: 1, text: 'India' },
    { id: 2, text: 'USA' }
]
var State = [
    { id: 1, text: 'Gujarat', Countryid: 1 },
    { id: 2, text: 'Rajasthan', Countryid: 1 },
    { id: 3, text: 'Califorina', Countryid: 2 },
    { id: 4, text: 'Florida', Countryid: 2 }
]
var City = [
    { id: 1, text: 'Siddhpur', Stateid: 1, Countryid: 1 },
    { id: 2, text: 'Junagadh', Stateid: 1, Countryid: 1 },
    { id: 3, text: 'Jaipur', Stateid: 2, Countryid: 1 },
    { id: 4, text: 'Udaipur', Stateid: 2, Countryid: 1 },
    { id: 5, text: 'Las Angles', Stateid: 3, Countryid: 2 },
    { id: 6, text: 'San Jose', Stateid: 3, Countryid: 2 },
    { id: 7, text: 'Miami', Stateid: 4, Countryid: 2 },
    { id: 8, text: 'Tampa', Stateid: 4, Countryid: 2 }
]
$(document).ready(function () {
    dt = $("#myTable").DataTable({
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
                data: "name",
            },
            {
                title: "Email",
                data: "email"
            },
            {
                title: "Contact Number",
                data: "contactnumber"
            },
            {
                title: "DOB",
                data: "dob"
            },
            {
                title: "Degree",
                data: "degree",
                defaultContent: "BE,IT",
            },
            {
                title: "Address",
                data: "address",
            },
            {
                title: "Action",
                data: null,
                defaultContent: `<button class="btn btn-outline-success Edit" data-bs-target="#myModal"
                data-bs-toggle="modal">Edit</button>&nbsp;&nbsp;<button class="btn btn-outline-danger Delete">Delete</button>&nbsp;&nbsp;
                <button class="btn btn-outline-secondary mt-2 add2" data-bs-target="#mySecondModal" data-bs-toggle="modal">Add Subjects</button>`,
            }
        ]
    });

    $(document.body).on('click', '#Add', function () {
        $(".modal-body input").val("");
        $(".Update").hide();
        $("#Submit").show();
        $(".error").html("")
    });

    $("#Submit").click(function () {
        isValid = true;
        var Name = $("#Name").val();
        var Email = $("#Email").val();
        var MyNumber = $("#Number").val();
        var DOB = $("#Date").val();

        if (Name == "") {
            $("#NameValidation").html("Name can't be Blank");
            $("#NameValidation").css("color", "red");
            isValid = false;
        }
        else if (!/^[A-Za-z]+$/.test(Name)) {
            $("#NameValidation").html("Name can't Contains Digits");
            $("#NameValidation").css("color", "red");
            isValid = false;
        }
        else {
            $("#NameValidation").html("");
        }

        if (Email == "") {
            $("#EmailValidation").html("Email can't be Blank");
            $("#EmailValidation").css("color", "red");
            isValid = false;
        }
        else if (!/[^\s@]+@[^\s@]+\.[^\s@]+/.test(Email)) {
            $("#EmailValidation").html("Enter Correct Email");
            $("#EmailValidation").css("color", "red");
            isValid = false;
        }
        else {
            $("#EmailValidation").html("");
        }

        if (MyNumber == "") {
            $("#NumberValidation").html("Contact Number can't be Blank");
            $("#NumberValidation").css("color", "red");
            isValid = false;
        }

        else if ((MyNumber.length > 10) || (MyNumber.length < 10)) {
            $("#NumberValidation").html("Contact Number Should be 10 Digits");
            $("#NumberValidation").css("color", "red");
            isValid = false;
        }
        else {
            $("#NumberValidation").html("");
        }

        if (DOB == "") {
            $("#DateValidation").html("Provide Your Birthdate");
            $("#DateValidation").css("color", "red");
            isValid = false;
        }
   
        else {
            $("#DateValidation").html("");
        }

        if (isValid) {
            var CountryName = Country.find(x => x.id == $("#Country").val()).text;
            var StateName = NewState.find(x => x.id == $("#State").val()).text;
            var CityName = NewCity.find(x => x.id == $("#City").val()).text;

            obj = {
                index: ++counter,
                name: Name,
                email: Email,
                contactnumber: MyNumber,
                dob: DOB,
                address: CountryName + "," + StateName + "," + CityName,
                Student: []
            }
            data.push(obj);
            dt.row.add(obj).draw();
            $(".modal").modal('hide');
            LowerTable();
        }
    });

    // $("#Degree").change(function () {
    //     $("#DegreeType").html("");
    //     var degree = $("#Degree").val();
    //     DegreeType.forEach((ele) => {
    //         if (ele.degreeID == degree) {
    //             $("#DegreeType").append(`<option value="${ele.degreeTypeName}">${ele.degreeTypeName}</option>`)
    //         }
    //     });
    // });

    $('#Country').select2({
        data: Country,
        placeholder: "Select Country",
        width: 460
    })

    $('#State').select2({
        data: ``,
        placeholder: "Select State",
        width: 460
    })

    $('#City').select2({
        data: ``,
        placeholder: "Select City",
        width: 460,
    })
});

$(document).on("change", "#Country", function () {
    NewState = State.filter(x => x.Countryid == $("#Country").val());
    $('#City').select2({
        data: [],
        placeholder: "Select City",
        width: 460
    })
    $('#State').select2({
        data: NewState,
        placeholder: "Select State",
        width: 460
    })

});

$(document).on("change", "#State", function () {
    NewCity = City.filter(x => x.Stateid == $("#State").val());
    $('#City').select2({
        data: NewCity,
        placeholder: "Select City",
        width: 460
    })
});

$('body').on('click', '.Delete', function () {
    alert("Do You Want to Delete the Record ?");
    var DeleteTempIndex = $(this).parents('tr').find('td:eq(1)').text();
    var DeleteIndex = data.findIndex(x => x.index == DeleteTempIndex);
    data.splice(DeleteIndex, 1);
    dt.clear().draw();
    dt.rows.add(data).draw();
});

$('body').on('click', '.Edit', function () {
    $("#Submit").hide();
    $(".Update").show();
    $("#Name").val($(this).parents('tr').find('td:eq(2)').text());
    $("#Email").val($(this).parents('tr').find('td:eq(3)').text());
    $("#Number").val($(this).parents('tr').find('td:eq(4)').text());
    $("#Date").val($(this).parents('tr').find('td:eq(5)').text());
    var EditTempIndex = $(this).parents('tr').find('td:eq(1)').text();
    EditIndex = data.findIndex(x => x.index == EditTempIndex);
    LowerTable();
})

$(document).on('click', '.Update', function () {
    data[EditIndex].name = $("#Name").val();
    data[EditIndex].email = $("#Email").val();
    data[EditIndex].contactnumber = $("#Number").val();
    data[EditIndex].dob = $("#Date").val();
    var CountryName = Country.find(x => x.id == $("#Country").val()).text;
    var StateName = NewState.find(x => x.id == $("#State").val()).text;
    var CityName = NewCity.find(x => x.id == $("#City").val()).text;
    data[EditIndex].address = CountryName + "," + StateName + "," + CityName;
    dt.clear().draw();
    dt.rows.add(data).draw();
    LowerTable();
});

function LowerTable() {
    $('.dt-control').off().click(function () {
        var tr = $(this).closest('tr');
        var row = dt.row(tr);

        if (row.child.isShown()) {
            tr.removeClass('details');
            row.child.hide();
        } else {
            tr.addClass('details');
            row.child(format(row.data().Student)).show();
        }
    });

    $("#Save").off().click(function () {
        var Subject = $("#Subject").val();
        var Department = $("#Department").val();
        isValid = true;
        if (Subject == "") {
            $("#SubjectValidation").html("Subject can't be Blank");
            $("#SubjectValidation").css("color", "red");
            isValid = false;
        }
        else {
            $("#SubjectValidation").html("");
        }

        if (Department == "") {
            $("#DepartmentValidation").html("Department can't be Blank");
            $("#DepartmentValidation").css("color", "red");
            isValid = false;
        }
        else {
            $("#DepartmentValidation").html("");
        }

        if (isValid) {
            StudentObj = {
                StudentSubject: Subject,
                StudentDepartment: Department
            }
            obj.Student.push(StudentObj);
            $(".modal2").modal('hide');
        }
    });

    function format(d) {
        var table = `<table><thead><tr><th>Subject</th><th>Department</th></tr></thead><tbody>`
        d.forEach(element => {
            table += `<tr><td>${element.StudentSubject}</td><td>${element.StudentDepartment}</td></tr>`
        });
        table += `</tbody></table>`
        return table;
    }

    $(".add2").off().click(function () {
        $(".error").html("");
        $(".modal-body input").val("");  
    });
}