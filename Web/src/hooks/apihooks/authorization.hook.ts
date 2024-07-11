import { useCallback} from "react";
import { FormValues } from "../../types/form-values.type";
import axios from "axios";
import { Token } from "../../types/token.type";


interface AuthRequests {
  register: (value: FormValues) => Promise<void>;
  login: (value: Pick<FormValues, 'email'| 'password'>) => Promise<Token>;
}

const useAuthorization = (): AuthRequests => {
  const baseUrl = '/api/Authorization';

  const register = useCallback(async (value: FormValues) => {
    const { data } = await axios.post<void>(`${baseUrl}/Register`,value);
    return data;
  },[]);

  const login = useCallback(async (value: Pick<FormValues, 'email'| 'password'>) => {
    const { data } = await axios.post<Token>(`${baseUrl}/Login`,value);
    return data;
  },[]);

  return {
    register,
    login
  };
};

export default useAuthorization;
