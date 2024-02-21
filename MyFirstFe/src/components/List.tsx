import List from '@mui/material/List';
import ListItem from './Item';

import { TodoItem } from '../types/todo';


function TodoList({ data }: Readonly<{ data: TodoItem[] }>) {
  return (
    <List
      sx={{ width: '100%', bgcolor: 'background.paper', maxWidth: 400, padding: '4px' }}
    >
      {data.map((datum) => {
        return <ListItem datum={datum} key={datum.id} />
      })}
    </List>
  );
}

export default TodoList;
