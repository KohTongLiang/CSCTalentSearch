$('#btntest').click(function () {

    alert('test');
    var soapMessage = '<soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">\
                      <soap:Body>\
                        <GetWeather xmlns="http://www.webserviceX.NET">\
                          <CityName>string</CityName>\
                          <CountryName>string</CountryName>\
                        </GetWeather>\
                      </soap:Body>\
                    </soap:Envelope>';

    $.ajax("http://www.webservicex.net/globalweather.asmx", {

        contentType: "application/soap+xml; charset=utf-8",
        type: "POST", //important
        dataType: "xml",
        data: soapMessage

    });

})


function initializeNavbar() {
    if (sessionStorage.getItem('tokenKey') == null || sessionStorage.getItem('username') == null) {
        $('#navright').html('<li><a data-toggle="modal" href="#registerModal"><span class="glyphicon glyphicon-user"></span> Register</a></li><li><a data-toggle="modal" href="#loginModal"><span class="glyphicon glyphicon-log-in"></span> Login</a></li>');
    }
    else {
        $('#navright').html('<li><a style="cursor:default"><span class="glyphicon glyphicon-user"></span> ' + sessionStorage.getItem('username') + '</a></li><li><a data-toggle="modal" href="#updateModal">Update Username</a></li><li><a data-toggle="modal" href="#updatePasswordModal">Update password</a></li><li><a style="cursor:pointer" onclick="logout();" id="btnLogout" name="btnLogout"><span class="glyphicon glyphicon-log-out"></span> Logout</a></li>');
    }
}

$(document).ready(function () {


    showResults();
    initializeNavbar();

});

$('#search').keyup(function () {
    showResults();
});

$('body').on('hidden.bs.modal', '.modal', function () {
    $(this).removeData('bs.modal');
    $(this).find("input,textarea,select").val('').end();
});

function hideModal() {
    $('.modal').modal('hide');
    showResults();
}

function alertDone(msg) {
    $('.modal').modal('hide');
    alert(msg);
}

//to hold Id for updating or deleting
var talentId;


$('#addModal').on('shown.bs.modal', function (e) {
    if (sessionStorage.getItem('tokenKey') == null || sessionStorage.getItem('email') == null) {
        alertDone('Login to access this feature');
    }
    else {
    }
});

//to add
$('#btnAdd').click(function () {

    if ($("#addName").val().trim().length == 0 || $("#addShortName").val().trim().length == 0 || $("#addReknown").val().trim().length == 0 || $("#addImage").val().trim().length == 0 || $("#addBio").val().trim().length == 0) {
        alert('Please fill in the information.');
    }

    else {

        var talent = {
            Name: $('#addName').val(),
            ShortName: $('#addShortName').val(),
            Reknown: $('#addReknown').val(),
            Bio: $('#addBio').val(),
            ImageLink: $('#addImage').file(),
            CreatedBy: sessionStorage.getItem('email'),
            UpdatedBy: sessionStorage.getItem('email')
        };

        $.ajax({
            url: '/api/talents',
            headers: { 'Authorization': 'Bearer ' + sessionStorage.getItem('tokenKey') },
            cache: false,
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(talent),
            //success: function () {
            //    hideModal();
            //}
            statusCode: {
                201: function () {
                    hideModal();
                }
            }
        }).success(function (data) {
            alert(success);
            window.location.replace(data);
        });

    }
});


//to get info about 1 and display in form
function getTalent(talentId) {
    $.ajax({
        url: '/api/talents/' + talentId,
        cache: false,
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            $('#editName').val(data.Name);
            $('#editShortName').val(data.ShortName);
            $('#editReknown').val(data.Reknown);
            $('#editBio').val(data.Bio);
            $('#editImage').val(data.ImageLink);
        }
    });
}

//to get Id for updating
$('#editModal').on('shown.bs.modal', function (e) {
    if (sessionStorage.getItem('tokenKey') == null || sessionStorage.getItem('email') == null) {
        alertDone('Login to access this feature');
    }
    else {
        talentId = $(e.relatedTarget).data('talentid');
        getTalent(talentId);
    }
});

//to update
$('#btnSave').click(function () {

    if ($("#editName").val().trim().length == 0 || $("#editShortName").val().trim().length == 0 || $("#editReknown").val().trim().length == 0 || $("#editImage").val().trim().length == 0 || $("#editBio").val().trim().length == 0) {
        alert('Please fill in the information.');
    }

    else {

        var talent = {
            Name: $('#editName').val(),
            ShortName: $('#editShortName').val(),
            Reknown: $('#editReknown').val(),
            Bio: $('#editBio').val(),
            ImageLink: $('#editImage').val()
        };

        $.ajax({
            url: '/api/talents/' + talentId,
            headers: { 'Authorization': 'Bearer ' + sessionStorage.getItem('tokenKey') },
            cache: false,
            type: 'PUT',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(talent),
            success: function () {
                hideModal();
            }
        })
    }
});


