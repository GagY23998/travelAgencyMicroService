import HOffer from "./Offer/HOffer";
import "./Offers.css";
import {useState,useEffect} from "react";
const HOffers = ({items,modalFunc})=> {
    const [offerState,setOffers] = useState([]);
    useEffect(() => {
        setOffers(items);
        console.log("Hotel items");
        console.log(items);
    }, [items]);
    const offers= (offerState instanceof Array && offerState.length!==0)?offerState.map((e,i)=>{
        return (<HOffer key={i} showModal={modalFunc} index={i} offerClass={"hoffer"} item={e}/>);
    }): <span></span>;
    
    return (
        <div className="hotelOffers">
            <span className="section__label">Hotel Offers</span>
        <section className="offerSection">
        {offers}
    </section>
        </div>
    );
};

export default HOffers;