$('.deleteModalButton').on("click", function () {
    var courseId = $(this).data('id'),
        courseName = $(this).data('name');
    $("#deleteModal .deleteOkButton").data('coursetodeleteid', courseId);
    $("#deleteModal #courseNameModal").text(courseName);
});

$(".deleteOkButton").on("click", function () {
    var id = $("#deleteModal .deleteOkButton").data('coursetodeleteid'),
     token = $('input[name="__RequestVerificationToken"]').val(),
     data = {
         'courseId': id,
         '__RequestVerificationToken': token
     };

    $.ajax({
        type: "POST",
        url: "/Courses/Delete",
        data: data,
        datatype: "html",
        success: function (data) {
            //$('#' + id).html(data);
            var deletedElement = $('[data-groupid=' + id + ']');
            deletedElement.remove();
        },
        error: function (data) {
            console.log(data);
        }
    });
});