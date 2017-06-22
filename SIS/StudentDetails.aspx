<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentDetails.aspx.cs" Inherits="SIS.StudentDetails" %>

<html>
<head>
    <title>Student Information System - SIS</title>
    <script src="Scripts/jquery-1.11.0.min.js"></script>
    <script src="Scripts/jquery-ui-1.10.4.min.js"></script>
    <!--<script src="Scripts/StudentDetails.js"></script>-->
    <script src="Scripts/StudentDetailsV1.js"></script>
    <link href="Content/Studentdetails.css" rel="stylesheet" />
    <body onload="studentDetails.getDetails()">
        <div class="studenthead stuhead">
            <div style="float: left; margin-left: 227px; height: 30px;"><img src="Images/Student_banner.jpeg" height="74px" width="350px"></div>
            <div style="padding: 16px; margin-left: 60px;"><b>Student Information System - SIS</b></div>
        </div>
        <div class="Scrcont" style="padding: 0px">
            <div class="stulist" id="students_list">
            </div>
        </div>
        <!-- Enrollment Details -->
        <div class="Scrcont section" id="student_enrollDiv" style="display: none">
            <div class="Studentdetailtable tabcont" style="width: 1240px;">
                <div class="tableline" style="width:1240px;"></div>
                <table class="table table-hover Tlist FLhead" id="skillsets_list_table">
                    <thead>
                        <tr>
                            <th>
                                <div><span class="Stxt">Entry Date</span></div>
                            </th>
                            <th width="31%">
                                <div><span class="Stxt">Exit Date</span></div>
                            </th>
                            <th width="">
                                <div><span class="Stxt">Exit Reason</span></div>
                            </th>
                        </tr>
                    </thead>
                </table>
                <table class="table table-hover">
                    <tbody id="enroll_list"></tbody>
                </table>
            </div>
        </div>
        <!-- Assignment Details -->
        <div class="Scrcont section" id="student_assignmentDiv" style="display: none">
            <div class="Studentdetailtable tabcont" style="width: 1240px;">
                <div class="tableline" style="width:1240px;"></div>
                <table class="table table-hover Tlist FLhead" id="skillsets_list_table">
                    <thead>
                        <tr>
                            <th width="26%">
                                <div><span class="Stxt">Assignment Name</span></div>
                            </th>
                            <th width="">
                                <div><span class="Stxt">Due Date</span></div>
                            </th>
                            <th width="14%">
                                <div><span class="Stxt">Max Score</span></div>
                            </th>
                            <th width="22%">
                                <div><span class="Stxt">Completion Date</span></div>
                            </th>
                            <th width="15%">
                                <div><span class="Stxt">Score Earned</span></div>
                            </th>
                        </tr>
                    </thead>
                </table>
                <table class="table table-hover">
                    <tbody id="assignment_list"></tbody>
                </table>
            </div>
        </div>
    </body>
</head>
</html>
