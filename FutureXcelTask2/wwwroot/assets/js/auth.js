// LOGIN
function loginUser() {
    $("#errorMsg").hide();

    $.ajax({
        url: "/api/auth/login",
        method: "POST",
        contentType: "application/json",
        xhrFields: { withCredentials: true }, 
        data: JSON.stringify({
            email: $("#email").val(),
            password: $("#password").val()
        }),
        success: function () {
            alert("Login successful!");
            window.location.href = "index.html";
        },
        error: function () {
            $("#errorMsg").text("Invalid email or password").show();
        }
    });
}

// SIGNUP
function signupUser() {
    $("#errorMsg").hide();

    $.ajax({
        url: "/api/auth/signup",
        method: "POST",
        contentType: "application/json",
        xhrFields: { withCredentials: true }, 
        data: JSON.stringify({
            name: $("#name").val(),
            email: $("#email").val(),
            password: $("#password").val()
        }),
        success: function () {
            alert("Signup successful! Please login.");
            window.location.href = "login.html";
        },
        error: function () {
            $("#errorMsg").text("Signup failed. Email may already exist.").show();
        }
    });
}

// LOGOUT
function logoutUser() {
    $.post("/api/auth/logout", function () {
        window.location.href = "login.html";
    });
}

// CHECK LOGIN
$(document).ready(function () {
    // Try fetching current user to see if token cookie exists
    $.get("/api/auth/me")
        .fail(function () {
            if (window.location.pathname.includes("index.html")) {
                window.location.href = "login.html";
            }
        });
});
