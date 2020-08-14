// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $("#loginBtn").click(function () {
        var username = $("#username").val();
        var password = $("#password").val();
        if (username.length === 0 || password.length === 0) {
            alert("Cannot leave username/password field blank");
            return;
        }
        $("#hashPwd").val(CryptoJS.SHA256(password).toString());
        $("#password").val("");
        $("#loginForm").submit();
    });

    $("#changePasswordBtn").click(function () {
        var oldPassword = $("#oldPassword").val();
        $("#hashPwd").val(CryptoJS.SHA256(oldPassword).toString());
        $("#oldPassword").val("");
        $("#changePasswordForm").submit();
    });
})