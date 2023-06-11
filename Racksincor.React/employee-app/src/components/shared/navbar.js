import React from "react";
import i18n from "../../i18n/i18n";
import { useTranslation } from "react-i18next";
import { useNavigate } from "react-router-dom";
import { Link as RouterLink } from "react-router-dom";
import {
    AppBar,
    Typography,
    Button,
    Box,
    MenuItem,
    Select,
} from "@mui/material";
import { FlexToolbar } from "../../material/flex-tool-bar";
import { removeToken, isTokenValid } from "../../api/token";

const Navbar = () => {
    const { t } = useTranslation();
    const navigate = useNavigate();

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
            <FlexToolbar>
                <Box>
                    <Typography
                        variant="h6"
                        component="div"
                        sx={{ flexGrow: 1 }}
                    >
                        Racksincor
                    </Typography>
                </Box>
                <Box>
                    <Button component={RouterLink} to="/rack" color="inherit">
                        {t("navbar.racks")}
                    </Button>
                    <Button
                        component={RouterLink}
                        to="/product"
                        color="inherit"
                    >
                        {t("navbar.products")}
                    </Button>
                    <Button
                        component={RouterLink}
                        to="/promotion"
                        color="inherit"
                    >
                        {t("navbar.promotions")}
                    </Button>
                </Box>
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
                            {t("navbar.logout")}
                        </Button>
                    ) : (
                        <Button
                            component={RouterLink}
                            to="/login"
                            color="inherit"
                        >
                            {t("navbar.login")}
                        </Button>
                    )}
                </Box>
            </FlexToolbar>
        </AppBar>
    );
};

export default Navbar;
