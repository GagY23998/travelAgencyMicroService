import {Link} from "react-router-dom";
import "./Header.css";
const Header =()=>{
    return (
        <div style={{backgroundColor:"whitesmoke"}}>
    <header className="header">

            <div className="header__logo">
                <span className="logo">Travel Agency</span>
                </div>
        <nav className="header__navigation">
            <ul className="navigation__list">
                <Link className="list__item" to="/NewsFeed">Home</Link>
                <Link className="list__item" to="/Offers">Offers</Link>
                <Link className="list__item" to="/Locations">Locations</Link>
                <Link className="list__item" to="/Contact">Contact</Link>
                <Link className="list__item" to="/Admin">Admin</Link>
            </ul>
        </nav>
    </header>
        </div>
    );
};

export default Header;