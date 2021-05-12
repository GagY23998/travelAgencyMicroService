import {useReducer} from "react";
import { initialState } from "../../reducers/cartReducer";
const useAsyncReducer= (reducer)=>{
    const [state,dispatch] = useReducer(reducer,initialState);
    console.log("Inside asyncReducer,state:",state);
    const asyncDispatch = (action) => {
        return function (){
            if (action instanceof Function){
                console.log(action)
                action(asyncDispatch)
            }
            else{
                dispatch(action);
            }
        }
    }
    return [state,asyncDispatch];
}
export default useAsyncReducer