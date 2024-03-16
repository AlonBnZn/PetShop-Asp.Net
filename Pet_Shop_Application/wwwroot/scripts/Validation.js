$(document).ready(function() {
    $("#commentForm").submit(function() {
        var textValue = $("#text").val().trim();

        if (textValue === "") {
            alert("Please enter a comment before submitting.");
            return false; // Prevent form submission
        }

        // You can add more validation logic here if needed
        return true; // Allow form submission
    });
});
