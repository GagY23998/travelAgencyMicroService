import React,{useState,useEffect} from "react";
import * as Components from "../Helpers/Components";
import "./Modal.css";


const Modal = ({modalComponent,data})=>{

    const Component = Components[modalComponent];
    const [modalState,setshowModal] = useState();

    useEffect(() => {
        if(data){
            setshowModal(()=>true);
        }
    },[data]);

    const closeModalHandler =(e)=>{
        setshowModal(!modalState);
    }
    const modal = modalState?
    (<div className="Modal">
        <Component item={data}/>
        <button type="button" onClick={closeModalHandler}>Close</button>
    </div>):null

    return modal;
};

export default Modal;
