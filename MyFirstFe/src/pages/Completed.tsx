import TodoList from "../components/List";
import useStore from "../store";

function Completed() {
  const { getCompletedTasks } = useStore();

  const completedData = getCompletedTasks();

  return <TodoList data={completedData} />
}

export default Completed;
