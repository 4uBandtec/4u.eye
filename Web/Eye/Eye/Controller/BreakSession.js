function breakSession() {
    PageMethods.BreakSession(function () { window.location = "Login.aspx" }, onError);
}