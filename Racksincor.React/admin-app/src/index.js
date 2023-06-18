import React from "react";
import ReactDOM from "react-dom/client";
import { ThemeProvider } from "@mui/material/styles";
import { I18nextProvider } from "react-i18next";
import i18n from "./i18n/i18n";
import "@fontsource/roboto";
import "./index.css";
import Routes from "./routes";
import theme from "./material/theme";
import Modal from "react-modal";

ReactDOM.createRoot(document.getElementById("root")).render(
    <React.StrictMode>
        <ThemeProvider theme={theme}>
            <I18nextProvider i18n={i18n}>
                <Routes />
            </I18nextProvider>
        </ThemeProvider>
    </React.StrictMode>
);

Modal.setAppElement("#root");
