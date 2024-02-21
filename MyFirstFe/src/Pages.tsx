import { useRoutes } from 'react-router-dom';

import Home from './pages/Home';
import Progress from './pages/Progress';
import Completed from './pages/Completed';
import SideBar from './components/Sidebar';

function PageWrapper({ children }) {
  return <div className="container">
    <SideBar />
    <div>
      {children}
    </div>
  </div>
}

function Pages() {
  const routes = useRoutes([
    {
      path: '/',
      element: (
        <PageWrapper >
          <Home />
        </PageWrapper>
      )
    },
    {
      path: '/completed',
      element: (
        <PageWrapper>
          <Completed />
        </PageWrapper>
      )
    },
    {
      path: '/progress',
      element: (
        <PageWrapper>
          <Progress />
        </PageWrapper>
      )
    },
  ])
  return routes;
}

export default Pages;
