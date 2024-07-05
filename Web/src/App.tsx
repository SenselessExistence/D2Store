import React, { useEffect } from 'react';
import { useTranslation } from 'react-i18next';
import { Outlet } from 'react-router-dom';
import "./i18n";

function App() {
  const { i18n } = useTranslation();

  useEffect(()=>{
    i18n.changeLanguage(navigator.language.split('-')[0]); 
  },[i18n]);
  
  return (
    <Outlet/>
  );
}

export default App;
