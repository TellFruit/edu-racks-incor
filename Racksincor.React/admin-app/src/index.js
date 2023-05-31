import React from "react";
import ReactDOM from "react-dom/client";
import { ThemeProvider } from '@mui/material/styles';
import Routes from "./routes";
import axios from "axios";
import theme from "./material/theme";
import Modal from "react-modal";

axios.defaults.baseURL = "https://localhost:7232/api/";

ReactDOM.createRoot(document.getElementById("root")).render(
  <React.StrictMode>
    <ThemeProvider theme={theme}>
      <Routes />
    </ThemeProvider>
  </React.StrictMode>
);

Modal.setAppElement('#root');