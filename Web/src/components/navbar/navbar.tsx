import React from 'react';
import './navbar.scss';
import { useTranslation } from 'react-i18next';
import { Link } from 'react-router-dom';
function Navbar() {
  const {t} = useTranslation();
  return (
    <nav>
      <div>
        <img src='/images/logo.png' className='logo' alt='logo'/>
      </div>
      <div className='nav-actions'>
        <Link to='registration'>{t('register')}</Link> |
        <Link to='login'>{t('login')}</Link>
      </div>
    </nav>
  );
}

export default Navbar;
