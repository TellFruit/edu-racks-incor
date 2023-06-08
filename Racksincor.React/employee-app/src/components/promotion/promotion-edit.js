import React, { useState } from "react";
import {
    Container,
    Button,
    TextField,
    Box,
    MenuItem,
    Select,
    InputLabel,
} from "@mui/material";
import Modal from "react-modal";

const PromotionEditModal = ({
    isOpen,
    onClose,
    promotion,
    onUpdate,
    products,
    promotionType
}) => {
    const [name, setName] = useState(promotion.name);
    const [expirationDate, setExpirationDate] = useState(promotion.expirationDate);
    const [percentage, setPercentage] = useState(promotion.percentage);
    const [giftProductId, setGiftProductId] = useState(promotion.giftProductId);

    const handleUpdate = () => {
        onUpdate(promotion.id, name, expirationDate, percentage, giftProductId);
    };

    return (
        <Modal
            isOpen={isOpen}
            onRequestClose={onClose}
            contentLabel="Edit Promotion Modal"
        >
            <Container maxWidth="xs">
                <Box sx={{ marginTop: 8 }}>
                    <h3>Edit Promotion</h3>
                    <TextField
                        label="Name"
                        variant="outlined"
                        fullWidth
                        value={name}
                        onChange={(e) => setName(e.target.value)}
                        sx={{ marginBottom: 2 }}
                    />
                    <TextField
                        label="Expiration Date"
                        variant="outlined"
                        fullWidth
                        type="date"
                        value={expirationDate}
                        onChange={(e) => setExpirationDate(e.target.value)}
                        sx={{ marginBottom: 2 }}
                    />
                    {promotionType !== "gift" && (
                        <TextField
                            label="Percentage"
                            variant="outlined"
                            fullWidth
                            type="number"
                            value={percentage}
                            onChange={(e) => setPercentage(e.target.value)}
                            sx={{ marginBottom: 2 }}
                        />
                    )}
                    {promotionType === "gift" && (
                        <div>
                            <InputLabel id="gift-product-select-label">
                                Gift Product
                            </InputLabel>
                            <Select
                                labelId="gift-product-select-label"
                                id="gift-product-select"
                                value={giftProductId}
                                onChange={(e) =>
                                    setGiftProductId(e.target.value)
                                }
                                variant="outlined"
                                fullWidth
                                sx={{ marginBottom: 2 }}
                            >
                                {products.map((product) => (
                                    <MenuItem
                                        key={product.id}
                                        value={product.id}
                                    >
                                        {product.name}
                                    </MenuItem>
                                ))}
                            </Select>
                        </div>
                    )}
                    <Button
                        variant="contained"
                        color="primary"
                        onClick={handleUpdate}
                    >
                        Update
                    </Button>
                    <Button
                        variant="contained"
                        color="secondary"
                        onClick={onClose}
                        sx={{ ml: 2 }}
                    >
                        Cancel
                    </Button>
                </Box>
            </Container>
        </Modal>
    );
};

export default PromotionEditModal;
