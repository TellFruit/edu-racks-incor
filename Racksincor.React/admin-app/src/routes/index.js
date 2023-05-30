import React from "react";
import {
  Route,
  BrowserRouter as Router,
  Routes as Switch
} from "react-router-dom";
import Login from "../pages/login";
import Register from "../pages/register";

const Routes = () => {

  return (
      <Router>
        <Switch>
          <Route path="/login" element={<Login />} />
          <Route path="/register" element={<Register />} />
        </Switch>
      </Router>
  );
};

export default Routes;
