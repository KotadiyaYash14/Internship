var myArray = [
    {
        "Name": `<input type="text" placeholder="Name" name="name" value="Tom" class="rounded-2 w-75 mt-1 p-1 first_input">`,
        "Subject": `<input type="text" placeholder="Subject" name="subject" value="Maths" class="rounded-2 w-75 mt-1 p-1 second_input">`,
        "Marks": `<input type="text" placeholder="Mark" name="mark" value="50" class="rounded-2 w-75 mt-1 p-1 third_input">`,
        "Result": `<button class="btn btn-outline-success">Pass</button>&nbsp;&nbsp;<button class="btn btn-outline-danger">Fail</button>`
    },
    {
        "Name": `<input type="text" placeholder="Name" name="name" value="Tom" class="rounded-2 w-75 mt-1 p-1 first_input">`,
        "Subject": `<input type="text" placeholder="Subject" name="subject" value="Maths" class="rounded-2 w-75 mt-1 p-1 second_input">`,
        "Marks": `<input type="text" placeholder="Mark" name="mark" value="50" class="rounded-2 w-75 mt-1 p-1 third_input">`,
        "Result": `<button class="btn btn-outline-success">Pass</button>&nbsp;&nbsp;<button class="btn btn-outline-danger">Fail</button>`
    },
    {
        "Name": `<input type="text" placeholder="Name" name="name" value="Tom" class="rounded-2 w-75 mt-1 p-1 first_input">`,
        "Subject": `<input type="text" placeholder="Subject" name="subject" value="Maths" class="rounded-2 w-75 mt-1 p-1 second_input">`,
        "Marks": `<input type="text" placeholder="Mark" name="mark" value="50" class="rounded-2 w-75 mt-1 p-1 third_input">`,
        "Result": `<button class="btn btn-outline-success">Pass</button>&nbsp;&nbsp;<button class="btn btn-outline-danger">Fail</button>`
    },
    {
        "Name": `<input type="text" placeholder="Name" name="name" value="Tom" class="rounded-2 w-75 mt-1 p-1 first_input">`,
        "Subject": `<input type="text" placeholder="Subject" name="subject" value="Maths" class="rounded-2 w-75 mt-1 p-1 second_input">`,
        "Marks": `<input type="text" placeholder="Mark" name="mark" value="50" class="rounded-2 w-75 mt-1 p-1 third_input">`,
        "Result": `<button class="btn btn-outline-success">Pass</button>&nbsp;&nbsp;<button class="btn btn-outline-danger">Fail</button>`
    },
    {
        "Name": `<input type="text" placeholder="Name" name="name" value="Tom" class="rounded-2 w-75 mt-1 p-1 first_input">`,
        "Subject": `<input type="text" placeholder="Subject" name="subject" value="Maths" class="rounded-2 w-75 mt-1 p-1 second_input">`,
        "Marks": `<input type="text" placeholder="Mark" name="mark" value="50" class="rounded-2 w-75 mt-1 p-1 third_input">`,
        "Result": `<button class="btn btn-outline-success">Pass</button>&nbsp;&nbsp;<button class="btn btn-outline-danger">Fail</button>`
    }
]

var myObj = "";
myArray.forEach((e) => {
    myObj += `<tr>
    <td></td>
    <td>${e.Name}</td>
    <td>${e.Subject}</td>
    <td>${e.Marks}</td>
    <td>${e.Result}</td>
    </tr>`
});
var body = document.getElementById("mybody");
body.innerHTML = myObj;

function addRow() {
    var table = document.getElementById("mybody");
    var row = table.insertRow();
    var cell1 = row.insertCell(0);
    var cell2 = row.insertCell(1);
    var cell3 = row.insertCell(2);
    var cell4 = row.insertCell(3);
    var cell5 = row.insertCell(4);
    var cell6 = row.insertCell(5);
    cell1.innerHTML = ``;
    cell2.innerHTML = `<input type="text" placeholder="Name" name="name" value="Tom" class="rounded-2 w-75 mt-1 p-1 first_input">`;
    cell3.innerHTML = `<input type="text" placeholder="Subject" name="subject" value="Maths" class="rounded-2 w-75 mt-1 p-1 second_input">`;
    cell4.innerHTML = `<input type="text" placeholder="Mark" name="mark" value="50" class="rounded-2 w-75 mt-1 p-1 third_input">`;
    cell5.innerHTML = `<button class="btn btn-outline-success">Pass</button>&nbsp;&nbsp;<button class="btn btn-outline-danger">Fail</button>`;
    cell6.innerHTML = `<td><button type="button" class="btn btn-outline-warning" onclick="removeRow(this)">Remove</button></td>`;
}

function removeRow(e) {
    e.parentElement.parentElement.remove();
}

