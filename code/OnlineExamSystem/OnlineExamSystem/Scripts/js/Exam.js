function openQuestionsForm(QuestionId) {
    $.ajax({
        type: 'GET',
        dataType: 'html',
        data: { id: QuestionId },
        url: '/Exam/AddQuestions',
        success: function (data) {
            $('#divFormDetails').html(data);
        },
        error: function (err) {
            alert(err);
        }
    });
}

openAnswerForm = function (answerId) {
    $.ajax({
        type: 'GET',
        dataType: 'html',
        data: { id: answerId },
        url: '/Exam/AddAnswers',
        success: function (data) {
            $('#divFormDetails').html(data);
        },
        error: function (err) {
            alert(err);
        }
    });
}

function CloseForm() { $(".myform").hide('3000'); }

function deleteQuestions(QuestionId) {
    if (confirm("Are you sure to remove this answer type record??")) {
        $.ajax({
            type: 'POST',
            contentType: 'application/json;charset=UTF-',
            dataType: 'json',
            url: '/Exam/DeleteQuestions/' + QuestionId,
            success: function (data) {
                alert("Yo have removed one answer type record successfully!!!");
                window.location.href = '@Url.Action("Questions")';
            },
            error: function (err) {
                alert(err.responseText);
            }
        });
    } else {
        return false;
    }
}

//Valdidation using jquery
function validate() {
    var isValid = true;
    if ($('#AnswerTypeId').val().trim() == "") {
        $('#AnswerTypeId').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#AnswerTypeId').css('border-color', 'lightgrey');
    }
    if ($('#CourseId').val().trim() == "") {
        $('#CourseId').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#CourseId').css('border-color', 'lightgrey');
    }
    if ($('#Question').val().trim() == "") {
        $('#Question').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Question').css('border-color', 'lightgrey');
    }
    if ($('#Marks').val().trim() == "" || $('#Marks').val().trim() == "0") {
        $('#Marks').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Marks').css('border-color', 'lightgrey');
    }
    if (!isValid) {
        event.preventDefault();
    }
    return isValid;
}

bindQuestionDropdown = function () {
    $.ajax({
        type: 'GET',
        contentType: 'application/json;charset=UTF-',
        dataType: 'json',
        url: '/Exam/GetQuestionByCourseId/' + $('#ddlCourse').val(),
        success: function (data) {
            $("#ddlQuestion").empty();

            var optionhtml1 = '<option value="">' + "Select Question" + '</option>';
            $("#ddlQuestion").append(optionhtml1);

            $.each(data, function (i) {
                var optionhtml = '<option value="' +
                    data[i].QuestionId + '">' + data[i].Question + '</option>';
                $("#ddlQuestion").append(optionhtml);
            });
        },
        error: function (err) {
            alert(err.responseText);
        }
    });
}

validateAnswer = function () {
    var isValid = true;
    if ($('#ddlCourse').val().trim() == "") {
        $('#ddlCourse').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#ddlCourse').css('border-color', 'lightgrey');
    }
    if ($('#ddlQuestion').val().trim() == "") {
        $('#ddlQuestion').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#ddlQuestion').css('border-color', 'lightgrey');
    }
    if ($('#Answer').val().trim() == "") {
        $('#Answer').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Answer').css('border-color', 'lightgrey');
    }
    if (!isValid) {
        event.preventDefault();
    }
    return isValid;
}