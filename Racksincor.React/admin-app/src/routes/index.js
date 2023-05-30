import React from "react";
import {
    Route,
    BrowserRouter as Router,
    Routes as Switch,
} from "react-router-dom";
import Login from "../pages/login";

const Routes = () => {
    return (
        <Router>
            <Switch>
                <Route path="/login" element={<Login />} />
            </Switch>
        </Router>
    );
};

export default Routes;
