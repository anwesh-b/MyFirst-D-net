
import Pages from './Pages'

import { BrowserRouter } from 'react-router-dom';

function App() {
  return <BrowserRouter basename="">
      <Pages />
    </BrowserRouter>
}

export default App
