import React, { useState } from "react";
import Button from "@mui/material/Button";
import Grid from "@mui/material/Grid";
import Paper from "@mui/material/Paper";
import Box from "@mui/material/Box";
import Pagination from "@mui/material/Pagination";

const PromotionList = ({ promotions, onDelete, onOpenEditModal }) => {
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

    return (
        <div>
            {displayedPromotions.map((promotion) => (
                <div key={promotion.id}>
                    <Paper variant="outlined" sx={{ p: 2, mb: 2 }}>
                        <Grid container spacing={2} alignItems="center">
                            <Grid item xs={6}>
                                <Box>
                                    <p>Name: {promotion.name}</p>
                                    <p>
                                        Expiration Date:{" "}
                                        {new Date(promotion.expirationDate).toLocaleDateString()}
                                    </p>
                                    {promotion.percentage && (
                                        <p>
                                            Percentage: {promotion.percentage}%
                                        </p>
                                    )}
                                    {promotion.giftProductId && (
                                        <p>
                                            Gift Product ID:{" "}
                                            {promotion.giftProductId}
                                        </p>
                                    )}
                                    {promotion.product && (
                                        <p>
                                            Product Name:{" "}
                                            {promotion.product.name}
                                        </p>
                                    )}
                                </Box>
                            </Grid>
                            <Grid item xs={6}>
                                <Box display="flex" justifyContent="flex-end">
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
                                        onClick={() => onDelete(promotion.id)}
                                        sx={{ ml: 2 }}
                                    >
                                        Delete
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

export default PromotionList;
