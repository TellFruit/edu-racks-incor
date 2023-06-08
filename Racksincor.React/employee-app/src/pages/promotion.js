import React, { useEffect, useState } from "react";
import axios from "../api/instance";
import { Container, Grid, Typography, Select, MenuItem } from "@mui/material";
import PromotionList from "./PromotionList";
import { getToken, getShopId } from "../api/token";

const PromotionsPage = () => {
    const token = getToken();
    const shopId = getShopId();
    const [shop, setShop] = useState([]);
    const [promotions, setPromotions] = useState([]);
    const [promotionType, setPromotionType] = useState("discount");

    useEffect(() => {
        fetchShop();
    });

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
            console.error("Error fetching promotions:", error);
        }
    };

    const handlePromotionTypeChange = (event) => {
        setPromotionType(event.target.value);
    };

    return (
        <Container maxWidth="lg" sx={{ mt: 4 }}>
            <Grid container spacing={4}>
                <Grid item xs={12}>
                    <Typography variant="h4" gutterBottom>
                        {`Promotions of ${shop?.name}`}
                    </Typography>
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
                    <PromotionList promotions={promotions} />
                </Grid>
            </Grid>
        </Container>
    );
};

export default PromotionsPage;
