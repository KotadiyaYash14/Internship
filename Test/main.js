/////////// Declare Global Variable ///////////
var dataTable, editTempIndex, editIndex;
var data = [];
var counter = 0;
var obj;

/////////// Initialize DataTable ///////////
$(document).ready(function () {
    dataTable = $('#data_table').DataTable({
        data: data,
        /////////// DataTable Fileds ///////////
        columns: [
            {
                title: '',
                data: null,
                defaultContent: '',
                class: 'dt-control'
            },
            {
                title: 'index',
                data: 'index',
                class: 'displaynone'
            },
            {
                title: 'email',
                data: 'Email',
                class: 'displaynone'
            },
            {
                title: 'city',
                data: 'city',
                class: 'displaynone'
            },
            {
                title: 'country',
                data: 'country',
                class: 'displaynone'
            },
            {
                title: 'state',
                data: 'state',
                class: 'displaynone'
            },
            {
                title: 'Name',
                data: 'Name',
            },
            {
                title: 'Age',
                data: 'DOB'
            },
            {
                title: 'ContactNumber',
                data: 'ContactNo'
            },
            {
                title: 'Address',
                data: 'address'
            },
            {
                title: 'Action',
                data: null,
                defaultContent: `<button class="btn btn-outline-primary treatment_btn">Add Treatment</button><div><button class="btn btn-outline-success edit_btn mt-2" data-bs-toggle="modal" data-bs-target="#add_patient_modal">Edit</button>&nbsp;&nbsp;<button class="btn btn-outline-danger delete_btn mt-2">Delete</button></div>`
            }
        ]
    });
    clickevent();
});

function clickevent() {
    /////////// State Validation ///////////
    $('#patient_country').off().change(function () {
        var patientCountry = $('#patient_country').val();
        if (patientCountry == 'India') {
            $('.stateguj').show();
            $('.stateparis').hide();
            $('.statechinatown').hide();
        }
        else if (patientCountry == 'USA') {
            $('.stateguj').hide();
            $('.stateparis').show();
            $('.statechinatown').hide();
        }
        else if (patientCountry == 'China') {
            $('.stateguj').hide();
            $('.stateparis').hide();
            $('.statechinatown').show();
        }
    });

     /////////// City Validation ///////////
    $('#patient_state').off().change(function () {
        var patientState = $('#patient_state').val();

        if (patientState == 'Gujarat') {
            $('.citysid').show();
            $('.cityparis').hide();
            $('.chinatown').hide();
        }
        else if (patientState == 'Florida') {
            $('.citysid').hide();
            $('.cityparis').show();
            $('.chinatown').hide();
        }
        else if (patientState == 'Sanghai') {
            $('.citysid').hide();
            $('.cityparis').hide();
            $('.chinatown').show();
        }
    });

    /////////// Show Treatment Modal ///////////
    $('.treatment_btn').off().click(function () {
        $('.modal2').show();
    });;
    
    /////////// Close Treatment Modal ///////////
    $('#modal2_close').off().click(function () {
        $('.modal2').hide();
    });

    /////////// Call a deleteDataInArray when delete button is clicked  ///////////
    $('.delete_btn').off().click(function () {
        alert("Do You Want to Delete the Record ?");
        deleteDataInArray(this);
    });

    /////////// Call a showDataInForm when edit button is clicked ///////////
    $('.edit_btn').off().click(function () {
        showDataInForm(this);
        $('#update_data').show();
        $('#save_patient_data').hide();
    });

    /////////// Update Data in Array ///////////
    $('#update_data').off().click(function () {
        editDataInArray();
        $('#update_data').hide();
        $('#save_patient_data').show();
        $('#patient_email').val('');
        $('#patient_city').val('');
        $('#patient_country').val('');
        $('#patient_state').val('');
        $('#patient_name').val('');
        $('#patient_dob').val('');
        $('#patient_number').val('');
    });

    /////////// Close Treatment Modal ///////////
    $('.a').off().click(function () {
        $(".modal2").hide();
    });
    
    /////////// Hide Show Plus and Minus Icon in DataTable ///////////
    $('.dt-control').off().click(function () {
        var tr = $(this).closest('tr')
        var row = dataTable.row(tr)

        if (row.child.isShown()) {
            tr.removeClass('details')
            row.child.hide();
        }
        else {
            tr.addClass('details')
            row.child(format(row.data().treatment)).show();
        }
    });

    $('#update_data').hide();
    $('#save_patient_data').show();
    $('.stateguj').hide();
    $('.stateparis').hide();
    $('.statechinatown').hide();
    $('.citysid').hide();
    $('.cityparis').hide();
    $('.chinatown').hide();
}

