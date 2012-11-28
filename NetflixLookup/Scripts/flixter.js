var baseUrl = "http://api.rottentomatoes.com/api/public/v1.0";

$(document).ready(function () {
    $("#btnTitleLookup").click(function (e) {
        searchMovies();
        e.preventDefault();
    });

});

function searchMovies() {
    var moviesSearchUrl = baseUrl + '/movies.json?apikey=' + g_ApiKey + '&q=' + encodeURI($("#txtTitle").val()) + "&page_limit=" + $("#txtMaxResults").val();

    $.ajax({
        url: moviesSearchUrl,
        dataType: "jsonp",
        success: function (data) {
            renderMovieList(data, $("#txtMaxResults").val());
        }
    });

}

function renderMovieList(data, maxResults) {
    $("#movieList").html("");

    var movies = data.movies;
    var rows = new Array();
    var row = null;
    var ul = null;

    $.each(movies, function (index, movie) {

        var isNewRow = index % 4 == 0;
        var isFirstRow = index == 0;

        if (isNewRow) {
            row = $('<span class="row">');
            ul = $('<ul class="thumbnails">');
            row.append(ul);
            rows.push(row);
        }

        movie.maxResults = maxResults;
        if (movie.alternate_ids) {
            movie.imdb_id = movie.alternate_ids.imdb;
        }

        $("#movieTemplate")
                    .tmpl(movie)
                    .appendTo(ul);
    });

    $.each(rows, function (index, aRow) {
        $("#movieList").append(aRow);
    });

    $("a.synopsis").click(function (e) {
        $(this).parent().parent().find("div.synopsis").toggle();
        e.preventDefault();
        }
    );

}

function searchComps(movieID, maxResults) {
    var moviesSearchUrl = baseUrl + '/movies/' + movieID + '/similar.json?apikey=' + g_ApiKey;

    $.ajax({
        url: moviesSearchUrl,
        dataType: "jsonp",
        success: function (data) {

            renderMovieList(data, maxResults);
        }
    });

}