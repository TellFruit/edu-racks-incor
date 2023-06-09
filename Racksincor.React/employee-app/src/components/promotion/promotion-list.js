import React, { useState } from "react";
import Button from "@mui/material/Button";
import Grid from "@mui/material/Grid";
import Paper from "@mui/material/Paper";
import Box from "@mui/material/Box";
import Pagination from "@mui/material/Pagination";

const PromotionList = ({
    promotions,
    onDelete,
    onOpenEditModal,
    onViewProducts,
    products,
}) => {
    const [page, setPage] = useState(1);
    const promotionsPerPage = 5;
    const totalPages = Math.ceil(promotions.length / promotionsPerPage);

    const handlePageChange = (event, value) => {
        event.preventDefault();
        setPage(value);
    };

    const startIndex = (page - 1) * promotionsPerPage;
    const endIndex = startIndex + promotionsPerPage;
    const displayedPromotions = promotions.slice(startIndex, endIndex);

    const getProductById = (productId) => {
        return products.find((product) => product.id === productId);
    };

    return (
        <div>
            {displayedPromotions.map((promotion) => {
                const productName = promotion.giftProductId
                    ? getProductById(promotion.giftProductId)?.name
                    : "N/A";

                return (
                    <div key={promotion.id}>
                        <Paper variant="outlined" sx={{ p: 2, mb: 2 }}>
                            <Grid container spacing={2} alignItems="center">
                                <Grid item xs={6}>
                                    <Box>
                                        <p>Name: {promotion.name}</p>
                                        <p>
                                            Expiration Date:{" "}
                                            {new Date(
                                                promotion.expirationDate
                                            ).toLocaleDateString()}
                                        </p>
                                        {promotion.percenatage && (
                                            <p>
                                                Percentage:{" "}
                                                {promotion.percenatage}%
                                            </p>
                                        )}
                                        {promotion.giftProductId && (
                                            <p>Gift Product: {productName}</p>
                                        )}
                                    </Box>
                                </Grid>
                                <Grid item xs={6}>
                                    <Box
                                        display="flex"
                                        justifyContent="flex-end"
                                    >
                                        <Button
                                            variant="contained"
                                            color="primary"
                                            onClick={() =>
                                                onOpenEditModal(promotion)
                                            }
                                        >
                                            Update
                                        </Button>
                                        <Button
                                            variant="contained"
                                            color="secondary"
                                            onClick={() =>
                                                onDelete(promotion.id)
                                            }
                                            sx={{ ml: 2 }}
                                        >
                                            Delete
                                        </Button>
                                        <Button
                                            variant="contained"
                                            color="primary"
                                            onClick={() =>
                                                onViewProducts(promotion.id)
                                            }
                                            sx={{ ml: 2 }}
                                        >
                                            View Products
                                        </Button>
                                    </Box>
                                </Grid>
                            </Grid>
                        </Paper>
                    </div>
                );
            })}
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

export default PromotionList;
