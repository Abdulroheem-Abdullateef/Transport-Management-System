function notifyLoginError(message) {
    $.notify({
        title: '<strong>Login Error!</strong>',
        message: message
    }, {
        type: 'danger'
    });
}

function notifyLoginSuccess() {
    $.notify({
        icon: 'glyphicon glyphicon-star',
        message: 'Login successful!'
    }, {
        type: 'success'
    });
}
function notifyRegistrationSuccess() {
    $.notify({
        icon: 'glyphicon glyphicon-star',
        message: 'You have successfully registered. kindly login!'
    }, {
        type: 'success'
    });
}
function notifyDataRequired(message) {
    $.notify({
        icon: 'glyphicon glyphicon-star',
        message: message
    }, {
        type: 'warning'
    });
}

function notifyUnAuthenticatedError() {
    $.notify({
        icon: 'glyphicon glyphicon-star',
        title: '<strong>Login Required!</strong>',
        message: 'You are not authenticated. kindly log in to continues.'
    }, {
        type: 'danger'
    });
}
function notifyUnAuthorizedError() {
    $.notify({
        icon: 'glyphicon glyphicon-star',
        title: '<strong>Access Denied!</strong>',
        message: 'You do not have enough permission to perform this action.'
    }, {
        type: 'warning'
    });
}
function notifyGeneralError(message) {
    $.notify({
        icon: 'glyphicon glyphicon-star',
        title: '<strong>Error!</strong>',
        message: message
    }, {
        type: 'danger'
    });
}