import { useCallback, useRef } from "react";

import Grid from '@mui/material/Grid';
import Button from "@mui/material/Button";
import TextField from "@mui/material/TextField";

import useTodoList from "../hooks/useTodoList";

function AddTask() {
  const addTaskInputRef = useRef<HTMLInputElement>(null);

  const { addTodo, isAddingNewTask } = useTodoList();

  const addItem = useCallback(async () => {
    if (addTaskInputRef.current) { // Check if ref is not null before accessing value
      const taskName = addTaskInputRef.current.value;

      if (taskName.trim() !== "") {
        // No need to try catch as it is done in the hook itself.
        await addTodo(taskName);
        addTaskInputRef.current.value = ""; // Clear input field after adding task
      }
    }
  }, [addTodo]);

  return <div style={{ margin: '10px', maxWidth: '400px' }}>
    <p>
      Add Form
    </p>
    <Grid container spacing={2}>
      <Grid item xs={8}>
        <TextField
          sx={{ input: { color: "white" }, width: '100%' }}
          color="info"
          inputRef={addTaskInputRef}
          defaultValue=""
          placeholder="Add your task here."
          InputProps={{
            classes: {
              notchedOutline: 'nicehai',
            },
            inputMode: 'numeric',
          }}
        />
      </Grid>
      <Grid item xs={4}>
        <Button variant="contained" color="success" disabled={false} onClick={addItem}>
          {isAddingNewTask ? <>Adding</> : <>Add Task</>}
        </Button>
      </Grid>

    </Grid>
  </div>
}

export default AddTask;
