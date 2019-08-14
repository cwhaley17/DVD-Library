$(document)
    .ready(function() {
        var uri = '/api/DVDs/';
        $(document)
            .on('click',
                '#btnDelete',
                function() {
                    $('#deleteDvdModal').modal('show');
                });
    });
$(document).on('click', '#btnConfirmDelete', function() {
    
})