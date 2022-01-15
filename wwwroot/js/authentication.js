let authConfig = {
    authTokenkey: "authToken",
    authExpirykey: "authExpiry",
    userInfo : "userInfo"
}
function isAuthenticated() {
    const token = localStorage.getItem(authConfig.authTokenkey);
    const expiry = localStorage.getItem(authConfig.authExpirykey);
    if (!token || !expiry) {
        return false;
    }
    else if (new Date(parseInt(expiry)).getTime() < Date.now()) {
        return false;
    }
    else {
        return true;
    }
}

function getAuthToken() {
    const token = localStorage.getItem(authConfig.authTokenkey);
    return token;
}

function getUserInfo() {
    if (isAuthenticated()) {
        const userInfo = JSON.parse(localStorage.getItem(authConfig.userInfo));
        return userInfo;
    } else {
        return null;
    }
}

function setAuthInfo(authToken, authExpiry, userInfo) {
    localStorage.setItem(authConfig.authTokenkey, authToken);
    localStorage.setItem(authConfig.authExpirykey, authExpiry);
    const userInfoString = JSON.stringify(userInfo) || "";
    localStorage.setItem(authConfig.userInfo, userInfoString);
}

function clearAuthInfo() {
    localStorage.removeItem(authConfig.authTokenkey);
    localStorage.removeItem(authConfig.authExpirykey);
    localStorage.removeItem(authConfig.userInfo);
}

async function login(username, password) {
    try {
        const data = { email: username, password };
        const response = await axios.post('/auth/token', data);
        const token = response.headers.token;
        const tokenExpiry = response.headers.tokenexpiry;
        const userInfo = {
            email: response.data.data.email,
            userName: response.data.data.userName,
            firstName: response.data.data.firstName,
            lastName: response.data.data.lastName,
            roles: response.data.data.roles
        }
        setAuthInfo(token, tokenExpiry, userInfo);
        updateUserInfoDisplay();
        notifyLoginSuccess();
        
    } catch (error) {
        notifyLoginError(error.response.data.message);
    }
}

async function register(registrationInfo) {
    try {
        const data = registrationInfo;
        const response = await axios.post('/auth/register', data);
        if (response) {
            notifyRegistrationSuccess();
            window.location.href = appConfig.loginUrl;
        }

    } catch (error) {
        notifyGeneralError(error.response.data.message);
    }
}

function logout() {
    clearAuthInfo();
    $("#logout").hide();
    $("#userInfo").hide();
    $("#login").show();
    $("#register").show();
    window.location.href = appConfig.appBaseUrl;
}

function updateUserInfoDisplay() {
    if (isAuthenticated()) {
        $("#userInfo").show();
        $("#userInfo").text(getUserInfo().email);
        $("#logout").show();
        $("#login").hide();
        $("#register").hide();
    }
    else {
        $("#logout").hide();
        $("#userInfo").hide();
        $("#login").show();
        $("#register").show();

    }
}

