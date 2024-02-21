import TodoList from "../components/List";
import useStore from "../store";

function Progress () {
  const { getInProgressTasks } = useStore();

  const completedData = getInProgressTasks();

  return <TodoList data={completedData} />
}

export default Progress;
