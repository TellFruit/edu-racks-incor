import React, { useState } from "react";
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
import i18n from "../../i18n/i18n";
import { removeToken, isTokenValid } from "../../api/token";
import { useNavigate } from "react-router-dom";

const Navbar = () => {
    const navigate = useNavigate();
    const [language, setLanguage] = useState(i18n.language);

    const handleLogout = () => {
        removeToken();
        navigate("/");
    };

    const handleLanguageChange = (event) => {
        const selectedLanguage = event.target.value;
        i18n.changeLanguage(selectedLanguage).then(() => {
            setLanguage(selectedLanguage);
        });
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
                        {i18n.t("navbar.racks")}
                    </Button>
                    <Button
                        component={RouterLink}
                        to="/product"
                        color="inherit"
                    >
                        {i18n.t("navbar.products")}
                    </Button>
                    <Button
                        component={RouterLink}
                        to="/promotion"
                        color="inherit"
                    >
                        {i18n.t("navbar.promotions")}
                    </Button>
                </Box>
                <Box>
                    <Select
                        value={language}
                        onChange={handleLanguageChange}
                        sx={{
                            "&:before": { borderBottom: "none" },
                            color: "inherit",
                        }}
                    >
                        <MenuItem value="en">English</MenuItem>
                        <MenuItem value="uk">Українська</MenuItem>
                    </Select>
                    {isTokenValid() ? (
                        <Button color="inherit" onClick={handleLogout}>
                            {i18n.t("navbar.logout")}
                        </Button>
                    ) : (
                        <Button
                            component={RouterLink}
                            to="/login"
                            color="inherit"
                        >
                            {i18n.t("navbar.login")}
                        </Button>
                    )}
                </Box>
            </FlexToolbar>
        </AppBar>
    );
};

export default Navbar;
