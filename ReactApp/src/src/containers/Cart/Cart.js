import {useState, useContext } from "react"
import { CartContext } from "../../reducers/cartReducer"
import CartItem from "./CartItem/CartItem"
import CartButton from "./CartButton/CartButton"
import "./Cart.css"
import UseApi from "../Helpers/ApiHook"

const Cart = ()=>{

    const {cart} = useContext(CartContext)
    const [showContainer, setShowContainer] = useState(false)
    console.log(cart)

    const cartClickHandler = e=>{
        setShowContainer(!showContainer)
    }

    const submitOrderHandler = (e)=>{
        const apiCall = UseApi("/booking").post("",{
            hotelOffer: cart.find(el=>el.compType==="HotelCartItem").id,
            transportOffer: cart.find(el=>el.compType==="TransportCartItem").id,
            reservationDate: Date.now()
        })
        apiCall.then(res=>console.log(res)).catch(err=>console.error(err))
    }

    return <>
        <CartButton click={cartClickHandler}/>
        {
            (showContainer)?
            <div className="cartItems__container">
                {cart.map((e,i)=><CartItem key={"CartItem"+ i} data={e}/>)}
                <button type="button" onClick={submitOrderHandler}>Submit Order</button>
            </div> 
            :null
                
        }
    </>
}
    
export default Cart