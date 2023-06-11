import React, { useState } from "react";
import Button from "@mui/material/Button";
import Grid from "@mui/material/Grid";
import Paper from "@mui/material/Paper";
import Box from "@mui/material/Box";
import Pagination from "@mui/material/Pagination";
import { useTranslation } from "react-i18next";

const ShopList = ({ shops, onDelete, onOpenEditModal, onViewEmployees }) => {
    const { t } = useTranslation();
    const [page, setPage] = useState(1);
    const shopsPerPage = 5;
    const totalPages = Math.ceil(shops.length / shopsPerPage);

    const handlePageChange = (event, value) => {
        event.preventDefault();
        setPage(value);
    };

    const startIndex = (page - 1) * shopsPerPage;
    const endIndex = startIndex + shopsPerPage;
    const displayedShops = shops.slice(startIndex, endIndex);

    return (
        <div>
            {displayedShops.map((shop) => (
                <div key={shop.id}>
                    <Paper variant="outlined" sx={{ p: 2, mb: 2 }}>
                        <Grid container spacing={2} alignItems="center">
                            <Grid item xs={6}>
                                <Box>
                                    <p>
                                        {t("shopList.name")}: {shop.name}
                                    </p>
                                    <p>
                                        {t("shopList.address")}: {shop.address}
                                    </p>
                                </Box>
                            </Grid>
                            <Grid item xs={6}>
                                <Box display="flex" justifyContent="flex-end">
                                    <Button
                                        variant="contained"
                                        color="primary"
                                        onClick={() => onOpenEditModal(shop)}
                                    >
                                        {t("shopList.update")}
                                    </Button>
                                    <Button
                                        variant="contained"
                                        color="secondary"
                                        onClick={() => onDelete(shop.id)}
                                        sx={{ ml: 2 }}
                                    >
                                        {t("shopList.delete")}
                                    </Button>
                                    <Button
                                        variant="contained"
                                        color="primary"
                                        onClick={() => onViewEmployees(shop.id)}
                                        sx={{ ml: 2 }}
                                    >
                                        {t("shopList.viewEmployees")}
                                    </Button>
                                </Box>
                            </Grid>
                        </Grid>
                    </Paper>
                </div>
            ))}
            <Pagination
                count={totalPages}
                page={page}
                onChange={handlePageChange}
                color="primary"
                size="large"
                showFirstButton
                showLastButton
            />
        </div>
    );
};

export default ShopList;
