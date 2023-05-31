import React from 'react';
import Button from '@mui/material/Button';

const CompanyList = ({ companies, handleUpdate, handleDelete }) => {
  return (
    <div>
      <h3>Company List</h3>
      {companies.map((company) => (
        <div key={company.id}>
          <p>Name: {company.name}</p>
          <p>URL: {company.url}</p>
          <p>Contact Phone: {company.contactPhone}</p>
          <p>Contact Email: {company.contactEmail}</p>
          <Button variant="contained" color="primary" onClick={() => handleUpdate(company.id)}>
            Update
          </Button>
          <Button variant="contained" color="secondary" onClick={() => handleDelete(company.id)}>
            Delete
          </Button>
          <hr />
        </div>
      ))}
    </div>
  );
};

export default CompanyList;
