$('.registerModalButton').on("click", function () {
    var courseId = $(this).data('id'),
        courseName = $(this).data('name');
    $("#studentModal .registerOkButton").data('courseToRegisterId', courseId);
    $("#studentModal #courseNameModal").text(courseName);
});

$(".registerOkButton").on("click", function () {
    var id = $("#studentModal .registerOkButton").data('courseToRegisterId'),
        token = $('input[name="__RequestVerificationToken"]').val(),
        data = {
         'courseId': id,
         '__RequestVerificationToken': token
        };

    $.ajax({
        type: "POST",
        url: "/Home/AssignToCourse",
        data: data,
        datatype: "html",
        success: function (data) {
            var deletedElement = $('[data-groupid=' + id + ']');
            deletedElement.remove();

            console.log('success');
            console.log(data);
        },
        error: function (data) {
            console.log('error');
            console.log(data);
        }
    });
});