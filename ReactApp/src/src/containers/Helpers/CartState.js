import { CartContext, cartReducer, initialState } from "../../reducers/cartReducer";
import {useReducer} from "react"

const CartState = ({children})=>{
    const [state,dispatch] = useReducer(cartReducer,initialState)

    return <CartContext.Provider value={{cart:state,dispatch: dispatch}}>
        {children}
    </CartContext.Provider>
}

export default CartState;