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
        url: window.origin + '/HospitalStaff/Home/ShowPatients',
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