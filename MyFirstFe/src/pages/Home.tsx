import TodoList from '../components/List';
import useTodoList from '../hooks/useTodoList';

function Home() {
  const { todoItems: data, isLoading } = useTodoList();

  return <>
    <TodoList data={data} />
    {isLoading && <>Loading state</>}
  </>
}

export default Home;
