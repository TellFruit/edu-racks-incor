import React from "react";
import ReactDOM from "react-dom/client";
import Routes from "./routes";
import axios from "axios";

axios.defaults.baseURL = "https://localhost:7232";


const root = ReactDOM.createRoot(document.getElementById("root"));

root.render(
    <React.StrictMode>
        <Routes />
    </React.StrictMode>
);
