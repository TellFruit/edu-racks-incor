import React, { useState } from 'react';
import Button from '@mui/material/Button';
import Grid from '@mui/material/Grid';
import Paper from '@mui/material/Paper';
import Box from '@mui/material/Box';
import Pagination from '@mui/material/Pagination';

const EmployeeList = ({ users, onDelete, onOpenEditModal }) => {
  const [page, setPage] = useState(1);
  const usersPerPage = 5;
  const totalPages = Math.ceil(users.length / usersPerPage);

  const handlePageChange = (event, value) => {
    event.preventDefault();
    setPage(value);
  };

  const startIndex = (page - 1) * usersPerPage;
  const endIndex = startIndex + usersPerPage;
  const displayedUsers = users.slice(startIndex, endIndex);

  return (
    <div>
      {displayedUsers.map((user) => (
        <div key={user.id}>
          <Paper variant="outlined" sx={{ p: 2, mb: 2 }}>
            <Grid container spacing={2} alignItems="center">
              <Grid item xs={12}>
                <Box>
                  <p>Email: {user.email}</p>
                </Box>
              </Grid>
              <Grid item xs={12}>
                <div style={{ display: 'flex', justifyContent: 'flex-end' }}>
                  <Button variant="contained" color="primary" onClick={() => onOpenEditModal(user)}>
                    Update
                  </Button>
                  <Button variant="contained" color="secondary" onClick={() => onDelete(user.id)} sx={{ ml: 2 }}>
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

export default EmployeeList;
