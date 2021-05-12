import * as Components from "../../Helpers/Components"

const CartItem = ({data})=>{
    
    const Component = Components[data.compType]
    
    return <Component item={data.item} />

};

export default CartItem;