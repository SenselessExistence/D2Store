import React, { useEffect, useState } from 'react';
import { useTranslation } from 'react-i18next';
import { Outlet } from 'react-router-dom';
import "./i18n";
import axios from 'axios';

function App() {
  const { i18n } = useTranslation();
  const [init, setinit]= useState<boolean>(false);

  useEffect(()=>{
    i18n.changeLanguage(navigator.language.split('-')[0]);
    axios.interceptors.request.use((config) => {
      config.baseURL = `https://localhost:44349/`;
      return config;
    });
    setinit(true);
  },[i18n]);


  
  return (
    <>
    {init &&
      <Outlet/>
    } 
    </>
  );
}

export default App;
