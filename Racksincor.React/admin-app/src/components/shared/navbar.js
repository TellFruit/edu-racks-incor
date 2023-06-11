import React from "react";
import i18n from "../../i18n/i18n";
import { Link as RouterLink } from "react-router-dom";
import {
    AppBar,
    Toolbar,
    Typography,
    Button,
    Box,
    Select,
    MenuItem
} from "@mui/material";
import { removeToken, isTokenValid } from "../../api/token";
import { useNavigate } from "react-router-dom";
import { useTranslation } from "react-i18next";

const Navbar = () => {
    const navigate = useNavigate();
    const { t } = useTranslation();

    const handleLogout = () => {
        removeToken();
        navigate("/");
    };

    const handleLanguageChange = (event) => {
        const selectedLanguage = event.target.value;
        i18n.changeLanguage(selectedLanguage);
    };

    return (
        <AppBar position="static">
            <Toolbar>
                <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
                    Racksincor
                </Typography>
                <Box sx={{ display: "flex", alignItems: "center" }}>
                    <Select
                        value={i18n.language}
                        onChange={handleLanguageChange}
                        sx={{
                            "&:before": { borderBottom: "none" },
                            color: "inherit",
                            ml: 2,
                        }}
                    >
                        <MenuItem value="en">English</MenuItem>
                        <MenuItem value="uk">Українська</MenuItem>
                    </Select>
                    {isTokenValid() ? (
                        <Button color="inherit" onClick={handleLogout}>
                            {t("navbar.logoutButton")}
                        </Button>
                    ) : (
                        <Button
                            component={RouterLink}
                            to="/login"
                            color="inherit"
                        >
                            {t("navbar.loginButton")}
                        </Button>
                    )}
                </Box>
            </Toolbar>
        </AppBar>
    );
};

export default Navbar;
