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
import { useTranslation } from "react-i18next";

const ProductRackPage = () => {
    const { t } = useTranslation();
    const token = getToken();
    const { rackId } = useParams();
    const [rack, setRack] = useState(null);
    const [availableProducts, setAvailableProducts] = useState([]);
    const [selectedProducts, setSelectedProducts] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
            await fetchRack();
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
        } catch (error) {
            console.error("Error fetching products:", error);
        }
    };

    const fetchSelectedProducts = async () => {
        try {
            const response = await axios.get(`/product/rack/${rackId}`, {
                headers: {
                    Authorization: `Bearer ${token}`,
                },
            });
            setSelectedProducts(response.data);
        } catch (error) {
            console.error("Error fetching products:", error);
        }
    };

    const fetchRack = async () => {
        try {
            const response = await axios.get(`/rack/${rackId}/`, {
                headers: {
                    Authorization: `Bearer ${token}`,
                },
            });
            setRack(response.data[0]);
        } catch (error) {
            console.error("Error fetching rack:", error);
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
            console.log(rack);
            await axios.put(
                `/rack/${rackId}`,
                {
                    id: rack.id,
                    Name: rack.name,
                    Products: selectedProducts,
                },
                {
                    headers: {
                        Authorization: `Bearer ${token}`,
                    },
                }
            );
        } catch (error) {
            console.error("Error updating rack:", error);
        }
    };

    return (
        <Container maxWidth="lg" sx={{ mt: 4 }}>
            <Grid container spacing={4}>
                <Grid item xs={6}>
                    <Paper variant="outlined" sx={{ p: 2, minHeight: 400 }}>
                        <Typography variant="h6" gutterBottom>
                            {t("productRackPage.availableProducts")}
                        </Typography>
                        <ProductActionTable
                            products={availableProducts}
                            onActionClick={handleAddProduct}
                            actionText={t("productRackPage.add")}
                        />
                    </Paper>
                </Grid>
                <Grid item xs={6}>
                    <Paper variant="outlined" sx={{ p: 2, minHeight: 400 }}>
                        <Typography variant="h6" gutterBottom>
                            {t("productRackPage.selectedProducts")}
                        </Typography>
                        <ProductActionTable
                            products={selectedProducts}
                            onActionClick={handleRemoveProduct}
                            actionText={t("productRackPage.remove")}
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
                        {t("productRackPage.applyChangesButton")}
                    </Button>
                </Grid>
            </Grid>
        </Container>
    );
};

export default ProductRackPage;
