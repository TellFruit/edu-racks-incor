import React, { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import { useNavigate } from 'react-router-dom';
import axios from "axios";
import Container from "@mui/material/Container";
import Box from "@mui/material/Box";
import Button from "@mui/material/Button";
import ShopList from "../components/shop/shop-list";
import ShopCreateModal from "../components/shop/shop-create";
import ShopEditModal from "../components/shop/shop-edit";
import { getToken } from "../api/token";

const ShopPage = () => {
    const token = getToken();
    const { companyId } = useParams();
    const [company, setCompany] = useState(null);
    const [shops, setShops] = useState([]);
    const [createModalIsOpen, setCreateModalIsOpen] = useState(false);
    const [editModalIsOpen, setEditModalIsOpen] = useState(false);
    const [selectedShop, setSelectedShop] = useState(null);
    const navigate = useNavigate();

    useEffect(() => {
        fetchParentCompany();
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

    const fetchParentCompany = async () => {
        try {
            const response = await axios.get(`/company/${companyId}/`, {
                headers: {
                    Authorization: `Bearer ${token}`,
                },
            });
            setCompany(response.data[0]);
        } catch (error) {
            console.error("Error fetching shops:", error);
        }
    };

    const handleCreate = async (name, address) => {
        try {
            const response = await axios.post(
                `/shop`,
                {
                    name,
                    address,
                    companyId: companyId
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

    const handleUpdate = async (id, name, address) => {
        try {
            const response = await axios.put(
                `/shop/${id}`,
                {
                    name,
                    address,
                    companyId: companyId
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

    const handleDelete = async (id) => {
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

    const handleViewEmployees = (shopId) => {
      navigate(`/shop/${shopId}/employees`);
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
        <Container maxWidth="md">
            <Box sx={{ mt: 8 }}>
                <h2>{`Shops of ${company?.name}`}</h2>
                <div>
                    <h3>Create shop</h3>
                    <Button
                        variant="contained"
                        color="primary"
                        onClick={openCreateModal}
                    >
                        Create
                    </Button>
                    <ShopCreateModal
                        isOpen={createModalIsOpen}
                        onClose={closeCreateModal}
                        onCreate={handleCreate}
                    />
                </div>
                <div>
                    <h3>Shop List</h3>
                    <ShopList
                        shops={shops}
                        onDelete={handleDelete}
                        onOpenEditModal={openEditModal}
                        onViewEmployees={handleViewEmployees}
                    />
                    {selectedShop && (
                        <ShopEditModal
                            isOpen={editModalIsOpen}
                            onClose={closeEditModal}
                            shop={selectedShop}
                            onUpdate={handleUpdate}
                        />
                    )}
                </div>
            </Box>
        </Container>
    );
};

export default ShopPage;
