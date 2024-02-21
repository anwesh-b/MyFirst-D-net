import { create, StoreApi, UseBoundStore } from "zustand";
import { TodoItem } from "./types/todo";

interface State {
  todoItems: TodoItem[],
  isLoading: boolean,
  isAddingNewTask: boolean,
}

interface Actions {
  toggle: (id: string, action: string) => void,
  add: (item: TodoItem) => void,
  initiate: (items: TodoItem[]) => void,
  setLoading: (isLoading: boolean) => void,
  setAddingNewTask: (isLoading: boolean) => void,
}

interface DataManipulationActions {
  getCompletedTasks: () => TodoItem[],
  getInProgressTasks: () => TodoItem[],
}

interface GlobalState extends State, Actions, DataManipulationActions {
}

const useStore: UseBoundStore<StoreApi<GlobalState>> = create<GlobalState>(
  (set) => ({
    todoItems: [],
    isLoading: false,
    isAddingNewTask: false,
    add: (item) => {
      set((state) => {
        state.todoItems.push(item);
        return {
          todoItems: state.todoItems
        }
      })
    },
    toggle: (id, action) => {
      set((state) => {
        const index = state.todoItems.findIndex(item => item.id === id);
        state.todoItems[index].status = action;
        return {
          todoItems: state.todoItems
        };
      })
    },
    initiate: (items: TodoItem[]) => {
      set({ todoItems: items, isLoading: false })
    },
    setLoading: (isLoading: boolean) => {
      set({ isLoading })
    },
    setAddingNewTask: (isAddingNewTask: boolean) => {
      set({ isAddingNewTask })
    },
    getCompletedTasks: () => {
      // eslint-disable-next-line react-hooks/rules-of-hooks
      return useStore().todoItems.filter((datum) => datum.status === "Completed")
    },
    getInProgressTasks: () => {
      // eslint-disable-next-line react-hooks/rules-of-hooks
      return useStore().todoItems.filter((datum) => datum.status === "In Progress")
    }
  })
);

export default useStore;
