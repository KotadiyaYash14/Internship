let chance = 6;
$(".addBtn").click(function () {
    let body = $("#body");
    let tr = $("<tr></tr>");
    let insert_row = `<td scope="row" class="pt-3 first_td"></td>
    <td class="second_td"><input type="text" placeholder="Name" name="name" class="rounded-2 w-75 mt-1 p-1 first_input"></td>
    <td class="third_td"><input type="text" placeholder="Subject" name="subject" class="rounded-2 w-75 mt-1 p-1 second_input"></td>
    <td class="fourth_td"><input type="text" placeholder="Mark" name="mark" class="rounded-2 w-75 mt-1 p-1 third_input"></td>
    <td scope="col" class="fifth_td"><button type="button" class="btn btn-outline-success" onclick="passBtn(this)">Pass</button>&nbsp;&nbsp;<button type="button" class="btn btn-outline-danger" onclick="failBtn(this)">Fail</button></td>
    <td><button type="button" class="btn btn-outline-warning removeBtn">Remove</button></td>`;
    tr.html(insert_row);
    body.append(tr);
});
// addBtn logic end

// RemoveBtn logic start
$("#body").on("click", '.removeBtn', function () {
    var user = confirm("Do you want to delete the record ?")
    if (user) {
        $(this).parent().parent().remove();
        return true;
    }
    else {
        return false;
    }
})
// RemoveBtn logic end

//  Submit buttton logic start

