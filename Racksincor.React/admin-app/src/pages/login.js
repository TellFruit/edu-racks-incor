import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import axios from "../api/instance";
import { setToken, isRoleValid } from "../api/token";
import { Link } from "react-router-dom";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import Container from "@mui/material/Container";
import Box from "@mui/material/Box";

const LoginPage = () => {
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
                    navigate("/company");
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
                <h2>Login</h2>
                <TextField
                    label="Email"
                    variant="outlined"
                    fullWidth
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                    sx={{ marginBottom: 2 }}
                />
                <TextField
                    label="Password"
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
                    Login
                </Button>
                <Box sx={{ marginTop: 2 }}>
                    <Link to="/register">
                        Don't have an account? Register here.
                    </Link>
                </Box>
            </Box>
        </Container>
    );
};

export default LoginPage;
