$('a.btn.btn-outline-primary, a.btn.btn-outline-danger, a.btn.btn-outline-info, a.btn.btn-outline-secondary').hover(function () {
    $(this).addClass('text-white');
}, function () {
    $(this).removeClass('text-white');
});
