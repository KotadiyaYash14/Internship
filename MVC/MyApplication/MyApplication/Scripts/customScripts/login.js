var myForm = document.getElementById("myForm");
myForm.addEventListener("submit", function (e) {
    e.preventDefault();
    var name = document.getElementById("name").value;
    var password = document.getElementById("password").value;
    var loginregname = /^[a-zA-Z]+ [a-zA-Z]+$/;
    var flag = 1;

    if (name == null || name == "" || !loginregname.test(name)) {
        document.getElementById("nameValidate").innerHTML = "Name is requered";
        myForm.nametxt.focus();
        flag = 0;
    }
    else {
        document.getElementById("nameValidate").innerHTML = "";
    }

    if (password == null || password == "" || password.length <= 6) {
        document.getElementById("PasswordValidate").innerHTML = "Password must be at least 6 characters long.";
        myForm.passwordtxt.focus();
        flag = 0;
    }
    else {
        document.getElementById("PasswordValidate").innerHTML = "";
    }

    if (flag) {
        window.location.href = "/home/index";
    }
});