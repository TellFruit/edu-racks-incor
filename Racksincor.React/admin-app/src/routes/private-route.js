import React from 'react';
import { Navigate, Outlet } from 'react-router-dom';
import { getToken } from '../api/token';

const PrivateRoute = () => {
    const auth = getToken() == null ? false : true;

    return auth ? <Outlet /> : <Navigate to="/login" />;
}

export default PrivateRoute;