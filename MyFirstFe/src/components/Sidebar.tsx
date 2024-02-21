import { NavLink, useLocation } from 'react-router-dom';

import Button from '@mui/material/Button';

type RouteType = {
  name: string,
  path: string
}

const routes: RouteType[] = [
  { name: "All", path: "/" },
  { name: "Completed", path: "/completed" },
  { name: "Progress", path: "/progress" },
]

function SidebarItem(props: Readonly<{ route: RouteType }>) {
  const { route } = props;

  const { name, path } = route;
  const location = useLocation();

  const variant = location.pathname === path ? 'contained' : "outlined";

  return <NavLink to={path}>
    <Button variant={variant} >{name}</Button>
  </NavLink>
}

function SideBar() {
  return <div>
    {
      routes.map(
        route => <SidebarItem route={route} key={route.path} />
      )
    }
  </div>
}

export default SideBar;
