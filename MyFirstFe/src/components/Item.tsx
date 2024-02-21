import ListItem from '@mui/material/ListItem';
import ListItemText from '@mui/material/ListItemText';
import Switch from '@mui/material/Switch';
import useStore from '../store';
import { TodoItem } from '../types/todo';
import React, { useEffect } from 'react';
import useTodoList from '../hooks/useTodoList';

function Item(props: Readonly<{ datum: TodoItem }>) {
  const { toggleTodo } = useTodoList();

  const { datum } = props;
  useEffect(()=>{
    console.log("hello");
  },[])

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

export default React.memo(Item);

