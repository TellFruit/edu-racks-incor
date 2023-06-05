import React from "react";
import {
    Route,
    BrowserRouter as Router,
    Routes as Switch,
} from "react-router-dom";
import Navbar from "../components/shared/navbar";
import LoginPage from "../pages/login";

const Routes = () => {
    return (
        <Router>
            <Navbar/>
            <Switch>
                <Route path="/login" element={<LoginPage />} />
            </Switch>
        </Router>
    );
};

export default Routes;
