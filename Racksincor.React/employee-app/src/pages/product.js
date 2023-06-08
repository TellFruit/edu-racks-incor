import React, { useState, useEffect } from "react";
import axios from "../api/instance";
import Container from "@mui/material/Container";
import Box from "@mui/material/Box";
import Button from "@mui/material/Button";
import ProductList from "../components/product/product-list";
import ProductCreateModal from "../components/product/product-create";
import ProductEditModal from "../components/product/product-edit";
import { getToken, getShopId } from "../api/token";

const ProductPage = () => {
    const token = getToken();
    const shopId = getShopId();
    const [shop, setShop] = useState(null);
    const [products, setProducts] = useState([]);
    const [createModalIsOpen, setCreateModalIsOpen] = useState(false);
    const [editModalIsOpen, setEditModalIsOpen] = useState(false);
    const [selectedProduct, setSelectedProduct] = useState(null);

    useEffect(() => {
        fetchShop();
        fetchProducts();
    }, []);

    const fetchShop = async () => {
        try {
            const response = await axios.get(`/shop/${shopId}`, {
                headers: {
                    Authorization: `Bearer ${token}`,
                },
            });
            setShop(response.data[0]);
        } catch (error) {
            console.error("Error fetching shop:", error);
        }
    };

    const fetchProducts = async () => {
        try {
            const response = await axios.get(`/product/shop/`, {
                headers: {
                    Authorization: `Bearer ${token}`,
                },
            });
            setProducts(response.data);
        } catch (error) {
            console.error("Error fetching products:", error);
        }
    };

    const handleCreate = async (name, price, isInStock) => {
        try {
            const response = await axios.post(
                `/product`,
                {
                    name,
                    price,
                    isInStock,
                    shopId: shopId,
                },
                {
                    headers: {
                        Authorization: `Bearer ${token}`,
                    },
                }
            );
            const createdProduct = response.data;
            setProducts((prevProducts) => [...prevProducts, createdProduct]);
            closeCreateModal();
        } catch (error) {
            console.error("Error creating product:", error);
        }
    };

    const handleUpdate = async (id, name, price, isInStock) => {
        try {
            const response = await axios.put(
                `/product/${id}`,
                {
                    name,
                    price,
                    isInStock,
                },
                {
                    headers: {
                        Authorization: `Bearer ${token}`,
                    },
                }
            );
            const updatedProduct = response.data;
            setProducts((prevProducts) =>
                prevProducts.map((product) =>
                    product.id === updatedProduct.id ? updatedProduct : product
                )
            );
            closeEditModal();
        } catch (error) {
            console.error("Error updating product:", error);
        }
    };

    const handleDelete = async (id) => {
        try {
            await axios.delete(`/product/${id}`, {
                headers: {
                    Authorization: `Bearer ${token}`,
                },
            });
            setProducts((prevProducts) =>
                prevProducts.filter((product) => product.id !== id)
            );
        } catch (error) {
            console.error("Error deleting product:", error);
        }
    };

    const openCreateModal = () => {
        setCreateModalIsOpen(true);
    };

    const closeCreateModal = () => {
        setCreateModalIsOpen(false);
    };

    const openEditModal = (product) => {
        setSelectedProduct(product);
        setEditModalIsOpen(true);
    };

    const closeEditModal = () => {
        setSelectedProduct(null);
        setEditModalIsOpen(false);
    };

    return (
        <Container maxWidth="md">
            <Box sx={{ mt: 8 }}>
                <h2>{`Products of ${shop?.name}`}</h2>
                <div>
                    <h3>Create product</h3>
                    <Button
                        variant="contained"
                        color="primary"
                        onClick={openCreateModal}
                    >
                        Create
                    </Button>
                    <ProductCreateModal
                        isOpen={createModalIsOpen}
                        onClose={closeCreateModal}
                        onCreate={handleCreate}
                    />
                </div>
                <div>
                    <h3>Product List</h3>
                    <ProductList
                        products={products}
                        onDelete={handleDelete}
                        onOpenEditModal={openEditModal}
                    />
                    {selectedProduct && (
                        <ProductEditModal
                            isOpen={editModalIsOpen}
                            onClose={closeEditModal}
                            product={selectedProduct}
                            onUpdate={handleUpdate}
                        />
                    )}
                </div>
            </Box>
        </Container>
    );
};

export default ProductPage;
