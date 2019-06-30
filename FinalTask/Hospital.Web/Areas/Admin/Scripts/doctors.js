function searchDoctors(page, sortIndex) { // поиск докторов по специальности,имени,фамилии

    let request = {
        search: {
            name: $('#Name').val(),
            surname: $('#Surname').val(),
            specialty: $('#Specialty').val()
        },
        page: typeof (page) === 'number' ? page : 1,
        sortIndex: !sortIndex ? 0 : parseInt(sortIndex)
    };

    $.ajax({
        type: 'POST',
        url: window.origin + '/Admin/Doctor/ShowDoctors',
        contentType: 'application/json; charset=utf-8;',
        data: JSON.stringify(request),
        dataType: 'html',
        beforeSend: function () {
            $('#spinner').show();
        },
        success: function (content) {
            $('#divSearch').html(content);
        },
        error: function () {
            alert('Error occured while processing request to the server.');
        },
        complete: function () {
            $('#spinner').hide();
        }
    });
}

function addDoctor() {

    let request = {
        name: $('#newName').val(),
        surname: $('#newSurname').val(),
        expirience: $('#newExpirience').val(),
        specialty: $('#newSpecialty').val(),
        role: $('#newRole').val(),
        email: $('#newEmail').val()
    };

    $.ajax({
        type: 'POST',
        url: window.origin + '/Admin/Doctor/AddDoctor',
        contentType: 'application/json;',
        data: JSON.stringify(request),
        dataType: "json",
        success: function (response) {
            if (!response.success) {
                alert(response.error);
            } else {
                searchDoctors();
            }
        },
        error: function () {
            alert('Error occured while processing request to the server.');
        },
        complete: function () {
            
            var el = document.getElementById("dataDismiss").click();
            //$('#newName').val(''),
            //    $('#newSurname').val(''),
            //    $('#newExpirience').val(''),
            //    $('#newSpecialty').val(0),
            //    $('#newRole').val(0),
            //    $('#newEmail').val('');
        }

    });
}