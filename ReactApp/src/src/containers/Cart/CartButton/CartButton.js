import "./CartButton.css"
import picture from "../../../images/shoppIcon.png"
import { useContext } from "react"
import { CartContext } from "../../../reducers/cartReducer"
const CartButton =({click})=> {
    const {cart} = useContext(CartContext)
return <div className="cartButton" onClick={click} >
    <img className={"cartImg"+ (cart && cart.length!==0?"cartShow":"cartHide")} alt="shoppingCart" src={picture}/>
</div>
}
export default CartButton