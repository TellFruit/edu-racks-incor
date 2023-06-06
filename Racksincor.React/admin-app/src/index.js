import React from "react";
import ReactDOM from "react-dom/client";
import { ThemeProvider } from '@mui/material/styles';
import '@fontsource/roboto';
import './index.css';
import Routes from "./routes";
import theme from "./material/theme";
import Modal from "react-modal";
ReactDOM.createRoot(document.getElementById("root")).render(
  <React.StrictMode>
    <ThemeProvider theme={theme}>
      <Routes />
    </ThemeProvider>
  </React.StrictMode>
);

Modal.setAppElement('#root');