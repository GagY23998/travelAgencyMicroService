import {Link} from "react-router-dom";
import "./Sidebar.css";

const Sidebar = (props)=>{

    return <aside className="Sidebar">
        <Link to="/">Home</Link>
        <Link to="/MyBookings">My Bookings</Link> 
        <Link to="/Account" >Account</Link>
    </aside>    

};


export default Sidebar;