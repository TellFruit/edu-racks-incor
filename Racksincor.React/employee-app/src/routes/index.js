import React from "react";
import {
    Route,
    BrowserRouter as Router,
    Routes as Switch,
} from "react-router-dom";
import PrivateRoute from "./private-route";
import Navbar from "../components/shared/navbar";
import LoginPage from "../pages/login";
import RackPage from "../pages/rack";

const Routes = () => {
    return (
        <Router>
            <Navbar/>
            <Switch>
                <Route path="/login" element={<LoginPage />} />
                <Route path="/rack" element={<PrivateRoute />}>
                    <Route path="/rack" element={<RackPage />} />
                </Route>
            </Switch>
        </Router>
    );
};

export default Routes;
