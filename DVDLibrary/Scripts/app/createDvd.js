$(document)
    .ready(function() {
        var uri = '/api/DVDs/';
        $(document)
            .on('click',
                '#btnShowAddMovie',
                function() {
                    $('#Title').val('');
                    $('#ReleaseDate').val('');
                    $('#Rating_RatingName').val('');
                    $('#Rating_RatingId').val('');
                    $('#MovieDirector').val('');
                    $('#Studio').val('');
                    $('#UserReview_UserName').val('');
                    $('#UserReview_UserRateInt').val('');
                    $('#DvdId').val('');
                    $('#Website').val('');
                    $('#addDvdModal').modal('show');
                });
        $(document)
            .on('click',
                '#btnSaveDvd1',
                function() {
                    var Rating = {
                        "RatingId": ""
                    }
                    var dvd = {
                        Title,
                        ReleaseDate,
                        Rating: {
                            RatingId
                        },
                        MovieDirector,
                        Studio,
                        DvdId,
                        Website,
                        Loan
                    };
                    dvd.Title = $('#Title').val();
                    dvd.ReleaseDate = $('#ReleaseDate').val();
                    dvd.Rating.RatingId = $('#Rating').val();
                    dvd.MovieDirector = $('#MovieDirector').val();
                    dvd.Studio = $('#Studio').val();
                    dvd.DvdId = $('#DvdId').val();
                    dvd.Website = $('#Website').val();
                    dvd.Loan = false;

                    $.post(uri, dvd)
                        .done(function() {
                            $('#addDvdModal').modal('hide');
                            getDVDs()
                                .success(function(data) {
                                    $scope.dvds = data;
                                });
                        })
                        .fail(function(jqXhr, status, err) {
                            alert(status + " - " + err);
                        });
                });
    });