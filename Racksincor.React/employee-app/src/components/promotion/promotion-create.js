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
import { useTranslation } from "react-i18next";

const PromotionCreateModal = ({
    isOpen,
    onClose,
    onCreate,
    promotionType,
    products,
}) => {
    const { t } = useTranslation();
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
            contentLabel={t("promotionCreateModal.titleLabel")}
        >
            <Container maxWidth="xs">
                <Box sx={{ marginTop: 8 }}>
                    <h3>{t("promotionCreateModal.titleLabel")}</h3>
                    <TextField
                        label={t("promotionCreateModal.nameLabel")}
                        variant="outlined"
                        fullWidth
                        value={name}
                        onChange={(e) => setName(e.target.value)}
                        sx={{ marginBottom: 2 }}
                    />
                    <DatePicker
                        label={t("promotionCreateModal.expirationDateLabel")}
                        value={expirationDate}
                        onChange={(date) => setExpirationDate(date)}
                        fullWidth
                        sx={{ marginBottom: 2 }}
                    />
                    {promotionType === "discount" && (
                        <TextField
                            label={t("promotionCreateModal.percentageLabel")}
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
                                {t("promotionCreateModal.giftProductLabel")}
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
                        {t("promotionCreateModal.createButton")}
                    </Button>
                    <Button
                        variant="contained"
                        color="secondary"
                        onClick={onClose}
                        sx={{ ml: 2 }}
                    >
                        {t("promotionCreateModal.cancelButton")}
                    </Button>
                </Box>
            </Container>
        </Modal>
    );
};

export default PromotionCreateModal;
