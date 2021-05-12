import "./Location.css";
import picture from "../../../images/8.png";
const Location= ({item, setCity})=>
{

return (<article className="country__wrapper">
    <div className="locationimg__container">
        <img src={picture} height="300px" width="300px" alt="location"/>
    </div>
    <div className="country__info">
        <pre className="location__description">
            {item.description}
        </pre>
    </div>
    <div className="btn__country__wrapper">
        <button type="button" onClick={(e)=>setCity(e,item.id)}>Check Offers</button>
    </div>
</article>);
};

export default Location;