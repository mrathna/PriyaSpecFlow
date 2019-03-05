Feature: Sample Test Case to check the appointment is booked

@mytag
Scenario Outline: Check_appointment_is_booked_successfully
 Given Navigate to the <URL>
 And Navigate to Home Page
 When User enter <username> and <password>
 And Click on the LogIn button
 Then Page name should be displayed as <pagetitle1>
 When Enter details likes <Date> and <Comments> to Make Appointment
 Then Verify appointment is booked successfully as <pagetitle2>

Examples:
| URL                                      | username | password           | pagetitle1       | Date       | Comments            | pagetitle2               |
| https://katalon-demo-cura.herokuapp.com/ | John Doe | ThisIsNotAPassword | Make Appointment | 11/12/2019 | Booking Appointment | Appointment Confirmation |

@mytag @newtag @TestTag @New Tag
Scenario Outline: Check_appointment_is_not_booked_successfully
 Given Navigate to the <URL>
 And Navigate to Home Page
 When User enter <username> and <password>
 And Click on the LogIn button
 Then Page name should be displayed as <pagetitle1>
 When Enter details likes <Date> and <Comments> to Make Appointment
 Then Verify appointment is booked successfully as <pagetitle2>

Examples:
| URL                                      | username | password           | pagetitle1       | Date       | Comments            | pagetitle2              |
| https://katalon-demo-cura.herokuapp.com/ | John Doe | ThisIsNotAPassword | Make Appointment | 11/12/2019 | Booking Appointment | Appointment Confirmatio |

@mytag
Scenario Outline: Check_appointment_is_booked_after_5Days
 Given Navigate to the <URL>
 And Navigate to Home Page
 When User enter <username> and <password>
 And Click on the LogIn button
 Then Page name should be displayed as <pagetitle1>
 When Enter days in addition to current date as per <DaysCount>
 And Enter <Comments> to book Appointment
 Then Verify appointment is booked successfully as <pagetitle2>
 Given Verify application is logged out

Examples:
| URL                                      | username | password           | pagetitle1       | Comments            | pagetitle2               | DaysCount |
| https://katalon-demo-cura.herokuapp.com/ | John Doe | ThisIsNotAPassword | Make Appointment | Booking Appointment | Appointment Confirmation | 6         |