/////////// Add Data in Array ///////////
function addDataInArray() {
    var patientName = $('#patient_name').val();
    var patientDOB = $('#patient_dob').val();

    const today = new Date();
    today.getFullYear();
    const dob = new Date(patientDOB);
    dob.getFullYear();
    var dif = parseInt(today.getFullYear()) - parseInt(dob.getFullYear());

    var patientEmail = $('#patient_email').val();
    var patientNumber = $("#patient_number").val();
    var patientCountry = $('#patient_country').val();
    var patientState = $('#patient_state').val();
    var patientCity = $('#patient_city').val();
    // var patientGender = $('.gender').prop('checked');
    var address = patientCity + ',' + patientState + ',' + patientCountry;

    obj = {
        index: ++counter,
        Name: patientName,
        DOB: dif,
        Email: patientEmail,
        country: patientCountry,
        city: patientCity,
        state: patientState,
        ContactNo: patientNumber,
        address: address,
        treatment: []
    }
    data.push(obj)
    addDataInTable(data);
}

/////////// Add Data in Table ///////////
function addDataInTable(array) {
    dataTable.clear().draw();
    dataTable.rows.add(array).draw();
    clickevent();
}

/////////// First Modal Validation ///////////
$('#save_patient_data').off().click(function () {
    isValid = true;
    if ($("#patient_name").val() == "") {
        $("#name").html("Name can't be blank");
        $("#name").css("color", "red");
        isValid = false;
    }
    if(!/^[A-Za-z]+$/.test($("#patient_name").val())){
        $("#name").html("Name can't Contains Digits");
        $("#name").css("color", "red");
        isValid = false;
    }
    else{
        $("#name").html("");
    }

    var dob =  $("#patient_dob").val()
    const a = new Date(dob);
    a.getFullYear();

    if(dob == ""){
        $("#dob").html("Please Enter Date");
        $("#dob").css("color", "red");
        isValid = false;
    }

    if(a.getFullYear() > 2007){
        $("#dob").html("Minimum Age Shold be 15");
        $("#dob").css("color", "red");
        isValid = false;
    }
    else{
        $("#dob").html("");
    }

    if($("#patient_email").val() == "" || !/[^\s@]+@[^\s@]+\.[^\s@]+/.test($("#patient_email").val())){
        $("#mail").html("Enter Correct Email");
        $("#mail").css("color", "red");
        isValid = false;
    }
    else{
        $("#mail").html("");
    }

    var n = $("#patient_number").val()
    if(n == ""){
        $("#phone").html("Enter Correct Phone Number");
        $("#phone").css("color", "red");
        isValid = false;
    }
    if((n.length > 10) || (n.length < 10)){
        $("#phone").html("Enter 10 digit Phone Number");
        $("#phone").css("color", "red");
        isValid = false;
    }
    else{
        $("#phone").html("");
    }

    if(isValid){
      addDataInArray();
      $('#update_data').hide();
      $('#save_patient_data').show();
      $('#patient_email').val('');
      $('#patient_city').val('');
      $('#patient_country').val('');
      $('#patient_state').val('');
      $('#patient_name').val('');
      $('#patient_dob').val('');
      $('#patient_number').val('');
      $('.modal').modal('hide');
    }
});

/////////// Delete Data in Array ///////////
function deleteDataInArray(ele) {
    var deleteTempIndex = $(ele).parents('tr').find('td:eq(1)').text();
    var deleteIndex = data.findIndex(x => x.index == deleteTempIndex);
    data.splice(deleteIndex, 1);
    addDataInTable(data);
}

