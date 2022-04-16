import logo from './logo.svg';
import './App.css';
import {BrowserRouter as Router} from 'react-router-dom';
import RoutingConfig from './routing/RoutingConfig';
import Header from './header/Header';

function App() {
  return (
    <Router>
      <Header />
      <RoutingConfig />
    </Router>
  );
}

export default App;
