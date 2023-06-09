import React from "react";
import { Link as RouterLink } from "react-router-dom";
import { AppBar, Typography, Button, Box } from "@mui/material";
import { FlexToolbar } from "../../material/flex-tool-bar";
import { removeToken, isTokenValid } from "../../api/token";
import { useNavigate } from "react-router-dom";

const Navbar = () => {
    const navigate = useNavigate();

    const handleLogout = () => {
        removeToken();
        navigate("/");
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
                        Racks
                    </Button>
                    <Button
                        component={RouterLink}
                        to="/product"
                        color="inherit"
                    >
                        Products
                    </Button>
                    <Button
                        component={RouterLink}
                        to="/promotion"
                        color="inherit"
                    >
                        Promotions
                    </Button>
                </Box>
                <Box>
                    {isTokenValid() ? (
                        <Button color="inherit" onClick={handleLogout}>
                            Logout
                        </Button>
                    ) : (
                        <Button
                            component={RouterLink}
                            to="/login"
                            color="inherit"
                        >
                            Login
                        </Button>
                    )}
                </Box>
            </FlexToolbar>
        </AppBar>
    );
};

export default Navbar;
