function searchDoctors(page, sortIndex) { // поиск докторов по специальности,имени,фамилии

    let request = {
        search: {
            name: $('#Name').val(),
            surname: $('#Surname').val(),
            specialty: $('#Specialty').val()
        },
        page: typeof(page) === 'number' ? page : 1,
        sortIndex: !sortIndex ? 0 : parseInt(sortIndex)
    };
        
    $.ajax({
        type: 'POST',
        url: window.origin + '/Doctor/ShowDoctors',
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