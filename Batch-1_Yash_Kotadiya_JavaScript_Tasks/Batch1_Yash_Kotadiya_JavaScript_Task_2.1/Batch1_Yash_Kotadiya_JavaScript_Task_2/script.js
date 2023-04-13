chance = 6;

// Defined addBtn function
function addBtn() {
    let body = document.getElementById("body");
    let tr = document.createElement("tr");
    let insert_row = `<td scope="row" class="pt-3 first_td">${lastId()}</td>
    <td class="second_td"><input type="text" placeholder="Name" name="name" class="rounded-2 w-75 mt-1 p-1 first_input"></td>
    <td class="third_td"><input type="text" placeholder="Subject" name="subject" class="rounded-2 w-75 mt-1 p-1 second_input"></td>
    <td class="fourth_td"><input type="text" placeholder="Mark" name="mark" class="rounded-2 w-75 mt-1 p-1 third_input"></td>
    <td scope="col" class="fifth_td"><button type="button" class="btn btn-outline-success">Pass</button>&nbsp;&nbsp;<button type="button" class="btn btn-outline-danger">Fail</button></td>
    <td><button onclick="return removeBtn(this)" class="btn btn-outline-warning">Remove</button></td>`
    tr.innerHTML = insert_row;
    body.appendChild(tr);
}

// Defined RemoveBtn function

function removeBtn(e) {
    var user = confirm("Do you want to delete the record ?")
    if (user) {
        e.parentElement.parentElement.remove();
        index();
        alert("Your record have deleted successfully.");
        return true;
    }
    else {
        alert("Your record have not deleted.");
        return false;
    }
}

function lastId() {
    return document.getElementById("first_table").rows.length;
}

function index() {
    Array.from(document.getElementsByClassName("first_td")).forEach((e, index) => {
        e.innerHTML = index + 1;
    });
}


// Defined Submit function

document.getElementById('myform').addEventListener('submit', (e) => {
    e.preventDefault();

    flag1 = 0;
    flag2 = 0;
    flag3 = 0;

    // call the validate function
    validate();

    // call the searchBar function
    searchBar();
});

// defined validate function

function validate() {

    document.myform.name.forEach(element => {
        var reg = /^[a-zA-Z\-]+$/
        var n = RegExp(reg).test(element.value);

        if ((element.value == "" || !n) && flag1 == 0) {
            element.value = "";
            alert("Invalid Name");
            flag1 = 1;
            return false;
        }
    });

    document.myform.subject.forEach(element => {
        var reg = /^[a-zA-Z\-]+$/
        var n = RegExp(reg).test(element.value);
        if ((element.value == "" || !n) && flag2 == 0) {
            element.value = "";
            alert("Invalid Subject");
            flag2 = 1;
            return false;
        }
    });

    document.myform.mark.forEach(element => {
        if ((element.value == "" || element.value < 0 || element.value > 100 || isNaN(element.value)) && flag3 == 0) {
            element.value = "";
            alert("Please Enter the valid marks");
            flag3 = 1;
            return false;
        }
    });
}

// defined searchBar function

