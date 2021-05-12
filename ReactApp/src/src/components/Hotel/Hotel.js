import {useState,useEffect} from "react";
import "./Hotel.css";
import picture from "../../images/16.jpg";

const Hotel = ({data})=>{
    useEffect(() => {
        setHotelState(data);
        console.log("this is hotel data");
        console.log(data);
    }, [data]);
    const [hotelState,setHotelState] = useState({});
    return <div className="hotel__wrapper">
        <div className="img__hotel">
            <img src={picture} height="300px" width="200px" alt="Hotel"/>
        </div>
        <div className="hotel__info">
            <label>Hotel Name:</label>
            <span>{hotelState.name}</span>
        </div>
        <div className="hotel__info">
            <label>Rating:</label>
            <span>{hotelState.rating}</span>
        </div>
        <div className="hotel__info">
            <label>Hotel Description</label>
            <span>{hotelState.description}</span>
        </div>
    </div>;

};

export default Hotel;