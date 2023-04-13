$(document).ready(function () {
    $("#addRow").click(function () {
        $("#body").append(`<tr>
        <td scope='row' class='pt-3 first_td'></td>
        <td class='second_td'><input type='text' placeholder='Name' name='name' class='rounded-2 w-75 mt-1 p-1 first_input'>
        </td><td class='third_td'><input type='text' placeholder='Subject' name='subject' class='rounded-2 w-75 mt-1 p-1 second_input'>
        </td><td class='fourth_td'><input type='text' placeholder='Mark' name='mark' class='rounded-2 w-75 mt-1 p-1 third_input'>
        </td><td scope='col' class='fifth_td'><button type='button' class='btn btn-outline-success'>Pass</button>&nbsp;&nbsp;<button type='button' class='btn btn-outline-danger'>Fail</button></td>
        <td><button type='button' class='btn btn-outline-warning removeRow'>Remove</button></td></tr>`);

        $(".removeRow").click(function () {
            $(this).parent().parent().remove();
        });
    });
    Time();

});

function Time() {
    var initialTime = "05:00";
    var interval = setInterval(function () {
        var timer = initialTime.split(':');
        var minutes = parseInt(timer[0]);
        var seconds = parseInt(timer[1]);
        --seconds;
        minutes = (seconds < 0) ? --minutes : minutes;
        seconds = (seconds < 0) ? 59 : seconds;
        seconds = (seconds < 10) ? '0' + seconds : seconds;
        if (minutes < 0) {
            clearInterval(interval);
            Swal.fire({
                icon : 'success',
                title: 'Your Records have been Saved.',
                allowOutsideClick: false
            }).then(function () {
                Time();
            })
        } else {
            $('#timer').html(minutes + ':' + seconds);
            initialTime = minutes + ':' + seconds;
        }
    }, 1000);
}