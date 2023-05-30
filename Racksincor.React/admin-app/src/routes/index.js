import React from "react";
import {
    Route,
    BrowserRouter as Router,
    Routes as Switch,
} from "react-router-dom";
import LoginPage from "../pages/login";

const Routes = () => {
    return (
        <Router>
            <Switch>
                <Route path="/login" element={<LoginPage />} />
            </Switch>
        </Router>
    );
};

export default Routes;
