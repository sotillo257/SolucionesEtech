$(window).on('resize', function () {
    resizeChanges();
});

$(document).ready(function () { 
    resizeChanges();
});
function resizeChanges() {
    if ($(window).width() < 769) {
        $(".label-inputs").css("display", "none");

        $("#inputUsername").attr("placeholder", "Username");
        $("#inputEmail").attr("placeholder", "Email");
        $("#inputFPass").attr("placeholder", "Password");
        $("#inputSPass").attr("placeholder", "Confirm Password");

        $("#inputName").attr("placeholder", "Name");
        $("#inputLastname").attr("placeholder", "Lastname");
        $("#inputAddress").attr("placeholder", "Address");
        $("#inputCity").attr("placeholder", "City");
        $("#inputZipcode").attr("placeholder", "Zip code");
        $("#inputContactNum").attr("placeholder", "Contact number");
        $("#inputContactNum2").attr("placeholder", "Alternate contact number");
        $("#inputAlternateMail").attr("placeholder", "Alternate email");

        $("#inputLicenseNum").attr("placeholder", "Driver's license number");
        $("#inputStateIssue").attr("placeholder", "State of issue");

        $("#inputSalary").attr("placeholder", "Salary range expected");
    } else {
        $(".label-inputs").css("display", "block");
        $("input").removeAttr("placeholder");
        $("#inputBirthdate").attr("placeholder", "Date for birth");
        $("#inputDateforwork").attr("placeholder", "Date available for work");
        $("#expDate").attr("placeholder", "Expiration date");
    }
}