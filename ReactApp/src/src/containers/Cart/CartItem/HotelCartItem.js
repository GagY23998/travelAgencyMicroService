const HotelCartItem =({item})=>{
    const dateOptions = {
        year: "numeric",
        month: "numeric",
        day: "numeric",
        hour: "numeric",
        minute: "numeric"
    };
    return (<div className="cart__item">
        <div className="hoteldescription">
            {/* <span>City: {item.hotel.city.name}</span> */}
            <span>Hotel Name:{item.hotel.name}</span>            
        </div>
        <div className="hOffer__Info">
            <div>
                <span>Start Date: {new Date(item.startDate).toLocaleTimeString("de-DE",dateOptions).split(",")[0]}</span>
                <span>Finish Date:{new Date(item.expirationDate).toLocaleTimeString("de-DE",dateOptions).split(",")[0]}</span>
            </div>
        </div>
    </div>)
};
export default HotelCartItem;