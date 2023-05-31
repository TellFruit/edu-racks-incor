import React, { useState } from 'react';
import Button from '@mui/material/Button';
import Grid from '@mui/material/Grid';
import Paper from '@mui/material/Paper';
import Box from '@mui/material/Box';
import Pagination from '@mui/material/Pagination';

const CompanyList = ({ companies, onDelete, onOpenEditModal }) => {
  const [page, setPage] = useState(1);
  const companiesPerPage = 5;
  const totalPages = Math.ceil(companies.length / companiesPerPage);

  const handlePageChange = (event, value) => {
    event.preventDefault();
    setPage(value);
  };

  const startIndex = (page - 1) * companiesPerPage;
  const endIndex = startIndex + companiesPerPage;
  const displayedCompanies = companies.slice(startIndex, endIndex);

  return (
    <div>
      {displayedCompanies.map((company) => (
        <div key={company.id}>
          <Paper variant="outlined" sx={{ p: 2, mb: 2 }}>
            <Grid container spacing={2} alignItems="center">
              <Grid item xs={8}>
                <Box>
                  <p>Name: {company.name}</p>
                  <p>URL: {company.url}</p>
                  <p>Contact Phone: {company.contactPhone}</p>
                  <p>Contact Email: {company.contactEmail}</p>
                </Box>
              </Grid>
              <Grid item xs={4}>
                <div style={{ display: 'flex', justifyContent: 'flex-end' }}>
                  <Button variant="contained" color="primary" onClick={() => onOpenEditModal(company)}>
                    Update
                  </Button>
                  <Button variant="contained" color="secondary" onClick={() => onDelete(company.id)}>
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

export default CompanyList;
