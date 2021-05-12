import TOffer from "./Offer/TOffer";
 import "./Offers.css";
import {useState,useEffect} from "react";

const TOffers = ({items,modalFunc})=> {
    const [offerState,setOffers] = useState([]);

    useEffect(() => {
        setOffers(items);
        console.log(items);
    }, [items]);
    const offers = (offerState instanceof Array && offerState.length!==0)?offerState.map((e,i)=>{
        return (<TOffer key={"Toffer" + i} showModal={modalFunc} index={i} offerClass={"toffer"} item={e}/>);
    }): <span></span>;
    
    return (
    <div className="transportOffers">
          <span className="section__label">Transport Offers</span>
        <section className="offerSection">
            {offers} 
        </section>
    </div>);
};

export default TOffers;