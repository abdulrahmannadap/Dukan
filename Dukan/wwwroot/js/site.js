// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('#mainTable').DataTable({
        "paging": true,        // Enables pagination
        "searching": true,     // Enables the search box
        "info": true,          // Shows table information
        "ordering": true       // Enables column sorting
    });
});