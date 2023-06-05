import React from "react";
import {
    Route,
    BrowserRouter as Router,
    Routes as Switch,
} from "react-router-dom";
import Navbar from "../components/shared/navbar";
import PrivateRoute from "./private-route";
import LoginPage from "../pages/login";
import CompanyPage from "../pages/company";
import ShopPage from "../pages/shop";
import EmployeePage from "../pages/employee";

const Routes = () => {
    return (
        <Router>
            <Navbar/>
            <Switch>
                <Route path="/login" element={<LoginPage />} />
                <Route path="/company" element={<PrivateRoute />}>
                    <Route path="/company" element={<CompanyPage />} />
                </Route>
                <Route path="/company/:companyId/shops" element={<PrivateRoute />}>
                    <Route path="/company/:companyId/shops" element={<ShopPage />} />
                </Route>
                <Route path="/shop/:shopId/employees" element={<PrivateRoute />}>
                    <Route path="/shop/:shopId/employees" element={<EmployeePage />} />
                </Route>
            </Switch>
        </Router>
    );
};

export default Routes;
