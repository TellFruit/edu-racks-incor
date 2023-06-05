import React from "react";
import { Navigate, Outlet } from "react-router-dom";
import { isTokenValid, isRoleValid } from "../api/token";

const PrivateRoute = () => {
    return isTokenValid() && isRoleValid() ? (
        <Outlet />
    ) : (
        <Navigate to="/login" />
    );
};

export default PrivateRoute;
