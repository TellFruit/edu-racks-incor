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
import dayjs from "dayjs";
import Modal from "react-modal";
import i18n from "../../i18n/i18n";

const PromotionEditModal = ({
    isOpen,
    onClose,
    promotion,
    onUpdate,
    products,
    promotionType,
}) => {
    const [name, setName] = useState(promotion.name);
    const [expirationDate, setExpirationDate] = useState(
        dayjs(promotion.expirationDate)
    );
    const [percenatage, setPercenatage] = useState(promotion.percenatage);
    const [giftProductId, setGiftProductId] = useState(promotion.giftProductId);

    const handleUpdate = () => {
        const formattedExpirationDate = expirationDate
            ? expirationDate.toISOString().split("T")[0]
            : null;
            
        onUpdate(
            promotion.id,
            name,
            formattedExpirationDate,
            percenatage,
            giftProductId
        );
    };

    const handleFocus = (event) => {
        event.target.blur();
    };

    return (
        <Modal
            isOpen={isOpen}
            onRequestClose={onClose}
            contentLabel={i18n.t("promotionEditModal.titleLabel")}
        >
            <Container maxWidth="xs">
                <Box sx={{ marginTop: 8 }}>
                    <h3>{i18n.t("promotionEditModal.titleLabel")}</h3>
                    <TextField
                        label={i18n.t("promotionEditModal.nameLabel")}
                        variant="outlined"
                        fullWidth
                        value={name}
                        onChange={(e) => setName(e.target.value)}
                        sx={{ marginBottom: 2 }}
                    />
                     <DatePicker
                        label={i18n.t("promotionEditModal.expirationDateLabel")}
                        value={expirationDate}
                        onChange={(date) => setExpirationDate(date)}
                        fullWidth
                        sx={{ marginBottom: 2 }}
                    />
                    {promotionType === "discount" && (
                        <TextField
                            label={i18n.t("promotionEditModal.percentageLabel")}
                            variant="outlined"
                            fullWidth
                            type="number"
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
                                {i18n.t("promotionEditModal.giftProductLabel")}
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
                        {i18n.t("promotionEditModal.updateButton")}
                    </Button>
                    <Button
                        variant="contained"
                        color="secondary"
                        onClick={onClose}
                        sx={{ ml: 2 }}
                    >
                        {i18n.t("promotionEditModal.cancelButton")}
                    </Button>
                </Box>
            </Container>
        </Modal>
    );
};

export default PromotionEditModal;
