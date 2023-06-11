import React, { useState } from "react";
import Button from "@mui/material/Button";
import Grid from "@mui/material/Grid";
import Paper from "@mui/material/Paper";
import Box from "@mui/material/Box";
import Pagination from "@mui/material/Pagination";
import { useTranslation } from "react-i18next";

const ProductList = ({ products, onDelete, onOpenEditModal }) => {
    const { t } = useTranslation();
    const [page, setPage] = useState(1);
    const productsPerPage = 5;
    const totalPages = Math.ceil(products.length / productsPerPage);

    const handlePageChange = (event, value) => {
        event.preventDefault();
        setPage(value);
    };

    const startIndex = (page - 1) * productsPerPage;
    const endIndex = startIndex + productsPerPage;
    const displayedProducts = products.slice(startIndex, endIndex);

    return (
        <div>
            {displayedProducts.map((product) => (
                <div key={product.id}>
                    <Paper variant="outlined" sx={{ p: 2, mb: 2 }}>
                        <Grid container spacing={2} alignItems="center">
                            <Grid item xs={6}>
                                <Box>
                                    <p>{t("productList.nameLabel")}: {product.name}</p>
                                    <p>{t("productList.priceLabel")}: ${product.price}</p>
                                    <p>
                                        {t("productList.isInStockLabel")}:{" "}
                                        {product.isInStock ? t("productList.yesLabel") : t("productList.noLabel")}
                                    </p>
                                </Box>
                            </Grid>
                            <Grid item xs={6}>
                                <Box display="flex" justifyContent="flex-end">
                                    <Button
                                        variant="contained"
                                        color="primary"
                                        onClick={() => onOpenEditModal(product)}
                                    >
                                        {t("productList.updateButton")}
                                    </Button>
                                    <Button
                                        variant="contained"
                                        color="secondary"
                                        onClick={() => onDelete(product.id)}
                                        sx={{ ml: 2 }}
                                    >
                                        {t("productList.deleteButton")}
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

export default ProductList;
