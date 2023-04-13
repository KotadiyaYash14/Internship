$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "https://api.publicapis.org/entries",
        beforeSend: function () {
            $("#spanDiv").show()
        },
        success: function (data) {
            $("#spanDiv").hide();
            var myData = data.entries;
            var showData = "";
            var myHead = "";
            myHead += `<thead>
            <tr>
                <th scope="col">API</th>
                <th scope="col">Description</th>
                <th scope="col">Auth</th>
                <th scope="col">Cors</th>
                <th scope="col">Link</th>
                <th scope="col">Category</th>
            </tr>
        </thead>`
            $("#myTable").append(myHead);
            $.each(myData, function (key, value) {
                showData += `<tr>
                <td>${value.API}</td>
                <td>${value.Description}</td>
                <td>${value.Auth}</td>
                <td>${value.Cors}</td>
                <td>${value.Link}</td>
                <td>${value.Category}</td>
                </tr>`
            });
            $("#myTable #myBody").append(showData);
        }
    })
})