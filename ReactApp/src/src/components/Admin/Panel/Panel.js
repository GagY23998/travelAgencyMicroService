import { useState } from "react"
import AdminFilter from "../AdminFilter/AdminFilter"
import * as Components from "../../../containers/Helpers/Components"
import { Route, Switch, useRouteMatch } from "react-router"
import Reservations from "../Booking/Reservations"
import Users from "../Users/Users"
import { Link } from "react-router-dom"
import "./Panel.css"

const Panel = ()=> {
    let {path,url} = useRouteMatch()
    const subRoutes = [
        {
            component: Reservations,
            subroute: "Reservations"
        },
        {
            component: Users,
            subroute: "Users"
        },
        // {
        //     component: Contacts,
        //     subroute: "Contacts"
        // }
    ]
    console.log(path,url);
    return <>
        <ul className="panel__nav">
            {
                subRoutes.map((e,i)=>{
                    return <Link key={e.subroute} className="panel__nav__item" to={`${url}/${e.subroute}`}>{e.subroute}</Link>
                })
            }
        </ul>
        <Switch>
            {
                subRoutes.map((e,i)=>{
                    return <Route key={e.subroute} path={`${url}/${e.subroute}`} component={e.component}/>
                })
            }
        </Switch>
    </>

}
export default Panel