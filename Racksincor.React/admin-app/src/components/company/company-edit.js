import React, { useState } from 'react';
import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';

const CompanyEdit = ({ company, handleUpdate }) => {
  const [name, setName] = useState(company.name);
  const [url, setUrl] = useState(company.url);
  const [contactPhone, setContactPhone] = useState(company.contactPhone);
  const [contactEmail, setContactEmail] = useState(company.contactEmail);

  const handleSubmit = (e) => {
    e.preventDefault();
    handleUpdate(company.id, name, url, contactPhone, contactEmail);
  };

  return (
    <div>
      <h3>Edit Company</h3>
      <form onSubmit={handleSubmit}>
        <TextField
          label="Name"
          variant="outlined"
          fullWidth
          value={name}
          onChange={(e) => setName(e.target.value)}
          sx={{ marginBottom: 2 }}
        />
        <TextField
          label="URL"
          variant="outlined"
          fullWidth
          value={url}
          onChange={(e) => setUrl(e.target.value)}
          sx={{ marginBottom: 2 }}
        />
        <TextField
          label="Contact Phone"
          variant="outlined"
          fullWidth
          value={contactPhone}
          onChange={(e) => setContactPhone(e.target.value)}
          sx={{ marginBottom: 2 }}
        />
        <TextField
          label="Contact Email"
          variant="outlined"
          fullWidth
          value={contactEmail}
          onChange={(e) => setContactEmail(e.target.value)}
          sx={{ marginBottom: 2 }}
        />
        <Button type="submit" variant="contained" color="primary">
          Update
        </Button>
      </form>
    </div>
  );
};

export default CompanyEdit;
