import React from "react";
import * as actionType from "../containers/Helpers/actionTypes";

export const initialState= [];

export const CartContext = React.createContext(null);
export const cartReducer = (state=initialState,action)=>{

    switch (action.type) {
        case actionType.ADD_CART_ITEM:
            console.log(action.payload)
            return [...state, action.payload]
        case actionType.REMOVE_CART_ITEM:
            const newState = state.filter(el=>el.id !== action.payload.id)
            return newState
        case actionType.UPDATE_CART_ITEM:
            const updatedIndex = state.findIndex(el=>el.id === action.payload.id)
            const updatedState = [...state];
            updatedState[updatedIndex] = action.payload;
            return [...newState];
        case actionType.SUBMIT_CART_RESERVATION:
        return {}
        default:
            return {...state};
    }

};

