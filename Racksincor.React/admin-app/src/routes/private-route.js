import React from 'react';
import { Navigate, Outlet } from 'react-router-dom';
import { getToken } from '../api/token';

const PrivateRoute = () => {
    return getToken() == null ? <Navigate to="/login" />  : <Outlet />;
}

export default PrivateRoute;