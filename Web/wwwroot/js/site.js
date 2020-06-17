// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function isEmpty(str) {
    return (!str || 0 === str.length);
}

function isBlank(str) {
    return (!str || /^\s*$/.test(str));
}

function isEmptyOrBlank(str) {

    if (str === undefined)
        return true;

    return isEmpty(str) && isBlank(str);
}

String.prototype.isEmpty = function() {
    return (this.length === 0 || !this.trim());
};

