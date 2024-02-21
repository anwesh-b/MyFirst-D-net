import ListItem from '@mui/material/ListItem';
import ListItemText from '@mui/material/ListItemText';
import Switch from '@mui/material/Switch';

function Item(props: any) {
  const { datum } = props;

  return <ListItem sx={{ bgcolor: 'text.secondary', borderRadius: '4px', border: '2px red', marginTop: '8px', marginBottom: '8px' }}>
    <ListItemText primary={datum.title} />
    <Switch
      edge="end"
      checked={datum.status === 'Completed'}
      inputProps={{
        'aria-labelledby': 'switch-list-label-wifi',
      }}
    />
  </ListItem>
}

export default Item;

