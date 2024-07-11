import React, { createContext, useContext, ReactNode } from 'react';
import { Token } from '../types/token.type';

type TokenContextType =  {
  getToken: () => Token | undefined, 
  setToken: (token: Token | null) => void
};


const TokenContext = createContext<Partial<TokenContextType>>({
});

export const TokenProvider: React.FC<{ children: ReactNode }> = ({ children }) => {

  const setToken = (token: Token | null) => {
    if (token) {
      localStorage.setItem('token', JSON.stringify(token));
    }
  }

  const getToken = () => localStorage.getItem('token')? JSON.parse(localStorage.getItem('token') as string) : undefined;

  return (
    <TokenContext.Provider value={{getToken, setToken}}>
      {children}
    </TokenContext.Provider>
  );
};

export const useToken = (): Partial<TokenContextType> =>  useContext(TokenContext);
