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
            $('[data-groupid=' + id + ']')
                .clone()
                .appendTo('.registerdSection')
                .find('button')
                .remove();
        },
        error: function (data) {
            $("#errorModal .modal-title").text(data.responseText);
            $('#errorModal').modal();

            console.log('fail to register');
        }
    });
});