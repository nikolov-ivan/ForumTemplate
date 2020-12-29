tinymce.init({
    selector: "textarea",
    plugins: [
        "image paste table link code media lists code emoticons autoresize"
    ],
    toolbar: "emoticons",
    content_style: 'body {font - family:Helvetica,Arial,sans-serif; font-size:14px }',

});
$(function () {
    $("time").each(function (i, e) {
        const dateTimeValue = $(e).attr("datetime");
        if (!dateTimeValue) {
            return;
        }
        const time = moment.utc(dateTimeValue).local();
        $(e).html(time.format("llll"));
        $(e).attr("title", $(e).attr("datetime"));
    });
});


