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
import ProductPage from "../pages/product";
import ProductRackPage from "../pages/product-rack";
import PromotionPage from "../pages/promotion";
import ProductPromotionPage from "../pages/product-promotion";

const Routes = () => {
    return (
        <Router>
            <Navbar />
            <Switch>
                <Route path="/login" element={<LoginPage />} />
                <Route path="/rack" element={<PrivateRoute />}>
                    <Route path="/rack" element={<RackPage />} />
                </Route>
                <Route path="/product" element={<PrivateRoute />}>
                    <Route path="/product" element={<ProductPage />} />
                </Route>
                <Route path="/promotion" element={<PrivateRoute />}>
                    <Route path="/promotion" element={<PromotionPage />} />
                </Route>
                <Route path="/rack/:rackId/products" element={<PrivateRoute />}>
                    <Route
                        path="/rack/:rackId/products"
                        element={<ProductRackPage />}
                    />
                </Route>
                <Route
                    path="/:promotionType/:rackId/products"
                    element={<PrivateRoute />}
                >
                    <Route
                        path="/:promotionType/:rackId/products"
                        element={<ProductPromotionPage />}
                    />
                </Route>
            </Switch>
        </Router>
    );
};

export default Routes;
