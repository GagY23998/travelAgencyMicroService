import {Link} from "react-router-dom";
import * as actionTypes from "../../../containers/Helpers/actionTypes"
import "./Offer.css";
import picture from "../../../images/16.jpg";
import { useContext } from "react";
import { CartContext } from "../../../reducers/cartReducer";
const HOffer=({offerClass,
               item,
               showModal,
               index})=>{
                const dateOptions = {
                    year: "numeric",
                    month: "numeric",
                    day: "numeric",
                    hour: "numeric",
                    minute: "numeric"
                };
    const cartCxt = useContext(CartContext);
    const addItemHandler = ()=>{

        let cond1 = !cartCxt.cart.find(el=>el.compType === "TransportCartItem" && el.item.transportCompany.city.id === item.hotel.cityId)
        let cond2 = !cartCxt.cart.find(el=>el.compType === "HotelCartItem")

        if(cond1 && cond2){

            cartCxt.dispatch({type:actionTypes.ADD_CART_ITEM,payload:{compType:"HotelCartItem",item: item}})
        
        }
    }
    return (<article className={"offer "+ offerClass}>
            <div className="offer__name">
                    <label>Hotel Name:</label>
                    <span>{item.hotel.name}</span>
                </div>
            <div className="offer__imageSection">
                <img className="offer__image" alt="hotel" src={picture} />
            </div>
            <hr/>
            <div className="offer_infoSection">
                <div className="offerinfo">
                    <label>Number of Rooms:</label>
                    <span>{item.hotelRoom.capacity}</span>
                </div>
                <div className="offerinfo">
                    <label>Room Type:</label>
                    <span>{item.hotelRoom.type}</span>
                </div>
                <div className="offerinfo">
                    <label>Start Date:</label>
                    <span>{new Date(item.startDate).toLocaleTimeString("de-DE",dateOptions).split(",")[0]}</span>
                </div>
                <div className="offerinfo">
                    <label>Expiration Date:</label>
                    <span>{new Date(item.expirationDate).toLocaleTimeString("de-DE",dateOptions).split(",")[0]}</span>
                </div>
                <div className="offerinfo">
                    <label>Offer Expired:</label>
                    <input type="checkbox" disabled value={item.offerFinished}/></div>
                <div className="offerinfo">
                    <label>Price:</label>
                    <span>{item.price.toFixed(2)}</span></div>
            </div>
            
                <div className="offerinfo__button">
                    <button type="button" className="button__link" onClick={()=>addItemHandler()}>Add To Cart</button>
                </div>
    </article>);
}

export default HOffer;