/////////// Show Data in Form When Edit Button Clicked ///////////
function showDataInForm(ele) {
    $('#patient_email').val($(ele).parents('tr').find('td:eq(2)').text());
    $('#patient_city').val($(ele).parents('tr').find('td:eq(3)').text());
    $('#patient_country').val($(ele).parents('tr').find('td:eq(4)').text());
    $('#patient_state').val($(ele).parents('tr').find('td:eq(5)').text());
    $('#patient_name').val($(ele).parents('tr').find('td:eq(6)').text());
    $('#patient_dob').val($(ele).parents('tr').find('td:eq(7)').text());
    $('#patient_number').val($(ele).parents('tr').find('td:eq(8)').text());
    editTempIndex = $(ele).parents('tr').find('td:eq(1)').text();
    editIndex = data.findIndex(x => x.index == editTempIndex);
}

/////////// Edit Data in Array ///////////
function editDataInArray() {
    var patientCountry = $('#patient_country').val();
    var patientState = $('#patient_state').val();
    var patientCity = $('#patient_city').val();
    var address = patientCity + ',' + patientState + ',' + patientCountry;
    data[editIndex].Name = $('#patient_name').val()

    const today = new Date();
    today.getFullYear();
    DOB = $('#patient_dob').val();
    const dob = new Date(DOB);
    dob.getFullYear();
    var dif = parseInt(today.getFullYear()) - parseInt(dob.getFullYear());
    data[editIndex].DOB = dif
    
    data[editIndex].Email = $('#patient_email').val()
    data[editIndex].country = $('#patient_country').val()
    data[editIndex].city = $('#patient_city').val()
    data[editIndex].state = $('#patient_state').val()
    data[editIndex].ContactNo = $('#patient_number').val()
    data[editIndex].address = address
    addDataInTable(data);
}

/////////// Show a Second Table When plus icon clicked ///////////
function format(d) {
    var str = `<table><thead><tr><th>Disease</th><th>Doctor</th><th>Medicine</th><th>Follow up date</th></tr></thead><tbody>`
    d.forEach(element => {
        str += `<tr><td>${element.disease}</td><td>${element.doctor}</td><td>${element.medicine}</td><td>${element.followUp}</td></tr>`
    });
    str += `</tbody></table>`
    return str
}

/////////// Second Modal Validation ///////////
$('#save_treatment').off().click(function () {
    isValid = true;
    if ($("#dis").val() == "") {
        $("#desease").html("Enter Correct Desease Name");
        $("#desease").css("color", "red");
        isValid = false;
    }
    else{
        $("#desease").html("");
    }

    if ($("#doc").val() == "") {
        $("#doctor").html("Enter Correct Doctor Name");
        $("#doctor").css("color", "red");
        isValid = false;
    } 
    if(!/^[a-zA-Z ]+$/.test($("#doc").val())){
        $("#doctor").html("Doctor Name can't Contains Digits");
        $("#doctor").css("color", "red");
        isValid = false;
    }
    else{
        $("#doctor").html("");
    }

    if ($("#med").val() == "") {
        $("#medicine").html("Enter Correct Medicine Name");
        $("#medicine").css("color", "red");
        isValid = false;
    }
    else{
        $("#medicine").html("");
    }

    if($("#fud").val() == ""){
        $("#fud_1").html("Please Enter Date");
        $("#fud_1").css("color", "red");
        isValid = false;
    }

    else{
        $("#fud_1").html("");
    }

    /////////// Show Data in Second Table ///////////
    if(isValid){
        var deseaseName = $('.desease_name');
        var doctorName = $('.doctor_name');
        var medicineName = $('.Medicine_name');
        var followUpDate = $('.follow_up_date');

        Array.from(deseaseName).forEach((ele, index) => {
            obj.treatment.push({
                disease: ele.value,
                doctor: doctorName[index].value,
                medicine: medicineName[index].value,
                followUp: followUpDate[index].value
            });
        });
        $(".modal2").hide();
        $("#modal2_body input").val('');
    }
});

