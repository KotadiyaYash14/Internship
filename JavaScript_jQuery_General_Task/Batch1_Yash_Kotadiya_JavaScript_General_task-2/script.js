var tables;
$(document).ready(function () {
    tables = $("table").DataTable();
})
async function addRow() {
    const { value: formValues } = await Swal.fire({
        title: 'Enter Your Details',
        allowOutsideClick: false,
        focusConfirm: false,
        html:
            '<input id="swal-input1" class="swal2-input" placeholder="Enter Your Name">' +
            '<input id="swal-input2" class="swal2-input" placeholder="Enter Your Age">' +
            '<input id="swal-input3" class="swal2-input" placeholder="Enter Your Designation">',
        preConfirm: () => {
            var Name = document.getElementById('swal-input1').value
            var Age = document.getElementById('swal-input2').value
            var Desig = document.getElementById('swal-input3').value

            if (!Name || !Age || !Desig) {
                Swal.showValidationMessage('Please Fill all Input Field');
            }
            else if (Age <= 20 || Age >= 100 || isNaN(Age)) {
                Swal.showValidationMessage('Please Enter Valid Age');
            }
            return [
                document.getElementById('swal-input1').value,
                document.getElementById('swal-input2').value,
                document.getElementById('swal-input3').value
            ]
        }
    })
    if (formValues) {
        tables.row.add([formValues[0], formValues[1], formValues[2]]).draw();
    }
}