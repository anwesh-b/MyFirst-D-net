import { create } from "zustand";
import { TodoItem } from "./types/todo";

type State = {
  todoItems: TodoItem[],
  isLoading: boolean,
};

type Actions = {
  toggle: (id: string, action: string) => void,
  add: (item: TodoItem) => void,
  initiate: (items: TodoItem[]) => void,
  setLoading: (isLoading: boolean) => void
};

type GlobalState = State & Actions;

const useStore = create<GlobalState>(
  (set) => ({
    todoItems: [],
    isLoading: false,
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
    }
  })
);

export default useStore;
