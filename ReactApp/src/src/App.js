import './App.css';
import {BrowserRouter} from "react-router-dom";
import Sidebar from './containers/Main/Sidebar/Sidebar';
import MainContent from './containers/Main/Main';
import Footer from "./containers/Footer/Footer";
import Header from"./containers/Header/Header";
function App() {
  return (<BrowserRouter>
         <Header/>
         <Sidebar/>
         <MainContent/>
         <Footer/>
         </BrowserRouter>
  );
}

export default App;
