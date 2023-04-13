chance = 6;

// addBtn logic start
function addBtn() {
    let body = document.getElementById("body");
    let tr = document.createElement("tr");
    let insert_row = `<td scope="row" class="pt-3 first_td">${lastIndexId()}</td>
    <td class="second_td"><input type="text" placeholder="Name" name="name" class="rounded-2 w-75 mt-1 p-1 first_input"></td>
    <td class="third_td"><input type="text" placeholder="Subject" name="subject" class="rounded-2 w-75 mt-1 p-1 second_input"></td>
    <td class="fourth_td"><input type="text" placeholder="Mark" name="mark" class="rounded-2 w-75 mt-1 p-1 third_input"></td>
    <td scope="col" class="fifth_td"><button type="button" class="btn btn-outline-success" onclick="passBtn(this)">Pass</button>&nbsp;&nbsp;<button type="button" class="btn btn-outline-danger" onclick="failBtn(this)">Fail</button></td>
    <td><button onclick="return removeBtn(this)" class="btn btn-outline-warning">Remove</button></td>`
    tr.innerHTML = insert_row;
    body.appendChild(tr);
}
// addBtn logic end

// RemoveBtn logic start

function removeBtn(element) {
    var user = confirm("Do you want to delete the record ?")
    if (user) {
        element.parentElement.parentElement.remove();
        index();
        // alert("Your record have deleted successfully.");
        return true;
    }
    else {
        // alert("Your record have not deleted.");
        return false;
    }
}
// RemoveBtn logic end

// serial number logic start

function lastIndexId() {
    return document.getElementById("first_table").rows.length;
}

function index() {
    Array.from(document.getElementsByClassName("first_td")).forEach((element, index) => {
        element.innerHTML = index + 1;
    });
}

// serial number logic end

//  Submit buttton logic start

document.getElementById("myform").addEventListener("submit", (element) => {
    element.preventDefault();

    flag1 = 0;
    flag2 = 0;
    flag3 = 0;

    // call the validate function
    validate();

    // call the searchBar function
    searchBar();
});

//  Submit buttton logic end

//  validate function logic start
function validate() {
    document.myform.name.forEach(element => {
        var reg = /^[a-zA-Z\-]+$/
        var n = RegExp(reg).test(element.value);

        if ((element.value == "" || !n) && flag1 == 0) {
            alert("Invalid Name");
            flag1 = 1;
            return false;
        }
    });

    document.myform.subject.forEach(element => {
        var reg = /^[a-zA-Z\-]+$/
        var n = RegExp(reg).test(element.value);
        if ((element.value == "" || !n) && flag2 == 0) {
            alert("Invalid Subject");
            flag2 = 1;
            return false;
        }
    });

    document.myform.mark.forEach(element => {
        if ((element.value == "" || element.value < 0 || element.value > 100 || isNaN(element.value)) && flag3 == 0) {
            alert("Please Enter the valid marks");
            flag3 = 1;
            return false;
        }
    });
}
//  validate function logic end

// searchBar function logic start

