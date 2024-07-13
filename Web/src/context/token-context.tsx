import React, { createContext, useContext, ReactNode, useEffect, useCallback, useState } from 'react';
import { Token } from '../types/token.type';
import  { jwtDecode } from 'jwt-decode';
import axios from 'axios';
import useClient from '../hooks/apihooks/client.hook copy';

type TokenContextType =  {
  getToken: () => Token | undefined, 
  setToken: (token: Token | null) => void
};


const TokenContext = createContext<Partial<TokenContextType>>({
});

export const TokenProvider: React.FC<{ children: ReactNode }> = ({ children }) => {
  const [id, setId] = useState<number>();
  const {getClient} = useClient();

  const setToken = useCallback((token: Token | null) => {
    if (token) {
      const decodedToken = jwtDecode(token.token);
      setId((decodedToken as any).UserId);
      localStorage.setItem('token', JSON.stringify({token: token.token, exp: decodedToken.exp}));
    }
  },[]);

  const getToken = useCallback(() => localStorage.getItem('token')? JSON.parse(localStorage.getItem('token') as string) : undefined,[]);

  const isTokenExpired = useCallback((token: Token) => {
    if (token && token.expirationDate) {
      const currentTime = Date.now() / 1000;
      const expiresIn = token.expirationDate - currentTime;
      if (expiresIn > 0) {
        setTimeout(() => {
          setToken(null);
          window.location.reload();
        }, expiresIn * 1000);
      }
      return token.expirationDate < currentTime;
    }
    return true;
  }, [setToken]);

  useEffect(() => {
    const token = getToken();
    if (token) {
      isTokenExpired(token);
      const decodedToken = jwtDecode(token.token);
      setId((decodedToken as any).UserId);
    }
    const requestInterceptor = axios.interceptors.request.use(
      function (config) {
        const token = getToken();
        if (token){
          config.headers.Authorization = `Bearer ${token.token}`;
        }
        return config;
      },
      function (error) {
        return Promise.reject(error);
      }
    );

    return () => {
      axios.interceptors.request.eject(requestInterceptor);
    };
  }, [getToken, isTokenExpired, setToken]);

  useEffect(()=>{
    if (id) {
      getClient(id).then(user => console.log(user));
    }
  },[id, getClient]);

  return (
    <TokenContext.Provider value={{getToken, setToken}}>
      {children}
    </TokenContext.Provider>
  );
};

export const useToken = (): Partial<TokenContextType> =>  useContext(TokenContext);
