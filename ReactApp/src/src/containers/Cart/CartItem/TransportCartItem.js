const TransportCartItem = ({item}) =>{
    const dateOptions = {
        year: "numeric",
        month: "numeric",
        day: "numeric",
        hour: "numeric",
        minute: "numeric"
    };

    return <div className="transportCartItem">
        <div className="transport__description">
            <span>City: {item.transportCompany.city.name}</span>
            <span>Hotel Name:{item.transportCompany.Name}</span>            
        </div>
        <div className="transport__info">
            <div>
                <span>Start Date: {new Date(item.startDate).toLocaleTimeString("de-DE",dateOptions).split(",")[0]}</span>
                <span>Finish Date:{new Date(item.finishDate).toLocaleTimeString("de-DE",dateOptions).split(",")[0]}</span>
            </div>
        </div>
    </div>
};

export default TransportCartItem