//to get Id for deleting
$('#deleteModal').on('shown.bs.modal', function (e) {
    if (sessionStorage.getItem('tokenKey') == null || sessionStorage.getItem('email') == null) {
        alertDone('Login to access this feature');
    }
    else {
        talentId = $(e.relatedTarget).data('talentid');
    }
});

//to delete
$('#btnDelete').click(function () {

    $.ajax({
        url: '/api/talents/' + talentId,
        headers: { 'Authorization': 'Bearer ' + sessionStorage.getItem('tokenKey') },
        cache: false,
        type: 'DELETE',
        contentType: 'application/json; charset=utf-8',
        success: function () {
            hideModal();
        }
    })

});




//get all
function showResults() {

    var searchField = $('#search').val();

    //Modify search to be case insensitive
    var myExp = new RegExp(searchField, "i");

    $.getJSON('/api/talents', function (data) {

        //Example of generated result

        //<div class="row col-md-10 col-md-offset-1">
        //    <div class="panel panel-default">
        //        <div class="panel-heading">
        //            <h3 class="panel-title pull-left">
        //                Barot Bellingham (Royal Academy of Painting and Sculpture)
        //            </h3>
        //            <button class="btn btn-danger pull-right" data-toggle="modal" data-target="#deleteModal" data-talentid="1"><span class="glyphicon glyphicon-trash"></span></button>
        //            <button class="btn btn-warning pull-right" data-toggle="modal" data-target="#editModal" data-talentid="1"><span class="glyphicon glyphicon-edit"></span></button>
        //            <div class="clearfix"></div>
        //        </div>
        //        <div class="panel-body">
        //            <img src="http://res.cloudinary.com/talentsearch/image/upload/v1466085085/talents/Barot_Bellingham.jpg" alt="Barot Bellingham">
        //            <p>Barot has just finished his final year at The Royal Academy of Painting and Sculpture, where he excelled in glass etching paintings and portraiture. Hailed as one of the most diverse artists of his generation, Barot is equally as skilled with watercolors as he is with oils, and is just as well-balanced in different subject areas. Barot's collection entitled "The Un-Collection" will adorn the walls of Gilbert Hall, depicting his range of skills and sensibilities - all of them, uniquely Barot, yet undeniably different</p>
        //        </div>
        //    </div>
        //</div>

        var output = '';

        $.each(data, function (key, val) {

            if ((val.Name.search(myExp) != -1) || (val.Bio.search(myExp) != -1)) {

                output += '<div class="row col-md-10 col-md-offset-1">';
                output += '<div class="panel panel-default">';
                output += '<div class="panel-heading">';
                output += '<h3 class="panel-title pull-left">';
                output += val.Name + ' (' + val.Reknown + ')';
                output += '</h3>';
                output += '<button class="btn btn-danger pull-right" data-toggle="modal" data-target="#deleteModal" data-talentid="' + val.Id + '"><span class="glyphicon glyphicon-trash"></span></button>';
                output += '<button class="btn btn-warning pull-right" data-toggle="modal" data-target="#editModal" data-talentid="' + val.Id + '"><span class="glyphicon glyphicon-edit"></span></button>';
                output += '<div class="clearfix"></div>';
                output += '</div>';
                output += '<div class="panel-body">';
                output += '<img src="' + val.ImageLink + '" alt="' + val.Name + '" />';
                output += '<p>' + val.Bio + '</p>';
                output += '</div>';
                output += '</div>';
                output += '</div>';

            }
        });

        $('#results').html(output);
    });
};

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


