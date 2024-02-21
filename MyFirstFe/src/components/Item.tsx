import Switch from '@mui/material/Switch';
import ListItem from '@mui/material/ListItem';
import ListItemText from '@mui/material/ListItemText';

import { TodoItem } from '../types/todo';
import useTodoList from '../hooks/useTodoList';

function Item(props: Readonly<{ datum: TodoItem }>) {
  const { datum } = props;

  const { toggleTodo } = useTodoList();

  return <ListItem sx={{ bgcolor: 'text.secondary', borderRadius: '4px', border: '2px red', marginTop: '8px', marginBottom: '8px' }}>
    <ListItemText primary={datum.title} />
    <Switch
      edge="end"
      onChange={() => toggleTodo(datum.id, datum.status === 'Completed' ? "In Progress" : "Completed")}
      checked={datum.status === 'Completed'}
      inputProps={{
        'aria-labelledby': 'switch-list-label-wifi',
      }}
    />
  </ListItem>
}

export default Item;
