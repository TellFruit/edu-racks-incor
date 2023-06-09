import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router";
import axios from "../api/instance";
import {
    Container,
    Grid,
    Button,
    Typography,
    Select,
    MenuItem,
} from "@mui/material";
import PromotionList from "../components/promotion/promotion-list";
import PromotionCreateModal from "../components/promotion/promotion-create";
import PromotionEditModal from "../components/promotion/promotion-edit";
import { getToken, getShopId } from "../api/token";

const PromotionPage = () => {
    const token = getToken();
    const shopId = getShopId();
    const [shop, setShop] = useState([]);
    const [promotions, setPromotions] = useState([]);
    const [products, setProducts] = useState([]);
    const [promotionType, setPromotionType] = useState("discount");
    const [createModalIsOpen, setCreateModalIsOpen] = useState(false);
    const [editModalIsOpen, setEditModalIsOpen] = useState(false);
    const [selectedPromotion, setSelectedPromotion] = useState(null);
    const navigate = useNavigate();

    useEffect(() => {
        fetchShop();
        fetchProducts();
    }, []);

    useEffect(() => {
        fetchPromotions();
    }, [promotionType]);

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

    const fetchPromotions = async () => {
        try {
            const response = await axios.get(
                `/${promotionType.toLowerCase()}/shop`,
                {
                    headers: {
                        Authorization: `Bearer ${token}`,
                    },
                }
            );
            setPromotions(response.data);
        } catch (error) {
            setPromotions([]);
            console.error("Error fetching promotions:", error);
        }
    };

    const fetchProducts = async () => {
        try {
            const response = await axios.get(`/product/shop`, {
                headers: {
                    Authorization: `Bearer ${token}`,
                },
            });
            setProducts(response.data);
        } catch (error) {
            console.error("Error fetching promotions:", error);
        }
    };

    const handleCreate = async (
        name,
        expirationDate,
        percenatage,
        giftProductId
    ) => {
        try {
            const response = await axios.post(
                `/${promotionType.toLowerCase()}`,
                {
                    name,
                    expirationDate,
                    percenatage,
                    giftProductId,
                    shopId: shopId,
                },
                {
                    headers: {
                        Authorization: `Bearer ${token}`,
                    },
                }
            );
            const createdPromotion = response.data;
            setPromotions((prevPromotions) => [
                ...prevPromotions,
                createdPromotion,
            ]);
            closeCreateModal();
        } catch (error) {
            console.error("Error creating promotion:", error);
        }
    };

    const handleUpdate = async (
        id,
        name,
        expirationDate,
        percenatage,
        giftProductId
    ) => {
        try {
            const response = await axios.put(
                `/${promotionType.toLowerCase()}/${id}`,
                {
                    name,
                    expirationDate,
                    percenatage,
                    giftProductId,
                },
                {
                    headers: {
                        Authorization: `Bearer ${token}`,
                    },
                }
            );
            const updatedPromotion = response.data;
            setPromotions((prevPromotions) =>
                prevPromotions.map((promotion) =>
                    promotion.id === updatedPromotion.id
                        ? updatedPromotion
                        : promotion
                )
            );
            closeEditModal();
        } catch (error) {
            console.error("Error updating promotion:", error);
        }
    };

    const handleDelete = async (id) => {
        try {
            await axios.delete(`/${promotionType.toLowerCase()}/${id}`, {
                headers: {
                    Authorization: `Bearer ${token}`,
                },
            });
            setPromotions((prevPromotions) =>
                prevPromotions.filter((promotion) => promotion.id !== id)
            );
        } catch (error) {
            console.error("Error deleting promotion:", error);
        }
    };

    const handlePromotionTypeChange = (event) => {
        setPromotionType(event.target.value);
    };

    const handleViewProducts = (rackId) => {
        navigate(`/${promotionType.toLowerCase()}/${rackId}/products`);
    };

    const openCreateModal = () => {
        setCreateModalIsOpen(true);
    };

    const closeCreateModal = () => {
        setCreateModalIsOpen(false);
    };

    const openEditModal = (promotion) => {
        setSelectedPromotion(promotion);
        setEditModalIsOpen(true);
    };

    const closeEditModal = () => {
        setSelectedPromotion(null);
        setEditModalIsOpen(false);
    };

    return (
        <Container maxWidth="md" sx={{ mt: 4 }}>
            <Grid container spacing={4}>
                <Grid item xs={12}>
                    <Typography variant="h4" gutterBottom>
                        {`Promotions of ${shop?.name}`}
                    </Typography>
                    <h3>Create promotion</h3>
                    <Button
                        variant="contained"
                        color="primary"
                        onClick={openCreateModal}
                    >
                        Create
                    </Button>
                    <PromotionCreateModal
                        isOpen={createModalIsOpen}
                        onClose={closeCreateModal}
                        onCreate={handleCreate}
                        products={products}
                        promotionType={promotionType}
                    />
                </Grid>
                <Grid item xs={12}>
                    <Typography variant="body1">Promotion Type:</Typography>
                    <Select
                        value={promotionType}
                        onChange={handlePromotionTypeChange}
                        sx={{ minWidth: 200 }}
                    >
                        <MenuItem value="discount">Discount</MenuItem>
                        <MenuItem value="gift">Gift</MenuItem>
                    </Select>
                </Grid>
                <Grid item xs={12}>
                    <PromotionList
                        promotions={promotions}
                        onDelete={handleDelete}
                        onOpenEditModal={openEditModal}
                        onViewProducts={handleViewProducts}
                        products={products}
                    />
                    {selectedPromotion && (
                        <PromotionEditModal
                            isOpen={editModalIsOpen}
                            onClose={closeEditModal}
                            promotion={selectedPromotion}
                            onUpdate={handleUpdate}
                            products={products}
                            promotionType={promotionType}
                        />
                    )}
                </Grid>
            </Grid>
        </Container>
    );
};

export default PromotionPage;
