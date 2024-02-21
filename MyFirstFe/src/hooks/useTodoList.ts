import { useEffect } from "react";

import useStore from "../store";

import http from '../utils/http';

import config from "../config";

import useMySnackBar from "./useSnackBar";

function useTodoList() {
  const { isLoading, isAddingNewTask, todoItems, initiate, setLoading, setAddingNewTask, toggle, add } = useStore();

  const { success, error } = useMySnackBar();

  useEffect(() => {
    (async () => {
      if (isLoading || todoItems.length) {
        return;
      }

      setLoading(true);
      try {
        const resp = await http.get(
          config.api.baseUrl
        );

        initiate(resp.data);
      } catch (e) {
        error("Error fetching todo list.")
      } finally {
        setLoading(false);
      }

    })();
  })

  const toggleTodo = async (id: string, action: "Completed" | "In Progress") => {
    const initialStatus = todoItems.find(item => item.id === id)?.status ?? "In Progress";
    // Early success.
    toggle(id, action);

    try {
      await http.patch(
        `${config.api.baseUrl}/${id}/status`,
        {
          status: action
        }
      );
      // success alert
      success("Successfully updated the task status.");

      toggle(id, action);
      // Again set to make sure of the race condition for concurrent requests.
      // Alternatives.
      // Can use debounche.
      // Also can store ids of item whose status are being changeed.
    } catch (e) {
      error("Error updating the task status.");

      // Reverting the action.
      toggle(id, initialStatus);
    }
  }

  const addTodo = async (title: string) => {
    if (isAddingNewTask) {
      return;
    }

    setAddingNewTask(true);
    try {
      const data = await http.post(
        `${config.api.baseUrl}`,
        {
          title: title,
        }
      );

      add(data.data);
      success("Successfully created a new task");
    } catch (e) {
      error("Error adding a new task");
    } finally {
      setAddingNewTask(false);
    }
  }

  return { todoItems, isLoading, isAddingNewTask, toggleTodo, addTodo };
}

export default useTodoList;
