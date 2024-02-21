import { BrowserRouter } from 'react-router-dom';
import { SnackbarProvider } from 'notistack';

import Pages from './Pages'

function App() {
  return <BrowserRouter basename="">
    <SnackbarProvider maxSnack={3}>
      <Pages />
    </SnackbarProvider>
  </BrowserRouter>
}

export default App
