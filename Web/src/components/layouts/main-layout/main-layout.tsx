import React from 'react';
import './main-layout.scss';
import Navbar from '../../navbar/navbar';
import { Outlet } from 'react-router-dom';
function MainLayout() {
  return (
    <>
      <Navbar/>
      <div className='main-body'>
        <Outlet/>
      </div>
    </>
  );
}

export default MainLayout;
