var studentDetails = {

    getDetails: function () {
        var actionUrl = "http://interviewapi20170221095727.azurewebsites.net/api/Student/All";
        var auth = btoa('authentica:@uth3nt1c@');
        $.ajax({
            url: actionUrl,
            type: "GET",
            data: {},
            dataType: 'json',
            headers: {
                "Authorization": "Basic " + auth
            },
            success: function (data) {
                studentDetails.viewAllStudentDetails(data);
            },
            error: function (req) {
                var errResponse = req.responseJSON[1];
                console.log(errResponse);
            }
        });
    },
    viewAllStudentDetails: function (parseObj) {
        $.each(parseObj, function (index, data) {
            var row = '<div class="container" id=' + data.studentId + '><div class="maindiv"><div class="spic"><img src="../images/user_' + index + '.png"> <i class="OnMob IC-mobi grn"></i></div>';
            row += '<div class="sname"><a>' + data.studentId + ' - <b>' + data.firstName + '&nbsp;' + data.lastName + '</b></a><a> ' + data.grade + '</a><a> ' + data.schoolName + '</a></div></div>';
            row += '<div class="sinfo"><div class="itms"><a onclick="studentDetails.getEnrollmentDetails(this,\'' + data.studentId + '\')">Enrollment History</a></div>';
            row += '<div class="itms"><div class="IC-mail2"></div><a onclick="studentDetails.getAssignmentDetails(this,\'' + data.studentId + '\')">Assignment History</a></div></div></div>';
            $('#students_list').append(row);
        })

    },
    getEnrollmentDetails: function (obj, id) {
        var studentId = id;
        $(".sel").removeClass("sel");
        $('#' + studentId).addClass('sel');
        var studentId = $(obj).parent().parent().parent().parent().find('.container').attr('id');
        var actionUrl = "http://interviewapi20170221095727.azurewebsites.net/api/Student/EnrollmentHistory";
        var auth = btoa('authentica:@uth3nt1c@');
        $.ajax({
            url: actionUrl,
            type: "GET",
            data: {
                'studentId': studentId
            },
            dataType: 'json',
            headers: {
                "Authorization": "Basic " + auth
            },
            success: function (data) {
                studentDetails.viewStudentHistoryDetails(data, obj);
            },
            error: function (req) {
                var errResponse = req.responseJSON[1];
                console.log(errResponse);
            }
        });
    },
    viewStudentHistoryDetails: function (result, obj) {
        $('#enroll_list').html('')
        $('#student_enrollDiv').show();
        $.each(result, function (index, data) {
            var row = ' <tr class="srow"><td>' + data.entryDate + '</td><td width="31%">' + data.exitDate + '</td> <td width="32%">' + data.exitReason + '</td> </tr>'
            $('#enroll_list').append(row);
        })
    },
    getAssignmentDetails: function (obj,id) {
        var studentId = id;
        $(".sel").removeClass("sel");
        $('#' + studentId).addClass('sel');
        var studentId = $(obj).parent().parent().parent().parent().find('.container').attr('id');
        var actionUrl = "http://interviewapi20170221095727.azurewebsites.net/api/Student/AssignmentHistory";
        var auth = btoa('authentica:@uth3nt1c@');
        $.ajax({
            url: actionUrl,
            type: "GET",
            data: {
                'studentId': studentId
            },
            dataType: 'json',
            headers: {
                "Authorization": "Basic " + auth
            },
            success: function (data) {
                studentDetails.viewAssignmentDetails(data, obj);
            },
            error: function (req) {
                var errResponse = req.responseJSON[1];
                console.log(errResponse);
            }
        });
    },
    viewAssignmentDetails: function (result, obj) {
        $('#assignment_list').html('')
        $('#student_enrollDiv').hide();
        $('#student_assignmentDiv').show();
        $.each(result, function (index, data) {
            var row = '<tr class="srow">';
            row += '<td width="26%">' + data.assignmentName + '</td>';
            row += '<td width="%">' + data.dueDate + '</td>';
            row += '<td width="14%">' + data.maxScore + '</td>'
            row += '<td width="22%">' + data.completionDate + '</td>';
            row += '<td width="12%">' + data.scoreEarned + '</td>';
            row += '</tr>'
            $('#assignment_list').append(row);
        })
    }

}