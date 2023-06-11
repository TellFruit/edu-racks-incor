import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import axios from "../api/instance";
import { setToken, isRoleValid } from "../api/token";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import Container from "@mui/material/Container";
import Box from "@mui/material/Box";
import { useTranslation } from "react-i18next";

const LoginPage = () => {
  const { t } = useTranslation();
  const navigate = useNavigate();
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const handleLogin = async () => {
    try {
      const response = await axios.post("/auth/login", {
        email,
        password,
      });

      if (response.status === 200) {
        const token = response.data;
        setToken(token);

        if (isRoleValid()) {
          navigate("/");
        } else {
          setEmail("");
          setPassword("");
        }
      } else {
        console.error("Login failed");
      }
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <Container maxWidth="xs">
      <Box sx={{ marginTop: 8 }}>
        <h2>{t("loginPage.title")}</h2>
        <TextField
          label={t("loginPage.emailLabel")}
          variant="outlined"
          fullWidth
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          sx={{ marginBottom: 2 }}
        />
        <TextField
          label={t("loginPage.passwordLabel")}
          variant="outlined"
          type="password"
          fullWidth
          value={password}
          onChange={(e) => setPassword(e.target.value)}
          sx={{ marginBottom: 2 }}
        />
        <Button
          variant="contained"
          color="primary"
          fullWidth
          onClick={handleLogin}
        >
          {t("loginPage.loginButton")}
        </Button>
      </Box>
    </Container>
  );
};

export default LoginPage;
