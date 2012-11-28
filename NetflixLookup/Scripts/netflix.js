
var g_searchTitlesUrl = "/start/GetTitles";
var g_searchCompsUrl = "/start/GetComps";

$(document).ready(function () {
    $("#btnTitleLookup").click(function (e) {
        $("form").submit();
        e.preventDefault();
    });

});


function searchTitles() {
    $.ajax({
        type: "POST",
        url: g_searchTitlesUrl,
        data:
        {
            "term": $("#txtTitle").val(),
            "maxResults": $("#txtMaxResults").val()
        },
        dataType: "json",
        async: true,
        success: function (response) {
            $("#movieList").html("");
            $("#movieTemplate")
            .tmpl(response)
            .appendTo("#movieList");

            $("a[movieid]").click(function (e) {
                searchComps($(this).attr("movieId"));
                e.preventDefault();
            });

        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Ajax call failed, please try again later.");
        }
    });
}

function searchComps(movieId) {
    $.ajax({
        type: "POST",
        url: g_searchCompsUrl,
        data:
        {
            "movieId": movieId,
            "maxResults": $("#txtMaxResults").val()
        },
        dataType: "json",
        async: true,
        success: function (response) {
            $("#movieList").html("");
            $("#movieTemplate")
            .tmpl(response)
            .appendTo("#movieList");

            $("a[movieid]").click(function (e) {
                searchComps($(this).attr("movieId"));
                e.preventDefault();
            });

        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Ajax call failed, please try again later.");
        }
    });
}