//to register
$('#btnRegister').click(function () {

    validateForm();

    function validateForm() {
        var msg = '';
        msg += checkEmail();
        msg += checkUsername();
        msg += checkPass();
        msg += checkPassEqual();


        if (msg == '') {

            $('#feedback').text("Processing Registration...");

            //generating random code for email confirmation
            var chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXTZabcdefghiklmnopqrstuvwxyz";
            var string_length = 30;
            var confirmationCode = '';
            for (var i = 0; i < string_length; i++) {
                var rnum = Math.floor(Math.random() * chars.length);
                confirmationCode += chars.substring(rnum, rnum + 1);
            }

            //data object to be sent
            var sendData = {
                Email: $('#registerEmail').val(),
                Password: $('#registerPassword1').val(),
                ConfirmPassword: $('#registerPassword2').val(),
                userName: $('#registerUsername').val()
            };

            //if email web service successfully called, do registration service
            $.ajax({
                type: 'POST',
                url: '/api/Account/Register',
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify(sendData)
            }).done(function (data) {

                $('#feedback').text("Successfully registered, welcome! Sending confirmation email now...");

                //ajax call to email web service for email confirmation
                $.ajax({
                    type: 'POST',
                    url: 'https://cscass2emailwebservice.azurewebsites.net/EmailWebService.asmx/SendGmail',
                    contentType: 'application/x-www-form-urlencoded',
                    data: 'msgFrom=donotreply@domaincom&msgTo=' + sendData.Email + '&msgSubject=Talent Service Email Confirmation&msgBody=Please visit https://cscass2talentsearch.azurewebsites.net/Home/Index to start using Talent Web Service.',
                    processData: false
                }).done(function () {
                    $('#feedback').text("Confirmation email has been sent. Redirecting you now...");
                    window.location.replace("/home/index");
                }).fail(function () {
                    $('#feedback').text("");
                    $('#badInput').text("Email has failed to sent. System may be experiencing technical issues.");
                });

            }).fail(function (data) {
                $('#badInput').text("Please ensure the fields are entered properly. The Email or Username may have already been used.");
                $('#feedback').text('');

                var errormessage = '';

                //$.each(data, function (key, val) {
                //    errormesssage += val + '\n';
                //    errormessage += "test";
                //})

                //$('#badInput').text(errormessage);
                //alert(errormessage);

                //alert("Error: " + data.responseText);

            });

        }

        else { alert(msg); }
    }

    function checkEmail() {
        regex = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        if (regex.test($('#registerEmail').val().trim()) == false) { return "Invalid email address. Please enter a valid email address.\n\n"; }
        else { return ""; }
    }

    function checkPass() {
        regex = /^(?=.*[0-9])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]{8,16}$/;
        if (regex.test($('#registerPassword1').val()) == false) { return "Invalid password. Ensure it is 8-16 characters in length, contains at least 1 number, and at least 1 special character.\n\n"; }
        else { return ""; }
    }

    function checkPassEqual() {
        if ($('#registerPassword1').val() == $('#registerPassword2').val())
            return "";
        else
            return "Entered password is not the same as the confirmation.\n\n";
    }

    function checkUsername() {

        if ($('#registerUsername').val().trim().length < 1)
        { return "Invalid username.\n\n"; }
        else { return ""; }
    }


});

//to update password
$('#btnUpdatePassword').click(function () {

    var sendData = {
        OldPassword: $('#oldPassword').val(),
        NewPassword: $('#updatePassword').val(),
        ConfirmPassword: $('#updatePassword2').val(),
    };

    $.ajax({
        type: 'POST',
        headers: { 'Authorization': 'Bearer ' + sessionStorage.getItem('tokenKey') },
        url: '/api/Account/ChangePassword',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(sendData)
    }).done(function (data) {
        alertDone('Successfully updated password! Please re-login with your new password.');
        logout();
    }).fail(function (data) {
        alertDone('Failed to update password.');
        $('#badPassword').text("Password failed to update. Please ensure new password is different from old one and confirmation password is same as new password.");
    });
});

//to update username
$('#btnUpdate').click(function () {

    var sendData = {
        UserName: $('#updateUsername').val()
    };

    $.ajax({
        type: 'POST',
        headers: { 'Authorization': 'Bearer ' + sessionStorage.getItem('tokenKey') },
        url: '/api/Account/UpdateUsername',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(sendData)
    }).done(function (data) {
        alertDone('Successfully updated username! Please re-login with your username.');
        logout();
    }).fail(function (data) {
        $('#badUsername').text('Username might have already been in used. Please try a more unique password.');
    });
});

//to login
$('#btnLogin').click(function () {

    var loginData = {
        grant_type: 'password',
        username: $('#loginUsername').val(),
        password: $('#loginPassword').val()
    };

    $.ajax({
        type: 'POST',
        url: '/Token',
        data: loginData
    }).done(function (data) {
        sessionStorage.setItem('username', data.userName);
        sessionStorage.setItem('tokenKey', data.access_token);
        $('.modal').modal('hide');
        initializeNavbar();

    }).fail(function (data) {
        $('#loginFeedback').text("Invalid username or password. Please try again.");
    });
});


//to logout
function logout() {
    sessionStorage.removeItem('username');
    sessionStorage.removeItem('tokenKey');
    initializeNavbar();
}