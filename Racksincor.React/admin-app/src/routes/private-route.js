import React from "react";
import { Navigate, Outlet } from "react-router-dom";
import { isTokenValid } from "../api/token";

const PrivateRoute = () => {
    return isTokenValid() ? (
        <Outlet />
    ) : (
        <Navigate to="/login" />
    );
};

export default PrivateRoute;
