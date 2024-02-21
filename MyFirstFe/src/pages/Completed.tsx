import TodoList from "../components/List";
import useStore from "../store";

function Completed() {
  const { todoItems: data } = useStore();

  return <TodoList data={data} />
}

export default Completed;
