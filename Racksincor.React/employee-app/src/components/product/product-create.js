import React, { useState } from "react";
import { Container, Button, TextField, Box, FormControlLabel, Checkbox } from "@mui/material";
import Modal from "react-modal";

const ProductCreateModal = ({ isOpen, onClose, onCreate }) => {
  const [name, setName] = useState("");
  const [price, setPrice] = useState("");
  const [isInStock, setIsInStock] = useState(true);

  const handleCreate = () => {
    onCreate(name, price, isInStock);
    setName("");
    setPrice("");
    setIsInStock(true);
  };

  return (
    <Modal
      isOpen={isOpen}
      onRequestClose={onClose}
      contentLabel="Create Product Modal"
    >
      <Container maxWidth="xs">
        <Box sx={{ marginTop: 8 }}>
          <h3>Create Product</h3>
          <TextField
            label="Name"
            variant="outlined"
            fullWidth
            value={name}
            onChange={(e) => setName(e.target.value)}
            sx={{ marginBottom: 2 }}
          />
          <TextField
            label="Price"
            variant="outlined"
            fullWidth
            value={price}
            onChange={(e) => setPrice(e.target.value)}
            sx={{ marginBottom: 2 }}
          />
          <FormControlLabel
            control={
              <Checkbox
                checked={isInStock}
                onChange={(e) => setIsInStock(e.target.checked)}
              />
            }
            label="Is In Stock"
            sx={{ marginBottom: 2 }}
          />
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

export default ProductCreateModal;
