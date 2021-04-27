function openStudentForm(userId) {
    $.ajax({
        type: 'GET',
        dataType: 'html',
        data: { id: userId },
        url: '/Student/AddStudent',
        success: function (data) {
            $('#divFormDetails').html(data);
        },
        error: function (err) {
            alert(err);
        }
    });
}

function CloseForm() {
    $(".myform").hide('3000');
}

function deleteStudent(ID) {
    //var user =  { UserId: userId };
    if (confirm("Are you sure to remove this Student?")) {
        $.ajax({
            type: 'POST',
            contentType: 'application/json;charset=UTF-8',
            dataType: 'json',
            url: '/Student/DeleteStudent/' + ID,
            success: function (data) {
                alert("Yo have removed one record successfully!!!");
                window.location.href = '/Student/Students';
            },
            error: function (err) {
                alert(err.responseText);
            }
        });
    } else {
        return false;
    }
}

function validate() {
    var isValid = true;
    if ($('#FirstName').val().trim() == "") {
        $('#FirstName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#FirstName').css('border-color', 'lightgrey');
    }
    if ($('#LastName').val().trim() == "") {
        $('#LastName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#LastName').css('border-color', 'lightgrey');
    }
    if ($('#MobileNo').val().trim() !== "") {
        var pat = /^\d*(?:\.\d{1,2})?$/;
        if (!pat.test(String($('#MobileNo').val()).toLowerCase()) || $('#MobileNo').val().length!==10) {
            $('#MobileNo').css('border-color', 'Red');
            alert('Please enter valid mobile number');
            isValid = false;
        }
    }
    else {
        $('#MobileNo').css('border-color', 'lightgrey');
    }
    if ($('#MobileNo').val().trim() == "") {
        $('#MobileNo').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#MobileNo').css('border-color', 'lightgrey');
    }
    if ($('#UserPassword').val().trim() === '') {
        $('#UserPassword').css('border-color', 'Red');
        isValid = false;
    } else {
        $('#UserPassword').css('border-color', 'lightgrey');
    }
    if ($('#EmailId').val().trim() === '') {
        $('#EmailId').css('border-color', 'Red');
        isValid = false;
    } else {
        $('#EmailId').css('border-color', 'lightgrey');
    }
    if ($('#EmailId').val() !== '') {
        var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        if (!re.test(String($('#EmailId').val()).toLowerCase())) {
            $('#EmailId').css('border-color', 'Red');
            alert('Please enter valid email address');
            isValid = false;
        }
    } else {
        $('#EmailId').css('border-color', 'lightgrey');
    }
    if (!isValid) {
        event.preventDefault();
    }
    return isValid;
}

onCourseSelected = function () {
    $.ajax({
        type: 'get',
        contentType: 'application/json;charset=UTF-8',
        dataType: 'json',
        url: '/Student/GetFeesDetailsByCourseId/' + $('#ddlCourse').val(),
        success: function (data) {
            $('#txtfees').val('RS. '+ data.Amount);
        },
        error: function (err) {
            alert(err.responseText);
        }
    });
}

addStudentExam = function (studentId) {
    $.ajax({
        type: 'GET',
        dataType: 'html',
        data: { id: studentId },
        url: '/Student/AddStudentExam',
        success: function (data) {
            $('#divFormDetails').html(data);
            $('#StudentId').val(studentId);
        },
        error: function (err) {
            alert(err);
        }
    }); 
}

viewStudentExam = function (studentId) {
    $.ajax({
        type: 'GET',
        dataType: 'html',
        data: { id: studentId },
        url: '/Student/ViewStudentExams',
        success: function (data) {
            $('#divFormDetails').html(data);
        },
        error: function (err) {
            alert(err);
        }
    });
}

validateStudentExam = function () {
    var isValid = true;
    if ($('#ddlCourse').val().trim() == "") {
        $('#ddlCourse').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#ddlCourse').css('border-color', 'lightgrey');
    }
    if ($('#datepicker').val().trim() == "") {
        $('#datepicker').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#datepicker').css('border-color', 'lightgrey');
    }
    if ($('#ExamTimesId').val().trim() == "") {
        $('#ExamTimesId').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#ExamTimesId').css('border-color', 'lightgrey');
    }
    if ($('#txtfees').val().trim() == "" || $('#txtfees').val().trim()==='0.00') {
        $('#txtfees').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#txtfees').css('border-color', 'lightgrey');
    }
    if (!isValid) {
        event.preventDefault();
    }
    return isValid;
}