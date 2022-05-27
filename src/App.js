import './App.css';
import React from 'react';
import {BrowserRouter, Route, Link, Routes } from 'react-router-dom';
import {AppBar, Box, Typography, Toolbar} from '@mui/material';

import {Home} from  './components/Home';
import {Orders} from "./components/Orders";
import {Products} from "./components/Products";
import {Users} from "./components/Users";


function App() {
  return (
    <>
      <BrowserRouter>
        <Box sx={{ flexGrow: 1 }}>
        <AppBar>
          <Toolbar>
            <Link to="/"> <Typography sx={{color:"#fff"}}>Home</Typography></Link>
            <Link to="/orders"> <Typography sx={{ml: 5, color:"#fff"}} spacing={2}>Orders</Typography></Link>
            <Link to="/products"> <Typography sx={{ml: 5, color:"#fff"}}>Products</Typography></Link>
            <Link to="/users"> <Typography sx={{ml: 5, color:"#fff"}}>Users</Typography></Link>
          </Toolbar>
        </AppBar>
        </Box>
        <div style={{marginTop: '65px'}}>
          <Routes>
            <Route path='/orders' element={<Orders/>}/>
            <Route path='/products' element={<Products/>}/>
            <Route path='/users' element={<Users/>}/>
            <Route path='/' element={<Home/>}/>
          </Routes>
        </div>
        
      </BrowserRouter>
    </>
  );
}

export default App;