function searchBar() {
    if (flag1 == 0 && flag2 == 0 && flag3 == 0) {

        // create a dropdown buttton and searchbar

        var upperDiv = document.createElement("div");
        upperDiv.classList.add("container");
        upperDiv.classList.add("mt-2");

        var form = document.createElement("form");
        form.classList.add("d-flex");

        var searchInp = document.createElement("input");
        searchInp.classList.add("form-control");
        searchInp.classList.add("mt-2");
        searchInp.setAttribute("placeholder", "Search");
        searchInp.setAttribute("aria-label", "Search");
        searchInp.setAttribute("id", "myinput");
        searchInp.setAttribute("onkeyup", "filterFunction()");

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
        upperDiv.appendChild(select);
        form.appendChild(searchInp);
        upperDiv.appendChild(form);

        // Create a result table 

        var lowerDiv = document.createElement("div");
        lowerDiv.classList.add("container");
        lowerDiv.classList.add("mt-4");

        var resultTable = document.createElement("table");
        resultTable.classList.add("table");
        resultTable.classList.add("table-bordered");
        resultTable.classList.add("table-light");
        resultTable.classList.add("table-hover");
        resultTable.classList.add("text-center");
        resultTable.classList.add("shadow");
        resultTable.classList.add("main");
        resultTable.setAttribute("id", "mytable");

        var resultHead = document.createElement("thead");

        var resultTr = document.createElement("tr");
        resultTr.classList.add("first");
        resultHead.appendChild(resultTr);

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

        resultTr.appendChild(td1);
        resultTr.appendChild(td2);
        resultTr.appendChild(td3);
        resultTr.appendChild(td4);
        resultTr.appendChild(td5);

        resultTable.appendChild(resultHead);
        lowerDiv.appendChild(resultTable);
        document.getElementById('report').innerHTML = upperDiv.outerHTML + lowerDiv.outerHTML;

        // Show the data into the result table

        var a = document.getElementsByClassName("first_td");

        var b = document.getElementsByClassName("second_td");
        b = document.querySelectorAll(".first_input");

        var c = document.getElementsByClassName("third_td");
        c = document.querySelectorAll(".second_input");

        var d = document.getElementsByClassName("fourth_td");
        d = document.querySelectorAll(".third_input");

        var g = document.getElementsByClassName("fifth_td");
        g = document.querySelectorAll(".btn");

        var table = document.querySelector(".main");
        var body = table.createTBody();

        var count = 1;
        for (var i = 0; i < a.length; i++) {
            var activeBtn = document.getElementsByClassName("fifth_td")[i].querySelector('.active');
            if (!activeBtn) {
                continue;
            }
            if (!activeBtn.classList.contains("btn-outline-danger")) {
                const f = b[i].value;
                const g = c[i].value;
                const h = d[i].value;
                const k = g[i];

                var new_tr = body.insertRow();
                var new_td1 = new_tr.insertCell();
                new_td1.innerHTML = count;
                count++;

                var new_td2 = new_tr.insertCell();
                new_td2.innerHTML = f;

                var new_td3 = new_tr.insertCell();
                new_td3.innerHTML = g;

                var new_td4 = new_tr.insertCell();
                new_td4.innerHTML = h;

                var new_td5 = new_tr.insertCell();
                new_td5.innerHTML = k;

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
        // searchBar function logic end

        // Create a percentage table

        var resultDiv = document.createElement("div");
        resultDiv.classList.add("container");
        resultDiv.classList.add("mt-4");

        var resultTable = document.createElement("table");
        resultTable.classList.add("table");
        resultTable.classList.add("table-bordered");
        resultTable.classList.add("table-light");
        resultTable.classList.add("table-hover");
        resultTable.classList.add("text-center");
        resultTable.classList.add("shadow");
        resultTable.classList.add("main1");
        resultTable.setAttribute("id", "main1")

        var resultHead = document.createElement("thead");

        var resultTr = document.createElement("tr");
        resultHead.appendChild(resultTr);

        var td6 = document.createElement("td");
        td6.innerHTML = "Sr-No.";

        var td7 = document.createElement("td");
        td7.innerHTML = "Name";

        var td8 = document.createElement("td");
        td8.innerHTML = "Percentage";

        resultTr.appendChild(td6);
        resultTr.appendChild(td7);
        resultTr.appendChild(td8);

        var body = resultTable.createTBody();

        // logic for calculate a percentage

        var nameArray = [];
        var marksArray = [];
        var countArray = [];

        var tableBody = Array.from(document.getElementById("body").rows);
        for (let index = 0; index < tableBody.length; index++) {
            const tBody = tableBody[index];
            var nameValue = tBody.cells[1].querySelector("input");
            var activeBtn = document.getElementsByClassName("fifth_td")[index].querySelector('.active');
            // if (!activeBtn || (activeBtn && activeBtn.classList.contains("btn-outline-danger"))) {
            //     continue;
            // }
            if (!nameArray.includes(nameValue.value)) {
                nameArray.push(nameValue.value);
            }
            else {
                continue;
            }

            var totalMarks = 0;
            var counter = 0;
            tableBody.forEach((e, i) => {
                var activeBtn = document.getElementsByClassName("fifth_td")[i].querySelector('.active');
                if (!activeBtn || (activeBtn && activeBtn.classList.contains("btn-outline-danger"))) {

                }
                else {
                    var anotherNameValue = e.cells[1].querySelector("input");
                    var markValue = e.cells[3].querySelector("input")
                    if (nameValue.value == anotherNameValue.value) {
                        totalMarks += parseInt(markValue.value);
                        counter++;
                    }
                }
            })
            marksArray.push(totalMarks);
            countArray.push(counter);
        }

        for (let index = 0; index < marksArray.length; index++) {
            perTr = document.createElement("tr");
            perTd0 = document.createElement("td");
            perTd0.innerHTML = index + 1;
            perTd1 = document.createElement("td");
            perTd1.innerHTML = nameArray[index];
            perTd2 = document.createElement("td");
            perTd2.innerHTML = marksArray[index] / countArray[index] + "%";
            perTr.appendChild(perTd0)
            perTr.appendChild(perTd1)
            perTr.appendChild(perTd2)
            body.appendChild(perTr)
        }
        resultTable.appendChild(resultHead);
        resultDiv.appendChild(resultTable);
        document.getElementById("result").innerHTML = resultDiv.outerHTML;
    }
}

// filter function logic start
function filterFunction() {
    var input, filter, table, filterTr, filterTd1, filterTd2, a, txtValue1, txtValue2;
    input = document.getElementById("myinput");
    filter = input.value.toUpperCase();
    table = document.getElementById("mytable");
    filterTr = table.getElementsByTagName("tr");

    for (a = 0; a < filterTr.length; a++) {
        filterTd1 = filterTr[a].getElementsByTagName("td")[1];
        filterTd2 = filterTr[a].getElementsByTagName("td")[2];
        if (filterTd1) {
            txtValue1 = filterTd1.textContent || filterTd1.innerText;
            txtValue2 = filterTd2.textContent || filterTd2.innerText;
            if (txtValue1.toUpperCase().indexOf(filter) > -1) {
                filterTr[a].style.display = "";
            }
            else if (txtValue2.toUpperCase().indexOf(filter) > -1) {
                filterTr[a].style.display = "";
            }
            else {
                filterTr[a].style.display = "none";
            }
        }
    }
}

// filter function logic end


// sort function logic start

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

// sort function logic end


function passBtn(e) {
    if (e.classList.contains("btn-outline-success")) {
        e.style.backgroundColor = "#198754";
        e.style.color = "white";
        e.nextElementSibling.style = "none";
    }
    if (e.nextElementSibling.classList.contains("active")) {
        e.nextElementSibling.classList.remove("active")
    }
}

function failBtn(e) {
    if (e.classList.contains("btn-outline-danger")) {
        e.style.backgroundColor = "#dc3545";
        e.style.color = "white";
        e.previousElementSibling.style = "none";
    }
    if (e.previousElementSibling.classList.contains("active")) {
        e.previousElementSibling.classList.remove("active")
    }
}