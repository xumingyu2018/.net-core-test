// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function showFilename(file) {
    $("#filename_label").html(file.name);
}

function type_change() {
    var options = $("select option:selected"); //获取选中的项
    $("input[name='TypeId']").val(options.attr("id"));
    $("input[name='TypeName']").val(options.val());
}

