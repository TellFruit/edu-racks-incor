import React from "react";
import {
    Route,
    BrowserRouter as Router,
    Routes as Switch,
} from "react-router-dom";
import PrivateRoute from "./private-route";
import LoginPage from "../pages/login";
import CompanyPage from "../pages/company";
import ShopPage from "../pages/shop";

const Routes = () => {
    return (
        <Router>
            <Switch>
                <Route path="/login" element={<LoginPage />} />
                <Route path="/company" element={<PrivateRoute />}>
                    <Route path="/company" element={<CompanyPage />} />
                </Route>
                <Route path="/company/:id/shops" element={<PrivateRoute />}>
                    <Route path="/company/:id/shops" element={<ShopPage />} />
                </Route>
            </Switch>
        </Router>
    );
};

export default Routes;
