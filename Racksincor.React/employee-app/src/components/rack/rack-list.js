import React, { useState } from "react";
import Button from "@mui/material/Button";
import Grid from "@mui/material/Grid";
import Paper from "@mui/material/Paper";
import Box from "@mui/material/Box";
import Pagination from "@mui/material/Pagination";

const RackList = ({ racks, onDelete, onOpenEditModal, onViewProducts }) => {
    const [page, setPage] = useState(1);
    const racksPerPage = 5;
    const totalPages = Math.ceil(racks.length / racksPerPage);

    const handlePageChange = (event, value) => {
        event.preventDefault();
        setPage(value);
    };

    const startIndex = (page - 1) * racksPerPage;
    const endIndex = startIndex + racksPerPage;
    const displayedRacks = racks.slice(startIndex, endIndex);

    return (
        <div>
            {displayedRacks.map((rack) => (
                <div key={rack.id}>
                    <Paper variant="outlined" sx={{ p: 2, mb: 2 }}>
                        <Grid container spacing={2} alignItems="center">
                            <Grid item xs={6}>
                                <Box>
                                    <p>Name: {rack.name}</p>
                                </Box>
                            </Grid>
                            <Grid item xs={6}>
                                <Box display="flex" justifyContent="flex-end">
                                    <Button
                                        variant="contained"
                                        color="primary"
                                        onClick={() => onOpenEditModal(rack)}
                                    >
                                        Update
                                    </Button>
                                    <Button
                                        variant="contained"
                                        color="secondary"
                                        onClick={() => onDelete(rack.id)}
                                        sx={{ ml: 2 }}
                                    >
                                        Delete
                                    </Button>
                                    <Button
                                        variant="contained"
                                        color="primary"
                                        onClick={() => onViewProducts(rack.id)}
                                        sx={{ ml: 2 }}
                                    >
                                        View Products
                                    </Button>
                                </Box>
                            </Grid>
                        </Grid>
                    </Paper>
                </div>
            ))}
            <Pagination
                count={totalPages}
                page={page}
                onChange={handlePageChange}
                color="primary"
                size="large"
                showFirstButton
                showLastButton
            />
        </div>
    );
};

export default RackList;
