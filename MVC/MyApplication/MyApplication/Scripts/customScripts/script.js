////$('#submit').click(function (e) {
////    e.preventDefault();
////    var userid = $("#UserId").val();
////    var username = $("#UserName").val();
////    var useremail = $("#UserEmail").val();
////    var useraddress = $("#UserAddress").val();
////    var usercity = $("#UserCity").val();
////    var userpincode = $("#UserPinCode").val();
////    var regname = /^[a-zA-Z]+ [a-zA-Z]+$/;
////    var emailregex = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
////    var pinregexpattern = /^\d{6}$/;
////    var isvalid = true;

////    if (userid == null || userid == "") {
////        $("#idValidate").html("Userid is requried");
////        $("#idValidate").css("color", "red");
////        isvalid = false;
////    }
////    else {
////        $("#idValidate").html("");
////    }

////    if (!regname.test(username)) {
////        $("#UserNameValidate").html("Name is requried");
////        $("#UserNameValidate").css("color", "red");
////        isvalid = false;
////    }
////    else {
////        $("#UserNameValidate").html("");
////    }

////    if (!emailregex.test(useremail)) {
////        $("#UseremailValidate").html("Email is requried");
////        $("#UseremailValidate").css("color", "red");
////        isvalid = false;
////    }
////    else {
////        $("#UseremailValidate").html("");
////    }

////    if (useraddress == null || useraddress == "") {
////        $("#UseraddressValidate").html("Address is requried");
////        $("#UseraddressValidate").css("color", "red");
////        isvalid = false;
////    }
////    else {
////        $("#UseraddressValidate").html("");
////    }

////    if (usercity == null || usercity == "") {
////        $("#UserCityValidate").html("City is requried");
////        $("#UserCityValidate").css("color", "red");
////        isvalid = false;
////    }
////    else {
////        $("#UserCityValidate").html("");
////    }

////    if (!pinregexpattern.test(userpincode)) {
////        $("#UserPinCodeValidate").html("PinCode is requried");
////        $("#UserPinCodeValidate").css("color", "red");
////        isvalid = false;
////    }
////    else {
////        $("#UserPinCodeValidate").html("");
////    }

////    if (isvalid) {
////        e.preventDefault();
////        Swal.fire({
////            title: 'Are you sure want to submit the data ?',
////            showDenyButton: true,
////            /*   showCancelButton: true,*/
////            confirmButtonText: 'Save',
////            denyButtonText: `Don't save`,
////            html: ` <b>UserId</b> : ${userid} </br>
////                    <b>Name</b> : ${username} </br>
////                    <b>Email</b> : ${useremail} </br>
////                    <b>Address</b> : ${useraddress} </br>
////                    <b>City</b> : ${usercity} </br>
////                    <b>PinCode</b> : ${userpincode}`
////        }).then((result) => {
////            /* Read more about isConfirmed, isDenied below */
////            if (result.isConfirmed) {
////                Swal.fire('Saved!', '', 'success').then((result) => {
////                    $('#Contact_Form').submit();
////                })
////            } else if (result.isDenied) {
////                Swal.fire('Changes are not saved', '', 'error')
////            }
////        })
////    }

////});