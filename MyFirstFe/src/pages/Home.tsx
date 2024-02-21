import { useEffect, useState } from 'react';

import TodoList from '../components/List';

import http from '../utils/http';

import config from "../config";

function Home() {
  const [data, setData] = useState<any[]>([])

  useEffect(() => {
    (async () => {
      const resp = await http.get(
        config.api.baseUrl
      );

      setData(resp.data);
    })();
  }, [])

  return <TodoList data={data} />
}

export default Home;
