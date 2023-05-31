import React, { useState } from 'react';
import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';

const CompanyCreate = ({ handleCreate }) => {
  const [name, setName] = useState('');
  const [url, setUrl] = useState('');
  const [contactPhone, setContactPhone] = useState('');
  const [contactEmail, setContactEmail] = useState('');

  const handleSubmit = (e) => {
    e.preventDefault();
    handleCreate(name, url, contactPhone, contactEmail);
    setName('');
    setUrl('');
    setContactPhone('');
    setContactEmail('');
  };

  return (
    <div>
      <h3>Create Company</h3>
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
          Create
        </Button>
      </form>
    </div>
  );
};

export default CompanyCreate;
