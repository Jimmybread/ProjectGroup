// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {

    $('a.btn.btn-outline-danger.btn-sm').click(function () {
        var candidateId = $(this).attr('data-id');
        $.ajax({
            method: "POST",
            async: true,
            url: "/candidate/DeleteCandidate?id=" + candidateId
        }).done(function (data) {
            if (data) {
                var btns = "a[name='card_btn_" + candidateId + "']";
                $(btns).removeClass(["btn-outline-primary", "btn-outline-danger", "btn-outline-info", "text-primary", "text-danger", "text-info"])
                    .addClass(['btn-outline-secondary', 'text-secondary'])
                    .css('pointer-events', 'none');

                var titleId = "#title_" + candidateId;
                $(titleId).removeClass("text-info").addClass("text-secondary");
                alert("删除成功");
            }
            else {
                alert("删除失败");
            }
        });
    });

});