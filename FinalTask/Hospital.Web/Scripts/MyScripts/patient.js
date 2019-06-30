function SearchToAssign(val) { // Поиск доктора по специальности в pop up

    $.ajax({
        type: 'Post',
        url: window.origin + "/Doctor/SearchToAssign",
        contentType: "application/json",
        data: JSON.stringify({ search: val }),
        dataType: 'Html',
        beforeSend: function () {

        },
        success: function (content) {
            $("#divPartialSearch").html(content);
        },
        error: function () {
            alert("Error");
        },
        completed: function () {

        }
    });
}

function assignDoctor(element) { //назначение доктора пациенту

    $('#DoctorId').val(element.id);
    $('#doctorAppointForm').submit();
}

function searchPatients(page, sortIndex) { //Поиск пациента по имени,фамилии и дате рождения

    let request = {
        search: {
            Name: $('#Name').val(),
            Surname: $('#Surname').val(),
            DateOfBirth: $('#DateOfBirth').val()
        },
        page: typeof page === 'number' ? page : 1,
        sortIndex: !sortIndex ? 0 : parseInt(sortIndex)
    };

    $.ajax({
        type: "Post",
        url: window.origin + '/Patient/ShowPatients',
        contentType: 'application/json; charset=utf-8;',
        data: JSON.stringify(request),
        dataType: 'html',
        beforeSend: function () {
            $('#spinner').show();
        },
        success: function (content) {
            $('#divSearchPatients').html(content);
        },
        error: function () {
            alert('Error occured while processing request to the server.');
        },
        complete: function () {
            $('#spinner').hide();
        }

    });
}
function chec() {
   
}