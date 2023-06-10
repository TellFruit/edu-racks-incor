import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import axios from "../api/instance";
import { getToken } from "../api/token";
import Container from "@mui/material/Container";
import Grid from "@mui/material/Grid";
import Paper from "@mui/material/Paper";
import Typography from "@mui/material/Typography";
import Button from "@mui/material/Button";
import ProductActionTable from "../components/product/product-action-table";
import i18n from "../i18n/i18n";

const ProductPromotionPage = () => {
    const token = getToken();
    const { promotionId, promotionType } = useParams();
    const [promotion, setPromotion] = useState(null);
    const [availableProducts, setAvailableProducts] = useState([]);
    const [selectedProducts, setSelectedProducts] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
            await fetchPromotion();
            await fetchSelectedProducts();
        };

        fetchData();
    }, []);

    useEffect(() => {
        if (selectedProducts.length >= 0) {
            fetchAvailableProducts();
        }
    }, [selectedProducts]);

    const fetchAvailableProducts = async () => {
        try {
            const response = await axios.get(`/product/shop/`, {
                headers: {
                    Authorization: `Bearer ${token}`,
                },
            });

            const filteredProducts = response.data.filter(
                (availableProduct) =>
                    !selectedProducts.some(
                        (selectedProduct) =>
                            selectedProduct.id === availableProduct.id
                    )
            );
            setAvailableProducts(filteredProducts);
            console.log(filteredProducts);
        } catch (error) {
            console.error("Error fetching products:", error);
        }
    };

    const fetchSelectedProducts = async () => {
        try {
            const response = await axios.get(
                `/product/promotion/${promotionId}`,
                {
                    headers: {
                        Authorization: `Bearer ${token}`,
                    },
                }
            );
            setSelectedProducts(response.data);
        } catch (error) {
            console.error("Error fetching products:", error);
        }
    };

    const fetchPromotion = async () => {
        try {
            const response = await axios.get(
                `/${promotionType.toLowerCase()}/${promotionId}/`,
                {
                    headers: {
                        Authorization: `Bearer ${token}`,
                    },
                }
            );
            setPromotion(response.data[0]);
        } catch (error) {
            console.error("Error fetching promotion:", error);
        }
    };

    const handleAddProduct = (product) => {
        setSelectedProducts((prevSelectedProducts) => [
            ...prevSelectedProducts,
            product,
        ]);
        setAvailableProducts((prevAvailableProducts) =>
            prevAvailableProducts.filter(
                (availableProduct) => availableProduct.id !== product.id
            )
        );
    };

    const handleRemoveProduct = (product) => {
        setAvailableProducts((prevAvailableProducts) => [
            ...prevAvailableProducts,
            product,
        ]);
        setSelectedProducts((prevSelectedProducts) =>
            prevSelectedProducts.filter(
                (selectedProduct) => selectedProduct.id !== product.id
            )
        );
    };

    const handleApplyChanges = async () => {
        try {
            await axios.put(
                `/${promotionType.toLowerCase()}/${promotionId}`,
                {
                    id: promotion.id,
                    name: promotion.name,
                    expirationDate: promotion.expirationDate,
                    percenatage: promotion.percenatage,
                    giftProductId: promotion.giftProductId,
                    products: selectedProducts,
                },
                {
                    headers: {
                        Authorization: `Bearer ${token}`,
                    },
                }
            );
        } catch (error) {
            console.error("Error updating promotion:", error);
        }
    };

    return (
        <Container maxWidth="lg" sx={{ mt: 4 }}>
            <Grid container spacing={4}>
                <Grid item xs={6}>
                    <Paper variant="outlined" sx={{ p: 2, minHeight: 400 }}>
                        <Typography variant="h6" gutterBottom>
                            {i18n.t("productPromotionPage.availableProducts")}
                        </Typography>
                        <ProductActionTable
                            products={availableProducts}
                            onActionClick={handleAddProduct}
                            actionText={i18n.t("productPromotionPage.add")}
                        />
                    </Paper>
                </Grid>
                <Grid item xs={6}>
                    <Paper variant="outlined" sx={{ p: 2, minHeight: 400 }}>
                        <Typography variant="h6" gutterBottom>
                            {i18n.t("productPromotionPage.selectedProducts")}
                        </Typography>
                        <ProductActionTable
                            products={selectedProducts}
                            onActionClick={handleRemoveProduct}
                            actionText={i18n.t("productPromotionPage.remove")}
                        />
                    </Paper>
                </Grid>
                <Grid
                    item
                    xs={12}
                    sx={{ display: "flex", justifyContent: "center", mt: 4 }}
                >
                    <Button
                        variant="contained"
                        color="primary"
                        onClick={handleApplyChanges}
                    >
                        {i18n.t("productPromotionPage.applyChanges")}
                    </Button>
                </Grid>
            </Grid>
        </Container>
    );
};

export default ProductPromotionPage;
