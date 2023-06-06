import jwtDecode from "jwt-decode";

const enforcedRole = "Employee";

export function getToken() {
    return localStorage.getItem("token");
}

export function setToken(token) {
    localStorage.setItem("token", token);
}

export function removeToken() {
    localStorage.removeItem("token");
}

function isTokenPresent() {
    const token = getToken();

    return token != null;
}

function isTokenRelevant() {
    const token = getToken();

    try {
        const decodedToken = jwtDecode(token);
        const currentTime = Date.now() / 1000;

        return decodedToken.exp > currentTime;
    } catch (error) {
        return false;
    }
}

export function isTokenValid() {
    return isTokenPresent() || isTokenRelevant();
}

export function isRoleValid() {
    const token = getToken();

    try {
        const decodedToken = jwtDecode(token);
        const userRole = decodedToken.role;

        return userRole === enforcedRole;
    } catch (error) {
        return false;
    }
}

export function extractShopId() {
    const token = getToken();

    try {
        const decodedToken = jwtDecode(token);
        
        return decodedToken.shopId;
    } catch (error) {
        return 0;
    }
}