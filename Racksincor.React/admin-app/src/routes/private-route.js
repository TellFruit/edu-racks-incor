import React from "react";
import { Navigate, Outlet } from "react-router-dom";
import { getToken, isTokenExpired } from "../api/token";

const PrivateRoute = () => {
    const token = getToken();

    return token == null || isTokenExpired(token) ? (
        <Navigate to="/login" />
    ) : (
        <Outlet />
    );
};

export default PrivateRoute;
