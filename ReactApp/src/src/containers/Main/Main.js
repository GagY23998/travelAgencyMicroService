import {useState} from "react";
import {Switch,Route} from "react-router-dom";
import NewsFeed from "../../components/NewsFeed/NewsFeed";
import Account from "../../components/User/User";
import "./Main.css";
import Locations from "../../components/Locations/Locations"
import Contact from "../../components/Contact/Contact"
import CartState from "../Helpers/CartState";
import Cart from "../Cart/Cart";
import Panel from "../../components/Admin/Panel/Panel";

const MainContent = ()=>{
    return (<div className="layout">
        <CartState>
        <Switch>
            <Route path="/Contact" component={Contact}/>
            <Route path="/Locations" component={Locations} />
            <Route path="/Account" component={Account}/>
            <Route path="/Admin" >
                <Panel/>
                </Route>
            <Route path="/" component={NewsFeed} />
        </Switch>
        <Cart/>
        </CartState>
    </div>)
};


export default MainContent;