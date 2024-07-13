import { useCallback} from "react";
import axios from "axios";


interface ClientRequests {
  getClient: (id: number) => Promise<any>;
}

const useClient = (): ClientRequests => {
  const baseUrl = '/api/Client';

  const getClient = useCallback(async (id: number) => {
    const { data } = await axios.get<any>(`${baseUrl}/${id}`);
    return data;
  },[]);


  return {
    getClient
  };
};

export default useClient;