function searchBar() {
    if (flag1 == 0 && flag2 == 0 && flag3 == 0) {

        var div1 = document.createElement("div");
        div1.classList.add("container");
        div1.classList.add("mt-2");

        var form = document.createElement("form");
        form.classList.add("d-flex");

        var inp = document.createElement("input");
        inp.classList.add("form-control");
        inp.classList.add("mt-2");
        inp.setAttribute("placeholder", "Search");
        inp.setAttribute("aria-label", "Search");
        inp.setAttribute("id", "myinput");
        inp.setAttribute("onkeyup", "filterFunction()");

        var select = document.createElement("select");
        select.classList.add("select");
        select.setAttribute('onchange', "sortFunction(this)");
        var option0 = document.createElement("option");
        option0.innerHTML = "Sort By";
        var option1 = document.createElement("option");
        option1.innerHTML = "Name";
        var option2 = document.createElement("option");
        option2.innerHTML = "Subject";

        select.appendChild(option0);
        select.appendChild(option1);
        select.appendChild(option2);
        div1.appendChild(select);
        form.appendChild(inp);
        div1.appendChild(form);

        // Create a table 

        var div = document.createElement("div");
        div.classList.add("container");
        div.classList.add("mt-4");

        var table = document.createElement("table");
        table.classList.add("table");
        table.classList.add("table-bordered");
        table.classList.add("table-light");
        table.classList.add("table-hover");
        table.classList.add("text-center");
        table.classList.add("main");
        table.setAttribute("id", "mytable");

        var thead = document.createElement("thead");
        thead.classList.add("thead");
        table.appendChild(thead);

        var tr = document.createElement("tr");
        tr.classList.add("first");
        thead.appendChild(tr);

        var td1 = document.createElement("td");
        td1.innerHTML = "Sr-No.";

        var td2 = document.createElement("td");
        td2.innerHTML = "Name";

        var td3 = document.createElement("td");
        td3.innerHTML = "Subject";

        var td4 = document.createElement("td");
        td4.innerHTML = "Marks";

        var td5 = document.createElement("td");
        td5.innerHTML = "Result";

        tr.appendChild(td1);
        tr.appendChild(td2);
        tr.appendChild(td3);
        tr.appendChild(td4);
        tr.appendChild(td5);

        div.appendChild(table);
        document.getElementById('report').innerHTML = div1.outerHTML + div.outerHTML;

        // Show the data into the table

        var a = document.getElementsByClassName("first_td");

        var b = document.getElementsByClassName("second_td");
        b = document.querySelectorAll(".first_input");

        var c = document.getElementsByClassName("third_td");
        c = document.querySelectorAll(".second_input");

        var d = document.getElementsByClassName("fourth_td");
        d = document.querySelectorAll(".third_input");

        var g = document.getElementsByClassName("fifth_td");

        var table = document.querySelector(".main");
        var body = table.createTBody();

        for (var i = 0; i < a.length; i++) {
            const e = a[i];
            const f = b[i].value;
            const g = c[i].value;
            const h = d[i].value;
            const x = a[i];

            var new_tr = body.insertRow();
            var new_td1 = new_tr.insertCell();
            new_td1.innerHTML = e.innerHTML;

            var new_td2 = new_tr.insertCell();
            new_td2.innerHTML = f;

            var new_td3 = new_tr.insertCell();
            new_td3.innerHTML = g;

            var new_td4 = new_tr.insertCell();
            new_td4.innerHTML = h;

            var new_td5 = new_tr.insertCell();
            new_td5.innerHTML = x;

            if (h >= 33) {
                new_tr.style.color = "green";
                new_td5.innerHTML = "Pass";
            }

            if (h < 33) {
                new_tr.style.color = "red";
                new_td5.innerHTML = "Fail";
            }
        }
    }
}

function filterFunction() {
    var input, filter, table, tr1, td, td6, a, txtValue, txtValue2;
    input = document.getElementById("myinput");
    filter = input.value.toUpperCase();
    table = document.getElementById("mytable");
    tr1 = table.getElementsByTagName("tr");

    for (a = 0; a < tr1.length; a++) {
        td = tr1[a].getElementsByTagName("td")[1];
        td6 = tr1[a].getElementsByTagName("td")[2];
        if (td) {
            txtValue = td.textContent || td.innerText;
            txtValue2 = td6.textContent || td6.innerText;
            if (txtValue.toUpperCase().indexOf(filter) > -1) {
                tr1[a].style.display = "";
            }
            else if (txtValue2.toUpperCase().indexOf(filter) > -1) {
                tr1[a].style.display = "";
            }
            else {
                tr1[a].style.display = "none";
            }
        }
    }
}

function sortFunction(element) {
    var table, rows, switching, i, x, y, shouldSwitch;
    table = document.getElementById("mytable");
    switching = true;

    while (switching) {
        switching = false;
        rows = table.rows;
        for (i = 1; i < (rows.length - 1); i++) {
            shouldSwitch = false;
            if (element.value == "Name") {
                x = rows[i].getElementsByTagName("td")[1];
                y = rows[i + 1].getElementsByTagName("td")[1];
            }
            else {
                x = rows[i].getElementsByTagName("td")[2];
                y = rows[i + 1].getElementsByTagName("td")[2];
            }
            if (x.innerHTML.toLowerCase() > y.innerHTML.toLowerCase()) {
                shouldSwitch = true;
                break;
            }
        }
        if (shouldSwitch) {
            rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
            switching = true;
        }
    }
}



