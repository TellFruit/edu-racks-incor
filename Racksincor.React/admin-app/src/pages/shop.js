import React, { useState, useEffect } from "react";
import axios from "axios";
import Container from "@mui/material/Container";
import Box from "@mui/material/Box";
import Button from "@mui/material/Button";
import ShopList from "../components/shop/shop-list";
import ShopCreateModal from "../components/shop/shop-create";
import ShopEditModal from "../components/shop/shop-edit";
import { getToken } from "../api/token";

const token = getToken();

const ShopPage = ({ companyId }) => {
    const [shops, setShops] = useState([]);
    const [createModalIsOpen, setCreateModalIsOpen] = useState(false);
    const [editModalIsOpen, setEditModalIsOpen] = useState(false);
    const [selectedShop, setSelectedShop] = useState(null);

    useEffect(() => {
        fetchShops();
    }, []);

    const fetchShops = async () => {
        try {
            const response = await axios.get(`/shop/company/${companyId}/`, {
                headers: {
                    Authorization: `Bearer ${token}`,
                },
            });
            setShops(response.data);
        } catch (error) {
            console.error("Error fetching shops:", error);
        }
    };

    const handleCreateShop = async (name, address) => {
        try {
            const response = await axios.post(
                `/shop`,
                {
                    name,
                    address,
                },
                {
                    headers: {
                        Authorization: `Bearer ${token}`,
                    },
                }
            );
            const createdShop = response.data;
            setShops((prevShops) => [...prevShops, createdShop]);
            closeCreateModal();
        } catch (error) {
            console.error("Error creating shop:", error);
        }
    };

    const handleUpdateShop = async (id, name, address) => {
        try {
            const response = await axios.put(
                `/shop/${id}`,
                {
                    name,
                    address,
                },
                {
                    headers: {
                        Authorization: `Bearer ${token}`,
                    },
                }
            );
            const updatedShop = response.data;
            setShops((prevShops) =>
                prevShops.map((shop) =>
                    shop.id === updatedShop.id ? updatedShop : shop
                )
            );
            closeEditModal();
        } catch (error) {
            console.error("Error updating shop:", error);
        }
    };

    const handleDeleteShop = async (id) => {
        try {
            await axios.delete(`/shop/${id}`, {
                headers: {
                    Authorization: `Bearer ${token}`,
                },
            });
            setShops((prevShops) => prevShops.filter((shop) => shop.id !== id));
        } catch (error) {
            console.error("Error deleting shop:", error);
        }
    };

    const openCreateModal = () => {
        setCreateModalIsOpen(true);
    };

    const closeCreateModal = () => {
        setCreateModalIsOpen(false);
    };

    const openEditModal = (shop) => {
        setSelectedShop(shop);
        setEditModalIsOpen(true);
    };

    const closeEditModal = () => {
        setSelectedShop(null);
        setEditModalIsOpen(false);
    };

    return (
        <Container>
            <Box sx={{ mt: 4 }}>
                <Button
                    variant="contained"
                    color="primary"
                    onClick={openCreateModal}
                >
                    Create Shop
                </Button>
                <div>
                    <ShopList
                        shops={shops}
                        onUpdateShop={handleUpdateShop}
                        onDeleteShop={handleDeleteShop}
                        onOpenEditModal={openEditModal}
                    />
                    <ShopCreateModal
                        isOpen={createModalIsOpen}
                        onClose={closeCreateModal}
                        onCreateShop={handleCreateShop}
                    />
                    {selectedShop && (
                        <ShopEditModal
                            isOpen={editModalIsOpen}
                            onClose={closeEditModal}
                            shop={selectedShop}
                            onUpdateShop={handleUpdateShop}
                        />
                    )}
                </div>
            </Box>
        </Container>
    );
};

export default ShopPage;
