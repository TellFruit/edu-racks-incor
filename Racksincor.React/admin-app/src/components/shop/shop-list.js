import React, { useState } from 'react';
import Button from '@mui/material/Button';
import Grid from '@mui/material/Grid';
import Paper from '@mui/material/Paper';
import Box from '@mui/material/Box';
import Pagination from '@mui/material/Pagination';

const ShopList = ({ shops, onDelete, onOpenEditModal }) => {
  const [page, setPage] = useState(1);
  const shopsPerPage = 5;
  const totalPages = Math.ceil(shops.length / shopsPerPage);

  const handlePageChange = (event, value) => {
    event.preventDefault();
    setPage(value);
  };

  const startIndex = (page - 1) * shopsPerPage;
  const endIndex = startIndex + shopsPerPage;
  const displayedShops = shops.slice(startIndex, endIndex);

  return (
    <div>
      {displayedShops.map((shop) => (
        <div key={shop.id}>
          <Paper variant="outlined" sx={{ p: 2, mb: 2 }}>
            <Grid container spacing={2} alignItems="center">
              <Grid item xs={8}>
                <Box>
                  <p>Name: {shop.name}</p>
                  <p>Address: {shop.address}</p>
                </Box>
              </Grid>
              <Grid item xs={4}>
                <div style={{ display: 'flex', justifyContent: 'flex-end' }}>
                  <Button variant="contained" color="primary" onClick={() => onOpenEditModal(shop)}>
                    Update
                  </Button>
                  <Button variant="contained" color="secondary" onClick={() => onDelete(shop.id)} sx={{ ml: 2 }}>
                    Delete
                  </Button>
                </div>
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

export default ShopList;
