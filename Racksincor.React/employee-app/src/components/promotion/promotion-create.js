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
import { DatePicker } from "@mui/x-date-pickers";
import Modal from "react-modal";

const PromotionCreateModal = ({
    isOpen,
    onClose,
    onCreate,
    promotionType,
    products,
}) => {
    const [name, setName] = useState("");
    const [expirationDate, setExpirationDate] = useState(null);
    const [percenatage, setPercenatage] = useState("");
    const [giftProductId, setGiftProductId] = useState("");

    const handleCreate = () => {
        const formattedExpirationDate = expirationDate
            ? expirationDate.toISOString().split("T")[0]
            : null;

        onCreate(name, formattedExpirationDate, percenatage, giftProductId);
        setName("");
        setExpirationDate(null);
        setPercenatage("");
        setGiftProductId("");
    };

    const handleFocus = (event) => {
        event.target.blur();
    };

    return (
        <Modal
            isOpen={isOpen}
            onRequestClose={onClose}
            contentLabel="Create Promotion Modal"
        >
            <Container maxWidth="xs">
                <Box sx={{ marginTop: 8 }}>
                    <h3>Create Promotion</h3>
                    <TextField
                        label="Name"
                        variant="outlined"
                        fullWidth
                        value={name}
                        onChange={(e) => setName(e.target.value)}
                        sx={{ marginBottom: 2 }}
                    />
                    <DatePicker
                        label="Expiration Date"
                        value={expirationDate}
                        onChange={(date) => setExpirationDate(date)}
                        fullWidth
                        sx={{ marginBottom: 2 }}
                    />
                    {promotionType === "discount" && (
                        <TextField
                            label="percenatage"
                            variant="outlined"
                            type="number"
                            fullWidth
                            value={percenatage}
                            onChange={(e) => setPercenatage(e.target.value)}
                            inputProps={{
                                max: -1,
                                onFocus: handleFocus,
                            }}
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
                        onClick={handleCreate}
                    >
                        Create
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

export default PromotionCreateModal;