$("#myform").submit((element) => {
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
    $("#myform").find('input[name="name"]').each((index,element) => {
        var reg = /^[a-zA-Z\-]+$/
        var n = RegExp(reg).test($(element).val());

        if (($(element).val() == "" || !n) && flag1 == 0) {
            alert("Invalid Name");
            flag1 = 1;
            return false;
        }
    });

    $("#myform").find('input[name="subject"]').each((index,element) => {
        var reg = /^[a-zA-Z\-]+$/
        var n = RegExp(reg).test($(element).val());
        if ((element.value == "" || !n) && flag2 == 0) {
            alert("Invalid Subject");
            flag2 = 1;
            return false;
        }
    });

    $("#myform").find('input[name="mark"]').each((index,element) => {
        if (($(element).val() == "" || $(element).val() < 0 || $(element).val() > 100 || isNaN($(element).val())) && flag3 == 0) {
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

        var upperDiv = $("<div></div>");
        upperDiv.addClass("container");
        upperDiv.addClass("mt-2");

        var formDiv = $("<div></div>");
        formDiv.addClass("d-flex");

        var searchInp = $("<input/>");
        searchInp.addClass("form-control");
        searchInp.addClass("mt-2");
        searchInp.attr("placeholder", "Search");
        searchInp.attr("aria-label", "Search");
        searchInp.attr("id", "myinput");
        searchInp.attr("onkeyup", "filterFunction()");

        var select = $("<select></select>");
        select.addClass("select");
        select.attr('onchange', "sortFunction(this)");
        var option0 = $("<option></option>");
        option0.html("Sort By");
        var option1 = $("<option></option>");
        option1.html("Name");
        var option2 = $("<option></option>");
        option2.html("Subject");

        select.append(option0);
        select.append(option1);
        select.append(option2);
        upperDiv.append(select);
        formDiv.append(searchInp);
        upperDiv.append(formDiv);

        // Create a result table 

        var lowerDiv = $("<div></div>");
        lowerDiv.addClass("container");
        lowerDiv.addClass("mt-4");

        var resultTable = $("<table></table>");
        resultTable.addClass("table");
        resultTable.addClass("table-bordered");
        resultTable.addClass("table-light");
        resultTable.addClass("table-hover");
        resultTable.addClass("text-center");
        resultTable.addClass("shadow");
        resultTable.addClass("main");
        resultTable.attr("id", "mytable");

        var resultHead = $("<thead></thead>");

        var resultTr = $("<tr></tr>");
        resultTr.addClass("first");
        resultHead.append(resultTr);

        var td1 = $("<td></td>");
        td1.html("Sr-No.");

        var td2 = $("<td></td>");
        td2.html("Name");

        var td3 = $("<td></td>");
        td3.html("Subject");

        var td4 = $("<td></td>");
        td4.html("Marks");

        var td5 = $("<td></td>");
        td5.html("Result");

        resultTr.append(td1);
        resultTr.append(td2);
        resultTr.append(td3);
        resultTr.append(td4);
        resultTr.append(td5);

        resultTable.append(resultHead);
        lowerDiv.append(resultTable);
        $("#report").html(upperDiv.prop('outerHTML') + lowerDiv.prop('outerHTML'));

        // Show the data into the result table

        var a = $(".first_td");

        var b = $(".second_td");
        b = $(".first_input");

        var c = $(".third_td");
        c = $(".second_input");

        var d = $(".fourth_td");
        d = $(".third_input");

        var g = $(".fifth_td");
        g = $(".btn");

        var table = $(".main");
        var body = $(table).append("<tbody></tbody>");

        var count = 1;
        for (var i = 0; i < a.length; i++) {
            var activeBtn = $($(".fifth_td")[i]).find('.active');
            if ($(activeBtn).length == 0) {
                continue;
            }
            if (!activeBtn.hasClass("btn-danger")) {
                const f = b[i].value;
                const g = c[i].value;
                const h = d[i].value;
                const k = g[i];
                var tr = `<tr>
                <td>${count++}</td>
                <td>${f}</td>
                <td>${g}</td>
                <td>${h}</td>
                <td>${k}</td>
                </tr>`
                $(".main tbody").append(tr)
                if (h >= 33) {
                    $(".main tbody tr:last-child").css({"color" : "green"})
                    $(".main tbody tr:last-child td:last-child").html("Pass")
                }

                if (h < 33) {
                    $(".main tbody tr:last-child").css({"color" : "red"})
                    $(".main tbody tr:last-child td:last-child").html("Fail")
                }
            }
        }
        // searchBar function logic end

        // Create a percentage table

        var resultDiv = $("<div></div>");
        resultDiv.addClass("container");
        resultDiv.addClass("mt-4");

        var resultTable = $("<table></table>");
        resultTable.addClass("table");
        resultTable.addClass("table-bordered");
        resultTable.addClass("table-light");
        resultTable.addClass("table-hover");
        resultTable.addClass("text-center");
        resultTable.addClass("shadow");
        resultTable.addClass("main1");
        resultTable.attr("id", "main1")

        var resultHead = $("<thead></thead>");

        var resultTr = $("<tr></tr>");
        resultHead.append(resultTr);

        var td6 = $("<td></td>");
        td6.html("Sr-No");

        var td7 = $("<td></td>");
        td7.html("Name");

        var td8 = $("<td></td>");
        td8.html("Percentage");

        resultTr.append(td6);
        resultTr.append(td7);
        resultTr.append(td8);
        resultDiv.append(resultTable);
        resultTable.append(resultHead);
        $("#result").html(resultDiv.prop('outerHTML'));
        var table = $(".main1");
        var body = $(table).append("<tbody></tbody>");

        // logic for calculate a percentage

        var nameArray = [];
        var marksArray = [];
        var countArray = [];
        var tableBody = $('.main').children('tbody').children('tr');
        for (let index = 0; index < $(tableBody).length; index++) {
            const tBody = $(tableBody)[index];
            var nameValue = $(tBody).find("td:nth-child(2)");
            if (!nameArray.includes(nameValue.html())) {
                nameArray.push(nameValue.html());
            }
            else{
                continue;
            }
            var totalMarks = 0;
            var counter = 0;
            $(".main tr").each(function (i,e) {
                    var anotherNameValue = $(e).find("td:nth-child(2)").html();
                    var markValue = $(this).find("td:nth-child(4)").html();
                    if (nameValue.html() == anotherNameValue) {
                        totalMarks += parseInt(markValue);
                        counter++;
                }
            });  
            marksArray.push(totalMarks);
            countArray.push(counter);
        };
    }
    var allTr = "";
    for (let index = 0; index < $(marksArray).length; index++) {
        allTr += `<tr>
                <td>${index + 1}</td>
                <td>${nameArray[index]}</td>
                <td>${marksArray[index] / countArray[index] + "%"}</td>
                </tr>`
    }
    $(".main1 tbody").append(allTr);
}

// filter function logic start
function filterFunction() {
    $("#myinput").on("keyup", function () {
        var value = $(this).val().toUpperCase();
        $("#mytable tr").filter(function () {
            $(this).toggle($(this).text().toUpperCase().indexOf(value) > -1);
        });
    });
}
// filter function logic end

// sort function logic start
function sortFunction(element) {
    var table, rows, switching, i, x, y, shouldSwitch;
    table = $("#mytable");
    switching = true;

    while (switching) {
        switching = false;
        var rows = $("#mytable tbody").find("tr");   
        for (i = 0; i < ($(rows).length - 1); i++) {
            shouldSwitch = false;
            if ($(element).val() == "Name") {
                x = $(rows[i]).children().eq(1).html()
                y = $(rows[i + 1]).children().eq(1).html()
            }
            else {
                x = $(rows[i]).children().eq(2).html();
                y = $(rows[i + 1]).children().eq(2).html();
            }
            if (x.toLowerCase() > y.toLowerCase()) {
                shouldSwitch = true;
                break;
            }
        }
        if (shouldSwitch) {
            $(rows[i + 1]).detach();
            $(rows[i]).before($(rows[i+1]));
            switching = true;
        }
    }
}
// sort function logic end

function passBtn(ele) {
    $(ele).addClass('btn-success').removeClass('btn-outline-success').addClass('active') ;
    $(ele).next().addClass('btn-outline-danger').removeClass('btn-danger').removeClass('active');
}

function failBtn(ele) {
    $(ele).addClass('btn-danger').removeClass('btn-outline-danger').addClass('active') ;
    $(ele).prev().addClass('btn-outline-success').removeClass('btn-success').removeClass('active');
}