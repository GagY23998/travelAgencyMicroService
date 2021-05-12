import "./Offer.css";
import {Link} from "react-router-dom";
import picture from "../../../images/16.jpg";
import * as actionTypes from "../../../containers/Helpers/actionTypes"
import { useContext } from "react";
import { CartContext } from "../../../reducers/cartReducer";
const TOffer = ({offerClass,item,showModal,index})=>{
    const dateOptions = {
        year: "numeric",
        month: "numeric",
        day: "numeric",
        hour: "numeric",
        minute: "numeric"
    };
    const cartCxt = useContext(CartContext)
    const addItemHandler = ()=>{

        let cond1 = !cartCxt.cart.find(el=>el.compType === "HotelCartItem" && item.transportCompany.city.id === el.item.hotel.cityId)
        let cond2 = !cartCxt.cart.find(el=>el.compType === "TransportCartItem")

        if(cond1 && cond2){

            cartCxt.dispatch({type:actionTypes.ADD_CART_ITEM,payload:{compType:"TransportCartItem",item: item}})
        
        }
    }
return (<article className={"offer "+ offerClass}>
           <div className="offer__name">       
            <label>Company:</label>         
            <span>{item.transportCompany.name}</span>
           </div>
    <div className="offer__imageSection">
        <img className="offer__image" alt="transport" src={picture}/>
    </div>
    <hr/>
    <div className="offer__infoSection">
        <div className="offerinfo">
            <label>Total Reservations:</label>
            <span>{item.totalReservation}</span>
        </div>
        <div className="offerinfo">
            <label>Current Reserved:</label>
            <span>{item.currentReserved}</span>
        </div>
        <div className="offerinfo">
            <label>Total Travels:</label>
            <span>{item.transportCompany.totalTravels}</span>
        </div>
        <div className="offerinfo">
            <label>Start date:</label>
            <span>{new Date(item.startDate).toLocaleTimeString("de-DE",dateOptions).split(",")[0]}</span>
        </div>
        <div className="offerinfo">
            <label>Finish date:</label>
            <span>{new Date(item.finishDate).toLocaleTimeString("de-DE",dateOptions).split(",")[0]}</span>
        </div>
        <div className="offerinfo">
            <label>Price:</label>
            <span>{item.price}</span>
        </div>   
    </div>
    <div className="offerinfo__button">
        <button className="button__link" type="button" onClick={()=>addItemHandler()}>Add To Cart</button>
    </div>
    </article>);
};
export default TOffer;