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

const ProductRackPage = () => {
  const token = getToken();
  const { rackId } = useParams();
  const [rack, setRack] = useState(null);
  const [availableProducts, setAvailableProducts] = useState([]);
  const [selectedProducts, setSelectedProducts] = useState([]);

  useEffect(() => {
    fetchRack();
    fetchAvailableProducts();
  }, []);

  const fetchAvailableProducts = async () => {
    try {
      const response = await axios.get(`/product/shop/`, {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      });
      setAvailableProducts(response.data);
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
      setRack(response.data);
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
            <ProductActionTable
              products={availableProducts}
              onActionClick={handleAddProduct}
              actionText="Add"
            />
          </Paper>
        </Grid>
        <Grid item xs={6}>
          <Paper variant="outlined" sx={{ p: 2, minHeight: 400 }}>
            <Typography variant="h6" gutterBottom>
              Selected Products
            </Typography>
            <ProductActionTable
              products={selectedProducts}
              onActionClick={handleRemoveProduct}
              actionText="Remove"
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
            Apply Changes
          </Button>
        </Grid>
      </Grid>
    </Container>
  );
};

export default ProductRackPage;
