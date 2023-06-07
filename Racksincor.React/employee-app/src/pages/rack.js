import React, { useState, useEffect } from "react";
import axios from "../api/instance";
import Container from "@mui/material/Container";
import Box from "@mui/material/Box";
import Button from "@mui/material/Button";
import RackList from "../components/rack/rack-list";
import RackCreateModal from "../components/rack/rack-create";
import RackEditModal from "../components/rack/rack-edit";
import { getToken, getShopId } from "../api/token";

const RackPage = () => {
    const token = getToken();
    const shopId = getShopId();
    const [shop, setShop] = useState(null);
    const [racks, setRacks] = useState([]);
    const [createModalIsOpen, setCreateModalIsOpen] = useState(false);
    const [editModalIsOpen, setEditModalIsOpen] = useState(false);
    const [selectedRack, setSelectedRack] = useState(null);

    useEffect(() => {
        fetchShop();
        fetchRacks();
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

    const fetchRacks = async () => {
        try {
            const response = await axios.get(`/rack/shop/`, {
                headers: {
                    Authorization: `Bearer ${token}`,
                },
            });
            setRacks(response.data);
        } catch (error) {
            console.error("Error fetching racks:", error);
        }
    };

    const handleCreate = async (name) => {
        try {
            const response = await axios.post(
                `/rack`,
                {
                    name,
                    shopId,
                },
                {
                    headers: {
                        Authorization: `Bearer ${token}`,
                    },
                }
            );
            const createdRack = response.data;
            setRacks((prevRacks) => [...prevRacks, createdRack]);
            closeCreateModal();
        } catch (error) {
            console.error("Error creating rack:", error);
        }
    };

    const handleUpdate = async (id, name) => {
        try {
            const response = await axios.put(
                `/rack/${id}`,
                {
                    name,
                    shopId,
                },
                {
                    headers: {
                        Authorization: `Bearer ${token}`,
                    },
                }
            );
            const updatedRack = response.data;
            setRacks((prevRacks) =>
                prevRacks.map((rack) =>
                    rack.id === updatedRack.id ? updatedRack : rack
                )
            );
            closeEditModal();
        } catch (error) {
            console.error("Error updating rack:", error);
        }
    };

    const handleDelete = async (id) => {
        try {
            await axios.delete(`/rack/${id}`, {
                headers: {
                    Authorization: `Bearer ${token}`,
                },
            });
            setRacks((prevRacks) => prevRacks.filter((rack) => rack.id !== id));
        } catch (error) {
            console.error("Error deleting rack:", error);
        }
    };

    const openCreateModal = () => {
        setCreateModalIsOpen(true);
    };

    const closeCreateModal = () => {
        setCreateModalIsOpen(false);
    };

    const openEditModal = (rack) => {
        setSelectedRack(rack);
        setEditModalIsOpen(true);
    };

    const closeEditModal = () => {
        setSelectedRack(null);
        setEditModalIsOpen(false);
    };

    return (
        <Container maxWidth="md">
            <Box sx={{ mt: 8 }}>
                <h2>{`Racks of ${shop?.name}`}</h2>
                <div>
                    <h3>Create rack</h3>
                    <Button
                        variant="contained"
                        color="primary"
                        onClick={openCreateModal}
                    >
                        Create
                    </Button>
                    <RackCreateModal
                        isOpen={createModalIsOpen}
                        onClose={closeCreateModal}
                        onCreate={handleCreate}
                    />
                </div>
                <div>
                    <h3>Rack List</h3>
                    <RackList
                        racks={racks}
                        onDelete={handleDelete}
                        onOpenEditModal={openEditModal}
                    />
                    {selectedRack && (
                        <RackEditModal
                            isOpen={editModalIsOpen}
                            onClose={closeEditModal}
                            rack={selectedRack}
                            onUpdate={handleUpdate}
                        />
                    )}
                </div>
            </Box>
        </Container>
    );
};

export default RackPage;
