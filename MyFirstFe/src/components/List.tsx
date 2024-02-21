import List from '@mui/material/List';
import ListItem from './Item';

import { TodoItem } from '../types/todo';


function TodoList({ data }: Readonly<{ data: TodoItem[] }>) {
  if (!data.length) {
    return <div style={{ height: '100px', width: '400px', backgroundColor: 'white', padding: '20px 10px', color: 'black' }}>
      No data guys
    </div>
  }

  return (
    <List
      sx={{ width: '100%', bgcolor: 'background.paper', maxWidth: 400, padding: '4px' }}
      nonce='asd'
    >
      {data.map((datum) => {
        return <ListItem datum={datum} key={datum.id} />
      })}
    </List>
  );
}

export default TodoList;
