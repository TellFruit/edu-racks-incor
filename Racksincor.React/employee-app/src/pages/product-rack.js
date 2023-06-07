import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import axios from "../api/instance";
import { getToken, getShopId } from "../api/token";
import {
    Container,
    Grid,
    Paper,
    Table,
    TableBody,
    TableCell,
    TableContainer,
    TableHead,
    TableRow,
    Typography,
    Button,
} from "@mui/material";

const ProductRackPage = () => {
    const token = getToken();
    const { rackId } = useParams();
    const [availableProducts, setAvailableProducts] = useState([]);
    const [selectedProducts, setSelectedProducts] = useState([]);

    useEffect(() => {
        fetchAvailableProducts();
    }, []);

    const fetchAvailableProducts = async () => {
        try {
            const response = await axios.get(`/product/shop/`, {
                headers: {
                    Authorization: `Bearer ${token}`,
                },
            });
            console.log(response.data);
            setAvailableProducts(response.data);
        } catch (error) {
            console.error("Error fetching products:", error);
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

    const handleApplyChanges = () => {
        // Send backend request to update the rack's associated products
        // Implement your logic here
    };

    return (
        <Container maxWidth="lg" sx={{ mt: 4 }}>
            <Grid container spacing={4}>
                <Grid item xs={6}>
                    <Paper variant="outlined" sx={{ p: 2, minHeight: 400 }}>
                        <Typography variant="h6" gutterBottom>
                            Available Products
                        </Typography>
                        <TableContainer sx={{ height: 400, maxHeight: 400 }}>
                            <Table>
                                <TableHead>
                                    <TableRow>
                                        <TableCell>Name</TableCell>
                                        <TableCell align="center">
                                            Action
                                        </TableCell>
                                    </TableRow>
                                </TableHead>
                                <TableBody>
                                    {availableProducts.map((product) => (
                                        <TableRow key={product.id}>
                                            <TableCell>
                                                {product.name}
                                            </TableCell>
                                            <TableCell align="center">
                                                <Button
                                                    variant="outlined"
                                                    onClick={() =>
                                                        handleAddProduct(
                                                            product
                                                        )
                                                    }
                                                >
                                                    Add
                                                </Button>
                                            </TableCell>
                                        </TableRow>
                                    ))}
                                </TableBody>
                            </Table>
                        </TableContainer>
                    </Paper>
                </Grid>
                <Grid item xs={6}>
                    <Paper variant="outlined" sx={{ p: 2, minHeight: 400 }}>
                        <Typography variant="h6" gutterBottom>
                            Selected Products
                        </Typography>
                        <TableContainer sx={{ height: 400, maxHeight: 400 }}>
                            <Table>
                                <TableHead>
                                    <TableRow>
                                        <TableCell>Name</TableCell>
                                        <TableCell align="center">
                                            Action
                                        </TableCell>
                                    </TableRow>
                                </TableHead>
                                <TableBody>
                                    {selectedProducts.map((product) => (
                                        <TableRow key={product.id}>
                                            <TableCell>
                                                {product.name}
                                            </TableCell>
                                            <TableCell align="center">
                                                <Button
                                                    variant="outlined"
                                                    onClick={() =>
                                                        handleRemoveProduct(
                                                            product
                                                        )
                                                    }
                                                >
                                                    Remove
                                                </Button>
                                            </TableCell>
                                        </TableRow>
                                    ))}
                                </TableBody>
                            </Table>
                        </TableContainer>
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
                        Apply Changes
                    </Button>
                </Grid>
            </Grid>
        </Container>
    );
};

export default ProductRackPage;
